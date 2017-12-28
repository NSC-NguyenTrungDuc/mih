package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl2090;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl2090Repository extends JpaRepository<Cpl2090, Long>, Cpl2090RepositoryCustom {
	@Query("SELECT DISTINCT 'Y' FROM Cpl2090 WHERE hospCode = :hospCode "
			+ "AND jundalPart = :jundalPart AND specimenSer = :specimenSer")
	public String checkExitCPL3020U02ExecuteCase2(@Param("hospCode") String hospCode,
			@Param("jundalPart") String jundalPart,
			@Param("specimenSer") String specimenSer);
	
	@Modifying
	@Query("UPDATE Cpl2090 SET updId = :updId , updDate = :updDate, note = :note"
			+ ", code = :code, etcComment  = :etcComment WHERE hospCode = :hospCode "
			+ "AND jundalPart = :jundalPart AND specimenSer = :specimenSer")
	public Integer updateCPL3020U02ExecuteCase2(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("code") String code,
			@Param("note") String note,
			@Param("etcComment") String etcComment,
			@Param("hospCode") String hospCode,
			@Param("jundalPart") String jundalPart,
			@Param("specimenSer") String specimenSer);

	@Modifying
	@Query("	UPDATE Cpl2090					        "
			+"	  SET updId        = :updId             " 
			+"	    , updDate     = SYSDATE()           " 
			+"	    , note         = :note              " 
			+"	    , code         = :code              " 
			+"	    , etcComment  = :etcComment         " 
			+"	WHERE hospCode    = :hospCode           " 
			+"	  AND jundalPart  = :jundalPart         " 
			+"	  AND specimenSer = :specimenSer        ")
	public Integer updateCPL3020U00CPL2090(@Param("updId") String updId,
			@Param("note") String note,
			@Param("code") String code,
			@Param("etcComment") String etcComment,
			@Param("jundalPart") String jundalPart,
			@Param("specimenSer") String specimenSer,
			@Param("hospCode") String hospCode);
}

