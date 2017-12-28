package nta.kcck.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class TransactionInfoDetailModel {


	private String transaction_id ;
    private String amount ;
    private String exam_date ;
    private String invoice_no ;
    private String payment_date_time ;
    private String status ;
    private String action_link ;
    private String order_id;
	private String transaction_date_time;
	private String fkout1001;
	private String patient_code;
	private String patient_name;
	private String currency;
	private String status_name;

	public String getTransaction_id() {
		return transaction_id;
	}

	public void setTransaction_id(String transaction_id) {
		this.transaction_id = transaction_id;
	}

	public String getAmount() {
		return amount;
	}

	public void setAmount(String amount) {
		this.amount = amount;
	}

	public String getExam_date() {
		return exam_date;
	}

	public void setExam_date(String exam_date) {
		this.exam_date = exam_date;
	}

	public String getInvoice_no() {
		return invoice_no;
	}

	public void setInvoice_no(String invoice_no) {
		this.invoice_no = invoice_no;
	}

	public String getPayment_date_time() {
		return payment_date_time;
	}

	public void setPayment_date_time(String payment_date_time) {
		this.payment_date_time = payment_date_time;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getAction_link() {
		return action_link;
	}

	public void setAction_link(String action_link) {
		this.action_link = action_link;
	}

	public String getOrder_id() {
		return order_id;
	}

	public void setOrder_id(String order_id) {
		this.order_id = order_id;
	}

	public String getTransaction_date_time() {
		return transaction_date_time;
	}

	public void setTransaction_date_time(String transaction_date_time) {
		this.transaction_date_time = transaction_date_time;
	}

	public String getFkout1001() {
		return fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
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

	public String getCurrency() {
		return currency;
	}

	public void setCurrency(String currency) {
		this.currency = currency;
	}

	public String getStatus_name() {
		return status_name;
	}

	public void setStatus_name(String status_name) {
		this.status_name = status_name;
	}
}
