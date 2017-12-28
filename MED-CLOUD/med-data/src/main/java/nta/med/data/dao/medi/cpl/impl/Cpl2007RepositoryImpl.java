package nta.med.data.dao.medi.cpl.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.cpl.Cpl2007RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
/**
 * @author dainguyen.
 */
public class Cpl2007RepositoryImpl implements Cpl2007RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Cpl2007RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public String callPrCplCalInsertBaseResult(String hospCode,
			String specimenSer, String hangmogCode, String result, String ioFlag) {
		LOGGER.info("[START] PR_CPL_CAL_INSERT_BASE_RESULT hospitalCode=" + hospCode + 
				", specimenSer=" + specimenSer + ", hangmogCode=" + hangmogCode + ", result=" + result+ ", ioFlag=" + ioFlag);
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_CAL_INSERT_BASE_RESULT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_RESULT", result);
		query.setParameter("IO_FLAG", ioFlag);
		
		
		String ioFlg = (String)query.getOutputParameterValue("IO_FLAG");
		if(ioFlg != null && !ioFlg.isEmpty()){
			return ioFlg;
		}
		return null;
	}
}

