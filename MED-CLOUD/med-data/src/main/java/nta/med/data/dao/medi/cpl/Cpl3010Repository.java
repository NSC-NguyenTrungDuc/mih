package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl3010;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl3010Repository extends JpaRepository<Cpl3010, Long>, Cpl3010RepositoryCustom {
	@Modifying
	@Query("DELETE Cpl3010 WHERE specimenSer = :f_specimen_ser")
	public Integer deleteCPL2010U00OrderCancelDeleteCpl3010(@Param("f_specimen_ser") String specimenSer);
	
	@Modifying
	@Query("	UPDATE Cpl3010									   "
			+"	SET updId       = :updId                           " 
			+"	    , updDate     = :updDate                      " 
			+"	    , resultDate  = :updDate                      " 
			+"	    , resultTime  = :updTime                      " 
			+"	WHERE hospCode    = :hospCode                      " 
			+"	  AND labNo       = :labNo                         " 
			+"	  AND specimenSer = :specimenSer                   ") 
	public Integer updateCPL3020U00CPL3010Else(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("updTime") String updTime,
			@Param("hospCode") String hospCode,
			@Param("labNo") String labNo,
			@Param("specimenSer") String specimenSer);
	
	@Modifying
	@Query("		UPDATE Cpl3010						    "
			+"		  SET updId       = :updId              "
			+"		    , updDate     = :updDate            "
			+"		    , resultDate  = DATE_FORMAT(:resultDate ,'%Y/%m/%d')         "
			+"		    , resultTime  = DATE_FORMAT(:resultTime,'%k%i')        "
			+"		WHERE hospCode    = :hospCode           "
			+"		  AND labNo       = :labNo              "
			+"		  AND specimenSer = :specimenSer        ")
	public Integer updateCPL3020U00CPL3010CplResult(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("resultDate") Date resultDate,
			@Param("resultTime") Date resultTime,
			@Param("hospCode") String hospCode,
			@Param("labNo") String labNo,
			@Param("specimenSer") String specimenSer);
	
	@Modifying
	@Query("	UPDATE Cpl3010									   "
			+"	SET updId       = :updId                           " 
			+"	    , updDate     = SYSDATE()                      " 
			+"	    , resultDate  = SYSDATE()                      " 
			+"	    , resultTime  = DATE_FORMAT(SYSDATE(),'%k%i')  " 
			+"	WHERE hospCode    = :hospCode                      " 
			+"	  AND specimenSer = SUBSTR(:specimenSer,3)        ") 
	public Integer updateCPL3010U01CPL3010(@Param("updId") String updId,
			@Param("hospCode") String hospCode,
			@Param("specimenSer") String specimenSer);
}

