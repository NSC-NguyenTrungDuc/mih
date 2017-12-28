package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0131RepositoryCustom;
import nta.med.data.model.ihis.adma.Ocs0131U01Grd0131ListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0131Info;
import nta.med.data.model.ihis.system.LoadOcs0131Info;

/**
 * @author dainguyen.
 */
public class Ocs0131RepositoryImpl implements Ocs0131RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String getLoadColumnCodeNameInfoCaseCodeType(String arg1, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(A.CODE_TYPE_NAME, ' ') FROM OCS0131 A WHERE A.CODE_TYPE = :f_aArgu1 AND A.LANGUAGE = :f_language ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_aArgu1", arg1);     
		query.setParameter("f_language", language);
		List<String> listResult= query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getOCS0131U00FwkCode(String find1, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE,                    ");
		sql.append("        A.CODE_TYPE_NAME                ");
		sql.append("   FROM OCS0131 A                       ");
		sql.append("  WHERE A.CODE_TYPE LIKE :f_find1       ");
		sql.append("    AND A.LANGUAGE = :f_language        ");
		sql.append("  ORDER BY 1, 2                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_find1", "%" + find1 + "%");
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<OCS0131U00GrdOCS0131Info> getOCS0131U00GrdOCS0131Info(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_TYPE      CODE_TYPE,            ");
		sql.append("       A.CODE_TYPE_NAME CODE_TYPE_NAME,       ");
		sql.append("       A.MENT           MENT,                 ");
		sql.append("       A.CHOICE_USER    CHOICE_USER,          ");
		sql.append("       A.UPD_ID         USER_ID               ");
		sql.append("  FROM OCS0131 A                              ");
		sql.append(" WHERE A.CODE_TYPE LIKE TRIM(:f_code_type)    ");
		sql.append("   AND A.LANGUAGE = :f_language        	  	  ");
		sql.append("ORDER BY A.CODE_TYPE                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType + "%");
		query.setParameter("f_language", language);
		
		List<OCS0131U00GrdOCS0131Info> list = new JpaResultMapper().list(query, OCS0131U00GrdOCS0131Info.class);
		return list;
	}
	
	@Override
	public List<LoadOcs0131Info> getLoadOcs0131Info(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE, A.CODE_TYPE_NAME, A.CHOICE_USER,  ");
		sql.append("        A.MENT, A.SYS_DATE, A.UPD_ID, A.UPD_DATE       ");
		sql.append("   FROM OCS0131 A                                      ");
		sql.append("  WHERE A.CODE_TYPE = :f_code_type                     ");
		sql.append("    AND A.LANGUAGE = :f_language        	  	  	   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<LoadOcs0131Info> list = new JpaResultMapper().list(query, LoadOcs0131Info.class);
		return list;
		
	}
	
	@Override
	public List<Ocs0131U01Grd0131ListItemInfo> getOcs0131U01Grd0131ListItemInfo(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_TYPE      CODE_TYPE,         ");
		sql.append("       A.CODE_TYPE_NAME CODE_TYPE_NAME,    ");  
		sql.append("       A.ADMIN_GUBUN    ADMIN_GUBUN,       ");
		sql.append("       A.MENT           MENT,              ");
		sql.append("       A.CHOICE_USER    CHOICE_USER,       ");
		sql.append("       A.UPD_ID         USER_ID            ");
		sql.append("  FROM OCS0131 A                           ");
		sql.append(" WHERE A.CODE_TYPE LIKE :f_code_type       ");
		sql.append("   AND A.LANGUAGE = :f_language        	   ");
		sql.append("ORDER BY                                   ");
		sql.append("      A.CODE_TYPE                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType + "%");
		query.setParameter("f_language", language);
		
		List<Ocs0131U01Grd0131ListItemInfo> list = new JpaResultMapper().list(query, Ocs0131U01Grd0131ListItemInfo.class);
		return list;
	}
}


