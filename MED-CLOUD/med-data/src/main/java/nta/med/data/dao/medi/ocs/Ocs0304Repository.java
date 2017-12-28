package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0304;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0304Repository extends JpaRepository<Ocs0304, Long>, Ocs0304RepositoryCustom {
	
	@Modifying                                                                   
	@Query("         UPDATE Ocs0304												 "
			+"      SET updId             = :updId           ,                    "
			+"          updDate           = SYSDATE()              ,              "
			+"          seq                = :seq               ,                 "
			+"          yaksokDirectName  = :yaksokDirectName ,                    "
			+"          ment               = :ment                                "
			+"    WHERE memb               = :doctor                              "
			+"      AND membGubun         =  :membGubun   					      "
			+"      AND yaksokDirectCode = :yaksokDirectCode                      "
			+"      AND hospCode          = :hospCode                             ")
	public Integer updateOcsaOCS0304U00OCS0304(@Param("updId") String updId,
			@Param("seq") Double seq,
			@Param("yaksokDirectName") String yaksokDirectName,
			@Param("doctor") String doctor,
			@Param("ment") String ment,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("hospCode") String hospCode);
	
	@Modifying                                                                   
	@Query("	 DELETE Ocs0304														"		
			+"	  WHERE memb               = :doctor                              "
			+"	 AND membGubun         = :membGubun 					        "
			+"	 AND yaksokDirectCode = :yaksokDirectCode                     "
			+"	 AND hospCode          = :hospCode                              ")
	public Integer deleteOcsaOCS0304U00OCS0304(@Param("doctor") String doctor,
			@Param("membGubun") String membGubun,
			@Param("yaksokDirectCode") String yaksokDirectCode,
			@Param("hospCode") String hospCode);
}

