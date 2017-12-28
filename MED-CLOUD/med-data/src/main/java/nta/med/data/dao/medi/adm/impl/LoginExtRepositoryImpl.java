package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.LoginExtRepositoryCustom;
import nta.med.data.model.ihis.system.LoginExtInfo;

/**
 * @author dainguyen.
 */
public class LoginExtRepositoryImpl implements LoginExtRepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(LoginExtRepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public LoginExtInfo getLoginExt(
			String userId, String hospCode) {
		StringBuffer sql = new StringBuffer();	
		sql.append(" SELECT CHANGE_PWD_FLG, 			                                                                	");
		sql.append("       FIRST_LOGIN_FLG,                                                                            		");
		sql.append("       LAST_CHANGE_PWD,	                                                                         		");
		sql.append("       PWD_HISTORY	                                                                         			");
		sql.append(" FROM LOGIN_EXT                                                                               			");               
		sql.append(" WHERE ACTIVE_FLG = '1' AND USER_ID = :f_user_id                                                        ");
		sql.append("  	AND HOSP_CODE = :f_hosp_code                               											");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		List<LoginExtInfo> list = new JpaResultMapper().list(query, LoginExtInfo.class);
		if (!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}
	
}

