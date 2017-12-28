package nta.mss.repository.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.info.TransactionInfo;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.repository.TransactionRepositoryCustom;

/**
 * TransactionRepositoryImpl.java
 *
 * @author HoanPC
 * @CrtDate 02/16/2017
 *
 */
public class TransactionRepositoryImpl implements TransactionRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<TransactionInfo> getTransactionInfo(String sessionId) {
		try {
			StringBuilder sql = new StringBuilder();
			sql.append(" SELECT t.accessid, t.accesspass, t.amount, t.id, t.status, t.request_id, t.executed_datetime		");
			sql.append("        FROM transaction t									    									");
			sql.append("        INNER JOIN reservation r ON r.transaction_id =t.id											");
			sql.append("        WHERE r.session_id = :sessionId																");
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("sessionId", sessionId);
			
			List<TransactionInfo> list = new JpaResultMapper().list(query, TransactionInfo.class);	
			return list;
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

}
