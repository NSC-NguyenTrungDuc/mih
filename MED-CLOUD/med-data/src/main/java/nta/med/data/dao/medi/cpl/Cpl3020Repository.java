package nta.med.data.dao.medi.cpl;

import java.util.Date;

import nta.med.core.domain.cpl.Cpl3020;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
/**
 * @author dainguyen.
 */
@Repository
public interface Cpl3020Repository extends JpaRepository<Cpl3020, Long>, Cpl3020RepositoryCustom {
	@Modifying
	@Query("UPDATE Cpl3020 SET updId = :updId, updDate = :updDate, confirmYn = 'Y', confirmDate = :updDate"
			+ ",gumsaja1 = :gumsaja1 WHERE hospCode = :hospCode AND pkcpl3020 = :pkcpl3020")
	public Integer updateCPL3020U02ExecuteConfirmY(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("gumsaja1") String gumsaja1,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	
	@Modifying
	@Query("UPDATE Cpl3020 SET updId = :updId, updDate = :updDate, confirmYn = 'N', confirmDate = NULL "
			+ ",gumsaja1 = NULL WHERE hospCode = :hospCode AND pkcpl3020 = :pkcpl3020")
	public Integer updateCPL3020U02ExecuteConfirmN(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	
	@Modifying
	@Query("UPDATE Cpl3020 SET updId = :updId, updDate = :updDate"
			+ ", comments = :comments, displayYn = :displayYn "
			+ "WHERE hospCode = :hospCode AND pkcpl3020 = :pkcpl3020")
	public Integer updateCPL3020U02ExecuteCase1(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("comments") String comments,
			@Param("displayYn") String displayYn,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);

	@Modifying
	@Query("DELETE Cpl3020 WHERE fkcpl2010 = :f_pkcpl2010")
	public Integer deleteCPL2010U00OrderCancelDeleteCpl3020(@Param("f_pkcpl2010") Double fkcpl2010);
	
	@Query("SELECT COUNT(*) FROM Cpl3020 WHERE specimenSer = :f_specimen_ser")
	public Integer getCountCPL2010U00OrderCancelDelete(@Param("f_specimen_ser") String specimenSer);
	@Modifying
	@Query("	UPDATE Cpl3020				      "
	      +"  SET updId           = :updId      "
	      +"   , sysDate         = SYSDATE()       "
	      +"   , confirmDate     = NULL            "
	      +"   , confirmYn       = 'N'             "
	      +"  WHERE hospCode        = :hospCode "
	      +"    AND pkcpl3020        = :pkcpl3020 ")
	public Integer updateCPL3020U00Cpl3020(@Param("updId") String updId,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	

	@Modifying
	@Query("	UPDATE Cpl3020					      "
			+"	  SET updId       = :updId            "
			+"	    , updDate     = :updDate        "
			+"	    , comments     = :comments        "
			+"	    , displayYn   = :displayYn        "
			+"	WHERE hospCode    = :hospCode         "
			+"	  AND pkcpl3020    = :pkcpl3020       ")
	public Integer updateCPL3020U00Cpl3020Final(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("comments") String comments,
			@Param("displayYn") String displayYn,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	
	@Modifying
	@Query("   UPDATE Cpl3020												"
			+"   SET updId       = :updId                              "
			+"     , updDate     = :updDate                               "
			+"     , resultYn    = 'Y'                                     "
			+"     , standardYn  = :standardYn                          "
			+"     , panicYn     = :panicYn                             "
			+"     , resultDate  = :updDate                               "
			+"     , resultTime  = :updTime                           "
			+"     , cplResult   = :cplResult                           "
			+" WHERE hospCode    = :hospCode                            "
			+"   AND pkcpl3020    = :pkcpl3020                            ")
	public Integer updateCPL3020U00Cpl3020Else(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("updTime") String updTime,
			@Param("standardYn") String standardYn,
			@Param("panicYn") String panicYn,
			@Param("cplResult") String cplResult,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	

	@Modifying
	@Query("     UPDATE Cpl3020					  "
			+"    SET updId      = :updId         " 
			+"      , updDate    = :updDate       " 
			+"      , resultYn   = 'N'            " 
			+"      , resultDate = NULL           " 
			+"      , resultTime = NULL           " 
			+"      , cplResult  = NULL           " 
			+"      , gumsaja     = NULL          " 
			+"  WHERE hospCode   = :hospCode      " 
			+"    AND pkcpl3020   = :pkcpl3020    " )
	public Integer updateCPL3020U00Cpl3020CplResult(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	
	@Modifying
	@Query("     UPDATE Cpl3020					  "
			+"    SET updId      = :updId         " 
			+"      , updDate    = :sysDate      " 
			+"      , resultYn   = 'Y'            " 
			+"		, resultDate  = :sysDate      "
			+"		, resultTime  = :sysTime       "
			+"      , cplResult  = :cplResult     " 
			+"  WHERE hospCode   = :hospCode      " 
			+"    AND pkcpl3020   = :pkcpl3020    " )
	public Integer updateCPL3020U02Cpl3020CplResult(@Param("updId") String updId,
			@Param("sysDate") Date sysDate,
			@Param("sysTime") String sysTime,
			@Param("hospCode") String hospCode,
			@Param("cplResult") String cplResult,
			@Param("pkcpl3020") Double pkcpl3020);
	
	@Modifying                                    
	@Query("	UPDATE Cpl3020						 "
			+"	  SET updId       = :updId           " 
			+"	    , updDate     = SYSDATE()        " 
			+"	    , confirmYn   = :confirmYn       " 
			+"	    , confirmDate = :confirmDate     " 
			+"	    , gumsaja1     = :gumsaja1       " 
			+"	WHERE hospCode    = :hospCode        " 
			+"	  AND pkcpl3020    = :pkcpl3020      ") 
	public Integer updateCPL3020U00Cpl3020ConfirmYN(@Param("updId") String updId,
			@Param("confirmYn") String confirmYn,
			@Param("confirmDate") Date confirmDate,
			@Param("gumsaja1") String gumsaja1,
			@Param("hospCode") String hospCode,
			@Param("pkcpl3020") Double pkcpl3020);
	
}

