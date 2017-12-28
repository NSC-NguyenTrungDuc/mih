package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm4100RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM107ULayDownListInfo;
import nta.med.data.model.ihis.adma.ADMS2015U01MenuInfo;
import nta.med.data.model.ihis.adma.ADMS2016MenuInfo;

/**
 * @author dainguyen.
 */
public class Adm4100RepositoryImpl implements Adm4100RepositoryCustom {
private static final Log LOGGER = LogFactory.getLog(Adm4100RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ADM107ULayDownListInfo> getAdm107uLayDownListInfo(String hospitalCode, String language, String userId, String sysId, String upprMenu) {

		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.USER_ID,                                                                              ");
		sql.append("        A.SYS_ID,                                                                               ");
		sql.append("        A.TR_ID,                                                                                ");
		sql.append("        A.TR_SEQ,                                                                               ");
		sql.append("        A.PGM_ID,                                                                               ");
		sql.append("        A.UPPR_MENU,                                                                            ");
		sql.append("        IFNULL(C.PGM_NM, A.MENU_TITLE)                AS PGM_NM,                                ");
		sql.append("        C.PGM_TP,                                                                               ");
		sql.append("        IF(B.USER_ID = :userId, 'Y', 'N')         AS USE_YN                                     ");
		sql.append("   FROM ADM4100  A  INNER JOIN ADMS_MENU M ON A.SYS_ID =  M.SYSTEM_ID AND A.TR_ID = M.TR_ID AND M.SELECT_FLG = 1      ");
		sql.append("     LEFT JOIN ADM4200 B ON B.HOSP_CODE = M.HOSP_CODE AND B.SYS_ID = A.SYS_ID                   ");
		sql.append("        AND B.TR_ID = A.TR_ID AND B.USER_ID = :userId                                           ");
		sql.append("     INNER JOIN ADM0300 C ON C.PGM_ID     = A.PGM_ID AND C.LANGUAGE = :language                 ");
		sql.append("  WHERE M.HOSP_CODE  = :hospCode                                                                ");
		sql.append("    AND A.SYS_ID     =  :sysId                                                                  ");
		sql.append("    AND A.LANGUAGE     =  :language                                                             ");
		sql.append("    AND A.PGM_ID     <> 'DOTMENU'                                                               ");
		sql.append("    AND IFNULL(A.UPPR_MENU,'x') = IFNULL(:upprMenu,'x')                                         ");
		sql.append("  ORDER BY A.TR_SEQ                                            									");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("userId", userId);
		query.setParameter("sysId", sysId);
		query.setParameter("upprMenu", upprMenu);

		List<ADM107ULayDownListInfo> list = new JpaResultMapper().list(query, ADM107ULayDownListInfo.class);

		return list;
	}
	public List<ADM107ULayDownListInfo> getAdm107uLayDownListInfo(String hospitalCode, String langauge, String userId, String sysId)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.USER_ID,                                                                              ");
		sql.append("        A.SYS_ID,                                                                               ");
		sql.append("        A.TR_ID,                                                                                ");
		sql.append("        A.TR_SEQ,                                                                               ");
		sql.append("        A.PGM_ID,                                                                               ");
		sql.append("        A.UPPR_MENU,                                                                            ");
		sql.append("        IFNULL(A.MENU_TITLE, C.PGM_NM)                AS PGM_NM,                                ");
		sql.append("        C.PGM_TP,                                                                               ");
		sql.append("        IF(B.USER_ID = :userId, 'Y', 'N')         AS USE_YN                                     ");
		sql.append("   FROM ADM4100  A  INNER JOIN ADMS_MENU M ON A.SYS_ID =  M.SYSTEM_ID AND A.TR_ID = M.TR_ID AND M.SELECT_FLG = 1      ");
		sql.append("     LEFT JOIN ADM4200 B ON B.HOSP_CODE = M.HOSP_CODE AND B.SYS_ID = A.SYS_ID                   ");
		sql.append("        AND B.TR_ID = A.TR_ID AND B.USER_ID = :userId                                           ");
		sql.append("     INNER JOIN ADM0300 C ON C.PGM_ID     = A.PGM_ID AND C.LANGUAGE = :langauge                 ");
		sql.append("  WHERE M.HOSP_CODE  = :hospCode                                                                ");
		sql.append("    AND A.SYS_ID     =  :sysId                                                                  ");
		sql.append("    AND A.PGM_ID     <> 'DOTMENU'                                                               ");

		sql.append("  ORDER BY A.TR_SEQ                                            									");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospitalCode);
		query.setParameter("langauge", langauge);
		query.setParameter("userId", userId);
		query.setParameter("sysId", sysId);


