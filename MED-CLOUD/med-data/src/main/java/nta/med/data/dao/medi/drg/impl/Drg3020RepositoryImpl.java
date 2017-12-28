package nta.med.data.dao.medi.drg.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3020RepositoryCustom;
import nta.med.data.dao.medi.ocs.impl.Ocs2003RepositoryImpl;

/**
 * @author dainguyen.
 */
public class Drg3020RepositoryImpl implements Drg3020RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg3020RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrDrgLoadBongtuSer(String hospCode, String magamDate, String magamGubun, String bunho,
			String magamDept, String userid) {
		String ioMagamSer = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_LOAD_BONGTU_SER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_DEPT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MAGAM_SER", Integer.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_MAGAM_DATE", DateUtil.toDate(magamDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_MAGAM_GUBUN", magamGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_MAGAM_DEPT", magamDept);
		query.setParameter("I_UPD_ID", userid);
		query.setParameter("IO_MAGAM_SER", CommonUtils.parseDouble(ioMagamSer));
		
		query.execute();
		ioMagamSer = ((Integer) query.getOutputParameterValue("IO_MAGAM_SER")).toString();
		return ioMagamSer;
	}
}

