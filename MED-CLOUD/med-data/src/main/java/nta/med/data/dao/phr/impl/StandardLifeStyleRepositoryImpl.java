package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.StandardLifeStyleRepositoryCustom;
import nta.med.data.model.phr.StandardLifeStyleInfo;

public class StandardLifeStyleRepositoryImpl implements StandardLifeStyleRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<StandardLifeStyleInfo> getStandardLifeStyleByDurationType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                           							    ");
		sql.append("       A.ID,                                                                                           								");
		sql.append("       A.NOTE,                                                                                           							");
		sql.append("       A.PROFILE_ID,                                                                                           						");
		sql.append("       A.RATING_SLEEP,                                                                                           					");
		sql.append("       A.TIME_AWAKE, A.TIME_START_SLEEP, A.TIME_WAKE_UP, SUM(A.TOTAL_HOUR_SLEEP),                                                                                           						");
//		if(durationType != null){
//			if(DurationType.DAILY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()){
//				sql.append("       A.TIME_START_SLEEP,                                                      											");
//				sql.append("       A.TIME_WAKE_UP,                                                                                                      ");
//				sql.append("       CAST(A.TOTAL_HOUR_SLEEP AS DECIMAL),                                                                                 ");
//			}
//			if(DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.YEARLY.getValue() == durationType.intValue()){
//				sql.append("       MAX(A.TIME_START_SLEEP) TIME_START_SLEEP,                                                                            ");
//				sql.append("       A.TIME_WAKE_UP,                                                                                                      ");
//				sql.append("       SUM(A.TOTAL_HOUR_SLEEP),                                                                                             ");
//			}
//		}
		//sql.append("       DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') PERDAY                                                                           ");

		if(durationType != null && DurationType.DAILY.getValue() == durationType.intValue() ) {
			sql.append("       DATE_FORMAT(A.TIME_START_SLEEP, '%H') PERDAY                                                                                               ");
		}
		else if(durationType != null && ( DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()) )
		{
			sql.append("       DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') PERDAY              																			");
		}
		else if(durationType == DurationType.YEARLY.getValue())
		{
			sql.append("       DATE_FORMAT(A.TIME_START_SLEEP, '%M') PERDAY               																				");
		}

		sql.append("     FROM PHR_STANDARD_LIFE_STYLE A                                                                                              	");
		sql.append("     WHERE 1 = 1                                                                                                                    ");
		sql.append("       AND A.ACTIVE_FLG = '1'		                                                                                                ");
		if(profileId != null){                                                                                                                          
			sql.append("       AND A.PROFILE_ID = :profileId                                                                                            ");
		}
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')   							");
			}
			if(DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -7 DAY), '%Y-%m-%d')    ");
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        						");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -30 DAY), '%Y-%m-%d')   ");
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        						");

			}
			if(DurationType.YEARLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')  ");
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        						");
				//sql.append("     GROUP BY PERDAY                                                                             							");
			}
			sql.append("     GROUP BY PERDAY                                                                            							");
		}
		sql.append("     ORDER BY TIME_START_SLEEP		                                                                   								");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<StandardLifeStyleInfo> standardLifeStyleInfos = new JpaResultMapper().list(query, StandardLifeStyleInfo.class);
		return standardLifeStyleInfos;
	}
	
}
