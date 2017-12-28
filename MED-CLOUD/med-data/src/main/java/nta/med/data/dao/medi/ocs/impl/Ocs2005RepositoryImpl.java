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
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2005RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00DupCheckInfo;
import nta.med.data.model.ihis.ocsi.OCS2004U00layAllOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2006Info;
import nta.med.data.model.ihis.ocsi.OCS2005U02SetTabInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02calSiksaDayClickInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS2005U02layVWOCSOCS2005NUTInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAlayOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAlayOCS2006Info;

/**
 * @author dainguyen.
 */
public class Ocs2005RepositoryImpl implements Ocs2005RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Ocs2005RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String callPrOcsCreateStopSiksa(String stopFromDate, String stopFromBld, String stopToDate, String stopToBld,
			String bunho, String hospCode, String fkinp1001, String updId, String commentGubun, String iudGubun,
			String ipwonDate) {
		String oFlag = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_CREATE_STOP_SIKSA ");
		query.registerStoredProcedureParameter("I_STOP_FROM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_FROM_BLD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_TO_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_STOP_TO_BLD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_COMMENT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);
		
		query.setParameter("I_STOP_FROM_DATE", DateUtil.toDate(stopFromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_STOP_FROM_BLD", stopFromBld);
		query.setParameter("I_STOP_TO_DATE", DateUtil.toDate(stopToDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_STOP_TO_BLD", stopToBld);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("I_UPD_ID", updId);
		query.setParameter("I_COMMENT_GUBUN", commentGubun);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_IPWON_DATE", ipwonDate);
		
		query.execute();
		oFlag = (String) query.getOutputParameterValue("O_FLAG");
		return oFlag;
	}
	
	@Override
	public List<OCS2005U02grdOCS2005Info> getOCS2005U02grdOCS2005Info(String hospCode, String jaewonYn, String bunho, Double fkinp1001, String blbGubun,
			Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT    A.BLD_GUBUN																	");
		sql.append("             , A.PKOCS2005																	");
		sql.append("             , A.BUNHO																		");
		sql.append("             , A.FKINP1001																	");
		sql.append("             , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')										");
		sql.append("             , A.INPUT_GUBUN																");
		sql.append("             , A.INPUT_ID																	");
		sql.append("             , CAST(A.PK_SEQ AS CHAR)														");
		sql.append("             , A.DIRECT_GUBUN																");
		sql.append("             , A.DIRECT_CODE																");
		sql.append("             , A.DIRECT_CODE_D																");
		sql.append("             , A.DIRECT_CONT1																");
		sql.append("             , A.DIRECT_CONT1_D																");
		sql.append("             , A.DIRECT_CONT2																");
		sql.append("             , A.DIRECT_CONT2_D																");
		sql.append("             , A.DIRECT_CONT3																");
		sql.append("             , A.DIRECT_CONT3_D																");
		sql.append("             , A.NOMIMONO																	");
		sql.append("             , IFNULL(A.KUMJISIK,'')														");
		sql.append("             , DATE_FORMAT(A.DRT_FROM_DATE,'%Y/%m/%d')										");
		sql.append("             , DATE_FORMAT(A.DRT_TO_DATE,'%Y/%m/%d')										");
		sql.append("             , A.CONTINUE_YN																");
		sql.append("             , ''																			");
		sql.append("       FROM OCS2005	A																		");
		sql.append("      WHERE (:f_jaewon_yn = 'Y' AND A.FKINP1001    = ( SELECT B.PKINP1001					");
		sql.append("                                                      FROM VW_OCS_INP1001_RES_01 B			");
		sql.append("                                                     WHERE B.BUNHO = :f_bunho				");
		sql.append("                                                   )										");
		sql.append("             OR :f_jaewon_yn = 'N' AND A.FKINP1001 = :f_fkinp1001)							");
		sql.append("        AND A.DIRECT_GUBUN = '03'															");
		sql.append("        AND A.FKOCS6015 IS NULL																");
		sql.append("        AND A.BLD_GUBUN    = :f_bld_gubun													");
		sql.append("        AND A.HOSP_CODE    = :f_hosp_code													");
		sql.append("      ORDER BY A.DRT_FROM_DATE																");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jaewon_yn", jaewonYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_bld_gubun", blbGubun);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U02grdOCS2005Info> result = new JpaResultMapper().list(query, OCS2005U02grdOCS2005Info.class);
		return result;

	}
	
	@Override
	public List<OCS2005U02layVWOCSOCS2005NUTInfo> getOCS2005U02layVWOCSOCS2005NUTInfo(String hospCode, String bunho, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DATE_FORMAT(A.NUT_DATE, '%Y/%m/%d')                     NUT_DATE													");
		sql.append("          , A.BLD_GUBUN                              BLD_GUBUN																	");
		sql.append("          , RPAD(IFNULL(A.SIK_GUBUN_NAME_S, A.SIK_GUBUN_NAME), 8, ' ') SIK_GUBUN												");
		sql.append("          , RPAD(IFNULL(A.SIK_JONG_NAME_S,  A.SIK_JONG_NAME),  8, ' ') SIKJONG													");
		sql.append("          , RPAD(IFNULL(A.SIK_JUSIK_NAME_S, A.SIK_JUSIK_NAME), 8, ' ') JUSIK													");
		sql.append("          , RPAD(IFNULL(A.SIK_BUSIK_NAME_S, A.SIK_BUSIK_NAME), 8, ' ') BUSIK													");
		sql.append("          , IFNULL(A.SIK_NOMIMONO_NAME_S,   IFNULL(A.SIK_NOMIMONO_NAME,''))       NOMIMONO										");
		sql.append("          , CAST(A.FKINP1001 AS CHAR)																							");
		sql.append("       FROM (																													");
		sql.append("       SELECT  B.HOSP_CODE,																										");
		sql.append("               B.PKOCS2005,																										");
		sql.append("               B.BUNHO,																											");
		sql.append("               B.FKINP1001,																										");
		sql.append("               A.IPWON_DATE,																									");
		sql.append("               A.TOIWON_DATE,																									");
		sql.append("               B.ORDER_DATE,																									");
		sql.append("               B.INPUT_GUBUN,																									");
		sql.append("               B.INPUT_ID,																										");
		sql.append("               B.PK_SEQ,																										");
		sql.append("               B.DIRECT_GUBUN,																									");
		sql.append("               B.DRT_FROM_DATE,																									");
		sql.append("               B.DRT_TO_DATE,																									");
		sql.append("               IFNULL(																											");
		sql.append("                  B.DRT_TO_DATE,																								");
		sql.append("                  (SELECT (DATE_ADD(MIN(Z.DRT_FROM_DATE), INTERVAL -1 DAY))														");
		sql.append("                   FROM OCS2005 Z																								");
		sql.append("                   WHERE Z.HOSP_CODE = B.HOSP_CODE																				");
		sql.append("                     AND Z.DIRECT_CODE = B.DIRECT_CODE																			");
		sql.append("                     AND Z.BUNHO = B.BUNHO																						");
		sql.append("                     AND Z.BLD_GUBUN = B.BLD_GUBUN																				");
		sql.append("                     AND Z.DRT_FROM_DATE > B.DRT_FROM_DATE))																	");
		sql.append("                  AS DRT_TO_DATE2,																								");
		sql.append("               B.CONTINUE_YN,																									");
		sql.append("               DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)  AS NUT_DATE,														");
		sql.append("               B.BLD_GUBUN,																										");
		sql.append("               (AA.ADD_DAY + 1)                                AS JAEWON_DAY,													");
		sql.append("               B.DIRECT_CODE,																									");
		sql.append("               B.DIRECT_CODE_D,																									");
		sql.append("               N0.NUR_SO_NAME                                  AS SIK_GUBUN_NAME,												");
		sql.append("               N0.MENT                                         AS SIK_GUBUN_NAME_S,												");
		sql.append("               B.DIRECT_CONT1,																									");
		sql.append("               B.DIRECT_CONT1_D,																								");
		sql.append("               N1.NUR_SO_NAME                                  AS SIK_JONG_NAME,												");
		sql.append("               N1.MENT                                         AS SIK_JONG_NAME_S,												");
		sql.append("               B.DIRECT_CONT2,																									");
		sql.append("               B.DIRECT_CONT2_D,																								");
		sql.append("               N2.NUR_SO_NAME                                  AS SIK_JUSIK_NAME,												");
		sql.append("               N2.MENT                                         AS SIK_JUSIK_NAME_S,												");
		sql.append("               B.DIRECT_CONT3,																									");
		sql.append("               B.DIRECT_CONT3_D,																								");
		sql.append("               N3.NUR_SO_NAME                                  AS SIK_BUSIK_NAME,												");
		sql.append("               N3.MENT                                         AS SIK_BUSIK_NAME_S,												");
		sql.append("               B.NOMIMONO,																										");
		sql.append("               N4.NUR_SO_NAME                                  AS SIK_NOMIMONO_NAME,											");
		sql.append("               N4.MENT                                         AS SIK_NOMIMONO_NAME_S,											");
		sql.append("               B.KUMJISIK,																										");
		sql.append("               B.INPUT_GWA,																										");
		sql.append("               B.INPUT_DOCTOR,																									");
		sql.append("               IFNULL(C.TO_HO_DONG1, A.HO_DONG1)               AS HO_DONG,														");
		sql.append("               IFNULL(C.TO_HO_CODE1, A.HO_CODE1)               AS HO_CODE,														");
		sql.append("               A.TOIWON_RES_DATE,																								");
		sql.append("               A.TOIWON_RES_TIME,																								");
		sql.append("               A.CANCEL_YN																										");
		sql.append("                 FROM INP1001 A																									");
		sql.append("                 JOIN OCS2005 B ON B.HOSP_CODE     = A.HOSP_CODE																");
		sql.append("                     AND B.BUNHO         = A.BUNHO																				");
		sql.append("                     AND B.FKINP1001     = A.PKINP1001																			");
		sql.append("                     AND B.DIRECT_GUBUN  = '03'																					");
		sql.append("                     AND B.DRT_FROM_DATE >= A.IPWON_DATE																		");
		sql.append("       JOIN INP2004 C ON C.HOSP_CODE     = A.HOSP_CODE																			");
		sql.append("                     AND C.BUNHO         = A.BUNHO																				");
		sql.append("                     AND C.FKINP1001     = A.PKINP1001																			");
		sql.append("       LEFT JOIN NUR0112 N0 ON N0.HOSP_CODE    = B.HOSP_CODE																	");
		sql.append("                     AND N0.NUR_GR_CODE  = B.DIRECT_GUBUN																		");
		sql.append("                     AND N0.NUR_MD_CODE  = B.DIRECT_CODE																		");
		sql.append("                     AND N0.NUR_SO_CODE  = B.DIRECT_CODE_D																		");
		sql.append("       LEFT JOIN NUR0112 N1 ON N1.HOSP_CODE    = B.HOSP_CODE																	");
		sql.append("                     AND N1.NUR_GR_CODE  = B.DIRECT_GUBUN																		");
		sql.append("                     AND N1.NUR_MD_CODE  = B.DIRECT_CONT1																		");
		sql.append("                     AND N1.NUR_SO_CODE  = B.DIRECT_CONT1_D																		");
		sql.append("       LEFT JOIN NUR0112 N2 ON N2.HOSP_CODE    = B.HOSP_CODE																	");
		sql.append("                     AND N2.NUR_GR_CODE  = B.DIRECT_GUBUN																		");
		sql.append("                     AND N2.NUR_MD_CODE  = B.DIRECT_CONT2																		");
		sql.append("                     AND N2.NUR_SO_CODE  = B.DIRECT_CONT2_D																		");
		sql.append("       LEFT JOIN NUR0112 N3 ON N3.HOSP_CODE    = B.HOSP_CODE																	");
		sql.append("                     AND N3.NUR_GR_CODE  = B.DIRECT_GUBUN																		");
		sql.append("                     AND N3.NUR_MD_CODE  = B.DIRECT_CONT3																		");
		sql.append("                     AND N3.NUR_SO_CODE  = B.DIRECT_CONT3_D																		");
		sql.append("       LEFT JOIN NUR0112 N4 ON N4.HOSP_CODE    = B.HOSP_CODE																	");
		sql.append("                     AND N4.NUR_GR_CODE  = B.DIRECT_GUBUN																		");
		sql.append("                     AND N4.NUR_MD_CODE  = '0305'																				");
		sql.append("                     AND N4.NUR_SO_CODE  = B.NOMIMONO																			");
		sql.append("       ,(																														");
		sql.append("         SELECT @rownr\\:=@rownr+1 AS ADD_DAY																					");
		sql.append("         FROM INP1001, (SELECT @rownr\\:=-1) TMP																				");
		sql.append("       ) AA																														");
		sql.append("       WHERE A.HOSP_CODE   = :f_hosp_code																						");
		sql.append("         AND A.BUNHO       = :f_bunho																							");
		sql.append("         AND A.PKINP1001   = :f_fkinp1001																						");
		sql.append("         AND B.DRT_FROM_DATE =																									");
		sql.append("             IFNULL(																											");
		sql.append("             (SELECT MAX(Z.DRT_FROM_DATE)																						");
		sql.append("              FROM OCS2005 Z																									");
		sql.append("              WHERE Z.HOSP_CODE      = B.HOSP_CODE																				");
		sql.append("                AND Z.FKINP1001      = B.FKINP1001																				");
		sql.append("                AND Z.DIRECT_CODE    = B.DIRECT_CODE																			");
		sql.append("                AND Z.BUNHO          = B.BUNHO																					");
		sql.append("                AND Z.BLD_GUBUN      = B.BLD_GUBUN																				");
		sql.append("                AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)											");
		sql.append("                AND (Z.DRT_TO_DATE IS NULL																						");
		sql.append("                   OR Z.DRT_TO_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))),										");
		sql.append("             (SELECT MAX(Z.DRT_FROM_DATE)																						");
		sql.append("                FROM OCS2005 Z																									");
		sql.append("                WHERE Z.HOSP_CODE      = B.HOSP_CODE																			");
		sql.append("                 AND Z.FKINP1001      = B.FKINP1001																				");
		sql.append("                 AND Z.DIRECT_CODE    = B.DIRECT_CODE																			");
		sql.append("                 AND Z.BUNHO          = B.BUNHO																					");
		sql.append("                 AND Z.BLD_GUBUN      = B.BLD_GUBUN																				");
		sql.append("                 AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)											");
		sql.append("                 AND Z.DRT_TO_DATE =																							");
		sql.append("               (SELECT MAX(X.DRT_TO_DATE)																						");
		sql.append("               FROM OCS2005 X																									");
		sql.append("               WHERE X.HOSP_CODE      = Z.HOSP_CODE																				");
		sql.append("                 AND X.DIRECT_CODE    = Z.DIRECT_CODE																			");
		sql.append("                 AND X.BUNHO          = Z.BUNHO																					");
		sql.append("                 AND X.BLD_GUBUN      = Z.BLD_GUBUN																				");
		sql.append("                 AND X.DRT_FROM_DATE  <=DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))))										");
		sql.append("         AND C.START_DATE =																										");
		sql.append("               (SELECT MAX(Z.START_DATE)																						");
		sql.append("               FROM INP2004 Z																									");
		sql.append("               WHERE Z.HOSP_CODE   = C.HOSP_CODE																				");
		sql.append("                 AND Z.BUNHO       = C.BUNHO																					");
		sql.append("                 AND Z.FKINP1001   = C.FKINP1001																				");
		sql.append("                 AND Z.START_DATE  <= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))											");
		sql.append("         AND C.TRANS_CNT =																										");
		sql.append("               (SELECT MAX(Z.TRANS_CNT)																							");
		sql.append("               FROM INP2004 Z																									");
		sql.append("               WHERE Z.HOSP_CODE   = C.HOSP_CODE																				");
		sql.append("                 AND Z.BUNHO       = C.BUNHO																					");
		sql.append("                 AND Z.FKINP1001   = C.FKINP1001																				");
		sql.append("                 AND Z.START_DATE  = C.START_DATE)																				");
		sql.append("         AND AA.ADD_DAY <= (DATEDIFF(IFNULL(A.TOIWON_DATE, CURRENT_DATE), A.IPWON_DATE) + IF(A.TOIWON_DATE IS NULL, 31, 0))		");
		sql.append("       ORDER BY 1, BLD_GUBUN, ADD_DAY) A																						");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code																							");
		sql.append("        AND A.BUNHO     = :f_bunho																								");
		sql.append("        AND A.FKINP1001 = :f_fkinp1001																							");
		sql.append("      ORDER BY A.NUT_DATE																										");
		sql.append("             , A.BLD_GUBUN																										");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U02layVWOCSOCS2005NUTInfo> result = new JpaResultMapper().list(query, OCS2005U02layVWOCSOCS2005NUTInfo.class);
		return result;

	}
	
	@Override
	public List<ComboListItemInfo> getOCS2005U02createHoDong(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'EMPTY' CODE											");
		sql.append("         , CASE(:f_language)										");
		sql.append("            WHEN 'JA' THEN '未指定'									");
		sql.append("            WHEN 'VI' THEN 'Chưa chỉ định'							");
		sql.append("            ELSE 'Unspecified' END CODE_NAME						");
		sql.append("      FROM DUAL														");
		sql.append("     UNION															");
		sql.append("     SELECT A.CODE													");
		sql.append("         , A.CODE_NAME												");
		sql.append("      FROM VW_IFS_IF_SKJ_HO_DONG A									");
		sql.append("      , (select @kcck_hosp_code\\:=:f_hosp_code) TMP				");
		sql.append("     WHERE A.HOSP_CODE =  :f_hosp_code								");
		sql.append("       AND A.LANGUAGE  =  :f_language								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;

	}
	
	@Override
	public List<ComboListItemInfo> getOCS2005U02createHoDongNut(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME                               ");
		sql.append("   FROM (                                             ");
		sql.append("     SELECT '%' CODE								  ");
		sql.append("     , CASE(:f_language)                              ");
		sql.append("           WHEN 'JA' THEN '全体'                      ");
		sql.append("           WHEN 'VI' THEN 'Tất cả'                    ");
		sql.append("       ELSE 'All' END CODE_NAME                       ");
		sql.append("     , 0 ORDER_KEY                                    ");
		sql.append("     FROM DUAL										  ");
		sql.append("    UNION                                             ");
		sql.append("    SELECT 'EMPTY' CODE                               ");
		sql.append("     , CASE(:f_language)                              ");
		sql.append("           WHEN 'JA' THEN '未指定'                     ");
		sql.append("           WHEN 'VI' THEN 'Chưa chỉ định'             ");
		sql.append("           ELSE 'Unspecified' END CODE_NAME           ");
		sql.append("     , 1 ORDER_KEY                                    ");
		sql.append("     FROM DUAL										  ");
		sql.append("     UNION                                            ");
		sql.append("     SELECT A.CODE                                    ");
		sql.append("        , A.CODE_NAME                                 ");
		sql.append("        , 2 ORDER_KEY                                 ");
		sql.append("     FROM VW_IFS_IF_SKJ_HO_DONG A                     ");
		sql.append("     , (select @kcck_hosp_code\\:=:f_hosp_code) TMP   ");
		sql.append("     WHERE A.HOSP_CODE =  :f_hosp_code                ");
		sql.append("       AND A.LANGUAGE  =  :f_language) AA             ");
		sql.append("    ORDER BY AA.ORDER_KEY, AA.CODE                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;

	}
	
	@Override
	public List<ComboListItemInfo> getOCS2005U02createHoCode(String hospCode, String language, String hoDong, String orderDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '%' CODE																					");
		sql.append("       , CASE(:f_language)																				");
		sql.append("         WHEN 'JA' THEN '全体'																			");
		sql.append("         WHEN 'VI' THEN 'Tất cả'																		");
		sql.append("         ELSE 'All' END CODE_NAME																		");
		sql.append("      FROM DUAL																							");
		sql.append("     UNION 																								");
		sql.append("     SELECT 'EMPTY' CODE																				");
		sql.append("      , CASE(:f_language)																				");
		sql.append("         WHEN 'JA' THEN '未指定'																			");
		sql.append("         WHEN 'VI' THEN 'Chưa chỉ định'																	");
		sql.append("         ELSE 'Unspecified' END CODE_NAME																");
		sql.append("      FROM DUAL																							");
		sql.append("     UNION 																								");
		sql.append("     SELECT A.HO_CODE CODE																				");
		sql.append("         , IFNULL(A.HO_CODE_NAME, A.HO_CODE) CODE_NAME													");
		sql.append("      FROM BAS0250 A																					");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code																	");
		sql.append("       AND A.HO_DONG   LIKE :f_ho_dong																	");
		sql.append("       AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN A.START_DATE AND A.END_DATE					");
		sql.append("       AND A.START_DATE = (SELECT MAX(Z.START_DATE)														");
		sql.append("                             FROM BAS0250 Z																");
		sql.append("                            WHERE Z.HOSP_CODE = A.HOSP_CODE												");
		sql.append("                              AND Z.HO_DONG   = A.HO_DONG												");
		sql.append("                              AND Z.HO_CODE   = A.HO_CODE												");
		sql.append("                              AND Z.START_DATE <=  STR_TO_DATE(:f_order_date, '%Y/%m/%d'))				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}

	@Override
	public Double getOCS2005U00getPKSeq(String hospCode, String bunho, String fkinp1001, String orderDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT MAX(A.PK_SEQ)																");
		sql.append("   FROM OCS2005 A																	");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code												");
		sql.append("    AND A.BUNHO       = :f_bunho													");
		sql.append("    AND A.FKINP1001   = :f_fkinp1001												");
		sql.append("    AND :f_order_date BETWEEN A.ORDER_DATE AND IFNULL(A.DRT_TO_DATE, '9999/12/31')	");
		sql.append("  ORDER BY A.PK_SEQ																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		
		List<Double> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public String callFnOcsiGEetJisiOrderGubun(String hospCode, String nurGrCode, String nurMdCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT FN_OCSI_GET_JISI_ORDER_GUBUN(:f_hosp_code, :f_nur_gr_code, :f_nur_md_code)               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2004U00DupCheckInfo> getOCS2004U00DupCheck(String hospCode, String bunho, String fkinp1001, String inputGubun,
			String directGubun, String directCode, String fromDate, String toDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																											");
		sql.append("		STR_TO_DATE(A.DRT_FROM_DATE, '%Y/%m/%d'),																					");
		sql.append("		IFNULL(A.DRT_TO_DATE, '9998/12/31') 		DRT_TO_DATE,													");
		sql.append("		B.NUR_GR_NAME,																								");
		sql.append("		C.NUR_MD_NAME,																								");
		sql.append("		A.DIRECT_GUBUN,																								");
		sql.append("		A.DIRECT_CODE																								");
		sql.append("	FROM																											");
		sql.append("		OCS2005 A 	JOIN	NUR0110 B																				");
		sql.append("					ON		A.DIRECT_GUBUN = B.NUR_GR_CODE															");
		sql.append("					AND		A.HOSP_CODE    = B.HOSP_CODE															");
		sql.append("					JOIN 	NUR0111 C																				");
		sql.append("					ON		A.DIRECT_CODE  = C.NUR_MD_CODE															");
		sql.append("					AND		B.HOSP_CODE    = C.HOSP_CODE															");
		sql.append("	WHERE																											");
		sql.append("		A.BUNHO       		= :f_bunho																				");
		sql.append("		AND A.FKINP1001    	= :f_fkinp1001																			");
		sql.append("		AND A.INPUT_GUBUN  	= :f_input_gubun																		");
		sql.append("		AND A.HOSP_CODE    	= :f_hosp_code																			");
		sql.append("																													");
		sql.append("		AND A.DIRECT_GUBUN 	= :f_direct_gubun																		");
		sql.append("		AND A.DIRECT_CODE  	= :f_direct_code																		");
		sql.append("																													");
		sql.append("		AND (:f_from_date BETWEEN A.DRT_FROM_DATE AND IFNULL(A.DRT_TO_DATE, '9998/12/31')							");
		sql.append("		OR IFNULL(:f_to_date, '9998/12/31') BETWEEN A.DRT_FROM_DATE AND IFNULL(A.DRT_TO_DATE, '9998/12/31') )		");
		sql.append("																													");
		sql.append("	ORDER BY																										");
		sql.append("		A.SYS_DATE ASC																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_direct_gubun", directGubun);
		query.setParameter("f_direct_code", directCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<OCS2004U00DupCheckInfo> listInfo = new JpaResultMapper().list(query, OCS2004U00DupCheckInfo.class);
		return listInfo;
	}

	@Override
	public String getOCS2004U00setFromDate(String hospCode, String pkocs2005, String fkinp1001, String kijunDate,
			String directGubun, String directCode, String kijunTime) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT									              																						");
		sql.append("		MIN(CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y%m%d'), STR_TO_DATE(A.DRT_FROM_TIME, '%Y%m%d'))) 		DRT_FROM_DATE						");
		sql.append("	FROM									              																						");
		sql.append("		OCS2005 A									              																				");
		sql.append("	WHERE									              																						");
		sql.append("		A.HOSP_CODE    		= :f_hosp_code									              														");
		sql.append("		AND A.FKINP1001    	= :f_fkinp1001									              														");
		sql.append("		AND A.DIRECT_GUBUN 	= :f_direct_gubun									              													");
		sql.append("		AND A.DIRECT_CODE  	= :f_direct_code									              													");
		sql.append("		AND A.PKOCS2005    	<> :f_pkocs2005									              														");
		sql.append("		AND CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y%m%d'), A.DRT_FROM_TIME) > CONCAT(STR_TO_DATE(:f_kijun_date, '%Y%m%d'), :f_kijun_time)		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_kijun_date", kijunDate);
		query.setParameter("f_direct_gubun", directGubun);
		query.setParameter("f_direct_code", directCode);
		query.setParameter("f_kijun_time", kijunTime);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS2004U00getPKSeq(String hospCode, String bunho, String fkinp1001, String orderDate,
			String tabinputGubun) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT									              	");
		sql.append("		CAST(IFNULL(MAX(PK_SEQ), 0) AS CHAR) 			PK_SEQ				");
		sql.append("	FROM									              	");
		sql.append("		OCS2005									            ");
		sql.append("	WHERE									              	");
		sql.append("		HOSP_CODE   	= :f_hosp_code						");
		sql.append("	  	AND BUNHO       = :f_bunho							");
		sql.append("	  	AND FKINP1001   = :f_fkinp1001						");
		sql.append("	  	AND ORDER_DATE  = STR_TO_DATE(:f_order_date, '%Y/%e/%c %r')						");
		sql.append("	  	AND INPUT_GUBUN = :f_tabinput_gubun					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_tabinput_gubun", tabinputGubun);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS2004U00setFromDate2(String hospCode, String fkinp1001, String kijunDate, String directGubun,
			String directCode, String kijunTime) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 									              										              												");
		sql.append("		MIN(CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y/%m/%d'), IFNULL(A.DRT_FROM_TIME,''))) 		DRT_FROM_DATE									            ");
		sql.append("	FROM									              										              												");
		sql.append("		OCS2005 A									              										              										");
		sql.append("	WHERE									              										              												");
		sql.append("		A.HOSP_CODE    		= :f_hosp_code									              										              				");
		sql.append("		AND A.FKINP1001    	= :f_fkinp1001									              																	");
		sql.append("		AND A.DIRECT_GUBUN 	= :f_direct_gubun									              										              			");
		sql.append("		AND A.DIRECT_CODE  	= :f_direct_code									              																");
		sql.append("		AND CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y%m%d'), IFNULL(A.DRT_FROM_TIME,'')) > CONCAT(DATE_FORMAT(:f_kijun_date, '%Y%m%d'), :f_kijun_time)		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_kijun_date", kijunDate);
		query.setParameter("f_direct_gubun", directGubun);
		query.setParameter("f_direct_code", directCode);
		query.setParameter("f_kijun_time", kijunTime);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS2004U00layAllOCS2005Info> getOCS2004U00layAllOCS2005(String hospCode, String language, String bunho, String fkinp1001, String orderDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																								");
		sql.append("	  	A.BUNHO,																																						");
		sql.append("	  	CAST(A.FKINP1001 AS CHAR),																																		");
		sql.append("	  	IFNULL(STR_TO_DATE(A.ORDER_DATE, '%y/%m/%d'), ''),																												");
		sql.append("	  	A.INPUT_GUBUN,																																					");
		sql.append("	  	FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, :f_hosp_code, :f_language)    											INPUT_GUBUN_NAME,					");
		sql.append("	  	A.INPUT_ID,																																						");
		sql.append("	  	CAST(A.PK_SEQ AS CHAR),																																			");
		sql.append("	  	A.DIRECT_GUBUN,																																					");
		sql.append("	  	B.NUR_GR_NAME,																																					");
		sql.append("	  	A.DIRECT_CODE,																																					");
		sql.append("	  	C.NUR_MD_NAME,																																					");
		sql.append("	  	IFNULL(A.DIRECT_CONT1, ''),																																		");
		sql.append("	  	A.DIRECT_CONT2,																																					");
		sql.append("	  	A.DIRECT_TEXT,																																					");
		sql.append("	  	IFNULL(C.DIRECT_CONT_YN, ''),																																	");
		sql.append("	  	STR_TO_DATE(IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE), '%Y/%m/%d')                   																	DRT_FROM_DATE,						");
		sql.append("	  	IFNULL(A.DRT_TO_DATE, '')                                      																DRT_TO_DATE,						");
		sql.append("	  	IFNULL(A.CONTINUE_YN, 'N')                         																			CONTINUE_YN,						");
		sql.append("	  	CAST(A.PKOCS2005 AS CHAR),																																		");
		sql.append("	  	IFNULL(C.JISI_ORDER_GUBUN, '0')                    																			JISI_ORDER_GUBUN,					");
		sql.append("	  	IFNULL(D.NUR_SO_NAME, '')                                      																JUSIK,								");
		sql.append("	  	E.NUR_SO_NAME                                      																			BUSIK,								");
		sql.append("	  	IFNULL(A.JUSIK_YUDONG, ''),																																		");
		sql.append("	  	IFNULL(A.BUSIK_YUDONG, ''),																																		");
		sql.append("	  	IFNULL(A.JORI_TYPE, ''),																																		");
		sql.append("	  	IFNULL(A.KUMJISIK, ''),																																			");
		sql.append("	  	IFNULL(FN_OCSI_IS_PRN_ORDER_RESULT(A.HOSP_CODE, A.PK_SEQ, A.INPUT_GUBUN, A.FKINP1001, A.BUNHO, A.ORDER_DATE), '')			SIJI_RESULT_ACT_MAX_DATE,			");
		sql.append("	  	IFNULL(A.DRT_TO_TIME, ''),																																		");
		sql.append("	  	IFNULL(A.DRT_FROM_TIME, '0000')																																	");
		sql.append("	FROM																																								");
		sql.append("	  	OCS2005 A 	JOIN		NUR0110 B																																");
		sql.append("					ON			A.DIRECT_GUBUN 	= B.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE		= B.HOSP_CODE																											");
		sql.append("					JOIN		NUR0111 C																																");
		sql.append("					ON			A.DIRECT_GUBUN	= C.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= C.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE   	= C.HOSP_CODE																											");
		sql.append("					LEFT JOIN 	NUR0112 D																																");
		sql.append("					ON 			A.DIRECT_GUBUN 	= D.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= D.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CONT1 	= D.NUR_SO_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE  	= D.HOSP_CODE																											");
		sql.append("					LEFT JOIN 	NUR0114 E																																");
		sql.append("					ON			A.DIRECT_GUBUN 	= E.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= E.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CONT2 	= E.NUR_SO_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE   	= E.HOSP_CODE																											");
		sql.append("	WHERE																																								");
		sql.append("	  	A.BUNHO       			= :f_bunho																																");
		sql.append("	  	AND A.FKINP1001 		= :f_fkinp1001																															");
		sql.append("	  	AND A.HOSP_CODE 		= :f_hosp_code																															");
		sql.append("	  	AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE) AND IFNULL(A.DRT_TO_DATE, '9999/12/31')								");
		sql.append("	  	AND A.DIRECT_GUBUN 		!= '03'																																	");
		sql.append("	   																																									");
		sql.append("	ORDER BY																																							");
		sql.append("	  	A.DIRECT_GUBUN, A.DIRECT_CODE, A.DRT_FROM_DATE, IFNULL(A.DRT_FROM_TIME, '0000'), A.PK_SEQ																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS2004U00layAllOCS2005Info> listInfo = new JpaResultMapper().list(query, OCS2004U00layAllOCS2005Info.class);
		return listInfo;
	}

	@Override
	public List<OCS2004U00layOCS2006Info> getOCS2004U00layOCS2006(String hospCode, String bunho, String fkinp1001, String orderDate, String pkSeq) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																															");
		sql.append("		A.BUNHO,																															");
		sql.append("	    CAST(A.FKINP1001 AS CHAR),																															");
		sql.append("	    IFNULL(STR_TO_DATE(A.ORDER_DATE, '%Y/%m/%d'), ''),																															");
		sql.append("	    A.INPUT_GUBUN,																															");
		sql.append("	    A.DIRECT_GUBUN,																															");
		sql.append("	    A.DIRECT_CODE,																															");
		sql.append("	    CAST(A.PK_SEQ AS CHAR),																															");
		sql.append("	    A.DIRECT_DETAIL,																															");
		sql.append("	    A.HANGMOG_CODE,																															");
		sql.append("	    CAST(A.SURYANG AS CHAR),																															");
		sql.append("	    IFNULL(A.NALSU, ''),																															");
		sql.append("	    IFNULL(A.ORD_DANUI, ''),																															");
		sql.append("	    IFNULL(A.BOGYONG_CODE, ''),																															");
		sql.append("	    IFNULL(A.JUSA_CODE, ''),																															");
		sql.append("	    IFNULL(A.JUSA_SPD_GUBUN, ''),																															");
		sql.append("	    IFNULL(A.DV, ''),																															");
		sql.append("	    IFNULL(A.DV_TIME, ''),																															");
		sql.append("	    IFNULL(A.INSULIN_FROM, ''),																															");
		sql.append("	    IFNULL(A.INSULIN_TO, ''),																															");
		sql.append("	    IFNULL(A.TIME_GUBUN, ''),																															");
		sql.append("	    IFNULL(A.BOM_SOURCE_KEY, ''),																															");
		sql.append("	    IFNULL(A.BOM_YN, ''),																															");
		sql.append("	    CAST(A.SEQ AS CHAR),																															");
		sql.append("	    CAST(B.PKOCS2005 AS CHAR)																															");
		sql.append("	FROM																															");
		sql.append("	  	OCS2006 A JOIN																															");
		sql.append("	    	(																															");
		sql.append("				SELECT *																															");
		sql.append("	    		FROM OCS2005 A																															");
		sql.append("	    		WHERE																															");
		sql.append("			 		A.HOSP_CODE = :f_hosp_code																															");
		sql.append("	        		AND A.BUNHO     = :f_bunho																															");
		sql.append("	        		AND A.FKINP1001 = :f_fkinp1001																															");
		sql.append("	        		AND :f_order_date BETWEEN A.DRT_FROM_DATE AND IFNULL(A.DRT_TO_DATE, '9998/12/31')																															");
		sql.append("	        		AND CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y/%m/%d'), '/', LPAD(A.PK_SEQ, 4, '0'))	 =																															");
		sql.append("						(																															");
		sql.append("		                	SELECT																															");
		sql.append("								MAX(CONCAT(DATE_FORMAT(AA.DRT_FROM_DATE, '%Y/%m/%d'), '/', LPAD(AA.PK_SEQ, 4,'0')))																															");
		sql.append("		                    FROM																															");
		sql.append("								OCS2005 AA																															");
		sql.append("		                    WHERE																															");
		sql.append("		                    	AA.HOSP_CODE   			= A.HOSP_CODE																															");
		sql.append("		                        AND AA.DIRECT_GUBUN = A.DIRECT_GUBUN																															");
		sql.append("		                        AND AA.DIRECT_CODE  = A.DIRECT_CODE																															");
		sql.append("		                        AND AA.BUNHO        = A.BUNHO																															");
		sql.append("		                        AND AA.FKINP1001    = A.FKINP1001																															");
		sql.append("		                        AND :f_order_date BETWEEN AA.DRT_FROM_DATE AND IFNULL(AA.DRT_TO_DATE, '9998/12/31')																															");
		sql.append("	                     )																															");
		sql.append("	    	) B																															");
		sql.append("																																				");
		sql.append("			ON 	A.HOSP_CODE = B.HOSP_CODE																															");
		sql.append("			AND	A.FKOCS2005 = B.PKOCS2005																															");
		sql.append("	WHERE																															");
		sql.append("	  	A.BUNHO       							= :f_bunho																															");
		sql.append("	  	AND A.FKINP1001   						= :f_fkinp1001																															");
		sql.append("	  	AND :f_order_date BETWEEN IFNULL(A.ORDER_DATE, B.DRT_FROM_DATE) AND IFNULL(B.DRT_TO_DATE, '9998/12/31')																															");
		sql.append("	  	AND A.HOSP_CODE   						= :f_hosp_code																															");
		sql.append("	  	AND IFNULL(B.DRT_TO_DATE, '9998/12/31') > :f_order_date 																															");
		sql.append("	ORDER BY																															");
		sql.append("		A.PK_SEQ, A.SEQ																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS2004U00layOCS2006Info> listInfo = new JpaResultMapper().list(query, OCS2004U00layOCS2006Info.class);
		return listInfo;
	}
	
	@Override
	public String executeFnOcsOcs2005DeleteYn(String hospCode, Date drtDate, String bldGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_OCS2005_DELETE_YN(:f_hosp_code , :f_drt_date, :f_bld_gubun) FROM DUAL ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drt_date", drtDate);
		query.setParameter("f_bld_gubun", bldGubun);
		
		List<String> results = query.getResultList();
		return CollectionUtils.isEmpty(results) ? "" : results.get(0);
	}

	@Override
	public Integer updateOcs2005InOCS6010U10SaveLayoutCase01(String hospCode, Double pkocs2005, String userId,
			String pickupUser) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	 UPDATE OCS2005								             ");
		sql.append("	 SET UPD_ID             = :f_user_id      ,	             ");
		sql.append("	     UPD_DATE           = SYSDATE()       ,	             ");
		sql.append("	     NURSE_PICKUP_USER  = :f_pickup_user  ,	             ");
		sql.append("	     NURSE_PICKUP_DATE  = CURRENT_DATE()  ,	             ");
		sql.append("	     NURSE_PICKUP_TIME  = DATE_FORMAT(SYSDATE(), '%H%i') ");
		sql.append("	 WHERE HOSP_CODE        = :f_hosp_code                   ");
		sql.append("	   AND PKOCS2005        = :f_pkocs2005                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_pickup_user", pickupUser);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		
		return query.executeUpdate();
	}
	
	@Override
	public Integer updateOcs2005InOCS6010U10SaveLayoutCase02(String hospCode, Double pkocs2005, String userId) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	 UPDATE OCS2005							");
		sql.append("	 SET UPD_ID             = :f_user_id,	");
		sql.append("	     UPD_DATE           = SYSDATE() ,	");
		sql.append("	     NURSE_PICKUP_USER  = NULL      ,	");
		sql.append("	     NURSE_PICKUP_DATE  = NULL      ,	");
		sql.append("	     NURSE_PICKUP_TIME  = NULL      	");
		sql.append("	 WHERE HOSP_CODE        = :f_hosp_code	");
		sql.append("	   AND PKOCS2005        = :f_pkocs2005	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		
		return query.executeUpdate();
	}

	@Override
	public List<OCS2004U00layOCS2005Info> getOCS2004U00layOCS2005(String hospCode, String language, String bunho, String fkinp1001, String orderDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																								");
		sql.append("	  	A.BUNHO,																																						");
		sql.append("	  	CAST(A.FKINP1001 AS CHAR),																																		");
		sql.append("	  	IFNULL(STR_TO_DATE(A.ORDER_DATE, '%y/%m/%d'), ''),																												");
		sql.append("	  	A.INPUT_GUBUN,																																					");
		sql.append("	  	FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, :f_hosp_code, :f_language)    											INPUT_GUBUN_NAME,					");
		sql.append("	  	A.INPUT_ID,																																						");
		sql.append("	  	CAST(A.PK_SEQ AS CHAR),																																			");
		sql.append("	  	A.DIRECT_GUBUN,																																					");
		sql.append("	  	B.NUR_GR_NAME,																																					");
		sql.append("	  	A.DIRECT_CODE,																																					");
		sql.append("	  	C.NUR_MD_NAME,																																					");
		sql.append("	  	IFNULL(A.DIRECT_CONT1, ''),																																		");
		sql.append("	  	A.DIRECT_CONT2,																																					");
		sql.append("	  	A.DIRECT_TEXT,																																					");
		sql.append("	  	IFNULL(C.DIRECT_CONT_YN, ''),																																	");
		sql.append("	  	DATE_FORMAT(IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE), '%Y/%m/%d')                   											DRT_FROM_DATE,						");
		sql.append("	  	IFNULL(DATE_FORMAT(A.DRT_TO_DATE, '%Y/%m/%d'), '')                                     								DRT_TO_DATE,								");
		sql.append("	  	IFNULL(A.CONTINUE_YN, 'N')                         																			CONTINUE_YN,						");
		sql.append("	  	CAST(A.PKOCS2005 AS CHAR),																																		");
		sql.append("	  	IFNULL(C.JISI_ORDER_GUBUN, '0')                    																			JISI_ORDER_GUBUN,					");
		sql.append("	  	IFNULL(D.NUR_SO_NAME, '')                                      																JUSIK,								");
		sql.append("	  	E.NUR_SO_NAME                                      																			BUSIK,								");
		sql.append("	  	IFNULL(A.JUSIK_YUDONG, ''),																																		");
		sql.append("	  	IFNULL(A.BUSIK_YUDONG, ''),																																		");
		sql.append("	  	IFNULL(A.JORI_TYPE, ''),																																		");
		sql.append("	  	IFNULL(A.KUMJISIK, ''),																																			");
		sql.append("	  	IFNULL(FN_OCSI_IS_PRN_ORDER_RESULT(A.HOSP_CODE, A.PK_SEQ, A.INPUT_GUBUN, A.FKINP1001, A.BUNHO, A.ORDER_DATE), '')			SIJI_RESULT_ACT_MAX_DATE,			");
		sql.append("	  	IFNULL(A.DRT_TO_TIME, ''),																																		");
		sql.append("	  	IFNULL(A.DRT_FROM_TIME, '0000')																																	");
		sql.append("	FROM																																								");
		sql.append("	  	OCS2005 A 	JOIN		NUR0110 B																																");
		sql.append("					ON			A.DIRECT_GUBUN 	= B.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE		= B.HOSP_CODE																											");
		sql.append("					JOIN		NUR0111 C																																");
		sql.append("					ON			A.DIRECT_GUBUN	= C.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= C.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE   	= C.HOSP_CODE																											");
		sql.append("					LEFT JOIN 	NUR0112 D																																");
		sql.append("					ON 			A.DIRECT_GUBUN 	= D.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= D.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CONT1 	= D.NUR_SO_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE  	= D.HOSP_CODE																											");
		sql.append("					LEFT JOIN 	NUR0114 E																																");
		sql.append("					ON			A.DIRECT_GUBUN 	= E.NUR_GR_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CODE 	= E.NUR_MD_CODE																											");
		sql.append("	  				AND 		A.DIRECT_CONT2 	= E.NUR_SO_CODE																											");
		sql.append("	  				AND 		A.HOSP_CODE   	= E.HOSP_CODE																											");
		sql.append("	WHERE																																								");
		sql.append("	  	A.BUNHO       			= :f_bunho																																");
		sql.append("	  	AND A.FKINP1001 		= :f_fkinp1001																															");
		sql.append("	  	AND A.HOSP_CODE 		= :f_hosp_code																															");
		sql.append("	  	AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE) AND IFNULL(A.DRT_TO_DATE, '9999/12/31')								");
		sql.append("	  	AND A.DIRECT_GUBUN 		!= '03'																																	");
		sql.append("	   																																									");
		sql.append("	ORDER BY																																							");
		sql.append("	  	A.DRT_FROM_DATE, IFNULL(A.DRT_FROM_TIME, '0000'), A.PK_SEQ																										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS2004U00layOCS2005Info> listInfo = new JpaResultMapper().list(query, OCS2004U00layOCS2005Info.class);
		return listInfo;
	}
	
	
	@Override
	public List<OCS2005U02SetTabInfo> getOCS2005U02SetTabInfo(String hospCode, String bunho, String jaewonYn, String bldGubun, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT PKOCS2005					                         PKOCS2005 ,						");
		sql.append("            IFNULL(DATE_FORMAT(A.DRT_FROM_DATE, '%Y/%m/%d'),'')  DRT_FROM_DATE,						");
		sql.append("            IFNULL(DATE_FORMAT(A.DRT_TO_DATE, '%Y/%m/%d'),'')    DRT_TO_DATE,						");
		sql.append("            SUBSTR(A.DIRECT_CODE, 4, 1)                          SIKA_GUBUN,						");
		sql.append("            ''		                                             ROWNUM,							");
		sql.append("			''													 MSG								");		
		sql.append("     FROM OCS2005 A																					");
//		sql.append("     , (																							");
//		sql.append("       SELECT @rownr\\:=@rownr+1 AS ROWNUM															");
//		sql.append("       FROM OCS2005, (SELECT @rownr\\:=0) TMP														");
//		sql.append("       ) AA																							");
		sql.append("     WHERE A.HOSP_CODE    = :f_hosp_code															");
		sql.append("     AND (:f_jaewon_yn = 'Y' AND A.FKINP1001  = ( SELECT B.PKINP1001								");
		sql.append("                                           FROM VW_OCS_INP1001_RES_01 B								");
		sql.append("                                           , (select @kcck_hosp_code\\:=:f_hosp_code) TMP			");
		sql.append("                                          WHERE B.BUNHO = :f_bunho									");
		sql.append("                                        )															");
		sql.append("          OR :f_jaewon_yn = 'N' AND A.FKINP1001 = :f_fkinp1001										");
		sql.append("         )																							");
		sql.append("     AND A.DIRECT_GUBUN = '03'																		");
		sql.append("     AND A.BLD_GUBUN    = :f_bld_gubun																");
		sql.append("     AND A.DIRECT_CODE  = '0301'																	");
		sql.append("     AND A.FKOCS6015 IS NULL																		");
		sql.append("     																								");
		sql.append("     ORDER BY A.DRT_FROM_DATE																		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_bld_gubun", bldGubun);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_jaewon_yn", jaewonYn);
		
		List<OCS2005U02SetTabInfo> result = new JpaResultMapper().list(query, OCS2005U02SetTabInfo.class);
		return result;
	}
	
	@Override
	public String getOCS2005U02IsNutCheckFromToDate(String hospCode, Date date, String bunho, String bldGubun, String pkocs2005, String fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_NUT_CHECK_FROM_TO_DATE(:f_date, :f_bunho, :f_hosp_code, :f_bld_gubun, :f_pkocs2005, :f_fkinp1001) FROM DUAL ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_bld_gubun", bldGubun);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_pkocs2005", pkocs2005);
		query.setParameter("f_date", date);
		
		List<String> listResult = query.getResultList();
		return listResult.get(0);
	}
	
	@Override
	public List<ComboListItemInfo> OCS2005U02btnLoadOldComment(String hospCode, String bldGubun, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '' MSG																		");
		sql.append("          , IFNULL(A.KUMJISIK,'') KUMJISIK												");
		sql.append("       FROM OCS2005 A																	");
		sql.append("      WHERE A.HOSP_CODE     = :f_hosp_code												");
		sql.append("        AND A.BLD_GUBUN     = :f_bld_gubun												");
		sql.append("        AND A.FKINP1001     = :f_fkinp1001												");
		sql.append("        AND A.DRT_FROM_DATE = (  SELECT MAX(B.DRT_FROM_DATE) DRT_FROM_DATE				");
		sql.append("                                   FROM OCS2005 B										");
		sql.append("                                  WHERE B.HOSP_CODE = A.HOSP_CODE						");
		sql.append("                                    AND B.BLD_GUBUN = A.BLD_GUBUN						");
		sql.append("                                    AND B.FKINP1001 = A.FKINP1001)						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bld_gubun", bldGubun);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}
	
	@Override
	public String OCS2005U02ProcCreateSikjin(String fromDate, String fromBld, String bunho, String hospCode, Double fkinp1001, String updId, String commentGubun,
			Integer sikjinGubun, String iudGubun, String nomimono, String ipwonDate, String sikgubun1th, String sikjong1th, String jusik1th, String busik1th,
			String sikgubun2th, String sikjong2th, String jusik2th, String busik2th, String sikgubun3th, String sikjong3th, String jusik3th, String busik3th,
			String sikgubun4th, String sikjong4th, String jusik4th, String busik4th, String sikgubun5th, String sikjong5th, String jusik5th, String busik5th){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_CREATE_SIKJIN");
		
		query.registerStoredProcedureParameter("I_FROM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_BLD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_COMMENT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJIN_GUBUN", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NOMIMONO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKGUBUN1TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJONG1TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSIK1TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUSIK1TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKGUBUN2TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJONG2TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSIK2TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUSIK2TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKGUBUN3TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJONG3TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSIK3TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUSIK3TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKGUBUN4TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJONG4TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSIK4TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUSIK4TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKGUBUN5TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SIKJONG5TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUSIK5TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUSIK5TH", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);

		query.setParameter("I_FROM_DATE", DateUtil.toDate(fromDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_FROM_BLD", fromBld);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_UPD_ID", updId);
		query.setParameter("I_COMMENT_GUBUN", commentGubun);
		query.setParameter("I_SIKJIN_GUBUN", sikjinGubun);
		query.setParameter("I_IUD_GUBUN", iudGubun);
		query.setParameter("I_NOMIMONO", nomimono);
		query.setParameter("I_IPWON_DATE", DateUtil.toDate(ipwonDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_SIKGUBUN1TH", sikgubun1th);
		query.setParameter("I_SIKJONG1TH", sikjong1th);
		query.setParameter("I_JUSIK1TH", jusik1th);
		query.setParameter("I_BUSIK1TH", busik1th);
		query.setParameter("I_SIKGUBUN2TH", sikgubun2th);
		query.setParameter("I_SIKJONG2TH", sikjong2th);
		query.setParameter("I_JUSIK2TH", jusik2th);
		query.setParameter("I_BUSIK2TH", busik2th);
		query.setParameter("I_SIKGUBUN3TH", sikgubun3th);
		query.setParameter("I_SIKJONG3TH", sikjong3th);
		query.setParameter("I_JUSIK3TH", jusik3th);
		query.setParameter("I_BUSIK3TH", busik3th);
		query.setParameter("I_SIKGUBUN4TH", sikgubun4th);
		query.setParameter("I_SIKJONG4TH", sikjong4th);
		query.setParameter("I_JUSIK4TH", jusik4th);
		query.setParameter("I_BUSIK4TH", busik4th);
		query.setParameter("I_SIKGUBUN5TH", sikgubun5th);
		query.setParameter("I_SIKJONG5TH", sikjong5th);
		query.setParameter("I_JUSIK5TH", jusik5th);
		query.setParameter("I_BUSIK5TH", busik5th);
		
		query.execute();
		String result = (String)query.getOutputParameterValue("O_FLAG");
		return result;
	}
	
	@Override
	public List<OCS2005U02calSiksaDayClickInfo> getOCS2005U02calSiksaDayClickInfo(String hospCode, String nutDate, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT																											");
		sql.append("          B.PKOCS2005																								");
		sql.append("        , DATE_FORMAT(B.DRT_FROM_DATE, '%Y/%m/%d') DRT_FROM_DATE													");
		sql.append("        , DATE_FORMAT(B.DRT_TO_DATE, '%Y/%m/%d') DRT_TO_DATE														");
		sql.append("        , DATE_FORMAT(DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY),'%Y/%m/%d') NUT_DATE							");
		sql.append("        , B.BLD_GUBUN																								");
		sql.append("        , B.FKINP1001																								");
		sql.append("        , '' MSG																									");
		sql.append("     FROM INP1001 A																									");
		sql.append("     JOIN OCS2005 B																									");
		sql.append("       ON  B.HOSP_CODE     = A.HOSP_CODE																			");
		sql.append("       AND B.FKINP1001     = :f_fkinp1001																			");
		sql.append("       AND B.BUNHO         = A.BUNHO																				");
		sql.append("       AND B.FKINP1001     = A.PKINP1001																			");
		sql.append("       AND B.DIRECT_GUBUN  = '03'																					");
		sql.append("       AND B.DRT_FROM_DATE >= A.IPWON_DATE																			");
		sql.append("       AND (B.DRT_TO_DATE IS NULL																					");
		sql.append("            OR B.DRT_TO_DATE <=																						");
		sql.append("                  IFNULL (A.TOIWON_DATE, STR_TO_DATE('9899/12/31', '%Y/%m/%d')))									");
		sql.append("           ,(																										");
		sql.append("         SELECT @rownr\\:=@rownr+1 AS ADD_DAY																		");
		sql.append("         FROM INP1001, (SELECT @rownr\\:=-1) TMP																	");
		sql.append("         ) AA																										");
		sql.append("     WHERE   1 = 1																									");
		sql.append("         AND A.HOSP_CODE = :f_hosp_code																				");
		sql.append("         AND DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY) = STR_TO_DATE(:f_nut_date, '%Y/%m/%d')					");
		sql.append("         AND B.DRT_FROM_DATE =																						");
		sql.append("              IFNULL (																								");
		sql.append("                 (SELECT MAX(Z.DRT_FROM_DATE)																		");
		sql.append("                    FROM OCS2005 Z																					");
		sql.append("                   WHERE     Z.HOSP_CODE   = B.HOSP_CODE															");
		sql.append("                         AND Z.FKINP1001   = B.FKINP1001															");
		sql.append("                         AND Z.DIRECT_CODE = B.DIRECT_CODE															");
		sql.append("                         AND Z.BUNHO       = B.BUNHO																");
		sql.append("                         AND Z.BLD_GUBUN   = B.BLD_GUBUN															");
		sql.append("                         AND Z.DRT_FROM_DATE <=																		");
		sql.append("                                DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)										");
		sql.append("                         AND (Z.DRT_TO_DATE IS NULL																	");
		sql.append("                              OR Z.DRT_TO_DATE >=																	");
		sql.append("                                    DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY))),								");
		sql.append("                 (SELECT MAX(Z.DRT_FROM_DATE)																		");
		sql.append("                    FROM OCS2005 Z																					");
		sql.append("                   WHERE     Z.HOSP_CODE    = B.HOSP_CODE															");
		sql.append("                         AND Z.FKINP1001    = B.FKINP1001															");
		sql.append("                         AND Z.DIRECT_CODE  = B.DIRECT_CODE															");
		sql.append("                         AND Z.BUNHO        = B.BUNHO																");
		sql.append("                         AND Z.BLD_GUBUN    = B.BLD_GUBUN															");
		sql.append("                         AND Z.DRT_FROM_DATE <=																		");
		sql.append("                                DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)										");
		sql.append("                         AND Z.DRT_TO_DATE =																		");
		sql.append("                                (SELECT MAX(X.DRT_TO_DATE)															");
		sql.append("                                   FROM OCS2005 X																	");
		sql.append("                                  WHERE     X.HOSP_CODE   = Z.HOSP_CODE												");
		sql.append("                                        AND X.DIRECT_CODE = Z.DIRECT_CODE											");
		sql.append("                                        AND X.BUNHO       = Z.BUNHO													");
		sql.append("                                        AND X.BLD_GUBUN   = Z.BLD_GUBUN												");
		sql.append("                                        AND X.DRT_FROM_DATE <=														");
		sql.append("                                               DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY))))					");
		sql.append("         AND AA.ADD_DAY <=																							");
		sql.append("                (( DATEDIFF(IFNULL (A.TOIWON_DATE, CURRENT_DATE()), A.IPWON_DATE))									");
		sql.append("                 + (CASE (A.TOIWON_DATE) WHEN NULL THEN 31 ELSE 0 END))												");
		sql.append("         ORDER BY  B.BLD_GUBUN , B.FKINP1001																		");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nut_date", nutDate);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<OCS2005U02calSiksaDayClickInfo> result = new JpaResultMapper().list(query, OCS2005U02calSiksaDayClickInfo.class);
		return result;
	}
	
	@Override
	public String OCS2005U02ProcDailyNut(String updId, String hospCode, String bunho, String fkinp1001, String chargeDate, String workGubun){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DAILY_NUT");
		
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CHARGE_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WORK_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);

		query.setParameter("I_UPD_ID", updId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_CHARGE_DATE", DateUtil.toDate(chargeDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_WORK_GUBUN", workGubun);
		
		query.execute();
		String result = (String)query.getOutputParameterValue("O_FLAG");
		return result;
	}
	
	@Override
	public Double getNextSeqOcs2005Today(String hospCode, String bunho, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(PK_SEQ), 0) + 1 PK_SEQ	");
		sql.append("	FROM OCS2005								");
		sql.append("	WHERE BUNHO             = :f_bunho			");
		sql.append("	  AND FKINP1001         = :f_fkinp1001		");
		sql.append("	  AND DATE(ORDER_DATE)  = DATE(SYSDATE())	");
		sql.append("	  AND HOSP_CODE         = :f_hosp_code		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_hosp_code", hospCode);
		
		List<Double> list = query.getResultList();
		return list.get(0);
	}

	@Override
	public List<OCS6010U10PopupIAlayOCS2006Info> getOCS6010U10PopupIAlayOCS2006(String hospCode, String pkocs2005) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT													");
		sql.append("	    A.BUNHO,											");
		sql.append("	    CAST(A.FKINP1001 AS CHAR),							");
		sql.append("	    IFNULL(STR_TO_DATE(A.ORDER_DATE, '%Y/%m/%d'), ''),	");
		sql.append("	    A.INPUT_GUBUN,										");
		sql.append("	    A.DIRECT_GUBUN,										");
		sql.append("	    A.DIRECT_CODE,										");
		sql.append("	    CAST(A.PK_SEQ AS CHAR),								");
		sql.append("	    A.HANGMOG_CODE,										");
		sql.append("	    CAST(A.SURYANG AS CHAR),							");
		sql.append("	    IFNULL(A.INSULIN_FROM, ''),							");
		sql.append("	    IFNULL(A.INSULIN_TO, ''),							");
		sql.append("	    IFNULL(A.TIME_GUBUN, ''),							");
		sql.append("	    CAST(A.SEQ AS CHAR),								");
		sql.append("	    CAST(B.PKOCS2005 AS CHAR),							");
		sql.append("	    STR_TO_DATE(B.DRT_FROM_DATE, '%Y/%m/%d'),			");
		sql.append("	    IFNULL(B.DRT_TO_DATE, '')							");
		sql.append("	FROM													");
		sql.append("		OCS2006 A 	JOIN 	OCS2005 B						");
		sql.append("					ON 		A.HOSP_CODE = B.HOSP_CODE		");
		sql.append("	  				AND 	A.FKOCS2005 = B.PKOCS2005		");
		sql.append("	WHERE													");
		sql.append("		B.HOSP_CODE 	= :f_hosp_code						");
		sql.append("	  	AND B.PKOCS2005 = :f_pkocs2005						");
		sql.append("	ORDER BY A.SEQ											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		
		List<OCS6010U10PopupIAlayOCS2006Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupIAlayOCS2006Info.class);
		return listInfo;
	}

	@Override
	public List<OCS6010U10PopupIAlayOCS2005Info> getOCS6010U10PopupIAlayOCS2005(String hospCode, String pkocs2005) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT												");
		sql.append("	    IFNULL(A.BUNHO, ''),							");
		sql.append("	    CAST(A.FKINP1001 AS CHAR),						");
		sql.append("	    STR_TO_DATE(A.ORDER_DATE, '%Y/%m/%d'),			");
		sql.append("	    A.INPUT_GUBUN,									");
		sql.append("	    A.INPUT_ID,										");
		sql.append("	    CAST(A.PK_SEQ AS CHAR),							");
		sql.append("	    A.DIRECT_GUBUN,									");
		sql.append("	    A.DIRECT_CODE,									");
		sql.append("	    A.DIRECT_CONT1,									");
		sql.append("	    A.DIRECT_CONT2,									");
		sql.append("	    IFNULL(A.DIRECT_TEXT, '')						");
		sql.append("	FROM												");
		sql.append("		OCS2005 A										");
		sql.append("	WHERE												");
		sql.append("	  	A.HOSP_CODE   	= :f_hosp_code					");
		sql.append("	  	AND A.PKOCS2005 = :f_pkocs2005					");
		sql.append("	ORDER BY											");
		sql.append("	  	A.PK_SEQ										");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		
		List<OCS6010U10PopupIAlayOCS2005Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupIAlayOCS2005Info.class);
		return listInfo;
	}
}

