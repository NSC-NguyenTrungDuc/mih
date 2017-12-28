package nta.med.data.dao.medi.adm.impl;

import java.util.Collections;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm0300RepositoryCustom;
import nta.med.data.dao.medi.adm.Adm108UFwkPgmIdListItemInfo;
import nta.med.data.dao.medi.adm.Adm108UGrdListItemInfo;
import nta.med.data.model.ihis.adma.Adm102UGrdListItemInfo;
import nta.med.data.model.ihis.adma.Adm106UMakeQueryListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.FormScreenInfo;

/**
 * @author dainguyen.
 */
public class Adm0300RepositoryImpl implements Adm0300RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<FormScreenInfo> getFormScreenInfo(String language, String screenId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SYS_ID, A.PGM_NM, A.PGM_ENT_GRAD, A.PGM_UPD_GRAD, A.PGM_SCRT, ");
		sql.append("IFNULL(A.PGM_DUP_YN,'N'), A.ASM_NAME, B.ASM_PATH, B.ASM_VER, C.GRP_ID  ");
		sql.append(" FROM ADM0300 A                                                        ");
		sql.append("     ,ADM0400 B                                                        ");
		sql.append("     ,ADM0200 C                                                        ");
		sql.append("WHERE A.PGM_TP = 'P'                                                   ");
		sql.append("  AND A.ASM_NAME = B.ASM_NAME                                          ");
		sql.append("  AND A.SYS_ID   = C.SYS_ID                                            ");
		sql.append("  AND A.LANGUAGE = :f_language                                         ");
		sql.append("  AND A.PGM_ID  = :f_screen_id                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_screen_id", screenId);
		
		List<FormScreenInfo> list = new JpaResultMapper().list(query, FormScreenInfo.class);
		return list;
	}

	@Override
	public List<Adm102UGrdListItemInfo> getAdm102UGrdListItem(String language,
			String sysId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PGM_ID, A.PGM_NM, A.PGM_TP, A.SYS_ID, 				");
		sql.append("	       A.PROD_ID, A.SRVC_ID, A.PGM_ENT_GRAD,                ");
		sql.append("	       A.PGM_UPD_GRAD, A.PGM_SCRT, A.PGM_DUP_YN,            ");
		sql.append("	       A.END_YN, A.PGM_ACS_YN, A.MANG_MEMB, A.ASM_NAME      ");
		sql.append("	  FROM ADM0300 A                                            ");
		sql.append("	 WHERE A.SYS_ID = :f_sys_id                                 ");
		sql.append("	 AND A.LANGUAGE  = :language                                ");
		sql.append("	 ORDER BY A.PGM_ID                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_sys_id", sysId);
		
		List<Adm102UGrdListItemInfo> list = new JpaResultMapper().list(query, Adm102UGrdListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getAdm106UFwkPgmIdListItem(String pgmId,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PGM_ID,					");
		sql.append("	 A.PGM_NM                           ");
		sql.append("	FROM ADM0300 A                      ");
		sql.append("	WHERE A.PGM_ID LIKE :f_pgm_id       ");
		sql.append("	AND A.LANGUAGE = :language          ");
		sql.append("	ORDER BY A.PGM_ID                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_pgm_id", "%" + pgmId + "%");
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getAdm106UGrdMenuListItem(String pgmId, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT PGM_NM 					");
		sql.append("	FROM ADM0300                    ");
		sql.append("	WHERE PGM_ID  =  :pgm_id        ");
		sql.append("	AND LANGUAGE = :language        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("pgm_id", pgmId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<Adm106UMakeQueryListItemInfo> getAdm106UMakeQueryListItem(
			String hospCode, String sysId, String upperMenu, String language, String role) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT A.SYS_ID 								");
		sql.append("	    , A.TR_ID                                   ");
		sql.append("	    , A.TR_SEQ                                  ");
		sql.append("	    , A.PGM_ID                                  ");
		sql.append("	    , A.UPPR_MENU                               ");
		sql.append("	    , IFNULL(A.MENU_TITLE, B.PGM_NM) PGM_NM     ");
		sql.append("	    , B.PGM_TP                                  ");
		sql.append("	    , A.PGM_OPEN_TP                             ");
		sql.append("	    , A.SHORT_CUT                               ");
		sql.append("	    , A.MENU_PARAM                              ");
		if (UserRole.SUPER_ADMIN.getValue().equals(role)) {
			sql.append("	 FROM ADM0300 B, ADM4100 A                      "); 
			sql.append("	 WHERE                      "); 
		} else {
			sql.append("	 FROM ADM0300 B, ADM4100 A INNER JOIN ADMS_MENU C ON A.SYS_ID =  C.SYSTEM_ID AND A.TR_ID = C.TR_ID AND C.SELECT_FLG = 1     "); 
			sql.append("	WHERE C.HOSP_CODE = :hospCode AND                  ");
		}
		sql.append("	   A.PGM_ID    = B.PGM_ID                    ");
		sql.append("	  AND B.LANGUAGE  = :language                   ");
		sql.append("	  AND A.LANGUAGE  = :language                   ");
		sql.append("	  AND A.SYS_ID    = :userId                     ");
		if(StringUtils.isEmpty(upperMenu)){
			sql.append("	  AND A.UPPR_MENU IS NULL                      ");
		}else{
			sql.append("	  AND IFNULL(A.UPPR_MENU,'x') = IFNULL(:upperMenu,'x')                     ");
		}
		sql.append("	  ORDER BY A.TR_SEQ                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!UserRole.SUPER_ADMIN.getValue().equals(role)) {
			query.setParameter("hospCode", hospCode);
		}
		query.setParameter("language", language);
		query.setParameter("userId", sysId);
		if(!StringUtils.isEmpty(upperMenu)){
			query.setParameter("upperMenu", upperMenu);
		}
		
		
		List<Adm106UMakeQueryListItemInfo> list = new JpaResultMapper().list(query, Adm106UMakeQueryListItemInfo.class);
		return list;
	}

	@Override
	public List<Adm108UGrdListItemInfo> getAdm108UGrdListItemIn(String sysId, String language, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SYS_ID, A.SEQ, A.PGM_SYS_ID,		");
		sql.append("		B.SYS_NM, A.PGM_ID, C.PGM_NM            ");
		sql.append("	  FROM ADM0500 A, ADM0200 B, ADM0300 C      ");
		sql.append("	 WHERE A.PGM_SYS_ID = B.SYS_ID              ");
		sql.append("	   AND A.PGM_ID = C.PGM_ID                  ");
		sql.append("	   AND A.SYS_ID = :f_sys_id                 ");
		sql.append("	   AND A.HOSP_CODE = :hospCode             	");
		sql.append("	   AND B.LANGUAGE = :language               ");
		sql.append("	   AND C.LANGUAGE = :language               ");
		sql.append("	 ORDER BY A.SEQ                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sys_id", sysId);
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		
		List<Adm108UGrdListItemInfo> list = new JpaResultMapper().list(query, Adm108UGrdListItemInfo.class);
		return list;
	}

	@Override
	public List<Adm108UFwkPgmIdListItemInfo> getAdm108UFwkPgmIdListItem(String language, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PGM_ID, A.PGM_NM, A.SYS_ID , B.SYS_NM			");
		sql.append("	FROM ADM0300 A, ADM0200 B                       		");
		sql.append("	WHERE A.SYS_ID = B.SYS_ID                     			");
		sql.append("	AND A.PGM_TP = 'P'                              		");
		sql.append("	AND A.LANGUAGE = :language                      		");
		sql.append("	AND B.LANGUAGE = :language                      		");
		sql.append("	AND A.PGM_ID IN(										");
		sql.append("	    SELECT C.PGM_ID 									");
		sql.append("	    FROM ADM4100 C										");
		sql.append("	    INNER JOIN ADMS_MENU D ON	C.TR_ID = D.TR_ID 		");
		sql.append("	                          AND C.SYS_ID = D.SYSTEM_ID	");
		sql.append("	    WHERE C.LANGUAGE = :language						");
		sql.append("	      AND D.HOSP_CODE = :hosp_code						");
		sql.append("	    	AND D.SELECT_FLG = 1							");
		sql.append("	    	AND D.ACTIVE_FLG = 1							");
		sql.append("	  )														");
		sql.append("	ORDER BY A.SYS_ID, A.PGM_ID                     		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hosp_code", hospCode);
		
		List<Adm108UFwkPgmIdListItemInfo> list = new JpaResultMapper().list(query, Adm108UFwkPgmIdListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsPemRU00FwkPgmIdListItem(
			String sysId, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT B.PGM_ID       , B.PGM_NM  			");
		sql.append("	FROM ADM0300 B, ADM0200 A                   ");
		sql.append("	WHERE A.SYS_ID LIKE IFNULL(:f_sys_id,'%')   ");
		sql.append("	AND A.LANGUAGE = :language                  ");
		sql.append("	AND B.LANGUAGE = :language                  ");
		sql.append("	AND B.SYS_ID = A.SYS_ID ORDER BY 1          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_sys_id", sysId);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public boolean isExistedADM0300(String pgmId, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM ADM0300 A                       	 	    		");
		sql.append("	WHERE A.PGM_ID     = :f_pgm_id   		    	        ");
		sql.append("	  AND A.LANGUAGE   = :f_language  		    	        ");
	
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_pgm_id", pgmId);
		query.setParameter("f_language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	

}

