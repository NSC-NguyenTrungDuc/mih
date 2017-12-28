package nta.mss.service.impl;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import nta.mss.entity.Department;
import nta.mss.entity.DepartmentSchedule;
import nta.mss.entity.Doctor;
import nta.mss.entity.DoctorSchedule;
import nta.mss.entity.DoctorSchedulePK;
import nta.mss.entity.Hospital;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.model.DepartmentScheduleModel;
import nta.mss.model.DoctorScheduleModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DepartmentScheduleRepository;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.DoctorScheduleRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IDoctorScheduleService;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * The Class DoctorScheduleService. 
 *
 * @author MinhLS
 * @crtDate Aug 2, 2014
 */
@Service
@Transactional
public class DoctorScheduleService implements IDoctorScheduleService {

	private Mapper mapper;
	private DoctorScheduleRepository doctorScheduleRepository;
	private DepartmentScheduleRepository departmentScheduleRepository;
	private HospitalRepository hospitalRepository;
	private DepartmentRepository departmentRepository;
	private ReservationRepository reservationRepository;
	private DoctorRepository doctorRepository;
	
    public DoctorScheduleService() {
    }

    @Autowired
	public DoctorScheduleService(Mapper mapper, DoctorScheduleRepository doctorScheduleRepository, 
			DepartmentScheduleRepository departmentScheduleRepository, HospitalRepository hospitalRepository, 
			DepartmentRepository departmentRepository, ReservationRepository reservationRepository, DoctorRepository doctorRepository) {
		this.mapper = mapper;
		this.doctorScheduleRepository = doctorScheduleRepository;
		this.departmentScheduleRepository = departmentScheduleRepository;
		this.hospitalRepository = hospitalRepository;
		this.departmentRepository = departmentRepository;
		this.reservationRepository = reservationRepository;
		this.doctorRepository = doctorRepository;
	}
	
	/**
	 * Gets the monthly department kpi.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the monthly department kpi
	 * @throws ParseException 
	 */
	public Map<DoctorScheduleModel, Integer> getMonthlyDepartmentKpi(Integer deptId, String startDate, String endDate) throws ParseException {
		List<DoctorScheduleModel> doctorScheduleList = this.getDoctorScheduleKpi(deptId, startDate, endDate);
		List<DepartmentScheduleModel> departmentScheduleList = this.getDefaultDepartmentKpi(deptId);
		Map<DoctorScheduleModel, Integer> result = new HashMap<DoctorScheduleModel, Integer>();
		Map<String, List<String>> daysInWeekMap = MssDateTimeUtil.getDaysInWeekMapBetween(startDate, endDate);
		
		DoctorScheduleModel ds;
		Integer kpi;
		String applyDate;
		List<String> dateList;
		// add the default coma to monthly setting
		for(DepartmentScheduleModel departmentSchedule : departmentScheduleList) {
			String startTime = departmentSchedule.getStartTime();
			Integer doctorId = departmentSchedule.getDoctorId();
			String endTime = departmentSchedule.getEndTime();
			kpi = departmentSchedule.getKpi();
			applyDate = departmentSchedule.getApplyDate();
			dateList = daysInWeekMap.get(departmentSchedule.getDay());
			if (dateList != null) {
				for(String date : dateList) {
					// compare apply date with the date in monthly setting
					if(MssDateTimeUtil.compareDateString(applyDate, date)) {
						ds = new DoctorScheduleModel();
						ds.setCheckDate(date);
						ds.setStartTime(startTime);
						ds.setDoctorId(doctorId);
						ds.setEndTime(endTime);
						result.put(ds, kpi);
					}
				}
			}
		}
		
		// add the doctor schedule to monthly setting
		for(DoctorScheduleModel doctorSchedule : doctorScheduleList) {
			result.put(doctorSchedule, doctorSchedule.getKpi());
		}
		return result;
	}
	
