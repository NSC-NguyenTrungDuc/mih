package nta.mss.repository;

import java.util.List;

import nta.mss.entity.UserChild;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface UserChildRepository.
 * 
 */

@Repository
public interface UserChildRepository extends JpaRepository<UserChild, Integer> {
	
	@Query("SELECT child FROM UserChild child WHERE user.userId = :userId AND activeFlg = :activeFlg")
	public List<UserChild> findChildByActiveFlg(@Param("userId") Integer userId, @Param("activeFlg") Integer activeFlg);
	
	@Query("SELECT child FROM UserChild child WHERE patient.patientId = :patientId AND activeFlg = 1")
	public List<UserChild> findUserChildByPatientId(@Param("patientId") Integer patientId);
	
}
