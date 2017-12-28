package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.ocs.Ocs2004RepositoryCustom;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;

/**
 * @author dainguyen.
 */
public class Ocs2004RepositoryImpl implements Ocs2004RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public CommonProcResultInfo callPrOcsiAutoCreateJisi(String hospCode, double fkinp1001, String bunho,
			String inputGubun, String inputId, String inputGwa, String inputDoctor, Date orderDate, String orderTime) {

		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCSI_AUTO_CREATE_JISI");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_TIME", String.class, ParameterMode.IN);

		query.registerStoredProcedureParameter("IO_RESULT_CNT", Integer.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_INPUT_ID", inputId);
	    query.setParameter("I_INPUT_GWA", inputGwa);
	    query.setParameter("I_INPUT_DOCTOR", inputDoctor);
	    query.setParameter("I_ORDER_DATE", orderDate);
	    query.setParameter("I_ORDER_TIME", orderTime);
	    
	    query.execute();
	    
	    Integer cnt = (Integer)query.getOutputParameterValue("IO_RESULT_CNT");
	    String flag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(cnt == null ? "" : String.valueOf(cnt));
	    info.setStrResult2(flag == null ? "" : flag); 
	    
		return info;
	}

	@Override
	public CommonProcResultInfo callPrOcsiOcs2005Dup(String hospCode, String iud, String gubun, String bunho,
			double fkinp1001, Date fromDate, String fromTime, Date toDate, String toTime, String user,
			Double pkocs2005) {
		
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCSI_OCS2005_DUP");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2005", Double.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_IUD", iud);
	    query.setParameter("I_GUBUN", gubun);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_FROM_DATE", fromDate);
	    query.setParameter("I_FROM_TIME", fromTime);
	    query.setParameter("I_TO_DATE", toDate);
	    query.setParameter("I_TO_TIME", toTime);
	    query.setParameter("I_USER", user);
	    query.setParameter("I_PKOCS2005", pkocs2005);
	    
	    query.execute();
	    String err = (String)query.getOutputParameterValue("O_ERR");
	    String msg = (String)query.getOutputParameterValue("O_MSG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(err == null ? "" : err);
	    info.setStrResult2(msg == null ? "" : msg); 
	    
	    return info;
	}
}