	/**
	 * Update doctor schedule.
	 *
	 * @param doctorScheduleModel the doctor schedule model
	 * @return true, if successful
	 */
	public boolean updateDoctorSchedule(DoctorScheduleModel dsm) {
		DoctorSchedule ds = this.doctorScheduleRepository.findOne(new DoctorSchedulePK(dsm.getDoctorId(), dsm.getCheckDate(), dsm.getStartTime()));
		ds.setActiveFlg(dsm.getActiveFlg());
		ds.setKpi(dsm.getKpi());
		ds = this.doctorScheduleRepository.save(ds);
		if (ds == null) {
			return false;
		}
		return true;
	}
	
	/**
	 * Gets the default department kpi.
	 *
	 * @param deptId the dept id
	 * @return the default department kpi
	 */
	private List<DepartmentScheduleModel> getDefaultDepartmentKpi(Integer deptId) {
		List<DepartmentScheduleModel> result = new ArrayList<DepartmentScheduleModel>();
		List<DepartmentSchedule> departmentScheduleList = this.departmentScheduleRepository.getDefaultDepartmentKpi(deptId);
		for(DepartmentSchedule departmentSchedule : departmentScheduleList) {
			result.add(departmentSchedule.toModel(mapper));
		}
		return result;
	}

	/**
	 * Gets the doctor schedule kpi.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the doctor schedule kpi
	 */
	private List<DoctorScheduleModel> getDoctorScheduleKpi(Integer deptId, String startDate, String endDate) {
		List<DoctorScheduleModel> result = new ArrayList<DoctorScheduleModel>();
		List<DoctorSchedule> doctorScheduleList = this.doctorScheduleRepository.findDoctorScheduleByDeptIdAndCheckDate(deptId, startDate, endDate);
		for(DoctorSchedule doctorSchedule : doctorScheduleList) {
			result.add(doctorSchedule.toModel(mapper));
		}
		return result;
	}
	
	/**
	 * Update monthly coma.
	 *
	 * @param monthlyComaMap the monthly coma map
	 * @return true, if successful
	 */
	public boolean updateMonthlyComa(Map<DoctorSchedulePK, DoctorScheduleModel> monthlyComaMap, Integer hospitalId, Integer deptId) {
		boolean success = true;
		try{
			if(monthlyComaMap != null) {
				if(monthlyComaMap.size() != 0) {
					Hospital hospital = this.hospitalRepository.findOne(hospitalId);
					Department department = this.departmentRepository.findOne(deptId);
					List<DoctorSchedule> doctorScheduleList = new ArrayList<DoctorSchedule>();
					DoctorSchedule ds;
					DoctorScheduleModel dsm;
					DoctorSchedulePK entryKey;
					DoctorScheduleModel entryValue;
					for (Entry<DoctorSchedulePK, DoctorScheduleModel> entry : monthlyComaMap.entrySet()) {
						entryKey = entry.getKey();
						entryValue = entry.getValue();
						ds = new DoctorSchedule();
						dsm = entryValue;
						ds.setId(entryKey);
						ds.setKpi(dsm.getKpi());
						ds.setHospital(hospital);
						ds.setDepartment(department);
						ds.setEndTime(dsm.getEndTime());
						doctorScheduleList.add(ds);
					}
					// save to db
					this.doctorScheduleRepository.save(doctorScheduleList);
				}
			}
		} catch (Exception e) {
			success = false;
		}
		return success;
	}
	
	/**
	 * Gets the doctor schedule by dept id and timeslot.
	 *
	 * @param deptId the dept id
	 * @param checkDate the check date
	 * @param startTime the start time
	 * @return the doctor schedule by dept id and timeslot
	 */
	public List<DoctorScheduleModel> getDoctorScheduleByDeptIdAndTimeslot(Integer deptId, String checkDate, String startTime) {
		List<DoctorScheduleModel> result = new ArrayList<DoctorScheduleModel>();
		List<DoctorSchedule> doctorScheduleList = this.doctorScheduleRepository.findDoctorByDeptIdAndTimeSlot(deptId, checkDate, startTime);
		for(DoctorSchedule ds : doctorScheduleList) {
			result.add(ds.toModel(mapper));
		}
		return result;
	}
	
