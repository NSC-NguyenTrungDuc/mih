package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm4500RepositoryCustom;
import nta.med.data.model.ihis.system.MenuViewFormItemInfo;

/**
 * @author dainguyen.
 */
public class Adm4500RepositoryImpl implements Adm4500RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public void callProcAdmGenMyMenu(String hospCode, String language, String userId, String role){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_GEN_MY_MENU");
		
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		
		query.execute();
	}
	
	@Override
	public List<MenuViewFormItemInfo> getMenuViewFormItemInfo(String hospCode, String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MENU_TP, MENU_LEVEL, TR_ID, MENU_TITLE, PGM_ID, PGM_OPEN_TP, MENU_PARAM ");
		sql.append("  FROM ADM4500 A                                                               ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                             ");
		sql.append("   AND A.USER_ID = :f_user_id                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		
		List<MenuViewFormItemInfo> list = new JpaResultMapper().list(query, MenuViewFormItemInfo.class);
		return list;
	}
}

