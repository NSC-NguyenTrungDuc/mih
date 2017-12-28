package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0404RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0401U01GrdNur0404Info;

/**
 * @author dainguyen.
 */
public class Nur0404RepositoryImpl implements Nur0404RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR0401U01GrdNur0404Info> getNUR0401U01GrdNur0404Info(String hospCode, String nurPlanJin,
			String nurPlan, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT NUR_PLAN_JIN,                                 ");
		sql.append("	       IFNULL(NUR_PLAN_PRO, ''),                     ");
		sql.append("	       IFNULL(CAST(NUR_PLAN AS CHAR), ''),           ");
		sql.append("	       NUR_PLAN_DETAIL,                              ");
		sql.append("	       FROM_DATE,                                    ");
		sql.append("	       END_DATE,                                     ");
		sql.append("	       NUR_PLAN_DENAME,                              ");
		sql.append("	       CAST(IFNULL(SORT_KEY, 99) AS CHAR) SORT_KEY,  ");
		sql.append("	       IFNULL(VALD,'N')                   VALD       ");
		sql.append("	  FROM NUR0404                                       ");
		sql.append("	 WHERE HOSP_CODE      = :f_hosp_code                 ");
		sql.append("	   AND NUR_PLAN_JIN   = :f_nur_plan_jin              ");
		sql.append("	   AND NUR_PLAN       = :f_nur_plan                  ");
		sql.append("	 ORDER BY IFNULL(SORT_KEY, 99), NUR_PLAN_DETAIL      ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset							 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_plan_jin", nurPlanJin);
		query.setParameter("f_nur_plan", nurPlan);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0401U01GrdNur0404Info> lstResult = new JpaResultMapper().list(query, NUR0401U01GrdNur0404Info.class);
		return lstResult;	
	}

	@Override
	public String getNUR0401U01SelectNewCode0404(String hospCode, String maxVal, String nurPlanJin, String nurPlan) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT TRIM(LPAD(GREATEST(IFNULL(MAX(NUR_PLAN_DETAIL),0), :f_max_val)+1, 2, '0')) NEW_CODE ");
		sql.append("	FROM NUR0404                                                                               ");
		sql.append("	WHERE HOSP_CODE   = :f_hosp_code                                                           ");
		sql.append("	AND NUR_PLAN_JIN  = :f_nur_plan_jin                                                        ");
		sql.append("	AND NUR_PLAN      = :f_nur_plan                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_plan_jin", nurPlanJin);
		query.setParameter("f_nur_plan", nurPlan);
		query.setParameter("f_max_val", maxVal);
		
		List<String> lst = query.getResultList();
		return CollectionUtils.isEmpty(lst) ? "" : lst.get(0);
	}

	@Override
	public Integer deleteNur0404InNUR0401U01(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE FROM NUR0404                                             ");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code                               ");
		sql.append("	  AND NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN                    ");
		sql.append("	                          FROM NUR0401 B                        ");
		sql.append("	                         WHERE B.HOSP_CODE       = :f_hosp_code ");
		sql.append("	                           AND B.NUR_PLAN_BUNRYU = :f_code)     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		return query.executeUpdate();
	}
}
