package nta.med.data.dao.medi.out.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.OutsangRepositoryCustom;
import nta.med.data.model.ihis.emr.OCS2015U00GetDiseaseReportInfo;
import nta.med.data.model.ihis.injs.INJ1001U01GrdSangItemInfo;
import nta.med.data.model.ihis.inps.INP3003U00grdINP2002Info;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOutSangInfo;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2001Info;
import nta.med.data.model.ihis.nuro.ORCATransferOrdersDiseaseInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdOutSangInfo;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridSangInfo;
import nta.med.data.model.ihis.ocsa.OCS2003P01GrdOutsangInfo;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdSangListItemInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02grdOCS1001Info;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1001Info;
import nta.med.data.model.ihis.ocso.OUTSANGQ00GrdOutSangInfo;
import nta.med.data.model.ihis.ocso.OUTSANGQ00IsEnableSangCodeInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00InitializeListItemInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridOutSangInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05DiseaseListItemInfo;
import nta.med.data.model.ihis.nuro.DiseaseInfo;
import nta.med.data.model.ihis.system.HospitalDetailInfo;
import nta.med.data.model.phr.SyncDiseaseInfo;

/**
 * @author dainguyen.
 */
public class OutsangRepositoryImpl implements OutsangRepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(OutsangRepositoryImpl.class);                
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsoOCS1003P01GridOutSangInfo> getOcsoOCS1003P01GridOutSangInfo(String hospCode, String language, String bunho, String gwa, String naewonDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUNHO                                                                                                             ");
		sql.append("     , A.GWA                                                                                                               ");
		sql.append("     , B.CODE_NAME                                                                                                               ");
		sql.append("     , C.SUGA_SANG_CODE                                                                                                               ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :hospCode, :language) GWA_NAME                                               ");
		sql.append("     , A.IO_GUBUN                                                                                                          ");
		sql.append("     , A.PK_SEQ                                                                                                            ");
		sql.append("     , A.NAEWON_DATE                                                                                                       ");
		sql.append("     , A.JUBSU_NO                                                                                                          ");
		sql.append("     , A.LAST_NAEWON_DATE                                                                                                  ");
		sql.append("     , A.LAST_DOCTOR                                                                                                       ");
		sql.append("     , A.LAST_NAEWON_TYPE                                                                                                  ");
		sql.append("     , A.LAST_JUBSU_NO                                                                                                     ");
		sql.append("     , A.FKOUT1001                                                                                                         ");
		sql.append("     , A.FKINP1001                                                                                                         ");
		sql.append("     , A.INPUT_ID                                                                                                          ");
		sql.append("     , A.SER                                                                                                               ");
		sql.append("     , A.SANG_CODE                                                                                                         ");
		sql.append("     , A.JU_SANG_YN                                                                                                        ");
		sql.append("     , A.SANG_NAME                                                                                                         ");
		sql.append("     , CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''), IFNULL(A.SANG_NAME,''), IFNULL(A.POST_MODIFIER_NAME,''))                     ");
		sql.append("     , A.SANG_START_DATE                                                                                                   ");
		sql.append("     , A.SANG_END_DATE                                                                                                     ");
		sql.append("     , A.SANG_END_SAYU                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER1                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER2                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER3                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER4                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER5                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER6                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER7                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER8                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER9                                                                                                     ");
		sql.append("     , A.PRE_MODIFIER10                                                                                                    ");
		sql.append("     , A.PRE_MODIFIER_NAME                                                                                                 ");
		sql.append("     , A.POST_MODIFIER1                                                                                                    ");
		sql.append("     , A.POST_MODIFIER2                                                                                                    ");
		sql.append("     , A.POST_MODIFIER3                                                                                                    ");
		sql.append("     , A.POST_MODIFIER4                                                                                                    ");
		sql.append("     , A.POST_MODIFIER5                                                                                                    ");
		sql.append("     , A.POST_MODIFIER6                                                                                                    ");
		sql.append("     , A.POST_MODIFIER7                                                                                                    ");
		sql.append("     , A.POST_MODIFIER8                                                                                                    ");
		sql.append("     , A.POST_MODIFIER9                                                                                                    ");
		sql.append("     , A.POST_MODIFIER10                                                                                                   ");
		sql.append("     , A.POST_MODIFIER_NAME                                                                                                ");
		sql.append("     , A.SANG_JINDAN_DATE                                                                                                  ");
		sql.append("     , A.PKOUTSANG                                                                                                         ");
		sql.append("     , A.DATA_GUBUN                                                                                                        ");
		sql.append("     , A.IF_DATA_SEND_YN                                                                                                   ");
		sql.append("     ,  CONCAT(( CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ),                                                ");
		sql.append("        ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                                       ");
		sql.append("                                                                                                                           ");
		sql.append("         DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'), LPAD(A.SER,10,'0')) ORDER_BY_KEY                                        ");
		sql.append("	 , IFNULL(A.EMR_PERMISSION, '')																						   ");
		sql.append("  FROM OUTSANG A LEFT JOIN CHT0110  C ON (A.SANG_CODE = C.SANG_CODE AND A.HOSP_CODE = C.HOSP_CODE   )                      ");
		sql.append("                 LEFT JOIN (SELECT * FROM BAS0102 WHERE HOSP_CODE = :hospCode AND LANGUAGE = :language                     ");
		sql.append("												AND CODE_TYPE = 'SANG_END_SAYU'  ) B ON ( A.SANG_END_SAYU = B.CODE )       ");
		sql.append(" WHERE A.HOSP_CODE        = :hospCode                                                                                      ");
		sql.append("   AND A.BUNHO            = :bunho                                                                                         ");
		sql.append("   AND A.IO_GUBUN         = 'O'                                                                                            ");
		sql.append("   AND DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d') <= :naewonDate                                                           ");
		sql.append("   AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) >= STR_TO_DATE(:naewonDate, '%Y/%m/%d')       		   ");
		sql.append("   AND A.DATA_GUBUN != 'D'                                                                                                 ");
		sql.append(" GROUP BY A.ID 																											   ");
		sql.append(" ORDER BY ORDER_BY_KEY                                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);
		//query.setParameter("gwa", gwa);
		query.setParameter("language", language);
		
		List<OcsoOCS1003P01GridOutSangInfo> list = new JpaResultMapper().list(query, OcsoOCS1003P01GridOutSangInfo.class);
		
		return list;
	}
	
	public String checkOcsoOCS1003P01SangDupCheck(String hospCode, String ioGubun, String gwa, String bunho, Double fkinp1001, String sangCode, String sangName, String postModifierName,
			String preModifierName,String sangStartDate,String sangEndDate,String sangJindanDate,String dataGubun,String juSangYn){
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_SANG_DUP_CHK(:hospCode , ");
		sql.append("     :ioGubun ,                         ");
		sql.append("     :gwa ,                              ");
		sql.append("     :bunho ,                            ");
		sql.append("     :fkinp1001 ,                        ");
		sql.append("     :sangCode ,                        ");
		sql.append("     :sangName ,                        ");
		sql.append("     :postModifierName ,               ");
		sql.append("     :preModifierName ,                ");
		sql.append("     :sangStartDate ,                  ");
		sql.append("     :sangEndDate ,                    ");
		sql.append("     :sangJindanDate ,                 ");
		sql.append("     :dataGubun ,                       ");
		sql.append("     :juSangYn)                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("gwa", gwa);
		query.setParameter("bunho", bunho);
		query.setParameter("fkinp1001", fkinp1001);
		query.setParameter("sangCode", sangCode);
		query.setParameter("sangName", sangName);
		query.setParameter("postModifierName", postModifierName);
		query.setParameter("preModifierName", preModifierName);
		query.setParameter("sangStartDate", sangStartDate);
		query.setParameter("sangEndDate", sangEndDate);
		query.setParameter("sangJindanDate", sangJindanDate);
		query.setParameter("dataGubun", dataGubun);
		query.setParameter("juSangYn", juSangYn);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		
		return null;
	}
	
	@Override
	public List<OcsoOCS1003Q05DiseaseListItemInfo> getOcsoOCS1003Q05DiseaseList(String hospCode, String language, String ioGubun, String jubsuNo, 
			String naewonDate, String gwa, String doctor, String naewonType, String bunho){
		LOGGER.info("[START] getOcsoOCS1003Q05DiseaseList");
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.JU_SANG_YN,                                                                                                               ");
		sql.append("       A.SANG_CODE,                                                                                                                ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(),  :hospCode, :language) GWA_NAME,                                               	   ");
		sql.append("       A.SER,                                                                                                                      ");
		sql.append("       CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''),IFNULL(A.SANG_NAME,''),IFNULL(A.POST_MODIFIER_NAME,'')) DIS_SANG_NAME,                ");
		sql.append("       A.SANG_START_DATE   ,                                                                                                       ");
		sql.append("       A.SANG_END_DATE     ,                                                                                                       ");
		sql.append("       A.SANG_END_SAYU     ,                                                                                                       ");
		sql.append("       FN_BAS_LOAD_CODE_NAME('SANG_END_SAYU', A.SANG_END_SAYU, :hospCode, :language)                                        	   ");
		sql.append("                                                SANG_END_SAYU_NAME,                                                                ");
		sql.append("       A.BUNHO             ,                                                                                                       ");
		sql.append("       A.NAEWON_DATE       ,                                                                                                       ");
		sql.append("       A.GWA               ,                                                                                                       ");
		sql.append("       A.DOCTOR            ,                                                                                                       ");
		sql.append("       A.NAEWON_TYPE       ,                                                                                                       ");
		sql.append("       A.JUBSU_NO          ,                                                                                                       ");
		sql.append("       ( CASE WHEN :ioGubun = 'I'                                                                                             	   ");
		sql.append("              THEN CONCAT(A.BUNHO,:jubsuNo,DATE_FORMAT(:naewonDate, '%Y/%m/%d'),RPAD(:gwa, 10,0),RPAD(:doctor, 10,0))      		   ");
		sql.append("              ELSE CONCAT(A.BUNHO,DATE_FORMAT(:naewonDate, '%Y/%m/%d'),:gwa,:doctor,:naewonType,:jubsuNo) END )         		   ");
		sql.append("                                                                    PK_ORDER,                                                      ");
		sql.append("       A.SANG_NAME         ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER1     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER2     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER3     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER4     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER5     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER6     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER7     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER8     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER9     ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER10    ,                                                                                                       ");
		sql.append("       A.PRE_MODIFIER_NAME ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER1    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER2    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER3    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER4    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER5    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER6    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER7    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER8    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER9    ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER10   ,                                                                                                       ");
		sql.append("       A.POST_MODIFIER_NAME,                                                                                                       ");
		sql.append("       A.SANG_JINDAN_DATE,                                                                                                         ");
		sql.append("       CONCAT(( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                                         ");
		sql.append("         DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'),LPAD(A.SER, 10,'0')) ORDER_BY_KEY                                                ");
		sql.append("  FROM OUTSANG A                                                                                                                   ");
		sql.append(" WHERE A.HOSP_CODE   = :hospCode                                                                                                   ");
		sql.append("   AND A.BUNHO       = :bunho                                                                                                      ");
		sql.append("   AND A.IO_GUBUN    = :ioGubun                                                                                                    ");
		sql.append("   AND DATE_FORMAT(A.SANG_START_DATE,'%Y/%m/%d') <= DATE_FORMAT(:naewonDate,'%Y/%m/%d')                                            ");
		sql.append("   AND IFNULL(DATE_FORMAT(A.SANG_END_DATE,'%Y/%m/%d'), DATE_FORMAT('99991231','%Y/%m/%d')) >= DATE_FORMAT(:naewonDate,'%Y/%m/%d')  ");
		sql.append("   AND A.DATA_GUBUN != 'D'                                                                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("jubsuNo", jubsuNo);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("gwa", gwa);
		query.setParameter("doctor", doctor);
		query.setParameter("naewonType", naewonType);
		query.setParameter("bunho", bunho);
		
		List<OcsoOCS1003Q05DiseaseListItemInfo> list = new JpaResultMapper().list(query, OcsoOCS1003Q05DiseaseListItemInfo.class);
		LOGGER.info("[END] getOcsoOCS1003Q05DiseaseList");
		return list;
	}

	@Override
	public List<OUTSANGU00InitializeListItemInfo> getOUTSANGU00InitializeListItemInfo(
			String hospCode, String bunho, String gwa, String ioGubun,
			String allSangYn, String gijunDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BUNHO             ,																							");
		sql.append("	       A.GWA               ,                                                                                            ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(),:hospCode,'JA') GWA_NAME,                                                  ");
		sql.append("	       A.IO_GUBUN          ,                                                                                            ");
		sql.append("	       A.PK_SEQ            ,                                                                                            ");
		sql.append("	       A.NAEWON_DATE       ,                                                                                            ");
		sql.append("	       A.DOCTOR            ,                                                                                            ");
		sql.append("	       A.NAEWON_TYPE       ,                                                                                            ");
		sql.append("	       A.JUBSU_NO          ,                                                                                            ");
		sql.append("	       A.FKINP1001         ,                                                                                            ");
		sql.append("	       A.INPUT_ID          ,                                                                                            ");
		sql.append("	       A.SANG_CODE         ,                                                                                            ");
		sql.append("	       A.SANG_NAME         ,                                                                                            ");
		sql.append("	       CONCAT(A.PRE_MODIFIER_NAME, A.SANG_NAME, A.POST_MODIFIER_NAME) DIS_SANG_NAME,                                    ");
		sql.append("	       A.JU_SANG_YN        ,                                                                                            ");
		sql.append("	       A.SANG_START_DATE   ,                                                                                            ");
		sql.append("	       A.SANG_END_DATE     ,                                                                                            ");
		sql.append("	       A.SANG_END_SAYU     ,                                                                                            ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME('SANG_END_SAYU', A.SANG_END_SAYU,:hospCode,'JA') SANG_END_SAYU_NAME,                       ");
		sql.append("	       A.SER               ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER1     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER2     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER3     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER4     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER5     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER6     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER7     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER8     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER9     ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER10    ,                                                                                            ");
		sql.append("	       A.PRE_MODIFIER_NAME ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER1    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER2    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER3    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER4    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER5    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER6    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER7    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER8    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER9    ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER10   ,                                                                                            ");
		sql.append("	       A.POST_MODIFIER_NAME,                                                                                            ");
		sql.append("	       A.SANG_JINDAN_DATE,                                                                                              ");
		sql.append("	       A.DATA_GUBUN,                                                                                                    ");
		sql.append("	       A.IF_DATA_SEND_YN,                                                                                               ");
		sql.append("	      CONCAT( ( CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ),                                              ");
		sql.append("	       ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                                     ");
		sql.append("	       DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'),LTRIM(LPAD(A.SER,10,'0'))) CONT_KEY                                     ");
		sql.append("		  ,A.EMR_PERMISSION																									");
		sql.append("		  ,''																											    ");
		sql.append("	  FROM OUTSANG A                                                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE  = :hospCode                                                                                         ");
		sql.append("	   AND A.BUNHO      = :bunho                                                                                            ");
		sql.append("	   AND A.GWA        LIKE :gwa                                                                                           ");
		sql.append("	   AND A.IO_GUBUN   = :ioGubun                                                                                          ");
		sql.append("	   AND (( :allSangYn = 'Y' )                                                                                            ");
		sql.append("	         OR                                                                                                             ");
		sql.append("	        ( :allSangYn = 'N'                                                                                              ");
		sql.append("	          AND DATE_FORMAT(A.SANG_START_DATE,'%Y/%m/%d')             <=  :gijunDate                                      ");
		sql.append("	          AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99991231','%Y%m%d')) >= STR_TO_DATE(:gijunDate, '%Y/%m/%d')))        ");
		sql.append("	   AND A.DATA_GUBUN !=  'D'                                                                                             ");
		sql.append("	 ORDER BY CONT_KEY                                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("gwa", gwa);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("allSangYn", allSangYn);
		query.setParameter("gwa", gwa);
		query.setParameter("gijunDate", gijunDate);

		
		List<OUTSANGU00InitializeListItemInfo> list = new JpaResultMapper().list(query, OUTSANGU00InitializeListItemInfo.class);
		return list;
	}

	@Override
	public Double getOUTSANGU00PkSeq(String hospCode, String bunho, String gwa,
			String ioGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT MAX(Z.PK_SEQ)+1 PK_SEQ 			");
		sql.append("	 FROM OUTSANG Z                         ");
		sql.append("	WHERE Z.BUNHO       = :bunho          ");
		sql.append("	  AND Z.GWA         = :gwa            ");
		sql.append("	  AND Z.IO_GUBUN    = :ioGubun       ");
		sql.append("	  AND Z.HOSP_CODE   = :hospCode         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("gwa", gwa);
		query.setParameter("ioGubun", ioGubun);
		
		List<Double> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			 return result.get(0);
		}
		
		return null;
		
	}

	@Override
	public Double getOUTSANGU00Ser(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT MAX(Z.PK_SEQ)+1 PK_SEQ 		");
		sql.append("	 FROM OUTSANG Z                     ");
		sql.append("	WHERE Z.BUNHO       =:bunho       ");
		sql.append("	  AND Z.HOSP_CODE   = :hospCode     ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<Double> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		
		return null;
	}

	@Override
	public String getOUTSANGU00ResultSang(String hospCode, String ioGubun,
			String gwa, String bunho, String fkinp1001, String sangCode,
			String sangName, String postModifierName, String preModifierName,
			String sangStartDate, String sangEndDate, String sangJindanDate,
			String dataGubun, String juSangYn) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT FN_OCS_SANG_DUP_CHK(:hospCode    ");
		sql.append("	 , :ioGubun                             ");
		sql.append("	 , :gwa                                 ");
		sql.append("	 , :bunho                               ");
		sql.append("	 , :fkinp1001                           ");
		sql.append("	 , :sangCode                            ");
		sql.append("	 , :sangName                            ");
		sql.append("	 , :postModifierName                    ");
		sql.append("	 , :preModifierName                     ");
		sql.append("	 , :sangStartDate                       ");
		sql.append("	 , :sangEndDate                         ");
		sql.append("	 , :sangJindanDate                      ");
		sql.append("	 , :dataGubun                           ");
		sql.append("	 , :juSangYn)                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("gwa", gwa);
		query.setParameter("bunho", bunho);
		query.setParameter("fkinp1001", fkinp1001);
		query.setParameter("sangCode", sangCode);
		query.setParameter("sangName", sangName);
		query.setParameter("postModifierName", postModifierName);
		query.setParameter("preModifierName", preModifierName);
		query.setParameter("sangStartDate", sangStartDate);
		query.setParameter("sangEndDate", sangEndDate);
		query.setParameter("sangJindanDate", sangJindanDate);
		query.setParameter("dataGubun", dataGubun);
		query.setParameter("juSangYn", juSangYn);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		
		return null;
	}

	@Override
	public String getIfDataSendYn(String hospCode, String bunho, String gwa,
			String ioGubun, Double pkSeq) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.IF_DATA_SEND_YN			");
		sql.append("	  FROM OUTSANG A                    ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode      ");
		sql.append("	   AND A.BUNHO     = :bunho         ");
		sql.append("	   AND A.GWA       = :gwa           ");
		sql.append("	   AND A.IO_GUBUN  = :ioGubun       ");
		sql.append("	   AND A.PK_SEQ    = :pkSeq         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("gwa", gwa);
		query.setParameter("ioGubun", ioGubun);
		query.setParameter("pkSeq", pkSeq);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		return null;
	}
			
	@Override
	public List<INJ1001U01GrdSangItemInfo> getINJ1001U01GrdSangItemInfo(String hospCode, String bunho, String gwa, String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                            ");
		sql.append("       PK_SEQ                                                                              ");
		sql.append("     , SANG_NAME                                                                           ");
		sql.append("     , JU_SANG_YN                                                                          ");
		sql.append("     , SANG_START_DATE                                                                     ");
		sql.append("  FROM OUTSANG                                                                             ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                                                            ");
		sql.append("   AND BUNHO = :f_bunho                                                                    ");
		sql.append("   AND GWA LIKE IFNULL(:f_gwa,'%')                                                         ");
		sql.append("   AND IO_GUBUN = 'O'                                                                      ");
		sql.append("   AND STR_TO_DATE(:f_reser_date, '%Y/%m/%d')                                              ");
		sql.append(" BETWEEN SANG_START_DATE AND IFNULL(SANG_END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))  ");
		sql.append(" ORDER BY IF(IFNULL(JU_SANG_YN,'N') = 'Y',1,2), SANG_START_DATE DESC                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_reser_date", reserDate);
		
		List<INJ1001U01GrdSangItemInfo> list = new JpaResultMapper().list(query, INJ1001U01GrdSangItemInfo.class);
		return list;
	}
	
	@Override
	public List<OCS1003Q02grdOCS1001Info> getOCS1003Q02grdOCS1001Info(String hospCode, String bunho, String gwa, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JU_SANG_YN        ,                                                                                           ");
		sql.append("        A.SANG_CODE         ,                                                                                           ");
		sql.append("        A.SER               ,                                                                                           ");
		sql.append("        CONCAT(IFNULl(A.PRE_MODIFIER_NAME,''),IFNULL(A.SANG_NAME,''),IFNULL(A.POST_MODIFIER_NAME,'')) DIS_SANG_NAME,    ");
		sql.append("        A.SANG_START_DATE   ,                                                                                           ");
		sql.append("        A.SANG_END_DATE     ,                                                                                           ");
		sql.append("        A.SANG_END_SAYU     ,                                                                                           ");
		sql.append("        A.BUNHO             ,                                                                                           ");
		sql.append("        A.NAEWON_DATE       ,                                                                                           ");
		sql.append("        A.GWA               ,                                                                                           ");
		sql.append("        A.DOCTOR            ,                                                                                           ");
		sql.append("        A.NAEWON_TYPE       ,                                                                                           ");
		sql.append("        A.JUBSU_NO          ,                                                                                           ");
		sql.append("        CONCAT(IFNULL(A.BUNHO,''),IFNULL(DATE_FORMAT(A.NAEWON_DATE,'%Y%m%d'),''),                                       ");
		sql.append("        IFNULL(A.GWA,''),IFNULL(A.DOCTOR,''),IFNULL(A.NAEWON_TYPE,''),                                                  ");
		sql.append("        IFNULL(LTRIM(cast(A.JUBSU_NO as char)),'')) PK_ORDER,                                                           ");
		sql.append("        A.SANG_NAME         ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER1     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER2     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER3     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER4     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER5     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER6     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER7     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER8     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER9     ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER10    ,                                                                                           ");
		sql.append("        A.PRE_MODIFIER_NAME ,                                                                                           ");
		sql.append("        A.POST_MODIFIER1    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER2    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER3    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER4    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER5    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER6    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER7    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER8    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER9    ,                                                                                           ");
		sql.append("        A.POST_MODIFIER10   ,                                                                                           ");
		sql.append("        A.POST_MODIFIER_NAME,                                                                                           ");
		sql.append("        case A.SANG_END_DATE when NULL then 'N' else 'Y' end         END_YN                                             ");
		sql.append("   FROM OUTSANG A                                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                                                 ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                                                     ");
		sql.append("    AND A.GWA            = :f_gwa                                                                                       ");
		sql.append("    AND :f_naewon_date   BETWEEN A.SANG_START_DATE  AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))      ");
		sql.append("  ORDER BY A.SANG_START_DATE, A.SER																						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_naewon_date", naewonDate);
		List<OCS1003Q02grdOCS1001Info> list = new JpaResultMapper().list(query, OCS1003Q02grdOCS1001Info.class);
		return list;
	}
	
	@Override
	public List<OCS1003Q09GridSangInfo> getOCS1003Q09GridSangListItem(
			String hospCode, String language, String ioGubun, String jubsuNo,
			Date naewonDate, String gwa, String doctor, String naewonType,
			String bunho) {
		LOGGER.info("[START] getOCS1003Q09GridSangListItem");
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JU_SANG_YN        ,																																	");
		sql.append("	       A.SANG_CODE         ,                                                                                                                                    ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :language) GWA_NAME,                                                                                ");
		sql.append("	       A.SER               ,                                                                                                                                    ");
		sql.append("	       CONCAT(A.PRE_MODIFIER_NAME,A.SANG_NAME,A.POST_MODIFIER_NAME)                                                                                             ");
		sql.append("	                                                DIS_SANG_NAME,                                                                                                  ");
		sql.append("	       A.SANG_START_DATE   ,                                                                                                                                    ");
		sql.append("	       A.SANG_END_DATE     ,                                                                                                                                    ");
		sql.append("	       A.SANG_END_SAYU     ,                                                                                                                                    ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME ('SANG_END_SAYU', A.SANG_END_SAYU, :f_hosp_code, :language)                                                                        ");
		sql.append("	                                                SANG_END_SAYU_NAME,                                                                                             ");
		sql.append("	       A.BUNHO             ,                                                                                                                                    ");
		sql.append("	       A.NAEWON_DATE       ,                                                                                                                                    ");
		sql.append("	       A.GWA               ,                                                                                                                                    ");
		sql.append("	       A.DOCTOR            ,                                                                                                                                    ");
		sql.append("	       A.NAEWON_TYPE       ,                                                                                                                                    ");
		sql.append("	       A.JUBSU_NO          ,                                                                                                                                    ");
		sql.append("	       ( CASE :f_io_gubun  WHEN  'I'                                                                                                                            ");
		sql.append("	              THEN CONCAT(A.BUNHO, :f_jubsu_no, DATE_FORMAT( :f_naewon_date,'%Y%m%d'),SUBSTR(:f_gwa,1,10),SUBSTR(:f_doctor,1,10))        ");
		sql.append("	              ELSE CONCAT(A.BUNHO,DATE_FORMAT(:f_naewon_date,'%Y%m%d'),:f_gwa,:f_doctor,:f_naewon_type,:f_jubsu_no) END )             ");
		sql.append("	                                                                    PK_ORDER,                                                                                   ");
		sql.append("	       A.SANG_NAME         ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER1     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER2     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER3     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER4     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER5     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER6     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER7     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER8     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER9     ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER10    ,                                                                                                                                    ");
		sql.append("	       A.PRE_MODIFIER_NAME ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER1    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER2    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER3    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER4    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER5    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER6    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER7    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER8    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER9    ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER10   ,                                                                                                                                    ");
		sql.append("	       A.POST_MODIFIER_NAME,                                                                                                                                    ");
		sql.append("	       A.SANG_JINDAN_DATE,                                                                                                                                      ");
		sql.append("	       CONCAT(( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                                                                      ");
		sql.append("	         DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'),LTRIM(LPAD(A.SER, 10,'0'))) ORDER_BY_KEY                                                                      ");
		sql.append("	  FROM OUTSANG A                                                                                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                             ");
		sql.append("	   AND A.BUNHO       = :f_bunho                                                                                                                                 ");
		sql.append("	   AND A.IO_GUBUN    = :f_io_gubun                                                                                                                              ");
		sql.append("	   AND A.SANG_START_DATE                                    <= :f_naewon_date                                                                                   ");
		sql.append("	   AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99991231','%Y%m%d')) >= :f_naewon_date                                                                              ");
		sql.append("	   AND A.DATA_GUBUN != 'D'                                                                                                                                      ");
		sql.append("	 ORDER BY ORDER_BY_KEY                                                                                                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_jubsu_no", jubsuNo);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_bunho", bunho);
		
		List<OCS1003Q09GridSangInfo> list = new JpaResultMapper().list(query, OCS1003Q09GridSangInfo.class);
		LOGGER.info("[END] getOCS1003Q09GridSangListItem");
		
		return list;
	}

	@Override
	public List<OCS1003R00LayOCS1001Info> getOCS1003R00LayOCS1001Info(
			String hospCode, String bunho, String gwa, String doctor,
			String jubsuNo, String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JU_SANG_YN        ,                                                                                                       ");
		sql.append("        A.SANG_CODE         ,                                                                                                       ");
		sql.append("        A.SER               ,                                                                                                       ");
		sql.append("        CONCAT(IFNULL(RTRIM(A.PRE_MODIFIER_NAME),''),IFNULL(RTRIM(A.SANG_NAME),''),IFNULL(RTRIM(A.POST_MODIFIER_NAME),''))          ");
		sql.append("                                                                     DIS_SANG_NAME,                                                 ");
		sql.append("        A.SANG_START_DATE   ,                                                                                                       ");
		sql.append("        A.SANG_END_DATE     ,                                                                                                       ");
		sql.append("        A.SANG_END_SAYU     ,                                                                                                       ");
		sql.append("        A.SANG_NAME         ,                                                                                                       ");
		sql.append("        A.PRE_MODIFIER_NAME ,                                                                                                       ");
		sql.append("        A.POST_MODIFIER_NAME,                                                                                                       ");
		sql.append("        IF(A.SANG_END_DATE IS NULL, 'N', 'Y') END_YN                                                                                ");
		sql.append("   FROM OUTSANG A                                                                                                                   ");
		sql.append("  WHERE A.BUNHO       = :f_bunho                                                                                                    ");
		sql.append("    AND A.GWA         = :f_gwa                                                                                                      ");
		sql.append("    AND A.DOCTOR      = :f_doctor                                                                                                   ");
		sql.append("    AND A.IO_GUBUN    = 'O'                                                                                                         ");
		sql.append("    AND A.JUBSU_NO    = :f_jubsu_no                                                                                                 ");
		sql.append("    AND A.HOSP_CODE   = :f_hosp_code                                                                                                ");
		sql.append("    AND DATE_FORMAT(IFNULL(A.SANG_END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')),'%Y%m') >=                                        ");
		sql.append("                                     DATE_FORMAT(STR_TO_DATE(:f_naewon_date,'%Y/%m/%d'),'%Y%m')                                     ");
		sql.append("    AND DATE_FORMAT(IFNULL(A.SANG_START_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d')),'%Y%m') >=                                      ");
		sql.append("        CASE WHEN IFNULL(A.POST_MODIFIER1 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER2 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER3 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER4 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER5 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER6 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER7 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER8 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER9 , 'XXXX') = '8002'                                                                        ");
		sql.append("               OR IFNULL(A.POST_MODIFIER10, 'XXXX') = '8002' THEN                                                                   ");
		sql.append("                   DATE_FORMAT(DATE_ADD(STR_TO_DATE(:f_naewon_date,'%Y/%m/%d'),INTERVAL 2 MONTH),'%Y%m')                            ");
		sql.append("        ELSE '000000' END                                                                                                           ");
		sql.append("  ORDER BY A.SER 																													");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_jubsu_no", jubsuNo);
		query.setParameter("f_naewon_date", naewonDate);
		List<OCS1003R00LayOCS1001Info> list = new JpaResultMapper().list(query, OCS1003R00LayOCS1001Info.class);
		return list;
	}

	@Override
	public List<String> getOCSACTGrdSangByungInfo(String hospCode,String bunho, Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_NAME   SANG_NAME                                                                                         ");
		sql.append("      FROM OUTSANG A                                                                                                    ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code AND A.BUNHO       = :f_bunho                                                      ");
		sql.append("       AND :f_order_date BETWEEN A.SANG_START_DATE AND IFNULL(A.SANG_END_DATE,STR_TO_DATE('2999/01/01','%Y/%m/%d'))     ");
		sql.append("     GROUP BY A.SANG_NAME ORDER BY 1																					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<OUTSANGQ00GrdOutSangInfo> getOUTSANGQ00GrdOutSangInfo(String hospCode, String language, String bunho, String gwa, String ioGubun,
			String allSangYn, Date gijunDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO             ,                                                                            ");
		sql.append("        A.GWA               ,                                                                            ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :f_language) GWA_NAME,                      ");
		sql.append("        A.IO_GUBUN          ,                                                                            ");
		sql.append("        A.PK_SEQ            ,                                                                            ");
		sql.append("        A.NAEWON_DATE       ,                                                                            ");
		sql.append("        A.DOCTOR            ,                                                                            ");
		sql.append("        A.NAEWON_TYPE       ,                                                                            ");
		sql.append("        A.JUBSU_NO          ,                                                                            ");
		sql.append("        A.FKINP1001         ,                                                                            ");
		sql.append("        A.INPUT_ID          ,                                                                            ");
		sql.append("        A.SANG_CODE         ,                                                                            ");
		sql.append("        A.SANG_NAME         ,                                                                            ");
		sql.append("        CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''), IFNULL(A.SANG_NAME,''), IFNULL(A.POST_MODIFIER_NAME,''))  ");
		sql.append("                                                 DIS_SANG_NAME,                                          ");
		sql.append("        A.JU_SANG_YN        ,                                                                            ");
		sql.append("        A.SANG_START_DATE   ,                                                                            ");
		sql.append("        A.SANG_END_DATE     ,                                                                            ");
		sql.append("        A.SANG_END_SAYU     ,                                                                            ");
		sql.append("        FN_BAS_LOAD_CODE_NAME('SANG_END_SAYU', A.SANG_END_SAYU, :f_hosp_code, :f_language)               ");
		sql.append("                                            SANG_END_SAYU_NAME,                                          ");
		sql.append("        A.SER               ,                                                                            ");
		sql.append("        A.PRE_MODIFIER1     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER2     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER3     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER4     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER5     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER6     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER7     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER8     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER9     ,                                                                            ");
		sql.append("        A.PRE_MODIFIER10    ,                                                                            ");
		sql.append("        A.PRE_MODIFIER_NAME ,                                                                            ");
		sql.append("        A.POST_MODIFIER1    ,                                                                            ");
		sql.append("        A.POST_MODIFIER2    ,                                                                            ");
		sql.append("        A.POST_MODIFIER3    ,                                                                            ");
		sql.append("        A.POST_MODIFIER4    ,                                                                            ");
		sql.append("        A.POST_MODIFIER5    ,                                                                            ");
		sql.append("        A.POST_MODIFIER6    ,                                                                            ");
		sql.append("        A.POST_MODIFIER7    ,                                                                            ");
		sql.append("        A.POST_MODIFIER8    ,                                                                            ");
		sql.append("        A.POST_MODIFIER9    ,                                                                            ");
		sql.append("        A.POST_MODIFIER10   ,                                                                            ");
		sql.append("        A.POST_MODIFIER_NAME,                                                                            ");
		sql.append("        'N' SELECTED,                                                                                    ");
		sql.append("        A.PKOUTSANG,                                                                                     ");
		sql.append("        A.SANG_JINDAN_DATE,                                                                              ");
		sql.append("        CONCAT(( CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ),                              ");
		sql.append("        ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                     ");
		sql.append("          DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'), LPAD(A.SER, 10,'00')) CONT_KEY                       ");
		sql.append("   FROM OUTSANG A                                                                                        ");
		sql.append("  WHERE 1 = 1                                                                                            ");
		sql.append("    AND A.BUNHO      =  :f_bunho                                                                         ");
		sql.append("    AND A.GWA        LIKE :f_gwa                                                                         ");
		sql.append("    AND A.IO_GUBUN   =  :f_io_gubun                                                                      ");
		sql.append("    AND (( :f_all_sang_yn = 'Y' )                                                                        ");
		sql.append("          OR                                                                                             ");
		sql.append("         ( :f_all_sang_yn = 'N'                                                                          ");
		sql.append("           AND A.SANG_START_DATE                                    <= :f_gijun_date                     ");
		sql.append("           AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99991231','%Y%m%d')) >= :f_gijun_date ))             ");
		sql.append("    AND A.HOSP_CODE  = :f_hosp_code                                                                      ");
		sql.append("    AND A.DATA_GUBUN != 'D'                                                                              ");
		sql.append("  ORDER BY CONT_KEY                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_all_sang_yn", allSangYn);
		query.setParameter("f_gijun_date", gijunDate);
		List<OUTSANGQ00GrdOutSangInfo> list = new JpaResultMapper().list(query, OUTSANGQ00GrdOutSangInfo.class);
		return list;
		
	}
	
	@Override
	public List<OUTSANGQ00IsEnableSangCodeInfo> getOUTSANGQ00IsEnableSangCodeInfo(String hospCode, Double pkoutsang, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d') SANG_START_DATE  ");
		sql.append("     , DATE_FORMAT(B.START_DATE, '%Y/%m/%d') START_DATE            ");
		sql.append("  FROM OUTSANG A                                                   ");
		sql.append("      ,CHT0110 B                                                   ");
		sql.append("WHERE A.HOSP_CODE = :f_hosp_code                                   ");
		sql.append("  AND A.PKOUTSANG = :f_pkoutsang                                   ");
		sql.append("  AND A.BUNHO     = :f_bunho                                       ");
		sql.append("  AND B.HOSP_CODE = A.HOSP_CODE                                    ");
		sql.append("  AND B.SANG_CODE = A.SANG_CODE                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkoutsang", pkoutsang);
		query.setParameter("f_bunho", bunho);
		
		List<OUTSANGQ00IsEnableSangCodeInfo> list = new JpaResultMapper().list(query, OUTSANGQ00IsEnableSangCodeInfo.class);
		return list;
	}

	@Override
	public List<Ocs3003Q10GrdSangListItemInfo> getOcs3003Q10GrdSangListItem(
			String hospCode, String language, String ioGubun, String jubsuNo,
			Date naewonDate, String gwa, String doctor, String naewonType,
			String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JU_SANG_YN        ,																																		");
		sql.append("	       A.SANG_CODE         ,                                                                                                                                        ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :language)  GWA_NAME,                                                                                   ");
		sql.append("	       A.SER               ,                                                                                                                                        ");
		sql.append("	       CONCAT(A.PRE_MODIFIER_NAME, A.SANG_NAME, A.POST_MODIFIER_NAME)     DIS_SANG_NAME,                                                                            ");
		sql.append("	       A.SANG_START_DATE   ,                                                                                                                                        ");
		sql.append("	       A.SANG_END_DATE     ,                                                                                                                                        ");
		sql.append("	       FN_BAS_LOAD_CODE_NAME ('SANG_END_SAYU', A.SANG_END_SAYU, :f_hosp_code, :language)       SANG_END_SAYU_NAME,                                                  ");
		sql.append("	       A.SANG_END_SAYU     ,                                                                                                                                        ");
		sql.append("	       A.BUNHO             ,                                                                                                                                        ");
		sql.append("	       A.NAEWON_DATE       ,                                                                                                                                        ");
		sql.append("	       A.GWA               ,                                                                                                                                        ");
		sql.append("	       A.DOCTOR            ,                                                                                                                                        ");
		sql.append("	       A.NAEWON_TYPE       ,                                                                                                                                        ");
		sql.append("	       A.JUBSU_NO          ,                                                                                                                                        ");
		sql.append("	       ( CASE WHEN :f_io_gubun = 'I'                                                                                                                                ");
		sql.append("	              THEN CONCAT(A.BUNHO,:f_jubsu_no,DATE_FORMAT(STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'),'%Y%m%d'),RPAD(:f_gwa, 10, ' '),RPAD(:f_doctor, 10, ' '))         ");
		sql.append("	              ELSE CONCAT(A.BUNHO,DATE_FORMAT(STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'),'%Y%m%d'),:f_gwa,:f_doctor,:f_naewon_type,:f_jubsu_no) END )                  ");
		sql.append("	                                                                    PK_ORDER,                                                                                       ");
		sql.append("	       A.SANG_NAME         ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER1     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER2     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER3     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER4     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER5     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER6     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER7     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER8     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER9     ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER10    ,                                                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER_NAME ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER1    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER2    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER3    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER4    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER5    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER6    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER7    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER8    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER9    ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER10   ,                                                                                                                                        ");
		sql.append("	       A.POST_MODIFIER_NAME,                                                                                                                                        ");
		sql.append("	       A.SANG_JINDAN_DATE,                                                                                                                                          ");
		sql.append("	       IF(A.SANG_END_DATE IS NULL, 'N', 'Y')               END_YN,                                                                                                  ");
		sql.append("	       CONCAT(( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                                                                          ");
		sql.append("	       DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'),LPAD(A.SER, 10,'0')) ORDER_BY_KEY                                                                                    ");
		sql.append("	  FROM OUTSANG A                                                                                                                                                    ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                 ");
		sql.append("	   AND A.BUNHO       = :f_bunho                                                                                                                                     ");
		sql.append("	   AND A.IO_GUBUN    = :f_io_gubun                                                                                                                                  ");
		sql.append("	   AND A.SANG_START_DATE                                    <= :f_naewon_date                                                                                       ");
		sql.append("	   AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99991231','%Y%m%d')) >= :f_naewon_date                                                                                  ");
		sql.append("	   AND A.DATA_GUBUN != 'D'                                                                                                                                          ");
		sql.append("	 ORDER BY ORDER_BY_KEY                                                                                                                                              ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_jubsu_no", ioGubun);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_naewon_type", naewonType);
		query.setParameter("f_bunho", bunho);
		
		List<Ocs3003Q10GrdSangListItemInfo> list = new JpaResultMapper().list(query, Ocs3003Q10GrdSangListItemInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdOutSangInfo> getORDERTRANSGrdOutSangInfo(
			String hospCode, String language, String bunho, String gubun,
			Date gijunDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT A.BUNHO                                                                                          ");
		sql.append("         , A.GWA                                                                                            ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.SANG_START_DATE, :f_hosp_code, :f_language )                     ");
		sql.append("         , A.IO_GUBUN                                                                                       ");
		sql.append("         , A.PK_SEQ                                                                                         ");
		sql.append("         , A.SER                                                                                            ");
		sql.append("         , A.SANG_CODE                                                                                      ");
		sql.append("         ,CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''), IFNULL(A.SANG_NAME,''), IFNULL(A.POST_MODIFIER_NAME,''))   ");
		sql.append("         , A.SANG_NAME                                                                                      ");
		sql.append("         , A.PRE_MODIFIER1                                                                                  ");
		sql.append("         , A.PRE_MODIFIER2                                                                                  ");
		sql.append("         , A.PRE_MODIFIER3                                                                                  ");
		sql.append("         , A.PRE_MODIFIER4                                                                                  ");
		sql.append("         , A.PRE_MODIFIER5                                                                                  ");
		sql.append("         , A.PRE_MODIFIER6                                                                                  ");
		sql.append("         , A.PRE_MODIFIER7                                                                                  ");
		sql.append("         , A.PRE_MODIFIER8                                                                                  ");
		sql.append("         , A.PRE_MODIFIER9                                                                                  ");
		sql.append("         , A.PRE_MODIFIER10                                                                                 ");
		sql.append("         , A.PRE_MODIFIER_NAME                                                                              ");
		sql.append("         , A.POST_MODIFIER1                                                                                 ");
		sql.append("         , A.POST_MODIFIER2                                                                                 ");
		sql.append("         , A.POST_MODIFIER3                                                                                 ");
		sql.append("         , A.POST_MODIFIER4                                                                                 ");
		sql.append("         , A.POST_MODIFIER5                                                                                 ");
		sql.append("         , A.POST_MODIFIER6                                                                                 ");
		sql.append("         , A.POST_MODIFIER7                                                                                 ");
		sql.append("         , A.POST_MODIFIER8                                                                                 ");
		sql.append("         , A.POST_MODIFIER9                                                                                 ");
		sql.append("         , A.POST_MODIFIER10                                                                                ");
		sql.append("         , A.POST_MODIFIER_NAME                                                                             ");
		sql.append("         , A.SANG_START_DATE                                                                                ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.SANG_START_DATE, :f_hosp_code, :f_language)                  ");
		sql.append("         , A.SANG_END_DATE                                                                                  ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.SANG_END_DATE, :f_hosp_code, :f_language)                    ");
		sql.append("         , A.SANG_END_SAYU                                                                                  ");
		sql.append("         , FN_BAS_LOAD_CODE_NAME ('SANG_END_SAYU', A.SANG_END_SAYU, :f_hosp_code, :f_language)              ");
		sql.append("         , A.JU_SANG_YN                                                                                     ");
		sql.append("         ,CONCAT(( CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ),                               ");
		sql.append("           ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                     ");
		sql.append("             DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'), LPAD(A.SER,10,'0')) CONT_KEY                         ");
		sql.append("      FROM OUTSANG A                                                                                        ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                                                       ");
		sql.append("       AND A.BUNHO = :f_bunho                                                                               ");
		sql.append("       AND A.DATA_GUBUN != 'D'                                                                              ");
		sql.append("       AND A.IO_GUBUN = :f_io_gubun                                                                         ");
		sql.append("       AND IFNULL(:f_gijun_date, SYSDATE()) BETWEEN A.SANG_START_DATE                                       ");
		sql.append("                                                  AND STR_TO_DATE('9999/12/31', '%Y/%m/%d')                 ");
		sql.append("     ORDER BY CONT_KEY 																						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_io_gubun", gubun);
		query.setParameter("f_gijun_date", gijunDate);
		
		List<ORDERTRANSGrdOutSangInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdOutSangInfo.class);
		return list;
	}

	@Override
	public List<ORCATransferOrdersDiseaseInfo> getORCATransferOrdersDiseaseInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();		
		sql.append("	SELECT   A.SANG_CODE                                                DIAGNOSIS_CODE			");
		sql.append("	        ,'ORCA'                                                     DIAGNOSIS_SYSTEM		");
		sql.append("	        ,A.SANG_START_DATE                                          DIAGNOSIS_START_DATE	");
		sql.append("	        ,A.SANG_END_DATE                                            DIAGNOSIS_END_DATE		");
		sql.append("	        ,'MML0012'                                                  MML_TABLE_ID			");
		sql.append("	        ,'Diagnosis'                                                DIAGNOSIS_CATEGORY		");
		sql.append("	        , case when ifnull(A.POST_MODIFIER1, '') = '' then 'Y' else 'N' end  JU_SANG_YN				");
		sql.append("	FROM OUTSANG A																				");
		sql.append("	WHERE A.BUNHO = :f_bunho																	");
		sql.append("	  AND A.HOSP_CODE = :f_hosp_code															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<ORCATransferOrdersDiseaseInfo> list = new JpaResultMapper().list(query, ORCATransferOrdersDiseaseInfo.class);
		return list;
	}
	
	@Override
	public String callPrIfsOutsangTrans(String hospCode, String ioGubun, Integer masterFk, String sendYn){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_OUTSANG_TRANS");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MASTER_FK", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEND_YN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_CNT", Integer.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_MASTER_FK", masterFk);
		query.setParameter("I_SEND_YN", sendYn);
		
		query.execute();
		String flag = (String)query.getOutputParameterValue("O_FLAG");
		return flag;
	}

	@Override
	public List<OCS2015U00GetDiseaseReportInfo> getOCS2015U00GetDiseaseReportInfo(String hospCode, String gwa, String bunho, Date naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  SANG_CODE   ,                																			");
		sql.append("         SANG_NAME                    																			");
		sql.append(" FROM   OUTSANG                       																			");
		sql.append(" WHERE   GWA  = :gwa  				  																			");
		sql.append("   AND BUNHO       = :bunho      																				");
		sql.append("   AND HOSP_CODE    = :hosp_code      																			");
		sql.append("   AND :naewon_date  BETWEEN SANG_START_DATE  AND IFNULL(SANG_END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gwa", gwa);
		query.setParameter("bunho", bunho);
		query.setParameter("hosp_code", hospCode);
		query.setParameter("naewon_date", naewonDate);
		
		List<OCS2015U00GetDiseaseReportInfo> list = new JpaResultMapper().list(query, OCS2015U00GetDiseaseReportInfo.class);
		return list;
	}
	
	@Override
	public List<HospitalDetailInfo> getHospitalList(String hospName, String address, String tel, String countryCode, String hospNameConverted, String addressConverted) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 	A.HOSP_CODE,  																						");
		sql.append("        	A.YOYANG_NAME ,																						");
		sql.append("        	A.ADDRESS ,																							");
		sql.append("        	A.TEL ,																								");
		sql.append("        	A.COUNTRY_CODE 																						");
		sql.append(" FROM   	BAS0001 A 																							");
		sql.append(" 		JOIN   BAS0001 B ON A.HOSP_CODE = B.HOSP_CODE 															");
		sql.append("   			AND A.LANGUAGE = B.LANGUAGE																			");
		sql.append("   			AND B.START_DATE = A.START_DATE																		");
		sql.append("   			AND A.START_DATE = (SELECT MAX(C.START_DATE) FROM BAS0001 C WHERE A.HOSP_CODE = C.HOSP_CODE)		");
		sql.append("  WHERE 	1 = 1																								");
		sql.append("  		AND (A.YOYANG_NAME LIKE :f_hosp_name																	");
		sql.append("  				OR A.YOYANG_NAME LIKE :f_hosp_name_converted)													");
		sql.append("  		AND (IFNULL(A.ADDRESS, '') LIKE :f_address																");
		sql.append("  				OR A.ADDRESS LIKE :f_address_converted)															");
		sql.append("  		AND IFNULL(A.TEL, '') LIKE :f_tel																		");
		sql.append("  		AND IFNULL(A.COUNTRY_CODE, '') LIKE :f_country_code														");
		sql.append(" ORDER BY A.YOYANG_NAME   																						");	
	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_name", "%" + hospName + "%");
		query.setParameter("f_address", "%" + address + "%");
		query.setParameter("f_tel", "%" + tel + "%");
		query.setParameter("f_country_code", "%" + countryCode + "%");
		query.setParameter("f_hosp_name_converted", "%" + hospNameConverted + "%");
		query.setParameter("f_address_converted", "%" + addressConverted + "%");
		List<HospitalDetailInfo> list = new JpaResultMapper().list(query, HospitalDetailInfo.class);
		return list;
	}
	
	@Override
	public List<SyncDiseaseInfo> getSyncDiseaseInfo(String hospCode, String patientCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("      SELECT                                                                                                                      		");
		sql.append("          D.SANG_JINDAN_DATE		AS	  datetime_record,                                                                            	");
		sql.append("          D.SANG_START_DATE			AS    disease_start_date,                                                                 			");
		sql.append("          D.SANG_END_DATE				AS    disease_end_date,		                                                                  	");
		sql.append("          C.CODE_NAME						AS    disease_outcome,	                                                                  	");
		sql.append("          D.ID									AS		sync_id,	                                                                 	");
		sql.append("          D.SANG_NAME						AS		disease,                                                                          	");
		sql.append("          D.YOYANG_NAME					AS		hosp_name,			                                                          			");
		sql.append("          D.SYS_DATE						AS		created,		                                                                  	");
		sql.append("          D.UPD_DATE						AS		updated							                                                  	");
		sql.append("      FROM (SELECT                                                                                                                		");
		sql.append("                A.SANG_END_SAYU,                                                                                                  		");
		sql.append("                A.HOSP_CODE,                                                                                                    		");
		sql.append("                A.BUNHO,                                                                                                            	");
		sql.append("                A.SANG_JINDAN_DATE,                                                                                                 	");
		sql.append("                A.SANG_START_DATE,                                                                                                  	");
		sql.append("                A.SANG_END_DATE,												                                                  		");
		sql.append("                A.ID,							                                                                                      	");
		sql.append("                A.SANG_NAME,                                                                                                    		");
		sql.append("                B.YOYANG_NAME,							                                                                         		");
		sql.append("                A.SYS_DATE,							                                                                            		");
		sql.append("                A.UPD_DATE							                                                                            		");
		sql.append("                FROM OUTSANG A, BAS0001 B                                                                                           	");
		sql.append("                WHERE 1 = 1                                                                                                     		");
		sql.append("                AND A.BUNHO 					  =		:patientCode                                                                  	");
		sql.append("                AND A.HOSP_CODE					=		:hospCode                                                                 		");
		sql.append("                AND A.HOSP_CODE					=		B.HOSP_CODE                                                                  	");
		sql.append("                AND B.START_DATE				=		(select MAX(START_DATE) from BAS0001 where HOSP_CODE = :hospCode )            	");
		sql.append("                AND B.LANGUAGE					=		:language                                                             			");
		sql.append("                ORDER BY A.SANG_JINDAN_DATE ASC) D                                                                                  	");
		sql.append("      LEFT JOIN BAS0102 C ON D.HOSP_CODE = C.HOSP_CODE                                                                              	");
		sql.append("      AND C.CODE_TYPE 				=		'SANG_END_SAYU'                                                                     		");
		sql.append("      AND C.CODE 					    =		D.SANG_END_SAYU                                                                     	");
		sql.append("      AND C.LANGUAGE					=		:language                                                                         		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);
		
		List<SyncDiseaseInfo> list = new JpaResultMapper().list(query, SyncDiseaseInfo.class);
		return list;
	}

	@Override
	public List<DiseaseInfo> getDiseaseInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SANG_CODE                                                          DiseaseCode,			");
		sql.append("        IFNULL(DATE_FORMAT(A.SANG_START_DATE, '%Y-%m-%d'), '')               DiseaseStartDate,		");
		sql.append("        IFNULL(DATE_FORMAT(A.SANG_END_DATE, '%Y-%m-%d'), '')                 DiseaseEndDate,		");
		sql.append("        CASE WHEN IFNULL(A.POST_MODIFIER1, '') = '' THEN 'PD' ELSE 'S' END   DiseaseSuspectedFlag,	");
		sql.append("        IFNULL(A.SANG_NAME, '')                                              DiseaseName,			");
		sql.append("        IFNULL(B.IF_CODE, '')                                                DiseaseOutCome			");
		sql.append(" FROM OUTSANG A																						");
		sql.append(" LEFT JOIN IFS0003 B ON A.HOSP_CODE = B.HOSP_CODE													");
		sql.append("                    AND B.MAP_GUBUN = 'IF_ORCA_REASON_DISEASE'										");
		sql.append("                    AND A.SANG_END_SAYU = B.OCS_CODE												");
		sql.append(" WHERE A.BUNHO = :f_bunho																			");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code																	");
		sql.append("   AND IFNULL(A.IF_DATA_SEND_YN, 'N') <> 'Y'														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<DiseaseInfo> list = new JpaResultMapper().list(query, DiseaseInfo.class);
		return list;
	}

	@Override
	public List<INP3003U00grdINP2002Info> getINP3003U00grdINP2002Info(String hospCode, String language, String bunho, String gwa, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JU_SANG_YN                                                                                        ");
		sql.append("      , A.SANG_CODE                                                                                         ");
		sql.append("      , CONCAT(IFNULL(A.PRE_MODIFIER_NAME,'') , IFNULL(A.SANG_NAME,'') , IFNULL(A.POST_MODIFIER_NAME,''))   ");
		sql.append("      , A.SANG_START_DATE                                                                                   ");
		sql.append("      , A.SANG_END_DATE                                                                                     ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME ('SANG_END_SAYU', A.SANG_END_SAYU, :hosp_code , :language)                    ");
		sql.append("   FROM OUTSANG A                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE = :hosp_code                                                                            ");
		sql.append("    AND A.BUNHO     = :bunho                                                                                ");
		sql.append("    AND A.GWA       = :gwa                                                                                  ");
		sql.append("    AND A.IO_GUBUN  = 'I'                                                                                   ");
		sql.append("  ORDER BY CASE A.JU_SANG_YN WHEN 'Y' THEN 1 ELSE 2 END,  A.SANG_START_DATE									");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("gwa", gwa);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP3003U00grdINP2002Info> list = new JpaResultMapper().list(query, INP3003U00grdINP2002Info.class);
		return list;
	}

	@Override
	public List<INPORDERTRANSGrdOutSangInfo> getINPORDERTRANSGrdOutSangInfo(String hospCode, String language,
			String bunho, String ioGubun, Date gijunDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT A.BUNHO                                                                                              ");
		sql.append("         , A.GWA                                                                                                ");
		sql.append("         , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.SANG_START_DATE , :hosp_code, :language)                             ");
		sql.append("         , A.IO_GUBUN                                                                                           ");
		sql.append("         , A.PK_SEQ                                                                                             ");
		sql.append("         , A.SER                                                                                                ");
		sql.append("         , A.SANG_CODE                                                                                          ");
		sql.append("         , CONCAT(IFNULL(A.PRE_MODIFIER_NAME,'') , IFNULL(A.SANG_NAME,'') , IFNULL(A.POST_MODIFIER_NAME,''))    ");
		sql.append("         , A.SANG_NAME                                                                                          ");
		sql.append("         , A.PRE_MODIFIER1                                                                                      ");
		sql.append("         , A.PRE_MODIFIER2                                                                                      ");
		sql.append("         , A.PRE_MODIFIER3                                                                                      ");
		sql.append("         , A.PRE_MODIFIER4                                                                                      ");
		sql.append("         , A.PRE_MODIFIER5                                                                                      ");
		sql.append("         , A.PRE_MODIFIER6                                                                                      ");
		sql.append("         , A.PRE_MODIFIER7                                                                                      ");
		sql.append("         , A.PRE_MODIFIER8                                                                                      ");
		sql.append("         , A.PRE_MODIFIER9                                                                                      ");
		sql.append("         , A.PRE_MODIFIER10                                                                                     ");
		sql.append("         , A.PRE_MODIFIER_NAME                                                                                  ");
		sql.append("         , A.POST_MODIFIER1                                                                                     ");
		sql.append("         , A.POST_MODIFIER2                                                                                     ");
		sql.append("         , A.POST_MODIFIER3                                                                                     ");
		sql.append("         , A.POST_MODIFIER4                                                                                     ");
		sql.append("         , A.POST_MODIFIER5                                                                                     ");
		sql.append("         , A.POST_MODIFIER6                                                                                     ");
		sql.append("         , A.POST_MODIFIER7                                                                                     ");
		sql.append("         , A.POST_MODIFIER8                                                                                     ");
		sql.append("         , A.POST_MODIFIER9                                                                                     ");
		sql.append("         , A.POST_MODIFIER10                                                                                    ");
		sql.append("         , A.POST_MODIFIER_NAME                                                                                 ");
		sql.append("         , A.SANG_START_DATE                                                                                    ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.SANG_START_DATE, :hosp_code, :language)                          ");
		sql.append("         , A.SANG_END_DATE                                                                                      ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.SANG_END_DATE, :hosp_code, :language)                            ");
		sql.append("         , A.SANG_END_SAYU                                                                                      ");
		sql.append("         , FN_BAS_LOAD_CODE_NAME ('SANG_END_SAYU', A.SANG_END_SAYU, :hosp_code, :language)                      ");
		sql.append("         , A.JU_SANG_YN                                                                                         ");
		sql.append("         , CONCAT(( CASE WHEN A.JU_SANG_YN = 'Y' THEN '0' ELSE '1' END ),                                       ");
		sql.append("           ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ),                                         ");
		sql.append("             DATE_FORMAT(A.SANG_START_DATE, '%Y%m%d'), LPAD(A.SER,10, '0')) CONT_KEY                            ");
		sql.append("      FROM OUTSANG A                                                                                            ");
		sql.append("     WHERE A.HOSP_CODE = :hosp_code                                                                             ");
		sql.append("       AND A.BUNHO = :bunho                                                                                     ");
		sql.append("       AND A.DATA_GUBUN != 'D'                                                                                  ");
		sql.append("       AND A.IO_GUBUN = :io_gubun                                                                               ");
		sql.append("       AND IFNULL(:gijun_date, SYSDATE()) BETWEEN A.SANG_START_DATE                                             ");
		sql.append("                                                  AND STR_TO_DATE('9999/12/31', '%Y/%m/%d')                     ");
		sql.append("     ORDER BY CONT_KEY 																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);
		query.setParameter("io_gubun", ioGubun);
		query.setParameter("gijun_date", gijunDate);
		List<INPORDERTRANSGrdOutSangInfo> list = new JpaResultMapper().list(query, INPORDERTRANSGrdOutSangInfo.class);
		return list;
	}

	@Override
	public List<OCS2003R00layOCS2001Info> getOCS2003R00layOCS2001Info(String hospCode, String bunho, Double fkinp1001, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JU_SANG_YN        ,                                                                               ");
		sql.append("        A.SANG_CODE         ,                                                                               ");
		sql.append("        A.SER               ,                                                                               ");
		sql.append("        CONCAT(RTRIM(A.PRE_MODIFIER_NAME),RTRIM(A.SANG_NAME),RTRIM(A.POST_MODIFIER_NAME))    DIS_SANG_NAME, ");   
		sql.append("        A.SANG_START_DATE   ,                                                                               ");
		sql.append("        A.SANG_END_DATE     ,                                                                               ");
		sql.append("        A.SANG_END_SAYU     ,                                                                               ");
		sql.append("        A.SANG_NAME         ,                                                                               ");
		sql.append("        A.PRE_MODIFIER_NAME ,                                                                               ");
		sql.append("        A.POST_MODIFIER_NAME,                                                                               ");
		sql.append("        CASE A.SANG_END_DATE WHEN NULL THEN 'N' ELSE 'Y' END END_YN                                         ");
		sql.append("   FROM OUTSANG A                                                                                           ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                        ");
		sql.append("    AND A.BUNHO       = :f_bunho                                                                            ");
		sql.append("    AND A.FKINP1001   = :f_fkinp1001                                                                        ");
		sql.append("    AND A.GWA         = :f_gwa                                                                              ");
		sql.append("  ORDER BY A.SER            																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_gwa", gwa);
		List<OCS2003R00layOCS2001Info> list = new JpaResultMapper().list(query, OCS2003R00layOCS2001Info.class);
		return list;
	}

	@Override
	public List<OCS2003P01GrdOutsangInfo> getOCS2003P01GrdOutsangInfo(String hospCode, String language, String bunho, String gwa, String naewonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("    SELECT 								                                                                           				");
		sql.append("    	A.BUNHO,	 								                                                                           	");
		sql.append("    	A.GWA,		 								                                                                           	");
		sql.append("    	FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), :f_hosp_code, :f_language) 		GWA_NAME, 								    	");
		sql.append("    	A.IO_GUBUN, 								                                                                           	");
		sql.append("    	CAST(A.PK_SEQ AS CHAR), 								                                                                ");
		sql.append("    	DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), 								                                                ");
		sql.append("    	CAST(A.JUBSU_NO AS CHAR), 								                                                                ");
		sql.append("    	DATE_FORMAT(A.LAST_NAEWON_DATE, '%Y/%m/%d'), 								                                            ");
		sql.append("    	A.LAST_DOCTOR, 								                                                                           	");
		sql.append("    	A.LAST_NAEWON_TYPE, 								                                                                    ");
		sql.append("    	CAST(A.LAST_JUBSU_NO AS CHAR), 								                                                            ");
		sql.append("    	IFNULL(A.FKOUT1001, ''), 								                                                                ");
		sql.append("    	IFNULL(A.FKINP1001, ''), 								                                                                ");
		sql.append("    	A.INPUT_ID, 								                                                                           	");
		sql.append("    	CAST(A.SER AS CHAR), 								                                                                    ");
		sql.append("    	A.SANG_CODE, 								                                                                           	");
		sql.append("    	A.JU_SANG_YN, 								                                                                           	");
		sql.append("    	A.SANG_NAME, 								                                                                           	");
		sql.append("    	CONCAT(A.PRE_MODIFIER_NAME, A.SANG_NAME, A.POST_MODIFIER_NAME), 								                        ");
		sql.append("    	DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), 								                                            ");
		sql.append("    	IFNULL(A.SANG_END_DATE, ''), 								                                                            ");
		sql.append("    	A.SANG_END_SAYU, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER1, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER2, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER3, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER4, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER5, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER6, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER7, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER8, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER9, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER10, 								                                                                        ");
		sql.append("    	A.PRE_MODIFIER_NAME, 								                                                                    ");
		sql.append("    	A.POST_MODIFIER1, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER2, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER3, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER4, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER5, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER6, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER7, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER8, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER9, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER10, 								                                                                        ");
		sql.append("    	A.POST_MODIFIER_NAME, 								                                                                    ");
		sql.append("    	DATE_FORMAT(A.SANG_JINDAN_DATE, '%Y/%m/%d'), 								                                            ");
		sql.append("    	IFNULL(A.PKOUTSANG, ''), 								                                                                ");
		sql.append("    	A.DATA_GUBUN, 								                                                                           	");
		sql.append("    	IFNULL(DATE_FORMAT(A.IF_DATA_SEND_YN, '%Y/%m/%d'), ''),		                                                            ");
		sql.append("    	CONCAT( 								                                                                           		");
		sql.append("    		(CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ), 								                        ");
		sql.append("    		(CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END ), 								                        ");
		sql.append("    		( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END ), 								                        ");
		sql.append("    		DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), 								                                        ");
		sql.append("    		LTRIM(LPAD(A.SER, 10, '0')) 								                                                        ");
		sql.append("    	) 																			ORDER_BY_KEY 								");
		sql.append("    FROM 								                                                                           				");
		sql.append("    	OUTSANG A 								                                                                           		");
		sql.append("    WHERE 								                                                                           				");
		sql.append("    	A.HOSP_CODE        															= :f_hosp_code 								");
		sql.append("    	AND A.BUNHO            														= :f_bunho 								    ");
		sql.append("    	AND A.GWA              														LIKE :f_gwa 								");
		sql.append("    	AND A.IO_GUBUN         														= 'I' 								        ");
		sql.append("    	AND A.SANG_START_DATE 														<= STR_TO_DATE(:f_naewon_date, '%Y/%m/%d') 	");
		sql.append("    	AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99981231', '%Y%m%d')) 				>= STR_TO_DATE(:f_naewon_date, '%Y/%m/%d') 	");
		sql.append("    	AND A.DATA_GUBUN 															!= 'D' 								        ");
		sql.append("    ORDER BY 								                                                                           			");
		sql.append("    	ORDER_BY_KEY 								                                                                           	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", "%" + gwa + "%");
		query.setParameter("f_naewon_date", naewonDate);
		List<OCS2003P01GrdOutsangInfo> list = new JpaResultMapper().list(query, OCS2003P01GrdOutsangInfo.class);
		return list;
	}
	
}
