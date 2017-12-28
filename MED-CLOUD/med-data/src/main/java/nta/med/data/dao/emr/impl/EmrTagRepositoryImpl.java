package nta.med.data.dao.emr.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrTagRepositoryCustom;
import nta.med.data.model.ihis.emr.*;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

public class EmrTagRepositoryImpl implements EmrTagRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	public List<OCS2015U06EmrTagInfo> getOCS2015U06EmrTagInfo(String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" select distinct                                                                                             ");
		sql.append(" A.EMR_TAG_ID,	                                                                                             ");
		sql.append(" A.TAG_CODE,	                                                                                             ");
		sql.append(" A.TAG_NAME,	                                                                                             ");
		sql.append(" A.TAG_LEVEL,	                                                                                             ");
		sql.append(" A.TAG_PARENT,                                                                                               ");
		sql.append(" A.DESCRIPTION,	                                                                                             ");
		sql.append(" A.HOSP_CODE,	                                                                                             ");
		sql.append(" A.SYS_ID,	                                                                                                 ");
		sql.append(" A.FILTER_FLG,	                                                                                             ");
		sql.append(" A.ACTIVE_FLG,	                                                                                             ");
		sql.append(" A.CREATED,	                                                                                                 ");
		sql.append(" A.UPDATED	                                                                                                 ");
		sql.append(" from EMR_TAG A     ");
		//sql.append(" INNER JOIN EMR_TAG_RELATION B ON A.TAG_CODE = B.TAG_PARENT   OR A.TAG_CODE = B.TAG_CHILD      ");
		sql.append(" where A.FILTER_FLG = '1'	                                                                                 ");
		sql.append(" and A.HOSP_CODE = :hosp_code	                                                                             ");
		//sql.append(" AND B.HOSP_CODE = :hosp_code                                                                                ");
		sql.append(" and A.ACTIVE_FLG = '1'	                                                                                     ");
		//sql.append(" AND B.ACTIVE_FLG = '1' 																					 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);

		List<OCS2015U06EmrTagInfo> list = new JpaResultMapper().list(query, OCS2015U06EmrTagInfo.class);
		return list;
	}

	public List<OCS2015U30EmrTagGetTagInfo> getOCS2015U30EmrTagGetTagInfo (String tagLevel, String hospCode, String userId, String userGroup) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT EMR_TAG_ID									     ");
		sql.append("	     , TAG_CODE                                          ");
		sql.append("	     , TAG_NAME                                          ");
		sql.append("	     , TAG_DISPLAY_TEXT                                  ");
		sql.append("	     , DESCRIPTION                                       ");
		sql.append("         , TAG_LEVEL                                         ");
		sql.append("	     , FILTER_FLG                                        ");
		sql.append("	     , TAG_PARENT                                        ");
		sql.append("	     , SYS_ID	                                         ");
		sql.append("	FROM EMR_TAG                                             ");
		sql.append("	   WHERE ACTIVE_FLG = '1'                                ");
		sql.append("	     AND HOSP_CODE = :f_hosp_code                        ");
		// get All Tag_Level so remove confition TAG_LEVEL = :f_tag_level 
		if (!"ADMIN".equals(userGroup)) {
			sql.append("	     AND (SYS_ID = :f_user_id OR PERMISSION_TYPE = 'S')  ");
		}
		sql.append("	ORDER BY EMR_TAG_ID                                          ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if (!"ADMIN".equals(userGroup)) {
			query.setParameter("f_user_id", userId);
		}
		
		List<OCS2015U30EmrTagGetTagInfo> list = new JpaResultMapper().list(query, OCS2015U30EmrTagGetTagInfo.class);
		return list;
	}
	
	public String getUserGroup (String userId) {
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT DISTINCT USER_GROUP FROM ADM3200 WHERE USER_ID = :f_user_id");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	public Integer checkExistTagCodeCaseAdded (String tagCode) {
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT COUNT(*) FROM EMR_TAG WHERE TAG_CODE = :f_tag_code");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_tag_code", tagCode);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return CommonUtils.parseInteger(result.get(0).toString());
		}
		return null;
	}
	
	public Integer checkExistTagCodeCaseModified (String tagId, String tagCode) {
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT COUNT(*) FROM EMR_TAG WHERE TAG_CODE = :f_tag_code  AND EMR_TAG_ID != :f_tag_id");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_tag_code", tagCode);
		query.setParameter("f_tag_id", tagId);
		
		@SuppressWarnings("unchecked")
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return CommonUtils.parseInteger(result.get(0).toString());
		}
		return null;
	}
	
	public List<OCS2015U31EmrTagGetTagInfo> getOCS2015U31EmrTagGetTagInfo (String hospCode,String tagLevel) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT EMR_TAG_ID                                       ");
		sql.append("	     , TAG_CODE                                         ");
		sql.append("	     , TAG_NAME                                         ");
		sql.append("	     , TAG_DISPLAY_TEXT                                 ");
		sql.append("	FROM EMR_TAG                                            ");
		sql.append("	WHERE ACTIVE_FLG = '1'                                  ");
		sql.append("	AND HOSP_CODE = :f_hosp_code                            ");
		if(!StringUtils.isEmpty(tagLevel)){
			sql.append("	AND TAG_LEVEL = :tagLevel                            ");
		}
		sql.append("	ORDER BY EMR_TAG_ID                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(tagLevel)){
			query.setParameter("tagLevel", tagLevel);
		}

		List<OCS2015U31EmrTagGetTagInfo> list = new JpaResultMapper().list(query, OCS2015U31EmrTagGetTagInfo.class);
		return list;
	}
	
	public List<OCS2015U31EmrTagGetTemplateTagsInfo> getOCS2015U31EmrTagGetTemplateTagsInfo (String hospCode, List<String> tagCode) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT EMR_TAG_ID             ");
		sql.append("	     , TAG_CODE               ");
		sql.append("	     , TAG_NAME               ");
		sql.append("	     , TAG_DISPLAY_TEXT       ");
		sql.append("	     , DESCRIPTION            ");
		sql.append("	     , FILTER_FLG             ");
		sql.append("	     , TAG_PARENT             ");
		sql.append("	     , SYS_ID                 ");
		sql.append("	FROM EMR_TAG                  ");
		sql.append("	WHERE ACTIVE_FLG = '1'        ");
		sql.append("	AND HOSP_CODE = :f_hosp_code  ");
		if(!CollectionUtils.isEmpty(tagCode)){
			sql.append("	AND TAG_CODE IN :tagCode  ");
		} 
		sql.append("	ORDER BY EMR_TAG_ID           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!CollectionUtils.isEmpty(tagCode)){
			query.setParameter("tagCode", tagCode);
		}
		
		List<OCS2015U31EmrTagGetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31EmrTagGetTemplateTagsInfo.class);
		return list;
	}
	
	
	public List<OCS2015U09GetTagsForContextInfo> getOCS2015U09GetTagsRootForContextInfo(String hospCode) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMR_TAG_ID,				");
		sql.append("	        TAG_CODE,               ");
		sql.append("	        TAG_NAME,               ");
		sql.append("	        TAG_LEVEL,              ");
		sql.append("	        TAG_DISPLAY_TEXT,       ");
		sql.append("	        TAG_PARENT,             ");
		sql.append("	        DESCRIPTION,            ");
		sql.append("	        PERMISSION_TYPE,        ");
		sql.append("	        SYS_ID,                 ");
		sql.append("	        UPD_ID                  ");                             
		sql.append("	FROM EMR_TAG                    ");                                                    
		sql.append("	WHERE TAG_LEVEL = 'R'           ");
		sql.append("	AND HOSP_CODE = :f_hosp_code    ");
		sql.append("	AND FILTER_FLG = '1'            ");                   
		sql.append("	AND ACTIVE_FLG = '1'            ");                                                           
		sql.append("	ORDER BY TAG_CODE               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		List<OCS2015U09GetTagsForContextInfo> list = new JpaResultMapper().list(query, OCS2015U09GetTagsForContextInfo.class);
		return list;
	}
	
	@Override
	public List<OCS2015U09GetTagsForContextInfo> getOCS2015U09GetTagsNodeForContextInfo(String hospCode, String userId, String tagParent) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMR_TAG_ID,															");
		sql.append("	      TAG_CODE,                                                             ");
		sql.append("	      TAG_NAME,                                                             ");
		sql.append("	      TAG_LEVEL,                                                            ");
		sql.append("	      TAG_DISPLAY_TEXT,                                                     ");
		sql.append("	      TAG_PARENT,                                                           ");
		sql.append("	      DESCRIPTION,                                                          ");
		sql.append("	      PERMISSION_TYPE,                                                      ");
		sql.append("	      SYS_ID,                                                               ");
		sql.append("	      UPD_ID                                                                ");
		sql.append("	FROM EMR_TAG                                                                ");
		sql.append("	WHERE TAG_LEVEL = 'N'                                                       ");
		sql.append("	  AND HOSP_CODE = :f_hosp_code                                              ");
		sql.append("	  AND TAG_PARENT LIKE :f_tag_parent                                         ");
		sql.append("	  AND (PERMISSION_TYPE='S' OR (PERMISSION_TYPE='F' AND SYS_ID=:f_user_id))  ");
		sql.append("	  AND FILTER_FLG = '1'                                                      ");
		sql.append("	  AND ACTIVE_FLG = '1'                                                      ");               
		sql.append("	ORDER BY TAG_CODE                                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_tag_parent", "%" + tagParent + "%");
		
		List<OCS2015U09GetTagsForContextInfo> list = new JpaResultMapper().list(query, OCS2015U09GetTagsForContextInfo.class);
		return list;
	}
	
	public List<OCS2015U07TagChildInfo> getOCS2015U07TagChildInfo(String tagParent, String hospCode){
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT TAG_CODE, 						");
		sql.append("	       TAG_NAME,                        ");
		sql.append("	       TAG_DISPLAY_TEXT                 ");
		sql.append("	FROM EMR_TAG                            ");
		sql.append("	WHERE TAG_PARENT LIKE :f_parent_tag     ");
		sql.append("	AND HOSP_CODE = :hospCode               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_parent_tag", "%" + tagParent + "%");
		query.setParameter("hospCode", hospCode);
		
		List<OCS2015U07TagChildInfo> list = new JpaResultMapper().list(query, OCS2015U07TagChildInfo.class);
		return list;
	}

