package nta.med.data.dao.medi.out;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Outsang;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface OutsangRepository extends JpaRepository<Outsang, Long>, OutsangRepositoryCustom {
	
	@Modifying
	@Query("UPDATE Outsang SET juSangYn = :juSangYn, sangName = :sangName, sangStartDate = :sangStartDate, sangEndDate = :sangEndDate, sangEndSayu = :sangEndSayu, "
			+ " preModifier1 = :preModifier1, preModifier2 = :preModifier2, preModifier3 = :preModifier3, preModifier4 = :preModifier4, preModifier5 = :preModifier5, "
			+ " preModifier6 = :preModifier6, preModifier7 = :preModifier7, preModifier8 = :preModifier8, preModifier9 = :preModifier9, preModifier10 = :preModifier10, "
			+ " preModifierName = :preModifierName, postModifier1 = :postModifier1, postModifier2 = :postModifier2, postModifier3 = :postModifier3, "
			+ " postModifier4 = :postModifier4, postModifier5 = :postModifier5, postModifier6 = :postModifier6, postModifier7 = :postModifier7, "
			+ " postModifier8 = :postModifier8, postModifier9 = :postModifier9, postModifier10 = :postModifier10, postModifierName = :postModifierName, "
			+ " updId = :updId, updDate = :updDate, sangJindanDate = :sangJindanDate, gwa = :gwa, dataGubun = :dataGubun, pkSeq = :pkSeq, ser = :ser "
			+ " WHERE bunho = :bunho AND gwa = :gwa AND ioGubun = :ioGubun AND pkSeq = :pkSeq AND hospCode = :hospCode")
	public Integer updateOcsoOCS1003P01UpdateOutSang(@Param("juSangYn") String juSangYn,
			@Param("sangName") String sangName,
			@Param("sangStartDate") Date sangStartDate,
			@Param("sangEndDate") Date sangEndDate,
			@Param("sangEndSayu") String sangEndSayu,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("preModifierName") String preModifierName,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("postModifierName") String postModifierName,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("sangJindanDate") Date sangJindanDate,
			@Param("gwa") String gwa,
			@Param("dataGubun") String dataGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("ser") Double ser,
			@Param("bunho") String bunho,
			@Param("ioGubun") String ioGubun,
			@Param("hospCode") String hospCode
			);
	
	@Query("SELECT ifDataSendYn FROM Outsang WHERE hospCode = :hospCode AND bunho = :bunho AND gwa = :gwa "
			+ " AND ioGubun  = :ioGubun AND pkSeq = :pkSeq")
	public String getOcsoOCS1003P01CheckDataSendYn(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq);
	
	@Modifying
	@Query("DELETE FROM Outsang WHERE bunho = :bunho AND gwa = :gwa AND ioGubun  = :ioGubun AND pkSeq = :pkSeq AND hospCode = :hospCode")
	public Integer deleteOcsoOCS1003P01DeleteFromOutsang(@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	@Query("SELECT gwa FROM Outsang WHERE hospCode = :hospCode and pkoutsang = :pkoutsang")
	public String getOcsoOCS1003P01GetGwoFromOutsang(@Param("hospCode") String hospCode,
			@Param("pkoutsang") Double pkoutsang);
	
	@Query("SELECT MAX(pkSeq)+1 FROM Outsang WHERE bunho = :bunho AND gwa = :gwa AND ioGubun = :ioGubun AND hospCode = :hospCode ")
	public String getOcsoOCS1003P01GetPkSeq1(@Param("hospCode") String hospCode,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,			
			@Param("bunho") String bunho);
	
	@Query("SELECT MAX(pkSeq)+1 FROM Outsang WHERE bunho = :bunho AND hospCode = :hospCode ")
	public String getOcsoOCS1003P01GetPkSeq2(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho);
	
	
	@Query("SELECT CONCAT(preModifierName, sangName, postModifierName) FROM Outsang  "
			+ "WHERE bunho = :bunho AND gwa IN (:gwa, '%' ) AND ioGubun  = :ioGubun "
			+ "AND hospCode = :hospCode  AND sangEndDate IS NULL "
			+ " ORDER BY CONCAT(( CASE WHEN juSangYn = 'Y' THEN '0' ELSE '1' END ), ( CASE WHEN sangEndDate IS NULL THEN '0' ELSE '1' END ), "
			+ "( CASE WHEN IFNULL(postModifier1 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier2 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier3 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier4 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier5 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier6 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier7 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier8 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier9 , 'XXXX') = '8002' "
			+ "OR IFNULL(postModifier10, 'XXXX') = '8002' "
			+ "THEN '0' ELSE '1' END ), "
			+ "DATE_FORMAT(sangStartDate, '%Y%m%d'),LTRIM(LPAD(ser,10,'0')))")    
	public List<String> loadOutSangOcsaOCS0503U00(
			@Param("hospCode") String hospCode, @Param("bunho") String bunho,
			@Param("gwa") String gwa, @Param("ioGubun") String ioGubun);

	
	@Modifying
	@Query("	 UPDATE Outsang								        "
			+"	   SET updId             = :updId          ,         "
			+"	       updDate           = SYSDATE()       ,         "
			+"	       ser                = :ser           ,         "
			+"	       sangName          = :sangName       ,         "
			+"	       sangStartDate    = :sangStartDate   ,         "
			+"	       sangEndDate      = :sangEndDate     ,         "
			+"	       sangEndSayu      = :sangEndSayu     ,         "
			+"	       juSangYn         = :juSangYn        ,         "
			+"	       preModifier1      = :preModifier1   ,         "
			+"	       preModifier2      = :preModifier2   ,         "
			+"	       preModifier3      = :preModifier3   ,         "
			+"	       preModifier4      = :preModifier4   ,         "
			+"	       preModifier5      = :preModifier5   ,         "
			+"	       preModifier6      = :preModifier6   ,         "
			+"	       preModifier7      = :preModifier7   ,         "
			+"	       preModifier8      = :preModifier8   ,         "
			+"	       preModifier9      = :preModifier9   ,         "
			+"	       preModifier10     = :preModifier10  ,         "
			+"	       preModifierName  = :preModifierName ,         "
			+"	       postModifier1     = :postModifier1  ,         "
			+"	       postModifier2     = :postModifier2  ,         "
			+"	       postModifier3     = :postModifier3  ,         "
			+"	       postModifier4     = :postModifier4  ,         "
			+"	       postModifier5     = :postModifier5  ,         "
			+"	       postModifier6     = :postModifier6  ,         "
			+"	       postModifier7     = :postModifier7  ,         "
			+"	       postModifier8     = :postModifier8  ,         "
			+"	       postModifier9     = :postModifier9  ,         "
			+"	       postModifier10    = :postModifier10 ,         "
			+"	       postModifierName = :postModifierName,         "
			+"	       sangJindanDate   = :sangJindanDate  ,         "
			+"	       dataGubun         = :dataGubun                "
			+"	 WHERE bunho              = :bunho                   "
			+"	   AND gwa                = :gwa                     "
			+"	   AND ioGubun           = :ioGubun                  "
			+"	   AND pkSeq             = :pkSeq                    "
			+"	   AND hospCode          = :hospCode                 ")
	public Integer updateOUTSANGOU00Transaction(@Param("updId") String updId,
			@Param("ser") Double ser,
			@Param("sangName") String sangName,
			@Param("sangStartDate") Date sangStartDate,
			@Param("sangEndDate") Date sangEndDate,
			@Param("sangEndSayu") String sangEndSayu,
			@Param("juSangYn") String juSangYn,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("preModifierName") String preModifierName,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("postModifierName") String postModifierName,
			@Param("sangJindanDate") Date sangJindanDate,
			@Param("dataGubun") String dataGubun,
			@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	
	@Modifying
	@Query("	 UPDATE Outsang								        "
			+"	   SET updId             = :updId          ,         "
			+"	       updDate           = SYSDATE()       ,         "
			+"	       ser                = :ser           ,         "
			+"	       sangName          = :sangName       ,         "
			+"	       sangStartDate    = :sangStartDate   ,         "
			+"	       sangEndDate      = :sangEndDate     ,         "
			+"	       sangEndSayu      = :sangEndSayu     ,         "
			+"	       juSangYn         = :juSangYn        ,         "
			+"	       preModifier1      = :preModifier1   ,         "
			+"	       preModifier2      = :preModifier2   ,         "
			+"	       preModifier3      = :preModifier3   ,         "
			+"	       preModifier4      = :preModifier4   ,         "
			+"	       preModifier5      = :preModifier5   ,         "
			+"	       preModifier6      = :preModifier6   ,         "
			+"	       preModifier7      = :preModifier7   ,         "
			+"	       preModifier8      = :preModifier8   ,         "
			+"	       preModifier9      = :preModifier9   ,         "
			+"	       preModifier10     = :preModifier10  ,         "
			+"	       preModifierName  = :preModifierName ,         "
			+"	       postModifier1     = :postModifier1  ,         "
			+"	       postModifier2     = :postModifier2  ,         "
			+"	       postModifier3     = :postModifier3  ,         "
			+"	       postModifier4     = :postModifier4  ,         "
			+"	       postModifier5     = :postModifier5  ,         "
			+"	       postModifier6     = :postModifier6  ,         "
			+"	       postModifier7     = :postModifier7  ,         "
			+"	       postModifier8     = :postModifier8  ,         "
			+"	       postModifier9     = :postModifier9  ,         "
			+"	       postModifier10    = :postModifier10 ,         "
			+"	       postModifierName = :postModifierName,         "
			+"	       sangJindanDate   = :sangJindanDate  ,         "
			+"	       dataGubun         = :dataGubun      ,         "
			+"	       emrPermission     = :emrPermission            "
			+"	 WHERE bunho              = :bunho                   "
			+"	   AND gwa                = :gwa                     "
			+"	   AND ioGubun           = :ioGubun                  "
			+"	   AND pkSeq             = :pkSeq                    "
			+"	   AND hospCode          = :hospCode                 ")
	public Integer updateOUTSANGOU00TransactionExt(@Param("updId") String updId,
			@Param("ser") Double ser,
			@Param("sangName") String sangName,
			@Param("sangStartDate") Date sangStartDate,
			@Param("sangEndDate") Date sangEndDate,
			@Param("sangEndSayu") String sangEndSayu,
			@Param("juSangYn") String juSangYn,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("preModifierName") String preModifierName,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("postModifierName") String postModifierName,
			@Param("sangJindanDate") Date sangJindanDate,
			@Param("dataGubun") String dataGubun,
			@Param("emrPermission") BigDecimal emrPermission,
			@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	
	@Modifying                                     
	@Query("	DELETE FROM Outsang A              "
			+"	 WHERE bunho        = :bunho       " 
			+"	   AND gwa          = :gwa         " 
			+"	   AND ioGubun      = :ioGubun     " 
			+"	   AND pkSeq        = :pkSeq       " 
			+"	   AND hospCode     = :hospCode    " )
	public Integer deleteOUTSANGU00Transaction(@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);

	@Query("SELECT A FROM Outsang A WHERE bunho = :bunho AND hospCode = :hospCode")
	public List<Outsang> findByBunhoAndHospCode(@Param("bunho") String bunho, @Param("hospCode") String hospCode);
	
	
	@Query("	select A FROM Outsang A             "
			+"	 WHERE bunho        = :bunho       " 
			+"	   AND gwa          = :gwa         " 
			+"	   AND ioGubun      = :ioGubun     " 
			+"	   AND pkSeq        = :pkSeq       " 
			+"	   AND hospCode     = :hospCode    " )
	public List<Outsang> getOUTSANGU00Transaction(@Param("bunho") String bunho,
			@Param("gwa") String gwa,
			@Param("ioGubun") String ioGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query("	 UPDATE Outsang SET ifDataSendYn = :ifDataSendYn, ifDataSendDate = :ifDataSendDate WHERE hospCode = :hospCode AND bunho = :bunho AND sangCode IN :sangCodeList ")
	public Integer updateDataSendYn(@Param("ifDataSendYn") String ifDataSendYn,
									@Param("ifDataSendDate") Date ifDataSendDate,
									@Param("hospCode") String hospCode,
									@Param("bunho") String bunho,
									@Param("sangCodeList") List<String> sangCodeList);
	
	@Query("SELECT A.sangName FROM Outsang A WHERE bunho = :bunho AND hospCode = :hospCode AND juSangYn = 'Y' AND (sangEndDate > SYSDATE() OR sangEndDate IS NULL)")
	public List<String> findByBunhoHospCodeAndJuSangYn(@Param("bunho") String bunho, @Param("hospCode") String hospCode);
	
	@Modifying
	@Query("	UPDATE Outsang								         "
			+"	SET juSangYn          = :juSangYn         ,          "
			+"	    sangName          = :sangName         ,          "
			+"	    sangStartDate     = :sangStartDate    ,          "
			+"	    sangEndDate       = :sangEndDate      ,          "
			+"	    sangEndSayu       = :sangEndSayu      ,          "
			+"	    preModifier1      = :preModifier1     ,          "
			+"	    preModifier2      = :preModifier2     ,          "
			+"	    preModifier3      = :preModifier3     ,          "
			+"	    preModifier4      = :preModifier4     ,          "
			+"	    preModifier5      = :preModifier5     ,          "
			+"	    preModifier6      = :preModifier6     ,          "
			+"	    preModifier7      = :preModifier7     ,          "
			+"	    preModifier8      = :preModifier8     ,          "
			+"	    preModifier9      = :preModifier9     ,          "
			+"	    preModifier10     = :preModifier10    ,          "
			+"	    preModifierName   = :preModifierName  ,          "
			+"	    postModifier1     = :postModifier1    ,          "
			+"	    postModifier2     = :postModifier2    ,          "
			+"	    postModifier3     = :postModifier3    ,          "
			+"	    postModifier4     = :postModifier4    ,          "
			+"	    postModifier5     = :postModifier5    ,          "
			+"	    postModifier6     = :postModifier6    ,          "
			+"	    postModifier7     = :postModifier7    ,          "
			+"	    postModifier8     = :postModifier8    ,          "
			+"	    postModifier9     = :postModifier9    ,          "
			+"	    postModifier10    = :postModifier10   ,          "
			+"	    postModifierName  = :postModifierName ,     	 "
			+"	    updId             = :updId            ,          "
			+"	    updDate           = SYSDATE()         ,     	 "
			+"	    sangJindanDate    = :sangJindanDate   ,          "
			+"	    gwa               = :gwa              ,  		 "
			+"	    dataGubun         = :dataGubun        ,    		 "
			+"	    pkSeq             = :pkSeq            ,  		 "
			+"	    ser               = :ser  						 "
			+"	WHERE hospCode  = :hospCode  						 "
			+"	  AND bunho     = :bunho                    		 "
			+"	  AND gwa       = :changeBeforeGwa                   "
			+"	  AND ioGubun   = :ioGubun                   		 "
			+"	  AND pkSeq     = :changeBeforePkseq  				 ")
	public Integer updateOcs2003P01Outsang(
			@Param("juSangYn") String juSangYn,
			@Param("sangName") String sangName,
			@Param("sangStartDate") Date sangStartDate,
			@Param("sangEndDate") Date sangEndDate,
			@Param("sangEndSayu") String sangEndSayu,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("preModifierName") String preModifierName,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("postModifierName") String postModifierName,
			@Param("updId") String updId,
			@Param("sangJindanDate") Date sangJindanDate,
			@Param("gwa") String gwa,
			@Param("dataGubun") String dataGubun,
			@Param("pkSeq") Double pkSeq,
			@Param("ser") Double ser,
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("changeBeforeGwa") String changeBeforeGwa,
			@Param("ioGubun") String ioGubun,
			@Param("changeBeforePkseq") Double changeBeforePkseq);
	
	@Modifying
	@Query("	UPDATE Outsang								         "
			+"	SET juSangYn          = :juSangYn         ,          "
			+"	    sangName          = :sangName         ,          "
			+"	    sangStartDate     = :sangStartDate    ,          "
			+"	    sangEndDate       = :sangEndDate      ,          "
			+"	    sangEndSayu       = :sangEndSayu      ,          "
			+"	    preModifier1      = :preModifier1     ,          "
			+"	    preModifier2      = :preModifier2     ,          "
			+"	    preModifier3      = :preModifier3     ,          "
			+"	    preModifier4      = :preModifier4     ,          "
			+"	    preModifier5      = :preModifier5     ,          "
			+"	    preModifier6      = :preModifier6     ,          "
			+"	    preModifier7      = :preModifier7     ,          "
			+"	    preModifier8      = :preModifier8     ,          "
			+"	    preModifier9      = :preModifier9     ,          "
			+"	    preModifier10     = :preModifier10    ,          "
			+"	    preModifierName   = :preModifierName  ,          "
			+"	    postModifier1     = :postModifier1    ,          "
			+"	    postModifier2     = :postModifier2    ,          "
			+"	    postModifier3     = :postModifier3    ,          "
			+"	    postModifier4     = :postModifier4    ,          "
			+"	    postModifier5     = :postModifier5    ,          "
			+"	    postModifier6     = :postModifier6    ,          "
			+"	    postModifier7     = :postModifier7    ,          "
			+"	    postModifier8     = :postModifier8    ,          "
			+"	    postModifier9     = :postModifier9    ,          "
			+"	    postModifier10    = :postModifier10   ,          "
			+"	    postModifierName  = :postModifierName ,     	 "
			+"	    updId             = :updId            ,          "
			+"	    updDate           = SYSDATE()         ,     	 "
			+"	    sangJindanDate    = :sangJindanDate   ,          "
			+"	    gwa               = :gwa              ,  		 "
			+"	    dataGubun         = :dataGubun            		 "
			+"	WHERE hospCode  = :hospCode  						 "
			+"	  AND bunho     = :bunho                    		 "
			+"	  AND gwa       = :changeBeforeGwa                   "
			+"	  AND ioGubun   = :ioGubun                   		 "
			+"	  AND pkSeq     = :changeBeforePkseq  				 ")
	public Integer updateOcs2003P01OutsangIgnoreSeq(
			@Param("juSangYn") String juSangYn,
			@Param("sangName") String sangName,
			@Param("sangStartDate") Date sangStartDate,
			@Param("sangEndDate") Date sangEndDate,
			@Param("sangEndSayu") String sangEndSayu,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("preModifierName") String preModifierName,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("postModifierName") String postModifierName,
			@Param("updId") String updId,
			@Param("sangJindanDate") Date sangJindanDate,
			@Param("gwa") String gwa,
			@Param("dataGubun") String dataGubun,
			@Param("hospCode") String hospCode,
			@Param("bunho") String bunho,
			@Param("changeBeforeGwa") String changeBeforeGwa,
			@Param("ioGubun") String ioGubun,
			@Param("changeBeforePkseq") Double changeBeforePkseq);
}

