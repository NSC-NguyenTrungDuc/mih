package nta.mss.service.impl;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import nta.mss.model.DepartmentScheduleModel;
import nta.mss.entity.Department;
import nta.mss.entity.DepartmentSchedule;
import nta.mss.entity.Doctor;
import nta.mss.entity.Hospital;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.model.DepartmentScheduleModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.UploadedFileModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DepartmentScheduleRepository;
import nta.mss.repository.DepartmentScheduleRepositoryCustom;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.DoctorScheduleRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.IDepartmentScheduleService;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class DepartmentScheduleService implements IDepartmentScheduleService {

	private static Logger LOG = LogManager.getLogger(DepartmentScheduleService.class);
	
	private Mapper mapper;
	private ReservationRepository reservationRepository;
	private DepartmentScheduleRepository departmentScheduleRepository;
	private DepartmentRepository departmentRepository;
	private HospitalRepository hospitalRepository;
	private DoctorRepository doctorRepository;
	private DepartmentScheduleRepositoryCustom departmentScheduleRepositoryCustom;
	private DoctorScheduleRepository doctorScheduleRepository;
	
    DepartmentScheduleService() {
    }

    @Autowired
	public DepartmentScheduleService(Mapper mapper, ReservationRepository reservationRepository, 
			DepartmentScheduleRepository departmentScheduleRepository, DepartmentRepository departmentRepository,
			HospitalRepository hospitalRepository, DoctorRepository doctorRepository,
			DepartmentScheduleRepositoryCustom departmentScheduleRepositoryCustom,
			DoctorScheduleRepository doctorScheduleRepository) {
		this.mapper = mapper;
		this.reservationRepository = reservationRepository;
		this.departmentScheduleRepository = departmentScheduleRepository;
		this.departmentRepository = departmentRepository;
		this.hospitalRepository = hospitalRepository;
		this.doctorRepository = doctorRepository;
		this.departmentScheduleRepositoryCustom = departmentScheduleRepositoryCustom;
		this.doctorScheduleRepository = doctorScheduleRepository;
	}
	
	/**
	 * map hospital code and hospital
	 * @return Map<String, Hospital>
	 */
	private Map<String, Hospital> getHospitalByHospitalCode() {
		Map<String, Hospital> result = new HashMap<String, Hospital>();
		List<Hospital> lstHosptal = hospitalRepository.findHospitalByActiveFlg(ActiveFlag.ACTIVE.toInt());
		for (Hospital hospital : lstHosptal) {
			result.put(hospital.getHospitalCode(), hospital);
		}
		return result;
	}
	
	/**
	 * @param execute import csv department schedule
	 * @return boolean
	 */
	public boolean importDepartmentScheduleFromCSV(String fileName, UploadedFileModel uploadedFile) {
		boolean success = false;
		LOG.info("[Start] importDepartmentScheduleFromCSV " + fileName);
		String applyDate = uploadedFile.getApplyDate();
		List<DepartmentSchedule> lstDS = new ArrayList<DepartmentSchedule>();
		Date modifyApplyDate = MssDateTimeUtil.dateFromString(applyDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND);
		applyDate = MssDateTimeUtil.dateToString(modifyApplyDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
		List<Doctor> listDoctor;
		Map<String, Hospital> mapHospt = getHospitalByHospitalCode();
		BufferedReader br = null;  
		String line = "";  
		String splitBy = ",";
		try {
			 String filePath = MssConfiguration.getInstance().getDirFileUpload() + "/" + fileName;
			 br = new BufferedReader(new FileReader(filePath));
			 String[] row;
			 String hospitalCode, deptCode, day, startTime, endTime;
			 Hospital hospital;
			 Department de;
			 //DepartmentSchedulePK dspk;
			 int numberRow = 0;
			 while ((line = br.readLine()) != null) {
			    // split on comma(',')  
			 	numberRow++;
			    row = line.split(splitBy);  
			    if(row.length < 5) {
			    	LOG.warn("Row "+ numberRow +" : Lack data");
			    	continue;
			    }
			    hospitalCode = row[0].replaceAll("[^\\p{ASCII}]", ""); 
			    deptCode = row[1];
			    day = row[2];
			    startTime = row[3];
			    endTime = row[4];
			    
			    StringBuilder rowData = new StringBuilder("Row Data [hospitalCode = ");
		    	rowData.append(hospitalCode).append(",deptCode=").append(deptCode).append(",day=").append(day);
		    	rowData.append(",startTime=").append(startTime).append(",endTime").append(endTime).append("]");
		    	LOG.debug("[Import Dept Schedule] Import " + rowData.toString());
			    if (StringUtils.isBlank(hospitalCode) || StringUtils.isBlank(deptCode) || 
			    		StringUtils.isBlank(day) || StringUtils.isBlank(startTime) || StringUtils.isBlank(endTime)) {
			    	LOG.warn("Row "+ numberRow +" : Have some fields in row is empty");
			    	LOG.warn("[Import Dept Schedule] Have some fields in row is empty. " + rowData.toString());
			    	continue;
			    }
			    if (startTime.length() > 6 || endTime.length() > 6) {
			    	LOG.warn("Row "+ numberRow +" : Have some fields in row is WRONG_SIZE");
			    	LOG.warn("[Import Dept Schedule] Have some fields in row is WRONG_SIZE. " + rowData.toString());
			    	continue;
			    }
			    if (startTime.length() == 3) {
			    	startTime = "0" + startTime;
			    } 
			    if (endTime.length() == 3) {
			    	endTime = "0" + endTime;
			    }
			    day = day.trim();
			    if (!"1".equals(day) && !"2".equals(day) && !"3".equals(day) && !"4".equals(day) && !"5".equals(day) && !"6".equals(day) && !"7".equals(day)) {
			    	LOG.warn("Row "+ numberRow +" : day=" + day + " is invalid. Day is allow in (1,7)");
			    	continue;
 			    }
			    hospital = mapHospt.get(hospitalCode);
			    if (hospital == null) {
			    	LOG.warn("Row "+ numberRow +" : Hospital_code=" + hospitalCode + "is not existed");
			    	continue;
			    }
			    List<Department> lstDepartment = this.departmentRepository.findDepartmentInHospital(hospital.getHospitalId(), deptCode);
			    if (lstDepartment == null || lstDepartment.isEmpty()) {
			    	LOG.warn("Row "+ numberRow +" : department_code=" + deptCode + " is not existed");
			    	continue;
			    }
			    de = lstDepartment.get(0);
			    listDoctor = doctorRepository.findByDeptId(de.getDeptId());
			    for (Doctor doctor : listDoctor) {
			    	DepartmentSchedule ds = new DepartmentSchedule();
				    ds.setHospital(hospital);
				    ds.setDepartment(de);
				    ds.setStartTime(startTime);
				    ds.setDoctor(doctor);
				    ds.setDay(day);
				    ds.setEndTime(endTime);
				    ds.setApplyDate(applyDate);
				    ds.setKpi(doctor.getKpiAvg());
				    
				    lstDS.add(ds);
				}
			}
			 
			// overwrite the schedule
			if (uploadedFile.getOverwriteSchedule() && lstDS != null && !lstDS.isEmpty()) {
				LOG.info("[Start] Overwrite the schedule");
				// get list department in CSV file
				List<Integer> deptIdList = new ArrayList<Integer>();
				Integer deptId;
				for (DepartmentSchedule ds : lstDS) {
					deptId = ds.getDepartment().getDeptId();
					if (!deptIdList.contains(deptId)) {
						deptIdList.add(deptId);
					}
				}
				List<Object[]> reservationList = reservationRepository.findDistinctTimeslotByDeptIdList(deptIdList);
				Map<Integer, List<String>> reservationTimeMap = new HashMap<Integer, List<String>>();
				Integer deptIdInList;
				String resTimeInList;
				for (Object[] rs : reservationList) {
					deptIdInList = Integer.valueOf(rs[0].toString());
					resTimeInList = rs[1].toString();
					if (reservationTimeMap.containsKey(deptIdInList)) {
						reservationTimeMap.get(deptIdInList).add(resTimeInList);
					}
					else {
						reservationTimeMap.put(deptIdInList, new ArrayList<String>(Arrays.asList(resTimeInList)));
					}
				}
				// remove old department schedule
				LOG.info("[Start] Remove old department schedule");
				LOG.debug("Dept Id List: " + deptIdList.toString());
				this.departmentScheduleRepository.deleteDepartmentScheduleInDeptIdList(deptIdList);
				LOG.info("[End] Remove old department schedule");
				
				// remove old doctor schedule
				LOG.info("[Start] Remove old doctor schedule");
				for (Entry<Integer, List<String>> entry : reservationTimeMap.entrySet()) {
					this.doctorScheduleRepository.deleteDoctorScheduleByDeptId(entry.getKey(), entry.getValue());
				}
				LOG.info("[End] Remove old doctor schedule");
				
				LOG.info("[End] Overwrite the schedule");
			}
			
			// save new department schedule
			if (lstDS != null && lstDS.size() > 0) {
				departmentScheduleRepository.save(lstDS);
				success = true;
			}
			br.close();
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
			success = false;
		}
		
		LOG.info("[End]  importDepartmentScheduleFromCSV " + fileName);
		return success;
	}
	
	/**
	 * Gets the latest default department kpi.
	 *
	 * @param deptId the dept id
	 * @return the latest default department kpi
	 */
	public Map<String, DepartmentScheduleModel> getLatestDefaultDepartmentKpi(Integer deptId) {
		Map<String, DepartmentScheduleModel> result = new HashMap<String, DepartmentScheduleModel>();
		List<DepartmentSchedule> departmentScheduleList = this.departmentScheduleRepository.getLatestDefaultDepartmentKpi(deptId);
		String key;
		for(DepartmentSchedule ds : departmentScheduleList) {
			key = ds.getDay() + "_" + ds.getStartTime() + "_" + ds.getDoctor().getDoctorId();
			result.put(key, ds.toModel(mapper));
		}
		return result;
	}
	
	/**
	 * Update default coma.
	 *
	 * @param defaultComaMap the default coma map
	 * @return true, if successful
	 */
	public boolean updateDefaultComa(Map<Integer, Integer> defaultComaMap) {
		boolean success = true;
		try{
			if(defaultComaMap != null) {
				if(defaultComaMap.size() != 0) {
					List<Integer> departmentScheduleIdList = new ArrayList<Integer>();
					departmentScheduleIdList.addAll(defaultComaMap.keySet());
					List<DepartmentSchedule> departmentScheduleList = this.departmentScheduleRepository.getDepartmentScheduleInIdList(departmentScheduleIdList);
					Integer departmentScheduleId;
					Integer kpi;
					// update new kpi for department schedule in list
					for(DepartmentSchedule ds : departmentScheduleList) {
						departmentScheduleId = ds.getDepartmentScheduleId();
						kpi = defaultComaMap.get(departmentScheduleId);
						ds.setKpi(kpi);
					}
					// save to db
					this.departmentScheduleRepository.save(departmentScheduleList);
				}
			}
		} catch (Exception e) {
			success = false;
		}
		return success;
	}
	
	/**
	 * Gets the timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by department
	 */
	public List<String> getTimeslotListByDepartment(Integer deptId) {
		return this.departmentScheduleRepository.getTimeslotListByDeptId(deptId);
	}
	
	/**
	 * Gets the full timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by department
	 */
	public List<String> getFullTimeslotListByDepartment(Integer deptId) {
		return this.departmentScheduleRepositoryCustom.getFullTimeslotListByDepartment(deptId);
		/*return this.departmentScheduleRepository.getFullTimeslotListByDeptId(deptId);*/
	}
	
	/**
	 * Gets the end time by start time and department.
	 *
	 * @param startTime the start time
	 * @param deptId the dept id
	 * @return the end time by start time and department
	 */
	public String getEndTimeByStartTimeAndDepartment(String startTime, Integer deptId) {
		List<String> endTimeList = this.departmentScheduleRepository.getEndTimeByStartTimeAndDeptId(startTime, deptId);
		if (endTimeList == null || endTimeList.size() == 0) {
			return "";
		}
		return endTimeList.get(0);
	}
	
	/**
	 * Delete department schedule by dept id.
	 *
	 * @param deptId the dept id
	 * @return true, if successful
	 */
	@Override
	public boolean deleteDepartmentScheduleByDeptId(Integer deptId) {
		boolean result = true;
		List<DepartmentSchedule> deparmentScheduleList = this.departmentScheduleRepository.getDefaultDepartmentKpi(deptId);
		if (deparmentScheduleList.size() != this.departmentScheduleRepository.deleteDepartmentScheduleByDeptId(deptId)) {
			result = false;
		}
		return result;
	}

	/**
	 * Generate department schedule.
	 *
	 * @param deptId the dept id
	 * @param kpiAvg the kpi avg
	 * @return true, if successful
	 */
	@Override
	public boolean generateDepartmentSchedule(Integer doctorId, Integer deptId, Integer kpiAvg) {
		Date currentDate = new Date();
    	String currentDateStr = MssDateTimeUtil.dateToString(currentDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
    	return this.departmentScheduleRepositoryCustom.generateDepartmentSchedule(doctorId, deptId, kpiAvg, currentDateStr);
	}
	
	/**
	 * Generate department schedule.
	 *
	 * @param doctorList the doctor list
	 * @return true, if successful
	 */
	@Override
	public boolean generateDepartmentSchedule(List<DoctorModel> doctorList) {
		for (DoctorModel doctor : doctorList) {
			if (!generateDepartmentSchedule(doctor.getDoctorId(), doctor.getDeptId(), doctor.getKpiAvg())) {
				LOG.debug("ERROR when generate department schedule for: doctorId = " + doctor.getDoctorId());
			}
		}
		return true;
	}
	
	@Override
	public boolean validHospCode(String fileName){
		LOG.info("[Start] importDepartmentScheduleFromCSV " + fileName);
		BufferedReader br = null;  
		String line = "";  
		String splitBy = ",";
		try {
			 String filePath = MssConfiguration.getInstance().getDirFileUpload() + "/" + fileName;
			 br = new BufferedReader(new FileReader(filePath));
			 String[] row;
			 String hospitalCode;
			 int numberRow = 0;
			 while ((line = br.readLine()) != null) {
			    // split on comma(',')  
			 	numberRow++;
			    row = line.split(splitBy);  
			    if(row.length < 5) {
			    	LOG.warn("Row "+ numberRow +" : Lack data");
			    	continue;
			    }
			    hospitalCode = row[0].replaceAll("[^\\p{ASCII}]", ""); 
			    if(!hospitalCode.equalsIgnoreCase(MssContextHolder.getHospCode())){
			    	return false;
			    }
			}
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
		
		return true;
	}

	@Override
	public DepartmentSchedule saveDepartmentSchedule(DepartmentSchedule departmentSchedule) {
		DepartmentSchedule saveDepartmentSchedule;
		int  departmentScheduleId = departmentSchedule.getDepartmentScheduleId();
		saveDepartmentSchedule = this.departmentScheduleRepository.findOne(departmentScheduleId);
		saveDepartmentSchedule.setKpi(departmentSchedule.getKpi());
		saveDepartmentSchedule = this.departmentScheduleRepository.save(saveDepartmentSchedule);
		return  saveDepartmentSchedule;
	}
}

