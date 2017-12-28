package nta.med.data.dao.medi.pfe.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.data.dao.medi.adm.impl.Adm3200RepositoryImpl;
import nta.med.data.dao.medi.pfe.Pfe0201RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Pfe0201RepositoryImpl implements Pfe0201RepositoryCustom {
private static final Log LOGGER = LogFactory.getLog(Adm3200RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	public Double callPrPfeEkgPfe5010Insert (String hospCode, Date oderDate, String dataDubun, 
			String inOutGubun, String bunho, Integer fk) {
		LOGGER.info("[START] callPrPfeEkgPfe5010Insert");
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_PFE_EKG_PFE5010_INSERT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_DUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FK", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PK", Double.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_ORDER_DATE", oderDate);
		query.setParameter("I_DATA_DUBUN", dataDubun);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FK", fk);
		
		Boolean isValid = query.execute();
		double oPk = -1;
		if (isValid == true) {
			oPk = (Double)query.getOutputParameterValue("O_PK");
		}
		return oPk;
	}
	
	public String callPrPfeEkgIfsProc (String hospCode, String ioGubun, Integer fkpfe, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_PFE_EKG_IFS_PROC");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IO_GUBUN", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKPFE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_IO_GUBUN", ioGubun);
		query.setParameter("I_FKPFE", fkpfe);
		query.setParameter("I_USER_ID", userId);

		query.execute();
		String oErr = query.getOutputParameterValue("O_PK").toString();
		return oErr;
	}
}

