package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm4100;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4100Repository extends JpaRepository<Adm4100, Long>, Adm4100RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Adm4100					    "
			+"	   SET pgmId       = :pgmId,        "
			+"	       menuTitle   = :menuTitle,    "
			+"	       trSeq      = :trSeq,         "
			+"	       upprMenu   = :upprMenu,      "
			+"	       pgmOpenTp  = :pgmOpenTp,     "
			+"	       menuParam  = :menuParam,     "
			+"	       upMemb     = :upMemb,        "
			+"	       upTrm      = :upTrm,         "
			+"	       upTime     = :upTime         "
			+"	 WHERE sysId      = :sysId          "
			+"	   AND trId       = :trId           "
			+"	   AND language   = :language       "
			+ " AND    pgmId      = :pgmId          ")
	public Integer updateAdm106UAdm4100(
			@Param("pgmId") String pgmId,
			@Param("menuTitle") String menuTitle,
			@Param("trSeq") Double trSeq,
			@Param("upprMenu") String upprMenu,
			@Param("pgmOpenTp") String pgmOpenTp,
			@Param("menuParam") String menuParam,
			@Param("upMemb") String upMemb,
			@Param("upTrm") String upTrm,
			@Param("upTime") Date upTime,
			@Param("sysId") String sysId,
			@Param("trId") String trId,
			@Param("language") String language);
	
	@Modifying
	@Query("	DELETE FROM Adm4100 				"
		   +"	WHERE sysId = :sysId        "
		   +"	AND trId  = :trId AND language = :language          ")
	public Integer deleteAdm106UAdm4100(
			@Param("sysId") String sysId,
			@Param("trId") String trId,
			@Param("language") String language);
	
	@Modifying
	@Query("	DELETE FROM Adm4100 				"
		   +"	WHERE sysId = :sysId        "
		   +"	AND upprMenu  = :trId   AND language = :language  ")
	public Integer deleteAdm106UAdm4100CaseChkEqualsX(
			@Param("sysId") String sysId,
			@Param("trId") String trId,
			@Param("language") String language);
	
	
}

