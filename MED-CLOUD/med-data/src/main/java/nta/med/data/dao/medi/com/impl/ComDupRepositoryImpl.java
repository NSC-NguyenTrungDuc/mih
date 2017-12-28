package nta.med.data.dao.medi.com.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.LockModeType;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.data.dao.medi.com.ComDupRepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class ComDupRepositoryImpl implements ComDupRepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(ComDupRepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<Double> getNextGroupSer(String hospCode,
			String keyObj, String bunho, String pkKey, String inputTab) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.KEY_VAL + 1 NEXT_GROUP_SER                                                         ");
		sql.append("  FROM COM_DUP A                                                                            ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                              ");
		sql.append("   AND A.KEY_OBJ   = :key_obj                                                               ");
		sql.append("   AND A.KEY_DATA  = CONCAT(:hospCode,'-',IFNULL(:bunho,''),'-',LPAD(:pk_key, 10, '0'),'-',IFNULL(:input_tab,'')) ");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		//query.setLockMode(LockModeType.PESSIMISTIC_WRITE);
		query.setParameter("hospCode", hospCode);
		query.setParameter("key_obj", keyObj);
		query.setParameter("bunho", bunho);
		query.setParameter("pk_key", pkKey);
		query.setParameter("input_tab", inputTab);

		List<Double> list = query.getResultList();
		return list;
	}
	
	@Override
	public String callPrOcsSetGroupSer(String hospCode, String pkKey,
			String bunho, String inputTab, String keyVal, String keyObj) {
		
		String oResult="";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_SET_GROUP_SER ");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PK_KEY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_TAB", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KEY_VAL", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KEY_OBJ", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_RESULT", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PK_KEY", pkKey);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_INPUT_TAB", inputTab);
		query.setParameter("I_KEY_VAL", keyVal);
		query.setParameter("I_KEY_OBJ", keyObj);
		query.setParameter("O_RESULT", "");
		//Boolean isCheck= query.execute();
		
		oResult = (String)query.getOutputParameterValue("O_RESULT");
		 if(oResult != null && !oResult.isEmpty()){
				return oResult;
			}
		 return null;
	}
}

