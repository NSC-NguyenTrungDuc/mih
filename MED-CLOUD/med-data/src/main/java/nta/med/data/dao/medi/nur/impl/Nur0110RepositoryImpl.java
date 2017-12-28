package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0110RepositoryCustom;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0110Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00layDirectInfoInfo;

/**
 * @author dainguyen.
 */
public class Nur0110RepositoryImpl implements Nur0110RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS2005U00layDirectInfoInfo> getOCS2005U00layDirectInfoInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT C.NUR_GR_CODE   , 														");
	    sql.append("       C.NUR_GR_NAME   ,                                                        ");
	    sql.append("       C.NUR_MD_CODE   ,                                                        ");
	    sql.append("       C.NUR_MD_NAME   ,                                                        ");
	    sql.append("       C.CNT_PERHOUR_YN,                                                        ");
	    sql.append("       C.CNT_PERDAY_YN ,                                                        ");
	    sql.append("       C.ACT_DAY_YN    ,                                                        ");
	    sql.append("       C.FRENCH_YN     ,                                                        ");
	    sql.append("       C.ACT_DQ1_YN    ,                                                        ");
	    sql.append("       C.ACT_DQ2_YN    ,                                                        ");
	    sql.append("       C.ACT_DQ3_YN    ,                                                        ");
	    sql.append("       C.ACT_DQ4_YN    ,                                                        ");
	    sql.append("       C.ACT_TIME_YN   ,                                                        ");
	    sql.append("       C.DIRECT_CONT_YN,                                                        ");
	    sql.append("       C.JISI_ORDER_GUBUN, 														");
	    sql.append("       IFNULL(C.JISI_CONTINUE_YN, 'Y') JISI_CONTINUE_YN 						");
	    sql.append("  FROM ( SELECT A.NUR_GR_CODE   ,                                               ");
	    sql.append("                A.NUR_GR_NAME   ,                                               ");
	    sql.append("                B.NUR_MD_CODE   ,                                               ");
	    sql.append("                B.NUR_MD_NAME   ,                                               ");
	    sql.append("                B.CNT_PERHOUR_YN,                                               ");
	    sql.append("                B.CNT_PERDAY_YN ,                                               ");
	    sql.append("                B.ACT_DAY_YN    ,                                               ");
	    sql.append("                B.FRENCH_YN     ,                                               ");
	    sql.append("                B.ACT_DQ1_YN    ,                                               ");
	    sql.append("                B.ACT_DQ2_YN    ,                                               ");
	    sql.append("                B.ACT_DQ3_YN    ,                                               ");
	    sql.append("                B.ACT_DQ4_YN    ,                                               ");
	    sql.append("                B.ACT_TIME_YN   ,                                               ");
	    sql.append("                B.DIRECT_CONT_YN,                                               ");
	    sql.append("                IFNULL(B.JISI_ORDER_GUBUN, '0')           JISI_ORDER_GUBUN, 	");
	    sql.append("                B.JISI_CONTINUE_YN, 											");
	    sql.append("                IFNULL(A.SORT_KEY, 99) NUR0110_SORT, 							");
	    sql.append("                IFNULL(B.SORT_KEY, 99) NUR0111_SORT 							");
	    sql.append("           FROM NUR0110 A, 														");
	    sql.append("                NUR0111 B 														");
	    sql.append("          WHERE A.HOSP_CODE   = :f_hosp_code 									");
	    sql.append("            AND B.NUR_GR_CODE = A.NUR_GR_CODE 									");
	    sql.append("			AND B.HOSP_CODE   = A.HOSP_CODE 									");
	    sql.append("            AND A.VALD        = 'Y' 											");
	    sql.append("            AND B.VALD        = 'Y' 											");
	    sql.append("            AND A.NUR_GR_CODE != '03'  											");
	    sql.append("            AND A.NUR_GR_CODE != '00'  											");
	    sql.append("          ) C 																	");
	    sql.append("ORDER BY C.NUR0110_SORT, C.NUR0111_SORT 										");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);

		List<OCS2005U00layDirectInfoInfo> list = new JpaResultMapper().list(query, OCS2005U00layDirectInfoInfo.class);
		return list;
	}

	@Override
	public List<NUR0110U00GrdNUR0110Info> getNUR0110U00GrdNUR0110Info(String hospCode, Integer startNum,
			Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_GR_CODE,                        ");
		sql.append("	       TRIM(A.NUR_GR_NAME),                  ");
		sql.append("	       A.VALD,                               ");
		sql.append("	       IFNULL(CAST(A.SORT_KEY AS CHAR), ''), ");
		sql.append("	       IFNULL(A.MENT, '')                    ");
		sql.append("	  FROM NUR0110 A                             ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code              ");
		sql.append("	   AND NUR_GR_CODE IS NOT NULL               ");
		sql.append("	 ORDER BY A.NUR_GR_CODE                      ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset					 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR0110Info> lstResult = new JpaResultMapper().list(query, NUR0110U00GrdNUR0110Info.class);
		return lstResult;		
	}
}

