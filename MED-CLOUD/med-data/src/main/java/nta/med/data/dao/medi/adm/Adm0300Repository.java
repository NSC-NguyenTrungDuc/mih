package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm0300;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0300Repository extends JpaRepository<Adm0300, Long>, Adm0300RepositoryCustom {
	
	@Modifying
	@Query("		UPDATE Adm0300					  "
			+"      SET pgmNm        = :pgmNm         " 
			+"         ,pgmTp        = :pgmTp         " 
			+"         ,sysId        = :sysId         " 
			+"         ,prodId      = :prodId         " 
			+"         ,srvcId      = :srvcId         " 
			+"         ,pgmEntGrad = :pgmEntGrad      " 
			+"         ,pgmUpdGrad = :pgmUpdGrad      " 
			+"         ,pgmScrt     = :pgmScrt        " 
			+"         ,pgmDupYn   = :pgmDupYn        " 
			+"         ,pgmAcsYn   = :pgmAcsYn        " 
			+"         ,endYn       = :endYn          " 
			+"         ,mangMemb    = :mangMemb       " 
			+"         ,asmName     = :asmName        " 
			+"         ,upMemb     = :upMemb          " 
			+"         ,upTime     = :upTime        " 
			+"    WHERE pgmId      = :pgmId           "
			+"    AND language = :language          ")
	public Integer updateAdm102UAdm0300(
			@Param("pgmNm") String pgmNm,
			@Param("pgmTp") String pgmTp,
			@Param("sysId") String sysId,
			@Param("prodId") String prodId,
			@Param("srvcId") String srvcId,
			@Param("pgmEntGrad") Double pgmEntGrad,
			@Param("pgmUpdGrad") Double pgmUpdGrad,
			@Param("pgmScrt") String pgmScrt,
			@Param("pgmDupYn") String pgmDupYn,
			@Param("pgmAcsYn") String pgmAcsYn,
			@Param("endYn") String endYn,
			@Param("mangMemb") String mangMemb,
			@Param("asmName") String asmName,
			@Param("upMemb") String upMemb,
			@Param("upTime") Date upTime,
			@Param("pgmId") String pgmId,
			@Param("language") String language);
	
	
	@Modifying
	@Query("DELETE Adm0300               "
			+ " WHERE pgmId = :pgmId     "
			+ " AND language = :language ")
	public Integer deleteAdm102UAdm0300(
			@Param("pgmId") String pgmId,
			@Param("language") String language);
}

