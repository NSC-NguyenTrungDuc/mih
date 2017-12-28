package nta.mss.service.impl;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeSet;

import nta.mss.converter.CsvConverter;
import nta.mss.entity.Department;
import nta.mss.entity.Doctor;
import nta.mss.entity.DoctorSchedule;
import nta.mss.entity.Hospital;
import nta.mss.info.DoctorInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.CsvErrorCode;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.JuniorFlag;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.ReservationKpiModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorInfroRepositoryCustom;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.DoctorScheduleRepository;
import nta.mss.repository.DoctorScheduleRepositoryCustom;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IDoctorService;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.codehaus.jackson.map.ObjectMapper;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.collect.Lists;
import com.google.common.collect.Ordering;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import com.google.gson.Gson;
import nta.kcck.model.DoctorModelInfo;
import nta.kcck.model.KcckDepartmentModel;
import nta.kcck.model.MessageResponse;

import com.google.common.reflect.TypeToken;
/**
 * The Class DoctorService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@Transactional
public class DoctorService implements IDoctorService {
	private static Logger LOG = LogManager.getLogger(DoctorService.class);
	
	private Mapper mapper;
	private DoctorScheduleRepository doctorScheduleRepository;
	private ReservationRepository reservationRepository;
	private DoctorRepository doctorRepository;
	private DepartmentRepository departmentRepository;
	private HospitalRepository	hospitalRepository;
	private DoctorInfroRepositoryCustom doctorInfroRepositoryCustom;
	private DoctorScheduleRepositoryCustom doctorScheduleRepositoryCustom;
    public DoctorService() {
    }

    /**
	 * Instantiates a new doctor service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param doctorScheduleRepository
	 *            the doctor schedule repository
	 * @param reservationRepository
	 *            the reservation repository
	 * @param doctorRepository
	 *            the doctor repository
	 * @param departmentRepository
	 *            the department repository
	 */
	@Autowired
	public DoctorService(Mapper mapper, DoctorScheduleRepository doctorScheduleRepository, ReservationRepository reservationRepository, DoctorRepository doctorRepository, DepartmentRepository departmentRepository,
			HospitalRepository	hospitalRepository, DoctorInfroRepositoryCustom doctorInfroRepositoryCustom, DoctorScheduleRepositoryCustom doctorScheduleRepositoryCustom) {
		this.mapper = mapper;
		this.doctorScheduleRepository = doctorScheduleRepository;
		this.reservationRepository = reservationRepository;
		this.doctorRepository = doctorRepository;
		this.departmentRepository = departmentRepository;
		this.hospitalRepository = hospitalRepository;
		this.doctorInfroRepositoryCustom = doctorInfroRepositoryCustom;
		this.doctorScheduleRepositoryCustom = doctorScheduleRepositoryCustom;
	}
	
	/**
	 * Gets the doctor by doctor id.
	 * 
	 * @param doctId
	 *            the doct id
	 * @return the doctor by doctor id
	 */
	public DoctorModel getDoctorByDoctorId(Integer doctId) {
		Doctor doctor = this.doctorRepository.findOne(doctId);
		return doctor == null ? null : doctor.toModel(this.mapper);
	}
	
	/**
	 * Find doctors by department.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the list doctors
	 */
	public List<DoctorModel> findDoctorsByDepartment(Integer deptId) {
		List<DoctorModel> result = new ArrayList<DoctorModel>();
		List<Doctor> doctorsList = this.doctorRepository.findByDeptId(deptId);
		if (doctorsList != null) {
			for (Doctor doctor : doctorsList) {
				result.add(doctor.toModel(this.mapper));
			}
		}
		return result;
	}

	/**
	 * Find available doctor.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the doctor model
	 */
	public DoctorModel findAvailableDoctor(Integer deptId, String checkDate, String startTime) {
		List<DoctorSchedule> listDoctorSchedules = this.doctorScheduleRepository.findDoctorByDeptIdAndTimeSlot(deptId, checkDate, startTime);
		
		if (listDoctorSchedules.isEmpty()) {
			return null;
		}
		List<Integer> doctorIds = new ArrayList<Integer>();
		for (DoctorSchedule doctorSchedule : listDoctorSchedules) {
			doctorIds.add(doctorSchedule.getDoctor().getDoctorId());
		}
		
		Map<Integer, Long> doctorReservation = this.getReservationByDoctors(doctorIds, checkDate, startTime);
		Map<Doctor, Long> mapDoctorAvailable = new HashMap<Doctor, Long>();
		if (!doctorReservation.isEmpty()) {
			for (DoctorSchedule doctorSchedule : listDoctorSchedules) {
				Doctor doct = doctorSchedule.getDoctor();
				Long reservationNumbers = doctorReservation.get(doct.getDoctorId());
				if (JuniorFlag.JUNIOR.toInt().equals(doct.getJuniorFlg())) {
					if (reservationNumbers == null || doctorSchedule.getKpi() > reservationNumbers) {
						return doct.toModel(mapper);
					}
				} else {
					if (reservationNumbers != null) {
						mapDoctorAvailable.put(doct, doctorSchedule.getKpi() - reservationNumbers);
					}
				}
			}
		} else {
			for (DoctorSchedule doctorSchedule : listDoctorSchedules) {
				Doctor doct = doctorSchedule.getDoctor();
				if (JuniorFlag.JUNIOR.toInt().equals(doct.getJuniorFlg())) {
					return doct.toModel(mapper);
				}
			}
			return listDoctorSchedules.get(0).getDoctor().toModel(mapper);
		}
		
		Ordering<Map.Entry<Doctor, Long>> byMapValues = new Ordering<Map.Entry<Doctor, Long>>() {
			@Override
			public int compare(Map.Entry<Doctor, Long> left, Map.Entry<Doctor, Long> right) {
				return left.getValue().compareTo(right.getValue());
			}
		};
		List<Map.Entry<Doctor, Long>> listDoctor = Lists.newArrayList(mapDoctorAvailable.entrySet());
		Collections.sort(listDoctor, byMapValues);
		
		return listDoctor.isEmpty() ? null : listDoctor.get(0).getKey().toModel(mapper);
	}
	
	/**
	 * Check doctor schedule.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the map
	 */
	@Override
	public Map<String, Boolean> checkDoctorSchedule(Integer doctorId, String startDate, String endDate) {
		Map<String, Boolean> result = new LinkedHashMap<String, Boolean>();
		Map<String, Long> reservations = this.getDoctorReservationByTimeSlot(doctorId, startDate, endDate);
		Map<String, Long> doctorKpi = this.getDoctorKpiByTimeSlot(doctorId, startDate, endDate);
		String entryKey;
		Long entryValue;
		for (Entry<String, Long> entry : doctorKpi.entrySet()) {
			entryKey = entry.getKey();
			entryValue = entry.getValue();
			if (!reservations.isEmpty() && reservations.containsKey(entryKey)) {
				if (reservations.get(entryKey) >= entryValue) {
					result.put(entryKey, false);
				} else {
					result.put(entryKey, true);
				}
			}
			else {
				result.put(entryKey, true);
			}
		}
		return result;
	}
	
	/**
	 * Gets the doctor schedule.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor schedule
	 */
	@Override
	public Map<String, ReservationKpiModel> getDoctorSchedule(Integer doctorId, String startDate, String endDate) {
		Map<String, ReservationKpiModel> result = new LinkedHashMap<String, ReservationKpiModel>();
		Map<String, Long> reservations = this.getDoctorReservationByTimeSlot(doctorId, startDate, endDate);
		Map<String, Long> doctorKpi = this.getDoctorKpiByTimeSlot(doctorId, startDate, endDate);
		Set<String> keySet = new TreeSet<String>();
		keySet.addAll(reservations.keySet());
		keySet.addAll(doctorKpi.keySet());
		for (String key : keySet) {
			ReservationKpiModel reservationKpi = new ReservationKpiModel();
			Long kpi = doctorKpi.get(key);
			Long reserved = reservations.get(key);
			reservationKpi.setKpi(kpi == null ? Long.valueOf(0) : kpi);
			reservationKpi.setTotalReservation(reserved == null ? Long.valueOf(0) : reserved);
			result.put(key, reservationKpi);
		}
		return result;
	}
	
	/**
	 * Gets the doctor reservation by time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor reservation by time slot
	 */
	private Map<String, Long> getDoctorReservationByTimeSlot(Integer doctorId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> reservations = this.reservationRepository.getDoctorReservationsBetweenDate(doctorId, startDate, endDate);
		if (reservations != null) {
			if (!reservations.isEmpty()) {
				for (Object[] objects : reservations) {
					result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()), (Long) objects[3]);
				}
			}
		}
		return result;
	}
	
	/**
	 * Gets the doctor kpi by time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor kpi by time slot
	 */
	private Map<String, Long> getDoctorKpiByTimeSlot(Integer doctorId, String startDate, String endDate) {
		Map<String, Long> result = new LinkedHashMap<String, Long>();
		List<Object[]> doctorKpi = this.doctorScheduleRepository.calculateDoctorKpi(doctorId, startDate, endDate);
		if (doctorKpi != null) {
			if (!doctorKpi.isEmpty()) {
				for (Object[] objects : doctorKpi) {
					result.put(MssDateTimeUtil.concatenateDateTime(objects[1].toString(), objects[2].toString()), (Long) objects[3]);
				}
			}
		}
		return result;
	}
	
	/**
	 * Gets the reservation by doctors.
	 * 
	 * @param doctorIds
	 *            the doctor ids
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the reservation by doctors
	 */
	private Map<Integer, Long> getReservationByDoctors(List<Integer> doctorIds, String checkDate, String startTime) {
		Map<Integer, Long> result = new LinkedHashMap<Integer, Long>();
		List<Object[]> reservationCount = this.reservationRepository.countReservationByDoctorAndTime(doctorIds, checkDate, startTime);
		if (reservationCount != null && !reservationCount.isEmpty()) {
			for (Object[] objects : reservationCount) {
				result.put((Integer) objects[0], (Long) objects[1]); 
			}
		}
		return result;
	}

	
	/**
	 * Gets the doctors by department.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the doctors by department
	 */
	public Map<Integer, String> getDoctorsByDepartment(Integer deptId) {
		Map<Integer, String> results = new HashMap<Integer, String>();
		List<Doctor> lstDoctor = this.doctorRepository.findByDeptId(deptId);
		if(!lstDoctor.isEmpty()) {
			for (Doctor doctor : lstDoctor) {
				results.put(doctor.getDoctorId(), doctor.getName());
			}
		}
		return results;
	}

	/**
	 * Adds the doctor.
	 * 
	 * @author linh.nguyen.trong
	 * @param deptId
	 *            the department id
	 * @param name
	 *            the doctor name
	 * @param orderPriority
	 *            the order priority
	 * @throws Exception
	 *             the exception
	 * @since 25/07/2014
	 * 
	 *        Add Doctor
	 */
	@Override
	public DoctorModel addDoctor(Integer deptId, String name, Integer orderPriority)
			throws Exception {
		Doctor doctor = new Doctor();
		doctor.setDepartment(this.departmentRepository.findOne(deptId));
		doctor.setName(name);
		doctor.setOrderPriority(orderPriority);
		doctor.setJuniorFlg(JuniorFlag.JUNIOR.toInt());
		return this.doctorRepository.save(doctor).toModel(mapper);
	}
	
	@Override
	public List<DoctorModel> processDoctorCsv(String name){
		List<DoctorModel> result = new ArrayList<DoctorModel>();
		LOG.info("[start] processDoctorCsv " + name);
		try {
			List<Doctor> listDoctors = new ArrayList<>();
			String filePath = MssConfiguration.getInstance().getDirFileUpload() + "/" + name;
			CsvConverter csvConverter = new CsvConverter();
			List<Entry<DoctorInfo, CsvErrorCode>> listCsvData = csvConverter.parseFromCsv(filePath);
			if (listCsvData != null && listCsvData.size() > 0) {
	            for (int rowNo = 1; rowNo <= listCsvData.size(); rowNo++) {
	                Entry<DoctorInfo, CsvErrorCode> mapDoctorInfo = listCsvData.get(rowNo - 1);
	                if (mapDoctorInfo.getValue() != null) {
	                    writeErrorLog(rowNo, mapDoctorInfo.getValue().name());
	                    continue;
	                }
	                DoctorInfo doctorInfo = mapDoctorInfo.getKey();
	                if (doctorInfo == null) {
	                    LOG.debug("AccountInfo is null");
	                    continue;
	                }

	                CsvErrorCode errorCode = validateCsvData(doctorInfo, rowNo);
	                if (!CsvErrorCode.VALID.toInt().equals(errorCode.toInt())) {
	                    writeErrorLog(rowNo, errorCode.name());
	                } else {
	                	try {
		                	Hospital hospital = new Hospital();
		                	List<Hospital> hospitalList = this.hospitalRepository.findByHospitalCode(doctorInfo.getHospitalCode());
		                	if (hospitalList == null || hospitalList.isEmpty()) {
		                		hospital.setHospitalCode(doctorInfo.getHospitalCode());
		                		hospital.setHospitalName(doctorInfo.getHospitalName());
		                		hospital = hospitalRepository.save(hospital);
		                	} else {
		                		hospital = hospitalList.get(0);
		                	}
		                	
		                	Department department = new Department();
		                	List<Department> departmentList = departmentRepository.findDepartmentInHospital(hospital.getHospitalId(), doctorInfo.getDepartmentCode());
		                	if (departmentList == null || departmentList.isEmpty()) {
		                		department.setHospital(hospital);
		                		department.setDeptCode(doctorInfo.getDepartmentCode());
		                		department.setDeptName(doctorInfo.getDepartmentName());
		                		department.setDeptType(Integer.valueOf(doctorInfo.getDepartmentType()));
		                		department.setDisplayOrder(Integer.valueOf(doctorInfo.getDepartmentOrder()));
		                		department = departmentRepository.save(department);
		                	} else {
		                		department = departmentList.get(0);
		                	}
		                	
		                	Doctor doctor = new Doctor();
		                	doctor.setDepartment(department);
		                	doctor.setJuniorFlg(Integer.valueOf(doctorInfo.getJuniorFlg()));
		                	doctor.setKpiAvg(Integer.valueOf(doctorInfo.getKpi()));
		                	doctor.setName(doctorInfo.getDoctorName());
		                	doctor.setOrderPriority(Integer.valueOf(doctorInfo.getDoctorOrder()));
		                	listDoctors.add(doctor);
	                	} catch (Exception e) {
	                		LOG.error("Error occurred while save data of row:" + rowNo + " => " + e.getMessage(), e);
	                	}
	                }
	            }
	            
	            if (listDoctors.size() > 0) {
	            	List<Doctor> doctorList = doctorRepository.save(listDoctors);
	            	for (Doctor doctor : doctorList) {
	            		result.add(doctor.toModel(mapper));
	            	}
	            }
	        }
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
		LOG.info("[end] processDoctorCsv " + name);
		return result;
	}
	
	private CsvErrorCode validateCsvData(DoctorInfo doctorInfo, Integer rowNo) {
		String hospitalCode = doctorInfo.getHospitalCode();
		String hospitalName = doctorInfo.getHospitalName();
		String departmentCode = doctorInfo.getDepartmentCode();
		String departmentName = doctorInfo.getDepartmentName();
		String doctorName = doctorInfo.getDoctorName();
		String doctorOrder = doctorInfo.getDoctorOrder();
		String deptType = doctorInfo.getDepartmentType();
		String departmentOrder = doctorInfo.getDepartmentOrder();
		String juniorFlg = doctorInfo.getJuniorFlg();
		String kpi = doctorInfo.getKpi();
		if (StringUtils.isBlank(hospitalCode) || StringUtils.isBlank(departmentCode) || StringUtils.isBlank(doctorName)
				|| StringUtils.isBlank(doctorOrder) || StringUtils.isBlank(deptType) || StringUtils.isBlank(departmentOrder) 
				|| StringUtils.isBlank(juniorFlg) || StringUtils.isBlank(kpi)) {
			LOG.warn("[Import doctor csv] ErrorCode = REQUIRED_DATA. " + doctorInfo.toString());
			return CsvErrorCode.REQUIRED_DATA;
		}
		if (!juniorFlg.equals(String.valueOf(ActiveFlag.ACTIVE.toInt())) && !juniorFlg.equals(String.valueOf(ActiveFlag.INACTIVE.toInt()))) {
			LOG.warn("[Import doctor csv] juniorFlg is invalid. " + doctorInfo.toString());
			return CsvErrorCode.WRONG_FORMAT;
		}
		if (hospitalCode.length() > 16 || departmentCode.length() > 32 || doctorName.length() > 64 || doctorOrder.length() > 9 
				|| departmentOrder.length() > 9 || kpi.length() > 9 || hospitalName.length() > 256 || departmentName.length() > 256) {
			LOG.warn("[Import doctor csv] ErrorCode = WRONG_SIZE. " + doctorInfo.toString());
			return CsvErrorCode.WRONG_SIZE;
		}
		return CsvErrorCode.VALID;
	}

	private void writeErrorLog(Integer rowNo, String errorCode) {
        LOG.warn("Error occurred while verifying the row:" + rowNo + "+ error code = " + errorCode);
    }

	/**
	 * Update junior flg for doctor
	 * 
	 */
	@Override
	public void updateJuniorFlgForDoctor(DoctorModel doctorModel)
			throws Exception {
		Doctor doctor = doctorModel.toEntity(mapper);
		this.doctorRepository.save(doctor);
		
	}

	/**
	 * Find doctor by order priority 
	 * 
	 * @param orderPriority
	 * @return list
	 * @throws Exception
	 */
	public List<DoctorModel> findDoctorByOrderPriority(Integer orderPriority)
			throws Exception {
		List<Doctor> doctors = this.doctorRepository.findByOrderPriority(orderPriority);
		List<DoctorModel> doctorModels = new ArrayList<DoctorModel>();
		if(doctors != null && !doctors.isEmpty()) {
			for(Doctor d : doctors) {
				doctorModels.add(d.toModel(mapper));
			}
		}
		return doctorModels;
	}
    
	/**
	 * Find all doctor info.
	 *
	 * @return the list
	 * @throws Exception the exception
	 */
	@Override
	public List<DoctorInfo> findAllDoctorInfo(Integer hospitalId) throws Exception {
		List<Object[]> lstObjDoctorInfo = this.doctorInfroRepositoryCustom.findAllDoctorInfo(hospitalId);
		if (lstObjDoctorInfo == null || lstObjDoctorInfo.isEmpty()) {
			return null;
		}
		List<DoctorInfo> lstDoctorInfo = new ArrayList<DoctorInfo>();
		for (Object[] objects : lstObjDoctorInfo) {
			DoctorInfo doctorInfo = new DoctorInfo();
			doctorInfo.setHospitalCode((String) objects[0]);
			if (objects[1] != null) {
				doctorInfo.setHospitalName((String) objects[1]);
			}
			doctorInfo.setDepartmentCode((String) objects[2]);
			if (objects[3] != null) {
				doctorInfo.setDepartmentName((String) objects[3]);
			}
			if (objects[4] != null) {
				doctorInfo.setDepartmentType(objects[4].toString());
			}
			if (objects[5] != null) {
				doctorInfo.setDepartmentOrder(objects[5].toString());
			}
			if (objects[6] != null) {
				doctorInfo.setDoctorName((String) objects[6]);
			}
			if (objects[7] != null) {
				doctorInfo.setDoctorOrder(objects[7].toString());
			}
			if (objects[8] != null) {
				doctorInfo.setJuniorFlg(objects[8].toString());
			}
			if (objects[9] != null) {
				doctorInfo.setKpi(objects[9].toString());
			}
			lstDoctorInfo.add(doctorInfo);
		}
		return lstDoctorInfo;
	}

	/**
	 * Copy doctor schedule.
	 *
	 * @param copyDoctorId the copy doctor id
	 * @param doctorId the doctor id
	 * @return true, if successful
	 */
	@Override
	public boolean copyDoctorSchedule(Integer copyDoctorId, Integer doctorId) {
		Date currentDate = new Date();
    	String currentDateStr = MssDateTimeUtil.dateToString(currentDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
    	return this.doctorScheduleRepositoryCustom.copyDoctorSchedule(copyDoctorId, doctorId, currentDateStr);
	}
	
	@Override
	public boolean processValidDataCsv(String name){
		LOG.info("[start] processValidDataCsv " + name);
		try {
			String filePath = MssConfiguration.getInstance().getDirFileUpload() + "/" + name;
			CsvConverter csvConverter = new CsvConverter();
			List<Entry<DoctorInfo, CsvErrorCode>> listCsvData = csvConverter.parseFromCsv(filePath);
			if (listCsvData != null && listCsvData.size() > 0) {
				for (int rowNo = 1; rowNo <= listCsvData.size(); rowNo++) {
					Entry<DoctorInfo, CsvErrorCode> mapDoctorInfo = listCsvData.get(rowNo - 1);
					DoctorInfo doctorInfo = mapDoctorInfo.getKey();
					if(doctorInfo != null && !doctorInfo.getHospitalCode().equalsIgnoreCase(MssContextHolder.getHospCode())){
					 	LOG.debug("Don't allow to import multi hospital");
						return false;
					}
				}
			}
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
		LOG.info("[end] processValidDataCsv " + name);
		return true;
	}


}