	/**
	 * Cancel doctor schedule by id in list.
	 *
	 * @param doctorSchedulePKSet the doctor schedule pk set
	 * @return true, if successful
	 */
	public boolean cancelDoctorScheduleByIdInList(Collection<DoctorSchedulePK> doctorSchedulePKs) {
		boolean result = false;
		if (doctorSchedulePKs.size() > 0) {
			this.doctorScheduleRepository.cancelDoctorScheduleByIdInList(doctorSchedulePKs);
			result = true;
		}
		return result;
	}
	
	/**
	 * Checks if is doctor schedule full.
	 *
	 * @param doctorId the doctor id
	 * @param checkDate the check date
	 * @param startTime the start time
	 * @return true, if is doctor schedule full
	 */
	@Override
	public boolean isDoctorScheduleFull(Integer doctorId, String checkDate, String startTime) {
		boolean result = false;
		DoctorSchedulePK doctorSchedulePK = new DoctorSchedulePK(doctorId, checkDate, startTime);
		Integer kpi = this.doctorScheduleRepository.findOne(doctorSchedulePK).getKpi();
		Object[] reservations = this.reservationRepository.countDoctorReservationsByTimeSlot(doctorId, checkDate, startTime);
		Long numberOfReservations = Long.valueOf(0);
		if (reservations != null) {
			numberOfReservations = (Long) reservations[0];
		}
		if (kpi <= numberOfReservations) {
			result = true;
		}
		return result;
	}

	/**
	 * Gets the by doctor schedule pk.
	 *
	 * @param doctorSchedulePK the doctor schedule pk
	 * @return the by doctor schedule pk
	 */
	@Override
	public DoctorScheduleModel getByDoctorSchedulePK(
			DoctorSchedulePK doctorSchedulePK) {
		DoctorSchedule doctorSchedule = this.doctorScheduleRepository.findOne(doctorSchedulePK);
		if (doctorSchedule == null) {
			return null;
		} 
		return doctorSchedule.toModel(mapper);
	}

	/**
	 * Update doctor schedule.
	 *
	 * @param doctorScheduleModel the doctor schedule model
	 * @return true, if successful
	 * @throws Exception the exception
	 */
	@Override
	public void addDoctorSchedule(DoctorScheduleModel doctorScheduleModel)
			throws Exception {
		DoctorSchedule doctorSchedule = new DoctorSchedule();
		DoctorSchedulePK doctorSchedulePK = new DoctorSchedulePK(doctorScheduleModel.getDoctorId(), doctorScheduleModel.getCheckDate(), doctorScheduleModel.getStartTime());
		doctorSchedule.setId(doctorSchedulePK);
		Department department = this.departmentRepository.findOne(doctorScheduleModel.getDeptId());
		doctorSchedule.setDepartment(department);
		Doctor doctor = this.doctorRepository.findOne(doctorScheduleModel.getDoctorId());
		doctorSchedule.setDoctor(doctor);
		Hospital hospital = this.hospitalRepository.findOne(doctorScheduleModel.getHospitalId());
		doctorSchedule.setHospital(hospital);
		doctorSchedule.setEndTime(doctorScheduleModel.getEndTime());
		doctorSchedule.setKpi(doctorScheduleModel.getKpi());
		this.doctorScheduleRepository.save(doctorSchedule);
	}
	
	/**
	 * Gets the timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by department
	 */
	@Override
	public List<String> getTimeslotListByDepartment(Integer deptId) {
		return this.doctorScheduleRepository.getTimeslotListByDeptId(deptId);
	}
	
	/**
	 * Gets the full timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by department
	 */
	@Override
	public List<String> getFullTimeslotListByDepartment(Integer deptId) {
		return this.departmentScheduleRepository.getFullTimeslotListByDeptId(deptId);
	}
}
