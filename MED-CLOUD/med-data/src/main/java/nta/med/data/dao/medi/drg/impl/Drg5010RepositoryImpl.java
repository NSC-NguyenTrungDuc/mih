package nta.med.data.dao.medi.drg.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg5010RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Drg5010RepositoryImpl implements Drg5010RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg5010RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Double callPrJihDrgDrg5010Insert(String hospitalCode, Date jubsuDate, String drgBunho, String dataDubun, String inOutGubun, String bunho, Integer fk) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_JIH_DRG_DRG5010_INSERT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATA_DUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FK", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PK", Double.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospitalCode);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_DRG_BUNHO", CommonUtils.parseDouble(drgBunho));
		query.setParameter("I_DATA_DUBUN", dataDubun);
		query.setParameter("I_IN_OUT_GUBUN", inOutGubun);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_FK", CommonUtils.parseDouble(CommonUtils.parseString(fk)));
		
		Boolean isValid = query.execute();
		Double oPk = (Double)query.getOutputParameterValue("O_PK");
		return oPk;
	}
}