		List<ADM107ULayDownListInfo> list = new JpaResultMapper().list(query, ADM107ULayDownListInfo.class);

		return list;
	}
	@Override
	public List<ADM107ULayDownListInfo> getAdm107uLayRootListInfo(String hospitalCode, String language, String userId, String sysId) {

		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT B.USER_ID,                                                                                                        				");
		sql.append("        A.SYS_ID,                                                                                                         						");
		sql.append("        A.TR_ID,                                                                                                          						");
		sql.append("        A.TR_SEQ,                                                                                                         						");
		sql.append("        A.PGM_ID,                                                                                                         						");
		sql.append("        A.UPPR_MENU,                                                                                                      						");
		sql.append("        IFNULL(A.MENU_TITLE, C.PGM_NM)                AS PGM_NM,                                                          						");
		sql.append("        C.PGM_TP,                                                                                                         						");
		sql.append("        IF(B.USER_ID = :userId, 'Y', 'N')         AS USE_YN                                                               						");
		sql.append("   FROM ADM4100  A  INNER JOIN  ADMS_MENU M ON A.SYS_ID =  M.SYSTEM_ID AND A.TR_ID = M.TR_ID AND M.SELECT_FLG = 1 AND M.HOSP_CODE  = :hospCode  ");
		sql.append("     LEFT JOIN ADM4200 B ON B.HOSP_CODE = M.HOSP_CODE AND B.SYS_ID = A.SYS_ID                                             						");
		sql.append("        AND B.TR_ID = A.TR_ID AND B.USER_ID = :userId                                                                     						");
		sql.append("     INNER JOIN ADM0300 C ON C.PGM_ID     = A.PGM_ID AND C.LANGUAGE = :language                                           						");
		sql.append("  WHERE                                                                                                                   						");
		sql.append("    A.SYS_ID     =  :sysId                                                                                                						");
		sql.append("    AND A.LANGUAGE     =  :language                                                                                                     		");
		sql.append("    AND  A.UPPR_MENU  IS NULL												                                              						");
		sql.append("  ORDER BY A.TR_SEQ  																		                              						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospitalCode);
		query.setParameter("language", language);
		query.setParameter("userId", userId);
		query.setParameter("sysId", sysId);

		List<ADM107ULayDownListInfo> list = new JpaResultMapper().list(query, ADM107ULayDownListInfo.class);


		return list;
	}

	@Override
	public String getAdm106UMaxValueCaseAdded(String hospCode, String language, String sysId, String role) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CAST((MAX(CAST(IFNULL(A.TR_ID,'0') AS SIGNED)) + 1) AS CHAR)	");
		if (UserRole.SUPER_ADMIN.getValue().equals(role)) {
			sql.append("	FROM ADM4100 A WHERE 1 = 1                                                           ");
		} else {
			sql.append("	FROM ADM4100 A INNER JOIN ADMS_MENU B ON A.SYS_ID =  B.SYSTEM_ID AND A.TR_ID = B.TR_ID AND B.SELECT_FLG = 1  ");
			sql.append("	WHERE B.HOSP_CODE = :hospCode                                                      ");
		}
		sql.append("	AND A.SYS_ID = :sysId                                                                  ");
		sql.append("    AND A.LANGUAGE     =  :language                                     		           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!UserRole.SUPER_ADMIN.getValue().equals(role)) {
			query.setParameter("hospCode", hospCode);
		}
		query.setParameter("sysId", sysId);
		query.setParameter("language", language);
		
		List<Object> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	public String getAdm106Uchkdelete(String hospCode, String language, String sysId, String trId, String role) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'X' 							");
		if (UserRole.SUPER_ADMIN.getValue().equals(role)) {
			sql.append("	FROM ADM4100 A  WHERE 1 = 1                     " );
		} else {
			sql.append("	FROM ADM4100 A INNER JOIN ADMS_MENU B ON A.SYS_ID =  B.SYSTEM_ID AND A.TR_ID = B.TR_ID AND B.SELECT_FLG = 1  ");
			sql.append("	WHERE B.HOSP_CODE = :hospCode                                                      ");
		}
		sql.append("	AND A.SYS_ID = :f_sys_id             " );
		sql.append("	AND A.UPPR_MENU = :f_tr_id           " );
		sql.append("	AND A.LANGUAGE = :f_language           " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!UserRole.SUPER_ADMIN.getValue().equals(role)) {
			query.setParameter("hospCode", hospCode);
		}
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_tr_id", trId);
		query.setParameter("f_language", language);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public List<ADMS2015U01MenuInfo> getADMS2015U01LoadUpperMenu(String sysId, String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SYS_ID,                                                        ");
		sql.append("       A.TR_ID,                                                          ");
		sql.append("	   A.TR_SEQ,                                                         ");
		sql.append("	   A.PGM_ID,                                                         ");
		sql.append("	   A.UPPR_MENU,                                                      ");
		sql.append("       IFNULL(A.MENU_TITLE, C.PGM_NM) PGM_NM,                            ");
		sql.append("	   C.PGM_TP,                                                         ");
		sql.append("	   IF(B.SELECT_FLG IS NULL, 0, B.SELECT_FLG)                         ");
		sql.append("  FROM ADM4100 A LEFT JOIN ADMS_MENU B ON A.TR_ID = B.TR_ID              ");
		sql.append("           AND A.SYS_ID = B.SYSTEM_ID AND B.SELECT_FLG = 1               ");
		sql.append("   		  AND B.HOSP_CODE = :f_hosp_code                                 ");
		sql.append("                 JOIN ADM0300 C ON A.PGM_ID = C.PGM_ID                   ");
		sql.append("		   AND C.LANGUAGE = :f_language                                  ");
		sql.append(" WHERE A.SYS_ID = :f_sys_id    AND A.LANGUAGE =  :f_language             ");
		sql.append("   AND A.UPPR_MENU IS NULL                                               ");
		sql.append("   ORDER BY A.TR_SEQ                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_sys_id", sysId);
		
		List<ADMS2015U01MenuInfo> list = new JpaResultMapper().list(query, ADMS2015U01MenuInfo.class);
		return list;
	}
	
	@Override
	public List<ADMS2015U01MenuInfo> getADMS2015U01LoadMenuItem(String sysId, String hospCode, String language, String upprMenu){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SYS_ID,                                                          ");
		sql.append("	   A.TR_ID,                                                           ");
		sql.append("	   A.TR_SEQ,                                                          ");
		sql.append("	   A.PGM_ID,                                                          ");
		sql.append("	   A.UPPR_MENU,                                                       ");
		sql.append("       IFNULL(A.MENU_TITLE, C.PGM_NM) PGM_NM,                             ");
		sql.append("	   C.PGM_TP,                                                          ");
		sql.append("	   IF(B.SELECT_FLG IS NULL, 0, B.SELECT_FLG)                                     ");
		sql.append("  FROM ADM4100 A LEFT JOIN ADMS_MENU B ON A.TR_ID = B.TR_ID               ");
		sql.append("           AND A.SYS_ID = B.SYSTEM_ID AND B.SELECT_FLG = 1 AND B.HOSP_CODE = :f_hosp_code ");
		sql.append("                 JOIN ADM0300 C ON A.PGM_ID = C.PGM_ID                    ");
		sql.append("		   AND C.LANGUAGE = :f_language                                   ");
		sql.append(" WHERE A.SYS_ID = :f_sys_id    AND A.LANGUAGE =  :f_language              ");
		sql.append("   AND A.PGM_ID != 'DOTMENU'                                              ");
		sql.append("   AND IFNULL(A.UPPR_MENU,'X') = IFNULL(:f_uppr_menu,'X')                 ");
		sql.append("   ORDER BY A.TR_SEQ                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_uppr_menu", upprMenu);
		
		List<ADMS2015U01MenuInfo> list = new JpaResultMapper().list(query, ADMS2015U01MenuInfo.class);
		return list;
	}
	
	@Override
	public List<ADMS2016MenuInfo> getMenuBySysIDs(String sysId, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SYS_ID,                                                          ");
		sql.append("	   A.TR_ID,                                                           ");
		sql.append("	   A.TR_SEQ,                                                          ");
		sql.append("	   A.UPPR_MENU                                                        ");
		sql.append("  FROM ADM4100 A               										      ");
		sql.append(" WHERE A.SYS_ID = :f_sys_id    AND A.LANGUAGE =  :f_language              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_language", language);
		
		List<ADMS2016MenuInfo> list = new JpaResultMapper().list(query, ADMS2016MenuInfo.class);
		return list;
	}
	
}


