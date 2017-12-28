package nta.med.data.dao.medi.ifs.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.ifs.Ifs3021RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ifs3021RepositoryImpl implements Ifs3021RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String callPrIfsSikaInputTest(String hospCode, String bunho,
			Date fromDate, Integer fromSik, Date toDate, Integer toSik) {
		String pkIfs3021 = null;
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_SIKSA_INPUT_TEST");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_SIK", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_SIK", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PKIFS3021", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FROM_DATE", fromDate);
		query.setParameter("I_FROM_SIK", fromSik);
		query.setParameter("I_TO_DATE", toDate);
		query.setParameter("I_TO_SIK", toSik);
		query.setParameter("O_PKIFS3021", "");
		
		Boolean isValid = query.execute();
		pkIfs3021 = (String)query.getOutputParameterValue("O_PKIFS3021");
		return pkIfs3021;
	}
}

