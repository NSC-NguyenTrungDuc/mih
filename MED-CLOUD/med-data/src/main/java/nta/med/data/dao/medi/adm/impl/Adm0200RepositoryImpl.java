package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm0200RepositoryCustom;
import nta.med.data.dao.medi.adm.Adm108UTvwSystemListItemInfo;
import nta.med.data.model.ihis.adma.ADM101UgrdSystemItemInfo;
import nta.med.data.model.ihis.adma.ADM103LaySysListGrpInfo;
import nta.med.data.model.ihis.adma.ADM401UGrdSysItemInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemListInfo;
import nta.med.data.model.ihis.adma.ADMSStartFormLoginInfo;
import nta.med.data.model.ihis.adma.OcsPemRU00GrdListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Adm0200RepositoryImpl implements Adm0200RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Adm0200RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ADM103LaySysListGrpInfo> getADM103LaySysListGrpInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.SYS_ID, SYS_NM FROM ADM0200 B INNER JOIN ADMS_GROUP_SYSTEM A   ");
		sql.append(" ON A.SYSTEM_ID  = B.SYS_ID AND A.GRP_ID = B.GRP_ID AND A.SELECT_FLG = 1    ");
		sql.append(" WHERE LANGUAGE = :f_language   AND A.HOSP_CODE = :hospCode ORDER BY 1      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("hospCode", hospCode);
		List<ADM103LaySysListGrpInfo> list = new JpaResultMapper().list(query,ADM103LaySysListGrpInfo.class);
		return list;
	}
	
	@Override
	public List<ADM103LaySysListGrpInfo> getADM103LaySysListGrpInfoSAM(String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.SYS_ID, SYS_NM FROM ADM0200 B ");
		sql.append(" WHERE LANGUAGE = :f_language  ORDER BY 1      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<ADM103LaySysListGrpInfo> list = new JpaResultMapper().list(query,ADM103LaySysListGrpInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getAdm102UFwkSysIdListItem(String hospCode, String language, String role) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SYS_ID,A.SYS_NM  				");
		if (UserRole.SUPER_ADMIN.getValue().equals(role)) {
			sql.append("	 FROM ADM0200 A WHERE 1 = 1                 "); 
		} else {
			sql.append("	FROM ADMS_GROUP_SYSTEM B INNER JOIN ADM0200 A ON B.SYSTEM_ID  = A.SYS_ID AND A.GRP_ID = B.GRP_ID AND B.SELECT_FLG = 1   "); 
			sql.append("	WHERE B.HOSP_CODE = :hospCode                   ");
		}
		sql.append("	AND IFNULL(A.MSG_SYS_YN,'N') = 'N'    ");
		sql.append("	AND LANGUAGE  = :language               ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		if (!UserRole.SUPER_ADMIN.getValue().equals(role)) {
			query.setParameter("hospCode", hospCode);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> findFwkSystem(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SYS_ID,A.SYS_NM  																								");
		sql.append("	FROM ADMS_GROUP_SYSTEM B INNER JOIN ADM0200 A ON B.SYSTEM_ID  = A.SYS_ID AND A.GRP_ID = B.GRP_ID AND B.SELECT_FLG = 1   "); 
		sql.append("	WHERE B.HOSP_CODE = :hospCode                   																		");
		sql.append("	AND IFNULL(A.MSG_SYS_YN,'N') = 'N'    																					");
		sql.append("	AND A.LANGUAGE  = :language               																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getAdm102UfbxSysId(String hospCode, String language, String sysId, String role) {
		StringBuilder sql = new StringBuilder();	
		sql.append("	SELECT SYS_NM                           ");
		if (UserRole.SUPER_ADMIN.getValue().equals(role)) {
			sql.append("	FROM ADM0200 B WHERE 1= 1  						    ");
		} else {
			sql.append("	FROM ADM0200 B  INNER JOIN ADMS_GROUP_SYSTEM A  ON A.SYSTEM_ID  = B.SYS_ID AND A.GRP_ID = B.GRP_ID AND A.SELECT_FLG = 1   						    ");
			sql.append("	WHERE A.HOSP_CODE = :hospCode             ");
		}
		sql.append("	AND B.SYS_ID = :sysId                     ");
		sql.append("	AND  IFNULL(MSG_SYS_YN,'N') = 'N'       ");
		sql.append("	AND LANGUAGE = :language                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		if (!UserRole.SUPER_ADMIN.getValue().equals(role)) {
			query.setParameter("hospCode", hospCode);
		}
		query.setParameter("sysId", sysId);
		
		List<String> object = query.getResultList();
		if(!CollectionUtils.isEmpty(object)){
			return object.get(0);
		}
		return null;
	}
	
	@Override
	public List<ADM101UgrdSystemItemInfo> getADM101UgrdSystemItemInfo(String hospCode, String language, String grdId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GRP_ID , A.SYS_ID , A.SYS_NM , A.SYS_SEQ , A.ADM_SYS_YN , A.MSG_SYS_YN , A.SYS_DESC               ");
		sql.append("      , A.MANG_DEPT , B.BUSEO_NAME , A.MANG_DEPT1 , B.BUSEO_NAME BUSEO_NAME2                                ");
		sql.append("   FROM (ADM0200 A LEFT JOIN  BAS0260 B ON B.BUSEO_CODE = A.MANG_DEPT  AND  B.BUSEO_CODE = A.MANG_DEPT1     ");
		sql.append("   AND B.LANGUAGE = A.LANGUAGE  AND B.HOSP_CODE =:f_hosp_code)                                              ");
		sql.append("   WHERE A.LANGUAGE = :f_language                                                                           ");
		sql.append("   AND A.GRP_ID = :f_grp_id                                                                                 ");
		sql.append("  ORDER BY A.SYS_SEQ, A.SYS_ID																				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_grp_id", grdId);
		List<ADM101UgrdSystemItemInfo> list = new JpaResultMapper().list(query,ADM101UgrdSystemItemInfo.class);
		return list;
	}

	@Override
	public List<ADM401UGrdSysItemInfo> getADM401UGrdSysItemInfo(String language, String grdId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT SYS_ID, SYS_NM, IFNULL(ADM_SYS_YN,'N'),                       ");
		sql.append(" IFNULL(MSG_SYS_YN,'N')  FROM ADM0200                                 ");
		sql.append("  WHERE LANGUAGE =:f_language AND GRP_ID = :f_grp_id ORDER BY SYS_ID  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_grp_id", grdId);
		List<ADM401UGrdSysItemInfo> list = new JpaResultMapper().list(query,ADM401UGrdSysItemInfo.class);
		return list;
	}
	
	
	@Override
	public String getAdm106UFbxSysIdItem(String sysId, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT SYS_NM 		           ");
		sql.append("	FROM ADM0200       			   ");
		sql.append("	WHERE SYS_ID = :sys_id         ");
		sql.append("	AND LANGUAGE = :language       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sys_id", sysId);
		query.setParameter("language", language);
		
		List<String> object = query.getResultList();
		if(!CollectionUtils.isEmpty(object)){
			return object.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getAdm108UlaySysList(String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT SYS_ID, SYS_NM   				");
		sql.append("	FROM ADM0200                            ");
		sql.append("	WHERE IFNULL(MSG_SYS_YN,'N') = 'N'      ");
		sql.append("	AND LANGUAGE = :language                ");
		sql.append("	ORDER BY SYS_ID                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<Adm108UTvwSystemListItemInfo> getAdm108UTvwSystemListItem(
			String language, String pgmId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PGM_NM, A.SYS_ID, B.SYS_NM	");
		sql.append("	    FROM ADM0300 A, ADM0200 B       ");
		sql.append("	   WHERE A.SYS_ID = B.SYS_ID        ");
		sql.append("	     AND A.PGM_TP = 'P'             ");
		sql.append("	     AND A.LANGUAGE = :language     ");
		sql.append("	     AND B.LANGUAGE = :language     ");
		sql.append("	     AND A.PGM_ID = :f_pgm_id       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_pgm_id", pgmId);
		
		List<Adm108UTvwSystemListItemInfo> list = new JpaResultMapper().list(query,Adm108UTvwSystemListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getLayLogSysList(String hospCode, String language, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  A.SYS_ID                ");
		sql.append("      , A.SYS_NM                ");
		sql.append("  FROM ADM0200         A        ");
		sql.append("       ,ADM3500 B               ");
		sql.append(" WHERE B.HOSP_CODE  = :hospCode ");
		sql.append("   AND A.LANGUAGE = :language   ");
		sql.append("   AND B.USER_ID    = :userId   ");
		sql.append("   AND A.SYS_ID     = B.SYS_ID  ");
		sql.append(" ORDER BY A.SYS_ID              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("userId", userId);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsPemRU00FwkSysIdListItem(String language) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT ''                            AS SYS_ID		");
		sql.append("	       , FN_ADM_MSG('221',:language) AS SYS_NM      ");
		sql.append("	 UNION ALL                                          ");
		sql.append("	SELECT A.SYS_ID                     AS SYS_ID       ");
		sql.append("	       , A.SYS_NM                   AS SYS_NM       ");
		sql.append("	  FROM ADM0200 A                                    ");
		sql.append("	 WHERE IFNUL(A.MSG_SYS_YN,'N') = 'N'                ");
		sql.append("	 AND LANGUAGE = :language                           ");
		sql.append("	 ORDER BY 1                                         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return null;
	}

	@Override
	public List<OcsPemRU00GrdListItemInfo> getOcsPemRU00GrdListItem(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SYS_ID									");
		sql.append("	      , C.PGM_ID                                ");
		sql.append("	      , B.PGM_NM                                ");
		sql.append("	      , C.DW_ID                                 ");
		sql.append("	      , C.SHETSHTID                             ");
		sql.append("	      , D.SHEETNAME                             ");
		sql.append("	 FROM ADM0200     A                             ");
		sql.append("	      , ADM0300   B                             ");
		sql.append("	      , OCSPEMR   C                             ");
		sql.append("	      , EMR.EMRSHEET D                          ");
		sql.append("	WHERE A.SYS_ID    LIKE IFNULL(:f_sys_id,'%')    ");
		sql.append("	  AND A.LANGUAGE  = :language                   ");
		sql.append("	  AND B.SYS_ID    = A.SYS_ID                    ");
		sql.append("	  AND B.LANGUAGE  = :language                   ");
		sql.append("	  AND C.HOSP_CODE = :f_hosp_code                ");
		sql.append("	  AND C.PGM_ID    = B.PGM_ID                    ");
		sql.append("	  AND D.SHEETID   = C.SHETSHTID                 ");
		sql.append("	ORDER BY A.SYS_ID, B.PGM_ID                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<OcsPemRU00GrdListItemInfo> list  = new JpaResultMapper().list(query, OcsPemRU00GrdListItemInfo.class);
		return list;
	}

	@Override
	public String getOcsPemRU00GrdFbxSysId(String dataValue, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT SYS_NM 							");
		sql.append("	FROM ADM0200                            ");
		sql.append("	WHERE IFNULL(MSG_SYS_YN,'N') = 'N'      ");
		sql.append("	AND LANGUAGE = :language                ");
		sql.append("	AND SYS_ID LIKE IFNULL(:dataValue,'%')  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("dataValue", dataValue);
		
		List<String> object = query.getResultList();
		if(!CollectionUtils.isEmpty(object)){
			return object.get(0);
		}
		return null;
	}
	
	public List<ADMSStartFormLoginInfo> getADMSStartFormLoginInfo(String hospCode, String userId, String language, boolean user) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT A.GRP_ID, 						");
		sql.append("	       A.GRP_NM,                        ");
		sql.append("	       B.SYS_ID,                        ");
		sql.append("	       B.SYS_NM,                        ");
		sql.append("	       A.DISP_GRP_ID                    ");
		sql.append("	FROM ADM0100 A, ADM0200 B, ADM3500 C    ");
		if (user == true) {
			sql.append("	,ADMS_GROUP_SYSTEM D    			");
		}
		sql.append("	WHERE C.HOSP_CODE = :f_hosp_code        ");
		sql.append("	AND C.USER_ID = :f_user_id              ");
		sql.append("	AND B.SYS_ID = C.SYS_ID                 ");
		sql.append("	AND A.GRP_ID = B.GRP_ID                 ");
		if (user == true) {
			sql.append("	AND B.SYS_ID = D.SYS_ID    			");
			sql.append("	AND D.HOSP_CODE = :f_hosp_code    	");
		}
		sql.append("	AND B.LANGUAGE = :f_language            ");
		sql.append("	AND A.LANGUAGE = :f_language            ");
		sql.append("	ORDER BY A.GRP_SEQ, B.SYS_SEQ ASC       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		
		List<ADMSStartFormLoginInfo> list  = new JpaResultMapper().list(query, ADMSStartFormLoginInfo.class);
		return list;
	}
	
	public List<ADMS2015U00GetSystemListInfo> getADMS2015U00GetSystemListInfo(String grpId, String language) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT SYS_ID, 				");
		sql.append("	       SYS_NM,              ");
		sql.append("	       SYS_SEQ              ");
		sql.append("	FROM ADM0200                ");
		sql.append("	WHERE GRP_ID = :f_grp_id    ");
		sql.append("	AND LANGUAGE = :f_language  ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_grp_id", grpId);
		
		List<ADMS2015U00GetSystemListInfo> list  = new JpaResultMapper().list(query, ADMS2015U00GetSystemListInfo.class);
		return list;
	}
		
	@Override
	public boolean isExistedADM0200(String sysId, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM ADM0200 A                       	 	    		");
		sql.append("	WHERE A.SYS_ID     = :f_sys_id   		    			");
		sql.append("	AND LANGUAGE = :f_language  							");
	
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	
	
}

