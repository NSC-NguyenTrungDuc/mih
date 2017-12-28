package nta.mss.service;

import java.util.List;
import java.util.Map;

import nta.mss.entity.DepartmentSchedule;
import nta.mss.model.DepartmentScheduleModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.UploadedFileModel;

/**
 * The Interface IDepartmentScheduleService. 
 *
 * @author MinhLS
 * @crtDate Aug 2, 2014
 */
public interface IDepartmentScheduleService {
	
	/**
	 * Import department schedule from csv.
	 *
	 * @param fileName the file name
	 * @param applyDate the apply date
	 * @return true, if successful
	 */
	boolean importDepartmentScheduleFromCSV(String fileName, UploadedFileModel uploadedFile);
	
	/**
	 * Gets the latest default department kpi.
	 *
	 * @param deptId the dept id
	 * @return the latest default department kpi
	 */
	Map<String, DepartmentScheduleModel> getLatestDefaultDepartmentKpi(Integer deptId);
	
	/**
	 * Update default coma.
	 *
	 * @param defaultComaMap the default coma map
	 * @return true, if successful
	 */
	boolean updateDefaultComa(Map<Integer, Integer> defaultComaMap);
	
	/**
	 * Gets the timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by department
	 */
	List<String> getTimeslotListByDepartment(Integer deptId);
	
	/**
	 * Gets the full timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by department
	 */
	List<String> getFullTimeslotListByDepartment(Integer deptId);
	
	/**
	 * Gets the end time by start time and department.
	 *
	 * @param startTime the start time
	 * @param deptId the dept id
	 * @return the end time by start time and department
	 */
	String getEndTimeByStartTimeAndDepartment(String startTime, Integer deptId);
	
	/**
	 * Delete department schedule by dept id.
	 *
	 * @param deptId the dept id
	 * @return true, if successful
	 */
	boolean deleteDepartmentScheduleByDeptId(Integer deptId);
	
	/**
	 * Generate department schedule.
	 *
	 * @param doctorId the doctor id
	 * @param deptId the dept id
	 * @param kpiAvg the kpi avg
	 * @return true, if successful
	 */
	boolean generateDepartmentSchedule(Integer doctorId, Integer deptId, Integer kpiAvg);
	
	/**
	 * Generate department schedule.
	 *
	 * @param doctorList the doctor list
	 * @return true, if successful
	 */
	boolean generateDepartmentSchedule(List<DoctorModel> doctorList);

	/**
	 * validHospCode
	 * @param fileName
	 * @return
	 */
	boolean validHospCode(String fileName);

	DepartmentSchedule saveDepartmentSchedule(DepartmentSchedule departmentSchedule);
}
