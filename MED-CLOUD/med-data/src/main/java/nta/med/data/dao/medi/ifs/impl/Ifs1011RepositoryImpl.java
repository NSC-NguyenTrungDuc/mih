package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs1011RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANSangTransInfo;

/**
 * @author dainguyen.
 */
public class Ifs1011RepositoryImpl implements Ifs1011RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSangTransInfo> getORDERTRANSangTransInfo(String hospCode, String fkout1003) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT PKIFS1011 FROM IFS1011 		                                                                        ");															
		sql.append("       	WHERE HOSP_CODE = :f_hosp_code                                                                        ");
		sql.append("   		AND FKOUT1003 = :f_fkout_1003                                                                       ");
		sql.append("   		AND IF_FLAG   = '10'		                                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkout_1003", fkout1003);
		
		List<ORDERTRANSangTransInfo> listORDERTRANSangTransInfo = new JpaResultMapper().list(query,ORDERTRANSangTransInfo.class);
		return listORDERTRANSangTransInfo;
	}
}

