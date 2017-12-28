package nta.med.data.dao.medi.inv.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv0110RepositoryCustom;
import nta.med.data.dao.medi.out.impl.Out1001RepositoryImpl;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkFullInfo;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkInfo;
import nta.med.data.model.ihis.invs.CheckRemainingInventoryInfo;
import nta.med.data.model.ihis.invs.INV6000U00ExportCSVInfo;
import nta.med.data.model.ihis.invs.INV6000U00LaySummaryMasterInfo;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002AfterInfo;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002BeforeInfo;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002Info;
import nta.med.data.model.ihis.invs.LoadINV0110Q00Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonJaeryoCodeInfo;

/**
 * @author dainguyen.
 */
public class Inv0110RepositoryImpl implements Inv0110RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Out1001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getInjsINJ1001U01ChkbState(String hospCode, Date reserDate, String actingFlag, String bunho, String doctor) {

		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT IFNULL(C.CHKB,'N')                                                                                  ");
		sql.append("FROM INJ1002 A                                                                                                      ");
		sql.append("INNER JOIN INJ1001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.PKINJ1001 = A.FKINJ1001                                     ");
		sql.append("INNER JOIN INV0110 C  ON  C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE = A.HANGMOG_CODE AND IFNULL(C.CHKB,'N') = 'Y' ");
		sql.append("WHERE A.HOSP_CODE             = :hospCode                                                                           ");
		if (reserDate != null) {
			sql.append("        AND A.RESER_DATE            = :reser_date                                                               ");
		}
		if (!StringUtils.isEmpty(actingFlag)) {
			sql.append("        AND IFNULL(A.ACTING_FLAG, 'N') = :acting_flag                                                           ");
		}
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("        AND B.BUNHO                 = :bunho                                                                    ");
		}
		if (!StringUtils.isEmpty(doctor)) {
			sql.append("        AND B.DOCTOR                = :doctor                                                                   ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if (reserDate != null) {
			query.setParameter("reser_date", reserDate);
		}
		if (!StringUtils.isEmpty(actingFlag)) {
			query.setParameter("acting_flag", actingFlag);
		}
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		if (!StringUtils.isEmpty(doctor)) {
			query.setParameter("doctor", doctor);
		}
		List<Object> listResult = query.getResultList();
		if (listResult != null && !listResult.isEmpty()) {
			return listResult.get(0).toString();
		}

		return "";
	}
	
	@Override
	public List<DRGOCSCHKGrdOcsChkInfo> getDRGOCSCHKGrdOcsChkInfo(String hospCode, String jaeryoCode, String jaeryoName, String preSmallCode, 
			String smallCode, String drgPackYn, String phamarcyYn, String powderYn, String hubalYn, String mayakYn, String beforeUseYn, Integer pageNumber, String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT STRAIGHT_JOIN A.JAERYO_CODE                                                                                              ");
		sql.append("      ,A.JAERYO_NAME                                                                                              ");
		sql.append("      ,A.CHK3          DRG_PACK_YN                                                                                ");
		sql.append("      ,A.CHK2          PHAMARCY_YN                                                                                ");
		sql.append("      ,A.CHK1          POWDER_YN                                                                                  ");
		sql.append("      ,A.TOIJANG_YN    HUBAL_CHANGE_YN                                                                            ");
		sql.append("      ,A.BUNRYU2       MAYAK_YN                                                                                   ");
		sql.append("      ,A.SMALL_CODE                                                                                               ");
		sql.append("      ,B.CODE_NAME1    SMALL_CODE_NAME                                                                            ");
		sql.append("      ,A.CAUTION_CODE                                                                                             ");
		sql.append("      ,D.CAUTION_NAME                                                                                             ");
		sql.append("  FROM INV0110 A LEFT OUTER JOIN DRG0141 B ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE1 = A.SMALL_CODE AND B.LANGUAGE  = :f_language            ");
		sql.append("                 LEFT OUTER JOIN DRG0130 D ON D.HOSP_CODE = A.HOSP_CODE AND D.CAUTION_CODE = A.CAUTION_CODE AND D.LANGUAGE  = :f_language       ");
		sql.append("                 JOIN OCS0103 C ON C.HOSP_CODE                = A.HOSP_CODE                                       ");
		sql.append("   AND C.HANGMOG_CODE             = A.JAERYO_CODE                                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                                 ");
		sql.append("   AND A.JAERYO_CODE          LIKE :f_jaeryo_code                                                                 ");
		sql.append("   AND A.JAERYO_NAME          LIKE :f_jaeryo_name                                                                 ");
		sql.append("   AND IFNULL(A.SMALL_CODE,'%')  LIKE :f_pre_small_code                                                           ");
		sql.append("   AND IFNULL(A.SMALL_CODE,'%')  LIKE :f_small_code                                                               ");
		sql.append("   AND IFNULL(A.CHK3,'%')        LIKE :f_drg_pack_yn                                                              ");
		sql.append("   AND IFNULL(A.CHK2,'%')        LIKE :f_phamarcy_yn                                                              ");
		sql.append("   AND IFNULL(A.CHK1,'%')        LIKE :f_powder_yn                                                                ");
		sql.append("   AND IFNULL(A.TOIJANG_YN,'%')  LIKE :f_hubal_yn                                                                 ");
		sql.append("   AND IFNULL(A.BUNRYU2,'0')     LIKE CONCAT(IF(:f_mayak_yn = '1','1','%'),'%')                                   ");
		sql.append("   AND SYSDATE()             BETWEEN C.START_DATE AND C.END_DATE                                                  ");
		sql.append("   AND IFNULL(C.BEFORE_USE_YN,'N')   LIKE :f_before_use_yn                                                        ");
		sql.append(" ORDER BY A.JAERYO_CODE                                                                                           ");
		if(pageNumber == null || pageNumber == 0 || pageNumber == 1){
			sql.append(" LIMIT 0,200                                                                                                    ");
		}else{
			sql.append(" LIMIT :f_page_number,200                                                                                                    ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaeryo_code", jaeryoCode + "%");
		query.setParameter("f_jaeryo_name", "%" + jaeryoName + "%");
		query.setParameter("f_pre_small_code", preSmallCode + "%");
		query.setParameter("f_small_code", smallCode + "%");
		query.setParameter("f_drg_pack_yn", drgPackYn + "%");
		query.setParameter("f_phamarcy_yn", phamarcyYn + "%");
		query.setParameter("f_powder_yn", powderYn + "%");
		query.setParameter("f_hubal_yn", hubalYn + "%");
		query.setParameter("f_mayak_yn", mayakYn);
		query.setParameter("f_before_use_yn", beforeUseYn + "%");
		query.setParameter("f_language", language);
		if(pageNumber != null && pageNumber != 0 && pageNumber != 1){
			query.setParameter("f_page_number", pageNumber*200 - 200);	
		}
		
		List<DRGOCSCHKGrdOcsChkInfo> list = new JpaResultMapper().list(query, DRGOCSCHKGrdOcsChkInfo.class);
		return list;
	}

	@Override
	public String getLoadColumnCodeNameJaeryoCodeCase(String code,
			String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JAERYO_NAME 				");
		sql.append("	FROM INV0110 A                      ");
		sql.append("	WHERE A.JAERYO_CODE = :code         ");
		sql.append("	 AND A.HOSP_CODE   = :hospCode      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("code", code);
		query.setParameter("hospCode", hospCode);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && listResult.get(0) != null){
			return listResult.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0103U00LayCommonJaeryoCodeInfo> getOCS0103U00LayCommonJaeryoCodeInfo(String hospCode, String jaeryoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JAERYO_NAME, A.BULYONG_DATE   ");
		sql.append("  FROM INV0110 A                        ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code     ");
		sql.append("   AND A.JAERYO_CODE = :f_jaeryo_code   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaeryo_code", jaeryoCode);
		List<OCS0103U00LayCommonJaeryoCodeInfo> list = new JpaResultMapper().list(query, OCS0103U00LayCommonJaeryoCodeInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String find) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JAERYO_CODE, A.JAERYO_NAME        ");
		sql.append("   FROM INV0110 A                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code          ");
		sql.append("    AND A.JAERYO_NAME_INX LIKE :f_find1     ");
		sql.append("  ORDER BY A.JAERYO_CODE 					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", "%" + find + "%");
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<INV6000U00LaySummaryMasterInfo> getINV6000U00LaySummaryMasterInfo(String hospCode, String language, String magamMonth) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.SLIP_CODE                                                                                                                         ");
		sql.append(" , E.SLIP_NAME                                                                                                                              ");
		sql.append(" , COUNT(*) drg_count                                                                                                                       ");
		sql.append(" , FORMAT(SUM(ROUND(IFNULL(A.SUBUL_DANGA,0)*IFNULL(D.JAEGO_QTY,0))),'0') SOUGAKU                                                            ");
		sql.append(" , FN_BAS_TO_JAPAN_DATE_CONVERT('1',D.MAGAM_DATE, :hosp_code, :language) MAGAM_DATE                                                         ");
		sql.append(" , SUBSTRING(FN_BAS_TO_JAPAN_DATE_CONVERT('1',STR_TO_DATE(CONCAT(D.MAGAM_MONTH,'01'),'%Y%m%d'), :hosp_code, :language),1,9) MAGAM_MONTH_JP  ");
		sql.append(" FROM INV0110 A LEFT OUTER JOIN OCS0132 C ON C.HOSP_CODE = A.HOSP_CODE AND C.LANGUAGE = :language                                           ");
		sql.append("               AND C.CODE = A.SUBUL_DANUI AND C.CODE_TYPE  = 'ORD_DANUI',                                                                   ");
		sql.append(" OCS0103 B, (SELECT X.HOSP_CODE                                                                                                             ");
		sql.append("             , Y.JAERYO_CODE                                                                                                                ");
		sql.append("             , Y.JAEGO_QTY                                                                                                                  ");
		sql.append("             , X.INPUT_DATE AS MAGAM_DATE                                                                                                   ");
		sql.append("             , X.MAGAM_MONTH AS MAGAM_MONTH                                                                                                 ");
		sql.append("                FROM INV6000 X, INV6001 Y                                                                                                   ");
		sql.append("                WHERE X.HOSP_CODE = :hosp_code                                                                                              ");
		sql.append("                AND X.MAGAM_MONTH = :magam_month                                                                                            ");
		sql.append("                AND Y.HOSP_CODE = X.HOSP_CODE                                                                                               ");
		sql.append("                AND Y.FKINV6000 = X.PKINV6000) D, OCS0102 E                                                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code AND IFNULL(A.STOCK_YN,'N') = 'Y' AND B.HOSP_CODE = A.HOSP_CODE                                              ");
		sql.append("   AND B.HANGMOG_CODE = A.JAERYO_CODE AND B.SLIP_CODE IN('J01','P01','P02')                                                                 ");
		sql.append("   AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                                                        ");
		sql.append("   AND D.HOSP_CODE = A.HOSP_CODE AND D.JAERYO_CODE = A.JAERYO_CODE                                                                          ");
		sql.append("   AND E.HOSP_CODE = B.HOSP_CODE AND E.SLIP_CODE     = B.SLIP_CODE                                                                          ");
		sql.append("   AND E.LANGUAGE = :language                                                                          										");
		sql.append(" GROUP BY B.SLIP_CODE,E.SLIP_NAME,D.MAGAM_DATE,D.MAGAM_MONTH                                                                                ");
		sql.append(" ORDER BY SUBSTRING(B.SLIP_CODE,1,1) DESC,SUBSTRING(B.SLIP_CODE,2,2)																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("magam_month", magamMonth);
		List<INV6000U00LaySummaryMasterInfo> list = new JpaResultMapper().list(query, INV6000U00LaySummaryMasterInfo.class);
		return list;
	}
	
	@Override
	public List<INV6002U00GrdINV6002BeforeInfo> getINV6002U00GrdINV6002BeforeInfo(String hospCode, String month, String jaeryoGubun, String language, Integer startNum, Integer endNum){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE																							");
		sql.append("	     , A.JAERYO_NAME																							");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME ('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)  AS SUBUL_DANUI_NAME		");
		sql.append("	     , C.ORDER_GUBUN                                        AS JARYO_GUBUN										");
		sql.append("	FROM OCS0103 C																									");
		sql.append("	   , INV0110 A																									");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code																				");
		sql.append("	 AND A.JAERYO_CODE NOT IN ( SELECT B.JAERYO_CODE																");
		sql.append("	                              FROM INV6002 B																	");
		sql.append("	                             WHERE B.HOSP_CODE   = :f_hosp_code													");
		sql.append("	                               AND B.MAGAM_MONTH = :f_month														");
		sql.append("	                               AND B.EXIST_COUNT IS NOT NULL													");
		sql.append("	                           ) 																					");
		sql.append("	 AND A.STOCK_YN      = 'Y'																						");
		sql.append("	 AND C.HOSP_CODE     = A.HOSP_CODE																				");
		sql.append("	 AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun																		");
		sql.append("	 AND C.HANGMOG_CODE  = A.JAERYO_CODE																			");
		sql.append("	 AND SYSDATE() BETWEEN C.START_DATE AND C.END_DATE																");
		sql.append("	ORDER BY C.ORDER_GUBUN, A.JAERYO_NAME																			");
		sql.append("      LIMIT :startNum, :endNum 			        		 															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_month", month);
		query.setParameter("f_jaeryo_gubun", jaeryoGubun);
		query.setParameter("f_language", language);
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		
		List<INV6002U00GrdINV6002BeforeInfo> listData = new JpaResultMapper().list(query, INV6002U00GrdINV6002BeforeInfo.class);
		return listData;
	}
	
	@Override
	public List<INV6002U00GrdINV6002AfterInfo> getINV6002U00GrdINV6002AfterInfo(String hospCode, String month, String jaeryoGubun, String language, Integer startNum, Integer endNum){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE																							");
		sql.append("	     , B.JAERYO_NAME																							");
		sql.append("	     , A.EXIST_COUNT																							");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME ('ORD_DANUI', B.SUBUL_DANUI, :f_hosp_code, :f_language)  AS SUBUL_DANUI_NAME		");
		sql.append("	     , DATE_FORMAT(A.INPUT_DATE, '%Y/%m/%d')																	");
		sql.append("	     , A.INPUT_USER																								");
		sql.append("	     , C.ORDER_GUBUN                                        AS JARYO_GUBUN										");
		sql.append("	  FROM OCS0103 C																								");
		sql.append("	     , INV0110 B																								");
		sql.append("	     , INV6002 A																								");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code																			");
		//sql.append("	   AND A.MAGAM_MONTH   = :f_month																				");
		sql.append("	   AND B.HOSP_CODE     = A.HOSP_CODE																			");
		sql.append("	   AND B.JAERYO_CODE   = A.JAERYO_CODE																			");
		sql.append("	   AND C.HOSP_CODE     = A.HOSP_CODE																			");
		sql.append("	   AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun																		");
		sql.append("	   AND C.HANGMOG_CODE  = A.JAERYO_CODE																			");
		sql.append("	   AND SYSDATE() BETWEEN C.START_DATE AND C.END_DATE															");
		sql.append("	 ORDER BY C.ORDER_GUBUN, B.JAERYO_NAME																			");
		sql.append("      LIMIT :startNum, :endNum 			        		 															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		//query.setParameter("f_month", month);
		query.setParameter("f_jaeryo_gubun", jaeryoGubun);
		query.setParameter("f_language", language);
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		
		List<INV6002U00GrdINV6002AfterInfo> listData = new JpaResultMapper().list(query, INV6002U00GrdINV6002AfterInfo.class);
		return listData;
	}
	
	@Override
	public List<LoadINV0110Q00Info> getINV0110Q00Info(String hospCode, String searchWord, String language, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.JAERYO_CODE																					");
		sql.append("	     , IFNULL(A.JAERYO_NAME, '')																		");
		sql.append("	     , IFNULL(A.SUBUL_DANUI, '')																		");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME ('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language) SUBUL_DANUI_NAME 	");
		sql.append("	     , IFNULL(A.SUBUL_DANGA, '')																		");
		sql.append("	  FROM INV0110 A																						");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code																		");
		sql.append("	   AND A.JAERYO_NAME_INX LIKE :f_search_word															");
		sql.append("	   AND A.STOCK_YN  = 'Y'																				");
		sql.append("	 ORDER BY A.JAERYO_CODE																					");
		sql.append(" 	LIMIT :startNum, :offset                                                                        		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_search_word", "%" + searchWord + "%");
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		
		List<LoadINV0110Q00Info> listData = new JpaResultMapper().list(query, LoadINV0110Q00Info.class);
		return listData;
	}

	@Override
	public List<CheckRemainingInventoryInfo> checkRemainingInventory(String hospCode, List<String> hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT	F.HANGMOG_CODE HANGMOG_CODE, F.HANGMOG_NAME ,                                                                                               ");
		sql.append("       IFNULL(C.JAEGO_QTY,0) + IFNULL(B.IPGO_QTY, 0) - IFNULL(B.CHULGO_QTY, 0)		 AS 			JAEGO_QTY,										");	
		sql.append("       IFNULL(FN_TOTAL_RESERVE_QTY(:hosp_code, A.JAERYO_CODE), 0)     									                                       	    ");
		sql.append(" 	FROM INV0110 A                                                                                                                                  ");
		sql.append(" 	 INNER JOIN (SELECT JAERYO_CODE,  HANGMOG_CODE, HANGMOG_NAME  FROM OCS0103 WHERE HOSP_CODE = :hosp_code AND HANGMOG_CODE IN(:hangmog_codes)     ");
		sql.append(" AND START_DATE <= SYSDATE() AND END_DATE >= SYSDATE() ) F   ON A.JAERYO_CODE = F.JAERYO_CODE                                                       ");
		sql.append("     LEFT JOIN																																		");				
		sql.append(" 	(  SELECT X.HOSP_CODE AS HOSP_CODE,																												");										
		sql.append(" 	          X.JAERYO_CODE AS JAERYO_CODE,																											");											
		sql.append(" 	          SUM(CASE IPCHUL_GUBUN WHEN 'I' THEN IPCHUL_QTY ELSE 0 END) AS IPGO_QTY,																");																						
		sql.append(" 	          SUM(CASE IPCHUL_GUBUN WHEN 'O' THEN IPCHUL_QTY ELSE 0 END) AS CHULGO_QTY,  															");																							
		sql.append(" 	          X.IPCHUL_BUSEO AS IPCHUL_BUSEO 																										");												
		sql.append(" 	          FROM INV5001 X																														");								
		sql.append(" 	          WHERE X.HOSP_CODE = :hosp_code																										");												
		sql.append(" 	           AND X.IPCHUL_DATE BETWEEN LAST_DAY(SYSDATE() - INTERVAL 1 MONTH) + INTERVAL 1 DAY AND SYSDATE()                                  	");																																					
		sql.append(" 	          GROUP BY X.HOSP_CODE, X.JAERYO_CODE ) B ON A.HOSP_CODE = B.HOSP_CODE AND A.JAERYO_CODE = B.JAERYO_CODE				                ");																																		
		sql.append(" 	LEFT JOIN (SELECT Y.HOSP_CODE AS HOSP_CODE																										");												
		sql.append(" 		            , Z.JAERYO_CODE AS JAERYO_CODE																									");													
		sql.append(" 		            , IFNULL(Z.JAEGO_QTY,0) AS JAEGO_QTY																							");															
		sql.append(" 		            FROM INV6000 Y																													");									
		sql.append(" 		            , INV6001 Z																														");								
		sql.append(" 		            WHERE Y.HOSP_CODE = :hosp_code																									");													
		sql.append(" 		            AND Y.MAGAM_MONTH = DATE_FORMAT(TIMESTAMPADD(MONTH, -1,LAST_DAY(SYSDATE() - INTERVAL 1 MONTH) + INTERVAL 1 DAY), '%Y%m')    	");																																	
		sql.append(" 		            AND Z.HOSP_CODE = Y.HOSP_CODE																									");													
		sql.append(" 		            AND Z.FKINV6000 = Y.PKINV6000 ) C ON C.HOSP_CODE = A.HOSP_CODE AND C.JAERYO_CODE= A.JAERYO_CODE	                                ");
		sql.append(" WHERE  A.HOSP_CODE = :hosp_code	                                                                                                                ");
		sql.append(" AND A.STOCK_YN = 'Y'																																");																						
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("hangmog_codes", hangmogCode);
		
		List<CheckRemainingInventoryInfo> listData = new JpaResultMapper().list(query, CheckRemainingInventoryInfo.class);
		return listData;
	}

	@Override
	public String checkInvenByHangmogCode(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT	'Y'                                                                                                                                     	");
		sql.append(" 	FROM INV0110 A                                                                                                                                  ");
		sql.append(" 	 INNER JOIN (SELECT JAERYO_CODE,  HANGMOG_CODE, HANGMOG_NAME  FROM OCS0103 WHERE HOSP_CODE = :hosp_code AND HANGMOG_CODE = :hangmog_codes       ");
		sql.append(" AND START_DATE <= SYSDATE() AND END_DATE >= SYSDATE() ) F   ON A.JAERYO_CODE = F.JAERYO_CODE                                                       ");
		sql.append(" WHERE  A.HOSP_CODE = :hosp_code	                                                                                                                ");
		sql.append(" AND A.STOCK_YN = 'Y'																																");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("hangmog_codes", hangmogCode);
		
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public String findJaeryoCode(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT	F.JAERYO_CODE                                                                                                                              ");
		sql.append(" 	FROM INV0110 A                                                                                                                                 ");
		sql.append(" 	 INNER JOIN (SELECT JAERYO_CODE,  HANGMOG_CODE, HANGMOG_NAME  FROM OCS0103 WHERE HOSP_CODE = :hosp_code AND HANGMOG_CODE = :hangmog_code       ");
		sql.append(" AND START_DATE <= SYSDATE() AND END_DATE >= SYSDATE() ) F   ON A.JAERYO_CODE = F.JAERYO_CODE                                                      ");
		sql.append(" WHERE  A.HOSP_CODE = :hosp_code	                                                                                                               ");
		sql.append(" AND A.STOCK_YN = 'Y'																															   ");		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("hangmog_code", hangmogCode);
		
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		
		return null;
	}

	@Override
	public List<INV6000U00ExportCSVInfo> getINV6000U00ExportCSVInfo(String hospCode, String language, Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CAST((@rownum\\:=@rownum+1) AS CHAR)          ROW_NUM                                                                         ");
		sql.append("  , A.JAERYO_CODE                                                                                                                     ");
		sql.append("  , B.JAERYO_NAME                                                                                                                     ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', B.SUBUL_DANUI, :hosp_code, :language) IPGO_DANUI_NAME                                        ");
		sql.append("  , A.DANGA                                                                                                                           ");
		sql.append("  , A.PRE_M_JAEGO_QTY                                                                                                                 ");
		sql.append("  , A.IPGO_QTY                                                                                                                        ");
		sql.append("  , A.CHULGO_QTY                                                                                                                      ");
		sql.append("  , A.JAEGO_QTY                                                                                                                       ");
		
		sql.append("  , C.EXIST_COUNT                                                                                      								  ");
		sql.append("  , IFNULL(C.EXIST_COUNT, 0) - IFNULL(A.JAEGO_QTY, 0) AS DELTA_QTY                                                                    ");
		sql.append(" FROM INV6001 A LEFT OUTER JOIN INV6002 C ON C.HOSP_CODE = A.HOSP_CODE                                                                ");
		sql.append("                                        AND  C.JAERYO_CODE = A.JAERYO_CODE                                                   		  ");
		sql.append(" , INV0110 B                                                                                										  ");
		sql.append(" ,(SELECT @rownum\\:=0) r                                                                                							  ");
		sql.append(" WHERE                                                                                                                                ");
		sql.append(" A.HOSP_CODE     =   B.HOSP_CODE                                                                                                      ");                                                                                                                                         
		sql.append(" AND B.HOSP_CODE =  :hosp_code                                                                                                        ");                                                                                                                                       
		sql.append(" AND B.JAERYO_CODE    =   A.JAERYO_CODE                                                                                               ");                                                                                                                                                
		sql.append("  AND   A.MAGAM_DATE >= :fromDate      AND A.MAGAM_DATE <= :toDate                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("fromDate", fromDate);
		query.setParameter("toDate", toDate);
		
		List<INV6000U00ExportCSVInfo> listData = new JpaResultMapper().list(query, INV6000U00ExportCSVInfo.class);
		return listData;
	}

	@Override
	public List<INV6002U00GrdINV6002Info> getINV6002U00GrdINV6002Info(String hospCode, String language, String gubun,
			String jaeryoGubun, String month, Integer startNum, Integer endNum, String hangmogNameInx) {
		StringBuilder sql = new StringBuilder();
		if(gubun.equalsIgnoreCase(CommonEnum.BEFORE.getValue())){
			sql.append("  SELECT A.JAERYO_CODE                                                                                              ");
			sql.append("       , A.JAERYO_NAME                                                                                              ");
			sql.append("       , ''           EXIST_COUNT                                                                                   ");
			sql.append("       , FN_OCS_LOAD_CODE_NAME ('ORD_DANUI', A.SUBUL_DANUI, :f_hosp_code, :f_language)  AS SUBUL_DANUI_NAME         ");
			sql.append("       , ''      INPUT_DATE                                                                                         ");
			sql.append("       , ''   INPUT_USER                                                                                            ");
			sql.append("       , V.CODE_NAME  AS JARYO_GUBUN                                                                                ");
			sql.append("       , :f_month                                                                                                   ");
			sql.append(" FROM  INV0110 A    LEFT JOIN OCS0103 C ON C.HOSP_CODE     = A.HOSP_CODE                                            ");
			sql.append("    AND C.HANGMOG_CODE  = A.JAERYO_CODE   AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun                                  ");
			sql.append("    LEFT JOIN INV0102 V ON V.CODE = C.ORDER_GUBUN AND V.HOSP_CODE = C.HOSP_CODE AND V.CODE_TYPE = 'JAERYO_GUBUN' AND V.LANGUAGE = :f_language   ");
			sql.append("   WHERE A.HOSP_CODE   = :f_hosp_code                                                                               ");
			sql.append("     AND A.JAERYO_CODE NOT IN ( SELECT B.JAERYO_CODE                                                                ");
			sql.append("                                                              FROM INV6002 B                                        ");
			sql.append("                                                             WHERE B.HOSP_CODE   = :f_hosp_code                     ");
			sql.append("                                                                   AND B.MAGAM_MONTH = :f_month                     ");
			sql.append("                                                                   AND B.EXIST_COUNT IS NOT NULL                    ");
			sql.append("                                                           )                                                        ");
			sql.append("     AND A.STOCK_YN      = 'Y'                                                                                      ");                                                        
			sql.append("     AND SYSDATE()  BETWEEN C.START_DATE AND C.END_DATE                                                             ");
			if(!Strings.isEmpty(hangmogNameInx)){
				sql.append("    AND C.HANGMOG_NAME_INX  LIKE :f_jaeryo_code                                  								");
			}
			sql.append("   ORDER BY C.ORDER_GUBUN, A.JAERYO_NAME																			");
			sql.append("      LIMIT :startNum, :endNum 			        		 													        ");
			
		}else{
			sql.append(" SELECT A.JAERYO_CODE                                                                                                                       ");
			sql.append("                 , B.JAERYO_NAME                                                                                                            ");
			sql.append("                 , cast(A.EXIST_COUNT  as char)                                                                                             ");
			sql.append("                 , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', B.SUBUL_DANUI, :f_hosp_code, :f_language) SUBUL_DANUI_NAME                          ");
			sql.append("                 , DATE_FORMAT(A.INPUT_DATE, '%Y/%m/%d')                                                                                    ");
			sql.append("                 , D.USER_NM                                                                                                                ");
			sql.append("                 , V.CODE_NAME  AS JARYO_GUBUN                                                                                              ");
			sql.append("                 , ''                                                                                                                       ");
			sql.append("          FROM  INV0110 B, INV6002 A   , ADM3200 D   ,                                                                                      ");
			sql.append("                 OCS0103 C LEFT JOIN INV0102 V ON V.CODE = C.ORDER_GUBUN AND V.HOSP_CODE = C.HOSP_CODE AND V.CODE_TYPE = 'JAERYO_GUBUN'  AND V.LANGUAGE = :f_language   ");
			sql.append("         WHERE A.HOSP_CODE     = :f_hosp_code                                                                                               ");
			sql.append("           AND A.MAGAM_MONTH   = :f_month                                                                                                   ");
			sql.append("           AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                ");
			sql.append("           AND B.JAERYO_CODE   = A.JAERYO_CODE                                                                                              ");
			sql.append("           AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                ");
			sql.append("           AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun                                                                                         ");
			sql.append("           AND D.HOSP_CODE = A.HOSP_CODE                                                                                                    ");
			sql.append("           AND D.USER_ID   = A.INPUT_USER                                                                                                   ");
			sql.append("           AND C.HANGMOG_CODE  = A.JAERYO_CODE                                                                                              ");
			sql.append("           AND SYSDATE()  BETWEEN C.START_DATE AND C.END_DATE                                                                               ");
			if(!Strings.isEmpty(hangmogNameInx)){
				sql.append("    	   AND C.HANGMOG_NAME_INX  LIKE :f_jaeryo_code                                  												");
			}
			
			sql.append("         ORDER BY C.ORDER_GUBUN , B.JAERYO_NAME																								");
			sql.append("      LIMIT :startNum, :endNum 			        		 													                                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaeryo_gubun", jaeryoGubun);
		query.setParameter("f_month", month);
		query.setParameter("f_language", language);
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		if(!Strings.isEmpty(hangmogNameInx)){
			query.setParameter("f_jaeryo_code", "%" + hangmogNameInx + "%");
		}
		
		List<INV6002U00GrdINV6002Info> listData = new JpaResultMapper().list(query, INV6002U00GrdINV6002Info.class);
		return listData;
	}
	
	@Override
	public boolean isExistedINV0110(String hospCode, String jaeryoCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'  									");
		sql.append("	FROM INV0110 A                         	 	    ");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code   		    ");
		sql.append("	AND A.JAERYO_CODE     = :f_jaeryo_code          ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaeryo_code", jaeryoCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}
	
	public List<DRGOCSCHKGrdOcsChkFullInfo> getDRGOCSCHKGrdOcsChkFullInfo(String hospCode, String language, String jaeryoCode, String jaeryoName, String preSmallCode, String smallCode,
		String drgPackYn, String phamarcyYn, String powderYn, String hubalYn, String mayakYn, String stockYn, String beforeUseYn, String wonnaeDrgYn,
		String jaeryoGubun, Integer pageNumber, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JAERYO_CODE             											 												");
		sql.append("   ,A.JAERYO_NAME																											");
		sql.append("   ,A.CHK3 DRG_PACK_YN																										");
		sql.append("   ,A.CHK2 PHAMARCY_YN																										");
		sql.append("   ,A.CHK1  POWDER_YN																										");
		sql.append("   ,A.TOIJANG_YN  HUBAL_CHANGE_YN																							");
		sql.append("   ,A.BUNRYU2 MAYAK_YN																										");
		sql.append("   ,A.SMALL_CODE 																											");
		sql.append("   ,B.CODE_NAME1 SMALL_CODE_NAME																							");
		sql.append("   ,A.CAUTION_CODE																											");
		sql.append("   ,D.CAUTION_NAME 																											");
		sql.append("   ,C.START_DATE  																											");
		sql.append("   ,E.DANUI SUNAB_DANUI 																									");
		sql.append("   ,E.DANUI_NAME SUNAB_DANUI_NAME																							");
		sql.append("   ,A.SUBUL_DANUI SUBUL_DANUI																								");
		sql.append("   ,F.CODE_NAME AS SUBUL_DANUI_NAME 																						");
		sql.append("   ,A.STOCK_YN STOCK_YN																										");
		sql.append("   ,A.SUBUL_DANGA SUBUL_DANGA																								");
		sql.append("   ,A.SUBUL_QCODE_OUT																										");
		sql.append("   ,(SELECT Y.CODE_NAME 																									");
		sql.append("    FROM BAS0102 Y, BAS0101 X																								");
		sql.append("    WHERE  X.CODE_TYPE = 'SUBUL_CONV_CODE'																					");
		sql.append("    AND Y.CODE_TYPE = X.CODE_TYPE																							");
		sql.append("    AND Y.CODE      = A.SUBUL_QCODE_OUT              																		");
		sql.append("    AND Y.HOSP_CODE = :f_hosp_code              																			");
		sql.append("    AND Y.LANGUAGE = :f_language AND X.LANGUAGE = :f_language)              SUBUL_QCODE_OUT_NAME							");
		sql.append("   ,A.SUBUL_QCODE_INP																										");
		sql.append("   ,(SELECT Y.CODE_NAME 																									");
		sql.append("    FROM BAS0102 Y, BAS0101 X																								");
		sql.append("    WHERE  X.CODE_TYPE = 'SUBUL_CONV_CODE'																					");
		sql.append("    AND Y.CODE_TYPE = X.CODE_TYPE																							");
		sql.append("    AND Y.HOSP_CODE = :f_hosp_code    																						");
		sql.append("    AND Y.LANGUAGE = :f_language    																						");
		sql.append("    AND Y.CODE      = A.SUBUL_QCODE_INP AND X.LANGUAGE = :f_language)    SUBUL_QCODE_INP_NAME								");
		sql.append(" FROM INV0110 A LEFT OUTER JOIN DRG0141 B ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE1   = A.SMALL_CODE AND B.LANGUAGE  = :f_language						");
		sql.append(" LEFT JOIN OCS0103 AB ON A.HOSP_CODE = AB.HOSP_CODE AND A.JAERYO_CODE = AB.HANGMOG_CODE										");
		sql.append(" LEFT OUTER JOIN DRG0130 D ON D.HOSP_CODE    = A.HOSP_CODE AND D.CAUTION_CODE    = A.CAUTION_CODE 	AND D.LANGUAGE  = :f_language						");
		sql.append(" LEFT OUTER JOIN(SELECT  X.SG_CODE           																				");
		sql.append("   , X.SG_UNION          																									");
		sql.append("   , X.SG_NAME           																									");
		sql.append("   , X.BULYONG_YMD       																									");
		sql.append("   , X.DANUI        																										");
		sql.append("   , Y.CODE_NAME AS DANUI_NAME     																							");
		sql.append("   , X.HUBAL_DRG_YN 																										");
		sql.append("   , X.HOSP_CODE																											");
		sql.append("    FROM BAS0310 X, OCS0132 Y       																						");
		sql.append("    WHERE X.HOSP_CODE = :f_hosp_code																						");
		sql.append("    AND X.SG_YMD =(SELECT MAX(Z.SG_YMD) 																					");
		sql.append("       FROM BAS0310 Z 																										");
		sql.append("       WHERE Z.HOSP_CODE = X.HOSP_CODE 																						");
		sql.append("       AND Z.SG_CODE = X.SG_CODE 																							");
		sql.append("       AND Z.SG_YMD <= SYSDATE())																							");
		sql.append("    AND Y.HOSP_CODE = X.HOSP_CODE																							");
		sql.append("    AND Y.CODE_TYPE = 'ORD_DANUI'																							");
		sql.append("    AND Y.CODE = X.DANUI) E ON E.HOSP_CODE  = A.HOSP_CODE AND E.SG_CODE    = A.JAERYO_CODE 									");
		sql.append("    LEFT OUTER JOIN OCS0132 F ON F.HOSP_CODE   = A.HOSP_CODE AND F.CODE     = A.SUBUL_DANUI AND F.CODE_TYPE   = 'ORD_DANUI' ");
		sql.append(" INNER JOIN OCS0103 C ON C.HOSP_CODE   = A.HOSP_CODE	AND C.HANGMOG_CODE  = A.JAERYO_CODE									");
		
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code 																						");
		sql.append(" AND A.JAERYO_CODE          LIKE :f_jaeryo_code 																			");
		sql.append(" AND A.JAERYO_NAME          LIKE :f_jaeryo_name 																			");
		sql.append(" AND IFNULL(A.SMALL_CODE,'%')  LIKE :f_pre_small_code  																		");
		sql.append(" AND IFNULL(A.SMALL_CODE,'%')  LIKE :f_small_code 																			");
		sql.append(" AND IFNULL(A.CHK3,'%')        LIKE :f_drg_pack_yn  																		");
		sql.append(" AND IFNULL(A.CHK2,'%')        LIKE :f_phamarcy_yn 																			");
		sql.append(" AND IFNULL(A.CHK1,'%')        LIKE :f_powder_yn  																			");
		sql.append(" AND IFNULL(A.TOIJANG_YN,'%')  LIKE :f_hubal_yn 																			");
		sql.append(" AND IFNULL(A.BUNRYU2,'0')     LIKE CONCAT(IF(:f_mayak_yn = '1','1','%'),'%') 												");
		sql.append(" AND IFNULL(A.STOCK_YN,'N')    LIKE :f_stock_yn 																			");
		sql.append(" AND SYSDATE()  BETWEEN C.START_DATE AND C.END_DATE 																		");
		sql.append(" AND IFNULL(C.BEFORE_USE_YN,'N') LIKE :f_before_use_yn 																		");
		sql.append(" AND IFNULL(C.WONNAE_DRG_YN,'N') LIKE :f_wonnae_drg_yn																		");
		if(jaeryoGubun.equals("%")){
			sql.append(" AND AB.ORDER_GUBUN LIKE :f_jaeryo_gubun                                                                                ");
		}else{
			sql.append(" AND AB.ORDER_GUBUN LIKE :f_jaeryo_gubun                                                                                ");
		}
		sql.append(" ORDER BY A.JAERYO_NAME																										");
		if (offset != 0) {
			sql.append(" LIMIT :startNum, :endNum 	 																							");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jaeryo_code", jaeryoCode + "%");
		query.setParameter("f_jaeryo_name", "%" + jaeryoName + "%");
		query.setParameter("f_pre_small_code", preSmallCode + "%");
		query.setParameter("f_small_code", smallCode + "%");
		query.setParameter("f_drg_pack_yn", drgPackYn + "%");
		query.setParameter("f_phamarcy_yn", phamarcyYn + "%");
		query.setParameter("f_powder_yn", powderYn + "%");
		query.setParameter("f_hubal_yn", hubalYn + "%");
		query.setParameter("f_mayak_yn", mayakYn);
		query.setParameter("f_stock_yn", stockYn + "%");
		query.setParameter("f_before_use_yn", beforeUseYn + "%");
		query.setParameter("f_wonnae_drg_yn", wonnaeDrgYn + "%");
		query.setParameter("f_jaeryo_gubun", jaeryoGubun);
		if (offset != 0) {
			query.setParameter("startNum", pageNumber);
			query.setParameter("endNum", offset);
		}
		
		List<DRGOCSCHKGrdOcsChkFullInfo> list = new JpaResultMapper().list(query, DRGOCSCHKGrdOcsChkFullInfo.class);
		return list;
	}

}