//	@Override
//	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsParentListInfo(String hospCode,
//			String templateCode, String permissionType, List<String> deptCodeList, String userId, boolean isAdmin, boolean isCommonTab) {
//		StringBuffer sql = new StringBuffer();
//		
//		sql.append("	SELECT   A.EMR_TAG_RELATION_ID														");
//		sql.append("	      	,TRIM(B.TAG_CODE)									    					");
//		sql.append("	      	,B.TAG_NAME																	");
//		sql.append("	      	,A.TAG_TYPE								                					");
//		sql.append("	      	,A.DEFAULT_CONTENT								        					");
//		sql.append("	      	,TRIM(A.TAG_PARENT)								        					");
//		sql.append("	      	,B.TAG_LEVEL					                        					");
//		sql.append("	FROM EMR_TAG_RELATION A																");
//		sql.append("	JOIN EMR_TAG B ON A.HOSP_CODE = B.HOSP_CODE											");
//		sql.append("	              AND A.TAG_PARENT = B.TAG_CODE											");
//		sql.append("	JOIN EMR_TEMPLATE C ON A.HOSP_CODE = C.HOSP_CODE									");
//		sql.append("	                   AND A.TEMPLATE_CODE = C.TEMPLATE_CODE							");
//		sql.append("	                   AND C.PERMISSION_TYPE = :permissionType							");
//		sql.append("	WHERE A.HOSP_CODE = :hospCode														");
//		sql.append("	  AND A.TEMPLATE_CODE =	:templateCode			        							");
//		sql.append("	  AND A.ACTIVE_FLG = 1  															");
//		sql.append("	  AND A.TAG_CHILD IS NULL                                     						");
//		
//		if(!isAdmin && isCommonTab){
//			sql.append("  AND ((C.TYPE = 1) OR (C.TYPE = 2 AND C.DEPT_CODE IN (:deptCodeList)) OR ((C.TYPE = 3 AND C.DEPT_CODE IN (:deptCodeList) AND C.USER_ID = :userId)))	");
//		}
//		
//		if(!isAdmin && !isCommonTab){
//			sql.append("  AND C.TYPE = 4 AND C.USER_ID = :userId																												");
//		}
//		
//		sql.append("	GROUP BY B.TAG_CODE, A.EMR_TAG_RELATION_ID,B.TAG_NAME, A.TAG_PARENT, B.TAG_LEVEL																		");
//		sql.append("	ORDER BY  B.EMR_TAG_ID ASC																																");
//		
//		Query query = entityManager.createNativeQuery(sql.toString());
//		query.setParameter("hospCode", hospCode);
//		query.setParameter("templateCode", templateCode);
//		query.setParameter("permissionType", permissionType);
//		
//		if(!isAdmin && isCommonTab){
//			query.setParameter("deptCodeList", deptCodeList);
//			query.setParameter("userId", userId);
//		}
//		
//		if(!isAdmin && !isCommonTab){
//			query.setParameter("userId", userId);
//		}
//		
//		List<OCS2015U31GetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31GetTemplateTagsInfo.class);
//		return list;
//	}
//
//	@Override
//	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsChildListInfo(
//			String hospCode, String templateCode, String permissionType, List<String> deptCodeList, String userId, boolean isAdmin, boolean isCommonTab) {
//		StringBuffer sql = new StringBuffer();
//		
////		sql.append("	SELECT A.EMR_TAG_RELATION_ID													");			
////		sql.append("		,TRIM(B.TAG_CODE)									                        ");
////		sql.append("		,B.TAG_NAME													                ");
////		sql.append("		,A.TAG_TYPE								                                    ");
////		sql.append("		,A.DEFAULT_CONTENT								                            ");
////		sql.append("		,TRIM(A.TAG_PARENT)								                            ");
////		sql.append("		,B.TAG_LEVEL					                                            ");
////		sql.append("	FROM EMR_TAG_RELATION A, EMR_TAG B 							   					");	
////		sql.append("	WHERE A.EMR_TEMPLATE_ID = :templateId				                            ");
////		sql.append("	AND B.HOSP_CODE = :hospCode                                                     ");
////		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                                   ");
////		sql.append("	AND B.TAG_CODE = A.TAG_CHILD                                                    ");
////		sql.append("	AND A.ACTIVE_FLG =	1															");
////		sql.append("	ORDER BY  A.EMR_TAG_RELATION_ID ASC     										");
//		
//		sql.append("	SELECT  A.EMR_TAG_RELATION_ID													");
//		sql.append("	      	,TRIM(B.TAG_CODE)														");
//		sql.append("	      	,B.TAG_NAME																");
//		sql.append("	      	,A.TAG_TYPE																");
//		sql.append("	      	,A.DEFAULT_CONTENT														");
//		sql.append("	      	,TRIM(A.TAG_PARENT)														");
//		sql.append("	      	,B.TAG_LEVEL					        								");
//		sql.append("	FROM EMR_TAG_RELATION A															");
//		sql.append("	JOIN EMR_TAG B ON A.HOSP_CODE = B.HOSP_CODE										");
//		sql.append("	              AND A.TAG_CHILD = B.TAG_CODE										");
//		sql.append("	JOIN EMR_TEMPLATE C ON A.HOSP_CODE = C.HOSP_CODE								");
//		sql.append("	                   AND A.TEMPLATE_CODE = C.TEMPLATE_CODE						");
//		sql.append("	                   AND C.PERMISSION_TYPE = :permissionType						");
//		sql.append("	WHERE A.HOSP_CODE = :hospCode													");
//		sql.append("	  AND A.TEMPLATE_CODE = :templateCode											");
//		sql.append("	  AND A.ACTIVE_FLG =	1														");
//		sql.append("	  AND A.TAG_CHILD IS NOT NULL													");
//		if(!isAdmin && isCommonTab){
//			sql.append("  AND ((C.TYPE = 1) OR (C.TYPE = 2 AND C.DEPT_CODE IN (:deptCodeList)) OR ((C.TYPE = 3 AND C.DEPT_CODE IN (:deptCodeList) AND C.USER_ID = :userId)))	");
//		}
//		
//		if(!isAdmin && !isCommonTab){
//			sql.append("  AND C.TYPE = 4 AND C.USER_ID = :userId																												");
//		}
//		
//		sql.append("	ORDER BY  B.EMR_TAG_ID ASC																																");
//		
//		Query query = entityManager.createNativeQuery(sql.toString());
//		query.setParameter("hospCode", hospCode);
//		query.setParameter("templateCode", templateCode);
//		query.setParameter("permissionType", permissionType);
//		if(!isAdmin && isCommonTab){
//			query.setParameter("deptCodeList", deptCodeList);
//			query.setParameter("userId", userId);
//		}
//		
//		if(!isAdmin && !isCommonTab){
//			query.setParameter("userId", userId);
//		}
//		
//		List<OCS2015U31GetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31GetTemplateTagsInfo.class);
//		return list;
//	}

	@Override
	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsParentListInfo(
			String hospCode, String templateId) {
		StringBuffer sql = new StringBuffer();
		
		sql.append("	SELECT  A.EMR_TAG_RELATION_ID										        	");			
		sql.append("		,TRIM(B.TAG_CODE)									                        ");
		sql.append("		,B.TAG_NAME													                ");
		sql.append("		,A.TAG_TYPE								                                    ");
		sql.append("		,A.DEFAULT_CONTENT								                            ");
		sql.append("		,TRIM(A.TAG_PARENT)								                            ");
		sql.append("		,B.TAG_LEVEL					                                            ");
		sql.append("	FROM EMR_TAG_RELATION A, EMR_TAG B 							   					");	
		sql.append("	WHERE A.EMR_TEMPLATE_ID =	:templateId				                            ");
		sql.append("	AND B.HOSP_CODE = :hospCode                                                     ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                                   ");
		sql.append("	AND B.TAG_CODE = A.TAG_PARENT                                                   ");
		sql.append("	AND A.TAG_CHILD IS NULL                                                         ");
		sql.append("	AND A.ACTIVE_FLG =	1															");
		sql.append("	GROUP BY B.TAG_CODE	, 												     		");
		sql.append("	A.EMR_TAG_RELATION_ID,B.TAG_NAME, A.TAG_PARENT, B.TAG_LEVEL						");
		sql.append("	ORDER BY  A.EMR_TAG_RELATION_ID ASC                      						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("templateId", templateId);
		
		List<OCS2015U31GetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31GetTemplateTagsInfo.class);
		return list;
	}

	@Override
	public List<OCS2015U31GetTemplateTagsInfo> getOCS2015U31GetTemplateTagsChildListInfo(
			String hospCode, String templateId) {
		StringBuffer sql = new StringBuffer();
		
		sql.append("	SELECT A.EMR_TAG_RELATION_ID													");			
		sql.append("		,TRIM(B.TAG_CODE)									                        ");
		sql.append("		,B.TAG_NAME													                ");
		sql.append("		,A.TAG_TYPE								                                    ");
		sql.append("		,A.DEFAULT_CONTENT								                            ");
		sql.append("		,TRIM(A.TAG_PARENT)								                            ");
		sql.append("		,B.TAG_LEVEL					                                            ");
		sql.append("	FROM EMR_TAG_RELATION A, EMR_TAG B 							   					");	
		sql.append("	WHERE A.EMR_TEMPLATE_ID = :templateId				                            ");
		sql.append("	AND B.HOSP_CODE = :hospCode                                                     ");
		sql.append("	AND B.HOSP_CODE = A.HOSP_CODE                                                   ");
		sql.append("	AND B.TAG_CODE = A.TAG_CHILD                                                    ");
		sql.append("	AND A.ACTIVE_FLG =	1															");
		sql.append("	ORDER BY  A.EMR_TAG_RELATION_ID ASC     										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("templateId", templateId);
		
		List<OCS2015U31GetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31GetTemplateTagsInfo.class);
		return list;
	}
	
	@Override
	public List<OCS2015U09TagParentAndChild> getOCS2015U09TagParentAndChild(String hospCode, List<Integer> emrTemplateId) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT TAG_PARENT, TAG_CHILD , EMR_TEMPLATE_ID  ");
		sql.append(" FROM EMR_TAG_RELATION                           ");
		sql.append(" WHERE HOSP_CODE = :hosp_code                    ");
		sql.append(" AND ACTIVE_FLG = '1'                            ");
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			sql.append(" AND EMR_TEMPLATE_ID IN :emrTemplateId       ");
		} 
		sql.append(" ORDER BY TAG_PARENT , TAG_CHILD                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			query.setParameter("emrTemplateId", emrTemplateId);
		} 
		List<OCS2015U09TagParentAndChild> list = new JpaResultMapper().list(query, OCS2015U09TagParentAndChild.class);
		return list;
	}

	@Override
	public List<OCS2015U31EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsInfo(String hospCode, String tagParent, String tagChild) {
		StringBuffer sql = new StringBuffer();
		sql.append("	SELECT EMR_TAG_ID             ");
		sql.append("	     , TAG_CODE               ");
		sql.append("	     , TAG_NAME               ");
		sql.append("	     , TAG_DISPLAY_TEXT       ");
		sql.append("	     , DESCRIPTION            ");
		sql.append("	     , FILTER_FLG             ");
		if(StringUtils.isEmpty(tagChild)){
			sql.append("	     , ''                 ");
		}else{
			sql.append(" , CASE WHEN TAG_CODE = :tagParent THEN '' ELSE :tagParent   END  TAG_PARENT  ");
		}
		sql.append("	     , SYS_ID                 ");
		sql.append("	FROM EMR_TAG                  ");
		sql.append("	WHERE ACTIVE_FLG = '1'        ");
		sql.append("	AND HOSP_CODE = :f_hosp_code  ");
		sql.append("	AND TAG_CODE = :tagChild OR TAG_CODE = :tagParent      ");
		sql.append("	ORDER BY EMR_TAG_ID           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("tagParent", tagParent);
		query.setParameter("tagChild", tagChild);
		
		List<OCS2015U31EmrTagGetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U31EmrTagGetTemplateTagsInfo.class);
		return list;
	}

	@Override
	public List<OCS2015U09EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsInfo(String hospCode,
			List<Integer> emrTemplateId) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT IFNULL(A.EMR_TAG_ID, C.EMR_TAG_ID) ,                            		  													");
		sql.append("        IFNULL(TRIM(A.TAG_CODE), TRIM(C.TAG_CODE)) ,                               													 ");
		sql.append("        IFNULL(A.TAG_NAME, C.TAG_NAME) ,                                															");
		sql.append("        CAST(B.TAG_TYPE AS CHAR) ,                 					 																");
		sql.append("        B.DEFAULT_CONTENT ,                         																				");
		sql.append("        IFNULL(A.TAG_DISPLAY_TEXT, C.TAG_DISPLAY_TEXT) ,                        													");
		sql.append("        IFNULL(A.DESCRIPTION, C.DESCRIPTION),                             		 													");
		sql.append("        IFNULL(A.FILTER_FLG, C.FILTER_FLG) ,                             		 													");
		sql.append("        IFNULL(A.SYS_ID, C.SYS_ID) ,                                 					 											");
		sql.append("        TRIM(B.TAG_PARENT) ,                              																			");
		sql.append("        TRIM(B.TAG_CHILD) ,                              																			 ");
		sql.append("        B.EMR_TEMPLATE_ID                           																				");
		sql.append(" FROM EMR_TAG_RELATION B                           																					 ");
		sql.append(" LEFT JOIN EMR_TAG A ON B.TAG_CHILD IS NULL AND B.TAG_PARENT = A.TAG_CODE AND A.ACTIVE_FLG = '1'     AND B.HOSP_CODE=A.HOSP_CODE  		");
		sql.append(" LEFT JOIN EMR_TAG C ON B.TAG_CHILD IS NOT NULL AND B.TAG_CHILD = C.TAG_CODE AND C.ACTIVE_FLG = '1'  AND B.HOSP_CODE=C.HOSP_CODE     ");
		sql.append(" WHERE B.ACTIVE_FLG = '1'                            																				");
		sql.append(" AND B.HOSP_CODE = :hosp_code                      																					 ");
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			sql.append(" AND B.EMR_TEMPLATE_ID IN :emrTemplateId      																					 ");
		}

		sql.append(" ORDER BY B.EMR_TAG_RELATION_ID ASC ");
		//sql.append(" order by B.TAG_PARENT, B.TAG_CHILD 				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			query.setParameter("emrTemplateId", emrTemplateId);
		}

		
		List<OCS2015U09EmrTagGetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U09EmrTagGetTemplateTagsInfo.class);
		return list;
	}

	@Override
	public List<OCS2015U09EmrTagGetTemplateTagsInfo> getOCS2015U09EmrTagGetTemplateTagsChildInfo(String hospCode,
			List<Integer> emrTemplateId) {
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT A.EMR_TAG_ID ,                              ");
		sql.append("        A.TAG_CODE ,                                ");
		sql.append("        A.TAG_NAME ,                                ");
		sql.append("        CAST(B.TAG_TYPE AS CHAR) ,                  ");
		sql.append("        B.DEFAULT_CONTENT ,                         ");
		sql.append("        A.TAG_DISPLAY_TEXT ,                        ");
		sql.append("        A.DESCRIPTION,                              ");
		sql.append("        A.FILTER_FLG ,                              ");
		sql.append("        A.SYS_ID ,                                  ");
		sql.append("        B.TAG_PARENT ,                              ");
		sql.append("        B.TAG_CHILD ,                               ");
		sql.append("        B.EMR_TEMPLATE_ID                           ");
		sql.append(" FROM EMR_TAG_RELATION B                            ");
		sql.append(" INNER JOIN EMR_TAG A ON B.TAG_CHILD = A.TAG_CODE   ");
		sql.append(" WHERE A.ACTIVE_FLG = '1'                           ");
		sql.append("  AND B.ACTIVE_FLG = '1'                            ");
		sql.append(" AND B.HOSP_CODE = :hosp_code                       ");
		sql.append(" AND A.HOSP_CODE = :hosp_code                       ");
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			sql.append(" AND B.EMR_TEMPLATE_ID IN :emrTemplateId       ");
		} 
		//sql.append(" order by B.TAG_PARENT, B.TAG_CHILD 				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(!CollectionUtils.isEmpty(emrTemplateId)){
			query.setParameter("emrTemplateId", emrTemplateId);
		} 
		
		List<OCS2015U09EmrTagGetTemplateTagsInfo> list = new JpaResultMapper().list(query, OCS2015U09EmrTagGetTemplateTagsInfo.class);
		return list;
	}

}
