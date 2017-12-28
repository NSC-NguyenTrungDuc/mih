package nta.med.data.dao.medi.ocs.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.ocs.Ocs1053RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ocs1053RepositoryImpl implements Ocs1053RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String callPrOcsInterfaceInsert(String hospCode, String ioGubun,Integer pkKey, String userId) {
		String ioErr="";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_INTERFACE_INSERT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PK_KEY", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_PK_KEY", pkKey);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("IO_ERR", ioErr);
		Boolean isCheck= query.execute();
		 ioErr = (String)query.getOutputParameterValue("IO_ERR");
		 if(ioErr != null && !ioErr.isEmpty()){
				return ioErr;
			}
		 return null;
	}
}

