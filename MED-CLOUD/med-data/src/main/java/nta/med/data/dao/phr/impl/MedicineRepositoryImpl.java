package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrMedicine;
import nta.med.data.dao.phr.MedicineRepositoryCustom;

public class MedicineRepositoryImpl implements MedicineRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrMedicine> getMedicineByLastestDay(Long profileId, Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a FROM PhrMedicine a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timeTakeMedicine DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrMedicine> listResult = query.getResultList();
		return listResult;
	}
}
