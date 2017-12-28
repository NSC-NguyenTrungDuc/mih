package nta.mss.repository;

import java.util.Collection;
import java.util.List;

import nta.mss.entity.DoctorSchedulePK;
import nta.mss.entity.Reservation;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface ReservationRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface ReservationRepository extends JpaRepository<Reservation, Integer>, ReservationRepositoryCustom {
	
	/**
	 * Find by session id.
	 * 
	 * @param sessionId
	 *            the session id
	 * @return the reservation
	 */
	@Query("SELECT r FROM Reservation r WHERE r.session.sessionId = ?1 ")
	public Reservation findBySessionId(String sessionId);
	
	
	
	/**
	 * Gets the reservations by time slot.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the reservations by time slot
	 */
	@Query("SELECT r.department.deptId, r.reservationDate, r.reservationTime, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.department.deptId = :deptId AND r.reservationDate >= :startDate AND r.reservationDate <= :endDate AND r.reservationStatus = 1 AND r.activeFlg = 1 "
			+ "GROUP BY r.department.deptId, r.reservationDate, r.reservationTime")
	public List<Object[]> getReservationsBetweenDate(@Param("deptId") Integer deptId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Gets the reservations between date with junior flg.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @param juniorFlg the junior flg
	 * @return the reservations between date with junior flg
	 */
	@Query("SELECT r.department.deptId, r.reservationDate, r.reservationTime, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.department.deptId = :deptId AND r.reservationDate >= :startDate AND r.reservationDate <= :endDate AND r.reservationStatus = 1 AND r.activeFlg = 1 AND r.doctor.juniorFlg = :juniorFlg "
			+ "GROUP BY r.department.deptId, r.reservationDate, r.reservationTime")
	public List<Object[]> getReservationsBetweenDateWithJuniorFlg(@Param("deptId") Integer deptId, @Param("startDate") String startDate, @Param("endDate") String endDate, @Param("juniorFlg") Integer juniorFlg);
	
	/**
	 * Gets the doctor reservations by time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param startDate
	 *            the start date
	 * @param endDate
	 *            the end date
	 * @return the doctor reservations by time slot
	 */
	@Query("SELECT r.doctor.doctorId, r.reservationDate, r.reservationTime, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.doctor.doctorId = :doctorId AND r.reservationDate >= :startDate AND r.reservationDate <= :endDate AND r.reservationStatus = 1 "
			+ "GROUP BY r.doctor.doctorId, r.reservationDate, r.reservationTime")
	public List<Object[]> getDoctorReservationsBetweenDate(@Param("doctorId") Integer doctorId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Count reservation by doctor and time.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param reservationDate
	 *            the reservation date
	 * @param reservationTime
	 *            the reservation time
	 * @return the list
	 */
	@Query("SELECT r.doctor.doctorId, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.doctor.doctorId IN (:doctorIds) AND r.reservationDate = :date AND r.reservationTime = :time AND r.reservationStatus = 1 AND r.activeFlg = 1 "
			+ "GROUP BY r.doctor.doctorId")
	public List<Object[]> countReservationByDoctorAndTime(@Param("doctorIds") List<Integer> doctorId, @Param("date") String reservationDate, @Param("time") String reservationTime);
	
	/**
	 * Find time current pending status.
	 * 
	 * @param date
	 *            the date
	 * @param deptId
	 *            the dept id
	 * @return the string
	 */
	@Query("SELECT max(r.reservationTime) FROM Reservation r WHERE r.reservationDate = ?1 and r.department.deptId = ?2 and r.reservationStatus in (2,3) AND r.activeFlg = 1")
	public String findTimeCurrentPendingStatus(String date, Integer deptId);
	
	/**
	 * Find by email.
	 * 
	 * @param email
	 *            the email
	 * @return the list
	 */
	@Query("SELECT r FROM Reservation r WHERE r.email = ?1 order by r.created desc ")
	public List<Reservation> findByEmail(String email);
	
	@Query("SELECT r FROM Reservation r WHERE r.email = ?1 AND r.reservationStatus IN (0,1) AND r.hospital.hospitalId = ?2 "
			+ " and STR_TO_DATE(CONCAT(r.reservationDate,' ', r.reservationTime ), '%Y%m%d %H%i') >= CURDATE() order by STR_TO_DATE(CONCAT(r.reservationDate,' ', r.reservationTime ), '%Y%m%d %H%i') desc ")
	public List<Reservation> findCompletedReservationListByEmail(String email, Integer hospitalId);
	
	@Query("SELECT r FROM Reservation r WHERE r.email = ?1 AND r.reservationStatus = 1 AND r.hospital.hospitalId = ?2 "
			+ " and STR_TO_DATE(CONCAT(r.reservationDate,' ', r.reservationTime ), '%Y%m%d %H%i') >= CURDATE() order by STR_TO_DATE(CONCAT(r.reservationDate,' ', r.reservationTime ), '%Y%m%d %H%i') desc ")
	public List<Reservation> findKcckCompletedReservationListByEmail(String email, Integer hospitalId);
	
	/**
	 * Find by patient id.
	 * 
	 * @param patientId
	 *            the patient id
	 * @param limit
	 *            the limit
	 * @return the list
	 */
	@Query(value = "SELECT r.* FROM reservation r WHERE r.patient_id = :patientId ORDER BY r.created DESC LIMIT :limit ", nativeQuery = true)
	public List<Reservation> findByPatientId(@Param("patientId") Integer patientId, @Param("limit") Integer limit);
	
	/**
	 * Find by doctor id and time slot.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param reservationDate
	 *            the reservation date
	 * @param reservationTime
	 *            the reservation time
	 * @return the list
	 */
	@Query("SELECT r FROM Reservation r WHERE r.doctor.doctorId = :doctId AND r.reservationDate = :date "
			+ "AND r.reservationTime = :time AND r.reservationStatus = 1 AND r.activeFlg = 1 ")
	public List<Reservation> findByDoctorIdAndTimeSlot(@Param("doctId") Integer doctorId, @Param("date") String reservationDate, @Param("time") String reservationTime);
	
	/**
	 * Find in doctor id and time slot list.
	 *
	 * @param doctorSchedulePKList the doctor schedule pk list
	 * @return the list
	 */
	@Query("SELECT r FROM Reservation r, DoctorSchedule d "
			+ "WHERE r.doctor.doctorId = d.id.doctorId AND r.reservationDate = d.id.checkDate AND r.reservationTime = d.id.startTime "
			+ "AND d.id IN (:doctorSchedulePKList) "
			+ "AND r.reservationStatus IN (1, 2, 3, 4) AND r.activeFlg = 1")
	public List<Reservation> findInDoctorIdAndTimeSlotList(@Param("doctorSchedulePKList") List<DoctorSchedulePK> doctorSchedulePKList);
	
	/**
	 * Find in id list.
	 *
	 * @param reservationIdList the reservation id list
	 * @return the list
	 */
	@Query("SELECT r FROM Reservation r WHERE r.reservationId IN (:reservationIds)")
	public List<Reservation> findInIdList(@Param("reservationIds") Collection<Integer> reservationIds);
	
	/**
	 * get all reservation have mail sending.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param reservationDate
	 *            the reservation date
	 * @return the list
	 */
	@Query("SELECT r.doctor.doctorId, r.doctor.name, r.reservationTime, r.patientName, r.email, r.phoneNumber, m.readingFlg, m.sendingStatus, m.subject "
			+ " FROM Reservation r inner join r.mailSendings m WHERE r.department.deptId = :deptId AND r.reservationDate = :date "
			+ " AND r.reservationStatus IN (0, 1, 2, 3, 4, 5) AND r.activeFlg = 1 order by r.doctor.name, r.reservationTime")
	public List<Object[]> searchInfoScheduleMailHistory(@Param("deptId") Integer deptId, @Param("date") String reservationDate);
	
	/**
	 * get reservation of one doctor by doctorId
	 * @param doctorId
	 * @return list Reservation
	 */
	@Query("SELECT r FROM Reservation r WHERE r.doctor.doctorId = ?1 and r.reservationStatus IN (0, 1, 2, 3, 4) and r.activeFlg = 1 ORDER BY reservationDate asc, reservationTime asc, patientName asc")
	public List<Reservation> findByDoctorId(Integer doctorId);
	
	/**
	 * Count doctor reservations by time slot.
	 *
	 * @param doctorId the doctor id
	 * @param checkDate the check date
	 * @param startTime the start time
	 * @return the object[]
	 */
	@Query("SELECT COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.doctor.doctorId = :doctorId AND r.reservationDate = :checkDate AND r.reservationTime = :startTime AND r.reservationStatus = 1 ")
	public Object[] countDoctorReservationsByTimeSlot(@Param("doctorId") Integer doctorId, @Param("checkDate") String checkDate, @Param("startTime") String startTime);
	
	/**
	 * Cancel reservation by id.
	 *
	 * @param reservationIdList the reservation id list
	 * @return true, if successful
	 */
	@Modifying
	@Query("UPDATE Reservation r SET r.reservationStatus = 5 WHERE r.reservationId IN (:reservationIds)")
	public Integer cancelReservationInIdList(@Param("reservationIds") Collection<Integer> reservationIds);
	
	/**
	 * Find future reservation by doctor id.
	 *
	 * @param doctorId the doctor id
	 * @param currentDateTime the current date time
	 * @return the list
	 */
	@Query("SELECT r FROM Reservation r WHERE r.doctor.doctorId = :doctorId and r.reservationStatus IN (0, 1, 2, 3, 4) and CONCAT(r.reservationDate, r.reservationTime) >= :currentDateTime and r.activeFlg = 1 ")
	public List<Reservation> findFutureReservationByDoctorId(@Param("doctorId") Integer doctorId, @Param("currentDateTime") String currentDateTime);
	
	/**
	 * Gets the reservations by day between date.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the reservations by day between date
	 */
	@Query("SELECT r.reservationDate, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.department.deptId = :deptId AND r.reservationDate >= :startDate AND r.reservationDate <= :endDate AND r.reservationStatus = 1 AND r.activeFlg = 1 AND r.doctor.juniorFlg = 1 "
			+ "GROUP BY r.reservationDate")
	public List<Object[]> getReservationsByDayBetweenDate(@Param("deptId") Integer deptId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Gets the reservations by timeslot between date.
	 *
	 * @param deptId the dept id
	 * @param startDate the start date
	 * @param endDate the end date
	 * @return the reservations by timeslot between date
	 */
	@Query("SELECT r.reservationDate, r.reservationTime, COUNT(r.reservationId) FROM Reservation r "
			+ "WHERE r.department.deptId = :deptId AND r.reservationDate >= :startDate AND r.reservationDate <= :endDate AND r.reservationStatus = 1 AND r.activeFlg = 1 AND r.doctor.juniorFlg = 1 "
			+ "GROUP BY r.reservationDate, r.reservationTime")
	public List<Object[]> getReservationsByTimeslotBetweenDate(@Param("deptId") Integer deptId, @Param("startDate") String startDate, @Param("endDate") String endDate);
	
	/**
	 * Find distinct timeslot by dept id list.
	 *
	 * @param deptIdList the dept id list
	 * @return the list
	 */
	@Query("SELECT DISTINCT r.department.deptId, r.reservationTime FROM Reservation r "
			+ "WHERE r.department.deptId IN (:deptIdList) ")
	public List<Object[]> findDistinctTimeslotByDeptIdList(@Param("deptIdList") List<Integer> deptIdList);
	
}
