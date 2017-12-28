package nta.med.data.dao.medi.ifs;

import java.util.Date;

import nta.med.core.domain.ifs.Ifs0004;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs0004Repository extends JpaRepository<Ifs0004, Long>, Ifs0004RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ifs0004 					      "
			+"	  SET updId         = :updId          "
			+"	    , updDate       = :updDate        "
			+"	    , nuCodeName   = :nuCodeName      "
			+"	WHERE hospCode      = :hospCode       "
			+"	  AND nuGubun       = :nuGubun        "
			+"	  AND nuCode        = :nuCode         "
			+"	  AND nuYmd         = :nuYmd          ")
	public Integer updateIFS0004U01ifs0004(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("nuCodeName") String nuCodeName,
			@Param("hospCode") String hospCode,
			@Param("nuGubun") String nuGubun,
			@Param("nuCode") String nuCode,
			@Param("nuYmd") Date nuYmd);
	
	@Modifying
	@Query("    DELETE Ifs0004 							 "
			+"	WHERE hospCode      = :hospCode       "
			+"	  AND nuGubun       = :nuGubun        "
			+"	  AND nuCode        = :nuCode         "
			+"	  AND nuYmd         = :nuYmd          ")
	public Integer deleteIFS0004U01ifs0004(
			@Param("hospCode") String hospCode,
			@Param("nuGubun") String nuGubun,
			@Param("nuCode") String nuCode,
			@Param("nuYmd") Date nuYmd);
	
}

