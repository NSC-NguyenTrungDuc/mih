package nta.mss.service;

import nta.kcck.model.KcckUpdatePaymentStatusModel;
import nta.mss.model.PaymentHistoriesModel;
import nta.mss.model.PaymentModel;
import nta.mss.model.SearchPaymentTransaction;

/**
 * @author DEV-TiepNM
 */
public interface IPaymentHistoryService {
    public PaymentHistoriesModel getPaymentHistory(SearchPaymentTransaction searchPaymentTransaction);
    public PaymentModel getKcckPayment(String fkOut, String patientCode, String hospCode, String orderId);
    public boolean updatePayment(KcckUpdatePaymentStatusModel updatePaymentInfo);
}
