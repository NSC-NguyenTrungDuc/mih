package nta.med.data.dao.cms.impl;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.CmsSurveyPatientRepositoryCustom;
import nta.med.data.model.cms.CmsListSurveyInfo;
import nta.med.data.model.cms.CmsSurveyPatientInfo;
import nta.med.data.model.cms.CmsSurveyPatientSummary;
import nta.med.data.model.cms.CmsSurveyRelatedInfo;
import nta.med.data.model.cms.CmsSurveyStatusInfo;

public class CmsSurveyPatientRepositoryImpl implements CmsSurveyPatientRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
//cms11	
	@Override
	public List<CmsSurveyPatientSummary> findAnsweredAndWaitingByHospCode(String hospCode,Integer type,Integer startIndex, Integer pageSize, boolean isPaging) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 	A.departmentCode,																					        ");
		sql.append("	COUNT(1) as total_survey,                  																	        ");
		sql.append("			SUM(A.answered)		AS totalAnswered,																        ");
		sql.append("			SUM(A.waiting)		AS totalWaiting																	        ");
		sql.append("	FROM(																										        ");
		sql.append("		SELECT 	A1.DEPARTMENT_CODE	AS departmentCode,															        ");
		sql.append("				A1.DEPARTMENT_NAME AS departmentName,															        ");
		sql.append("				CASE WHEN A1.STATUS_FLG = 1 THEN 1 ELSE 0 END AS answered,										        ");
		sql.append("				CASE WHEN A1.STATUS_FLG = 0 THEN 1 ELSE 0 END AS waiting										        ");
		sql.append("		FROM cms_survey_patient A1 INNER JOIN cms_survey A2 ON A1.CMS_SURVEY_ID = A2.ID AND A2.ACTIVE_FLG = 1 	        ");
		sql.append("		WHERE A1.HOSP_CODE = :f_hospCode																		        ");
		sql.append("		  AND   A1.ACTIVE_FLG = 1																				        ");
		sql.append("		  AND   A2.HOSP_CODE = :f_hospCode																		        ");
		if(type==1){
			sql.append("	  AND   A1.RESERVATION_DATE = 	CURDATE()																		");
		}else if(type==2){
			sql.append("	  AND   A1.RESERVATION_DATE BETWEEN DATE_ADD(CURDATE(), INTERVAL 1-DAYOFWEEK(CURDATE()) DAY)					");
			sql.append("	  AND   DATE_ADD(CURDATE(), INTERVAL 7-DAYOFWEEK(CURDATE()) DAY)												");
		}else if(type==3){
			sql.append("	  AND   A1.RESERVATION_DATE BETWEEN  DATE_SUB(CURDATE(),INTERVAL (DAY(CURDATE())-1) DAY) AND LAST_DAY(NOW())	");
		}else if(type==4){
			sql.append("	 																										        ");
		}                                                                                                                                   
		sql.append("	) A																											        ");
		sql.append("	GROUP BY A.departmentCode																					        ");
		sql.append("	ORDER BY A.departmentCode																					        ");
		/*if(isPaging)
		{
			sql.append("	LIMIT :f_startIndex, :f_endIndex																		");
		}*/

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		/*if(isPaging)
		{
			query.setParameter("f_startIndex", startIndex);
			query.setParameter("f_endIndex", pageSize);
		}*/

		
		List<CmsSurveyPatientSummary> listData = new JpaResultMapper().list(query, CmsSurveyPatientSummary.class);
		return listData;
	}
//Cms12
	@Override
	public List<CmsSurveyPatientInfo> getListSurveyPatientInfo(String hospCode, String departmentCode, String search,BigDecimal statusFlg, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.ID,  A.CMS_SURVEY_ID,									");
		sql.append("	        A.PATIENT_CODE,											");
		sql.append("	        A.PATIENT_NAME,	 										");
		sql.append("	        A.RESERVATION_DATE,										");
		sql.append("	        A.RESERVATION_TIME,										");
		sql.append("	        A.DEPARTMENT_CODE,										");
		sql.append("	       	A.DEPARTMENT_NAME,										");
		sql.append("			B.TITLE													");
		sql.append("	FROM cms_survey_patient A										");
		sql.append("	JOIN cms_survey B ON A.CMS_SURVEY_ID = B.ID						");
		sql.append("	WHERE   A.HOSP_CODE = :f_hospCode								");
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("	  AND   A.DEPARTMENT_CODE = :f_departmentCode				");
			}
		
		if(!StringUtils.isEmpty(search)){
			sql.append("  	  AND  ( A.PATIENT_CODE = :f_search_patient_code					");
			sql.append("  	  OR   A.PATIENT_NAME like :f_search_patient_name     )           ");

		}
		if(statusFlg != null){
			sql.append(" AND A.STATUS_FLG = 					").append(statusFlg.intValue());
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
			query.setParameter("f_departmentCode", 
					departmentCode);
		}
		
		query.setParameter("f_hospCode", hospCode);
		
		if(!StringUtils.isEmpty(search)){
			query.setParameter("f_search_patient_code", search);
			query.setParameter("f_search_patient_name", "%" + search + "%");
		}
