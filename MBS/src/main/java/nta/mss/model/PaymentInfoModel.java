package nta.mss.model;

/**
 * 
 * @author TungLT
 *
 */
public class PaymentInfoModel {
	private String patientId;
	private String patientCode;
	private String patientName;
	private String datetimeExamination;
	private String address;
	private String phone;
	private String email;
	private String cardType;
	private String totalPayment;
	private String orderId;
	private String amount;
	private String shopPass;
	private String fkOut;
	private String invoiceNo;
	private String password;

	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
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
	public String getDatetimeExamination() {
		return datetimeExamination;
	}
	public void setDatetimeExamination(String datetimeExamination) {
		this.datetimeExamination = datetimeExamination;
	}
	public String getCardType() {
		return cardType;
	}
	public void setCardType(String cardType) {
		this.cardType = cardType;
	}
	public String getTotalPayment() {
		return totalPayment;
	}
	public void setTotalPayment(String totalPayment) {
		this.totalPayment = totalPayment;
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
	public String getShopPass() {
		return shopPass;
	}
	public void setShopPass(String shopPass) {
		this.shopPass = shopPass;
	}
	public String getFkOut() {
		return fkOut;
	}
	public void setFkOut(String fkOut) {
		this.fkOut = fkOut;
	}
	public String getInvoiceNo() {
		return invoiceNo;
	}
	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}
	public String getPatientId() {
		return patientId;
	}
	public void setPatientId(String patientId) {
		this.patientId = patientId;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}

}
