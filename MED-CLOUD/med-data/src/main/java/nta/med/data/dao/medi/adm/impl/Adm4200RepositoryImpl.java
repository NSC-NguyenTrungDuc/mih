package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.data.dao.medi.adm.Adm4200RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Adm4200RepositoryImpl implements Adm4200RepositoryCustom {
private static final Log LOGGER = LogFactory.getLog(Adm4200RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public boolean isExistedADM4200(String hospCode, String userId, String sysId, String trId) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM ADM4200 A                       	 	    		");
		sql.append("	WHERE A.SYS_ID     = :f_sys_id   		    			");
		sql.append("	AND A.USER_ID     = :f_user_id   		    			");
		sql.append("	AND A.TR_ID     = :f_tr_id   		    			    ");
		sql.append("	AND A.HOSP_CODE     = :f_hosp_code   		    	    ");
	
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_sys_id", sysId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_tr_id", trId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	
}

