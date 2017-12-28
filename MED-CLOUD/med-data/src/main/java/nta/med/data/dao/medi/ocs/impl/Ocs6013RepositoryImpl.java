package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs6013RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ocs6013RepositoryImpl implements Ocs6013RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callFnOcsLoadOrderPrtPgmId(String hospCode, String tableId, String key) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_LOAD_ORDER_PRT_PGM_ID(:f_hosp_code, :f_table_id, :f_key) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_table_id", tableId);
		query.setParameter("f_key", CommonUtils.parseInteger(key));
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public String getOCS6010U10GetCheckDupDirRequest(String hospCode, String fkocs6010, String inputGubun, String orderDate, String directGubun, String directCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT 'Y'     							");
		sql.append("	FROM OCS6013  						");
		sql.append(" WHERE HOSP_CODE    = :f_hosp_code 		");
		sql.append("	 AND FKOCS6010    = :f_fkocs6010    ");
		sql.append("	 AND INPUT_GUBUN  = :f_input_gubun  ");
//		sql.append("     AND ORDER_DATE   = :f_order_date 	");
//		sql.append("	 AND DIRECT_GUBUN = :f_direct_gubun ");
//		sql.append("	 AND DIRECT_CODE  = :f_direct_code  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", CommonUtils.parseDouble(fkocs6010));
		query.setParameter("f_input_gubun", inputGubun);
//		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
//		query.setParameter("f_direct_gubun", directGubun);
//		query.setParameter("f_direct_code", directCode);
		
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public Double getNextGroupSerOcs6013(String hospCode, Date orderDate, String inputGubun, Double fkocs6010) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(GROUP_SER), 0) + 1       T_GROUP_SER	");
		sql.append("	FROM OCS6013											");
		sql.append("	WHERE HOSP_CODE       = :f_hosp_code					");
		sql.append("	  AND PLAN_ORDER_DATE = :f_order_date					");
		sql.append("	  AND INPUT_GUBUN     = :f_input_gubun					");
		sql.append("	  AND FKOCS6010       = :f_fkocs6010					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_fkocs6010", fkocs6010);
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 0.0 : result.get(0);
	}
}

