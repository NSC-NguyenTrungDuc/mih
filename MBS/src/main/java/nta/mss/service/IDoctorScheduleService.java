package nta.mss.service;

import java.text.ParseException;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import nta.mss.entity.DoctorSchedulePK;
import nta.mss.model.DoctorScheduleModel;

/**
 * The Interface IDoctorScheduleService. 
 *
 * @author MinhLS
 * @crtDate Aug 2, 2014
 */
public interface IDoctorScheduleService {

	/**
	 * Gets the monthly department kpi.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the monthly department kpi
	 * @throws ParseException the parse exception
	 */
	Map<DoctorScheduleModel, Integer> getMonthlyDepartmentKpi(Integer deptId, String startDate, String endDate) throws ParseException;
	
	/**
	 * Update doctor schedule.
	 *
	 * @param doctorScheduleModel the doctor schedule model
	 * @return true, if successful
	 */
	boolean updateDoctorSchedule(DoctorScheduleModel dsm);
	
	/**
	 * Update monthly coma.
	 *
	 * @param monthlyComaMap the monthly coma map
	 * @param hospitalId the hospital id
	 * @param deptId the dept id
	 * @return true, if successful
	 */
	boolean updateMonthlyComa(Map<DoctorSchedulePK, DoctorScheduleModel> monthlyComaMap, Integer hospitalId, Integer deptId);
	
	/**
	 * Gets the doctor schedule by dept id and timeslot.
	 *
	 * @param deptId the dept id
	 * @param checkDate the check date
	 * @param startTime the start time
	 * @return the doctor schedule by dept id and timeslot
	 */
	List<DoctorScheduleModel> getDoctorScheduleByDeptIdAndTimeslot(Integer deptId, String checkDate, String startTime);
	
	/**
	 * Cancel doctor schedule by id in list.
	 *
	 * @param doctorSchedulePKs the doctor schedule p ks
	 * @return true, if successful
	 */
	boolean cancelDoctorScheduleByIdInList(Collection<DoctorSchedulePK> doctorSchedulePKs);
	
	/**
	 * Checks if is doctor schedule full.
	 *
	 * @param doctorId the doctor id
	 * @param checkDate the check date
	 * @param startTime the start time
	 * @return true, if is doctor schedule full
	 */
	boolean isDoctorScheduleFull(Integer doctorId, String checkDate, String startTime);
	
	/**
	 * Gets the by doctor schedule pk.
	 *
	 * @param doctorSchedulePK the doctor schedule pk
	 * @return the by doctor schedule pk
	 */
	public DoctorScheduleModel getByDoctorSchedulePK(DoctorSchedulePK doctorSchedulePK);
	
	/**
	 * Update doctor schedule.
	 *
	 * @param doctorScheduleModel the doctor schedule model
	 * @return true, if successful
	 * @throws Exception the exception
	 */
	public void addDoctorSchedule(DoctorScheduleModel doctorScheduleModel) throws Exception;
	
	/**
	 * Gets the timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by department
	 */
	public List<String> getTimeslotListByDepartment(Integer deptId);
	
	/**
	 * Gets the full timeslot list by department.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by department
	 */
	public List<String> getFullTimeslotListByDepartment(Integer deptId);
}
