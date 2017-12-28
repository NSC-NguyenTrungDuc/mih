package nta.mss.service;

import java.util.List;
import java.util.Map;

import nta.kcck.model.KcckDepartmentModel;
import nta.kcck.model.MessageResponse;
import nta.kcck.model.TimeslotScheduleModel;
import nta.mss.info.CalendarInfo;
import nta.mss.model.DefaultScheduleModel;
import nta.mss.model.DepartmentModel;
import nta.mss.model.ReservationKpiModel;
import nta.kcck.model.KcckDefaultScheduleModel;

/**
 * The Interface IDepartmentService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public interface IDepartmentService {
	
	/**
	 * Find department by id.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the department model
	 */
	DepartmentModel findDepartmentById(Integer deptId);
	
	/**
	 * Find department by code.
	 *
	 * @param deptCode the dept code
	 * @return the department model
	 */
	DepartmentModel findDepartmentByCode(String hospitalCode, String deptCode);
	
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
	Map<String, Boolean> checkDepartmentSchedule(Integer deptId, String startDate, String endDate);

	TimeslotScheduleModel getDepartmentTimeslotSchedule(Integer deptId, String startDate, String endDate);
	
	/**
	 * Save department.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @param deptName
	 *            the dept name
	 * @param displayOrder
	 *            the display order
	 * @param deptType
	 *            the dept type
	 * @throws Exception
	 *             the exception
	 */
	void saveDepartment(Integer hospitalId, String deptCode, String deptName, Integer displayOrder, Integer deptType) throws Exception;
	
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
	Map<String, ReservationKpiModel> getDepartmentSchedule(Integer deptId, String startDate, String endDate);
	
	/**
	 * Gets the all active department.
	 *
	 * @return the all active department
	 */
	List<DepartmentModel> getAllActiveDepartment();
	
	/**
	 * Gets the all department in hospital.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @return the all department in hospital
	 */
	List<DepartmentModel> getAllDepartmentInHospital(Integer hospitalId);
	
	/**
	 * Gets the all department in hospital by HospitalParentID.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @return the all department in hospital
	 */
	List<DepartmentModel> getAllDepartmentInHospitalbyParentId(Integer hospitalId,Integer parentId );
	
	/**
	 * 
	 * Delete deparment
	 * 
	 * @param departmentModel
	 * @throws Exception
	 */
	void deleteDepartment(DepartmentModel departmentModel) throws Exception;
	
	/**
	 * Find doctor by order priority.
	 *
	 * @param displayOrder the display order
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<DepartmentModel> findDepartmentByDisplayOrder(Integer displayOrder)
			throws Exception;
	
	/**
	 * Check department schedule in day.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the map
	 */
	public Map<String, Integer> checkDepartmentScheduleInDay(Integer deptId, String startDate, String endDate);
	
	/**
	 * Check department schedule in timeslot.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the map
	 */
	Map<String, List<CalendarInfo>> checkDepartmentScheduleInTimeslot(Integer deptId, String startDate, String endDate);
	
	
	public DepartmentModel findDeptByType(String hospCode, Integer deptType) throws Exception;
	
	
}
