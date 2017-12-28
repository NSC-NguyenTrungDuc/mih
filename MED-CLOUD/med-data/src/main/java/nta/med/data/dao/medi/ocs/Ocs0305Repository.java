package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0305;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0305Repository extends JpaRepository<Ocs0305, Long>, Ocs0305RepositoryCustom {
	
	@Modifying                                                                   
	@Query("	UPDATE Ocs0305												"			
			+"	  SET updId             = :updId       ,               "
			+"	      updDate           = SYSDATE()          ,             "
			+"	      directGubun       = :directGubun  ,               "
			+"	      directCode        = :directCode   ,               "
			+"	      directCont1       = :directCont1  ,               "
			+"	      directCont2       = :directCont2  ,               "
			+"	      directText        = :directText                   "
			+"	WHERE memb               = :doctor                        "
			+"	  AND membGubun         = :membGubun 		            "
			+"	  AND yaksokDirectCode = :yaksokDirectCode            "
			+"	  AND pkSeq             = :pkSeq                        "
			+"	  AND hospCode          = :hospCode                     ")
	public Integer updateOcsaOCS0304U00UOCS0305(@Param("updId") String updId,
			@Param("directGubun") String directGubun,
			@Param("directCode") String directCode,
			@Param("directCont1") String directCont1,
			@Param("directCont2") String directCont2,
			@Param("directText") String directText,
			@Param("doctor") String doctor,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	@Modifying                                                                   
	@Query(  "		DELETE Ocs0305 													"
			 +"		WHERE memb               = :doctor                           " 
			 +"		  AND membGubun         = :membGubun                       " 
			 +"		  AND yaksokDirectCode = :yaksokDirectCode               " 
			 +"		  AND pkSeq             = :pkSeq                           " 
			 +"		  AND hospCode          = :hospCode                        " )
	public Integer deleteOcsaOCS0304U00OCS0305(@Param("doctor") String doctor,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
}


