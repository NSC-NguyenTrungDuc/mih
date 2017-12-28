package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0801;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;


/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0801Repository extends JpaRepository<Ocs0801, Long>, Ocs0801RepositoryCustom {
	@Query("SELECT A.patStatusName  FROM Ocs0801 A WHERE A.language= :f_language AND A.patStatus  = :f_code ")
	public String getOCS0803U00GetCodeNameCasePatStatus(@Param("f_language") String language,@Param("f_code") String code);
	
	@Modifying                                          
	@Query("	UPDATE Ocs0801							"
			+"	SET updId          = :updId        ,    " 
			+"	    updDate        = SYSDATE()    ,     " 
			+"	    patStatusName = :patStatusName,     " 
			+"	    ment            = :ment           , " 
			+"	    seq             = :seq              " 
			+"	WHERE patStatus      = :patStatus       " 
			+"	 AND language        = :language        ") 
	public Integer updateOCS0801TransactionalModified(
			@Param("updId") String updId,
			@Param("patStatusName") String patStatusName,
			@Param("ment") String ment,
			@Param("seq") Double seq,
			@Param("patStatus") String patStatus,
			@Param("language") String language);
	
	@Modifying                                          
	@Query(" DELETE FROM Ocs0801				    "
			+" WHERE patStatus = :patStatus         "
			+"   AND language  = :language          ") 
	public Integer deleteOCS0801TransactionalDeleted(
			@Param("patStatus") String patStatus,
			@Param("language") String language);
}

