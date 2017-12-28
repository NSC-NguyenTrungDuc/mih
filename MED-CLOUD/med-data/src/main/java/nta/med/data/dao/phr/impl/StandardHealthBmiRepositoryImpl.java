package nta.med.data.dao.phr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.DurationType;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.phr.StandardHealthBmiRepositoryCustom;
import nta.med.data.model.phr.HealthBmiInfo;

public class StandardHealthBmiRepositoryImpl implements StandardHealthBmiRepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<HealthBmiInfo> getPhrStandardHealthBmiByprofileIdAndType(Long profileId, Long durationType) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT                                                                                                                                             ");
		sql.append("       A.ID,                                                                                                                                            ");
		sql.append("       A.DATETIME_RECORD DATETIME_RECORD,                                                      	                                                        ");
		sql.append("      AVG(A.BMI),                                                                                                                                        	");
		sql.append("       A.NOTE,                                                                                                                                          ");
		//sql.append("       DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') PERDAY                                                                                                ");

		if(durationType != null && DurationType.DAILY.getValue() == durationType.intValue() ) {
			sql.append("       DATE_FORMAT(A.DATETIME_RECORD, '%H') PERDAY ,                                                                                               ");
		}
		else if(durationType != null && ( DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.WEEKLY.getValue() == durationType.intValue()) )
		{
			sql.append("       DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') PERDAY ,              																			");
		}
		else if(durationType == DurationType.YEARLY.getValue())
		{
			sql.append("       DATE_FORMAT(A.DATETIME_RECORD, '%M') PERDAY ,              																				");
		}

		sql.append("      COUNT(A.BMI)                                                                                           											");
		sql.append("     FROM PHR_STANDARD_HEALTH_BMI A                                                                                                                  	");
		sql.append("     WHERE 1 = 1                                                                                                                                        ");
		sql.append("       AND A.ACTIVE_FLG = '1'		                                                                                                                    ");
		if(profileId != null){                                                                                                                                              
			sql.append("       AND A.PROFILE_ID = :profileId                                                                                                                ");
		}
		if(durationType != null){
			if(DurationType.DAILY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') = DATE_FORMAT(SYSDATE(), '%Y-%m-%d')   													");
			}
			if(DurationType.WEEKLY.getValue() == durationType.intValue()){
				sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -7 DAY), '%Y-%m-%d')       					");
				sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        											");
			}
			if(DurationType.MONTHLY.getValue() == durationType.intValue() || DurationType.YEARLY.getValue() == durationType.intValue()){

				if(DurationType.MONTHLY.getValue() == durationType.intValue()){
					sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -30 DAY), '%Y-%m-%d')       				");
					sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        										");
				}
				if(DurationType.YEARLY.getValue() == durationType.intValue()){
					sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') > DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL -365 DAY), '%Y-%m-%d')       			");
					sql.append("         AND DATE_FORMAT(A.DATETIME_RECORD, '%Y-%m-%d') <= DATE_FORMAT(CURDATE(), '%Y-%m-%d')        										");
				}

			}
			sql.append("                         GROUP BY PERDAY                                                                                                        ");
		}
		sql.append("     ORDER BY DATETIME_RECORD		                                                                   	 												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if(profileId != null){
			query.setParameter("profileId", profileId);
		}
		List<HealthBmiInfo> standardHealthHeights = new JpaResultMapper().list(query, HealthBmiInfo.class);
		return standardHealthHeights;
	}

}
