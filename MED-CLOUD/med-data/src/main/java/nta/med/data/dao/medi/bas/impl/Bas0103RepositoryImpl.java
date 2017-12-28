package nta.med.data.dao.medi.bas.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import antlr.collections.List;
import nta.med.data.dao.medi.bas.Bas0103RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Bas0103RepositoryImpl implements Bas0103RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	


	@Override
	public String callPrAdmHotcodeMasterInsert(String hospCode, String userId, String hotCode) {
		String erFlg = null;
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_HOTCODEMASTER_INSERT_OCS0103");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOT_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_HOT_CODE", hotCode);
			
		query.execute();
		erFlg = (String)query.getOutputParameterValue("IO_ERR_FLAG");
		return erFlg;
	}
}

