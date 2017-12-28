package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabyGrowth;
import nta.med.data.dao.phr.BabyGrowthRepositoryCustom;

public class BabyGrowthRepositoryImpl implements BabyGrowthRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrBabyGrowth> getBabyGrowthByLastestDay(Long profileId,
			Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a FROM PhrBabyGrowth a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timeMeasure DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrBabyGrowth> listResult = query.getResultList();
		return listResult;
	}
	
	
}
