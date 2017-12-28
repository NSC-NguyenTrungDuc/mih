package nta.mss.service.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.entity.Hospital;
import nta.mss.entity.Transaction;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.model.TransactionModel;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.TransactionRepository;
import nta.mss.service.ITransactionService;

/**
 * The Class TransactionService.
 * 
 * @author HoanPC
 * @CrtDate 02/16/2017
 */
@Service
@Transactional
public class TransactionService implements ITransactionService {
	private Mapper mapper;
	private TransactionRepository transactionRepository;
	private HospitalRepository hospitalRepository;

	public TransactionService() {
	}

	@Autowired
	public TransactionService(Mapper mapper, TransactionRepository transactionRepository, HospitalRepository hospitalRepository) {
		this.mapper = mapper;
		this.transactionRepository = transactionRepository;
		this.hospitalRepository = hospitalRepository;
	}

	@Override
	public Transaction saveTransaction(TransactionModel transactionModel) throws Exception {
		Transaction transaction = new Transaction();
		
		transaction.setRequestId(transactionModel.getRequestId());
		transaction.setRefId(transactionModel.getRefId());
		transaction.setExecutedDatetime(transactionModel.getExecutedDatetime());
		transaction.setAmount(transactionModel.getAmount());
		transaction.setCurrency(transactionModel.getCurrency());
		transaction.setStatus(transactionModel.getStatus());
		transaction.setErrorCode(transactionModel.getErrorCode());
		transaction.setPaymentGw(transactionModel.getPaymentGw());
		Hospital hospital = this.hospitalRepository.findOne(transactionModel.getHospitalId());
		transaction.setHospital(hospital);
		transaction.setAccessId(transactionModel.getAccessId());
		transaction.setAccessPass(transactionModel.getAccessPass());
		transaction.setSysId(transactionModel.getSysId());
		transaction.setUpdId(transactionModel.getUpdId());
		transaction.setActiveFlg(ActiveFlag.ACTIVE.toInt());
		transaction.setCreated(new Date());
		transaction.setUpdated(new Date());
		
		transaction = this.transactionRepository.save(transaction);
		return transaction;
		
	}

	@Override
	public void updateTransaction(Integer transactionId, BigDecimal status) throws Exception {
		List<Transaction> transactions = this.transactionRepository.findById(transactionId);
		if(transactions != null && transactions.size() > 0) {
			transactions.get(0).setStatus(status.intValue());
			this.transactionRepository.save(transactions.get(0));
		}
	}
	
}
