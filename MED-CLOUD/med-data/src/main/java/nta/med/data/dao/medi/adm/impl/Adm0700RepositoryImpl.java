package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.data.dao.medi.adm.Adm0700RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Adm0700RepositoryImpl implements Adm0700RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String getOCS2003U99SeqRequest(String hospCode, String senderId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT IFNULL(MAX(SEND_SEQ),0) + 1   	");
		sql.append("   FROM ADM0700   						");
		sql.append("  WHERE SEND_DT   = DATE(SYSDATE())   	");
		sql.append("    AND HOSP_CODE = :f_hosp_code  		");
		sql.append("    AND SENDER_ID = :f_sender_id  		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sender_id", senderId);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
}