//		if(statusFlg != null){
//			query.setParameter("f_statusFlg", 0);
//		}
		if(isPaging)
		{
			query.setParameter("f_startIndex", startIndex);
			query.setParameter("f_endIndex", pageSize);
		}

		
		List<CmsSurveyPatientInfo> listSurveyPatient = new JpaResultMapper().list(query, CmsSurveyPatientInfo.class);
		return listSurveyPatient;
	}
//Cms13
	@Override
	public List<CmsSurveyPatientSummary> findAnsweredAndWaitingByHospCode(String hospCode) {	
			
		StringBuilder sql = new StringBuilder();
		sql.append("	select sp.DEPARTMENT_CODE,                                         							          ");
		sql.append("	                                                											          ");
		sql.append("	COUNT(1) as total_survey,                  													          ");
		sql.append("	SUM(case when sp.STATUS_FLG = 1 then 1 else 0 end) as answered,    							          ");
		sql.append("	SUM(case when sp.STATUS_FLG = 0 then 1 else 0 end) as waiting      							          ");
		sql.append("	from cms_survey_patient sp                                         							          ");
		sql.append("	INNER JOIN cms_survey s on sp.CMS_SURVEY_ID = s.ID AND s.HOSP_CODE = :f_hospCode AND s.ACTIVE_FLG = 1 ");
		sql.append("	where sp.HOSP_CODE = :f_hospCode                                     							      ");
		sql.append("	AND sp.ACTIVE_FLG = 1                                     							      			  ");
		sql.append("	group by sp.DEPARTMENT_CODE   																	      ");
		sql.append("	ORDER BY sp.DEPARTMENT_CODE																		      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		
		List<CmsSurveyPatientSummary> listData = new JpaResultMapper().list(query, CmsSurveyPatientSummary.class);
		return listData;
	}
	
	@Override
	public List<CmsSurveyRelatedInfo> getSurveypatientRelated(String patientCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT                                    								");
		sql.append("	S.DEPARTMENT_CODE,                        								");
		sql.append("	S.DEPARTMENT_NAME,                        								");
		sql.append("	S.ID,                                     								");
		sql.append("	DATE_FORMAT(S.ANSWER_DATE, '%Y-%m-%d')    								");
		sql.append("	FROM cms_survey_patient S                 								");			
		sql.append("	WHERE S.PATIENT_CODE = :patientCode       								");
		sql.append("	AND S.STATUS_FLG = '1'                    								");
		sql.append("	AND S.ACTIVE_FLG = '1'                    								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("patientCode", patientCode);
		
		List<CmsSurveyRelatedInfo> listData = new JpaResultMapper().list(query, CmsSurveyRelatedInfo.class);
		return listData;
	}
	
	//cms 14
	@Override
	public List<CmsSurveyStatusInfo> getListSurveybyDepartmentCode(String hospCode, String departmentCode,
			Integer startIndex, Integer pageSize) {
		StringBuilder sql = new StringBuilder();
		sql.append("			SELECT s.ID,                                                     			");
		sql.append("		       s.TITLE,                                                      			");
		sql.append("		       s.DESCRIPTION,                                                			");	
		sql.append("		       s.DEFAULT_FLG,                                                			");
		sql.append("		       ( CASE                                                        			");
		sql.append("		           WHEN sp1.ANSWERED IS NULL THEN 0                          			");
		sql.append("		           ELSE sp1.ANSWERED                                         			");
		sql.append("		         end ) AS answered,                                          			");
		sql.append("		       ( CASE                                                        			");
		sql.append("		           WHEN sp1.WAITING IS NULL THEN 0                           			");
		sql.append("		           ELSE sp1.WAITING                                          			");
		sql.append("		         end ) AS waiting                                            			");	
		sql.append("		FROM   cms_survey s                                                  			");
		sql.append("		       LEFT JOIN (SELECT sp.CMS_SURVEY_ID,                           			");
		sql.append("		                         Sum(CASE                                    			");
		sql.append("		                               WHEN sp.STATUS_FLG = 1 THEN 1         			");
		sql.append("		                               ELSE 0                                			");
		sql.append("		                             end) AS answered,                       			");
		sql.append("		                         Sum(CASE                                    			");
		sql.append("		                               WHEN sp.STATUS_FLG = 0 THEN 1         			");
		sql.append("		                               ELSE 0                                			");
		sql.append("		                             end) AS waiting                         			");	
		sql.append("		                  FROM   cms_survey_patient sp                       			");
		sql.append("		                  WHERE  1 = 1								        			");
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("		AND  sp.DEPARTMENT_CODE = :f_departmentCode                           		");
		}
		sql.append("		                  AND sp.HOSP_CODE = :f_hospCode                       			");
		sql.append("		                  GROUP  BY sp.CMS_SURVEY_ID) AS sp1                 			");
		sql.append("		              ON s.ID = sp1.CMS_SURVEY_ID                            			");
		sql.append("		WHERE 1 = 1                           											");
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("		AND  s.DEPARTMENT_CODE = :f_departmentCode                           		");
		}
		sql.append("		AND s.HOSP_CODE = :f_hospCode                                          			");
		sql.append("		AND s.ACTIVE_FLG = 1                                                 			");
		sql.append("	LIMIT :f_startIndex, :f_endIndex													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", 
					departmentCode);
		}
		query.setParameter("f_hospCode", hospCode);
		query.setParameter("f_startIndex", startIndex);
		query.setParameter("f_endIndex", pageSize);
		
		List<CmsSurveyStatusInfo> listSurvey = new JpaResultMapper().list(query, CmsSurveyStatusInfo.class);
		return listSurvey;
	}
	
	@Override
	public int getTotalSurveybyDepartmentCode(String hospCode, String departmentCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("			SELECT COUNT(1)                                                     		");	
		sql.append("		FROM   cms_survey s                                                  			");
		sql.append("		       LEFT JOIN (SELECT /*sp.DEPARTMENT_CODE,*/                         		");
		sql.append("		                         /*sp.DEPARTMENT_NAME,*/                         		");
		sql.append("		                         sp.CMS_SURVEY_ID,                           			");
		sql.append("		                         Sum(CASE                                    			");
		sql.append("		                               WHEN sp.STATUS_FLG = 1 THEN 1         			");
		sql.append("		                               ELSE 0                                			");
		sql.append("		                             end) AS answered,                       			");
		sql.append("		                         Sum(CASE                                    			");
		sql.append("		                               WHEN sp.STATUS_FLG = 0 THEN 1         			");
		sql.append("		                               ELSE 0                                			");
		sql.append("		                             end) AS waiting                         			");	
		sql.append("		                  FROM   cms_survey_patient sp                       			");
		sql.append("		                  WHERE  1 = 1								        			");
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("		AND  sp.DEPARTMENT_CODE = :f_departmentCode                           		");
		}
		sql.append("		                  AND sp.HOSP_CODE = :f_hospCode                       			");
		sql.append("		                  GROUP  BY sp.CMS_SURVEY_ID) AS sp1                 			");
		sql.append("		              ON s.ID = sp1.CMS_SURVEY_ID                            			");
		sql.append("		WHERE 1 = 1                           											");
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("		AND  s.DEPARTMENT_CODE = :f_departmentCode                           		");
		}
		sql.append("		AND s.HOSP_CODE = :f_hospCode                                          			");
		sql.append("		AND s.ACTIVE_FLG = 1                                                 			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", 
					departmentCode);
		}
		query.setParameter("f_hospCode", hospCode);
		
		List<BigInteger> listSurvey = query.getResultList();
		if(!CollectionUtils.isEmpty(listSurvey)){
			return listSurvey.get(0).intValue();
		}
		
		return 0;
	}

	//cms 10
	@Override
	public List<CmsListSurveyInfo> getListSurveyPatient(String hospCode, String departmentCode, BigDecimal statusFlg, String patient, String title,
			Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging, Integer searchType, Date fromDate, Date toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.PATIENT_CODE,														");
		sql.append("	        A.PATIENT_NAME,														");
		sql.append("	        A.DEPARTMENT_CODE,													");
		sql.append("	        A.DEPARTMENT_NAME,													");
		sql.append("	        A.ID	,															");
		sql.append("	        A.STATUS_FLG	,													");
		sql.append("	        B.TITLE	, A.RESERVATION_DATE,										");
		sql.append("	        A.RESERVATION_TIME													");
		sql.append("	        , B.ID SURVEY_ID													");
		sql.append("	FROM    cms_survey_patient A,cms_survey B 									");
		sql.append("	WHERE   A.CMS_SURVEY_ID = B.ID												");
		sql.append("	AND   	A.HOSP_CODE =:f_hospCode 											");
		sql.append("	AND  	B.HOSP_CODE =:f_hospCode 											");
		sql.append("	AND  	A.ACTIVE_FLG = 1 													");
		sql.append("	AND  	B.ACTIVE_FLG = 1 													");
		
		if(fromDate == null && toDate == null && searchType != null){
			if(1 == searchType){
				sql.append("	AND	A.RESERVATION_DATE = CURDATE()																		");
			}else if(2 == searchType){
				sql.append("	AND A.RESERVATION_DATE BETWEEN DATE_ADD(CURDATE(), INTERVAL 1-DAYOFWEEK(CURDATE()) DAY)					");
				sql.append("							AND   DATE_ADD(CURDATE(), INTERVAL 7-DAYOFWEEK(CURDATE()) DAY)					");
			}else if(3 == searchType){
				sql.append("	AND A.RESERVATION_DATE BETWEEN  DATE_SUB(CURDATE(),INTERVAL (DAY(CURDATE())-1) DAY) AND LAST_DAY(NOW())	");
			}else if(4 == searchType){
				sql.append("	 																										");
			}
		} 
		if(fromDate != null){
			sql.append("		AND A.RESERVATION_DATE >= :f_fromDate 																	");
		} 
		if(toDate != null){
			sql.append("		AND A.RESERVATION_DATE <= :f_toDate 																	");
		}
		
		if(!StringUtils.isEmpty(patient)){
			sql.append("	  AND   (A.PATIENT_CODE =   :f_patient_code								");
			sql.append("	  OR     A.PATIENT_NAME like :f_patient_name	)						");
		}
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("  	  AND   A.DEPARTMENT_CODE = :f_departmentCode							");
		}
		if(!StringUtils.isEmpty(title)){
			sql.append("  	  AND   B.TITLE like :f_title											");
		}		
		if(statusFlg!=null){
			sql.append("	AND A.STATUS_FLG = :f_statusFlg											");
		}
		if(!StringUtils.isEmpty(column) && !StringUtils.isEmpty(dir)) {
			sql.append("  	  ORDER BY " + column + " " + dir);
		}
		if(isPaging){
			sql.append("	LIMIT :f_startIndex, :f_endIndex										");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		
		if(!StringUtils.isEmpty(patient)){
			query.setParameter("f_patient_code", patient );
			query.setParameter("f_patient_name", "%" + patient + "%" );
		}
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", departmentCode);
		}
		if(!StringUtils.isEmpty(title)){
			query.setParameter("f_title", "%" + title + "%");
		}
		if(statusFlg!=null){
			query.setParameter("f_statusFlg", statusFlg);
		}
		if(fromDate != null){
			query.setParameter("f_fromDate", fromDate);
		} 
		if(toDate != null){
			query.setParameter("f_toDate", toDate);
		}
		
		if(isPaging){
			query.setParameter("f_startIndex", startIndex);
			query.setParameter("f_endIndex", pageSize);
		}

		query.getResultList();
		List<CmsListSurveyInfo> listSurvey = new JpaResultMapper().list(query, CmsListSurveyInfo.class);
		return listSurvey;
	}
	
	
	@Override
	public boolean isExistedSurveyRelated(BigInteger surveyId) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM cms_survey_patient                	 	    		");
		sql.append("	WHERE CMS_SURVEY_ID     = :surveyId   		    		");
	
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("surveyId", surveyId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	
}
	
	
 

