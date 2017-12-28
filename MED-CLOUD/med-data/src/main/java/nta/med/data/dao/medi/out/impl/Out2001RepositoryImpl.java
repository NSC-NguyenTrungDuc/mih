package nta.med.data.dao.medi.out.impl;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.out.Out2001RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Out2001RepositoryImpl implements Out2001RepositoryCustom {
	
	private static final Log LOG = LogFactory.getLog(Out0103RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	//PR_OUT_CREATE_OUT2001_TEMP
	@Override
	public String callPrOutCreateOut2001Temp(String hospCode, Integer pkOcs, String userId) {
		
		String err = null;
		LOG.info("[START] callPrOutCreateOut2001Temp pkOcs=" + pkOcs + ", hospCode=" + hospCode 
				+ ", userId=" + userId);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_CREATE_OUT2001_TEMP");
		query.registerStoredProcedureParameter("I_FKOUT1003", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);       
		
		query.setParameter("I_FKOUT1003",pkOcs);
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_USER_ID",userId);
		query.setParameter("O_ERR","");
		
		Boolean isValid = query.execute();
		if(isValid){
			err = (String)query.getOutputParameterValue("O_ERR");
		}
		return err;
	}
	
	//PR_OIF_MAKE_ORDER_DATA_OUT
	@Override
	public List<String> callPrOutMakeOrderDataOut(String hospCode, String language, String bunho, Date kaikeiDate,
			Integer pkOcs, String docUid , 
			String insureUid, String orderUid, String sangUid, String doctor, 
			String userId) {

		List<String> list = new ArrayList<String>();
		LOG.info("[START] callPrOutMakeOrderDataOut hospCode=" + hospCode + ", language=" + language 
				+ ", bunho=" + bunho
				+ ", kaikeiDate=" + kaikeiDate
				+ ", pkOcs=" + pkOcs
				+ ", doctor =" + docUid 
				+ ", insureUid=" + insureUid
				+ ", orderUid=" + orderUid
				+ ", sangUid=" + sangUid
				+ ", createUser=" + doctor
				+ ", userId=" + userId);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OIF_MAKE_ORDER_DATA_OUT");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KAIKEI_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOUT1003", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOC_UID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INSURE_UID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_UID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SANG_UID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CREATE_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);       
		
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_LANGUAGE",language);
		query.setParameter("I_BUNHO",bunho);
		query.setParameter("I_KAIKEI_DATE",kaikeiDate);
		query.setParameter("I_PKOUT1003",pkOcs);
		query.setParameter("I_DOC_UID",docUid);
		query.setParameter("I_INSURE_UID", insureUid);
		query.setParameter("I_ORDER_UID", orderUid);
		query.setParameter("I_SANG_UID", sangUid);
		query.setParameter("I_CREATE_USER", doctor);
		query.setParameter("I_USER_ID",userId);
		query.setParameter("O_ERR","");
		
		Boolean isValid = query.execute();
		if(isValid){
			String err = (String) query.getOutputParameterValue("O_ERR");
			String pkOif1101 = (String) query.getOutputParameterValue("IO_PKOIF1101");
			list.add(err);
			list.add(pkOif1101);
		}
		return list;
	}
}

