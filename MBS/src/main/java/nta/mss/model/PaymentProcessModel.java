package nta.mss.model;

/**
 * 
 * @author TungLT
 *
 */
public class PaymentProcessModel {


	public PaymentProcessModel()
	{

	};

	private static final long serialVersionUID = 1L;
	// Decrale field

	private String shopId;

	private String orderId;

	private String amount;

	private String tax;

	private String currency;

	private String dateTime;

	private String shopPass;

	private String shopPassString;

	private String retURL;

	private String cancelURL;

	private String userInfo;

	private String retryMax;

	private String sessionTimeout;
	private String lang;
	private String confirm;
	private String userCredit;
	private String templateNo;
	private String jobCd;

	public String getShopId() {
		return shopId;
	}
	public void setShopId(String shopId) {
		this.shopId = shopId;
	}
	public String getOrderId() {
		return orderId;
	}
	public void setOrderId(String orderId) {
		this.orderId = orderId;
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
	public String getDateTime() {
		return dateTime;
	}
	public void setDateTime(String dateTime) {
		this.dateTime = dateTime;
	}
	public String getShopPassString() {
		return shopPassString;
	}
	public void setShopPassString(String shopPassString) {
		this.shopPassString = shopPassString;
	}
	public String getRetURL() {
		return retURL;
	}
	public void setRetURL(String retURL) {
		this.retURL = retURL;
	}
	public String getCancelURL() {
		return cancelURL;
	}
	public void setCancelURL(String cancelURL) {
		this.cancelURL = cancelURL;
	}
	public String getUserInfo() {
		return userInfo;
	}
	public void setUserInfo(String userInfo) {
		this.userInfo = userInfo;
	}
	public String getRetryMax() {
		return retryMax;
	}
	public void setRetryMax(String retryMax) {
		this.retryMax = retryMax;
	}
	public String getSessionTimeout() {
		return sessionTimeout;
	}
	public void setSessionTimeout(String sessionTimeout) {
		this.sessionTimeout = sessionTimeout;
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
	public String getUserCredit() {
		return userCredit;
	}
	public void setUserCredit(String userCredit) {
		this.userCredit = userCredit;
	}
	public String getTemplateNo() {
		return templateNo;
	}
	public void setTemplateNo(String templateNo) {
		this.templateNo = templateNo;
	}
	public String getJobCd() {
		return jobCd;
	}
	public void setJobCd(String jobCd) {
		this.jobCd = jobCd;
	}
	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public String getShopPass() {
		return shopPass;
	}

	public void setShopPass(String shopPass) {
		this.shopPass = shopPass;
	}
}
