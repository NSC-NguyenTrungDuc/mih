package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0306;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0306Repository extends JpaRepository<Ocs0306, Long>, Ocs0306RepositoryCustom {
		
	@Modifying                                                                      
	@Query( "	UPDATE Ocs0306													    "
			+"	   SET updId             = :updId      ,                            "
			+"	       updDate           = SYSDATE()         ,                      "
			+"	       seq                = :seq          ,                         "
			+"	       hangmogCode       = :hangmogCode ,                           "
			+"	       suryang            = :suryang      ,                         "
			+"	       nalsu              = :nalsu        ,                         "
			+"	       ordDanui          = :ordDanui    ,                           "
			+"	       bogyongCode       = :bogyongCode ,                           "
			+"	       jusaCode          = :jusaCode    ,                           "
			+"	       jusaSpdGubun     = :jusaSpdGubun,                            "
			+"	       dv                 = :dv           ,                         "
			+"	       dvTime            = :dvTime      ,                           "
			+"	       insulinFrom       = :insulinFrom ,                           "
			+"	       insulinTo         = :insulinTo   ,                           "
			+"	       timeGubun         = :timeGubun   ,                           "
			+"	       bomYn             = :bomYn       ,                           "
			+"	       bomSourceKey     = :bomSourceKey                             "
			+"	 WHERE memb               = :doctor                                 "
			+"	   AND membGubun         =  :membGubun  					        "
			+"	   AND yaksokDirectCode = :yaksokDirectCode                         "
			+"	   AND directGubun       = :directGubun                             "
			+"	   AND directCode        = :directCode                              "
			+"	   AND pkSeq             = :pkSeq                                   "
			+"	   AND hospCode          = :hospCode                                ")
	public Integer updateOcsaOCS0304U00UOCS0306(@Param("updId") String updId,
			@Param("seq") Double seq,
			@Param("hangmogCode") String hangmogCode,
			@Param("suryang") Double suryang,
			@Param("nalsu") Double nalsu,
			@Param("ordDanui") String ordDanui,
			@Param("bogyongCode") String bogyongCode,
			@Param("jusaCode") String jusaCode,
			@Param("jusaSpdGubun") String jusaSpdGubun,
			@Param("dv") Double dv,
			@Param("dvTime") String dvTime,
			@Param("insulinFrom") Double insulinFrom,
			@Param("insulinTo") Double insulinTo,
			@Param("timeGubun") String timeGubun,
			@Param("bomYn") String bomYn,
			@Param("bomSourceKey") Double bomSourceKey,
			@Param("doctor") String doctor,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("directGubun") String directGubun,
			@Param("directCode") String directCode,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	@Modifying                                                                   
	@Query(  "		DELETE Ocs0306 													"
			 +"		WHERE memb               = :doctor                           " 
			 +"		  AND membGubun         = :membGubun                       " 
			 +"		  AND yaksokDirectCode = :yaksokDirectCode               " 
			 +"		  AND pkSeq             = :pkSeq                           " 
			 +"		  AND hospCode          = :hospCode                        " )
	public Integer deleteOcsaOCS0304U00OCS0306(@Param("doctor") String doctor,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
}

