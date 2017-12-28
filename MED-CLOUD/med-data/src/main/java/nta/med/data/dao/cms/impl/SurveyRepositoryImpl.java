package nta.med.data.dao.cms.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.cms.ServeyRepositoryCustom;
import nta.med.data.model.cms.CmsSurveyInfo;

/**
 * @author DEV-TiepNM
 */
public class SurveyRepositoryImpl implements ServeyRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CmsSurveyInfo> getListSurveyPatient(String hospCode, String reservationDate, String departmentCode, String surveyStatus, String patientName, String title,Integer startIndex, Integer pageSize){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.PATIENT_CODE,														");
		sql.append("	        A.PATIENT_NAME,														");
		sql.append("	        A.DEPARTMENT_CODE,													");
		sql.append("	        A.DEPARTMENT_NAME,													");
		sql.append("	        A.CMS_SURVEY_PATIENT_ID												");
		sql.append("	        A.STATUS															");
		sql.append("	        B.TITLE																");
		sql.append("	FROM    cms_survey_patient A,cms_survey B 									");
		sql.append("	WHERE   A.CMS_SURVEY_ID = B.ID												");
		if(!StringUtils.isEmpty(reservationDate)){
			sql.append("	  AND   A.RESERVATION_DATE = :f_reservationDate							");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			sql.append("	  AND   A.PATIENT_NAME like :f_patientName								");
		}
		
		if(!StringUtils.isEmpty(departmentCode)){
			sql.append("  	  AND   A.DEPARTMENT_CODE = :f_departmentCode							");
		}
			
		sql.append("  	  AND   B.TITLE like :f_title												");
		sql.append("  	  AND   A.STATUS_FLG = :f_statusFlg											");
		sql.append("	ORDER BY A.CREATED															");
		sql.append("	LIMIT :f_startIndex, :f_endIndex											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if(!StringUtils.isEmpty(departmentCode)){
			query.setParameter("f_departmentCode", departmentCode);
		}
		
		query.setParameter("f_hospCode", hospCode);
		if(!StringUtils.isEmpty(patientName)){
			query.setParameter("f_patientName", patientName );
		}
		
		if(!StringUtils.isEmpty(reservationDate)){
			query.setParameter("f_reservationDate", reservationDate);
		}
		
		
		
		query.setParameter("f_statusFlg", surveyStatus);
		query.setParameter("f_title", title);
		
		query.setParameter("f_hospCode", hospCode);
		query.setParameter("f_startIndex", startIndex);
		query.setParameter("f_endIndex", pageSize);
		
		List<CmsSurveyInfo> listSurvey = new JpaResultMapper().list(query, CmsSurveyInfo.class);
		return listSurvey;
	}
}
