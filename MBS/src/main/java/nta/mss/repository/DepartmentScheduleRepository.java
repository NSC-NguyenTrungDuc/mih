package nta.mss.repository;

import java.util.List;

import nta.mss.entity.DepartmentSchedule;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface DepartmentScheduleRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface DepartmentScheduleRepository extends JpaRepository<DepartmentSchedule, Integer> {
	
	/**
	 * Gets the latest default department kpi.
	 *
	 * @param deptId the dept id
	 * @return the latest default department kpi
	 */
	@Query(value = "SELECT * "
			+ "FROM (SELECT day, dept_id, start_time, doctor_id, hospital_id, MAX(apply_date) as max_apply_date "
					+ "FROM department_schedule "
					+ "GROUP BY day, dept_id, start_time, doctor_id, hospital_id "
					+ ") AS temp "
			+ "INNER JOIN department_schedule as ds on (temp.day, temp.dept_id, temp.start_time, temp.doctor_id, temp.hospital_id) = (ds.day, ds.dept_id, ds.start_time, ds.doctor_id, ds.hospital_id) "
			+ "AND temp.max_apply_date = ds.apply_date "
			+ "WHERE ds.dept_id = :deptId", nativeQuery = true)
	public List<DepartmentSchedule> getLatestDefaultDepartmentKpi(@Param("deptId") Integer deptId);
	
	/**
	 * Gets the department schedule in id list.
	 *
	 * @param deptIdList the dept id list
	 * @return the department schedule in id list
	 */
	@Query("SELECT ds FROM DepartmentSchedule ds WHERE ds.departmentScheduleId IN (:deptIdList)")
	public List<DepartmentSchedule> getDepartmentScheduleInIdList(@Param("deptIdList") List<Integer> deptIdList);
	
	/**
	 * Gets the default department kpi.
	 *
	 * @param deptId the dept id
	 * @return the default department kpi
	 */
	@Query("SELECT ds FROM DepartmentSchedule ds WHERE ds.department.deptId = :deptId ORDER BY ds.applyDate ASC")
	public List<DepartmentSchedule> getDefaultDepartmentKpi(@Param("deptId") Integer deptId);
	
	/**
	 * Gets the timeslot list by dept id.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by dept id
	 */
	@Query("SELECT DISTINCT ds.startTime FROM DepartmentSchedule ds WHERE ds.department.deptId = :deptId AND ds.activeFlg = 1 ORDER BY ds.startTime")
	public List<String> getTimeslotListByDeptId(@Param("deptId") Integer deptId);
	
	/**
	 * Gets the full timeslot list by dept id.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by dept id
	 */
	@Query("SELECT DISTINCT CONCAT(CONCAT(ds.startTime, '_'), ds.endTime) AS dsTime FROM DepartmentSchedule ds WHERE ds.department.deptId = :deptId and ds.activeFlg = 1 ORDER BY dsTime")
	public List<String> getFullTimeslotListByDeptId(@Param("deptId") Integer deptId);
	
	/**
	 * Gets the end time by start time and dept id.
	 *
	 * @param startTime the start time
	 * @param deptId the dept id
	 * @return the end time by start time and dept id
	 */
	@Query("SELECT DISTINCT ds.endTime FROM DepartmentSchedule ds WHERE ds.startTime = :startTime AND ds.department.deptId = :deptId ORDER BY ds.endTime")
	public List<String> getEndTimeByStartTimeAndDeptId(@Param("startTime") String startTime, @Param("deptId") Integer deptId);
	
	/**
	 * Delete department schedule by dept id.
	 *
	 * @param deptId the dept id
	 * @return the integer
	 */
	@Modifying
	@Query("UPDATE DepartmentSchedule ds SET ds.activeFlg = 0 WHERE ds.department.deptId = :deptId AND ds.activeFlg = 1")
	public Integer deleteDepartmentScheduleByDeptId(@Param("deptId") Integer deptId);
	
	/**
	 * Delete department schedule in dept id list.
	 *
	 * @param deptIdList the dept id list
	 * @return the integer
	 */
	@Modifying
	@Query("UPDATE DepartmentSchedule ds SET ds.activeFlg = 0 WHERE ds.department.deptId IN (:deptIdList) AND ds.activeFlg = 1")
	public Integer deleteDepartmentScheduleInDeptIdList(@Param("deptIdList") List<Integer> deptIdList);
}
