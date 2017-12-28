package nta.kcck.model;

/**
 * @author DEV-TiepNM
 */
public class KcckUpdatePaymentStatusModel {
    private String patient_code;
    private String hosp_code;
    private String order_id;
    private String status;
    private String transaction_id;
    private String fkout1001;
    private String comment;
    private String error_code;
    private String trans_date;
    private String user;

    public KcckUpdatePaymentStatusModel(String patient_code, String hosp_code, String order_id, String status,
                                        String transaction_id, String fkout1001, String comment, String error_code, String trans_date, String user) {
        this.patient_code = patient_code;
        this.hosp_code = hosp_code;
        this.order_id = order_id;
        this.status = status;
        this.transaction_id = transaction_id;
        this.fkout1001 = fkout1001;
        this.comment = comment;
        this.error_code = error_code;
        this.trans_date = trans_date;
        this.user = user;
    }

    public String getPatient_code() {
        return patient_code;
    }

    public void setPatient_code(String patient_code) {
        this.patient_code = patient_code;
    }

    public String getHosp_code() {
        return hosp_code;
    }

    public void setHosp_code(String hosp_code) {
        this.hosp_code = hosp_code;
    }

    public String getOrder_id() {
        return order_id;
    }

    public void setOrder_id(String order_id) {
        this.order_id = order_id;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getTransaction_id() {
        return transaction_id;
    }

    public void setTransaction_id(String transaction_id) {
        this.transaction_id = transaction_id;
    }

    public String getFkout1001() {
        return fkout1001;
    }

    public void setFkout1001(String fkout1001) {
        this.fkout1001 = fkout1001;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public String getError_code() {
        return error_code;
    }

    public void setError_code(String error_code) {
        this.error_code = error_code;
    }

    public String getTrans_date() {
        return trans_date;
    }

    public void setTrans_date(String trans_date) {
        this.trans_date = trans_date;
    }

    public String getUser() {
        return user;
    }

    public void setUser(String user) {
        this.user = user;
    }
}
