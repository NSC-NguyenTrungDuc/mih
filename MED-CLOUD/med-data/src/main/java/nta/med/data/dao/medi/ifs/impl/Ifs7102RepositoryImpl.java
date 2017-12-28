package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.ifs.Ifs7102RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ifs7102RepositoryImpl implements Ifs7102RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Double getMaxSeq(String hospCode, String seqKey){
		StringBuilder sql = new StringBuilder("SELECT FN_MAXSEQ(:f_hosp_code, 'IFS7102' , 'SEQ', :f_seq_key, '0')");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_seq_key", seqKey);
		
		List<Double> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		return null;
	}
}

