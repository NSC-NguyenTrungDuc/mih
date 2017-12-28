package nta.kcck.model;

/**
 * @author TungLT
 */
public class KcckPaymentProcessModel {

    public KcckPaymentProcessModel() {

    }
    private String shop_id;
    private String order_id;
    private String amount;
    private String tax;
    private String currency;
    private String date_time;
    private String shop_pass;
    private String ret_url;
    private String cancel_url;
    private String user_info;
    private String retry_max;
    private String session_time_out;
    private String lang;
    private String confirm;
    private String user_credit;
    private String template_no;
    private String job_cd;

    public String getShop_id() {
        return shop_id;
    }

    public void setShop_id(String shop_id) {
        this.shop_id = shop_id;
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

    public String getTax() {
        return tax;
    }

    public void setTax(String tax) {
        this.tax = tax;
    }

    public String getCurrency() {
        return currency;
    }

    public void setCurrency(String currency) {
        this.currency = currency;
    }

    public String getDate_time() {
        return date_time;
    }

    public void setDate_time(String date_time) {
        this.date_time = date_time;
    }

    public String getShop_pass() {
        return shop_pass;
    }

    public void setShop_pass(String shop_pass) {
        this.shop_pass = shop_pass;
    }

    public String getRet_url() {
        return ret_url;
    }

    public void setRet_url(String ret_url) {
        this.ret_url = ret_url;
    }

    public String getCancel_url() {
        return cancel_url;
    }

    public void setCancel_url(String cancel_url) {
        this.cancel_url = cancel_url;
    }

    public String getUser_info() {
        return user_info;
    }

    public void setUser_info(String user_info) {
        this.user_info = user_info;
    }

    public String getRetry_max() {
        return retry_max;
    }

    public void setRetry_max(String retry_max) {
        this.retry_max = retry_max;
    }

    public String getSession_time_out() {
        return session_time_out;
    }

    public void setSession_time_out(String session_time_out) {
        this.session_time_out = session_time_out;
    }

    public String getLang() {
        return lang;
    }

    public void setLang(String lang) {
        this.lang = lang;
    }

    public String getConfirm() {
        return confirm;
    }

    public void setConfirm(String confirm) {
        this.confirm = confirm;
    }

    public String getUser_credit() {
        return user_credit;
    }

    public void setUser_credit(String user_credit) {
        this.user_credit = user_credit;
    }

    public String getTemplate_no() {
        return template_no;
    }

    public void setTemplate_no(String template_no) {
        this.template_no = template_no;
    }

    public String getJob_cd() {
        return job_cd;
    }

    public void setJob_cd(String job_cd) {
        this.job_cd = job_cd;
    }
}
