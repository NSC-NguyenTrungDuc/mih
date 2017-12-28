package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabyMilk;
import nta.med.data.dao.phr.BabyMilkRepositoryCustom;

public class BabyMilkRepositoryImpl implements BabyMilkRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrBabyMilk> getBabyMilkByLastestDay(Long profileId, Integer limit) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT a FROM PhrBabyMilk a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timeDrinkMilk DESC");

		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		 
		List<PhrBabyMilk> listResult = query.getResultList();
		return listResult;
	}

}
