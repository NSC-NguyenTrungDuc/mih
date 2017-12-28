package nta.med.data.dao.emr.impl;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.emr.EmrTemplateRepositoryCustom;
import nta.med.data.model.ihis.emr.DepartAndDoctorInfo;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateInfo;
import nta.med.data.model.ihis.emr.OCS2015U09GetTemplateComboBoxInfo;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateInfo;
import nta.med.data.model.ihis.emr.OCS2015U31GetEmrTemplateInfo;

public class EmrTemplateRepositoryImpl implements EmrTemplateRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	public List<OCS2015U06EmrTemplateInfo> getOCS2015U06EmrTemplateInfo(String templateCode, String gwa){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT					       ");
		sql.append("	EMR_TEMPLATE_ID,			       ");
		sql.append("	EMR_TEMPLATE_TYPE_ID,		       ");
//		sql.append("	TEMPLATE_CODE,			       ");
		sql.append("	:f_template_code TEMPLATE_CODE,			       ");
		sql.append("	TEMPLATE_NAME,			       ");
		sql.append("	TEMPLATE_CONTENT,		       ");
		sql.append("	HOSP_CODE,				       ");
//		sql.append("	GWA,					       ");
		sql.append("	:f_gwa GWA,					       ");
		sql.append("	SYS_ID,				       ");	
		sql.append("	PERMISSION_TYPE,		       ");
		sql.append("	ACTIVE_FLG,				       ");
		sql.append("	CREATED,				       ");
		sql.append("	UPDATED					       ");
		sql.append("	FROM EMR_TEMPLATE		       ");
		sql.append("	WHERE ACTIVE_FLG='1'	       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_template_code", templateCode);
		query.setParameter("f_gwa", gwa);

		List<OCS2015U06EmrTemplateInfo> list = new JpaResultMapper().list(query, OCS2015U06EmrTemplateInfo.class);
		return list;
	}
	
	public List<OCS2015U31EmrTemplateInfo> getTemplateListItemInfo (String hospCode, String userId, String userGroup, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.EMR_TEMPLATE_ID							    ");
		sql.append("	     , B.EMR_TEMPLATE_TYPE_ID                           ");
		sql.append("	     , A.TEMPLATE_CONTENT                               ");
		sql.append("	     , A.TEMPLATE_NAME                                  ");
		sql.append("	     , A.DESCRIPTION                                    ");
		sql.append("	     , ''	PERMISSION_TYPE                             ");
		sql.append("	     , ''	HOSP_CODE                                   ");
		sql.append("	     , B.TYPE_NAME                                      ");
		sql.append("	     , A.SYS_ID                                         ");
		sql.append("	FROM EMR_TEMPLATE A, EMR_TEMPLATE_TYPE B                ");
		sql.append("	WHERE A.ACTIVE_FLG = '1'                                ");
		sql.append("	AND A.EMR_TEMPLATE_TYPE_ID = B.EMR_TEMPLATE_TYPE_ID     ");
		sql.append("	AND A.HOSP_CODE = :f_hosp_code                          ");
		sql.append("	AND B.LANGUAGE = :f_language                            ");
		if (!"ADMIN".equals(userGroup)) {
			sql.append("	AND (A.SYS_ID = :f_user_id OR A.PERMISSION_TYPE = 'S')  ");
		}
		sql.append("	ORDER BY A.EMR_TEMPLATE_ID                                  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		if (!"ADMIN".equals(userGroup)) {
			query.setParameter("f_user_id", userId);
		}
		
		List<OCS2015U31EmrTemplateInfo> list = new JpaResultMapper().list(query, OCS2015U31EmrTemplateInfo.class);
		return list;
	}
	
	@Override
	public List<OCS2015U09GetTemplateComboBoxInfo> getOCS2015U09GetTemplateComboBoxInfo (String hospCode, String userId, String language) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT A.EMR_TEMPLATE_ID,																");
		sql.append("	       B.EMR_TEMPLATE_TYPE_ID,                                                          ");
		sql.append("	       A.TEMPLATE_NAME,                                                                 ");
		sql.append("	       A.TEMPLATE_CONTENT,                                                              ");
		sql.append("	       A.DESCRIPTION,                                                                   ");
		sql.append("	       A.PERMISSION_TYPE,                                                               ");
		sql.append("	       A.SYS_ID,                                                                        ");
		sql.append("	       A.UPD_ID,                                                                        ");
		sql.append("	       A.DEFAULT_FLG                                                                    ");
		
