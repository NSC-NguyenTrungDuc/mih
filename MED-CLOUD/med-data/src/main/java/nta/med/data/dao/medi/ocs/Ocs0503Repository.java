package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0503;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0503Repository extends JpaRepository<Ocs0503, Long>,
		Ocs0503RepositoryCustom {
	@Modifying
	@Query("	UPDATE Ocs0503												"
			+ "	   SET updId             = :updId          		 ,          "
			+ "	       updDate           = SYSDATE()           	 ,          "
			+ "	       consultGwa        = :consultGwa         	 ,          "
			+ "	       consultDoctor     = :consultDoctor      	 ,          "
			+ "	       wangjinYn         = :wangjinYn            ,          "
			+ "	       sangCode1         = :sangCode1            ,          "
			+ "	       sangName1         = :sangName1            ,          "
			+ "	       sangCode2         = :sangCode2            ,          "
			+ "	       sangName2         = :sangName2            ,          "
			+ "	       sangCode3         = :sangCode3            ,          "
			+ "	       sangName3         = :sangName3            ,          "
			+ "	       reqRemark         = :reqRemark            ,          "
			+ "	       appDate           = :appDate              ,          "
			+ "	       answer             = :answer              ,          "
			+ "	       inOutGubun       = :inOutGubun            ,          "
			+ "	       fkinp1001          = :fkinp1001           ,          "
			+ "	       printYn           = :printYn              ,          "
			+ "	       emerGubun         = :emerGubun            ,          "
			+ "	       realJinryoDate   = :realJinryoDate        ,          "
			+ "	       resultArriveDate = :resultArriveDate      ,          "
			+ "	       confirmYn         = :confirmYn            ,          "
			+ "	       answerEndYn      = :answerEndYn           ,          "
			+ "	       jinryoPreDate    = :jinryoPreDate         ,          "
			+ "	       ampmGubun         = :ampmGubun            ,          "
			+ "	       reqEndYn         = :reqEndYn              ,          "
			+ "	       displayYn         = :displayYn            ,          "
			+ "	       consultSangName  = :consultSangName                  "
			+ "	 WHERE hospCode          = :hospCode                       "
			+ "	   AND pkocs0503          = :pkocs0503                      ")
	public Integer updateOCS0503U01(@Param("updId") String updId,
			@Param("consultGwa") String consultGwa,
			@Param("consultDoctor") String consultDoctor,
			@Param("wangjinYn") String wangjinYn,
			@Param("sangCode1") String sangCode1,
			@Param("sangName1") String sangName1,
			@Param("sangCode2") String sangCode2,
			@Param("sangName2") String sangName2,
			@Param("sangCode3") String sangCode3,
			@Param("sangName3") String sangName3,
			@Param("reqRemark") String reqRemark,
			@Param("appDate") Date appDate, @Param("answer") String answer,
			@Param("inOutGubun") String inOutGubun,
			@Param("fkinp1001") Double fkinp1001,
			@Param("printYn") String printYn,
			@Param("emerGubun") String emerGubun,
			@Param("realJinryoDate") Date realJinryoDate,
			@Param("resultArriveDate") Date resultArriveDate,
			@Param("confirmYn") String confirmYn,
			@Param("answerEndYn") String answerEndYn,
			@Param("jinryoPreDate") Date jinryoPreDate,
			@Param("ampmGubun") String ampmGubun,
			@Param("reqEndYn") String reqEndYn,
			@Param("displayYn") String displayYn,
			@Param("consultSangName") String consultSangName,
			@Param("hospCode") String hospCode,
			@Param("pkocs0503") Double pkocs0503);

	@Modifying
	@Query("DELETE Ocs0503  WHERE hospCode = :hospCode AND pkocs0503  = :pkocs0503")
	public Integer deleteOCS0503U01(@Param("hospCode") String hospCode,
			@Param("pkocs0503") Double pkocs0503);
	
	@Query("SELECT MAX(A.reqDate) FROM Ocs0503 A WHERE hospCode = :hospCode AND A.bunho = :bunho "
			+ "AND SUBSTR(A.reqDoctor, 3)  = :reqDoctor "
			+ "AND IFNULL(A.answerEndYn, 'N') = 'Y' AND IFNULL(A.reqEndYn   , 'N') = 'N'")
	public Date getLoadConsultEndYN(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("reqDoctor") String reqDoctor);
	
	@Modifying
	@Query("	UPDATE Ocs0503												"
			+ "	   SET updId             = :updId          		 ,          "
			+ "	       updDate           = SYSDATE()           	 ,          "
			+ "	       consultGwa        = :consultGwa         	 ,          "
			+ "	       consultDoctor     = :consultDoctor      	 ,          "
			+ "	       wangjinYn         = :wangjinYn            ,          "
			+ "	       sangCode1         = :sangCode1            ,          "
			+ "	       sangName1         = :sangName1            ,          "
			+ "	       sangCode2         = :sangCode2            ,          "
			+ "	       sangName2         = :sangName2            ,          "
			+ "	       sangCode3         = :sangCode3            ,          "
			+ "	       sangName3         = :sangName3            ,          "
			+ "	       reqRemark         = :reqRemark            ,          "
			+ "	       appDate           = :appDate              ,          "
			+ "	       answer             = :answer              ,          "
			+ "	       inOutGubun       = :inOutGubun            ,          "
			+ "	       fkinp1001          = :fkinp1001           ,          "
			+ "	       printYn           = :printYn              ,          "
			+ "	       emerGubun         = :emerGubun            ,          "
			+ "	       realJinryoDate   = :realJinryoDate        ,          "
			+ "	       resultArriveDate = :resultArriveDate      ,          "
			+ "	       confirmYn         = :confirmYn            ,          "
			+ "	       answerEndYn      = :answerEndYn           ,          " 
			+ "	       jinryoPreDate    = :jinryoPreDate         ,          "
			+ "	       reserTime    = :reserTime                 ,          "
			+ "	       reqEndYn         = :reqEndYn              ,          "
			+ "	       displayYn         = :displayYn            ,          "
			+ "	       consultSangName  = :consultSangName                  "
			+ "	 WHERE hospCode          = :hospCode                       "
			+ "	   AND pkocs0503          = :pkocs0503                      ")
	public Integer updateOCS0503U00(@Param("updId") String updId,
			@Param("consultGwa") String consultGwa,
			@Param("consultDoctor") String consultDoctor,
			@Param("wangjinYn") String wangjinYn,
			@Param("sangCode1") String sangCode1,
			@Param("sangName1") String sangName1,
			@Param("sangCode2") String sangCode2,
			@Param("sangName2") String sangName2,
			@Param("sangCode3") String sangCode3,
			@Param("sangName3") String sangName3,
			@Param("reqRemark") String reqRemark,
			@Param("appDate") Date appDate, @Param("answer") String answer,
			@Param("inOutGubun") String inOutGubun,
			@Param("fkinp1001") Double fkinp1001,
			@Param("printYn") String printYn,
			@Param("emerGubun") String emerGubun,
			@Param("realJinryoDate") Date realJinryoDate,
			@Param("resultArriveDate") Date resultArriveDate,
			@Param("confirmYn") String confirmYn,
			@Param("answerEndYn") String answerEndYn,
			@Param("jinryoPreDate") Date jinryoPreDate,
			@Param("reserTime") String reserTime,
			@Param("reqEndYn") String reqEndYn,
			@Param("displayYn") String displayYn,
			@Param("consultSangName") String consultSangName,
			@Param("hospCode") String hospCode,
			@Param("pkocs0503") Double pkocs0503);
	
	@Modifying
	@Query("UPDATE Ocs0503  												"
			+ "	   SET updId             = :updId          		 ,          "
			+ "	       updDate           = SYSDATE()           	 ,          "
			+ "	       consultDoctor     = :consultDoctor      	            "
			+ " WHERE hospCode = :hospCode AND pkocs0503  = :pkocs0503		")
	public Integer updateOCS0503OCS2003P01ProcessCommonDoc(@Param("hospCode") String hospCode,
			@Param("pkocs0503") Double pkocs0503,
			@Param("updId") String userId,
			@Param("consultDoctor") String consultDoctor);
}
