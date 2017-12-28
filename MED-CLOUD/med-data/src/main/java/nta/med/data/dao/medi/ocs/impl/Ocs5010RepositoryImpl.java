package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.ocs.Ocs5010RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Ocs5010RepositoryImpl implements Ocs5010RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ocs5010RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public void callPrOcsUpdateResult(String hospCode, String inOutGubun, Double fkOcs, String resultBuseo, Date resultDate){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_UPDATE_RESULT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT_BUSEO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT_DATE", Date.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_FKOCS", fkOcs);
		query.setParameter("I_RESULT_BUSEO", resultBuseo);
		query.setParameter("I_RESULT_DATE", resultDate);
		
		query.execute();
	}
}

