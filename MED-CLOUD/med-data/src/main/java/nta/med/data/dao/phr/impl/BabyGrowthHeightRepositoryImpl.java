package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabyGrowthHeight;
import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.BabyGrowthHeightRepositoryCustom;
import nta.med.data.model.phr.BabyGrowthHeightInfo;

public class BabyGrowthHeightRepositoryImpl implements BabyGrowthHeightRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BabyGrowthHeightInfo> getBabyGrowthHeightInfoByprofileIdAndDurationType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                                                                             ");
		sql.append("       A.ID,                                                                                                                                            ");
		sql.append("       A.TIME_MEASURE TIME_MEASURE,                                                      	                                                        	");
		sql.append("        AVG(A.HEIGHT),                                                                                                                                         ");
		sql.append("       A.DOCTOR_NOTE,                                                                                                                                   ");
		sql.append("       A.PARENT_NOTE,                                                                                         											");
		//sql.append("       DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') PERDAY                                                                                                	");

		if(durationType != null && DurationType.DAILY.getValue() == durationType.intValue() ) {
			sql.append("       DATE_FORMAT(A.TIME_MEASURE, '%H') PERDAY ,                                                                                               ");
		}
		else if(durationType != null && ( DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()) )
		{
			sql.append("       DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') PERDAY ,              																			");
		}
		else if(durationType == DurationType.YEARLY.getValue())
		{
			sql.append("       DATE_FORMAT(A.TIME_MEASURE, '%M') PERDAY ,              																				");
		}

		sql.append("      COUNT(A.HEIGHT)                                                                                           											");

		sql.append("     FROM PHR_BABY_GROWTH_HEIGHT A                                                                                                                  	");
		sql.append("     WHERE 1 = 1                                                                                                                                        ");
		sql.append("       AND A.ACTIVE_FLG = '1'		                                                                                                                    ");
		if(profileId != null){                                                                                                                                              
			sql.append("       AND A.PROFILE_ID = :profileId                                                                                                                ");
		}
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')   													");
			}
			if(DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -7 DAY), '%Y-%m-%d')       						");
				sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        												");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.YEARLY.getValue() == durationType.intValue()){
//				sql.append("         AND A.TIME_MEASURE IN (        																										");
//				sql.append("         	SELECT B.TIME_MEASURE  FROM (                                                                                                   	");
//				sql.append("                 SELECT                                                                                                                         ");
//				sql.append("                      MAX(A.TIME_MEASURE) TIME_MEASURE,                                                                                   		");
//				sql.append("                     DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') PERDAY                                                                          	");
//				sql.append("                   FROM PHR_BABY_GROWTH_HEIGHT A                                                                                            	");
//				sql.append("                   WHERE 1 = 1                                                                                                                  ");
//				sql.append("                         AND A.ACTIVE_FLG = '1'		                                                                                            ");
//				sql.append("                         AND A.PROFILE_ID = :profileId                                                                                          ");
				if(DurationType.MONTHLY.getValue() == durationType.intValue()){
					sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -30 DAY), '%Y-%m-%d')       				");
					sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        											");
				}
				if(DurationType.YEARLY.getValue() == durationType.intValue()){
					sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')       				");
					sql.append("         AND DATE_FORMAT(A.TIME_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        											");
				}

//				sql.append("               ) B                                                                                                                              ");
//				sql.append("             )                                                                                                                                  ");
			}
			sql.append("                         GROUP BY PERDAY                                                                                                        ");
		}
		sql.append("     ORDER BY TIME_MEASURE		                                                                   	 													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<BabyGrowthHeightInfo> babyGrowthHeightInfos = new JpaResultMapper().list(query, BabyGrowthHeightInfo.class);
		return babyGrowthHeightInfos;
	}

	@Override
	public List<PhrBabyGrowthHeight> getBabyGrowthHeightByLastestDay(Long profileId, Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT a FROM PhrBabyGrowthHeight a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timeMeasure DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrBabyGrowthHeight> listResult = query.getResultList();
		return listResult;
	}
}
