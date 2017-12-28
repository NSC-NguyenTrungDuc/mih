package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0130;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0130Repository extends JpaRepository<Drg0130, Long>, Drg0130RepositoryCustom {
	
	@Modifying                                                   
	@Query("	UPDATE Drg0130             				       "
			+"	  SET cautionName  = :cautionName ,            "
			+"	     cautionName2 = :cautionName2,             "
			+"	     jobType      = :jobType     ,             "
			+"	     updId        = :updId       ,             "
			+"	     updDate      = SYSDATE()                  "
			+"	WHERE cautionCode  = :cautionCode              "  
			+"	  AND hospCode     = :hospCode  AND language = :language               "  )
	public Integer updateDrgsDRG0130U00Drg0130(@Param("cautionName") String cautionName,
			@Param("cautionName2") String cautionName2,
			@Param("jobType") String jobType,
			@Param("updId") String updId,
			@Param("cautionCode") String cautionCode,
			@Param("hospCode") String hospCode,
			@Param("language") String language);
			
	@Modifying                                                                   
	@Query("	DELETE Drg0130							"	
			+"	WHERE cautionCode = :cautionCode        "
			+"	AND hospCode    = :hospCode   AND language = :language          ")
	public Integer deleteDrgsDRG0130U00Drg0130(@Param("cautionCode") String cautionCode,
			@Param("hospCode") String hospCode,
			@Param("language") String language);
	
	@Query("SELECT cautionName FROM Drg0130 WHERE hospCode = :f_hosp_code AND cautionCode = :f_caution_code  AND language = :language  ")
	public String getDRGOCSCHKCautionCodeDataValidating(@Param("f_caution_code") String cautionCode,
			@Param("f_hosp_code") String hospCode,
			@Param("language") String language);
}

