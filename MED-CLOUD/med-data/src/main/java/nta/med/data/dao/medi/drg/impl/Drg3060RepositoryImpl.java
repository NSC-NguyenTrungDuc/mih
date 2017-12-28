package nta.med.data.dao.medi.drg.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3060RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Drg3060RepositoryImpl implements Drg3060RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrDrgLoadPrintGubun(String hospCode, String jubsuDate, String drgBunho, String printGubun) {
		String oPrintGubun = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_LOAD_PRINT_GUBUN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PRINT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_PRINT_GUBUN", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", DateUtil.toDate(jubsuDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_DRG_BUNHO", CommonUtils.parseDouble(drgBunho));
		query.setParameter("I_PRINT_GUBUN", printGubun);
		query.setParameter("O_PRINT_GUBUN", oPrintGubun);
		
		query.execute();
		oPrintGubun = (String) query.getOutputParameterValue("O_PRINT_GUBUN");
		return oPrintGubun;
	}

	@Override
	public String callPrDrgMakeDrg3060(String hospCode, String userId, Double fkocs2003, String boryuYn) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_MAKE_DRG3060");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS2003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BORYU_YN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_FKOCS2003", fkocs2003);
		query.setParameter("I_BORYU_YN", boryuYn);
		
		query.execute();
		String err = (String) query.getOutputParameterValue("O_ERR");
		return err;
	}

	@Override
	public String callPrDrgLoadPrintGubun(String hospCode, Date jusuDate, Double drgBunho, String printGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_LOAD_PRINT_GUBUN");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DRG_BUNHO", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PRINT_GUBUN", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_PRINT_GUBUN", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_JUBSU_DATE", jusuDate);
		query.setParameter("I_DRG_BUNHO", drgBunho);
		query.setParameter("I_PRINT_GUBUN", printGubun);
		
		query.execute();
		String result = (String) query.getOutputParameterValue("O_PRINT_GUBUN");
		return result;
	}
}
