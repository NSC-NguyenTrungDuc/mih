package nta.med.data.dao.medi.ifs;

import java.util.Date;

import nta.med.core.domain.ifs.Ifs0005;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0005Repository extends JpaRepository<Ifs0005, Long>, Ifs0005RepositoryCustom {
	@Modifying
	@Query("	UPDATE Ifs0005							"	
			+"	  SET updId          = :updId       "
			+"	    , updDate        = :updDate          "
			+"	    , bunCode        = :bunCode      "
			+"	    , sgCode         = :sgCode       "
			+"	WHERE hospCode      = :hospCode     "
			+"	  AND nuGubun       = :nuGubun      "
			+"	  AND nuCode        = :nuCode       "
			+"	  AND nuYmd         = :nuYmd        ")
	public Integer updateIFS0004U01Ifs0005(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("bunCode") String bunCode,
			@Param("sgCode") String sgCode,
			@Param("hospCode") String hospCode,
			@Param("nuGubun") String nuGubun,
			@Param("nuCode") String nuCode,
			@Param("nuYmd") Date nuYmd);
	
	@Modifying
	@Query("	DELETE Ifs0005						 "
			+"	WHERE hospCode       = :hospCode     "
			+"	  AND nuGubun        = :nuGubun      "
			+"	  AND nuCode         = :nuCode       "
			+"	  AND nuYmd          = :nuYmd        "
			+"	  AND bunCode       = :bunCode       "
			+"	  AND sgCode        = :sgCode        ")
	public Integer deleteIFS0004U01Ifs0005(
			@Param("hospCode") String hospCode,
			@Param("nuGubun") String nuGubun,
			@Param("nuCode") String nuCode,
			@Param("nuYmd") Date nuYmd,
			@Param("bunCode") String bunCode,
			@Param("sgCode") String sgCode);
}

