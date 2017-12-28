package nta.med.data.dao.medi.kinki.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.kinki.RevisionRepositoryCustom;
import nta.med.data.model.ihis.system.CacheRevisionInfo;

public class RevisionRepositoryImpl implements RevisionRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<CacheRevisionInfo> getCacheRevisionInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT TABLE_NAME, REVISION FROM REVISION_SHARDING WHERE HOSP_CODE = :hosp_code     ");
		sql.append("UNION ALL                                                                           ");
		sql.append("SELECT TABLE_NAME, REVISION FROM REVISION_GLOBAL  ORDER BY 1                        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		List<CacheRevisionInfo> listResult = new JpaResultMapper().list(query, CacheRevisionInfo.class);
		return listResult;
	}
}
