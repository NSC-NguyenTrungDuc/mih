package nta.kcck.model;

public class KcckGmoShopInfoModel {
	
	private String shop_id;
	private String shop_password;
	private String use_auth = "N";
	private int auth_amt;
	private String template_no = "1";
	
	private String currency = "JPY";
	private String locale;
	private boolean isAuthorization;
	
	private int tax;
	private String order_id;
	private String date_time;
	private String shop_pass_string;
	private String ret_url;
	private String cancel_url;
	private String user_info = "pc";
	private String retry_max ="2";
	private String session_timeout = "9999";
	private String use_credit = "1";
	private String job_cd = "SAUTH";
	
	private String patientname;
	private String bookingMode;
	private String currencyDisplay = "JPY";
	
	// GMO PG
	private String gmoPayUrlResquestion;
	private String gmoPayUrlCancelation;
	
	public String getUse_auth() {
		return use_auth;
	}
	public void setUse_auth(String use_auth) {
		this.use_auth = use_auth;
	}
	public int getAuth_amt() {
		return auth_amt;
	}
	public void setAuth_amt(int auth_amt) {
		this.auth_amt = auth_amt;
	}
	public String getCurrency() {
		return currency;
	}
	public void setCurrency(String currency) {
		this.currency = currency;
	}
	public String getLocale() {
		return locale;
	}
	public void setLocale(String locale) {
		this.locale = locale;
	}
	public String getShop_id() {
		return shop_id;
	}
	public void setShop_id(String shop_id) {
		this.shop_id = shop_id;
	}
	public String getShop_password() {
		return shop_password;
	}
	public void setShop_password(String shop_password) {
		this.shop_password = shop_password;
	}
	public String getTemplate_no() {
		return template_no;
	}
	public void setTemplate_no(String template_no) {
		this.template_no = template_no;
	}
	public boolean isAuthorization() {
		return isAuthorization;
	}
	public void setAuthorization(boolean isAuthorization) {
		this.isAuthorization = isAuthorization;
	}
	
	public int getTax() {
		return tax;
	}
	public void setTax(int tax) {
		this.tax = tax;
	}
	public String getOrder_id() {
		return order_id;
	}
	public void setOrder_id(String order_id) {
		this.order_id = order_id;
	}
	public String getDate_time() {
		return date_time;
	}
	public void setDate_time(String date_time) {
		this.date_time = date_time;
	}
	public String getShop_pass_string() {
		return shop_pass_string;
	}
	public void setShop_pass_string(String shop_pass_string) {
		this.shop_pass_string = shop_pass_string;
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
	public String getSession_timeout() {
		return session_timeout;
	}
	public void setSession_timeout(String session_timeout) {
		this.session_timeout = session_timeout;
	}
	public String getUse_credit() {
		return use_credit;
	}
	public void setUse_credit(String use_credit) {
		this.use_credit = use_credit;
	}
	public String getJob_cd() {
		return job_cd;
	}
	public void setJob_cd(String job_cd) {
		this.job_cd = job_cd;
	}
	public String getGmoPayUrlResquestion() {
		return gmoPayUrlResquestion;
	}
	public void setGmoPayUrlResquestion(String gmoPayUrlResquestion) {
		this.gmoPayUrlResquestion = gmoPayUrlResquestion;
	}
	public String getGmoPayUrlCancelation() {
		return gmoPayUrlCancelation;
	}
	public void setGmoPayUrlCancelation(String gmoPayUrlCancelation) {
		this.gmoPayUrlCancelation = gmoPayUrlCancelation;
	}
	public String getPatientname() {
		return patientname;
	}
	public void setPatientname(String patientname) {
		this.patientname = patientname;
	}
	public KcckGmoShopInfoModel() {
		super();
	}
	public String getBookingMode() {
		return bookingMode;
	}
	public void setBookingMode(String bookingMode) {
		this.bookingMode = bookingMode;
	}
	public String getCurrencyDisplay() {
		return currencyDisplay;
	}
	public void setCurrencyDisplay(String currencyDisplay) {
		this.currencyDisplay = currencyDisplay;
	}
	public KcckGmoShopInfoModel(String use_auth, int auth_amt, String currency, String locale) {
		super();
		this.use_auth = use_auth;
		this.auth_amt = auth_amt;
		this.currency = currency;
		this.locale = locale;
	}
	
	public KcckGmoShopInfoModel(String shop_id, String shop_password, String use_auth, int auth_amt, String currency,
			String locale, String template_no) {
		super();
		this.shop_id = shop_id;
		this.shop_password = shop_password;
		this.use_auth = use_auth;
		this.auth_amt = auth_amt;
		this.currency = currency;
		this.locale = locale;
		this.template_no = template_no;
	}
	
}
