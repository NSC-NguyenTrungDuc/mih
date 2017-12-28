package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.App1001RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsCHTAPPROVEgrdAPP1001Info;

public class App1001RepositoryImpl implements App1001RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getOBGetNotApproveDeseaseCnt(String hospCode, String ioGubun, String insteadYn, String approveYn,
			String doctorId, String bunho) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CAST(FN_OCS_GET_NOTAPPROVE_DESEASE(:f_hosp_code, :f_io_gubun, :f_instead_yn, :f_approve_yn, :f_doctor_id, :f_bunho) AS CHAR) FROM DUAL	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_instead_yn", insteadYn);
		query.setParameter("f_approve_yn", approveYn);
		query.setParameter("f_doctor_id", doctorId);
		query.setParameter("f_bunho", bunho);
		
		List<String> listStr = query.getResultList();
		return CollectionUtils.isEmpty(listStr) ? "" : listStr.get(0);
	}

	@Override
	public List<OcsCHTAPPROVEgrdAPP1001Info> getOcsCHTAPPROVEgrdAPP1001Info(String hospCode, String language,
			String outsangYn, String bunho, String doctor, String ioGubun, String approveYn, String prePostGubun,
			String allSangYn, Date gijunDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO             ,																												");
		sql.append("	     A.GWA               ,																													");
		sql.append("	     FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), A.HOSP_CODE, :f_language)                               GWA_NAME,								");
		sql.append("	     A.IO_GUBUN          ,																													");
		sql.append("	     A.DOCTOR            ,																													");
		sql.append("	     A.FKINP1001         ,																													");
		sql.append("	     A.INPUT_ID          ,																													");
		sql.append("	     A.SANG_CODE         ,																													");
		sql.append("	     A.SANG_NAME         ,																													");
		sql.append("	     IFNULL(CONCAT(A.PRE_MODIFIER_NAME, A.SANG_NAME, A.POST_MODIFIER_NAME), '')                     DIS_SANG_NAME,							");
		sql.append("	     A.JU_SANG_YN        ,																													");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), '')   SANG_START_DATE,																");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_END_DATE, '%Y/%m/%d'), '')     SANG_END_DATE,																");
		sql.append("	     IFNULL(A.SANG_END_SAYU, '')                              SANG_END_SAYU,																");
		sql.append("	     IFNULL(FN_BAS_LOAD_CODE_NAME('SANG_END_SAYU', A.SANG_END_SAYU, A.HOSP_CODE, :f_language), '')  SANG_END_SAYU_NAME,						");
		sql.append("	     IFNULL(A.PRE_MODIFIER1	   ,'')		  PRE_MODIFIER1,																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER2     ,'')		PRE_MODIFIER2,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER3     ,'')		PRE_MODIFIER3,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER4     ,'')		PRE_MODIFIER4,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER5     ,'')		PRE_MODIFIER5,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER6     ,'')		PRE_MODIFIER6,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER7     ,'')		PRE_MODIFIER7,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER8     ,'')		PRE_MODIFIER8,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER9     ,'')		PRE_MODIFIER9,     																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER10    ,'')		PRE_MODIFIER10,    																				");
		sql.append("	     IFNULL(A.PRE_MODIFIER_NAME ,'')		PRE_MODIFIER_NAME, 																				");
		sql.append("	     IFNULL(A.POST_MODIFIER1    ,'')		POST_MODIFIER1,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER2    ,'')		POST_MODIFIER2,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER3    ,'')		POST_MODIFIER3,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER4    ,'')		POST_MODIFIER4,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER5    ,'')		POST_MODIFIER5,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER6    ,'')		POST_MODIFIER6,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER7    ,'')		POST_MODIFIER7,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER8    ,'')		POST_MODIFIER8,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER9    ,'')		POST_MODIFIER9,    																				");
		sql.append("	     IFNULL(A.POST_MODIFIER10   ,'')		POST_MODIFIER10,   																				");
		sql.append("	     IFNULL(A.POST_MODIFIER_NAME,'')		POST_MODIFIER_NAME,																				");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_JINDAN_DATE, '%Y/%m/%d')  ,'')		SANG_JINDAN_DATE,  														");
		sql.append("	     IFNULL(B.USER_GUBUN        ,'')    USER_GUBUN,																							");
		sql.append("	     IFNULL(A.INSTEAD_YN, 'N')          INSTEAD_YN, 																						");
		sql.append("	     A.INSTEAD_ID        ,																													");
		sql.append("	     B.USER_NM           				USER_NM_INS,																						");
		sql.append("	     DATE_FORMAT(A.INSTEAD_DATE, '%Y/%m/%d')  INSTEAD_DATE,																					");
		sql.append("	     A.INSTEAD_TIME      ,                                             																		");
		sql.append("	     IFNULL(A.APPROVE_YN, 'N')                APPROVE_YN,																					");
		sql.append("	     A.APPROVE_ID,																															");
		sql.append("	     IFNULL(C.USER_NM, '')                    USER_NM_APP, 																						");
		sql.append("	     DATE_FORMAT(A.APPROVE_DATE, '%Y/%m/%d')  APPROVE_DATE,																					");
		sql.append("	     A.APPROVE_TIME      ,																													");
		sql.append("	     IFNULL(A.POSTAPPROVE_YN, 'E')            POSTAPPROVE_YN,																				");
		sql.append("	     A.PKAPP1001,																															");
		sql.append("	     'N',																																	");
		sql.append("	     CONCAT((CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END )																		");
		sql.append("	        , ( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END )																		");
		sql.append("	        , IFNULL(DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), '')																			");
		sql.append("	        , IFNULL(DATE_FORMAT(A.SANG_END_DATE, '%Y/%m/%d'), ''))          CONT_KEY															");
		sql.append("	FROM APP1001 A																																");
		sql.append("	JOIN ADM3200 B ON A.HOSP_CODE  = B.HOSP_CODE																								");
		sql.append("	              AND A.INSTEAD_ID = B.USER_ID 																									");
		sql.append("	LEFT JOIN ADM3200 C ON A.HOSP_CODE = C.HOSP_CODE																							");
		sql.append("	                   AND A.APPROVE_ID = C.USER_ID 																							");
		sql.append("	WHERE :f_outsang_yn = 'N'																													");
		sql.append("	 AND A.HOSP_CODE   = :f_hosp_code																											");
		sql.append("	 AND A.BUNHO       = :f_bunho																												");
		sql.append("	 AND SUBSTRING(A.DOCTOR, LENGTH(A.DOCTOR) - 4) = SUBSTRING(:f_doctor, LENGTH(:f_doctor) - 4)												");
		sql.append("	 AND A.IO_GUBUN    = :f_io_gubun																											");
		sql.append("	 AND A.INSTEAD_YN  = 'Y'																													");
		sql.append("	 AND A.APPROVE_YN  = :f_approve_yn																											");
		sql.append("	 AND IFNULL(A.POSTAPPROVE_YN, 'N') = :f_prepost_gubun																						");
		sql.append("	 																																			");
		sql.append("	 UNION 																																		");
		sql.append("	 SELECT A.BUNHO           ,																													");
		sql.append("	     A.GWA               ,																													");
		sql.append("	     FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), A.HOSP_CODE, :f_language) GWA_NAME,																");
		sql.append("	     A.IO_GUBUN          ,																													");
		sql.append("	     A.DOCTOR            ,																													");
		sql.append("	     A.FKINP1001         ,																													");
		sql.append("	     A.INPUT_ID          ,																													");
		sql.append("	     A.SANG_CODE         ,																													");
		sql.append("	     A.SANG_NAME         ,																													");
		sql.append("	     IFNULL(CONCAT(A.PRE_MODIFIER_NAME, A.SANG_NAME, A.POST_MODIFIER_NAME), '')   DIS_SANG_NAME,											");
		sql.append("	     A.JU_SANG_YN        ,																													");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), '')                       SANG_START_DATE,											");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_END_DATE, '%Y/%m/%d'), '')                         SANG_END_DATE,											");
		sql.append("	     IFNULL(A.SANG_END_SAYU, '')                                                  SANG_END_SAYU,											");
		sql.append("	     IFNULL(FN_BAS_LOAD_CODE_NAME('SANG_END_SAYU', A.SANG_END_SAYU, A.HOSP_CODE, :f_language), '')  SANG_END_SAYU_NAME,						");
		sql.append("	     IFNULL(A.PRE_MODIFIER1     ,'')	PRE_MODIFIER1,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER2     ,'')	PRE_MODIFIER2,    																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER3     ,'')	PRE_MODIFIER3,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER4     ,'')	PRE_MODIFIER4,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER5     ,'')	PRE_MODIFIER5,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER6     ,'')	PRE_MODIFIER6,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER7     ,'')	PRE_MODIFIER7,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER8     ,'')	PRE_MODIFIER8,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER9     ,'')	PRE_MODIFIER9,     																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER10    ,'')	PRE_MODIFIER10,    																					");
		sql.append("	     IFNULL(A.PRE_MODIFIER_NAME ,'')	PRE_MODIFIER_NAME, 																					");
		sql.append("	     IFNULL(A.POST_MODIFIER1    ,'')	POST_MODIFIER1,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER2    ,'')	POST_MODIFIER2,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER3    ,'')	POST_MODIFIER3,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER4    ,'')	POST_MODIFIER4,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER5    ,'')	POST_MODIFIER5,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER6    ,'')	POST_MODIFIER6,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER7    ,'')	POST_MODIFIER7,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER8    ,'')	POST_MODIFIER8,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER9    ,'')	POST_MODIFIER9,    																					");
		sql.append("	     IFNULL(A.POST_MODIFIER10   ,'')	POST_MODIFIER10,   																					");
		sql.append("	     IFNULL(A.POST_MODIFIER_NAME,'') POST_MODIFIER_NAME,																					");
		sql.append("	     IFNULL(DATE_FORMAT(A.SANG_JINDAN_DATE, '%Y/%m/%d')  ,'')		SANG_JINDAN_DATE,														");
		sql.append("	     IFNULL(B.USER_GUBUN, '')                 USER_GUBUN,																					");
		sql.append("	     IFNULL(C.INSTEAD_YN, 'N')                INSTEAD_YN,																					");
		sql.append("	     IFNULL(C.INSTEAD_ID, '')                 INSTEAD_ID,																					");
		sql.append("	     IFNULL(D.USER_NM, '')                    USER_NM_INS, 																					");
		sql.append("	     DATE_FORMAT(C.INSTEAD_DATE, '%Y/%m/%d')  INSTEAD_DATE,																					");
		sql.append("	     IFNULL(C.INSTEAD_TIME, '')               INSTEAD_TIME,																					");
		sql.append("	     IFNULL(C.APPROVE_YN, 'N')                APPROVE_YN,																					");
		sql.append("	     IFNULL(C.APPROVE_ID, '')                 APPROVE_ID,																					");
		sql.append("	     IFNULL(E.USER_NM, '')                    USER_NM_APP,  																				");
		sql.append("	     DATE_FORMAT(C.APPROVE_DATE, '%Y/%m/%d')  APPROVE_DATE, 																				");
		sql.append("	     IFNULL(C.APPROVE_TIME, '')               APPROVE_TIME,																					");
		sql.append("	     IFNULL(C.POSTAPPROVE_YN, 'E')            POSTAPPROVE_YN,																				");
		sql.append("	     C.PKAPP1001,																															");
		sql.append("	     'N',																																	");
		sql.append("	     CONCAT(( CASE WHEN A.JU_SANG_YN = 'Y'      THEN '0' ELSE '1' END )																		");
		sql.append("	     ,( CASE WHEN A.SANG_END_DATE IS NULL THEN '0' ELSE '1' END )																			");
		sql.append("	     ,IFNULL(DATE_FORMAT(A.SANG_START_DATE, '%Y/%m/%d'), '')																				");
		sql.append("	     ,IFNULL(DATE_FORMAT(A.SANG_END_DATE, '%Y/%m/%d'), '')) CONT_KEY																		");
		sql.append("	FROM OUTSANG A																																");
		sql.append("	LEFT JOIN ADM3200 B ON A.HOSP_CODE = B.HOSP_CODE																							");
		sql.append("	                   AND A.INPUT_ID  = B.USER_ID																								");
		sql.append("	LEFT JOIN APP1001 C ON A.HOSP_CODE = C.HOSP_CODE																							");
		sql.append("	                   AND A.FKAPP1001 = C.PKAPP1001																							");
		sql.append("	LEFT JOIN ADM3200 D ON C.HOSP_CODE = D.HOSP_CODE																							");
		sql.append("	                   AND C.INSTEAD_ID = D.USER_ID																								");
		sql.append("	LEFT JOIN ADM3200 E ON C.HOSP_CODE  = E.HOSP_CODE																							");
		sql.append("	                   AND C.APPROVE_ID = E.USER_ID																								");
		sql.append("	WHERE :f_outsang_yn = 'Y'																													");
		sql.append("	 AND A.HOSP_CODE   = :f_hosp_code																											");
		sql.append("	 AND A.BUNHO       = :f_bunho																												");
		sql.append("	 AND A.IO_GUBUN    = :f_io_gubun																											");
		sql.append("	 AND (( :f_all_sang_yn = 'Y' )																												");
		sql.append("	       OR																																	");
		sql.append("	      ( :f_all_sang_yn = 'N'																												");
		sql.append("	        AND A.SANG_START_DATE <= :f_gijun_date																								");
		sql.append("	        AND IFNULL(A.SANG_END_DATE, STR_TO_DATE('99991231','%Y/%m/%d')) >= :f_gijun_date ))													");
		sql.append("	ORDER BY 53																																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_all_sang_yn", allSangYn);
		query.setParameter("f_gijun_date", gijunDate);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_outsang_yn", outsangYn);
		query.setParameter("f_prepost_gubun", prePostGubun);
		query.setParameter("f_approve_yn", approveYn);
		
		List<OcsCHTAPPROVEgrdAPP1001Info> listData = new JpaResultMapper().list(query, OcsCHTAPPROVEgrdAPP1001Info.class);
		return listData;
	}
	
	@Override
	public String getApproveYnByPkapp1001(String hospCode, String pkapp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.APPROVE_YN CURR_YN				");
		sql.append("    FROM APP1001 A						");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code		");
		sql.append("     AND A.PKAPP1001 = :f_pkapp1001		");	
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkapp1001", CommonUtils.parseDouble(pkapp1001));
		List<String> listStr = query.getResultList();
		return CollectionUtils.isEmpty(listStr) ? "" : listStr.get(0);
	}

	@Override
	public List<ComboListItemInfo> getOcsCHTAPPROVEgrdPatientInfo(String hospCode, String ioGubun, String userId,
			String approveYn) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT B.BUNHO, B.SUNAME 									");
		sql.append("	      FROM APP1001 A												");
		sql.append("	         , OUT0101 B												");
		sql.append("	     WHERE A.HOSP_CODE = :f_hosp_code								");
		sql.append("	       AND B.HOSP_CODE = A.HOSP_CODE								");
		sql.append("	       AND B.BUNHO     = A.BUNHO									");
		sql.append("	       AND A.IO_GUBUN  = :f_io_gubun								");
		sql.append("	       AND SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR) - 4)    = :f_user_id	");
		sql.append("	       AND A.APPROVE_YN = :f_approve_yn								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_approve_yn", approveYn);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}
