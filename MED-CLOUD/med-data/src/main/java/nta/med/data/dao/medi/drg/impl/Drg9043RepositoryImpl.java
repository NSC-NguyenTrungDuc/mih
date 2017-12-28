package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.drg.Drg9043RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Drg9043RepositoryImpl implements Drg9043RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String checkDrgsDRG5100P01GetTimer(String currentTime, String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_DRG_LOAD_CHECK_DRG_TIME(DATE_FORMAT(SYSDATE(),'%Y%m%d'),:f_current_time,:f_hosp_code);");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_current_time", currentTime);
		query.setParameter("f_hosp_code", hospCode);
		
		List<Object> list = query.getResultList();
		if(list != null){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS6010U10PopupIfJusaConf(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IF(COUNT('Y') = 0, 'N', 'Y') CHK  																								");
		sql.append("	FROM DRG9043																															");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code																											");
		sql.append("	  AND DATE_FORMAT(SYSDATE(),'%Y%m%d%H%m%s') BETWEEN CONCAT(DATE_FORMAT(START_DATE,'%Y%m%d'), START_TIME) 								");
		sql.append("	                                                AND CONCAT(DATE_FORMAT(IFNULL(END_DATE,SYSDATE()),'%Y%m%d'), IFNULL(END_TIME,'9999'))	");
		sql.append("	  AND CANCEL_DATE IS NULL																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> list = query.getResultList();
		return list.get(0);
	}
}

