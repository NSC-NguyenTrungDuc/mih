package nta.med.data.dao.cms.impl;

import java.math.BigInteger;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.cms.CmsSurveyRepositoryCustom;

public class CmsSurveyRepositoryImpl implements CmsSurveyRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public boolean deleteSurvey(BigInteger surveyId, String hospCode) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE cms_survey SET ACTIVE_FLG = 0 WHERE ACTIVE_FLG = 1 AND ID = :f_surveyId AND HOSP_CODE = :hospCode ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_surveyId", surveyId);
		query.setParameter("hospCode", hospCode);
		
		return query.executeUpdate() > 0;		
	}
	
//	@Override
//	public List<CmsSurvey> getSurveyIdByDepartmentCode(String departmentCode) {
//		
//		StringBuilder sql = new StringBuilder();
//		sql.append("	SELECT  *													");
//		sql.append("	FROM    cms_survey A											");
//		sql.append("	WHERE   A.DEPARTMENT_CODE = :f_departmentCode					");
//		sql.append("	AND   A.DEFAULT_FLG = 1											");
//		
//		Query query = entityManager.createNativeQuery(sql.toString());
//		query.setParameter("f_departmentCode", departmentCode);
//		
//		List<CmsSurvey> surveyId = new JpaResultMapper().list(query, CmsSurvey.class);
//		
//		return surveyId;
//	}
	

}
