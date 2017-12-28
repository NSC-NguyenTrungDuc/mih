package nta.med.data.dao.medi.ocs.impl;

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
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2017RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR2017U01grdNUR2017Info;
import nta.med.data.model.ihis.nuri.NUR2017U01grdPalistInfo;
import nta.med.data.model.ihis.ocsi.NUR2017Q00grdNUR2017Info;

/**
 * @author dainguyen.
 */
public class Ocs2017RepositoryImpl implements Ocs2017RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs2017RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<NUR2017Q00grdNUR2017Info> getNUR2017Q00grdNUR2017Info(String hospCode, String language, String bunho,
			String orderDate, String pkocs2003) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT E.HO_CODE1,																				    ");
		sql.append("       C.BUNHO,																					    ");
		sql.append("       E.SUNAME,																				    ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(E.GWA, B.ORDER_DATE, :f_hosp_code, :f_language)    GWA_NAME,		    ");
		sql.append("       B.HANGMOG_CODE,                                                                              ");
		sql.append("       A.HANGMOG_NAME,                                                                              ");
		sql.append("       CASE SUBSTRING(IFNULL(B.ACTING_SURYANG,0),1,1)                                               ");
		sql.append("       WHEN '.' THEN CONCAT('0',ROUND(B.ACTING_SURYANG,3))                                          ");
		sql.append("       ELSE ROUND(B.ACTING_SURYANG,3) END                                      SURYANG,			    ");
		sql.append("       C.ORD_DANUI,		                                                                            ");
		sql.append("       C.DV_TIME,		                                                                            ");
		sql.append("       1,				                                                                            ");
		sql.append("       C.JUSA,			                                                                            ");
		sql.append("       C.BOGYONG_CODE,	                                                                            ");
		sql.append("       B.ACTING_DATE,		                                                                        ");
		sql.append("       IFNULL(B.ACTING_TIME, '0000'),	                                                            ");
		sql.append("       B.ACT_USER   ,					                                                            ");
		sql.append("       IF(B.ACTING_DATE IS NULL,'N','Y')                                        ACTING_YN,		    ");
		sql.append("       B.FKOCS2003,																				    ");
		sql.append("       B.SEQ,																					    ");
		sql.append("       B.ORDER_DATE,																			    ");
		sql.append("       IFNULL(F.BOGYONG_NAME,' ')                                               BOGYONG_NAME,	    ");
		sql.append("       C.DC_YN,		                                                                                ");
		sql.append("       C.GROUP_SER,	                                                                                ");
		sql.append("       C.MIX_GROUP,	                                                                                ");
		sql.append("       C.HOPE_DATE,	                                                                                ");
		sql.append("       FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code, 'JUSA', C.JUSA)             JUSA_TEXT,		    ");
		sql.append("       FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code, 'ORD_DANUI', C.ORD_DANUI)   DANUI_TEXT,		    ");
		sql.append("       C.ORDER_REMARK,                                                                              ");
		sql.append("       C.NURSE_REMARK,                                                                              ");
		sql.append("       FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code,'INPUT_GUBUN',C.INPUT_GUBUN) INPUT_GUBUN_TEXT,	");
		sql.append("       C.JUSA_SPD_GUBUN                                                         JUSA_SPD_GUBUN,		");
		sql.append("       FN_BAS_LOAD_SABUN_NAME(:f_hosp_code, B.ACT_USER)                         ACT_USER_NAME,   	");
		sql.append("       B.BANNAB_YN                                                              BANNAB_YN,			");
		sql.append("       B.BANNAB_FKOCS2003                                                       BANNAB_FKOCS2003,	");
		sql.append("       IFNULL(B.BANNAB_YN, 'N')                                                 OLD_BANNAB_YN		");
		sql.append("  FROM OCS0103        A							                                                    ");
		sql.append("       JOIN OCS2017        B					                                                    ");
		sql.append("          ON  B.HOSP_CODE    = A.HOSP_CODE		                                                    ");
		sql.append("       JOIN OCS2003        C					                                                    ");
		sql.append("          ON  C.HOSP_CODE    = A.HOSP_CODE		                                                    ");
		sql.append("          AND C.HANGMOG_CODE = A.HANGMOG_CODE	                                                    ");
		sql.append("          AND C.PKOCS2003 = B.FKOCS2003			                                                    ");
		sql.append("       LEFT JOIN DRG0120        F				                                                    ");
		sql.append("          ON  F.HOSP_CODE = C.HOSP_CODE			                                                    ");
		sql.append("          AND F.BOGYONG_CODE = C.BOGYONG_CODE	                                                    ");
		sql.append("          AND F.LANGUAGE     = :f_language		                                                    ");
		sql.append("       JOIN VW_OCS_INP1001 E					                                                    ");
		sql.append("          ON  E.HOSP_CODE    = A.HOSP_CODE		                                                    ");
		sql.append("          AND C.FKINP1001    = E.PKINP1001		                                                    ");
		sql.append("  ,(select @kcck_hosp_code\\:=:f_hosp_code) TMP	                                                    ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code			                                                    ");
		sql.append("   AND IFNULL(C.PRN_YN,'N') = 'N'				                                                    ");
		sql.append("   AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')                                            ");
		sql.append("   AND B.DISPLAY_SEQ IN( 3, 4, 5) 						                                            ");
		sql.append("   AND IFNULL(C.ERROR_FLAG, 'N') = 'N'					                                            ");
		sql.append("   AND C.OCS_FLAG > '0'									                                            ");
		sql.append("   AND IFNULL(C.TOIWON_DRG_YN, 'N') = 'N'  				                                            ");
		sql.append("   AND C.PKOCS2003 IN ( SELECT X.PKOCS2003				                                            ");
		sql.append("                          FROM OCS2003 X				                                            ");
		sql.append("                         WHERE X.HOSP_CODE  = A.HOSP_CODE	                                        ");
		sql.append("                           AND X.BUNHO      = :f_bunho		                                        ");
		sql.append("                           AND X.ORDER_DATE = :f_order_date	                                        ");
		sql.append("                           AND EXISTS ( SELECT 'X'			                                        ");
		sql.append("                                          FROM OCS2003 Y	                                        ");
		sql.append("                                         WHERE Y.HOSP_CODE  = X.HOSP_CODE							");
		sql.append("                                           AND Y.PKOCS2003  = :f_pkocs2003							");
		sql.append("                                           AND Y.GROUP_SER  = X.GROUP_SER							");
		sql.append("                                           AND Y.INPUT_GUBUN = X.INPUT_GUBUN						");
		sql.append("                                           AND Y.ORDER_DATE = X.ORDER_DATE ))						");
		sql.append("   AND C.ORDER_DATE  = :f_order_date																");
		sql.append("   AND E.BUNHO       = :f_bunho                                        								");
