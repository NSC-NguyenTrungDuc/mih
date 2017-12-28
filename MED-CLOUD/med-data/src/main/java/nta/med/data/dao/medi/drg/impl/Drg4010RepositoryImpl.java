package nta.med.data.dao.medi.drg.impl;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.drg.Drg4010RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Drg4010RepositoryImpl implements Drg4010RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public BigDecimal getDrg4010Seq(String seqName){
		StringBuilder sql = new StringBuilder("SELECT SWF_NextVal(:f_seq_name)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_seq_name", seqName);
		
		List<BigDecimal> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		return null;
	}
	
	@Override
	public Double getMaxSeq(String hospCode, String seqKey){
		StringBuilder sql = new StringBuilder("SELECT FN_MAXSEQ(:f_hosp_code, 'DRG4010' , 'DRG_BUNHO_SEQ', :f_seq_key, '0')");
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

