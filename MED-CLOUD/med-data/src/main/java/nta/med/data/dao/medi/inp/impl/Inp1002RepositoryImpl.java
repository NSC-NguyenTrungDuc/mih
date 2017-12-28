package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.collections.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.dao.medi.inp.Inp1002RepositoryCustom;
import nta.med.data.model.ihis.inps.INP1001U01ChangeGubunGrdHistoryInfo;
import nta.med.data.model.ihis.inps.INP1001U01LoadBoheomChildListInfo;
import nta.med.data.model.ihis.inps.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo;

/**
 * @author dainguyen.
 */
public class Inp1002RepositoryImpl implements Inp1002RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getINP3003U00GrdMasterItem(String hospCode, Double pkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(A.PKINP1002 AS CHAR) 	        						");
		sql.append("		FROM INP1002 A 													");
		sql.append("	    WHERE A.HOSP_CODE = :f_hosp_code  								");
		sql.append("	    AND A.FKINP1001 = :f_pkinp1001 									");
		sql.append("	    AND A.GUBUN_TRANS_CNT = (SELECT MAX(Z.GUBUN_TRANS_CNT) 			");
		sql.append("	    						FROM INP1002 Z							");
		sql.append("	    						WHERE Z.HOSP_CODE = A.HOSP_CODE			");
		sql.append("	    							AND Z.FKINP1001 = A.FKINP1001	    ");
		sql.append("	    							AND Z.GUBUN_TRANS_YN = 'N' )	    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", pkinp1001);
		
		@SuppressWarnings("unchecked")
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<INP1001U01LoadBoheomChildListInfo> getINP1001U01LoadBoheomChildListInfo(String hospCode,
			String language, Double fkinp1001) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.PKINP1002																						");
		sql.append("	      , IFNULL(A.GUBUN, '')																				");
		sql.append("	      , IFNULL(FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.GUBUN_IPWON_DATE, :f_hosp_code), '')					");
		sql.append("	      , IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.GUBUN_IPWON_DATE, :f_hosp_code, :f_language), '')	");
		sql.append("	 FROM INP1002 A																							");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code 																		");
		sql.append("	  AND A.FKINP1001 = :f_fkinp1001																		");
		sql.append("	ORDER BY A.GUBUN_IPWON_DATE DESC																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<INP1001U01LoadBoheomChildListInfo> lstResult = new JpaResultMapper().list(query, INP1001U01LoadBoheomChildListInfo.class);
		return lstResult;
	}
	
	@Override
	public List<INP1001U01ChangeGubunGrdHistoryInfo> getINP1001U01ChangeGubunGrdHistoryInfo(String hospCode, double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GUBUN																	");
		sql.append("	     , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.GUBUN_IPWON_DATE, A.HOSP_CODE)			");
		sql.append("	     , DATE_FORMAT(A.GUBUN_IPWON_DATE, '%Y/%m/%d')	AS gubunIpwonDate1			");
		sql.append("	     , A.PKINP1002																");
		sql.append("	     , DATE_FORMAT(A.GUBUN_IPWON_DATE, '%Y/%m/%d')	AS gubunIpwonDate2			");
		sql.append("	     , A.FKINP1001																");
		sql.append("	FROM INP1002 A																	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code												");
		sql.append("	  AND A.FKINP1001 = :f_fkinp1001												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<INP1001U01ChangeGubunGrdHistoryInfo> lstResult = new JpaResultMapper().list(query, INP1001U01ChangeGubunGrdHistoryInfo.class);
		return lstResult;
	}
	
	
	@Override
	public List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> getINPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo(
			String hospCode, String language, String bunho, String fromDate, String queryDate, String hoDong1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT AA.PKINP1001                                                 AS PKINP1001										                                          ");
		sql.append(" , AA.BUNHO                                                          AS BUNHO											                                          ");
		sql.append(" , F.SUNAME                                                          AS SUNAME	                                                                                  ");
		sql.append(" , F.SUNAME2                                                         AS SUNAME2	                                                                                  ");
		sql.append(" , AA.GWA                                                            AS GWA		                                                                                  ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(AA.GWA, CURRENT_DATE(), :f_hosp_code, :f_language)		                                                                                  ");
		sql.append(" 																	AS GWA_NAME	                                                                                  ");
		sql.append(" , SUBSTR(AA.DOCTOR, -5, 5)                                          AS DOCTOR	                                                                                  ");
		sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, CURRENT_DATE(), :f_hosp_code)  AS DOCTOR_NAME	                                                                              ");
		sql.append(" , AA.HO_DONG1                                                       AS HO_DONG1	                                                                              ");
		sql.append(" , FN_BAS_LOAD_GWA_NAME(AA.HO_DONG1, CURRENT_DATE(), :f_hosp_code, :f_language)                                                                                   ");
		sql.append(" 																	AS HO_DONG1_NAME                                                                              ");
		sql.append(" , AA.HO_CODE1                                                       AS HO_CODE1	                                                                              ");
		sql.append(" , AA.IPWON_DATE							                            AS IPWON_DATE                                                                             ");
		sql.append(" , IFNULL(AA.TOIWON_DATE, AA.TOIWON_RES_DATE)    					AS TOIWON_RES_DATE                                                                            ");
		sql.append(" , IFNULL(											                                                                                                              ");
		sql.append("   (SELECT 'Y' 										                                                                                                              ");
		sql.append("      FROM DUAL										                                                                                                              ");
		sql.append("     WHERE EXISTS (									                                                                                                              ");
		sql.append("                    SELECT 'Y'						                                                                                                              ");
		sql.append("                      FROM OCS2003      A			                                                                                                              ");
		sql.append("                      JOIN OCS0103      B   ON B.HOSP_CODE                     = A.HOSP_CODE	                                                                  ");
		sql.append(" 										  AND B.HANGMOG_CODE                  = A.HANGMOG_CODE	                                                                  ");
		sql.append(" 										  AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)                                                         ");
		sql.append(" 																				   FROM OCS0103 Z		                                                          ");
		sql.append(" 																				  WHERE Z.HOSP_CODE       = A.HOSP_CODE                                           ");
		sql.append(" 																					AND Z.HANGMOG_CODE    = A.HANGMOG_CODE                                        ");
		sql.append(" 																					AND Z.START_DATE      <= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                 ");
		sql.append(" 																					AND (   Z.END_DATE    IS NULL									              ");
		sql.append(" 																						 OR Z.END_DATE    >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)	              ");
		sql.append(" 																						)	                                                                      ");
		sql.append(" 																				)			                                                                      ");
		sql.append(" 										  AND (   B.END_DATE                  IS NULL		                                                                      ");
		sql.append(" 											   OR B.END_DATE                  >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                             ");
		sql.append(" 											  )												                                                                      ");
		sql.append("                      JOIN BAS0310      E   ON E.HOSP_CODE                    = A.HOSP_CODE	                                                                      ");
		sql.append(" 										  AND E.SG_CODE                      = A.SG_CODE	                                                                      ");
		sql.append(" 										  AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)                                                              ");
		sql.append(" 																				  FROM BAS0310 Z	                                                              ");
		sql.append(" 																				 WHERE Z.HOSP_CODE       = A.HOSP_CODE	                                          ");
		sql.append(" 																				   AND Z.SG_CODE         = A.SG_CODE	                                          ");
		sql.append(" 																				   AND Z.SG_YMD          <= IFNULL( A.ACTING_DATE, A.ORDER_DATE)	              ");
		sql.append(" 																				   AND (   Z.BULYONG_YMD IS NULL									              ");
		sql.append(" 																						OR Z.BULYONG_YMD >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)	              ");
		sql.append(" 																					   )	                                                                      ");
		sql.append(" 																			   )			                                                                      ");
		sql.append(" 										  AND (   E.BULYONG_YMD              IS NULL									                                          ");
		sql.append(" 											   OR E.BULYONG_YMD              >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)	                                          ");
		sql.append(" 											  )																													  ");
		sql.append("                      LEFT JOIN (SELECT  Z.HOSP_CODE              AS HOSP_CODE																					  ");
		sql.append("                                  , Z.FKOCS2003              AS FKOCS2003                                                                                         ");
		sql.append("                                  , Z.ACT_RES_DATE           AS ACT_RES_DATE                                                                                      ");
		sql.append("                                  , Z.IF_DATA_SEND_YN        AS IF_DATA_SEND_YN                                                                                   ");
		sql.append("                                  , (SELECT COUNT(1)	                                                                                                          ");
		sql.append("                                       FROM OCS2017 Y	                                                                                                          ");
		sql.append("                                      WHERE Y.HOSP_CODE      = Z.HOSP_CODE                                                                                        ");
		sql.append("                                        AND Y.FKOCS2003      = Z.FKOCS2003                                                                                        ");
		sql.append("                                        AND Y.ACT_RES_DATE   = Z.ACT_RES_DATE                                                                                     ");
		sql.append("                                        AND Y.PASS_DATE      IS NOT NULL) CNT                                                                                     ");
		sql.append("                               FROM OCS2017 Z                                                                                                                     ");
		sql.append("                                  , OCS2003 X                                                                                                                     ");
		sql.append("                              WHERE X.HOSP_CODE              = :f_hosp_code                                                                                       ");
		sql.append("                                AND X.BUNHO                  LIKE IF(:f_bunho IS NULL OR :f_bunho = '', '%', :f_bunho)                                            ");
		sql.append("                                AND Z.HOSP_CODE              = X.HOSP_CODE                                                                                        ");
		sql.append("                                AND Z.FKOCS2003              = X.PKOCS2003                                                                                        ");
		sql.append("                                AND Z.ACT_RES_DATE           BETWEEN :f_from_date                                                                                 ");
		sql.append("                                                                 AND :f_query_date                                                                                ");
		sql.append("                              GROUP BY Z.HOSP_CODE		                                                                                                          ");
		sql.append("                                     , Z.FKOCS2003		                                                                                                          ");
		sql.append("                                     , Z.ACT_RES_DATE	                                                                                                          ");
		sql.append("                                     , Z.IF_DATA_SEND_YN                                                                                                          ");
		sql.append("                              ORDER BY Z.ACT_RES_DATE		                                                                                                      ");
		sql.append("                            ) ZZ ON ZZ.HOSP_CODE		= A.HOSP_CODE                                                                                             ");
		sql.append(" 							   AND ZZ.FKOCS2003     = A.PKOCS2003	                                                                                              ");
		sql.append(" 							   AND ZZ.CNT           = A.DV			                                                                                              ");
		sql.append("                     WHERE A.HOSP_CODE                     = AA.HOSP_CODE	                                                                                      ");
		sql.append("                       AND A.BUNHO                         = AA.BUNHO		                                                                                      ");
		sql.append("                       AND A.FKINP1001                     = AA.PKINP1001 	                                                                                      ");
		sql.append("                       AND  (												                                                                                      ");
		sql.append("                               B.ORDER_GUBUN                      IN ('B', 'C')                                                                                   ");
		sql.append("                               AND IFNULL(A.TOIWON_DRG_YN,'N')       = 'N'	                                                                                      ");
		sql.append("                               AND (										                                                                                      ");
		sql.append("                                        A.JUNDAL_PART NOT IN ('HOM')		                                                                                      ");
		sql.append("                                    AND IFNULL(ZZ.IF_DATA_SEND_YN, 'N')   = 'N')                                                                                  ");
		sql.append("                               OR (												                                                                                  ");
		sql.append("                                        A.JUNDAL_PART IN ('HOM')				                                                                                  ");
		sql.append("                                    AND IFNULL(A.IF_DATA_SEND_YN, 'N') = 'N')                                                                                     ");
		sql.append("                             OR 																														          ");
		sql.append("                                 ( B.ORDER_GUBUN                  IN ('B', 'C', 'D') 	                                                                          ");
		sql.append("                                   AND IFNULL(A.TOIWON_DRG_YN,'N')   <> 'N'				                                                                          ");
		sql.append("                                   AND IFNULL(A.IF_DATA_SEND_YN, 'N') = 'N'				                                                                          ");
		sql.append("                                 ) OR													                                                                          ");
		sql.append("                                 B.ORDER_GUBUN                   NOT IN ('B', 'C') 		                                                                          ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N')    = 'N'				                                                                          ");
		sql.append("                                 AND IFNULL(A.IF_DATA_SEND_YN, 'N') = 'N'				                                                                          ");
		sql.append("                             )															                                                                          ");
		sql.append("                       AND  ( 															                                                                          ");
		sql.append("                              (															                                                                          ");
		sql.append("                                 B.ORDER_GUBUN IN ('B', 'C')							                                                                          ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N' 					                                                                          ");
		sql.append("                                 AND (													                                                                          ");
		sql.append("                                          A.JUNDAL_PART NOT IN ('HOM')					                                                                          ");
		sql.append("                                      AND ZZ.ACT_RES_DATE BETWEEN :f_from_date			                                                                          ");
		sql.append("                                                         AND :f_query_date)				                                                                          ");
		sql.append("                                 OR(													                                                                          ");
		sql.append("                                   A.JUNDAL_PART IN ('HOM')								                                                                          ");
		sql.append("                                   AND A.ACTING_DATE                   IS NULL			                                                                          ");
		sql.append("                                   AND (   1=2											                                                                          ");
		sql.append("                                        OR A.RESER_DATE                BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR A.HOPE_DATE                 BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR (    A.HOPE_DATE            IS NULL				                                                                      ");
		sql.append("                                            AND A.RESER_DATE           IS NULL				                                                                      ");
		sql.append("                                            AND A.ORDER_DATE           BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                            )	                                                                                                                  ");
		sql.append("                                        )		                                                                                                                  ");
		sql.append("                                 )				                                                                                                                  ");
		sql.append("                               )				                                                                                                                  ");
		sql.append("                           OR (  				                                                                                                                  ");
		sql.append("                                 ( B.ORDER_GUBUN                 IN ('B', 'C', 'D')                                                                               ");
		sql.append("                                   AND IFNULL(A.TOIWON_DRG_YN,'N')  <> 'N'					                                                                      ");
		sql.append("                                   AND A.ACTING_DATE                   BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                   AND (   1=2												                                                                      ");
		sql.append("                                        OR A.RESER_DATE                BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR A.HOPE_DATE                 BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR (    A.HOPE_DATE            IS NULL				                                                                      ");
		sql.append("                                            AND A.RESER_DATE           IS NULL				                                                                      ");
		sql.append("                                            AND A.ORDER_DATE           BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                            )	                                                                                                                  ");
		sql.append("                                        )		                                                                                                                  ");
		sql.append("                                 ) OR			                                                                                                                  ");
		sql.append("                                     B.ORDER_GUBUN                   NOT IN ('B', 'C') 	                                                                          ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N')        = 'N'			                                                                          ");
		sql.append("                                 AND A.ACTING_DATE                   BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                 AND (   1=2												                                                                      ");
		sql.append("                                      OR A.RESER_DATE                BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                         AND :f_query_date	                                                                      ");
		sql.append("                                      OR A.HOPE_DATE                 BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                         AND :f_query_date	                                                                      ");
		sql.append("                                      OR (    A.HOPE_DATE            IS NULL				                                                                      ");
		sql.append("                                          AND A.RESER_DATE           IS NULL				                                                                      ");
		sql.append("                                          AND A.ORDER_DATE           BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                         AND :f_query_date	                                                                      ");
		sql.append("                                          )																														  ");
		sql.append("                                      )	                                                                                                                          ");
		sql.append("                               )		                                                                                                                          ");
		sql.append("                            )			                                                                                                                          ");
		sql.append("                       AND A.NALSU                         >= 0                                                                                                   ");
		sql.append("                       AND IFNULL(A.DC_YN,'N')                = 'N'                                                                                               ");
		sql.append("                       AND IFNULL(A.MUHYO,'N')                = 'N'                                                                                               ");
		sql.append("                  )												                                                                                                  ");
		sql.append("   ), 'N'    													                                                                                                  ");
		sql.append(" )                                                                 AS TRANS_ORD_YN                                                                                ");
		sql.append(" , IFNULL(																			                                                                              ");
		sql.append("   (SELECT 'Y' 																		                                                                              ");
		sql.append("      FROM DUAL																		                                                                              ");
		sql.append("     WHERE EXISTS (				                                                                                                                                  ");
		sql.append("                    SELECT 'Y'	                                                                                                                                  ");
		sql.append("                      FROM OCS2003      A                                                                                                                         ");
		sql.append("                      JOIN OCS0103      B   ON B.HOSP_CODE                     = A.HOSP_CODE	                                                                  ");
		sql.append(" 										  AND B.HANGMOG_CODE                  = A.HANGMOG_CODE	                                                                  ");
		sql.append(" 										  AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)                                                         ");
		sql.append(" 																				   FROM OCS0103 Z		                                                          ");
		sql.append(" 																				  WHERE Z.HOSP_CODE       = B.HOSP_CODE		                                      ");
		sql.append(" 																					AND Z.HANGMOG_CODE    = B.HANGMOG_CODE	                                      ");
		sql.append(" 																					AND Z.START_DATE      <= A.ORDER_DATE	                                      ");
		sql.append(" 																					AND (   Z.END_DATE    IS NULL			                                      ");
		sql.append(" 																						 OR Z.END_DATE    >= A.ORDER_DATE	                                      ");
		sql.append(" 																						)	                                                                      ");
		sql.append(" 																				)			                                                                      ");
		sql.append("                      JOIN BAS0310      E   ON E.HOSP_CODE                    = A.HOSP_CODE	                                                                      ");
		sql.append(" 										  AND E.SG_CODE                      = A.SG_CODE	                                                                      ");
		sql.append(" 										  AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)                                                              ");
		sql.append(" 																				  FROM BAS0310 Z	                                                              ");
		sql.append(" 																				 WHERE Z.HOSP_CODE       = E.HOSP_CODE	                                          ");
		sql.append(" 																				   AND Z.SG_CODE         = E.SG_CODE	                                          ");
		sql.append(" 																				   AND Z.SG_YMD          <= A.ORDER_DATE                                          ");
		sql.append(" 																				   AND (   Z.BULYONG_YMD IS NULL		                                          ");
		sql.append(" 																						OR Z.BULYONG_YMD >= A.ORDER_DATE                                          ");
		sql.append(" 																					   )	                                                                      ");
		sql.append(" 																			   )			                                                                      ");
		sql.append(" 										  AND (   E.BULYONG_YMD              IS NULL		                                                                      ");
		sql.append(" 											   OR E.BULYONG_YMD              >= A.ORDER_DATE                                                                      ");
		sql.append(" 											  )												                                                                      ");
		sql.append("                      LEFT JOIN (SELECT X.*													                                                                      ");
		sql.append("                              FROM OCS2017 X												                                                                      ");
		sql.append("                             WHERE X.HOSP_CODE     = :f_hosp_code							                                                                      ");
		sql.append("                               AND X.ACT_RES_DATE  BETWEEN :f_from_date						                                                                      ");
		sql.append("                                                       AND :f_query_date					                                                                      ");
		sql.append("                           ) ZZ ON ZZ.HOSP_CODE	= A.HOSP_CODE	                                                                                                  ");
		sql.append(" 							  AND ZZ.FKOCS2003  = A.PKOCS2003	                                                                                                  ");
		sql.append("                     WHERE A.HOSP_CODE                     = AA.HOSP_CODE                                                                                         ");
		sql.append("                       AND A.BUNHO                         = AA.BUNHO	                                                                                          ");
		sql.append("                       AND A.FKINP1001                     = AA.PKINP1001                                                                                         ");
		sql.append("                       AND  (													                                                                                  ");
		sql.append("                               B.ORDER_GUBUN                      IN ('B', 'C')                                                                                   ");
		sql.append("                               AND IFNULL(A.TOIWON_DRG_YN,'N')       = 'N'		                                                                                  ");
		sql.append("                               AND IFNULL(ZZ.IF_DATA_SEND_YN, 'N')   = 'N'		                                                                                  ");
		sql.append("                             OR 												                                                                                  ");
		sql.append("                                 ( B.ORDER_GUBUN                  IN ('B', 'C', 'D')                                                                              ");
		sql.append("                                   AND IFNULL(A.TOIWON_DRG_YN,'N')   <> 'N'	                                                                                      ");
		sql.append("                                   AND IFNULL(A.IF_DATA_SEND_YN, 'N') = 'N'	                                                                                      ");
		sql.append("                                 ) OR										                                                                                      ");
		sql.append("                                 B.ORDER_GUBUN                   NOT IN ('B', 'C')                                                                                ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N')    = 'N'			                                                                              ");
		sql.append("                                 AND IFNULL(A.IF_DATA_SEND_YN, 'N') = 'N'			                                                                              ");
		sql.append("                             )														                                                                              ");
		sql.append("                       AND  ( 	                                                                                                                                  ");
		sql.append("                              (	                                                                                                                                  ");
		sql.append("                                 B.ORDER_GUBUN IN ('B', 'C')                                                                                                      ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N') = 'N'                                                                                            ");
		sql.append("                                 AND ZZ.PASS_DATE IS NULL					                                                                                      ");
		sql.append("                                 AND ZZ.ACT_RES_DATE BETWEEN :f_from_date	                                                                                      ");
		sql.append("                                                         AND :f_query_date	                                                                                      ");
		sql.append("                               )											                                                                                      ");
		sql.append("                           OR (  											                                                                                      ");
		sql.append("                                 ( B.ORDER_GUBUN                 IN ('B', 'C', 'D')                                                                               ");
		sql.append("                                   AND IFNULL(A.TOIWON_DRG_YN,'N')  <> 'N'		                                                                                  ");
		sql.append("                                   AND A.ACTING_DATE                   IS NULL	                                                                                  ");
		sql.append("                                   AND (   1=2									                                                                                  ");
		sql.append("                                        OR A.RESER_DATE                BETWEEN :f_from_date                                                                       ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR A.HOPE_DATE                 BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                        OR (    A.HOPE_DATE            IS NULL	                                                                                  ");
		sql.append("                                            AND A.RESER_DATE           IS NULL	                                                                                  ");
		sql.append("                                            AND A.ORDER_DATE           BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                           AND :f_query_date                                                                      ");
		sql.append("                                            )												                                                                      ");
		sql.append("                                        )													                                                                      ");
		sql.append("                                 ) OR														                                                                      ");
		sql.append("                                     B.ORDER_GUBUN                   NOT IN ('B', 'C') 		                                                                      ");
		sql.append("                                 AND IFNULL(A.TOIWON_DRG_YN,'N')        = 'N'				                                                                      ");
		sql.append("                                 AND A.ACTING_DATE                   IS NULL				                                                                      ");
		sql.append("                                 AND (   1=2												                                                                      ");
		sql.append("                                      OR A.RESER_DATE                BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                         AND :f_query_date	                                                                      ");
		sql.append("                                      OR A.HOPE_DATE                 BETWEEN :f_from_date	                                                                      ");
		sql.append("                                                                         AND :f_query_date	                                                                      ");
		sql.append("                                      OR (    A.HOPE_DATE            IS NULL                                                                                      ");
		sql.append("                                          AND A.RESER_DATE           IS NULL                                                                                      ");
		sql.append("                                          AND A.ORDER_DATE           BETWEEN :f_from_date                                                                         ");
		sql.append("                                                                         AND :f_query_date                                                                        ");
		sql.append("                                          )	                                                                                                                      ");
		sql.append("                                      )		                                                                                                                      ");
		sql.append("                               )			                                                                                                                      ");
		sql.append("                            )				                                                                                                                      ");
		sql.append("                       AND A.JUNDAL_PART                   NOT IN ('HOM')                                                                                         ");
		sql.append("                       AND A.NALSU                         >= 0		                                                                                              ");
		sql.append("                       AND IFNULL(A.DC_YN,'N')                = 'N'	                                                                                              ");
		sql.append("                       AND IFNULL(A.MUHYO,'N')                = 'N'	                                                                                              ");
		sql.append(" 					  												                                                                                              ");
		sql.append("                       AND (   B.END_DATE                  IS NULL	                                                                                              ");
		sql.append("                            OR B.END_DATE                  >= A.ORDER_DATE                                                                                        ");
		sql.append("                           )	                                                                                                                                  ");
		sql.append("                  )				                                                                                                                                  ");
		sql.append("   ), 'N'    					                                                                                                                                  ");
		sql.append(" )                                                                 AS ACT_ORD_YN                                                                                  ");
		sql.append(" , (								                                                                                                                              ");
		sql.append(" 	SELECT MAX(A.IF_DATA_SEND_DATE)	                                                                                                                              ");
		sql.append(" 	 FROM OCS2003      A                                                                                                                                          ");
		sql.append(" 		, OCS0103      B                                                                                                                                          ");
		sql.append(" 		, BAS0310      E                                                                                                                                          ");
		sql.append(" 	WHERE A.HOSP_CODE                     = AA.HOSP_CODE                                                                                                          ");
		sql.append(" 	  AND A.BUNHO                         = AA.BUNHO	                                                                                                          ");
		sql.append(" 	  AND A.FKINP1001                     = AA.PKINP1001                                                                                                          ");
		sql.append(" 	  AND IFNULL(A.IF_DATA_SEND_YN, 'N')  = 'Y'					                                                                                                  ");
		sql.append(" 	  AND (   (   A.ACTING_DATE           BETWEEN :f_from_date	                                                                                                  ");
		sql.append(" 											  AND :f_query_date	                                                                                                  ");
		sql.append(" 			  )													                                                                                                  ");
		sql.append(" 		   OR (    A.ACTING_DATE          IS NULL				                                                                                                  ");
		sql.append(" 			   AND A.ORDER_DATE           BETWEEN :f_from_date	                                                                                                  ");
		sql.append(" 											  AND :f_query_date	                                                                                                  ");
		sql.append(" 			  )													                                                                                                  ");
		sql.append(" 		  )                                    					                                                                                                  ");
		sql.append(" 	  AND A.NALSU                         >= 0		                                                                                                              ");
		sql.append(" 	  AND IFNULL(A.DC_YN,'N')                = 'N'	                                                                                                              ");
		sql.append(" 	  AND IFNULL(A.MUHYO,'N')                = 'N'	                                                                                                              ");
		sql.append(" 	  AND B.HOSP_CODE                     = A.HOSP_CODE		                                                                                                      ");
		sql.append(" 	  AND B.HANGMOG_CODE                  = A.HANGMOG_CODE	                                                                                                      ");
		sql.append(" 	  AND B.START_DATE                    = (SELECT MAX(Z.START_DATE)                                                                                             ");
		sql.append(" 											   FROM OCS0103 Z		                                                                                              ");
		sql.append(" 											  WHERE Z.HOSP_CODE       = B.HOSP_CODE                                                                               ");
		sql.append(" 												AND Z.HANGMOG_CODE    = B.HANGMOG_CODE                                                                            ");
		sql.append(" 												AND Z.START_DATE      <= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                                     ");
		sql.append(" 												AND (   Z.END_DATE    IS NULL									                                                  ");
		sql.append(" 													 OR Z.END_DATE    >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)	                                                  ");
		sql.append(" 													)	                                                                                                          ");
		sql.append(" 											)			                                                                                                          ");
		sql.append(" 	  AND (   B.END_DATE                  IS NULL		                                                                                                          ");
		sql.append(" 		   OR B.END_DATE                  >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                                                                 ");
		sql.append(" 		  )														                                                                                                  ");
		sql.append(" 	  AND E.HOSP_CODE                    = A.HOSP_CODE			                                                                                                  ");
		sql.append(" 	  AND E.SG_CODE                      = A.SG_CODE			                                                                                                  ");
		sql.append(" 	  AND E.SG_YMD                       = (SELECT MAX(Z.SG_YMD)                                                                                                  ");
		sql.append(" 											  FROM BAS0310 Z	                                                                                                  ");
		sql.append(" 											 WHERE Z.HOSP_CODE       = E.HOSP_CODE                                                                                ");
		sql.append(" 											   AND Z.SG_CODE         = E.SG_CODE							                                                      ");
		sql.append(" 											   AND Z.SG_YMD          <= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                                      ");
		sql.append(" 											   AND (   Z.BULYONG_YMD IS NULL								                                                      ");
		sql.append(" 													OR Z.BULYONG_YMD >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                                      ");
		sql.append(" 												   )	                                                                                                          ");
		sql.append(" 										   )			                                                                                                          ");
		sql.append(" 	  AND (   E.BULYONG_YMD              IS NULL		                                                                                                          ");
		sql.append(" 		   OR E.BULYONG_YMD              >= IFNULL( A.ACTING_DATE, A.ORDER_DATE)                                                                                  ");
		sql.append(" 		  )																				                                                                          ");
		sql.append(" )																		AS TRANS_DATE	                                                                          ");
		sql.append(" , IFNULL(AA.TOIWON_GOJI_YN, 'N')                                        AS INP_FLAG	                                                                          ");
		sql.append(" FROM VW_OCS_INP1001_01     AA															                                                                          ");
		sql.append(" , INP1002               AB																                                                                          ");
		sql.append(" , OUT0101               F 																                                                                          ");
		sql.append(" , (select @kcck_hosp_code \\:= :f_hosp_code) TMP		                                                                                                          ");
		sql.append(" WHERE AA.HOSP_CODE                   = :f_hosp_code	                                                                                                          ");
		sql.append(" AND AA.BUNHO                       LIKE IF(:f_bunho IS NULL OR :f_bunho = '', '%', :f_bunho)                                                                     ");
		sql.append(" AND AA.HO_DONG1                    LIKE :f_ho_dong1	                                                                                                          ");
		sql.append(" AND AA.IPWON_DATE                  <= :f_query_date	                                                                                                          ");
		sql.append(" AND (   AA.TOIWON_DATE             IS NULL				                                                                                                          ");
		sql.append(" OR AA.TOIWON_DATE                 > :f_query_date		                                                                                                          ");
		sql.append("   )													                                                                                                          ");
		sql.append(" AND AB.HOSP_CODE                   = AA.HOSP_CODE		                                                                                                          ");
		sql.append(" AND AB.BUNHO                       = AA.BUNHO			                                                                                                          ");
		sql.append(" AND AB.FKINP1001                   = AA.PKINP1001 		                                                                                                          ");
		sql.append(" AND AB.GUBUN_IPWON_DATE            <= :f_query_date	                                                                                                          ");
		sql.append(" AND (   AB.GUBUN_TOIWON_DATE       IS NULL				                                                                                                          ");
		sql.append(" OR AB.GUBUN_TOIWON_DATE           >= :f_query_date		                                                                                                          ");
		sql.append("  )																                                                                                                  ");
		sql.append(" AND AB.PKINP1002                   = ( SELECT MAX(Z.PKINP1002)	                                                                                                  ");
		sql.append("                                  FROM INP1002                  Z                                                                                                 ");
		sql.append("                                 WHERE Z.HOSP_CODE              = AB.HOSP_CODE                                                                                    ");
		sql.append("                                   AND Z.FKINP1001              = AB.FKINP1001                                                                                    ");
		sql.append("                                   AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE                                                                             ");
		sql.append("                                   AND (   Z.GUBUN_TOIWON_DATE  IS NULL			                                                                                  ");
		sql.append("                                        OR Z.GUBUN_TOIWON_DATE  >= :f_query_date                                                                                  ");
		sql.append("                                        )										                                                                                  ");
		sql.append("                                      )  										                                                                                  ");
		sql.append(" AND F.HOSP_CODE                   = AA.HOSP_CODE								                                                                                  ");
		sql.append(" AND F.BUNHO                       = AA.BUNHO									                                                                                  ");
		sql.append(" ORDER BY AA.HOSP_CODE                                                      	                                                                                  ");
		sql.append("   , INP_FLAG                      DESC                                                                                                                           ");
		sql.append("   , AA.HO_DONG1																                                                                                  ");
		sql.append("   , AA.HO_CODE1																                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_query_date", DateUtil.toDate(queryDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_ho_dong1", hoDong1);
		                                                                        
		List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> list = new JpaResultMapper().list(query, INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.class);
		return list;
	}


	@Override
	public List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> getINPBATCHTRANSgrdInpListQueryStartingrbnTransInfo(
			String hospCode, String language, String bunho, String fromDate, String queryDate, String hoDong1) {
StringBuilder sql = new StringBuilder();
		
			sql.append(" SELECT A.PKINP1001																								");
			sql.append(" , A.BUNHO																										");
			sql.append(" , B.SUNAME																										");
			sql.append(" , B.SUNAME2																									");
			sql.append(" , A.GWA                                                                                       GWA				");
			sql.append(" , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE(), :f_hosp_code, :f_language)                            GWA_NAME			");
			sql.append(" , A.DOCTOR                                                                                    DOCTOR			");
			sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,SYSDATE(), :f_hosp_code)                                   DOCTOR_NAME		");
			sql.append(" , A.HO_DONG1                                                                                  HO_DONG1			");
			sql.append(" , FN_BAS_LOAD_GWA_NAME(A.HO_DONG1,SYSDATE(), :f_hosp_code, :f_language)                       HO_DONG1_NAME	");
			sql.append(" , A.HO_CODE1                                                                                  HO_CODE1			");
			sql.append(" , DATE_FORMAT(A.IPWON_DATE,'%Y/%m/%d')                                                        IPWON_DATE		");
			sql.append(" , DATE_FORMAT(IFNULL(A.TOIWON_DATE,A.TOIWON_RES_DATE),'%Y/%m/%d')                             TOIWON_RES_DATE	");
			sql.append(" , (SELECT DISTINCT 'Y'																							");
			sql.append("   FROM OCS2003 C																								");
			sql.append("   WHERE C.HOSP_CODE = :f_hosp_code																				");
			sql.append("   AND C.FKINP1001 = A.PKINP1001																				");
			sql.append("   AND C.BUNHO     = A.BUNHO																					");
			sql.append("   AND IFNULL(C.RESER_DATE,C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date									");
			sql.append("   AND (C.JUNDAL_TABLE = 'HOM'																					");
			sql.append("   OR (C.JUNDAL_TABLE <> 'HOM' AND C.OCS_FLAG  = '3')  															");
			sql.append(" )																												");
			sql.append("   AND IFNULL(C.IF_DATA_SEND_YN,'N') = 'N'  																	");
			sql.append("   AND C.IF_DATA_SEND_DATE IS NULL        																		");
			sql.append("   AND C.SG_CODE   IS NOT NULL           																		");
			sql.append(" )                                                                                             TRANS_ORD_YN		");
			sql.append(" , (SELECT DISTINCT 'Y'																							");
			sql.append("   FROM OCS2003 C																								");
			sql.append("   WHERE C.HOSP_CODE = :f_hosp_code																				");
			sql.append("   AND C.FKINP1001 = A.PKINP1001																				");
			sql.append("   AND C.BUNHO     = A.BUNHO																					");
			sql.append("   AND IFNULL(C.RESER_DATE,C.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date									");
			sql.append("   AND C.OCS_FLAG  IN('1','2')    																				");
			sql.append("   AND C.SG_CODE   IS NOT NULL    																				");
			sql.append("   AND C.JUNDAL_TABLE <> 'HOM')                                                                ACT_END_YN		");
			sql.append(" , (SELECT MAX(C.IF_DATA_SEND_DATE)																				");
			sql.append("   FROM OCS2003 C																								");
			sql.append("   WHERE C.HOSP_CODE = :f_hosp_code																				");
			sql.append("   AND C.FKINP1001 = A.PKINP1001																				");
			sql.append("   AND C.BUNHO     = A.BUNHO)                                                                  TRANS_DATE		");
			sql.append(" , IFNULL(A.TOIWON_GOJI_YN,'N')                                                                INP_FLAG			");
			sql.append("FROM VW_OCS_INP1001_01          A, OUT0101 B, OCS2003 D															");
			sql.append("WHERE :f_query_date BETWEEN A.IPWON_DATE AND IFNULL(A.TOIWON_DATE,STR_TO_DATE('99981231','%Y%m%d'))				");
			sql.append("AND IFNULL(A.HO_DONG1,'%')       LIKE :f_ho_dong1																");
			sql.append("AND A.BUNHO                    LIKE IFNULL(:f_bunho,'%')														");
			sql.append("AND B.HOSP_CODE                = :f_hosp_code																	");
			sql.append("AND B.BUNHO                    = A.BUNHO																		");
			sql.append("AND D.FKINP1001                = A.PKINP1001																	");
			sql.append("AND D.BUNHO                    = A.BUNHO																		");
			sql.append("AND IFNULL(D.RESER_DATE,D.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date									");
			sql.append("AND IFNULL(D.IF_DATA_SEND_YN,'N') = 'Y'																			");
			sql.append("AND D.IF_DATA_SEND_DATE IS NOT NULL																				");
			sql.append("AND D.PKOCS2003 =(SELECT MAX(E.PKOCS2003)																		");
			sql.append("   FROM OCS2003 E																								");
			sql.append("   WHERE E.HOSP_CODE                 = :f_hosp_code																");
			sql.append("   AND E.FKINP1001                 = A.PKINP1001																");
			sql.append("   AND E.BUNHO                     = A.BUNHO																	");
			sql.append("   AND IFNULL(E.RESER_DATE,E.ORDER_DATE) BETWEEN :f_from_date AND :f_query_date									");
			sql.append("   AND IFNULL(E.IF_DATA_SEND_YN,'N') = 'Y'																		");
			sql.append("   AND E.IF_DATA_SEND_DATE IS NOT NULL)																			");
			sql.append("ORDER BY INP_FLAG DESC,A.HO_DONG1,A.HO_CODE1,A.BED_NO,A.PKINP1001												");
			
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_query_date", DateUtil.toDate(queryDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_ho_dong1", hoDong1);
		                                                                        
		List<INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo> list = new JpaResultMapper().list(query, INPBATCHTRANSgrdInpListQueryStartingrbnMiTransInfo.class);
		return list;
	}

	@Override
	public Double getMaxGubunTransCnt(String hospCode, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(A.GUBUN_TRANS_CNT), 0) + 1	");
		sql.append("			  FROM INP1002 A						");
		sql.append("			 WHERE A.HOSP_CODE = :f_hosp_code		");
		sql.append("			   AND A.FKINP1001 = :f_fkinp1001		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkinp1001", CommonUtils.parseDouble(fkinp1001));
		
		@SuppressWarnings("unchecked")
		List<Double> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public Integer iNP1001U01ChangeGubunUpdateInp1002(String userId, String gubunipwonDate, String hospCode, Double fkinp1001, Double gubunTransCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE INP1002 set UPD_DATE = SYSDATE() 														");
		sql.append("	, UPD_ID   = :f_user_id     																	");
		sql.append("	, GUBUN_TOIWON_DATE = DATE_ADD(DATE_FORMAT(:f_gubun_ipwon_date, '%Y/%m/%d'), INTERVAL -1 DAY)	");
		sql.append("	, GUBUN_TRANS_YN   =  'Y'     																	");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code 																	");
		sql.append("	AND  FKINP1001 = :f_fkinp1001 																	");
		sql.append("	AND GUBUN_TRANS_CNT = :f_gubun_trans_cnt 														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_gubun_ipwon_date", gubunipwonDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_gubun_trans_cnt", gubunTransCnt);
		
		return query.executeUpdate();
	}
	
	@Override
	public CommonProcResultInfo callPrInpMakePkinp1002(Double fkinp1001, String gubun, String hospCode){
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_MAKE_PKINP1002");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_PKINP1002", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_SEQ", Double.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_GUBUN", gubun);
		
		query.execute();
		
		CommonProcResultInfo result = new CommonProcResultInfo();
		result.setStrResult1((String)query.getOutputParameterValue("IO_PKINP1002"));
		result.setStrResult2((String)query.getOutputParameterValue("IO_SEQ"));
		result.setStrResult3((String)query.getOutputParameterValue("IO_ERR"));
		
		return result;
	}

}

