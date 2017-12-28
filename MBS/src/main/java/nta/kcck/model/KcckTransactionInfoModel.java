package nta.kcck.model;

import java.util.ArrayList;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class KcckTransactionInfoModel {
    private Integer total_record;
    private List<TransactionInfoDetailModel> transactions = new ArrayList<>();

    public List<TransactionInfoDetailModel> getTransactions() {
        return transactions;
    }

    public void setTransactions(List<TransactionInfoDetailModel> transactions) {
        this.transactions = transactions;
    }

    public Integer getTotal_record() {
        return total_record;
    }

    public void setTotal_record(Integer total_record) {
        this.total_record = total_record;
    }
}
