package nta.mss.service.impl;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Currency;
import java.util.List;
import java.util.Locale;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ctc.wstx.util.StringUtil;

import nta.kcck.model.KcckOrderMedicineModel;
import nta.kcck.model.KcckPaymentInfoModel;
import nta.kcck.model.KcckPaymentModel;
import nta.kcck.model.KcckPaymentProcessModel;
import nta.kcck.model.KcckTransactionInfoModel;
import nta.kcck.model.KcckUpdatePaymentStatusModel;
import nta.kcck.model.TransactionInfoDetailModel;
import nta.kcck.service.IKcckApiService;
import nta.med.common.util.Collections;
import nta.mss.model.OrderMedicineModel;
import nta.mss.model.PaymentHistoriesModel;
import nta.mss.model.PaymentHistory;
import nta.mss.model.PaymentInfoModel;
import nta.mss.model.PaymentModel;
import nta.mss.model.PaymentProcessModel;
import nta.mss.model.SearchPaymentTransaction;
import nta.mss.service.IPaymentHistoryService;

/**
 * @author DEV-TiepNM
 */
@Service
@Transactional
public class PaymentHistoryService implements IPaymentHistoryService {
	@Autowired
	private IKcckApiService kcckApiService;

	@Override
	public PaymentHistoriesModel getPaymentHistory(SearchPaymentTransaction searchPaymentTransaction) {
		PaymentHistoriesModel paymentHistoryModel = new PaymentHistoriesModel();
		List<PaymentHistory> paymentHistories = new ArrayList<>();
		KcckTransactionInfoModel kcckPaymentInfoModel = kcckApiService.getTransactionInfos(searchPaymentTransaction);
		for (TransactionInfoDetailModel model : kcckPaymentInfoModel.getTransactions()) {
			PaymentHistory paymentHistory = new PaymentHistory();
			paymentHistory.setTransactionId(model.getTransaction_id());
			paymentHistory.setTransactionDateTime(model.getTransaction_date_time());
			paymentHistory.setPaymentDateTime(model.getPayment_date_time());
			paymentHistory.setAmount(new BigDecimal(model.getAmount()));
			paymentHistory.setOrderId(model.getOrder_id());
			paymentHistory.setInvoiceNo(model.getInvoice_no());
			paymentHistory.setStatus(model.getStatus());
			paymentHistory.setValueStatus(model.getStatus());
			paymentHistory.setLink(model.getExam_date());
			paymentHistory.setPatientCode(model.getPatient_code());
			paymentHistory.setPatientName(model.getPatient_name());
			paymentHistory.setFkOut(model.getFkout1001());
			paymentHistory.setExamDate(model.getExam_date());
			String transactionId = model.getTransaction_id();
			String transactionIdShort = transactionId;
			if(!StringUtils.isEmpty(transactionId) && transactionId.length() > 10)
			{
				int length = transactionId.length();
				int startSliceIndex = length - 10;
				transactionIdShort = "...." + transactionId.substring(startSliceIndex, length);
			}
			paymentHistory.setTransactionIdShort(transactionIdShort);
			paymentHistories.add(paymentHistory);
		}
		paymentHistoryModel.setPaymentHistories(paymentHistories);
		paymentHistoryModel.setTotalRecord(
				kcckPaymentInfoModel.getTotal_record() == null ? 0 : kcckPaymentInfoModel.getTotal_record());
		return paymentHistoryModel;
	}

	@Override
	public PaymentModel getKcckPayment(String fkOut, String patientCode, String hospCode, String orderId) {
		PaymentModel paymentModel = new PaymentModel();
		KcckPaymentModel kcckPaymentModel = kcckApiService.getKcckPayment(fkOut, patientCode, hospCode, orderId);

		List<OrderMedicineModel> orderMedicines = new ArrayList<>();
		PaymentInfoModel paymentInfo = new PaymentInfoModel();
		PaymentProcessModel paymentProcess = new PaymentProcessModel();
		getPaymentInfoAndPaymentProgress(kcckPaymentModel, orderMedicines, paymentInfo, paymentProcess);

		paymentModel.setOrderMedicine(orderMedicines);
		paymentModel.setPaymentInfo(paymentInfo);
		paymentModel.setPaymentProcess(paymentProcess);
		paymentModel.setExpireLink(kcckPaymentModel.getExpire_link() == null ? "" : kcckPaymentModel.getExpire_link());
		return paymentModel;
	}

