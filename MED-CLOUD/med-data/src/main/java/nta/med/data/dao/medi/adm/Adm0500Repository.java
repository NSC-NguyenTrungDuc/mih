package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm0500;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0500Repository extends JpaRepository<Adm0500, Long>, Adm0500RepositoryCustom {
	@Modifying
	@Query("	UPDATE Adm0500									"
			+"	   SET pgmSysId = :pgmSysId       				"
			+"	      ,pgmId     = :pgmId          		 		"
			+"	      ,upMemb    = :userId          			"
			+"	      ,upTime    = :upTime             			"
			+"	      ,seq 		 = :newSeq        	 			"
			+"	 WHERE sysId = :sysId               			"
			+"	   AND seq = :oldSeq AND hospCode = :hospCode	")
	public Integer updateAdm108UModified(
			@Param("pgmSysId") String pgmSysId,
			@Param("pgmId") String pgmId,
			@Param("userId") String userId,
			@Param("upTime") Date upTime,
			@Param("newSeq") Double newSeq,
			@Param("sysId") String sysId,
			@Param("oldSeq") Double oldSeq,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("	DELETE Adm0500			 					"
			+"	WHERE sysId = :sysId     					"
			+"	AND seq    = :seq AND hospCode = :hospCode	")
	public Integer deleteAdm108UDeleted(
			@Param("sysId") String sysId,
			@Param("seq") Double seq,
			@Param("hospCode") String hospCode);
	
}