//		sql.append("	FROM EMR_TEMPLATE A, EMR_TEMPLATE_TYPE B                                                ");
//		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                                        ");
//		sql.append("	AND (A.PERMISSION_TYPE = 'S' OR (A.PERMISSION_TYPE = 'P' AND A.SYS_ID = :f_user_id))    ");
//		sql.append("	AND B.EMR_TEMPLATE_TYPE_ID = A.EMR_TEMPLATE_TYPE_ID                                     ");
//		sql.append("	AND A.ACTIVE_FLG = '1'                                     								");
//		sql.append("	AND B.ACTIVE_FLG = '1'                                     								");
		
		sql.append("	FROM EMR_TEMPLATE A																		");
		sql.append("	JOIN EMR_TEMPLATE_TYPE B ON A.EMR_TEMPLATE_TYPE_ID = B.EMR_TEMPLATE_TYPE_ID				");
		sql.append("	                        AND B.ACTIVE_FLG = '1' AND B.LANGUAGE = :f_language				");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code														");
		sql.append("	  AND A.ACTIVE_FLG = '1'																");
		sql.append("	  AND A.SABUN = :f_user_id																");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_language", language);
		
		List<OCS2015U09GetTemplateComboBoxInfo> list = new JpaResultMapper().list(query, OCS2015U09GetTemplateComboBoxInfo.class);
		return list;
	}

	@Override
	public List<OCS2015U31GetEmrTemplateInfo> getOCS2015U31GetEmrTemplateListInfo(String hospCode, String userId,
			String templateCode, String permissionType, String level, List<String> deptCodeList, String doctorCode, boolean isCommonTab, String language) {
		
		StringBuffer sql = new StringBuffer();			
		sql.append("	SELECT  A.EMR_TEMPLATE_ID				                 																								");
		sql.append("	      , A.TEMPLATE_CODE   																																");
		sql.append("	      , A.TEMPLATE_NAME																																	");
		sql.append("	      , A.DESCRIPTION																																	");
		sql.append("	      , B.EMR_TEMPLATE_TYPE_ID  																														");
		sql.append("	      , B.SYS_ID																																		");
		sql.append("	      , A.DEFAULT_FLG																																	");
		sql.append("	FROM EMR_TEMPLATE	A																																	");
		sql.append("	LEFT JOIN EMR_TEMPLATE_TYPE B ON A.EMR_TEMPLATE_TYPE_ID = B.EMR_TEMPLATE_TYPE_ID AND B.LANGUAGE = :f_language 											");
		sql.append("	WHERE A.HOSP_CODE = :hospCode																															");
		sql.append("	  AND A.ACTIVE_FLG = 1		                             																								");
		if(!StringUtils.isEmpty(permissionType)){
			sql.append("	  AND A.PERMISSION_TYPE = :permissionType																										    ");
		}
		
		if(!StringUtils.isEmpty(templateCode)){
			sql.append("  AND A.TEMPLATE_CODE = :templateCode																													");
		}
		
		if(!StringUtils.isEmpty(level)){
			sql.append("	  AND A.LEVEL = :level																																");
		}
		
		if(isCommonTab){
			sql.append("	  AND ((A.LEVEL = 1) OR (A.LEVEL = 2 AND A.GWA IN (:deptCodeList)))");
		} else {
			sql.append("	  AND ((A.LEVEL = 1) OR (A.LEVEL = 2 AND A.GWA IN (:deptCodeList)) OR ((A.LEVEL = 3 AND A.GWA IN (:deptCodeList) AND A.SABUN = :doctorCode)))");
		}
		
		sql.append("	ORDER BY  A.EMR_TEMPLATE_ID");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!StringUtils.isEmpty(permissionType)){
			query.setParameter("permissionType", permissionType);
		}
		
		if(!StringUtils.isEmpty(templateCode)){
			query.setParameter("templateCode", templateCode);
		}
		
		if(!StringUtils.isEmpty(level)){
			query.setParameter("level", level);
		}
		
		query.setParameter("deptCodeList", deptCodeList);
		if(!isCommonTab){
			query.setParameter("doctorCode", doctorCode);
		}
		query.setParameter("f_language", language);
		
		List<OCS2015U31GetEmrTemplateInfo> list = new JpaResultMapper().list(query, OCS2015U31GetEmrTemplateInfo.class);
		return list;
	}

	@Override
	public List<DepartAndDoctorInfo> getDepartAndDoctorInfo(String hospCode, String language, String buseoGubun){
		StringBuffer sql = new StringBuffer();
		sql.append(" SELECT  DISTINCT IFNULL(A.GWA,''),																				    			");
		sql.append("         CASE WHEN A.GWA = 'ADM' THEN 'ADM' ELSE IFNULL(B.GWA_NAME, '') END  AS DEPT_NAME,										");
		sql.append("         CASE WHEN A.GWA = 'ADM' THEN '' ELSE IFNULL(A.SABUN, '') END  AS USER_ID,												");
		sql.append("         CASE WHEN A.GWA = 'ADM' THEN '' WHEN A.SABUN = 'ADM' AND 'JA' = :f_language THEN '全体' WHEN A.SABUN = 'ADM' AND 'VI' = :f_language THEN 'Toàn Bộ' WHEN A.SABUN = 'ADM' AND 'EN' = :f_language THEN 'All' ELSE IFNULL(C.DOCTOR_NAME, '') END  AS DOCTOR_NAME	");
		sql.append(" FROM EMR_TEMPLATE A																											");
		sql.append(" LEFT JOIN BAS0260 B ON A.HOSP_CODE = B.HOSP_CODE																				");
		sql.append("               AND B.GWA = A.GWA																								");
		sql.append("               AND B.LANGUAGE = :f_language																						");
		sql.append("               AND B.BUSEO_GUBUN = :f_buseoGubun																				");
		sql.append(" LEFT JOIN BAS0270 C ON A.HOSP_CODE = C.HOSP_CODE																				");
		sql.append("                    AND A.SABUN = C.SABUN																						");
		sql.append(" WHERE A.HOSP_CODE = :f_hospCode																								");
		sql.append("   AND A.LEVEL IN ('1', '2', '3')																								");
		sql.append("   AND A.PERMISSION_TYPE = 'S'																									");
		sql.append("   AND A.ACTIVE_FLG = 1																											");
		sql.append(" ORDER BY CREATED DESC																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_buseoGubun", buseoGubun);
		
		List<DepartAndDoctorInfo> list = new JpaResultMapper().list(query, DepartAndDoctorInfo.class);
		return list;
	}
	
	@Override
	public String findLastestTemplateCode(String hospCode, String templateCode, String doctorCode, String permissionType){
		StringBuffer sql = new StringBuffer();
		
		sql.append("	SELECT TEMPLATE_CODE 																			");
		sql.append("	FROM EMR_TEMPLATE 																				");
		sql.append("	WHERE HOSP_CODE = :f_hospCode																	");
		sql.append("	  AND SABUN = :f_doctorCode																		");
		sql.append("	  AND (TEMPLATE_CODE = :f_templateCode OR TEMPLATE_CODE LIKE CONCAT(:f_templateCode, '(%)'))  	");
		sql.append("	  AND PERMISSION_TYPE = :f_permissionType														");
		sql.append("	  AND ACTIVE_FLG = 1																			");
		sql.append("	ORDER BY LENGTH(TEMPLATE_CODE) DESC, TEMPLATE_CODE DESC											");
		sql.append("	LIMIT 1																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hospCode", hospCode);
		query.setParameter("f_doctorCode", doctorCode);
		query.setParameter("f_templateCode", templateCode);
		query.setParameter("f_permissionType", permissionType);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		
		return "";
	}
	
}
