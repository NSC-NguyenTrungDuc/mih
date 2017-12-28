package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0401RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR4001U00FwkJinInfo;

/**
 * @author dainguyen.
 */
public class Nur0401RepositoryImpl implements Nur0401RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getNUR0401U01SelectNewCode0401(String hospCode, String maxVal, String nurPlanBunryu) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CONCAT(:f_nur_plan_bunryu, TRIM(LPAD(GREATEST(IFNULL(MAX(SUBSTRING(NUR_PLAN_JIN,3)),0),:f_max_val)+1, 3, '0'))) NEW_CODE ");
		sql.append("	FROM NUR0401                                                                                                                    ");
		sql.append("	WHERE HOSP_CODE       = :f_hosp_code                                                                                            ");
		sql.append("	AND NUR_PLAN_BUNRYU = :f_nur_plan_bunryu                                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_max_val", maxVal);
		query.setParameter("f_nur_plan_bunryu", nurPlanBunryu);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
	
	@Override
	public List<NUR4001U00FwkJinInfo> getNUR4001U00FwkJinInfo(String hospCode, String nurPlanBunryu){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.NUR_PLAN_JIN,                                  ");
		sql.append("          A.NUR_PLAN_JIN_NAME,                             ");
		sql.append("          CAST(IFNULL(A.SORT_KEY, 99) AS CHAR) SORT_KEY    ");
		sql.append("     FROM NUR0401 A                                        ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code                      ");
		sql.append("      AND A.NUR_PLAN_BUNRYU = :f_nur_plan_bunryu           ");
		sql.append("      AND A.VALD = 'Y'                                     ");
		sql.append("    ORDER BY IFNULL(A.SORT_KEY, 99), A.NUR_PLAN_JIN        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_plan_bunryu", nurPlanBunryu);
		
		List<NUR4001U00FwkJinInfo> listInfo = new JpaResultMapper().list(query, NUR4001U00FwkJinInfo.class);
		return listInfo;
	}
 
}
