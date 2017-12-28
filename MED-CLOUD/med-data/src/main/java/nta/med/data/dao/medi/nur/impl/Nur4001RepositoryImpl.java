package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur4001RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR4001U00GrdNUR4001Info;
import nta.med.data.model.ihis.nuri.NUR9001U00layComboNur4001Info;
import nta.med.data.model.ihis.nuri.NUR9001U00layNur4001Info;

/**
 * @author dainguyen.
 */
public class Nur4001RepositoryImpl implements Nur4001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR4001U00GrdNUR4001Info> getNUR4001U00GrdNUR4001Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.PKNUR4001                                                                                                       ");
		sql.append("        , A.FKINP1001                                                                                                       ");
		sql.append("        , A.BUNHO                                                                                                           ");
		sql.append("        , A.NUR_PLAN_JIN                                                                                                    ");
		sql.append("        , A.NUR_PLAN_JIN_NAME                                                                                               ");
		sql.append("        , DATE_FORMAT(A.PLAN_DATE, '%Y/%m/%d')                                                                              ");
		sql.append("        , IFNULL(DATE_FORMAT(FN_NUR_PLAN_END_DATE(A.HOSP_CODE, A.PKNUR4001, SYSDATE()), '%Y/%m/%d'), '') END_DATE        	");
		sql.append("        , IFNULL(DATE_FORMAT(FN_NUR_PLAN_RECENT_VALU(A.HOSP_CODE, A.PKNUR4001, SYSDATE()), '%Y/%m/%d'), '') RESER_DATE   	");
		sql.append("        , A.PLAN_USER                                                                                        				");
		sql.append("        , IFNULL(FN_ADM_LOAD_USER_NM(A.HOSP_CODE,A.PLAN_USER, IFNULL(A.PLAN_DATE, SYSDATE())), '') PLAN_USER_NAME			");
		sql.append("        , CAST(A.SORT_KEY AS CHAR)                                                                                          ");
		sql.append("        , A.PURPOSE                                                                                                         ");
		sql.append("     FROM NUR4001 A                                                                                                         ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                                        ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001                                                                                        ");
		sql.append("    ORDER BY SORT_KEY, A.PKNUR4001                                                                                          ");		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																			 				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR4001U00GrdNUR4001Info> listInfo = new JpaResultMapper().list(query, NUR4001U00GrdNUR4001Info.class);
		return listInfo;
	}
	
	@Override
	public void callPrNurNur4001Delete(String hospCode, Double pknur4001) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_NUR_NUR4001_DELETE");

		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKNUR4001", Double.class, ParameterMode.IN);

		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKNUR4001", pknur4001);
		query.execute();
	}
	
	@Override
	public List<NUR9001U00layNur4001Info> getNUR9001U00layNur4001Info(String hospCode, String bunho, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT M.PKNUR4001                   ,                                                                                             ");
		sql.append("          M.BUNHO                       ,                                                                                             ");
		sql.append("          M.FKINP1001                   ,                                                                                             ");
		sql.append("          M.NUR_PLAN_JIN                ,                                                                                             ");
		sql.append("          M.NUR_PLAN_JIN_NAME           ,                                                                                             ");
		sql.append("          M.PURPOSE                     ,                                                                                             ");
		sql.append("          M.PLAN_USER                   ,                                                                                             ");
		sql.append("          M.PLAN_DATE                   ,                                                                                             ");
		sql.append("          M.PKNUR4003                   ,                                                                                             ");
		sql.append("          M.NUR_PLAN                    ,                                                                                             ");
		sql.append("          M.NUR_PLAN_OTE                ,                                                                                             ");
		sql.append("          '' N                          ,                                                                                             ");
		sql.append("          M.PKNUR4004                   ,                                                                                             ");
		sql.append("          M.NUR_PLAN_DETAIL             ,                                                                                             ");
		sql.append("          M.NUR_PLAN_DENAME             ,                                                                                             ");
		sql.append("          FN_ADM_LOAD_USER_NM(:f_hosp_code, M.PLAN_USER, SYSDATE()) PLAN_USER_NAME,                                                   ");
		sql.append("          M.NUR_PLAN_NAME               ,                                                                                             ");
		sql.append("          M.NUR4001_VALD                  NUR4001_VALD,                                                                               ");
		sql.append("          DATE_FORMAT(M.VALU_DATE,'%Y/%m/%d')                  VALU_DATE                                                              ");
		sql.append("     FROM ( SELECT A.PKNUR4001                   ,                                                                                    ");
		sql.append("                   A.BUNHO                       ,                                                                                    ");
		sql.append("                   A.FKINP1001                   ,                                                                                    ");
		sql.append("                   A.NUR_PLAN_JIN                ,                                                                                    ");
		sql.append("                   A.PURPOSE                     ,                                                                                    ");
		sql.append("                   CASE(IFNULL(A.SORT_KEY,'')) WHEN '' THEN A.NUR_PLAN_JIN_NAME ELSE CONCAT('#', A.SORT_KEY, ' ',A.NUR_PLAN_JIN_NAME) ");
		sql.append("                         END  NUR_PLAN_JIN_NAME  ,                                                                                    ");
		sql.append("                   A.PLAN_USER                   ,                                                                                    ");
		sql.append("                   DATE_FORMAT(A.PLAN_DATE,'%Y/%m/%d') PLAN_DATE ,                                                                    ");
		sql.append("                   D.PKNUR4003                   ,                                                                                    ");
		sql.append("                   CAST(D.NUR_PLAN AS CHAR)  NUR_PLAN    ,                                                                            ");
		sql.append("                   D.NUR_PLAN_OTE                ,                                                                                    ");
		sql.append("                   D.NUR_PLAN_NAME               ,                                                                                    ");
		sql.append("                   E.PKNUR4004                   ,                                                                                    ");
		sql.append("                   E.NUR_PLAN_DETAIL             ,                                                                                    ");
		sql.append("                   E.NUR_PLAN_DENAME             ,                                                                                    ");
		sql.append("                   A.SORT_KEY        NUR4001_SORT,                                                                                    ");
		sql.append("                   D.SORT_KEY        NUR4003_SORT,                                                                                    ");
		sql.append("                   CASE(D.NUR_PLAN_OTE) WHEN 'P' THEN '1' WHEN 'O' THEN '2' WHEN 'T' THEN '3' ELSE '4' END OTE_GUBUN,                 ");
		sql.append("                   E.SORT_KEY        NUR4004_SORT,                                                                                    ");
		sql.append("                   CASE(FN_NUR_PLAN_END_DATE(A.HOSP_CODE, A.PKNUR4001, SYSDATE())) WHEN NULL THEN 'Y' ELSE 'N' END  NUR4001_VALD,     ");
		sql.append("                   FN_NUR_PLAN_RECENT_VALU(A.HOSP_CODE, A.PKNUR4001, SYSDATE()) VALU_DATE                                             ");
		sql.append("              FROM NUR4001 A                                                                                                          ");
		sql.append("              JOIN NUR4003 D                                                                                                          ");
		sql.append("                ON D.HOSP_CODE          = A.HOSP_CODE                                                                                 ");
		sql.append("               AND D.FKNUR4001          = A.PKNUR4001                                                                                 ");
		sql.append("               AND IFNULL(D.VALD, 'N')  = 'Y'                                                                                         ");
		sql.append("              LEFT JOIN NUR4004 E                                                                                                     ");
		sql.append("                ON E.HOSP_CODE          = D.HOSP_CODE                                                                                 ");
		sql.append("               AND E.FKNUR4003          = D.PKNUR4003                                                                                 ");
		sql.append("               AND E.VALD                = 'Y'                                                                                        ");
		sql.append("             WHERE A.HOSP_CODE          = :f_hosp_code                                                                                ");
		sql.append("               AND A.BUNHO              = :f_bunho                                                                                    ");
		sql.append("               AND A.FKINP1001          = :f_fkinp1001                                                                                ");
		sql.append("               ) M                                                                                                                    ");
		sql.append("   ORDER BY IFNULL(M.NUR4001_SORT, 99)                                                                                                ");
		sql.append("          , CONCAT(LPAD(M.PKNUR4001, 15,'0'),                                                                                         ");
		sql.append("            DATE_FORMAT(M.PLAN_DATE, '%Y%m%d'),                                                                                       ");
		sql.append("            M.OTE_GUBUN,                                                                                                              ");
		sql.append("            LTRIM(LPAD(IFNULL(M.NUR4003_SORT, 99), 2, '0')),                                                                          ");
		sql.append("            LTRIM(LPAD(IFNULL(M.NUR4004_SORT, 99), 2, '0')))                                                                          ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		
		List<NUR9001U00layNur4001Info> listInfo = new JpaResultMapper().list(query, NUR9001U00layNur4001Info.class);
		return listInfo;
	}
	
	@Override
	public List<NUR9001U00layComboNur4001Info> getNUR9001U00layComboNur4001Info(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT M.PKNUR4001,                         ");
		sql.append("          M.NUR_PLAN_JIN_NAME,                 ");
		sql.append("          CAST(M.SORT_KEY AS CHAR)             ");
		sql.append("   FROM(                                       ");
		sql.append("   SELECT NULL PKNUR4001,                      ");
		sql.append("          '-' NUR_PLAN_JIN_NAME,               ");
		sql.append("          0  SORT_KEY                          ");
		sql.append("     FROM DUAL                                 ");
		sql.append("    UNION ALL                                  ");
		sql.append("   SELECT 0 PKNUR4001,                         ");
		sql.append("          'T' NUR_PLAN_JIN_NAME,               ");
		sql.append("          1  SORT_KEY                          ");
		sql.append("     FROM DUAL                                 ");
		sql.append("    UNION ALL                                  ");
		sql.append("   SELECT A.PKNUR4001,                         ");
		sql.append("          A.NUR_PLAN_JIN_NAME,                 ");
		sql.append("          IFNULL(A.SORT_KEY+1, 99) SORT_KEY    ");
		sql.append("     FROM NUR4001 A                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code           ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001           ");
		sql.append("    ORDER BY SORT_KEY, PKNUR4001) M            ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<NUR9001U00layComboNur4001Info> listInfo = new JpaResultMapper().list(query, NUR9001U00layComboNur4001Info.class);
		return listInfo;
	}
}

