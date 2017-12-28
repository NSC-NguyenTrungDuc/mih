package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabyDiaper;
import nta.med.data.dao.phr.BabyDiaperRepositoryCustom;

public class BabyDiaperRepositoryImpl implements BabyDiaperRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrBabyDiaper> getBabyDiaperByLastestDay(Long profileId,
			Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a FROM PhrBabyDiaper a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timePeePoo DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrBabyDiaper> listResult = query.getResultList();
		return listResult;
	}
	
	
}
