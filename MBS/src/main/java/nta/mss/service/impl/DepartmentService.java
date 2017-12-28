package nta.mss.service.impl;

import java.lang.reflect.Type;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeSet;

import nta.kcck.model.*;
import nta.kcck.service.impl.KcckApiService;
import nta.mss.entity.Department;
import nta.mss.entity.Hospital;
import nta.mss.info.CalendarInfo;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.CalendarStatus;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.JuniorFlag;
import nta.mss.model.DefaultScheduleModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.ReservationKpiModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorScheduleRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IDepartmentService;

import org.apache.commons.collections.CollectionUtils;
import org.codehaus.jackson.map.ObjectMapper;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.reflect.TypeToken;
import com.google.gson.Gson;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

import javax.persistence.criteria.Predicate;

/**
 * The Class DepartmentService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@Transactional
public class DepartmentService implements IDepartmentService {
//	private static final Logger LOG = LogManager.getLogger(DepartmentService.class);
	private Mapper mapper;
	private DepartmentRepository departmentRepository;
	private ReservationRepository reservationRepository;
	private DoctorScheduleRepository doctorScheduleRepository;
	private HospitalRepository hospitalRepository;
	KcckApiService kcckApiService = new KcckApiService();

    DepartmentService(){

    }
	/**
	 * Instantiates a new department service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param departmentRepository
	 *            the department repository
	 * @param reservationRepository
	 *            the reservation repository
	 * @param doctorScheduleRepository
	 *            the doctor schedule repository
	 * @param hospitalRepository
	 *            the hospital repository
	 */
	@Autowired
	public DepartmentService(Mapper mapper, DepartmentRepository departmentRepository, 
			ReservationRepository reservationRepository, DoctorScheduleRepository doctorScheduleRepository,
			HospitalRepository hospitalRepository) {
		this.mapper = mapper;
		this.departmentRepository = departmentRepository;
		this.reservationRepository = reservationRepository;
		this.doctorScheduleRepository = doctorScheduleRepository;
		this.hospitalRepository = hospitalRepository;
	}
	
	/**
	 * Find department by id.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the department model
	 */
	public DepartmentModel findDepartmentById(Integer deptId) {
		Department department = this.departmentRepository.findOne(deptId);
		return department.toModel(mapper);
	}
	
	/**
	 * Find department by code.
	 *
	 * @param deptCode the dept code
	 * @return the department model
	 */
	public DepartmentModel findDepartmentByCode(String hospitalCode, String deptCode) {
		List<Department> departmentList = this.departmentRepository.findByDeptCode(hospitalCode, deptCode);
		DepartmentModel department = null;
		if (departmentList != null && departmentList.size() != 0) {
			department = departmentList.get(0).toModel(mapper);
		}
		return department;
	}
	
	/**
	 * Check department schedule.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the map
	 */
	public Map<String, Boolean> checkDepartmentSchedule(Integer deptId, String startDate, String endDate) {
		Map<String, Boolean> result = new LinkedHashMap<String, Boolean>();
		Map<String, Long> reservations = this.getReservationByTimeSlot(deptId, startDate, endDate, JuniorFlag.JUNIOR.toInt());
		Map<String, Long> departmentKpi = this.getDepartmentKpiByTimeSlot(deptId, startDate, endDate, JuniorFlag.JUNIOR.toInt());
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : departmentKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (reservations.get(entryKey) != null && reservations.get(entryKey) >= entryValue) {
				result.put(entryKey, false);
			} else {
				result.put(entryKey, entryValue > 0);
			}
		}
		return result;
	}

	public TimeslotScheduleModel getDepartmentTimeslotSchedule(Integer deptId, String startDate, String endDate){
		Map<String, List<KcckBookingSlotModel>> result = new LinkedHashMap<String, List<KcckBookingSlotModel>>();
		Map<String, Long> reservations = this.getReservationByTimeSlot(deptId, startDate, endDate, JuniorFlag.JUNIOR.toInt());
		Map<String, Long> departmentKpi = this.getDepartmentKpiByTimeSlot(deptId, startDate, endDate, JuniorFlag.JUNIOR.toInt());
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : departmentKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (reservations.get(entryKey) != null && reservations.get(entryKey) >= entryValue) {
			} else {
				ArrayList<KcckBookingSlotModel> bookingFrames = new ArrayList<KcckBookingSlotModel>();
				bookingFrames.add(new KcckBookingSlotModel(null, entryKey.substring(9, 13), null,null));
				result.put(entryKey, bookingFrames);
			}
		}
		String avgTime = "30";
		ArrayList<String> timeFrames = new ArrayList<String>(this.doctorScheduleRepository.getTimeslotListByDeptId(deptId));
		if(timeFrames.size() > 2){
			LocalTime lt1 = LocalTime.parse(timeFrames.get(0), DateTimeFormatter.ofPattern("HHmm"));
			LocalTime lt2 = LocalTime.parse(timeFrames.get(1), DateTimeFormatter.ofPattern("HHmm"));
			avgTime = String.valueOf(lt1.until(lt2, ChronoUnit.MINUTES));
		}

		return new TimeslotScheduleModel(
				new ArrayList<String>(this.doctorScheduleRepository.getTimeslotListByDeptId(deptId)),
				result,
				avgTime
		);
	}
	
	/**
	 * Gets the department schedule.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the department schedule
	 */
	public Map<String, ReservationKpiModel> getDepartmentSchedule(Integer deptId, String startDate, String endDate) {
		Map<String, ReservationKpiModel> result = new LinkedHashMap<String, ReservationKpiModel>();
		Map<String, Long> reservations = this.getReservationByTimeSlot(deptId, startDate, endDate, null);
		Map<String, Long> departmentKpi = this.getDepartmentKpiByTimeSlot(deptId, startDate, endDate, null);
		Set<String> keySet = new TreeSet<String>();
		keySet.addAll(reservations.keySet());
		keySet.addAll(departmentKpi.keySet());
		for (String key : keySet) {
			ReservationKpiModel reservationKpi = new ReservationKpiModel();
			Long kpi = departmentKpi.get(key);
			Long reserved = reservations.get(key);
			reservationKpi.setKpi(kpi == null ? Long.valueOf(0) : kpi);
			reservationKpi.setTotalReservation(reserved == null ? Long.valueOf(0) : reserved);
			result.put(key, reservationKpi);
		}
		return result;
	}
	
	/**
	 * Gets the reservation by time slot.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the reservation by time slot
	 */
	private Map<String, Long> getReservationByTimeSlot(Integer deptId, String startDate, String endDate, Integer juniorFlg) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> reservations;
		if (juniorFlg != null) {
			reservations = this.reservationRepository.getReservationsBetweenDateWithJuniorFlg(deptId, startDate, endDate, juniorFlg);
		}
		else {
			reservations = this.reservationRepository.getReservationsBetweenDate(deptId, startDate, endDate);
		}
		if (reservations != null && !reservations.isEmpty()) {
			for (Object[] objects : reservations) {
				result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()), (Long) objects[3]);
			}
		}
		return result;
	}
	
	/**
	 * Gets the department kpi by time slot.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the department kpi by time slot
	 */
	private Map<String, Long> getDepartmentKpiByTimeSlot(Integer deptId, String startDate, String endDate, Integer juniorFlg) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> departmentKpi;
		if (juniorFlg != null) {
			departmentKpi = this.doctorScheduleRepository.calculateDepartmentKpiWithJuniorFlg(deptId, startDate, endDate, juniorFlg);
		}
		else {
			departmentKpi = this.doctorScheduleRepository.calculateDepartmentKpi(deptId, startDate, endDate);
		}
		
		if (departmentKpi != null && !departmentKpi.isEmpty()) {
			for (Object[] objects : departmentKpi) {
				result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()), (Long) objects[3]);
			}
		}
		return result;
	}

	
	/**
	 * Gets the all active department.
	 *
	 * @return the all active department
	 */
	public List<DepartmentModel> getAllActiveDepartment() {
		List<DepartmentModel> lstDepartmentModel = new ArrayList<>();
		List<Department> lstDepartment = this.departmentRepository.findAllActiveDepartment();
		for (Department department : lstDepartment) {
			lstDepartmentModel.add(department.toModel(mapper));
		}
		return lstDepartmentModel;
	}
	
	/**
	 * get all department in hospital.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @return the all department in hospital
	 */
	public List<DepartmentModel> getAllDepartmentInHospital(Integer hospitalId) {
		List<DepartmentModel> lstDepartmentModel = new ArrayList<>();
		List<Department> lstDepartment = this.departmentRepository.findAllDepartmentInHospital(hospitalId);
		for (Department department : lstDepartment) {
			lstDepartmentModel.add(department.toModel(mapper));
		}
		return lstDepartmentModel;
	}
	
	/**
	 * Save department.
	 * 
	 * @author linh.nguyen.trong
	 * @param hospitalId
	 *            the hospital id
	 * @param deptName
	 *            the department name
	 * @param displayOrder
	 *            the display order
	 * @param deptType
	 *            the dept type
	 * @throws Exception
	 *             the exception
	 * @since 24/07/2014 Add department
	 */
	@Override
	public void saveDepartment(Integer hospitalId, String deptCode, String deptName,
			Integer displayOrder, Integer deptType) throws Exception {
		Department department = null;
		department = new Department();
		department.setHospital(this.hospitalRepository.findOne(hospitalId));
		department.setDeptCode(deptCode);
		department.setDeptName(deptName);
		department.setDisplayOrder(displayOrder);
		department.setDeptType(deptType);

		this.departmentRepository.save(department);
	}
	
	/**
	 * Delete department
	 */
	@Override
	public void deleteDepartment(DepartmentModel departmentModel)
			throws Exception {
		Department department = departmentModel.toEntity(mapper);
		department.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		this.departmentRepository.save(department);
	}
	
	/**
	 * Find doctor by order priority.
	 *
	 * @param orderPriority the order priority
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<DepartmentModel> findDepartmentByDisplayOrder(Integer displayOrder)
			throws Exception {
		List<Department> departments = this.departmentRepository.findByDisplayOrder(displayOrder);
		List<DepartmentModel> departmentModels = new ArrayList<DepartmentModel>();
		if(departments != null && !departments.isEmpty()) {
			for(Department d : departments) {
				departmentModels.add(d.toModel(mapper));
			}
		}
		return departmentModels;
	}
	
	/**
	 * Check department schedule in day.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the list
	 */
	public Map<String, Integer> checkDepartmentScheduleInDay(Integer deptId, String startDate, String endDate) {
		Map<String, Integer> result = new LinkedHashMap<String, Integer>();
		Map<String, Long> reservations = this.getReservationByDay(deptId, startDate, endDate);
		Map<String, Long> departmentKpi = this.getDepartmentKpiByDay(deptId, startDate, endDate);
		Integer status;
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : departmentKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (entryValue != 0) {
				if (reservations.get(entryKey) == null) {
					status = CalendarStatus.NONE.toInt();
				} 
				else if (reservations.get(entryKey) < entryValue){
					status = CalendarStatus.HALF_FULL.toInt();
				} 
				else {
					status = CalendarStatus.FULL.toInt();
				}
			}
			else {
				status = CalendarStatus.FULL.toInt();
			}
			result.put(entryKey, status);	
		}
		return result;
	}
	
	/**
	 * Gets the reservation by day.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the reservation by day
	 */
	private Map<String, Long> getReservationByDay(Integer deptId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> reservations;
		reservations = this.reservationRepository.getReservationsByDayBetweenDate(deptId, startDate, endDate);
		if (reservations != null && !reservations.isEmpty()) {
			for (Object[] objects : reservations) {
				result.put(MssDateTimeUtil.convertStringDate(objects[0].toString(), DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND), (Long) objects[1]);
			}
		}
		return result;
	}
	
	/**
	 * Gets the department kpi by day.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the department kpi by day
	 */
	private Map<String, Long> getDepartmentKpiByDay(Integer deptId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> departmentKpi;
		departmentKpi = this.doctorScheduleRepository.calculateDepartmentKpiByDay(deptId, startDate, endDate);		
		if (departmentKpi != null && !departmentKpi.isEmpty()) {
			for (Object[] objects : departmentKpi) {
				result.put(MssDateTimeUtil.convertStringDate(objects[0].toString(), DateTimeFormat.DATE_FORMAT_YYYYMMDD, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND), (Long) objects[1]);
			}
		}
		return result;
	}
	
	/**
	 * Check department schedule in timeslot.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the map
	 */
	public Map<String, List<CalendarInfo>> checkDepartmentScheduleInTimeslot(Integer deptId, String startDate, String endDate) {
		Map<String, List<CalendarInfo>> result = new LinkedHashMap<String, List<CalendarInfo>>();
		Map<String, Long> reservations = this.getReservationByTimeslot(deptId, startDate, endDate);
		Map<String, Long> departmentKpi = this.getDepartmentKpiByTimeslot(deptId, startDate, endDate);
		List<CalendarInfo> calendarInfoList;
		CalendarInfo cal;
		Boolean isAdded;
		String dateKey;
		String timeKey;
		// now
		Date now = new Date();
		Date date;
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : departmentKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			isAdded = false;
			dateKey = entryKey.split(" ")[0];
			timeKey = entryKey.split(" ")[1];
			date = MssDateTimeUtil.dateFromString(entryKey, DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND);
			if (!date.before(now)) {
				if (entryValue != 0) {
					cal = new CalendarInfo();
					if (reservations.get(entryKey) == null) {
						cal.setStatus(CalendarStatus.NONE.toInt());
						isAdded = true;
					} 
					else if (reservations.get(entryKey) < entryValue){
						cal.setStatus(CalendarStatus.HALF_FULL.toInt());
						isAdded = true;
					}
					if (isAdded) {
						cal.setCheckedDate(MssDateTimeUtil.convertStringDate(dateKey, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, DateTimeFormat.DATE_FORMAT_YYYYMMDD));
						cal.setStartDateTime(MssDateTimeUtil.convertStringDate(timeKey, DateTimeFormat.TIME_FORMAT_HH_MM_DEFAULT, DateTimeFormat.TIME_FORMAT_HH_MM));
						cal.setFormattedStartDateTime(timeKey);
						calendarInfoList = new ArrayList<CalendarInfo>();
						if (result.containsKey(dateKey)) {
							calendarInfoList = result.get(dateKey);
						}
						calendarInfoList.add(cal);
						result.put(dateKey, calendarInfoList);
					}
				}
			}
		}  
		return result;
	}
	
	/**
	 * Gets the reservation by timeslot.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the reservation by timeslot
	 */
	private Map<String, Long> getReservationByTimeslot(Integer deptId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> reservations;
		reservations = this.reservationRepository.getReservationsByTimeslotBetweenDate(deptId, startDate, endDate);
		if (reservations != null && !reservations.isEmpty()) {
			for (Object[] objects : reservations) {
				result.put(MssDateTimeUtil.convertStringDateTime(objects[0].toString(), objects[1].toString(), DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM, DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND), (Long) objects[2]);
			}
		}
		return result;
	}
	
	/**
	 * Gets the department kpi by timeslot.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the department kpi by timeslot
	 */
	private Map<String, Long> getDepartmentKpiByTimeslot(Integer deptId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> departmentKpi;
		departmentKpi = this.doctorScheduleRepository.calculateDepartmentKpiByTimeslot(deptId, startDate, endDate);		
		if (departmentKpi != null && !departmentKpi.isEmpty()) {
			String formattedStartDateTime;
			for (Object[] objects : departmentKpi) {
				formattedStartDateTime = MssDateTimeUtil.convertStringDateTime(objects[0].toString(), objects[1].toString(), DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM, DateTimeFormat.DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND);
				result.put(formattedStartDateTime, (Long) objects[3]);
			}
		}
		return result;
	}
	
	public DepartmentModel findDeptByType(String hospCode, Integer deptType) throws Exception {

		List<Hospital> hospitalList = this.hospitalRepository.findByHospitalCode(hospCode);
		if(!CollectionUtils.isEmpty(hospitalList))
		{
			List<Department> lstDepartment = this.departmentRepository.findDepartmentByType(hospitalList.get(0).getHospitalId(), deptType);
			if (CollectionUtils.isNotEmpty(lstDepartment)) {
				return lstDepartment.get(0).toModel(mapper);
			}
		}
		return null;
	}
	//list department in hopital from KCCK DB
	@Override
	public List<DepartmentModel> getAllDepartmentInHospitalbyParentId(Integer hospitalId, Integer parentId) {
		// TODO Auto-generated method stub
		return null;
	}
	
}
