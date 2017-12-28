package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs5011RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANSSangSendAllInfo;

/**
 * @author dainguyen.
 */
public class Ifs5011RepositoryImpl implements Ifs5011RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSSangSendAllInfo> getORDERTRANSSangSendAllInfo(
			String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFS_KEY FROM IFS5011 WHERE HOSP_CODE = :f_hosp_code AND IF_FLAG = 'N'   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<ORDERTRANSSangSendAllInfo> list = new JpaResultMapper().list(query, ORDERTRANSSangSendAllInfo.class);
		return list;
	}
}

