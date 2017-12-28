package nta.mss.service;

import java.math.BigDecimal;

import nta.mss.entity.Transaction;
import nta.mss.model.TransactionModel;

/**
 * The Interface ITransactionService.
 * 
 * @author HoanPC
 * @CrtDate 02/16/2017
 */
public interface ITransactionService {
	
	Transaction saveTransaction(TransactionModel transactionModel) throws Exception;
	
	void updateTransaction(Integer transactionId, BigDecimal status) throws Exception; 
	
}
