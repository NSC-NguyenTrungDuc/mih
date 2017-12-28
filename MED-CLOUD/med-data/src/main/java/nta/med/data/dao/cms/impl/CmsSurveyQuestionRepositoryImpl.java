package nta.med.data.dao.cms.impl;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsSurveyQuestionRepositoryCustom;
import nta.med.data.model.cms.CmsSurveyQuestionInfo;

public class CmsSurveyQuestionRepositoryImpl implements CmsSurveyQuestionRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CmsSurveyQuestionInfo> getQuestionInfo(BigInteger questionGroupId) {
		StringBuilder sql = new StringBuilder();
		sql.append("		SELECT 		A.ID,														");
		sql.append("					A.CONTENT,													");
		sql.append("					A.DESCRIPTION,												");
		sql.append("					B.SEQUENCE SEQUENCE,										");
		sql.append("					B.REQUIRED_FLG,												");
		sql.append("					A.ALLOW_OTHER_FLG,											");
		sql.append("					A.QUESTION_TYPE, 											");
		
		sql.append("					B.CMS_SURVEY_QUESTION_GROUP_ID 								");

		sql.append("		FROM 		cms_question A, 											");
		sql.append("					cms_survey_question B										");
		
		sql.append("	WHERE			 A.ID = B.CMS_QUESTION_ID   								");
		sql.append("	AND      A.ACTIVE_FLG = 1													");
		sql.append("	AND      B.ACTIVE_FLG = 1													");
		sql.append("	AND      B.CMS_SURVEY_QUESTION_GROUP_ID = :f_questionGroupId				");
		sql.append("	ORDER BY SEQUENCE ASC														");
				
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_questionGroupId", questionGroupId);
		List<CmsSurveyQuestionInfo> listQuestionInfo = new JpaResultMapper().list(query, CmsSurveyQuestionInfo.class);
		return listQuestionInfo;
	
	}
	
}
