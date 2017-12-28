package nta.mss.repository;

import java.util.List;

import nta.mss.entity.VaccineChildHistory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import org.springframework.data.repository.query.Param;

/**
 * The Interface VaccineChildHistoryRepository.
 */
@Repository
public interface VaccineChildHistoryRepository extends JpaRepository<VaccineChildHistory, Integer>{
	
	@Query("SELECT a FROM VaccineChildHistory a, VaccineGroup b, Vaccine c WHERE a.vaccine.vaccineId = c.vaccineId AND b.vaccineGroupId = c.vaccineGroup.vaccineGroupId AND a.userChild.childId = :childId AND b.vaccineGroupId = :vaccineGroupId AND a.activeFlg = 1")
	public List<VaccineChildHistory> findByVaccineIdAndChildId(@Param("childId") Integer childId, @Param("vaccineGroupId") Integer vaccineGroupId);
	
	@Query("SELECT a FROM VaccineChildHistory a, Reservation b WHERE a.reservationId = b.reservationId AND a.reservationId = :reservationId AND a.activeFlg = 1 AND b.activeFlg = 1")
	public VaccineChildHistory findByReservationId(@Param("reservationId") Integer reservationId);
	
	@Query("SELECT a FROM VaccineChildHistory a, Reservation b WHERE a.reservationId = b.reservationId AND a.reservationId = :reservationId AND a.vaccine.vaccineId = :vaccineId AND a.userChild.childId = :childId AND a.activeFlg = 1 AND b.activeFlg = 1")
	public VaccineChildHistory findByVaccineIdChildIdReservationId(@Param("reservationId") Integer reservationId, @Param("vaccineId") Integer vaccineId, @Param("childId") Integer childId);
	
	@Query(value = "SELECT a.* FROM vaccine_child_history a LEFT JOIN reservation b ON a.reservation_id = b.reservation_id WHERE a.child_id = :childId AND a.active_flg = 1 AND IF(a.reservation_id IS NOT NULL, b.reservation_status = 3 AND b.active_flg = 1, true) ORDER BY a.injected_date DESC", nativeQuery = true)
	public List<VaccineChildHistory> findByChildId(@Param("childId") Integer childId);
	
	@Query("SELECT a FROM VaccineChildHistory a WHERE a.activeFlg = 1 AND a.vaccine.vaccineId = :vaccineId AND a.userChild.childId = :childId")
	public List<VaccineChildHistory> findByVaccineId(@Param("vaccineId") Integer vaccineId, @Param("childId") Integer childId);
	
	@Query("SELECT a FROM VaccineChildHistory a WHERE a.activeFlg = 1 AND a.vaccine.vaccineId = :vaccineId AND a.userChild.childId = :childId AND a.injectedNo = :injectedNo")
	public List<VaccineChildHistory> findByVaccineIdInjectedNo(@Param("vaccineId") Integer vaccineId, @Param("childId") Integer childId, @Param("injectedNo") Integer injectedNo);
	
	@Query("SELECT a FROM VaccineChildHistory a, Reservation b WHERE a.reservationId = b.reservationId AND a.userChild.user.userId = :userId AND a.userChild.childId = :childId AND a.activeFlg = 1")
	public List<VaccineChildHistory> findByUserIdChildId(@Param("userId") Integer userId, @Param("childId") Integer childId);
	
	@Query("SELECT a FROM VaccineChildHistory a WHERE a.activeFlg = 1 AND a.vaccine.vaccineId = :vaccineId")
	public List<VaccineChildHistory> findByVaccineId(@Param("vaccineId") Integer vaccineId);
}
