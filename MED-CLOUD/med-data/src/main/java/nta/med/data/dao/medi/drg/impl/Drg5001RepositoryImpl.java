package nta.med.data.dao.medi.drg.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.data.dao.medi.drg.Drg5001RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Drg5001RepositoryImpl implements Drg5001RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Date callFnDrgGetCycleOrdDate(String hospCode, Date ordDate, String hoDong) {
		String sql = " SELECT FN_DRG_GET_CYCLE_ORD_DATE(:f_hosp_code, :f_ord_date, :f_ho_dong) FROM DUAL ";
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ord_date", ordDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<Date> dts = query.getResultList();
		return CollectionUtils.isEmpty(dts) ? null : dts.get(0);
	}

	@Override
	public Date callFnDrgGetCycleMagamDate(String hospCode, Date ordDate, String hoDong) {
		String sql = " SELECT FN_DRG_GET_CYCLE_MAGAM_DATE(:f_hosp_code, :f_ord_date, :f_ho_dong) FROM DUAL ";
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ord_date", ordDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<Date> dts = query.getResultList();
		return CollectionUtils.isEmpty(dts) ? null : dts.get(0);
	}

	@Override
	public String callPrDrgInpMagam(String updId, String hospCode, String hoDong, Date magamDate, String magamGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_DRG_INP_MAGAM ");
		query.registerStoredProcedureParameter("I_UPD_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HO_DONG", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MAGAM_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_UPD_ID", updId);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_HO_DONG", hoDong);
		query.setParameter("I_MAGAM_DATE", magamDate);
		query.setParameter("I_MAGAM_GUBUN", magamGubun);
		
		query.execute();
		String flag = (String) query.getOutputParameterValue("O_FLAG");
		return flag;
	}
	
}
