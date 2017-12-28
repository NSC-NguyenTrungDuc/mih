package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.phr.PhrBabySleep;
import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.BabySleepRepositoryCustom;
import nta.med.data.model.phr.BabySleepInfo;

public class BabySleepRepositoryImpl implements BabySleepRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PhrBabySleep> getBabySleepByLastestDay(Long profileId,
			Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT a FROM PhrBabySleep a WHERE a.profileId = :profileId AND a.activeFlg = 1 ORDER BY a.timeWakeUp DESC");
		
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("profileId", profileId);
		query.setMaxResults(limit);
		
		List<PhrBabySleep> listResult = query.getResultList();
		return listResult;
	}

	@Override
	public List<BabySleepInfo> getBabySleepInfoByprofileIdAndType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                           							    ");
		sql.append("       A.ID,                                                                                           								");
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("       A.TIME_START_SLEEP,                                                      											");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.YEARLY.getValue() == durationType.intValue()){
				sql.append("       MAX(A.TIME_START_SLEEP) TIME_START_SLEEP,                                                                            ");
			}
		}
		sql.append("       A.TOTAL_HOUR_SLEEP,                                                                                                          ");
		sql.append("       A.MORNING_TIME_SLEEP,                                                                                                        ");
		sql.append("       A.AFTERNOON_TIME_SLEEP,                                                                                                      ");
		sql.append("       A.NIGHT_TIME_SLEEP,                                                                                                          ");
		sql.append("       DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') PERDAY                                                                           ");
		sql.append("     FROM PHR_BABY_SLEEP A                                                                                              			");
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
				sql.append("     GROUP BY PERDAY                                                                            							");
			}
			if(DurationType.YEARLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')  ");
				sql.append("         AND DATE_FORMAT(A.TIME_START_SLEEP, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        						");
				sql.append("     GROUP BY PERDAY                                                                             							");
			}
		}
		sql.append("     ORDER BY TIME_START_SLEEP		                                                                   								");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<BabySleepInfo> babySleepInfos = new JpaResultMapper().list(query, BabySleepInfo.class);
		return babySleepInfos;
	}
	
	
}
