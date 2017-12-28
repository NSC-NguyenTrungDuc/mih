package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.data.dao.medi.ocs.Ocs6015RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ocs6015RepositoryImpl implements Ocs6015RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String checkDupOcs6015InOcs6010U10(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun,
			String orderGubun, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'		                       ");
		sql.append("	FROM OCS6015	                       ");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code      ");
		sql.append("	  AND FKOCS6010    = :f_fkocs6010      ");
		sql.append("	  AND JAEWONIL     = :t_jaewonil       ");
		sql.append("	  AND INPUT_GUBUN  = :f_input_gubun    ");
		sql.append("	  AND DIRECT_GUBUN = :f_order_gubun    ");
		sql.append("	  AND DIRECT_CODE  = :f_hangmog_code   ");
		sql.append("	LIMIT 1								   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", fkocs6010);
		query.setParameter("t_jaewonil", jaewonil);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_hangmog_code", hangmogCode);

		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}

	@Override
	public Double getNextSeqOcs6015(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT IFNULL(MAX(PK_SEQ), 0) + 1	");
		sql.append("	FROM OCS6015						");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code	");
		sql.append("	  AND FKOCS6010    = :f_fkocs6010	");
		sql.append("	  AND JAEWONIL     = :t_jaewonil	");
		sql.append("	  AND INPUT_GUBUN  = :f_input_gubun	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", fkocs6010);
		query.setParameter("t_jaewonil", jaewonil);
		query.setParameter("f_input_gubun", inputGubun);
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 0.0 : result.get(0);
	}

	@Override
	public String checkPlanFromDateInOcs6010U10(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun,
			Double pk, String orderDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IF(SIGN(DATEDIFF(A.PLAN_FROM_DATE, STR_TO_DATE(:f_order_date, '%Y/%m/%d'))) = 0, 'Y', 'N')	");
		sql.append("	FROM OCS6015 A																						");
		sql.append("	WHERE HOSP_CODE       = :f_hosp_code	                                                            ");
		sql.append("	 AND FKOCS6010       = :f_fkocs6010		                                                            ");
		sql.append("	 AND JAEWONIL        = :f_jaewonil		                                                            ");
		sql.append("	 AND INPUT_GUBUN     = :f_input_gubun	                                                            ");
		sql.append("	 AND PK_SEQ          = :f_pk			                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", fkocs6010);
		query.setParameter("f_jaewonil", jaewonil);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk", pk);
		
		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}

	@Override
	public int updateOcs6015InOcs6010U10Case02(String hospCode, Double fkocs6010, Double jaewonil, String inputGubun,
			Double pk, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE OCS6015																			");
		sql.append("	SET PLAN_TO_DATE = DATE_ADD(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), INTERVAL - 1 DAY),	");
		sql.append("	    CONTINUE_YN  = 'N'																	");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code	                                                    ");
		sql.append("	  AND FKOCS6010    = :f_fkocs6010	                                                    ");
		sql.append("	  AND JAEWONIL     = :f_jaewonil	                                                    ");
		sql.append("	  AND INPUT_GUBUN  = :f_input_gubun	                                                    ");
		sql.append("	  AND PK_SEQ       = :f_pk			                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", fkocs6010);
		query.setParameter("f_jaewonil", jaewonil);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk", pk);
		
		return query.executeUpdate();
	}
}
