package nta.med.data.dao.cms.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.cms.CmsQuestion;
import nta.med.core.domain.cms.CmsSurveyQuestionGroup;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsSurveyQuestionGroupRepositoryCustom;

public class CmsSurveyQuestionGroupRepositoryImpl implements CmsSurveyQuestionGroupRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<CmsSurveyQuestionGroup> listSurveyQuestionGroup() {
		
		StringBuilder sql = new StringBuilder();
		sql.append("		SELECT 		 B.ID,									");
		sql.append("					B.TITLE,								");
		sql.append("					B.SEQUENCE								");
		sql.append("					A.QUESTION_TYPE, 						");
		sql.append("					A.ALLOW_OTHER_FLG						");
		sql.append("		FROM 		cms_survey A, 							");
		sql.append("					cms_survey_question_group B				");
		sql.append("		WHERE      A.ID = B.CMS_SURVEY_ID					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		List<CmsSurveyQuestionGroup> listQuestionGroup = new JpaResultMapper().list(query, CmsSurveyQuestionGroup.class);
		return listQuestionGroup;
	
	}
	}


