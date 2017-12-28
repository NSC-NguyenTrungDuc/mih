package nta.med.data.dao.medi.clis;

import java.util.Date;

import nta.med.core.domain.clis.ClisPatientStatus;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface ClisPatientStatusRepository  extends JpaRepository<ClisPatientStatus, Long>, ClisPatientStatusRepositoryCustom {

	@Modifying
	@Query("	UPDATE ClisPatientStatus						"
			+ "		SET updateDate = :updateDate,          	 	"
			+ "	    	updId = :updId,                     	"
			+ "	    	updated = SYSDATE()                 	"
			+ "	    WHERE patientStatusId = :patientStatusId	")
	public Integer updateCLIS2015U04UpdateStatusPatientItem(
			@Param("updateDate") Date updateDate,
			@Param("updId") String userId,
			@Param("patientStatusId") Integer patientStatusId);
}
