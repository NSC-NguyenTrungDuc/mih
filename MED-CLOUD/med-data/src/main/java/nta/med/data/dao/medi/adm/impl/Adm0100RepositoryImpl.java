package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm0100RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM101UGrdGroupItemInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupListInfo;
import nta.med.data.model.ihis.system.MainFormGetMainMenuItemInfo;
import nta.med.data.model.ihis.system.MainMenuInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Adm0100RepositoryImpl implements Adm0100RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Adm0100RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<MainMenuInfo> generateMainMenu(String msgUserYn, String adminUserYn, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GRP_ID, A.GRP_NM, B.SYS_ID, B.SYS_NM, A.DISP_GRP_ID, C.GRP_NM as DISP_GRP_NM, B.SYS_DESC      ");
		sql.append("                 FROM ADM0100 A, ADM0200 B, ADM0100 C                                                  ");
		sql.append("                WHERE A.GRP_ID = B.GRP_ID                                                              ");
		sql.append("                  AND A.DISP_GRP_ID = C.GRP_ID                                                         ");
		sql.append("                  AND IFNULL(B.MSG_SYS_YN,'N') = :msgUserYn                                            ");
		sql.append("                  AND IFNULL(B.ADM_SYS_YN,'Y') LIKE (CASE :adminUserYn WHEN 'Y' THEN '%' ELSE 'N' END) ");
		sql.append("                  AND A.LANGUAGE = :language														   ");
		sql.append("                  AND B.LANGUAGE = :language														   ");
		sql.append("                  AND C.LANGUAGE = :language														   ");
		sql.append("                ORDER BY A.GRP_SEQ, B.SYS_SEQ;                                                         ");
		                
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("msgUserYn", msgUserYn);
		query.setParameter("adminUserYn", adminUserYn);
		query.setParameter("language", language);
		
		List<MainMenuInfo> list = new JpaResultMapper().list(query, MainMenuInfo.class);
		return list;
	}

	@Override
	public String getLoadColumnCodeNameJundalTableCase(String agru1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.GRP_NM 			");
		sql.append("	 FROM ADM0100 A             ");
		sql.append("	WHERE A.GRP_ID = :agru1     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("agru1", agru1);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<ADM101UGrdGroupItemInfo> getADM101UGrdGroupItemInfo(String language, String grdId, String grpNm) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GRP_ID                                                ");
		sql.append("      , A.GRP_NM                                                ");
		sql.append("      , A.GRP_SEQ                                               ");
		sql.append("      , A.GRP_DESC                                              ");
		sql.append("      , A.DISP_GRP_ID                                           ");
		sql.append("   FROM ADM0100 A                                               ");
		sql.append("  WHERE LANGUAGE = :f_language                                  ");
		sql.append("  AND (A.GRP_ID LIKE :f_grp_id AND A.GRP_NM LIKE :f_grp_nm )    ");
		sql.append("  ORDER BY A.GRP_SEQ, A.GRP_ID									");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_grp_id", grdId + "%");
		query.setParameter("f_grp_nm", grpNm + "%");
		List<ADM101UGrdGroupItemInfo> list = new JpaResultMapper().list(query, ADM101UGrdGroupItemInfo.class);
		return list;
	}

	@Override
	public List<MainFormGetMainMenuItemInfo> getMainFormGetSuperAdminMenuItem(String language, String userId, String msgSys) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GRP_ID, A.GRP_NM,                                                 ");
		sql.append("  B.SYS_ID, B.SYS_NM, A.DISP_GRP_ID , D.GRP_NM DISP_GRP_NM, B.SYS_DESC      ");
		sql.append(" FROM ADM0100 A, ADM0200 B, ADM3500 C  , ADM0100 D                          ");
		sql.append(" WHERE C.HOSP_CODE = 'NTA'                                                  ");
		sql.append(" AND C.USER_ID = :f_user_id                                                 ");
		sql.append("  AND A.DISP_GRP_ID = D.GRP_ID                                              ");
		sql.append("  AND IFNULL(B.MSG_SYS_YN,'N') = :f_msg_sys                                 ");
		sql.append("  AND A.LANGUAGE = :f_language                                              ");
		sql.append("  AND B.LANGUAGE = :f_language                                              ");   
		sql.append("  AND D.LANGUAGE = :f_language                                              ");
		sql.append(" AND B.SYS_ID = C.SYS_ID                                                    ");
		sql.append(" AND A.GRP_ID = B.GRP_ID                                                    ");
		sql.append(" order by A.GRP_SEQ, B.SYS_SEQ												");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_msg_sys", msgSys);
		List<MainFormGetMainMenuItemInfo> list = new JpaResultMapper().list(query, MainFormGetMainMenuItemInfo.class);
		return list;
	}

	@Override
	public List<MainFormGetMainMenuItemInfo> getMainFormGetAdminMenuItem(String hospCode, String language, String userId, String msgSys) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GRP_ID, A.GRP_NM, B.SYS_ID,                                                                                       ");
		sql.append("   B.SYS_NM, A.DISP_GRP_ID , E.GRP_NM DISP_GRP_NM, B.SYS_DESC                                                               ");
		sql.append("  FROM ADM0100 A INNER JOIN  ADM0100 E ON A.DISP_GRP_ID = E.GRP_ID                                                          ");
		sql.append("                 INNER JOIN ADMS_GROUP M ON E.GRP_ID =  M.GRP_ID AND M.SELECT_FLG = 1 AND M.HOSP_CODE = :f_hosp_code        ");
		sql.append("                 INNER JOIN  ADM0200 B ON A.GRP_ID = B.GRP_ID                                                               ");
		sql.append("                 INNER JOIN ADM3500 C ON B.SYS_ID = C.SYS_ID                                                                ");
		sql.append("                 INNER JOIN ADMS_GROUP_SYSTEM D ON D.SYSTEM_ID  = B.SYS_ID AND D.GRP_ID = B.GRP_ID                          ");
		sql.append(" 				AND D.SELECT_FLG = 1 AND D.HOSP_CODE = :f_hosp_code                                                         ");
		sql.append("  WHERE C.HOSP_CODE = :f_hosp_code                                                                                          ");
		sql.append("      AND C.USER_ID = :f_user_id                                                                                            ");                                                                          
		sql.append("      AND E.LANGUAGE = :f_language                                                                                          ");
		sql.append("      AND A.LANGUAGE = :f_language                                                                                          ");
		sql.append("      AND B.LANGUAGE = :f_language                                                                                          ");                         
		sql.append("      AND IFNULL(B.MSG_SYS_YN,'N') = :f_msg_sys                                                                             ");
		sql.append("  ORDER BY A.GRP_SEQ,B.SYS_SEQ																								");							
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_msg_sys", msgSys);
		List<MainFormGetMainMenuItemInfo> list = new JpaResultMapper().list(query, MainFormGetMainMenuItemInfo.class);
		return list;
	}

	public List<ADMS2015U00GetGroupListInfo> getADMS2015U00GetGroupListInfo (String language) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT GRP_ID, 					");
		sql.append("	       GRP_NM,                  ");
		sql.append("	       GRP_SEQ                  ");
		sql.append("	FROM ADM0100                    ");
		sql.append("	WHERE LANGUAGE = :f_language    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		
		List<ADMS2015U00GetGroupListInfo> list = new JpaResultMapper().list(query, ADMS2015U00GetGroupListInfo.class);
		return list;
	}
}

