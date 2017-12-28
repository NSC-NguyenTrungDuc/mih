package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl0001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0001Repository extends JpaRepository<Cpl0001, Long>, Cpl0001RepositoryCustom {
	
	@Modifying
	@Query("	 UPDATE Cpl0001					    "
			+"	  SET updId          = :updId       " 
			+"	     , sysDate       = :sysDate     " 
			+"	     , slipName      = :slipName    "  
			+"	     , slipNameRe    = :slipNameRe  " 
			+"	     , jundalGubun   = :jundalGubun " 
			+"	WHERE hospCode       = :hospCode    " 
			+"	AND slipCode         = :slipCode    ") 
	public Integer updateCPL0001U00GrdSave(
			@Param("updId") String updId,
			@Param("sysDate") Date sysDate,
			@Param("slipName") String slipName,
			@Param("slipNameRe") String slipNameRe,
			@Param("jundalGubun") String jundalGubun,
			@Param("hospCode") String hospCode,
			@Param("slipCode") String slipCode);
	
	@Modifying
	@Query("	 DELETE FROM Cpl0001				"
			+"	WHERE hospCode       = :hospCode    " 
			+"	AND slipCode         = :slipCode    ") 
	public Integer deleteCPL0001U00GrdSave(
			@Param("hospCode") String hospCode,
			@Param("slipCode") String slipCode);
}

