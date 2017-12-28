package nta.kcck.model;

/**
 * @author TungLT
 */
public class KcckPaymentInfoModel {
    private String patient_id;
    private String patient_code;
    private String patient_name;
    private String examination_date;
    private String address;
    private String phone;
    private String email;
    private String card_type;
    private String total_payment;
    private String order_id;
    private String amount;
    private String shop_pass;
    private String fk_out;
    private String invoice_no;
    private String password;

    public String getPatient_id() {
        return patient_id;
    }

    public void setPatient_id(String patient_id) {
        this.patient_id = patient_id;
    }

    public String getPatient_code() {
        return patient_code;
    }

    public void setPatient_code(String patient_code) {
        this.patient_code = patient_code;
    }

    public String getPatient_name() {
        return patient_name;
    }

    public void setPatient_name(String patient_name) {
        this.patient_name = patient_name;
    }

    public String getExamination_date() {
        return examination_date;
    }

    public void setExamination_date(String examination_date) {
        this.examination_date = examination_date;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getCard_type() {
        return card_type;
    }

    public void setCard_type(String card_type) {
        this.card_type = card_type;
    }

    public String getTotal_payment() {
        return total_payment;
    }

    public void setTotal_payment(String total_payment) {
        this.total_payment = total_payment;
    }

    public String getOrder_id() {
        return order_id;
    }

    public void setOrder_id(String order_id) {
        this.order_id = order_id;
    }

    public String getAmount() {
        return amount;
    }

    public void setAmount(String amount) {
        this.amount = amount;
    }

    public String getShop_pass() {
        return shop_pass;
    }

    public void setShop_pass(String shop_pass) {
        this.shop_pass = shop_pass;
    }

    public String getFk_out() {
        return fk_out;
    }

    public void setFk_out(String fk_out) {
        this.fk_out = fk_out;
    }

    public String getInvoice_no() {
        return invoice_no;
    }

    public void setInvoice_no(String invoice_no) {
        this.invoice_no = invoice_no;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
