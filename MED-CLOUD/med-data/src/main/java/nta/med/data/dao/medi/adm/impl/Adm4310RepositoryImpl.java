package nta.med.data.dao.medi.adm.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.adm.Adm4310RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Adm4310RepositoryImpl implements Adm4310RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public void callProcAdmGenMenu(String hospCode, String language, String userId, String sysId, Integer userRole){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_GEN_MENU");
		
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SYS_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ROLE", Integer.class, ParameterMode.IN);
		
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_SYS_ID", sysId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_USER_ROLE", userRole);
		query.execute();
	}
}

