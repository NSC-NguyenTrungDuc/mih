package nta.med.data.dao.medi.adm.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm3200RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM104UGridUserInfo;
import nta.med.data.model.ihis.adma.ADM3200R00grdADM3200Info;
import nta.med.data.model.ihis.adma.Adm107UFwkUserIdInfo;
import nta.med.data.model.ihis.adma.CheckAdminUserInfo;
import nta.med.data.model.ihis.adma.UserLoginFormListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.EmailToInfo;
import nta.med.data.model.ihis.emr.OCS2015U31GetADM3200UserInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00MembListInfo;
import nta.med.data.model.ihis.system.AccountInfo;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.data.model.ihis.system.FwUserInfoChangePswInfo;
import nta.med.data.model.ihis.system.PrAdmMessageCallOutputInfo;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;

/**
 * @author dainguyen.
 */
public class Adm3200RepositoryImpl implements Adm3200RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Adm3200RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	@SuppressWarnings("unchecked")
	public List<String> getUserNameByUserId(String hospitalCode, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_ADM_LOAD_USER_NAME(:userId, :hospitalCode);");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("userId", userId);

		List<String> list = query.getResultList();

		return list;
	}
	
	@Override
	public List<OcsaOCS0204U00MembListInfo> getOcsaOCS0204U00MembListOcsaOCS0204U00FindWorkerList(String hospCode, String language, String find1, boolean isAll){
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("SELECT '%', FN_ADM_MSG('221',:f_language)  ");
			sql.append(" UNION ALL                                 ");
		}
		sql.append(" SELECT A.USER_ID, B.USER_NM                                                         ");
		sql.append("   FROM ADM3200 A, ADM3211 B                                                            ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                      ");
		sql.append("	AND A.USER_ID = B.USER_ID                                                           ");
		sql.append("    AND B.START_DATE = ( SELECT MAX(X.START_DATE)                                       ");
		sql.append("                             FROM ADM3211 X                                             ");
		sql.append("                          WHERE X.HOSP_CODE = :f_hosp_code                              ");
		sql.append("                             AND B.HOSP_CODE = X.HOSP_CODE                              ");
		sql.append("                              AND X.USER_ID = B.USER_ID                                 ");
		sql.append("                              AND X.START_DATE <= DATE_FORMAT(SYSDATE(),'%Y/%m/%d') )   ");
		sql.append("    AND B.USER_NM LIKE :f_find1                                                         ");
		sql.append("	ORDER BY 1                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(isAll){ 
			query.setParameter("f_language", language);
		}
		query.setParameter("f_find1", find1+"%");
		
		List<OcsaOCS0204U00MembListInfo> list = new JpaResultMapper().list(query, OcsaOCS0204U00MembListInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getCbxActorKist(String hospCode) {
        StringBuilder sql= new StringBuilder();
        sql.append(" SELECT USER_ID                    ");
        sql.append(" , USER_NM                         ");
        sql.append(" FROM ADM3200                      ");
        sql.append(" WHERE HOSP_CODE   = :f_hosp_code   ");
        sql.append(" AND USER_GROUP  = 'CPL'           ");
        sql.append(" ORDER BY  USER_ID  DESC           ");
        Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<ComboListItemInfo> listCbxActor= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCbxActor;
	}

	@Override
	public List<ComboListItemInfo> getFwkActorListItem(String hospCode,
			String userGroup, boolean order) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_ID							");
		sql.append("	    , USER_NM                           ");
		sql.append("	 FROM ADM3200                           ");
		sql.append("	 WHERE HOSP_CODE   = :hospCode      	");
		sql.append("	 AND USER_GROUP  = :userGroup       ");
		if(order){
			sql.append("	 ORDER BY USER_ID                   ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userGroup", userGroup);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getCPL3020U00UserNmVsvJubsuja(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_NM							");
		sql.append("	FROM ADM3200                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode         	");
		sql.append("	AND USER_ID   = :code                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	@SuppressWarnings("unchecked")
	public String getSCH3001U00VsvUserName(String hospCode, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_ADM_LOAD_USER_NAME(:f_code,:f_hosp_code) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}

	@Override
	@SuppressWarnings("unchecked")
	public String getCPL3020U00LayCommon(String hospCode, String userGroup,
			String userId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_NM   				        ");
		sql.append("	FROM ADM3200                            ");
		sql.append("	WHERE HOSP_CODE   = :hospCode           ");
		sql.append("	  AND USER_GROUP  = :userGroup          ");
		sql.append("	  AND USER_ID     = :userId             ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userGroup", userGroup);
		query.setParameter("userId", userId);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public UserInfoCheckUserSubDoctorInfo callProcAdmCheckLogin(String hospCode, String language, String sysId, String userId, String userScrt, String scrtCheckYn){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_CHECK_LOGIN");
		
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SYS_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_SCRT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SCRT_CHECK_YN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_USER_NM", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_USER_DEPT", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_DEPT_NM", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_GWA_CODE", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_GWA_NAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_USER_LEVEL", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_USER_GROUP", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_USER_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_BUSEO_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_YAKSOK_COM_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_YAKSOK_OPEN_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SLIP_COM_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SLIP_OPEN_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SANG_COM_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_SANG_OPEN_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_JINDAN_COM_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_JINDAN_OPEN_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_NURSE_TEAM", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_CP_COM_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_CP_OPEN_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_INPUT_GUBUN", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_DOCTOR_ID", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_ERR_MSG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_SYS_ID", sysId);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_USER_SCRT", userScrt);
		query.setParameter("I_SCRT_CHECK_YN", scrtCheckYn);
		
		query.execute();
		UserInfoCheckUserSubDoctorInfo result = new UserInfoCheckUserSubDoctorInfo((String)query.getOutputParameterValue("O_USER_NM"),
				(String)query.getOutputParameterValue("O_USER_DEPT"),
				(String)query.getOutputParameterValue("O_DEPT_NM"),
				(String)query.getOutputParameterValue("O_GWA_CODE"),
				(String)query.getOutputParameterValue("O_GWA_NAME"),
				(String)query.getOutputParameterValue("O_USER_LEVEL"),
				(String)query.getOutputParameterValue("O_USER_GROUP"),
				(String)query.getOutputParameterValue("O_USER_GUBUN"),
				(String)query.getOutputParameterValue("O_BUSEO_GUBUN"),
				(String)query.getOutputParameterValue("O_YAKSOK_COM_ID"),
				(String)query.getOutputParameterValue("O_YAKSOK_OPEN_ID"),
				(String)query.getOutputParameterValue("O_SLIP_COM_ID"),
				(String)query.getOutputParameterValue("O_SLIP_OPEN_ID"),
				(String)query.getOutputParameterValue("O_SANG_COM_ID"),
				(String)query.getOutputParameterValue("O_SANG_OPEN_ID"),
				(String)query.getOutputParameterValue("O_JINDAN_COM_ID"),
				(String)query.getOutputParameterValue("O_JINDAN_OPEN_ID"),
				(String)query.getOutputParameterValue("O_NURSE_TEAM"),
				(String)query.getOutputParameterValue("O_CP_COM_ID"),
				(String)query.getOutputParameterValue("O_CP_OPEN_ID"),
				(String)query.getOutputParameterValue("O_INPUT_GUBUN"),
				(String)query.getOutputParameterValue("O_DOCTOR_ID"),
				(String)query.getOutputParameterValue("O_ERR_MSG"),
				hospCode,"");

		return result;
	}
	
	@Override
	public PrAdmMessageCallOutputInfo callPrAdmMessageCall(String hospCode, String language, String userId, String userTrm,
			String senderId, String msgTitle, String msgContents, String sendAllCnfmYn, String receiveGubun, String receiverId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_CHECK_LOGIN");
		
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_TRM", String.class, ParameterMode.IN);		
		query.registerStoredProcedureParameter("I_SENDER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MSG_TITLE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MSG_CONTENTS", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEND_ALL_CNFM_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RECVER_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RECVER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR_FLAG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("T_SEND_SEQ", Integer.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_USER_TRM", userTrm);
		query.setParameter("I_SENDER_ID", senderId);
		query.setParameter("I_MSG_TITLE", msgTitle);
		query.setParameter("I_MSG_CONTENTS", msgContents);
		query.setParameter("I_SEND_ALL_CNFM_YN", sendAllCnfmYn);
		query.setParameter("I_RECVER_GUBUN", receiveGubun);
		query.setParameter("I_RECVER_ID", receiverId);
		
		query.execute();
		PrAdmMessageCallOutputInfo result = new PrAdmMessageCallOutputInfo((String)query.getOutputParameterValue("O_ERR_FLAG"),
				(Integer)query.getOutputParameterValue("T_SEND_SEQ"));
		return result;
	}
	
	@Override
	@SuppressWarnings("unchecked")
	public String getEnablePostApprove(String hospCode, String doctor){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.POSTAPPROVE_YN, 'N') POSTAPPROVE_YN                   ");
		sql.append("        FROM ADM3200 A                                                 ");
		sql.append("       WHERE A.HOSP_CODE  = :f_hosp_code                               ");
		sql.append("         AND A.USER_ID    = SUBSTR(:f_doctor, LENGTH(:f_doctor) - 4)   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOFMakeUserCombo(String hospCode,String find,boolean isDoctorMode) {
		StringBuilder sql = new StringBuilder();
		find=find+"%";
		sql.append("  SELECT A.USER_ID, B.USER_NM                                   ");
		sql.append("  FROM ADM3200 A, ADM3211 B                                     ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                              ");
		sql.append("   AND B.HOSP_CODE  = A.HOSP_CODE                               ");
		sql.append("   AND A.USER_ID    = B.USER_ID                                 ");
		sql.append("   AND B.START_DATE = ( SELECT MAX(X.START_DATE)                ");
		sql.append("                          FROM ADM3211 X                        ");
		sql.append("                         WHERE X.HOSP_CODE  = B.HOSP_CODE       ");
		sql.append("                           AND X.USER_ID    = B.USER_ID         ");
		sql.append("                           AND X.START_DATE <= SYSDATE() )      ");
		sql.append("   AND B.USER_NM LIKE :f_find1                                  ");
		if(isDoctorMode){
			sql.append("   AND A.USER_GUBUN = '1'                                   ");
		}else{
			sql.append("  AND A.USER_GUBUN != '1'                                   ");
		}
		sql.append("  ORDER BY 1 													");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getDRG0201U00CbxActor(String hospCode, String userGroup, boolean userEndYmd) {
		StringBuilder sql = new StringBuilder();
		//sql.append(" SELECT '' USER_ID, '' USER_NM                                  ");
		//sql.append(" UNION                                                          ");
		sql.append(" SELECT A.USER_ID, A.USER_NM                                    ");
		sql.append("   FROM ADM3200 A                                               ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                            ");
		sql.append("    AND A.USER_GROUP  = :userGroup                             ");
		if(userEndYmd){
			sql.append("    AND IFNULL(A.USER_END_YMD, '9998/12/31') >= SYSDATE()   ");
		}
		sql.append(" ORDER BY USER_ID IS NULL 										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("userGroup", userGroup);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ADM104UGridUserInfo> getADM104UGridUserInfo(String hospCode, String language, String userGroup, String searchWord, String userGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.USER_ID,                                                                      	  ");
		sql.append("       A.USER_NM,                                                                      	  ");
		sql.append("       A.USER_SCRT,                                                                    	  ");
		sql.append("       A.DEPT_CODE,                                                                    	  ");
		sql.append("       B.BUSEO_NAME,                                                                   	  ");
		sql.append("       A.USER_GROUP,                                                                   	  ");
		sql.append("       C.GROUP_NM,                                                                     	  ");
		sql.append("       A.USER_LEVEL,                                                                   	  ");
		sql.append("       A.USER_END_YMD,                                                                 	  ");
		sql.append("       A.USER_GUBUN,                                                                   	  ");
		sql.append("       A.NURSE_CONFIRM_ENABLE_YN,                                                      	  ");
		sql.append("       A.CO_ID,                                                                        	  ");
		sql.append("       A.EMAIL,                                                                        	  ");
		sql.append("       D.CLIS_SMO_ID,                                                                  	  ");
		sql.append("       A.LOGIN_FLG                                                                   	  ");
		sql.append("       , E.CHANGE_PWD_FLG                                                                 ");
		sql.append("       , E.PWD_HISTORY	                                                                  ");
		sql.append("  FROM ADM3200 A                                                                       	  ");
		sql.append("      LEFT JOIN ( SELECT D.HOSP_CODE, D.BUSEO_CODE, D.BUSEO_NAME                       	  ");
		sql.append("            FROM BAS0260 D                                                             	  ");
		sql.append("           WHERE D.HOSP_CODE = :f_hosp_code                                            	  ");
		sql.append("             AND D.LANGUAGE = :language                                                	  ");
		sql.append("             AND SYSDATE() BETWEEN D.START_DATE AND D.END_DATE                         	  ");
		sql.append("        ) B                                                                            	  ");
		sql.append("      ON B.HOSP_CODE = A.HOSP_CODE AND B.BUSEO_CODE = A.DEPT_CODE                      	  ");
		sql.append("      LEFT JOIN ADM3100 C ON C.HOSP_CODE = A.HOSP_CODE AND C.USER_GROUP = A.USER_GROUP AND C.LANGUAGE = :language	  ");
		sql.append("      LEFT JOIN CLIS_SMO D ON A.HOSP_CODE = D.HOSP_CODE AND A.CLIS_SMO_ID = D.CLIS_SMO_ID ");
		sql.append("      LEFT JOIN LOGIN_EXT E ON E.HOSP_CODE = A.HOSP_CODE AND E.USER_ID = A.USER_ID		  ");
		sql.append(" WHERE A.HOSP_CODE         = :f_hosp_code                                              	  ");
		if(!StringUtils.isEmpty(userGroup)){
			sql.append("   AND A.USER_GROUP LIKE :f_user_group                                                ");
		}
		if(!StringUtils.isEmpty(searchWord)){
			sql.append("   AND (A.USER_ID  LIKE :f_search_word OR A.USER_NM LIKE :f_search_word)              ");
		}
		if(!StringUtils.isEmpty(userGubun)){
			sql.append("   AND A.USER_GUBUN LIKE :f_user_gubun                                                ");
		}
		sql.append(" ORDER BY A.HOSP_CODE, A.USER_ID                                                          ");
		sql.append(" LIMIT 500                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(userGroup)){
			query.setParameter("f_user_group", userGroup + "%");
		}
		if(!StringUtils.isEmpty(searchWord)){
			query.setParameter("f_search_word", searchWord + "%");
		}
		if(!StringUtils.isEmpty(userGubun)){
			query.setParameter("f_user_gubun", userGubun);
		}
		List<ADM104UGridUserInfo > list = new JpaResultMapper().list(query, ADM104UGridUserInfo .class);
		return list;
	}
	
	@Override
	public String callPrAdmInsertSubpartDoctor(String hospitalCode, String userId, String iud) {
		LOGGER.info("[START] callPrAdmInsertSubpartDoctor");
		String ioFlg = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_INSERT_SUBPART_DOCTOR");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT);;
		query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospitalCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_IUD", iud);
		
		ioFlg = (String)query.getOutputParameterValue("O_ERR");
		return ioFlg;
	}
	
	@Override
	public List<Adm107UFwkUserIdInfo> getAdm107uFwkUserID(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.USER_ID        AS USER_ID                              ");
		sql.append("       , A.USER_NM         AS USER_NM                           ");
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			sql.append("    , 'ユーザ'          AS GROUP_USER                         ");
		}else if(Language.ENGLISH.toString().equalsIgnoreCase(language)){
			sql.append("       , 'User'         AS GROUP_USER                       ");
		}else if(Language.VIETNAMESE.toString().equalsIgnoreCase(language)){
			sql.append("       , 'Người Dùng'          AS GROUP_USER                ");
		}
		sql.append("  FROM ADM3200 A                                                ");
		sql.append(" WHERE A.HOSP_CODE        = :f_hosp_code                        ");
		sql.append(" UNION                                                          ");
		sql.append("SELECT A.USER_GROUP         AS USER_ID                          ");
		sql.append("       , A.GROUP_NM         AS USER_NM                          ");
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			sql.append("       , 'ユーザグループ'          AS GROUP_USER                 ");
		}else if(Language.ENGLISH.toString().equalsIgnoreCase(language)){
			sql.append("       , 'Group'         AS GROUP_USER                      ");
		}else if(Language.VIETNAMESE.toString().equalsIgnoreCase(language)){
			sql.append("       ,  'Nhóm người dùng'        AS GROUP_USER            ");
		}
		sql.append("  FROM ADM3100 A                                                ");
		sql.append(" WHERE A.HOSP_CODE        = :f_hosp_code                        ");
		sql.append(" AND A.LANGUAGE = :language                                     ");
		sql.append(" ORDER BY 1                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<Adm107UFwkUserIdInfo> list = new JpaResultMapper().list(query, Adm107UFwkUserIdInfo.class);
		return list;
	}
	
	@Override
	@SuppressWarnings("unchecked")
	public List<String> getAdm107uUserNm(String hospCode, String userId, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.USER_NM         AS USER_NM      ");
		sql.append("  FROM ADM3200 A                         ");
		sql.append(" WHERE A.HOSP_CODE        = :f_hosp_code ");
		sql.append("  AND  A.USER_ID        = :userId   	 ");
		sql.append(" UNION                                   ");
		sql.append("SELECT A.GROUP_NM         AS USER_NM     ");
		sql.append("  FROM ADM3100 A                         ");
		sql.append(" WHERE A.HOSP_CODE       = :f_hosp_code  ");
		sql.append("  AND  A.USER_GROUP      = :userId		 ");
		sql.append(" AND A.LANGUAGE = :language              ");
		sql.append(" ORDER BY 1                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("userId", userId);
		query.setParameter("language", language);
		return query.getResultList();
	}
	
	public List<ComboListItemInfo> getUserIdUserNameInfo (String userGroup, String userGubun, String hospCode,
			boolean userEndYmd, String date){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '' USER_ID							 ");
		sql.append("	     , '' USER_NM                            ");
		sql.append("	UNION                                        ");
		sql.append("	SELECT USER_ID                               ");
		sql.append("	     , USER_NM                               ");
		sql.append("	  FROM ADM3200                               ");
		sql.append("	 WHERE HOSP_CODE   = :hospCode				 ");
		sql.append("	   AND USER_GROUP  = :f_user_group           ");
		sql.append("	   AND USER_GUBUN  = :userGubun              ");
		if(userEndYmd){
			sql.append("    AND IFNULL(USER_END_YMD, '9998/12/31') >= :date   ");
		}
		sql.append("	 ORDER BY USER_ID IS NULL                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_user_group", userGroup);
		query.setParameter("userGubun", userGubun);
		if(userEndYmd){
			query.setParameter("date", date);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexPfesCaseListItem(
			String hospCode, String userGroup, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '' USER_ID												");
		sql.append("	    , '' USER_NM                                                ");
		sql.append("	 UNION                                                          ");
		sql.append("	 SELECT USER_ID                                                 ");
		sql.append("	    , USER_NM                                                   ");
		sql.append("	 FROM ADM3200                                                   ");
		sql.append("	WHERE HOSP_CODE   = :hospCode                                   ");
		sql.append("	  AND USER_GROUP  = :userGroup                                  ");
		sql.append("	  AND USER_ID     IN (SELECT CODE_NAME                          ");
		sql.append("	                        FROM OCS0132                            ");
		sql.append("	                        WHERE HOSP_CODE   = :hospCode           ");
		sql.append("	                        AND CODE_TYPE     = :codeType           ");
		sql.append("							AND LANGUAGE = :language)               ");
		sql.append("	ORDER BY USER_ID IS NULL                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userGroup", userGroup);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexOprsCaseListItem(
			String hospCode, String userGroup, String userGubun,String deptCode,
			 boolean order) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.USER_ID						");
		sql.append("	    , A.USER_NM                         ");
		sql.append("	 FROM ADM3200 A                         ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode          ");
		sql.append("	  AND A.USER_GROUP = :userGroup         ");
		sql.append("	  AND A.DEPT_CODE  = :deptCode          ");
		sql.append("	  AND A.USER_GUBUN = :userGubun         ");
		if(order){
			sql.append("	ORDER BY A.USER_ID                  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userGroup", userGroup);
		query.setParameter("deptCode", deptCode);
		query.setParameter("userGubun", userGubun);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexNuriCaseListItem(
			String hospCode, String userGroup, String userGubun, String hoDong,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.USER_ID							");
		sql.append("	    , A.USER_NM                             ");
		sql.append("	 FROM ADM3200 A                             ");
		sql.append("	    , BAS0260 B                             ");
		sql.append("	WHERE A.HOSP_CODE  = :hospCode              ");
		sql.append("	  AND A.USER_GROUP = :userGroup             ");
		sql.append("	  AND A.USER_GUBUN = :userGubun             ");
		sql.append("	  AND B.HOSP_CODE = A.HOSP_CODE             ");
		sql.append("	  AND B.BUSEO_NAME = :hoDong                ");
		sql.append("	  AND B.LANGUAGE = :language                ");
		sql.append("	  AND B.BUSEO_CODE = A.DEPT_CODE            ");
		sql.append("	ORDER BY A.USER_ID                          ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userGroup", userGroup);
		query.setParameter("userGubun", userGubun);
		query.setParameter("hoDong", hoDong);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CheckAdminUserInfo> getCheckAdminUserInfo(String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.USER_SCRT, A.USER_GROUP, IF(A.USER_END_YMD IS NULL,'Y','N') USE_YN, A.CLIS_SMO_ID  CLIS_SMO_ID,   ");
		sql.append("       A.HOSP_CODE,                                                                          			  ");
		sql.append("       B.LANGUAGE                                                                                         ");
		sql.append("FROM ADM3200 A                                                         						 			  ");
		sql.append("LEFT JOIN BAS0001 B ON A.HOSP_CODE = B.HOSP_CODE                                             			  ");
		sql.append("AND B.START_DATE = (SELECT MAX(X.START_DATE) FROM BAS0001 X WHERE X.HOSP_CODE = B.HOSP_CODE) 			  ");
		sql.append("WHERE A.USER_ID = :user_id                                                                   			  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("user_id", userId);
		List<CheckAdminUserInfo> list = new JpaResultMapper().list(query, CheckAdminUserInfo.class);
		return list;
	}
	
	public List<EmailToInfo> getEmailToInfoList (String emrRecordId) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT EMAIL								");
		sql.append("	       , USER_NM                            ");
		sql.append("	       , USER_ID                            ");
		sql.append("	FROM ADM3200 WHERE USER_ID IN (             ");
		sql.append("	  SELECT DISTINCT A.USERID FROM (           ");
		sql.append("	    SELECT DISTINCT UPD_ID USERID           ");
		sql.append("	    FROM EMR_RECORD                         ");
		sql.append("	    WHERE EMR_RECORD_ID = :f_emr_record_id  ");
		sql.append("	  UNION ALL                                 ");
		sql.append("	    SELECT DISTINCT SYS_ID USERID           ");
		sql.append("	    FROM EMR_RECORD                         ");
		sql.append("	    WHERE EMR_RECORD_ID = :f_emr_record_id  ");
		sql.append("	  UNION ALL                                 ");
		sql.append("	    SELECT DISTINCT UPD_ID USERID           ");
		sql.append("	    FROM EMR_RECORD_HISTORY                 ");
		sql.append("	    WHERE EMR_RECORD_ID = :f_emr_record_id  ");
		sql.append("	  UNION ALL                                 ");
		sql.append("	    SELECT DISTINCT SYS_ID USERID           ");
		sql.append("	    FROM EMR_RECORD_HISTORY                 ");
		sql.append("	    WHERE EMR_RECORD_ID = :f_emr_record_id  ");
		sql.append("	  ) A                                       ");
		sql.append("	)                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_emr_record_id", emrRecordId);
		
		List<EmailToInfo> list = new JpaResultMapper().list(query, EmailToInfo.class);
		return list;
	}
	
	public ComboListItemInfo getDoctorCodeName (String userId) {
		StringBuffer sql = new StringBuffer();	
		sql.append("SELECT USER_NM, USER_ID FROM ADM3200 WHERE USER_ID = :f_user_id ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		if (!CollectionUtils.isEmpty(list) && list.get(0)!=null) {
			return list.get(0);
		}
		
		return null;
	}
	
	public UserLoginFormListItemInfo getUserLoginFormListItemInfo (String userId, String pwd) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT USER_ID, 				");
		sql.append("	       USER_NM,                 ");
		sql.append("	       USER_GROUP,              ");
		sql.append("	       HOSP_CODE                ");
		sql.append("	FROM ADM3200                    ");
		sql.append("	WHERE USER_ID = :f_user_id      ");
		sql.append("	  AND USER_SCRT = :f_user_scrt  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_user_scrt", pwd);
		
		List<UserLoginFormListItemInfo> list = new JpaResultMapper().list(query, UserLoginFormListItemInfo.class);
		if (!CollectionUtils.isEmpty(list) && list.get(0)!=null) {
			return list.get(0);
		}
		
		return null;
	}

	@Override
	public AdmLoginFormCheckLoginUserInfo getAdmLoginFormCheckLoginUserInfo(
			String userId, String password, String hospCode) {
		StringBuffer sql = new StringBuffer();	
		sql.append("SELECT A.USER_ID, 			                                                                 ");
		sql.append("       A.USER_NM,                                                                            ");
		sql.append("       A.USER_GROUP,                                                                         ");
		sql.append("       A.HOSP_CODE,                                                                          ");
		sql.append("       B.LANGUAGE,                                                                           ");
		sql.append("       A.CLIS_SMO_ID  CLIS_SMO_ID                                          					 ");
		sql.append("       , A.LOGIN_FLG                                                                         ");
		sql.append("       , DATE_FORMAT(A.USER_END_YMD,'%Y/%m/%d')                                              ");
		sql.append("       ,CASE WHEN (IFNULL(A.CERT_EXPIRED, STR_TO_DATE('9998/12/31','%Y/%m/%d')) > SYSDATE()) ");
		sql.append(" THEN 'N' ELSE 'Y' END CERT_EXPIRED                                                          ");
		sql.append("       ,B.TIME_ZONE                                                                          ");
		//sql.append("       , ATTEMPT_TIMES                                                                       ");
		sql.append("FROM ADM3200 A                                                                               ");
		sql.append("LEFT JOIN BAS0001 B ON A.HOSP_CODE = B.HOSP_CODE                                             ");
		sql.append("AND B.START_DATE = (SELECT MAX(X.START_DATE) FROM BAS0001 X WHERE X.HOSP_CODE = B.HOSP_CODE) ");                       
		sql.append("WHERE USER_ID = :f_user_id                                                                   ");
		sql.append("  AND USER_SCRT = :f_user_scrt   And A.HOSP_CODE = :f_hosp_code                               ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_user_scrt", password);
		query.setParameter("f_hosp_code", hospCode);
		List<AdmLoginFormCheckLoginUserInfo> list = new JpaResultMapper().list(query, AdmLoginFormCheckLoginUserInfo.class);
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<FwUserInfoChangePswInfo> getFwUserInfoChangePswInfo(String hospCode, String userId) {
		StringBuffer sql = new StringBuffer();	
		sql.append(" SELECT A.USER_END_YMD USER_END_YMD    ,A.USER_SCRT PSWD        ");
		sql.append(" FROM ADM3200 A                                                 ");
		sql.append("   WHERE A.HOSP_CODE  = :f_hosp_code                            ");
		sql.append(" AND A.USER_ID = :f_user_id										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		List<FwUserInfoChangePswInfo> list = new JpaResultMapper().list(query, FwUserInfoChangePswInfo.class);
		return list;
	}
	
	@Override
	public AdmLoginFormCheckLoginUserInfo getAdmLoginFormCheckLoginUserInfoByUserId(
			String userId) {
		StringBuffer sql = new StringBuffer();	
		sql.append("SELECT A.USER_ID, 			                                                                 ");
		sql.append("       A.USER_NM,                                                                            ");
		sql.append("       A.USER_GROUP,                                                                         ");
		sql.append("       A.HOSP_CODE,                                                                          ");
		sql.append("       B.LANGUAGE,                                                                           ");
		sql.append("       A.CLIS_SMO_ID  CLIS_SMO_ID                                          					 ");
		sql.append("       , A.LOGIN_FLG                                                                         ");
		sql.append("       , ATTEMPT_TIMES                                                                       ");
		sql.append("FROM ADM3200 A                                                                               ");
		sql.append("LEFT JOIN BAS0001 B ON A.HOSP_CODE = B.HOSP_CODE                                             ");
		sql.append("AND B.START_DATE = (SELECT MAX(X.START_DATE) FROM BAS0001 X WHERE X.HOSP_CODE = B.HOSP_CODE) ");                       
		sql.append("WHERE USER_ID = :f_user_id                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		
		List<AdmLoginFormCheckLoginUserInfo> list = new JpaResultMapper().list(query, AdmLoginFormCheckLoginUserInfo.class);
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2015U31GetADM3200UserInfo> getAdminListOCS2015U31GetADM3200UserInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.USER_ID,									");
		sql.append("	 A.USER_GROUP,                                      ");  
		sql.append("	 B.SYS_ID,                                          ");       
		sql.append("	 A.USER_NM                                          ");     
		sql.append("	FROM ADM3200 A, EMR_TEMPLATE B                      ");
		sql.append("	WHERE A.USER_ID = B.SYS_ID                          ");
		sql.append("	AND A.HOSP_CODE = B.HOSP_CODE                       ");
		sql.append("	AND A.HOSP_CODE = :hospCode                         ");
		sql.append("	AND B.ACTIVE_FLG = '1'                              ");
		sql.append("	ORDER BY B.CREATED                                  ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		
		List<OCS2015U31GetADM3200UserInfo> list = new JpaResultMapper().list(query, OCS2015U31GetADM3200UserInfo.class);
		return list;
	}

	@Override
	public List<OCS2015U31GetADM3200UserInfo> getNursOrDoctorListOCS2015U31GetADM3200UserInfo(
			String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_ID,										");
		sql.append("	 USER_GROUP,                                      	");  
		sql.append("	 SYS_ID,                                          	");       
		sql.append("	 USER_NM                                            ");    
		sql.append("	FROM ADM3200                						");
		sql.append("	WHERE USER_ID = :userId     						");
		sql.append("	AND HOSP_CODE = :hospCode         					");
		sql.append("	AND USER_GROUP IN ('NUR','OCS')         			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userId", userId);
		
		List<OCS2015U31GetADM3200UserInfo> list = new JpaResultMapper().list(query, OCS2015U31GetADM3200UserInfo.class);
		return list;
	}
	
	@Override
	public boolean isExistedAdma(String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'                 						");
		sql.append("	   FROM ADM3200            	 					");
		sql.append("	WHERE HOSP_CODE =      :hospCode 				");
		sql.append("	   AND USER_ID =  :userId         				");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userId", userId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		return false;
	}
	
	@Override
	public List<ComboListItemInfo> getOCSACT2GetComboUser(String hospCode, String userGroup, boolean order) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_ID							");
		sql.append("	    , USER_NM                           ");
		sql.append("	 FROM ADM3200                           ");
		sql.append("	 WHERE HOSP_CODE   = :hospCode      	");
		if(!CommonEnum.PERCENTAGE.getValue().equals(userGroup)){
			sql.append("	 AND USER_GROUP  = :userGroup       ");
		}
		if(order){
			sql.append("	 ORDER BY USER_ID                   ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if(!CommonEnum.PERCENTAGE.getValue().equals(userGroup)){
			query.setParameter("userGroup", userGroup);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getExeDoctorListItemInfo(String hospCode, String gwa) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.USER_ID	CODE														                                                       ");
		sql.append("     , A.USER_NM   CODE_NAME                                                                                                                   ");
		sql.append("  FROM ADM3200 A                                                                                                                               ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("   AND A.USER_GROUP IN ('NUR', 'NUT', 'OCS','XRT', 'CPL', 'DRG')        																			   ");
		
		if(!"%".equals(gwa) && !Strings.isEmpty(gwa)){
			sql.append("   AND A.DEPT_CODE    = :f_gwa                                                                                                             ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		if(!"%".equals(gwa) && !Strings.isEmpty(gwa)){
			query.setParameter("f_gwa", gwa);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public AccountInfo verifyAccountInfo(String userId, String password, String hospCode) {
		StringBuffer sql = new StringBuffer();	
		sql.append(" SELECT                                                             										");
		sql.append("   A.USER_ID,                                                       										");
		sql.append("   A.USER_NM                                                        										");
		sql.append(" FROM ADM3200 A, ADM3500 B                                          										");
		sql.append(" WHERE 1 = 1                                                        										");
		sql.append(" 	AND A.HOSP_CODE						=	:f_hosp_code													");
		sql.append(" 	AND A.USER_ID						=	:f_user_id														");
		sql.append(" 	AND A.USER_SCRT						=	:f_user_scrt													");
		sql.append(" 	AND A.HOSP_CODE						=	B.HOSP_CODE														");
		sql.append(" 	AND (A.USER_ID 						=	B.USER_ID 			OR A.USER_GROUP = B.USER_ID) 				");
		sql.append(" 	AND B.SYS_ID						=	'MBSS'		            										");
			
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_user_scrt", password);
		query.setParameter("f_hosp_code", hospCode);
		List<AccountInfo> list = new JpaResultMapper().list(query, AccountInfo.class);
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}
	
	public List<ADM3200R00grdADM3200Info> getADM3200R00grdADM3200Info(String hospCode, String userGroup, String hoDong, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.USER_ID							 															");
		sql.append("	    ,  A.USER_NM                           																");
		sql.append("        ,  FN_BAS_LOAD_BUSEO_NAME(A.HOSP_CODE, A.DEPT_CODE, SYSDATE()) BUSEO_NAME							");
		sql.append("        ,  A.CO_ID 																							");
		sql.append("	 FROM ADM3200 A										                           							");
		sql.append("     JOIN BAS0260 B  ON B.HOSP_CODE  = A.HOSP_CODE 															");
		sql.append("    				AND B.BUSEO_CODE = A.DEPT_CODE															");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code      																");
		sql.append("       AND A.USER_GROUP  LIKE :f_user_group																	");
		sql.append(" 	   AND B.GWA		 LIKE :f_ho_dong																	");
		sql.append("	 ORDER BY A.USER_ID																						");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		
		if(StringUtils.isEmpty(userGroup)){
			userGroup = "NUR";
		}
		query.setParameter("f_user_group", userGroup);
		
		if(StringUtils.isEmpty(hoDong)){
			hoDong = "%";
		}
		query.setParameter("f_ho_dong", hoDong);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<ADM3200R00grdADM3200Info> list = new JpaResultMapper().list(query, ADM3200R00grdADM3200Info.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> callFnPpeLoadConfirmEnable(String hospCode, String uerId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT USER_NM, FN_PPE_LOAD_CONFIRM_ENABLE(:f_hosp_code, :f_user_id) CONFIRM_GRANT 	");
		sql.append("    FROM ADM3200    																	");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code 														");
		sql.append("    AND USER_ID    = :f_user_id 														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", uerId);
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS2003U99DeptCodeRequest(String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DEPT_CODE  				");
		sql.append("    FROM ADM3200 A  				");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code ");
		sql.append("     AND A.USER_ID = :f_reciever_id ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_reciever_id", userId);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public String getUserNmByUserId(String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT USER_NM							");
		sql.append("	FROM ADM3200                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode         	");
		sql.append("	AND USER_ID   = :userId                 ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userId", userId);
		
		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}

	@Override
	public String getOCS6010U10frmARActingUserNm(String hospCode, String userId) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT				             		");
		sql.append("	  	USER_NM				             	");
		sql.append("	FROM				             		");
		sql.append("	  	ADM3200				             	");
		sql.append("	WHERE				             		");
		sql.append("	  	HOSP_CODE 	= :f_hosp_code			");
		sql.append("	  	AND USER_ID	= :f_user_id			");


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<String> getNurUserId(String hospCode, String coId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_NUR_GET_USER_ID(:hospCode, :coId)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("coId", coId);

		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getDRG3010P99cbxActor(String hospCode, String userGroup){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT '' USER_ID																		");
		sql.append("          , '' USER_NM																		");
		sql.append("       FROM DUAL																			");
		sql.append("     UNION																					");
		sql.append("     SELECT A.USER_ID																		");
		sql.append("          , A.USER_NM																		");
		sql.append("       FROM ADM3200 A																		");
		sql.append("      WHERE A.HOSP_CODE   = :f_hosp_code													");
		sql.append("        AND A.USER_GROUP  = :f_user_group													");
		sql.append("        AND IFNULL(A.USER_END_YMD, STR_TO_DATE('9998/12/31','%Y/%m/%d')) >= CURRENT_DATE()	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_group", userGroup);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getCbxActorByUserGroup(String hospCode, String userGroup) {
        StringBuilder sql= new StringBuilder();
        sql.append("	SELECT '' USER_ID                                                                  ");
        sql.append("	     , '' USER_NM                                                                  ");
        sql.append("	FROM DUAL                                                                          ");
        sql.append("	UNION                                                                              ");
        sql.append("	SELECT A.USER_ID                                                                   ");
        sql.append("	     , A.USER_NM                                                                   ");
        sql.append("	  FROM ADM3200 A                                                                   ");
        sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                ");
        sql.append("	   AND A.USER_GROUP  = :f_user_group                                               ");
        sql.append("	   AND IFNULL(A.USER_END_YMD, STR_TO_DATE('9998/12/31', '%Y/%m/%d')) >= SYSDATE()  ");
        sql.append("	ORDER BY USER_ID                                                                   ");
        
        Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_group", userGroup);
		
		List<ComboListItemInfo> listCbxActor= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCbxActor;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR6011U01UserNmByBuseoName(String hospCode, String buseoName) {
        StringBuilder sql= new StringBuilder();
        sql.append("   SELECT A.USER_ID, A.USER_NM                                                   ");
        sql.append("     FROM ADM3200 A                                                              ");
        sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                             ");
        sql.append("      AND A.DEPT_CODE = (SELECT B.BUSEO_CODE                                     ");
        sql.append("                           FROM BAS0260 B                                        ");
        sql.append("                          WHERE B.BUSEO_NAME = :f_buseo_name)                    ");
        sql.append("    ORDER BY A.USER_ID                                                           ");
        Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_name", buseoName);
		
		List<ComboListItemInfo> listCbxActor= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCbxActor;
	}
	
	@Override
	public List<ComboListItemInfo> getCbxNUR1020U00fwkWriter(String hospCode, String buseoName, Date nurWrdt) {
		StringBuilder sql= new StringBuilder();
		sql.append("	SELECT USER_ID, USER_NM                                  ");
		sql.append("	  FROM ADM3200                                           ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code                          ");
		sql.append("	   AND (USER_END_YMD IS NULL                             ");
		sql.append("	        OR :f_nur_wrdt < USER_END_YMD)                   ");
		sql.append("	   AND DEPT_CODE = (SELECT B.BUSEO_CODE                  ");
		sql.append("	                      FROM BAS0260 B                     ");
		sql.append("	                     WHERE B.HOSP_CODE  = :f_hosp_code   ");
		sql.append("	                       AND B.BUSEO_NAME = :f_buseo_name) ");
		sql.append("	 ORDER BY USER_ID                                        ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_name", buseoName);
		query.setParameter("f_nur_wrdt", nurWrdt);
		
		List<ComboListItemInfo> lstData= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstData;
	}

	@Override
	public List<ComboListItemInfo> getCbxNUR1020U00layNURList(String hospCode, String buseoName) {
		StringBuilder sql= new StringBuilder();
		sql.append("	SELECT USER_ID, USER_NM 								");
		sql.append("	FROM ADM3200 											");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code							");
		sql.append("	 AND DEPT_CODE = (SELECT B.BUSEO_CODE					");
		sql.append("	                    FROM BAS0260 B						");
		sql.append("	                   WHERE B.HOSP_CODE  = :f_hosp_code	");
		sql.append("	                     AND B.BUSEO_NAME = :f_buseo_name)	");
		sql.append("	ORDER BY USER_ID										");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_name", buseoName);
		
		List<ComboListItemInfo> lstData= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstData;
	}
	
	@Override
	public String checkNUR1010Q00CheckNurseID(String hospCode, String userId) {

		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                       ");
		sql.append("     FROM DUAL                                                      ");
		sql.append("    WHERE EXISTS ( SELECT 'Y'                                       ");
		sql.append("                     FROM ADM3200 A                                 ");
		sql.append("                    WHERE A.HOSP_CODE = :f_hosp_code                ");
		sql.append("                      AND A.USER_GROUP LIKE 'NUR%'                  ");
		sql.append("                      AND A.USER_ID = :f_user_id)                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1010U00fwkNurse(String hospCode, String buseoCode, String sabun) {
		StringBuilder sql= new StringBuilder();
		sql.append("   SELECT B.USER_ID                              ");
		sql.append("        , B.USER_NM                              ");
		sql.append("     FROM ADM3200 B                              ");
		sql.append("    WHERE B.HOSP_CODE = :f_hosp_code             ");
		sql.append("      AND (B.USER_END_YMD IS NULL                ");
		sql.append("       OR SYSDATE() < B.USER_END_YMD)            ");
		sql.append("      AND B.USER_ID LIKE :f_sabun                ");
		sql.append("      AND B.USER_GUBUN = '2'                     ");
		sql.append("      AND B.DEPT_CODE  = :f_buseo_code           ");
		sql.append("    ORDER BY B.USER_ID, B.USER_NM                ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		
		if(sabun == null || sabun == ""){
			sabun = "%";
		}else{
			sabun += "%";
		}
		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_code", buseoCode);
		query.setParameter("f_sabun", sabun);
		
		List<ComboListItemInfo> lstData= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstData;
	}
	
	@Override
	public String getNUR1010U00DamdangNurse(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT B.USER_NM                                                                     ");
		sql.append("     FROM ADM3200 B                                                                     ");
		sql.append("    WHERE B.HOSP_CODE   = :f_hosp_code                                                  ");
		sql.append("      AND B.DEPT_CODE   LIKE '%'                                                        ");
		sql.append("      AND SYSDATE()     <= IFNULL(B.USER_END_YMD, STR_TO_DATE('99981231', '%Y%m%d'))    ");
		sql.append("      AND B.USER_ID     = :f_code                                                       ");
		sql.append("      AND B.USER_GUBUN  = '2'                                                           ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public List<ComboListItemInfo> getNUR9001U00fwkFind(String hospCode, String find1, String sabun) {
		StringBuilder sql= new StringBuilder();
		sql.append("   SELECT B.USER_ID,                                                                ");
		sql.append("          B.USER_NM                                                                 ");
		sql.append("     FROM ADM3211 B                                                                 ");
		sql.append("     JOIN ADM3200 C                                                                 ");
		sql.append("       ON C.HOSP_CODE  = B.HOSP_CODE                                                ");
		sql.append("      AND C.USER_ID    = B.USER_ID                                                  ");
		sql.append("      AND C.USER_GUBUN = '2'                                                        ");
		sql.append("    WHERE B.HOSP_CODE  = :f_hosp_code                                               ");
		sql.append("      AND SYSDATE() BETWEEN B.START_DATE                                            ");
		sql.append("                    AND IFNULL(B.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))   ");
		sql.append("      AND ((B.USER_ID LIKE :f_sabun                                                 ");
		sql.append("      AND   B.USER_ID LIKE :f_find1)                                                ");
		sql.append("      OR   (B.USER_NM LIKE :f_sabun                                                 ");
		sql.append("      AND   B.USER_NM LIKE :f_find1))                                               ");
		sql.append("    ORDER BY B.USER_ID, B.USER_NM                                                   ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		
		if(sabun == null || sabun == ""){
			sabun = "%";
		}else{
			sabun += "%";
		}
		
		if(find1 == null || find1 == ""){
			find1 = "%";
		}else{
			find1 += "%";
		}
		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1);
		query.setParameter("f_sabun", sabun);
		
		List<ComboListItemInfo> lstData= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstData;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR5020U00fwkNurse(String hospCode, String buseoCode, String sabun) {
		StringBuilder sql= new StringBuilder();
		sql.append("   SELECT B.USER_ID                                                        ");
		sql.append("        , B.USER_NM                                                        ");
		sql.append("     FROM ADM3200 B                                                        ");
		sql.append("    WHERE B.HOSP_CODE = :f_hosp_code                                       ");
		sql.append("      AND (B.USER_END_YMD IS NULL                                          ");
		sql.append("       OR SYSDATE() < B.USER_END_YMD)                                      ");
		sql.append("      AND (B.USER_ID LIKE :f_sabun OR B.USER_NM LIKE CONCAT('%', :f_sabun))");
		sql.append("      AND B.USER_GUBUN = '2'                                               ");
		sql.append("      AND B.DEPT_CODE  = :f_buseo_code                                     ");
		sql.append("    ORDER BY B.USER_ID, B.USER_NM                                          ");
		
		Query query=entityManager.createNativeQuery(sql.toString());
		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_buseo_code", buseoCode);
		query.setParameter("f_sabun", sabun);
		
		List<ComboListItemInfo> lstData= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstData;
	}
}

