package nta.med.data.dao.medi.drg.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.stereotype.Repository;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg9005RepositoryCustom;
import nta.med.data.model.ihis.drgs.DRG3010Q12AntibioticListgrdAntibioticListInfo;
import nta.med.data.model.ihis.drgs.DRG3010Q12grdDrgHistoryInfo;

/**
 * @author dainguyen.
 */
@Repository("drg9005Repository")
public class Drg9005RepositoryImpl implements Drg9005RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DRG3010Q12grdDrgHistoryInfo> getDRG3010Q12grdDrgHistoryInfo(String hospCode, String language, String yyyymm, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT																																				");
		sql.append("            FN_INV_LOAD_CODE_NAME('01', A.MAGAM_GUBUN, 'A', :f_hosp_code)                    AS MAGAM_GUBUN												");
		sql.append("          , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                            AS ORDER_DATE												");
		sql.append("          , SUBSTR(A.GROUP_SER,2,2)                                                          AS GROUP_SER												");
		sql.append("          , REPLACE(IFNULL(FN_INV_LOAD_JAERYO_NAME(JAERYO_CODE, '0', :f_hosp_code), JAERYO_CODE),'/','')        AS HANGMOG_NAME							");
		sql.append("          , CAST(A.SURYANG AS CHAR)                                                          AS SURYANG													");
		sql.append("          , CAST(A.NALSU AS CHAR)                                                            AS NALSU													");
		sql.append("          , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI, :f_hosp_code, :f_language)      AS DANUI_NAME												");
		sql.append("          , A.BOGYONG_NAME                                                                   AS BOGYONG_NAME											");
		sql.append("          , A.BUNHO                                                                          AS BUNHO													");
		sql.append("          , A.DOCTOR                                                                         AS DOCTOR													");
		sql.append("          , IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,  CURRENT_DATE(), :f_hosp_code),'')      AS DOCTOR_NAME												");
		sql.append("          , B.SUNAME                                                                         AS SUNAME													");
		sql.append("          , FN_BAS_LOAD_GWA_NAME(A.HO_DONG, A.ORDER_DATE, :f_hosp_code, :f_language)         AS GWA														");
		sql.append("          , A.YYYYMM                                                                         AS YYYYMM													");
		sql.append("          , IFNULL(A.DONBOK_YN,'')                                                           AS DONBOK_YN												");
		sql.append("          , A.IN_OUT_GUBUN                                                                   AS IN_OUT_GUBUN											");
		sql.append("          , IFNULL(A.MIX_GROUP,'')                                                           AS MIX_GROUP												");
		sql.append("          , A.HO_CODE                                                                        AS HO_CODE													");
		sql.append("          , A.DV_TIME                                                                        AS DV_TIME													");
		sql.append("          , CAST(A.DV AS CHAR)                                                               AS DV														");
		sql.append("          , CASE(IFNULL(C.HANGMOG_CODE, 'N')) WHEN '' THEN 'N' WHEN 'N' THEN 'N' ELSE 'Y' END                  AS ANTIBIOTIC_YN							");
		sql.append("          , IFNULL(CONCAT(A.MAGAM_GUBUN, DATE_FORMAT(A.ORDER_DATE, '%Y%m%d'), A.GROUP_SER, A.MIX_GROUP,  LTRIM(LPAD(A.SEQ, 10,'0'))),'') CONT_KEY		");
		sql.append("          , CASE (A.NUM01) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM01									");
		sql.append("          , CASE (A.NUM02) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM02									");
		sql.append("          , CASE (A.NUM03) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM03									");
		sql.append("          , CASE (A.NUM04) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM04									");
		sql.append("          , CASE (A.NUM05) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM05									");
		sql.append("          , CASE (A.NUM06) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM06									");
		sql.append("          , CASE (A.NUM07) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM07									");
		sql.append("          , CASE (A.NUM08) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM08									");
		sql.append("          , CASE (A.NUM09) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM09									");
		sql.append("          , CASE (A.NUM10) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM10									");
		sql.append("          , CASE (A.NUM11) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM11									");
		sql.append("          , CASE (A.NUM12) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM12									");
		sql.append("          , CASE (A.NUM13) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM13									");
		sql.append("          , CASE (A.NUM14) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM14									");
		sql.append("          , CASE (A.NUM15) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM15									");
		sql.append("          , CASE (A.NUM16) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM16									");
		sql.append("          , CASE (A.NUM17) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM17									");
		sql.append("          , CASE (A.NUM18) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM18									");
		sql.append("          , CASE (A.NUM19) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM19									");
		sql.append("          , CASE (A.NUM20) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM20									");
		sql.append("          , CASE (A.NUM21) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM21									");
		sql.append("          , CASE (A.NUM22) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM22									");
		sql.append("          , CASE (A.NUM23) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM23									");
		sql.append("          , CASE (A.NUM24) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM24									");
		sql.append("          , CASE (A.NUM25) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM25									");
		sql.append("          , CASE (A.NUM26) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM26									");
		sql.append("          , CASE (A.NUM27) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM27									");
		sql.append("          , CASE (A.NUM28) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM28									");
		sql.append("          , CASE (A.NUM29) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM29									");
		sql.append("          , CASE (A.NUM30) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM30									");
		sql.append("          , CASE (A.NUM31) WHEN '0' THEN '' ELSE (CASE (A.MAGAM_GUBUN) WHEN 'ZZ' THEN '○' ELSE '●' END) END    AS NUM31									");
		sql.append("       FROM DRG9005 A																																	");
		sql.append("       JOIN OUT0101 B																																	");
		sql.append("         ON B.HOSP_CODE    = A.HOSP_CODE																												");
		sql.append("        AND B.BUNHO        = A.BUNHO																													");
		sql.append("       LEFT JOIN (																																		");
		sql.append("             SELECT CC.HANGMOG_CODE																														");
		sql.append("               FROM OCS0103 CC																															");
		sql.append("               JOIN INV0110 AA																															");
		sql.append("                 ON AA.HOSP_CODE               = CC.HOSP_CODE																							");
		sql.append("                AND AA.JAERYO_CODE             = CC.HANGMOG_CODE																						");
		sql.append("                AND AA.SMALL_CODE              LIKE '61%'																								");
		sql.append("              WHERE CC.HOSP_CODE               = :f_hosp_code																							");
		sql.append("                AND CC.WONNAE_DRG_YN           = 'Y'																									");
		sql.append("                AND CURRENT_DATE()            BETWEEN CC.START_DATE AND CC.END_DATE																		");
		sql.append("            ) C																																			");
		sql.append("         ON C.HANGMOG_CODE = A.JAERYO_CODE																												");
		sql.append("      WHERE A.HOSP_CODE    = :f_hosp_code																												");
		sql.append("       AND A.YYYYMM       = :f_yyyymm																													");
		sql.append("       AND A.BUNHO        LIKE :f_bunho																													");
		sql.append("      ORDER BY CONT_KEY																																	");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																															");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_yyyymm", yyyymm);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<DRG3010Q12grdDrgHistoryInfo> list = new JpaResultMapper().list(query, DRG3010Q12grdDrgHistoryInfo.class);
		return list;
	}
	
	@Override
	public boolean callProcDrg9005SeriesNew(String userId, String hospCode, String orderFrom, String bunho, String inOutGubun){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_DRG9005_SERIES_NEW");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_FROM", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_ORDER_FROM", orderFrom);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.execute();
		return true ;

	}
}

