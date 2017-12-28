package nta.mss.model;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class PaymentHistoriesModel {
    private Integer totalRecord;
    private List<PaymentHistory> paymentHistories;

    public Integer getTotalRecord() {
        return totalRecord;
    }

    public void setTotalRecord(Integer totalRecord) {
        this.totalRecord = totalRecord;
    }

    public List<PaymentHistory> getPaymentHistories() {
        return paymentHistories;
    }

    public void setPaymentHistories(List<PaymentHistory> paymentHistories) {
        this.paymentHistories = paymentHistories;
    }
}
