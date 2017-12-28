package nta.med.data.dao.phr.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrStandardFoodMenu;
import nta.med.data.dao.phr.StandardFoodMenuRepositoryCustom;

public class StandardFoodMenuRepositoryImpl implements StandardFoodMenuRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<PhrStandardFoodMenu> getListStandardFoodByProfileId(
			Long profileId, Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" select a from PhrStandardFoodMenu a where a.profileId = :profileId order by eatingTime desc ");
		
		Query query  = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrStandardFoodMenu> listResult = query.getResultList();
		return listResult;
	}

	@Override
	public BigDecimal getTotalKcalByProfileId(Long profileId, Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUM(kcal) FROM PhrStandardFoodMenu a 	");
		sql.append("	WHERE a.profileId = :profileId					");
		sql.append("		AND a.eatingTime >= :fromDate				");
		sql.append("		AND a.eatingTime <= :toDate					");
		sql.append("		AND a.activeFlg = 1							");
		
		Query query  = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setParameter("fromDate", fromDate);
		query.setParameter("toDate", toDate);
		
		BigDecimal totalKcal = (BigDecimal)query.getSingleResult();
		return totalKcal;
	}
	
}
