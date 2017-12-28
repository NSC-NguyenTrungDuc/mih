package nta.mss.repository;

import java.util.List;

import nta.mss.info.TransactionInfo;


/**
 *
 * @author HoanPC
 * @CrtDate 02/16/2016
 *
 */
public interface TransactionRepositoryCustom {
	
	public List<TransactionInfo> getTransactionInfo(String sessionId);
	
}
