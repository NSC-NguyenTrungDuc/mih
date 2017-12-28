package nta.mss.service;

import java.util.List;
import java.util.Map;

import nta.mss.info.DoctorInfo;
import nta.kcck.model.MessageResponse;
import nta.kcck.model.DoctorModelInfo;
import nta.mss.model.DoctorModel;
import nta.mss.model.ReservationKpiModel;

/**
 * The Interface IDoctorService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public interface IDoctorService {
	
	/**
	 * Gets the doctor by doctor id.
	 * 
	 * @param doctId
	 *            the doct id
	 * @return the doctor by doctor id
	 */
	DoctorModel getDoctorByDoctorId(Integer doctId);
	
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
	Map<String, Boolean> checkDoctorSchedule(Integer doctorId, String startDate, String endDate);
	
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
	DoctorModel findAvailableDoctor(Integer deptId, String checkDate, String startTime);
	
	/**
	 * Find doctors by department.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the list
	 */
	List<DoctorModel> findDoctorsByDepartment(Integer deptId);
	
	/**
	 * Gets the doctors by department.
	 * 
	 * @param deptId
	 *            the dept id
	 * @return the doctors by department
	 */
	Map<Integer, String> getDoctorsByDepartment(Integer deptId);
	
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
	Map<String, ReservationKpiModel> getDoctorSchedule(Integer doctorId, String startDate, String endDate);
	
	/**
	 * Adds the doctor.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param name
	 *            the name
	 * @param orderPriority
	 *            the order priority
	 * @throws Exception
	 *             the exception
	 */
	DoctorModel addDoctor(Integer deptId, String name, Integer orderPriority) throws Exception;

	public abstract List<DoctorModel> processDoctorCsv(String name);
	
	/**
	 * Update junior_flg for doctor
	 * 
	 * @param doctorModel
	 * @throws Exception
	 */
	void updateJuniorFlgForDoctor(DoctorModel doctorModel) throws Exception;
	
	
	/**
	 * Find doctor by order priority 
	 * 
	 * @param orderPriority
	 * @return list
	 * @throws Exception
	 */
	List<DoctorModel> findDoctorByOrderPriority(Integer orderPriority) throws Exception;
	
	/**
	 * Find all doctor info.
	 *
	 * @return the list
	 * @throws Exception the exception
	 */
	public List<DoctorInfo> findAllDoctorInfo(Integer hospitalId) throws Exception;
	
	public boolean copyDoctorSchedule(Integer copyDoctorId, Integer doctorId);

	/**
	 * processValidDataCsv
	 * @param name
	 * @return
	 */
	public boolean processValidDataCsv(String name);
	
	
	
}
