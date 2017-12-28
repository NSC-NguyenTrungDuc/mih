package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabyFood;
import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.BabyFoodRepositoryCustom;
import nta.med.data.model.phr.BabyFoodInfo;
import nta.med.data.model.phr.BabySleepInfo;

public class BabyFoodRepositoryImpl implements BabyFoodRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrBabyFood> getBabyFoodByLastestDay(Long profileId,
			Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a FROM PhrBabyFood a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.eatingTime DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrBabyFood> listResult = query.getResultList();
		return listResult;
	}

	@Override
	public List<BabyFoodInfo> getBabyFoodByDurationType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                           							    ");
		sql.append("     A.ID, A.EATING_TIME, A.FOOD, CAST(SUM(A.KCAL) AS CHAR),																		");
//		if(durationType != null){
//			if(DurationType.DAILY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()){
//				sql.append("       A.EATING_TIME,                                                      													");
//				sql.append("       A.FOOD,                                                                                                          	");
//				sql.append("       A.KCAL,                                                                                                        		");
//			}
//			if(DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.YEARLY.getValue() == durationType.intValue()){
//				sql.append("       MAX(A.EATING_TIME) EATING_TIME,                                                                            			");
//				sql.append("       A.FOOD,                                                                                                          	");
//				sql.append("       CAST(SUM(A.KCAL) AS CHAR),                                                                                           ");
//			}
//		}
		sql.append("       A.MEAL_TYPE,                                                                                                      			");
	//	sql.append("       DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') PERDAY                                                                           		");

		if(durationType != null && DurationType.DAILY.getValue() == durationType.intValue() ) {
			sql.append("       DATE_FORMAT(A.EATING_TIME, '%H') PERDAY                                                                                               ");
		}
		else if(durationType != null && ( DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()) )
		{
			sql.append("       DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') PERDAY               																			");
		}
		else if(durationType == DurationType.YEARLY.getValue())
		{
			sql.append("       DATE_FORMAT(A.EATING_TIME, '%M') PERDAY              																				");
		}


		sql.append("     FROM PHR_BABY_FOOD A                                                                                              				");
		sql.append("     WHERE 1 = 1                                                                                                                    ");
		sql.append("       AND A.ACTIVE_FLG = '1'		                                                                                                ");
		if(profileId != null){                                                                                                                          
			sql.append("       AND A.PROFILE_ID = :profileId                                                                                            ");
		}
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')   									");
			}
			if(DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -7 DAY), '%Y-%m-%d')    		");
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -30 DAY), '%Y-%m-%d')   		");
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");
				//sql.append("     GROUP BY PERDAY                                                                            							");
			}
			if(DurationType.YEARLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')  		");
				sql.append("         AND DATE_FORMAT(A.EATING_TIME, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");

			}
			sql.append("     GROUP BY PERDAY                                                                             							");
		}
		sql.append("     ORDER BY EATING_TIME		                                                                   									");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<BabyFoodInfo> babyFoodInfos = new JpaResultMapper().list(query, BabyFoodInfo.class);
		return babyFoodInfos;
	}
}
