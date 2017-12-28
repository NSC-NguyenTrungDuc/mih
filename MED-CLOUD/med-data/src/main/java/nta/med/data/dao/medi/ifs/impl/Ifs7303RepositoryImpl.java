package nta.med.data.dao.medi.ifs.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.ifs.Ifs7303RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ifs7303RepositoryImpl implements Ifs7303RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrJihInjIfsProc(String hospCode, String ioGubun, Double fkdrg, String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_JIH_INJ_IFS_PROC");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKDRG", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT); 
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_FKDRG", fkdrg);
		query.setParameter("I_USER_ID", userId);
		query.execute();
		
		String err = (String)query.getOutputParameterValue("O_ERR");
		return err;
	}
}