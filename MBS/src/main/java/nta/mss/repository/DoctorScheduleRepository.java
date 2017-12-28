package nta.mss.repository;

import java.util.Collection;
import java.util.List;

import nta.mss.entity.DoctorSchedule;
import nta.mss.entity.DoctorSchedulePK;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface DoctorScheduleRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface DoctorScheduleRepository extends JpaRepository<DoctorSchedule, DoctorSchedulePK> {
	
	/**
	 * Calculate department kpi.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param starDate
	 *            the star date
	 * @param endDate
	 *            the end date
	 * @return the list
	 */
	@Query("SELECT ds.department.deptId, ds.id.checkDate, ds.id.startTime, SUM(ds.kpi) FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate >= :starDate AND ds.id.checkDate <= :endDate AND ds.activeFlg = 1 AND ds.doctor.activeFlg = 1 "
			+ "GROUP BY ds.department.deptId, ds.id.checkDate, ds.id.startTime")
	public List<Object[]> calculateDepartmentKpi(@Param("deptId") Integer deptId, @Param("starDate") String starDate, @Param("endDate") String endDate);
	
	
	/**
	 * Calculate department kpi with junior flg.
	 *
	 * @param deptId the dept id
	 * @param starDate the star date
	 * @param endDate the end date
	 * @param juniorFlg the junior flg
	 * @return the list
	 */
	@Query("SELECT ds.department.deptId, ds.id.checkDate, ds.id.startTime, SUM(ds.kpi) FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate >= :starDate AND ds.id.checkDate <= :endDate AND ds.activeFlg = 1 AND ds.doctor.activeFlg = 1 AND ds.doctor.juniorFlg = :juniorFlg "
			+ "GROUP BY ds.department.deptId, ds.id.checkDate, ds.id.startTime")
	public List<Object[]> calculateDepartmentKpiWithJuniorFlg(@Param("deptId") Integer deptId, @Param("starDate") String starDate, @Param("endDate") String endDate, @Param("juniorFlg") Integer juniorFlg);
	/**
	 * Find doctor by dept id and time slot.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the list
	 */
	@Query("SELECT ds FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate = :checkDate AND ds.id.startTime = :startTime AND ds.doctor.activeFlg = 1 AND ds.activeFlg = 1"
			+ "AND ds.kpi > 0")
	public List<DoctorSchedule> findDoctorByDeptIdAndTimeSlot(@Param("deptId") Integer deptId, @Param("checkDate") String checkDate, @Param("startTime") String startTime);
	
	/**
	 * Calculate doctor kpi.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the list
	 */
	@Query("SELECT ds.id.doctorId, ds.id.checkDate, ds.id.startTime, SUM(ds.kpi) FROM DoctorSchedule ds "
			+ "WHERE ds.id.doctorId = :doctorId AND ds.id.checkDate >= :startDate AND ds.id.checkDate <= :endDate "
			+ "AND ds.activeFlg = 1 "
			+ "GROUP BY ds.id.doctorId, ds.id.checkDate, ds.id.startTime")
	public List<Object[]> calculateDoctorKpi(@Param("doctorId") Integer doctorId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Find doctor by doctor id and time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 * @return the list
	 */
	@Query("SELECT ds FROM DoctorSchedule ds "
			+ "WHERE ds.doctor.doctorId = :doctorId AND ds.id.checkDate = :checkDate AND ds.id.startTime = :startTime AND ds.activeFlg = 1 ")
	public List<DoctorSchedule> findDoctorByDoctorIdAndTimeSlot(@Param("doctorId") Integer doctorId, @Param("checkDate") String checkDate, @Param("startTime") String startTime);
	
	/**
	 * Find doctor schedule by dept id and check date.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the list
	 */
	@Query("SELECT ds FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate >= :startDate AND ds.id.checkDate <= :endDate AND ds.activeFlg = 1 AND ds.doctor.activeFlg = 1 ")
	public List<DoctorSchedule> findDoctorScheduleByDeptIdAndCheckDate(@Param("deptId") Integer deptId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Cancel doctor schedule by id in list.
	 *
	 * @param doctorSchedulePKList the doctor schedule pk list
	 * @return the integer
	 */
	@Modifying
	@Query("UPDATE DoctorSchedule ds SET ds.activeFlg = 0 WHERE ds.id IN (:doctorSchedulePKs)")
	public Integer cancelDoctorScheduleByIdInList(@Param("doctorSchedulePKs") Collection<DoctorSchedulePK> doctorSchedulePKs);
	
	/**
	 * Calculate department kpi by day.
	 *
	 * @param deptId the dept id
	 * @param starDate the star date
	 * @param endDate the end date
	 * @return the list
	 */
	@Query("SELECT ds.id.checkDate, SUM(ds.kpi) FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate >= :starDate AND ds.id.checkDate <= :endDate AND ds.activeFlg = 1 AND ds.doctor.activeFlg = 1 AND ds.doctor.juniorFlg = 1 "
			+ "GROUP BY ds.id.checkDate")
	public List<Object[]> calculateDepartmentKpiByDay(@Param("deptId") Integer deptId, @Param("starDate") String starDate, @Param("endDate") String endDate);
	
	/**
	 * Calculate department kpi by timeslot.
	 *
	 * @param deptId the dept id
	 * @param starDate the star date
	 * @param endDate the end date
	 * @return the list
	 */
	@Query("SELECT ds.id.checkDate, ds.id.startTime, ds.endTime, SUM(ds.kpi) FROM DoctorSchedule ds "
			+ "WHERE ds.department.deptId = :deptId AND ds.id.checkDate >= :starDate AND ds.id.checkDate <= :endDate AND ds.activeFlg = 1 AND ds.doctor.activeFlg = 1 AND ds.doctor.juniorFlg = 1 "
			+ "GROUP BY ds.id.checkDate, ds.id.startTime, ds.endTime")
	public List<Object[]> calculateDepartmentKpiByTimeslot(@Param("deptId") Integer deptId, @Param("starDate") String starDate, @Param("endDate") String endDate);
	
	/**
	 * Delete doctor schedule by dept id.
	 *
	 * @param deptId the dept id
	 * @param startTimeList the start time list
	 * @return the integer
	 */
	@Modifying
	@Query("UPDATE DoctorSchedule ds SET ds.activeFlg = 0 WHERE ds.department.deptId = :deptId AND ds.activeFlg = 1 AND ds.id.startTime NOT IN (:startTimeList)")
	public Integer deleteDoctorScheduleByDeptId(@Param("deptId") Integer deptId, @Param("startTimeList") List<String> startTimeList);
	
	/**
	 * Gets the timeslot list by dept id.
	 *
	 * @param deptId the dept id
	 * @return the timeslot list by dept id
	 */
	@Query("SELECT DISTINCT ds.id.startTime FROM DoctorSchedule ds WHERE ds.department.deptId = :deptId AND ds.activeFlg = 1 ORDER BY ds.id.startTime")
	public List<String> getTimeslotListByDeptId(@Param("deptId") Integer deptId);
	
	/**
	 * Gets the full timeslot list by dept id.
	 *
	 * @param deptId the dept id
	 * @return the full timeslot list by dept id
	 */
	@Query("SELECT DISTINCT CONCAT(CONCAT(ds.id.startTime, '_'), ds.endTime) FROM DoctorSchedule ds WHERE ds.department.deptId = :deptId and ds.activeFlg = 1 ORDER BY ds.id.startTime")
	public List<String> getFullTimeslotListByDeptId(@Param("deptId") Integer deptId);
}