	@Override
	public boolean updatePayment(KcckUpdatePaymentStatusModel updatePaymentInfo) {
		return kcckApiService.updatePayment(updatePaymentInfo);
	}

	private void getPaymentInfoAndPaymentProgress(KcckPaymentModel kcckPaymentModel,
			List<OrderMedicineModel> orderMedicines, PaymentInfoModel paymentInfo, PaymentProcessModel paymentProcess) {
		if (!Collections.isEmpty(kcckPaymentModel.getOrder_medicine())) {
			for (KcckOrderMedicineModel item : kcckPaymentModel.getOrder_medicine()) {
				String price = item.getPrice();
				if(price.equals(""))
					price = "0";
				String calPrice = item.getCal_price();
				if(calPrice.equals(""))
					calPrice = "0";
				if (kcckPaymentModel.getPayment_process() != null) {
					if (!price.equals("") && kcckPaymentModel.getPayment_process().getCurrency()
							.equals(Currency.getInstance(Locale.JAPAN).getCurrencyCode())) {
						price = String.format("%d", (int) Double.parseDouble(price));
					}
					if (!calPrice.equals("") && kcckPaymentModel.getPayment_process().getCurrency()
							.equals(Currency.getInstance(Locale.JAPAN).getCurrencyCode())) {
						calPrice = String.format("%d", (int) Double.parseDouble(calPrice));
					}
				}
				OrderMedicineModel orderMedicineModel = new OrderMedicineModel(item.getHangmog_name(),
						item.getHangmog_code(), item.getCode_name(), price, item.getQuantity(), calPrice);

				orderMedicines.add(orderMedicineModel);
			}
		}
		if (kcckPaymentModel.getPayment_info() != null) {
			KcckPaymentInfoModel kcckPaymentInfoModel = kcckPaymentModel.getPayment_info();
			paymentInfo.setPatientId(kcckPaymentInfoModel.getPatient_id());
			paymentInfo.setPatientCode(kcckPaymentInfoModel.getPatient_code());
			paymentInfo.setPatientName(kcckPaymentInfoModel.getPatient_name());
			paymentInfo.setDatetimeExamination(kcckPaymentInfoModel.getExamination_date());
			paymentInfo.setAddress(kcckPaymentInfoModel.getAddress());
			paymentInfo.setPhone(kcckPaymentInfoModel.getPhone());
			paymentInfo.setEmail(kcckPaymentInfoModel.getEmail());
			paymentInfo.setCardType(kcckPaymentInfoModel.getCard_type());
			paymentInfo.setOrderId(kcckPaymentInfoModel.getOrder_id());
			paymentInfo.setAmount(kcckPaymentInfoModel.getAmount());
			paymentInfo.setFkOut(kcckPaymentInfoModel.getFk_out());
			paymentInfo.setInvoiceNo(kcckPaymentInfoModel.getInvoice_no());
			paymentInfo.setPassword(kcckPaymentInfoModel.getPassword());

		}

		if (kcckPaymentModel.getPayment_process() != null) {
			KcckPaymentProcessModel item = kcckPaymentModel.getPayment_process();
			paymentProcess.setShopId(item.getShop_id());
			paymentProcess.setOrderId(item.getOrder_id());
			paymentProcess.setAmount(item.getAmount());
			paymentProcess.setTax(item.getTax());
			paymentProcess.setDateTime(item.getDate_time());
			paymentProcess.setShopPass(item.getShop_pass());
			paymentProcess.setRetURL(item.getRet_url());
			paymentProcess.setCancelURL(item.getCancel_url());
			paymentProcess.setUserInfo(item.getUser_info());
			paymentProcess.setRetryMax(item.getRetry_max());
			paymentProcess.setSessionTimeout(item.getSession_time_out());
			paymentProcess.setLang(item.getLang());
			paymentProcess.setConfirm(item.getConfirm());
			paymentProcess.setUserCredit(item.getUser_credit());
			paymentProcess.setTemplateNo(item.getTemplate_no());
			paymentProcess.setJobCd(item.getJob_cd());
			paymentProcess.setCurrency(item.getCurrency());
		}
	}
}
