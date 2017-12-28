package nta.med.data.dao.medi.com.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.com.ComSeqRepositoryCustom;

/**
 * @author dainguyen.
 */
public class ComSeqRepositoryImpl implements ComSeqRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Double getMaxSeq(String hospCode, String keyObj, String keyType, String key){
		StringBuilder sql = new StringBuilder();
		
		sql.append("select FN_MAXSEQ(:f_hosp_code,:f_key_obj,:f_key_type,:f_key,'0')");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_key_obj", keyObj);
		query.setParameter("f_key_type", keyType);
		query.setParameter("f_key", key);
		
		List<Double> list = query.getResultList();
		if(list != null){
			return list.get(0);
		}
		return null;
	}
}

