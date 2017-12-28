package nta.med.data.dao.medi.drg.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.drg.Drg2020RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Drg2020RepositoryImpl implements Drg2020RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg2020RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrDrgMakeBongtuOut(Date sysDate, String userId, Date orderDate, Date jubsuDate, String jubsuTime, Integer drgBunho, 
			String wonyoiOrderYn, String jubsuYn, String gyunbonYn, String hospCode, String language) {
		LOG.info("[START] callPrDrgMakeBongtuOut");
		String out = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_MAKE_BONGTU_OUT");
		query.registerStoredProcedureParameter("I_SYS_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.INOUT);;
		query.registerStoredProcedureParameter("I_JUBSU_TIME", String.class, ParameterMode.INOUT);;
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Integer.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_WONYOI_ORDER_YN", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_JUBSU_YN", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_GYUNBON_YN", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("P_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_SYS_DATE", sysDate);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_JUBSU_DATE", jubsuDate);
		query.setParameter("I_JUBSU_TIME", jubsuTime);
		query.setParameter("I_DRG_BUNHO", drgBunho);
		query.setParameter("I_WONYOI_ORDER_YN", wonyoiOrderYn);
		query.setParameter("I_JUBSU_YN", jubsuYn);
		query.setParameter("I_GYUNBON_YN", gyunbonYn);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("O_ERR", out);
		query.setParameter("P_ERR", "");
		
		Boolean isValid = query.execute();
		out = (String)query.getOutputParameterValue("O_ERR");
		String error = (String)query.getOutputParameterValue("P_ERR");
		if(!StringUtils.isEmpty(error)) {
			LOG.info("Error in PR_DRG_MAKE_BONGTU_OUT is: " + error);
		}
		LOG.info("[END] callPrDrgMakeBongtuOut");
		return out;
	}
}


