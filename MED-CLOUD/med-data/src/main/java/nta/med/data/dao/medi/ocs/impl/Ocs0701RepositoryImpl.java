package nta.med.data.dao.medi.ocs.impl;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0701RepositoryCustom;
import nta.med.data.model.ihis.ocso.OCS2016U00GrdQuestionInfo;

public class Ocs0701RepositoryImpl implements Ocs0701RepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS2016U00GrdQuestionInfo> getListOCS2016U00GrdQuestionInfo(String hospCode, String reqDoctor,
			String reqDate, String questionType, String gwa, String language) {
		
		Query query = null;
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  CONVERT(A.ID, CHAR(20))                	  AS grpQuestionId,																				");
		sql.append("	        DATE_FORMAT(A.REQ_DATE, '%Y/%m/%d')       AS reqDate,																					");
		sql.append("	        A.REQ_GWA                                 AS reqGwa,																					");
		sql.append("	        A.REQ_DOCTOR                              AS reqDoctor,																					");
		sql.append("	        A.CONSULT_GWA                             AS consultGwa,																				");
		sql.append("	        A.CONSULT_DOCTOR                          AS consultDoctor,																				");
		sql.append("	        DATE_FORMAT(A.CONSULT_DATE, '%Y/%m/%d')   AS consultDate,																				");
		sql.append("	        A.CONSULT_HOSP_CODE                       AS consultHospCode,																			");
		sql.append("	        A.BUNHO                                   AS bunho,																						");
		sql.append("	        A.FINISH_FLG                              AS finishYn,																					");
		sql.append("	        A.HOSP_CODE                               AS hospCode,																					");
		sql.append("			D.GWA_NAME                                AS reqGwaName,																				");
		sql.append("			E.GWA_NAME                             	  AS consultGwaName,																			");
		sql.append("			C.DOCTOR_NAME                             AS consultDoctorName,																			");
		sql.append("			B.YOYANG_NAME                       	  AS consultHospName,																			");
		sql.append("      		C1.DOCTOR_NAME                            AS reqDoctorName,																				");
		sql.append("      		B2.YOYANG_NAME                            AS reqHospitalName,																			");
		sql.append("      		CONVERT(A.STATUS, CHAR(1))				  AS status																						");
		sql.append("	FROM OCS0701 A																																	");
		sql.append("	JOIN BAS0001 B ON A.CONSULT_HOSP_CODE = B.HOSP_CODE																								");
		sql.append("	              AND B.LANGUAGE = :f_language																										");
		sql.append("				  AND B.START_DATE = (SELECT MAX(B1.START_DATE) FROM BAS0001 B1 WHERE B1.HOSP_CODE = B.HOSP_CODE AND B1.LANGUAGE = B.LANGUAGE)		");
		
		sql.append("	JOIN BAS0001 B2 ON A.HOSP_CODE = B2.HOSP_CODE																									");
		sql.append("	              AND B2.LANGUAGE = :f_language																										");
		sql.append("				  AND B2.START_DATE = (SELECT MAX(B3.START_DATE) FROM BAS0001 B3 WHERE B3.HOSP_CODE = B2.HOSP_CODE AND B3.LANGUAGE = B2.LANGUAGE)	");
		
		sql.append("	LEFT JOIN BAS0271 C ON A.CONSULT_DOCTOR = C.DOCTOR																								");
		sql.append("	              AND A.CONSULT_HOSP_CODE = C.HOSP_CODE																								");
		
		sql.append("  LEFT JOIN BAS0271 C1 ON A.REQ_DOCTOR = C1.DOCTOR																									");
		sql.append("                      AND A.HOSP_CODE = C1.HOSP_CODE																								");
		
		sql.append("	LEFT JOIN BAS0260 D ON A.HOSP_CODE = D.HOSP_CODE																								");
		sql.append("	                   AND A.REQ_GWA = D.GWA																										");
		sql.append("	                   AND D.LANGUAGE = :f_language																									");
		sql.append("	LEFT JOIN BAS0260 E ON A.HOSP_CODE = E.HOSP_CODE																								");
		sql.append("	                   AND A.CONSULT_GWA = E.GWA																									");
		sql.append("	                   AND E.LANGUAGE = :f_language																									");
		sql.append("	WHERE A.ACTIVE_FLG = 1																															");
		if(questionType.equals(CommonEnum.QUESTION_SENT.getValue())){
			sql.append("  AND DATE_FORMAT(A.UPDATED,'%Y/%m/%d') >= :f_req_date																							");
			sql.append("  AND A.HOSP_CODE = :f_hosp_code																												");
			sql.append("  AND A.REQ_DOCTOR = :f_req_doctor																												");
			sql.append("ORDER BY A.CREATED DESC																															");
			
			query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_req_date", reqDate);
			query.setParameter("f_req_doctor", reqDoctor);
			query.setParameter("f_language", language);
		}else if(questionType.equals(CommonEnum.QUESTION_RECEIVED.getValue())){
			sql.append("  AND A.REQ_DATE >= STR_TO_DATE(:f_req_date, '%Y/%m/%d')																							");
			sql.append("  AND A.CONSULT_HOSP_CODE = :f_hosp_code																										");
			sql.append("  AND A.CONSULT_DOCTOR = :f_req_doctor																											");
			sql.append("ORDER BY A.CREATED DESC																															");
			
			query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_req_date", reqDate);
			query.setParameter("f_req_doctor", reqDoctor);
			query.setParameter("f_language", language);
		}else if(questionType.equals(CommonEnum.QUESTION_DEPARMENT.getValue())){
			sql.append("  AND A.REQ_DATE >= STR_TO_DATE(:f_req_date, '%Y/%m/%d')																							");
			sql.append("  AND A.CONSULT_HOSP_CODE = :f_hosp_code																										");
			sql.append("  AND A.CONSULT_GWA = :f_gwa																													");
			sql.append("ORDER BY A.CREATED DESC																															");
			
			query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_req_date", reqDate);
			query.setParameter("f_gwa", gwa);
			query.setParameter("f_language", language);
		}else {
			query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_req_date", reqDate);
			query.setParameter("f_language", language);
			sql.append("	AND 1 = 0																																	");
		}
		
		List<OCS2016U00GrdQuestionInfo> listItem = new JpaResultMapper().list(query, OCS2016U00GrdQuestionInfo.class);
		return listItem;
	}
	
	@Override
	public String countToNotofication(String hospCode, String doctor, BigDecimal status){
		
		String result = "";
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT MAX(DATE_FORMAT(A.UPDATED, '%Y/%m/%d %T')) 	");
		sql.append("	FROM OCS0701 A									  	");
		sql.append("	WHERE A.FINISH_FLG = 0							  	");
		sql.append("	  AND A.ACTIVE_FLG = 1							  	");
		sql.append("	  AND A.STATUS = :f_status							");
		if(new BigDecimal(1).compareTo(status) == 0){
			sql.append("  AND A.CONSULT_DOCTOR = :f_doctor					");
			sql.append("  AND A.CONSULT_HOSP_CODE = :f_hosp_code			");
		} else{
			sql.append("  AND A.REQ_DOCTOR = :f_doctor						");
			sql.append("  AND A.HOSP_CODE = :f_hosp_code					");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_status", status);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> rs = query.getResultList();
		if(rs != null && rs.size() > 0){
			if(rs.get(0) != null){
				result = rs.get(0);
			}
		}
		return result;
	}
}
