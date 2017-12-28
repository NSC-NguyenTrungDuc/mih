package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.StandardTempTemperatureRepositoryCustom;
import nta.med.data.model.phr.StandardTempTemperatureInfo;

public class StandardTempTemperatureRepositoryImpl implements StandardTempTemperatureRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<StandardTempTemperatureInfo> getStandardTempTemperatureInfoByprofileIdAndDurationType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                            								");
		sql.append("       A.ID, A.DATE_MEASURE DATE_MEASURE,  AVG(A.TEMPERATURE),                                                                     ");
		sql.append("       A.NOTE,                                                                                         								");

		if(durationType != null && DurationType.DAILY.getValue() == durationType.intValue() ) {
			sql.append("       DATE_FORMAT(A.DATE_MEASURE, '%H') PERDAY ,                                                                                               ");
		}
		else if(durationType != null && ( DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()) )
		{
			sql.append("       DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') PERDAY ,              																			");
		}
		else if(durationType == DurationType.YEARLY.getValue())
		{
			sql.append("       DATE_FORMAT(A.DATE_MEASURE, '%M') PERDAY ,              																				");
		}

		sql.append("      COUNT(A.TEMPERATURE)                                                                                           											");
		sql.append("     FROM PHR_STANDARD_TEMP_TEMPERATURE A                                                                 							");
		sql.append("     WHERE 1 = 1                                                                                       								");
		sql.append("       AND A.ACTIVE_FLG = '1'		                                                                   								");
		if(profileId != null){                                                                                             
			sql.append("       AND A.PROFILE_ID = :profileId                                                               								");
		}
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')   								");
			}
			if(DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -7 DAY), '%Y-%m-%d')       	");
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -30 DAY), '%Y-%m-%d')       ");
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");
			}
			if(DurationType.YEARLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')      ");
				sql.append("         AND DATE_FORMAT(A.DATE_MEASURE, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        							");

			}
			sql.append("     GROUP BY PERDAY                                                                             							");
		}
		sql.append("     ORDER BY DATE_MEASURE		                                                                   	 								");
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<StandardTempTemperatureInfo> temperatureInfos = new JpaResultMapper().list(query, StandardTempTemperatureInfo.class);
		return temperatureInfos;
	}
}
