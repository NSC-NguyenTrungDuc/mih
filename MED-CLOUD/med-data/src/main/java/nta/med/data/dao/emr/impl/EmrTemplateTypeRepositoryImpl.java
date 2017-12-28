package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.emr.EmrTemplateTypeRepositoryCustom;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateTypeInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateTypeInfo;

public class EmrTemplateTypeRepositoryImpl implements EmrTemplateTypeRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<OCS2015U31EmrTemplateTypeInfo> getTemplateTyeListItemInfo (String language){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.EMR_TEMPLATE_TYPE_ID				         ");
		sql.append("	      , ''   TYPE_CODE                   	         ");
		sql.append("	      , A.TYPE_NAME                      	         ");
		sql.append("	       , ''   DESCRIPTION                	         ");
		sql.append("	FROM EMR_TEMPLATE_TYPE A 	                         ");
		sql.append("	WHERE  A.ACTIVE_FLG = '1'                            ");
		sql.append("	  AND  A.LANGUAGE = :f_language                      ");
		sql.append("	ORDER BY A.EMR_TEMPLATE_TYPE_ID                      ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		
		List<OCS2015U31EmrTemplateTypeInfo> list = new JpaResultMapper().list(query, OCS2015U31EmrTemplateTypeInfo.class);
		return list;
	}

	public List<OCS2015U06EmrTemplateTypeInfo> getOCS2015U06EmrTemplateTypeInfo(String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT									");
		sql.append("	EMR_TEMPLATE_TYPE_ID,					");
		sql.append("	TYPE_CODE,								");
		sql.append("	TYPE_NAME,								");
		sql.append("	TYPE_TAG,								");
		sql.append("	DESCRIPTION,							");
		sql.append("	ACTIVE_FLG,								");
		sql.append("	CREATED,								");
		sql.append("	UPDATED									");
		sql.append("	FROM EMR_TEMPLATE_TYPE					");
		sql.append("	WHERE ACTIVE_FLG='1'					");
		sql.append("	  AND LANGUAGE = :f_language            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);

		List<OCS2015U06EmrTemplateTypeInfo> list = new JpaResultMapper().list(query, OCS2015U06EmrTemplateTypeInfo.class);
		return list;
	}

}
