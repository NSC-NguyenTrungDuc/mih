package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0802;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0802Repository extends JpaRepository<Ocs0802, Long>, Ocs0802RepositoryCustom {
	@Query("SELECT A.patStatusCodeName FROM Ocs0802 A WHERE A.hospCode= :f_hosp_code AND A.language  =:f_language "
			+ "AND A.patStatus  = :f_pat_status AND A.patStatusCode = :f_code ")
	public String getOCS0803U00GetCodeNameCaseBreakPatStatusCode(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_pat_status") String patStatus,@Param("f_code") String code);
	
	
	@Modifying                                          
	@Query("	UPDATE Ocs0802							"
			+"	SET updId          = :updId        ,    " 
			+"	    updDate        = SYSDATE()    ,     " 
			+"	    patStatusCodeName = :patStatusCodeName,     " 
			+"	    ment            = :ment           , " 
			+"	    seq             = :seq              " 
			+"	WHERE patStatus      = :patStatus       " 
			+"	  AND patStatusCode       = :patStatusCode        "
			+"	  AND hospCode       = :hospCode        " 
			+"	 AND language        = :language        ") 
	public Integer updateOCS0801TransactionalOcs0802Modified(
			@Param("updId") String updId,
			@Param("patStatusCodeName") String patStatusCodeName,
			@Param("ment") String ment,
			@Param("seq") Double seq,
			@Param("patStatusCode") String patStatusCode,
			@Param("patStatus") String patStatus,
			@Param("hospCode") String hospCode,
			@Param("language") String language);
	
	@Modifying                                          
	@Query(" DELETE FROM Ocs0802				    "
			+" WHERE patStatus = :patStatus         "
			+"	  AND patStatusCode       = :patStatusCode        "
			+"   AND hospCode  = :hospCode          "
			+"   AND language  = :language          ") 
	public Integer deleteOCS0801TransactionalOcs0802Deleted(
			@Param("patStatus") String patStatus,
			@Param("patStatusCode") String patStatusCode,
			@Param("hospCode") String hospCode,
			@Param("language") String language);
}

