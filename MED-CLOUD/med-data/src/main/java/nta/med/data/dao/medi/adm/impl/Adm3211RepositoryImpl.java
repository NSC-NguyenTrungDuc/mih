package nta.med.data.dao.medi.adm.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm3211RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Adm3211RepositoryImpl implements Adm3211RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getLoadColumnCodeNameUserId(String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.USER_NM 													");
		sql.append("	 FROM ADM3211 A                                                     ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode                                      ");
		sql.append("	  AND A.USER_ID    = :userId                                        ");
		sql.append("	  AND A.START_DATE = ( SELECT MAX(Z.START_DATE)                     ");
		sql.append("	                         FROM ADM3211 Z                             ");
		sql.append("	                        WHERE Z.HOSP_CODE  = A.HOSP_CODE            ");
		sql.append("	                          AND Z.USER_ID    = A.USER_ID              ");
		sql.append("	                          AND Z.START_DATE <= SYSDATE() )          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userId", userId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOCS0150Q00FindboxMemb(String hospCode,String language,String find) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%', FN_ADM_MSG('221',:f_language)                              ");
		sql.append("   UNION ALL                                                            ");
		sql.append("  SELECT A.USER_ID, B.USER_NM                                           ");
		sql.append("    FROM ADM3200 A, ADM3211 B                                           ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                     ");
		sql.append("     AND A.USER_ID = B.USER_ID                                          ");
		sql.append("     AND B.START_DATE = ( SELECT MAX(X.START_DATE)                      ");
		sql.append("                            FROM ADM3211 X                              ");
		sql.append("                           WHERE X.HOSP_CODE = :f_hosp_code             ");
		sql.append("                             AND B.HOSP_CODE = X.HOSP_CODE              ");
		sql.append("                             AND X.USER_ID = B.USER_ID                  ");
		sql.append("                             AND X.START_DATE <= SYSDATE() )            ");
		sql.append("     AND B.USER_NM LIKE :f_find1                                        ");
		sql.append("   ORDER BY 2, 1														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_find1", find+"%");
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getNUR6011U01LoadUserNm(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();

		sql.append("   SELECT IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, :f_code, SYSDATE()), '') FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public String callFnAdmLoadUserNm(String hospCode, String code, Date fdate) {
		StringBuilder sql = new StringBuilder();

		sql.append("   SELECT IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, :f_code, :f_date), '') FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_date", fdate);
		
		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}
}

