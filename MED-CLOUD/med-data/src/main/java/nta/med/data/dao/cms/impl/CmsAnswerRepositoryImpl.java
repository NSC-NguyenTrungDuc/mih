package nta.med.data.dao.cms.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.cms.CmsAnswer;
import nta.med.core.domain.cms.CmsSurveyQuestionGroup;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsAnswerRepositoryCustom;

public class CmsAnswerRepositoryImpl implements CmsAnswerRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	}


