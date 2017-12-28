package nta.med.data.dao.cms.impl;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.cms.CmsQuestion;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsQuestionRepositoryCustom;
import nta.med.data.model.cms.CmsQuestionInfo;
import nta.med.data.model.cms.CmsSurveyQuestionInfo;

public class CmsQuestionRepositoryImpl implements CmsQuestionRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CmsQuestionInfo> getListCmsQuestion(String hospCode, String departmentCode, String questionType,
			String questionContent, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging) {

		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.ID,													");
		sql.append("	        A.QUESTION_TYPE,										");
		sql.append("	        A.DEPARTMENT_CODE,										");
		sql.append("	        A.DEPARTMENT_NAME,										");
		sql.append("	        A.CONTENT												");
		sql.append("	FROM    cms_question A											");
		sql.append("	WHERE   A.HOSP_CODE = :f_hospCode								");
		
		if(!StringUtils.isEmpty(questionType)){
			sql.append("	  AND  A.QUESTION_TYPE = :f_questionType					");
		}
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("	  AND   A.DEPARTMENT_CODE = :f_departmentCode				");
		}
		
		
		if(!StringUtils.isEmpty(questionContent)){
			sql.append("  	  AND   A.CONTENT like :f_questionContent					");
		}
		
		sql.append("  	  AND   A.ACTIVE_FLG = 1										");
		
		// EDIT
		//sql.append("	ORDER BY A.CREATED												");
		if(!StringUtils.isEmpty(column) && !StringUtils.isEmpty(dir)){
			sql.append("  	  ORDER BY " + column + " " + dir);
		}
		if(isPaging)
		{
			sql.append("	LIMIT :f_startIndex, :f_endIndex								");
		}

		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", departmentCode);
		}
		if(!StringUtils.isEmpty(questionType)){
			query.setParameter("f_questionType", questionType);
		}
		
		// EDIT
//		if(!StringUtils.isEmpty(column) && !StringUtils.isEmpty(dir)){
//			query.setParameter("f_column", column);
//			query.setParameter("f_dir", dir);
//		}
		
		query.setParameter("f_hospCode", hospCode);
		if(!StringUtils.isEmpty(questionContent)){
			query.setParameter("f_questionContent", "%" + questionContent + "%");
		}
		if(isPaging)
		{
			query.setParameter("f_startIndex", startIndex);
			query.setParameter("f_endIndex", pageSize);
		}

		
		List<CmsQuestionInfo> listQuestion = new JpaResultMapper().list(query, CmsQuestionInfo.class);
		return listQuestion;
	}

	@Override
	public boolean deleteQuestionList(List<Long> questionIdList, String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE cms_question SET ACTIVE_FLG = 0 WHERE ACTIVE_FLG = 1 AND HOSP_CODE = :hospCode AND ID IN :f_questionIdList");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_questionIdList", questionIdList);
		query.setParameter("hospCode", hospCode);
		
		return query.executeUpdate() > 0;		
	}

	@Override
	public int countRecord(String hospCode, String departmentCode, String questionType, String questionContent) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  COUNT(1)												");

		sql.append("	FROM    cms_question A											");
		sql.append("	WHERE   A.HOSP_CODE = :f_hospCode								");
		
		if(!StringUtils.isEmpty(questionType)){
			sql.append("	  AND  A.QUESTION_TYPE = :f_questionType					");
		}
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("	  AND   A.DEPARTMENT_CODE = :f_departmentCode				");
		}
		
		
		if(!StringUtils.isEmpty(questionContent)){
			sql.append("  	  AND   A.CONTENT like :f_questionContent					");
		}
		
		sql.append("  	  AND   A.ACTIVE_FLG = 1										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		
		
		
		
		if(!StringUtils.isEmpty(questionType)){
			query.setParameter("f_questionType", questionType);
		}
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", departmentCode);
		}
		
		
		if(!StringUtils.isEmpty(questionContent)){
			query.setParameter("f_questionContent", questionContent);
		}
		
		List<Integer> listQuestion = new JpaResultMapper().list(query, Integer.class);
		if(!CollectionUtils.isEmpty(listQuestion)){
			return listQuestion.get(0);
		}
		return 0;
	}

	
}