//		sql.append(" ORDER BY E.BUNHO,C.ORDER_DATE, B.SEQ, FN_OCS_LOAD_ORDER_SORT('I',   C.INPUT_GUBUN, C.ORDER_GUBUN, C.GROUP_SER, C.MIX_GROUP,");
//		sql.append("                                 C.SEQ, C.PKOCS2003, C.SOURCE_FKOCS2003, :f_hosp_code)				");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_pkocs2003", CommonUtils.parseDouble(pkocs2003));
		List<NUR2017Q00grdNUR2017Info> list =  new JpaResultMapper().list(query, NUR2017Q00grdNUR2017Info.class);
		return list;
	}
	@Override
	public Integer updateOcs2017InOCS6010U10PopupDAbtnList(String hospCode, double fkocs2003, Date actResDate,
			String userId, String actUser, Date actingDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("   UPDATE OCS2017										");
		sql.append("   SET UPD_ID      = :f_user_id							");
		sql.append("     , UPD_DATE    = SYSDATE()							");
		sql.append("     , ACTING_DATE = :f_acting_date						");
		sql.append("     , PASS_DATE   = :f_acting_date						");
		sql.append("     , ACTING_TIME = DATE_FORMAT(SYSDATE(), '%H%i')		");
		sql.append("     , ACT_USER    = :f_act_user						");
		sql.append("   WHERE HOSP_CODE     = :f_hosp_code					");
		sql.append("     AND FKOCS2003     = :f_fkocs2003					");
		sql.append("     AND ACT_RES_DATE  = :f_act_res_date				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2003", fkocs2003);
		query.setParameter("f_act_res_date", actResDate);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_act_user", actUser);
		
		return query.executeUpdate();
	}
	
	@Override
	public List<NUR2017U01grdNUR2017Info> getNUR2017U01grdNUR2017Info(String hospCode, String language,
			String orderGubun, String actResDate, String bunho, String bannabDel) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT E.HO_CODE1                                                                                                                                               ");
		sql.append("	     , C.BUNHO                                                                                                                                                  ");
		sql.append("	     , E.SUNAME                                                                                                                                                 ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(E.GWA, B.ORDER_DATE, :f_hosp_code, :f_language)                    	                                                                ");
		sql.append("	                                                                      GWA_NAME                                                                                  ");
		sql.append("	     , B.HANGMOG_CODE                                                                                                                                           ");
		sql.append("	     , A.HANGMOG_NAME                                                                                                                                           ");
		sql.append("	     , B.ACT_RES_DATE                            					  ACT_RES_DATE                                                                              ");
		sql.append("	     , IF(SUBSTR(IFNULL(B.ACTING_SURYANG,0),1,1) = '.', CONCAT('0', ROUND(B.ACTING_SURYANG,3)) , ROUND(B.ACTING_SURYANG,3))                                     ");
		sql.append("	                                                                      SURYANG                                                                                   ");
		sql.append("	     , C.ORD_DANUI                                                                                                                                              ");
		sql.append("	     , C.DV_TIME                                                                                                                                                ");
		sql.append("	     , 1                                                              DV                                                                                        ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_JUSA_CUT_NAME(C.JUSA, :f_hosp_code), '')    JUSA                                                                                      ");
		sql.append("	     , FN_OCS_BOGYONG_COL_NAME(A.ORDER_GUBUN, C.BOGYONG_CODE, C.JUSA_SPD_GUBUN, :f_hosp_code, :f_language)                                                      ");
		sql.append("	                                                                      BOGYONG_CODE                                                                              ");
		sql.append("	     , IFNULL(B.ACTING_DATE, B.PASS_DATE)                             ACTING_DATE                                                                               ");
		sql.append("	     , IFNULL(IF(B.ACTING_DATE IS NULL, '', IFNULL(B.ACTING_TIME, '0000'))                                                                                      ");
		sql.append("	          ,IF(B.PASS_DATE IS NULL, '', IFNULL(B.PASS_TIME, '0000')))  ACTING_TIME                                                                               ");
		sql.append("	     , IFNULL(IFNULL(B.ACT_USER, B.PASS_USER), '')                    ACTING_USER                                                                               ");
		sql.append("	     , IF(B.ACTING_DATE IS NULL, 'N', 'Y')                            ACTING_YN                                                                                 ");
		sql.append("	     , B.FKOCS2003                                                                                                                                              ");
		sql.append("	     , B.SEQ                                                                                                                                                    ");
		sql.append("	     , B.ORDER_DATE                                                                                                                                             ");
		sql.append("	     , IFNULL(F.BOGYONG_NAME,' ')                                     BOGYONG_NAME                                                                              ");
		sql.append("	     , C.DC_YN                                                                                                                                                  ");
		sql.append("	     , SUBSTR(C.GROUP_SER, 2 )                                        GROUP_SER                                                                                 ");
		sql.append("	     , C.MIX_GROUP                                                                                                                                              ");
		sql.append("	     , C.HOPE_DATE                                                                                                                                              ");
		sql.append("	     , IFNULL(FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code, 'JUSA', C.JUSA), '')                                                                                 ");
		sql.append("	                                                                      JUSA_TEXT                                                                                 ");
		sql.append("	     , FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code, 'ORD_DANUI', C.ORD_DANUI)                                                                                   ");
		sql.append("	                                                                      DANUI_TEXT                                                                                ");
		sql.append("	     , IFNULL(C.ORDER_REMARK, '')                                                                                                                               ");
		sql.append("	     , IFNULL(C.NURSE_REMARK, '')                                                                                                                               ");
		sql.append("	     , FN_OCSI_LOAD_OCS0132_CODE_NAME(:f_hosp_code, 'INPUT_GUBUN', C.INPUT_GUBUN)                                                                               ");
		sql.append("	                                                                      INPUT_GUBUN_TEXT                                                                          ");
		sql.append("	     , C.JUSA_SPD_GUBUN                                               JUSA_SPD_GUBUN                                                                            ");
		sql.append("	     , IFNULL(FN_BAS_LOAD_SABUN_NAME(:f_hosp_code, IFNULL(B.ACT_USER, B.PASS_USER)), '')                                                                        ");
		sql.append("	                                                                      ACT_USER_NAME                                                                             ");
		sql.append("	     , IFNULL(B.BANNAB_YN, '')                                        BANNAB_YN                                                                                 ");
		sql.append("	     , B.BANNAB_FKOCS2003                                             BANNAB_FKOCS2003                                                                          ");
		sql.append("	     , IFNULL(B.BANNAB_YN, 'N')                                       OLD_BANNAB_YN                                                                             ");
		sql.append("	     , IFNULL(B.BANNAB_YN, '')                                        DRUG_BANNAB_YN                                                                            ");
		sql.append("	     , CASE WHEN IFNULL(C.DC_GUBUN, 'N') = 'Y' AND IF(C.DC_YN IS NULL OR C.DC_YN = '', 'N', C.DC_YN) = 'Y' THEN 'Y'                                             ");
		sql.append("	            ELSE 'N'                                                                                                                                            ");
		sql.append("	       END                                                            ORDER_DC_YN                                                                               ");
		sql.append("	     , CASE WHEN IFNULL(C.DC_GUBUN, 'N') = 'Y' AND IF(C.DC_YN IS NULL OR C.DC_YN = '', 'N', C.DC_YN) = 'N' THEN 'Y'                                             ");
		sql.append("	            ELSE 'N'                                                                                                                                            ");
		sql.append("	       END                                                            ORDER_BANNAB_YN                                                                           ");
		sql.append("	     , CASE WHEN C.ACTING_DATE IS NOT NULL THEN 'Y'                                                                                                             ");
		sql.append("	                                           ELSE 'N'                                                                                                             ");
		sql.append("	       END                                                            BANNAB_ACTING_YN                                                                          ");
		sql.append("	     , FN_BAS_LOAD_CODE_NAME('DV_PATTERN_GUBUN', (CASE B.SEQ WHEN '0' THEN '0' ELSE LOCATE('1',SUBSTRING(F.PATTERN,2),1) END), :f_hosp_code, :f_language)       ");
		sql.append("	                                                                      PATTERN_GUBUN                                                                             ");
		sql.append("	     , C.ORDER_GUBUN                                                                                                                                            ");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(C.ORDER_GUBUN,2,1), :f_hosp_code, :f_language)                                                           ");
		sql.append("	                                                                      ORDER_GUBUN_NAME                                                                          ");
		sql.append("	     , IF(B.PASS_DATE IS NULL OR B.PASS_DATE = '', 'N', 'Y')          PASS_YN                                                                                   ");
		sql.append("	     , IF(B.IF_DATA_SEND_YN IS NULL OR B.IF_DATA_SEND_YN = '', 'N', B.IF_DATA_SEND_YN)                                                                          ");
		sql.append("	                                                                      IF_DATA_SEND_YN                                                                           ");
		sql.append("	  FROM OCS0103        A,                                                                                                                                        ");
		sql.append("	       OCS2017        B,                                                                                                                                        ");
		sql.append("		     VW_OCS_INP1001 E,                                                                                                                                      ");
		sql.append("	       OCS2003        C                                                                                                                                         ");
		sql.append("	  LEFT JOIN DRG0120   F ON C.HOSP_CODE 	  = F.HOSP_CODE                                                                                                         ");
		sql.append("						   AND C.BOGYONG_CODE = F.BOGYONG_CODE                                                                                                      ");
		sql.append("	  ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                                                               ");
		sql.append("	 WHERE A.HOSP_CODE       = :f_hosp_code                                                                                                                         ");
		sql.append("	   AND B.HOSP_CODE       = A.HOSP_CODE                                                                                                                          ");
		sql.append("	   AND C.HOSP_CODE       = A.HOSP_CODE                                                                                                                          ");
		sql.append("	   AND E.HOSP_CODE       = A.HOSP_CODE                                                                                                                          ");
		sql.append("	   AND C.NDAY_YN         = 'N'                                                                                                                                  ");
		sql.append("	   AND C.FKINP1001       = E.PKINP1001                                                                                                                          ");
		sql.append("	   AND A.HANGMOG_CODE    = C.HANGMOG_CODE                                                                                                                       ");
		sql.append("	   AND C.PKOCS2003       = B.FKOCS2003                                                                                                                          ");
		sql.append("	   AND IF(C.PRN_YN IS NULL OR C.PRN_YN = '', 'N', C.PRN_YN) = 'N'                                                                                               ");
		sql.append("	   AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')                                                                                                        ");
		sql.append("	   AND ((IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun)  = 'A' AND B.DISPLAY_SEQ IN( 3, 4, 5))                                          ");
		sql.append("	    OR  (IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun)  = 'C' AND B.DISPLAY_SEQ = 5)                                                   ");
		sql.append("	    OR  (IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun) != 'C' AND B.DISPLAY_SEQ IN( 3, 4)))                                            ");
		sql.append("	   AND B.ACT_RES_DATE   = STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')                                                                                              ");
		sql.append("	   AND ( (C.ORDER_GUBUN IN ('0C','0D') AND  IFNULL(B.CANCEL_YN,'N') = 'Y'                                                                                       ");
		sql.append("	        AND  STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')BETWEEN DATE(FN_OCSI_LOAD_BANNAB_FROM_DATE(:f_hosp_code, C.PKOCS2003)) AND                                 ");
		sql.append("	             DATE(FN_OCSI_LOAD_BANNAB_TO_DATE(:f_hosp_code, C.PKOCS2003)))                                                                                      ");
		sql.append("	            OR                                                                                                                                                  ");
		sql.append("	             (C.ORDER_GUBUN IN ('0B') AND  IFNULL(B.CANCEL_YN,'N') = 'Y')                                                                                       ");
		sql.append("	             OR                                                                                                                                                 ");
		sql.append("	             (IF(B.CANCEL_YN IS NULL OR B.CANCEL_YN = '', 'N', B.CANCEL_YN) = 'N')                                                                              ");
		sql.append("	            )                                                                                                                                                   ");
		sql.append("	   AND E.BUNHO          = :f_bunho                                                                                                                              ");
		sql.append("	   AND IF(C.ERROR_FLAG IS NULL OR C.ERROR_FLAG = '', 'N', C.ERROR_FLAG) = 'N'                                                                                   ");
		sql.append("	   AND C.OCS_FLAG > '0'                                                                                                                                         ");
		sql.append("	   AND IF(C.TOIWON_DRG_YN IS NULL OR C.TOIWON_DRG_YN = '', 'N', C.TOIWON_DRG_YN) = 'N'                                                                          ");
		sql.append("	   AND C.ACTING_DATE IS NOT NULL                                                                                                                                ");
		sql.append("	   AND ( (:f_bannab_del = 'Y' AND IF(C.BANNAB_YN IS NULL OR C.BANNAB_YN = '', 'N', C.BANNAB_YN) ='N')                                                           ");
		sql.append("	         OR :f_bannab_del = 'N')                                                                                                                                ");
		sql.append("	ORDER BY SUBSTR(C.ORDER_GUBUN, 2) DESC                                                                                                                          ");
		sql.append("	       , IF(B.SEQ = '0', '0', LOCATE('1',SUBSTRING(F.PATTERN,2),1))                                                                                             ");
		sql.append("	       , B.SEQ                                                                                                                                                  ");
		sql.append("	       , C.GROUP_SER                                                                                                                                            ");
		sql.append("	       , C.MIX_GROUP                                                                                                                                            ");
		sql.append("	       , C.PKOCS2003                                                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_act_res_date", actResDate);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_bannab_del", bannabDel);
		
		List<NUR2017U01grdNUR2017Info> list =  new JpaResultMapper().list(query, NUR2017U01grdNUR2017Info.class);
		return list;
	}
	@Override
	public List<NUR2017U01grdPalistInfo> getNUR2017U01grdPalistInfo(String hospCode, String hoDong, String orderGubun,
			String actResDate, String fa, String fb, String fc, String fd, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT                                                                                                                    ");
		sql.append("	        E.HO_DONG1,                                                                                                                ");
		sql.append("	        E.HO_CODE1,                                                                                                                ");
		sql.append("	        E.BED_NO,                                                                                                                  ");
		sql.append("	        E.BUNHO,                                                                                                                   ");
		sql.append("	        E.SUNAME,                                                                                                                  ");
		sql.append("	        E.PKINP1001,                                                                                                               ");
		sql.append("	        CONCAT(FN_BAS_LOAD_AGE(STR_TO_DATE('2013/09/20', '%Y/%m/%d'), E.BIRTH, ''), '/', E.SEX) AGE_SEX,                           ");
		sql.append("	        E.IPWON_DATE                                                      						IPWON_DATE,                        ");
		sql.append("	        FN_BAS_LOAD_DOCTOR_NAME(E.DOCTOR, STR_TO_DATE('2013/09/20', '%Y/%m/%d'), :f_hosp_code) 	DOCTOR_NAME,                       ");
		sql.append("	        D.HO_SORT                                                                                                                  ");
		sql.append("	  FROM OCS0103        A,                                                                                                           ");
		sql.append("	       OCS2017        B,                                                                                                           ");
		sql.append("	       BAS0250        D,                                                                                                           ");
		sql.append("	       VW_OCS_INP1001 E,                                                                                                           ");
		sql.append("		   OCS2003        C                                                                                                            ");
		sql.append("	  LEFT JOIN DRG0120 F ON C.HOSP_CODE	= F.HOSP_CODE                                                                              ");
		sql.append("						 AND C.BOGYONG_CODE = F.BOGYONG_CODE                                                                           ");
		sql.append("	  ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP					                                                               ");
		sql.append("	 WHERE E.HOSP_CODE       = :f_hosp_code                                                                                            ");
		sql.append("	   AND E.HO_DONG1        = :f_ho_dong                                                                                              ");
		sql.append("	   AND D.HOSP_CODE       = E.HOSP_CODE                                                                                             ");
		sql.append("	   AND C.HOSP_CODE       = E.HOSP_CODE                                                                                             ");
		sql.append("	   AND B.HOSP_CODE       = E.HOSP_CODE                                                                                             ");
		sql.append("	   AND A.HOSP_CODE       = E.HOSP_CODE                                                                                             ");
		sql.append("	   AND C.NDAY_YN         = 'N'                                                                                                     ");
		sql.append("	   AND C.FKINP1001       = E.PKINP1001                                                                                             ");
		sql.append("	   AND C.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                          ");
		sql.append("	   AND C.PKOCS2003       = B.FKOCS2003                                                                                             ");
		sql.append("	   AND D.HO_DONG         = E.HO_DONG1                                                                                              ");
		sql.append("	   AND D.HO_CODE         = E.HO_CODE1                                                                                              ");
		sql.append("	   AND IF(C.PRN_YN IS NULL OR C.PRN_YN = '', 'N', C.PRN_YN) = 'N'                                                                  ");
		sql.append("	   AND (C.INPUT_GUBUN LIKE 'D%' OR C.INPUT_GUBUN = 'NR')                                                                           ");
		sql.append("	   AND ((IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun)  = 'A' AND B.DISPLAY_SEQ IN( 3, 4, 5))             ");
		sql.append("	    OR  (IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun)  = 'C' AND B.DISPLAY_SEQ = 5)                      ");
		sql.append("	    OR  (IF(:f_order_gubun IS NULL OR :f_order_gubun = '', 'A', :f_order_gubun) != 'C' AND B.DISPLAY_SEQ IN( 3, 4)))               ");
		sql.append("	   AND B.ACT_RES_DATE   = STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')                                                                 ");
		sql.append("	   AND ( (C.ORDER_GUBUN IN ('0C','0D') AND  IF(B.CANCEL_YN IS NULL OR B.CANCEL_YN = '', 'N', B.CANCEL_YN) = 'Y'                    ");
		sql.append("	        AND  STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')BETWEEN DATE(FN_OCSI_LOAD_BANNAB_FROM_DATE(:f_hosp_code, C.PKOCS2003)) AND    ");
		sql.append("	             DATE(FN_OCSI_LOAD_BANNAB_TO_DATE(:f_hosp_code, C.PKOCS2003)))                                                         ");
		sql.append("	            OR                                                                                                                     ");
		sql.append("	             (C.ORDER_GUBUN IN ('0B') AND  IFNULL(B.CANCEL_YN, 'N') = 'Y')                                                         ");
		sql.append("	             OR                                                                                                                    ");
		sql.append("	             (IF(B.CANCEL_YN IS NULL OR B.CANCEL_YN = '', 'N', B.CANCEL_YN) = 'N')                                                 ");
		sql.append("	            )                                                                                                                      ");
		sql.append("	   AND IF(C.ERROR_FLAG IS NULL OR C.ERROR_FLAG = '', 'N', C.ERROR_FLAG) = 'N'                                                      ");
		sql.append("	   AND C.OCS_FLAG > '0'                                                                                                            ");
		sql.append("	   AND IF(C.TOIWON_DRG_YN IS NULL OR C.TOIWON_DRG_YN = '', 'N', C.TOIWON_DRG_YN) = 'N'                                             ");
		sql.append("	   AND C.ACTING_DATE IS NOT NULL                                                                                                   ");
		sql.append("	   AND ((IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'Y' AND D.TEAM = 'A') OR                                                       ");
		sql.append("	        (IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'Y' AND D.TEAM = 'B') OR                                                       ");
		sql.append("	        (IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'Y' AND D.TEAM = 'C') OR                                                       ");
		sql.append("	        (IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'Y' AND D.TEAM = 'D') OR                                                       ");
		sql.append("	        (IF(:f_a IS NULL OR :f_a = '', 'N', :f_a) = 'N' AND                                                                        ");
		sql.append("	         IF(:f_b IS NULL OR :f_b = '', 'N', :f_b) = 'N' AND                                                                        ");
		sql.append("	         IF(:f_c IS NULL OR :f_c = '', 'N', :f_c) = 'N' AND                                                                        ");
		sql.append("	         IF(:f_d IS NULL OR :f_d = '', 'N', :f_d) = 'N' ))                                                                         ");
		sql.append("	 ORDER BY D.HO_SORT, E.BED_NO                                                                                                      ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_act_res_date", actResDate);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_a", fa);
		query.setParameter("f_b", fb);
		query.setParameter("f_c", fc);
		query.setParameter("f_d", fd);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR2017U01grdPalistInfo> list =  new JpaResultMapper().list(query, NUR2017U01grdPalistInfo.class);
		return list;
	}
	
	@Override
	public Integer updateOcs2017InNUR2017U01(String hospCode, String userId, String actingYn, String actingDate,
			String actingTime, String actUser, String passYn, Double fkocs2003, String actResDate, String hangmogCode,
			Double seq) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS2017                                                                              ");
		sql.append("	SET    UPD_ID       = :q_user_id                                                            ");
		sql.append("	     , UPD_DATE     = SYSDATE()                                                             ");
		sql.append("	     , ACTING_DATE  = IF(:f_acting_yn = 'Y', STR_TO_DATE(:f_acting_date, '%Y/%m/%d'), NULL) ");
		sql.append("	     , ACTING_TIME  = IF(:f_acting_yn = 'Y', REPLACE(:f_acting_time, ':', ''), NULL)        ");
		sql.append("	     , ACT_USER     = IF(:f_acting_yn = 'Y', :f_act_user, NULL)                             ");
		sql.append("	     , PASS_DATE    = IF(:f_pass_yn = 'Y', STR_TO_DATE(:f_acting_date, '%Y/%m/%d'), NULL)   ");
		sql.append("	     , PASS_TIME    = IF(:f_pass_yn = 'Y', REPLACE(:f_acting_time, ':', ''), NULL)          ");
		sql.append("	     , PASS_USER    = IF(:f_pass_yn = 'Y', :f_act_user, NULL)                               ");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code                                                           ");
		sql.append("	  AND FKOCS2003    = :f_fkocs2003                                                           ");
		sql.append("	  AND ACT_RES_DATE = STR_TO_DATE(:f_act_res_date, '%Y/%m/%d')                               ");
		sql.append("	  AND HANGMOG_CODE = :f_hangmog_code                                                        ");
		sql.append("	  AND SEQ          = :f_seq                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_acting_yn", actingYn);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_acting_time", actingTime);
		query.setParameter("f_act_user", actUser);
		query.setParameter("f_pass_yn", passYn);
		query.setParameter("f_fkocs2003", fkocs2003);
		query.setParameter("f_act_res_date", actResDate);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_seq", seq);
		
		return query.executeUpdate();
	}
	@Override
	public String callPrOcsiProcessBannab(String hospCode, String workGubun, Double pkocskey, Double seq,
			String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_PROCESS_BANNAB");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WORK_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCSKEY", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_WORK_GUBUN", workGubun);
		query.setParameter("I_PKOCSKEY", pkocskey);
		query.setParameter("I_SEQ", seq);
		query.setParameter("I_USER_ID", userId);
		query.execute();
		
		String err = (String)query.getOutputParameterValue("IO_ERR") ;
		return err;
	}
	
	
}

