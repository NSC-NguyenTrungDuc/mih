package nta.med.data.dao.medi.nur.impl;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.nur.Nur1040RepositoryCustom;
import nta.med.data.model.ihis.cpls.PrOcsoChkResultMsgListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Nur1040RepositoryImpl implements Nur1040RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Nur1040RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public PrOcsoChkResultMsgListItemInfo prOcsoChkResultMsg(String hospCode, String ocskey, String userId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSO_CHK_RESULT_MSG");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_OCSKEY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_IP", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_TEXT", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("O_ERR_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_OCSKEY", ocskey);
		query.setParameter("I_USER_ID", userId);
		
		Boolean isValid = query.execute();
		PrOcsoChkResultMsgListItemInfo info = new PrOcsoChkResultMsgListItemInfo();
		info.setIpValue((String)query.getOutputParameterValue("O_IP"));
		info.setTextValue((String)query.getOutputParameterValue("O_TEXT"));
		info.setErrFlg((String)query.getOutputParameterValue("O_ERR_FLAG"));
		return info;
	}
}

