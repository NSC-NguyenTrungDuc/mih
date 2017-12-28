package nta.mss.model;

import java.util.Date;

public class TransactionModel {
	
	private Integer id;
	private Integer hospitalId;
	private String requestId;
	private String refId;
	private Date executedDatetime;
	private Integer amount;
	private String currency;
	private Integer status;
	private String errorCode;
	private String paymentGw;
	private String accessId;
	private String accessPass;
	private String sysId;
	private String updId;
	
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getRequestId() {
		return requestId;
	}
	public void setRequestId(String requestId) {
		this.requestId = requestId;
	}
	public String getRefId() {
		return refId;
	}
	public void setRefId(String refId) {
		this.refId = refId;
	}
	public Date getExecutedDatetime() {
		return executedDatetime;
	}
	public void setExecutedDatetime(Date executedDatetime) {
		this.executedDatetime = executedDatetime;
	}
	public Integer getAmount() {
		return amount;
	}
	public void setAmount(Integer amount) {
		this.amount = amount;
	}
	public String getCurrency() {
		return currency;
	}
	public void setCurrency(String currency) {
		this.currency = currency;
	}
	public Integer getStatus() {
		return status;
	}
	public void setStatus(Integer status) {
		this.status = status;
	}
	public String getErrorCode() {
		return errorCode;
	}
	public void setErrorCode(String errorCode) {
		this.errorCode = errorCode;
	}
	public String getPaymentGw() {
		return paymentGw;
	}
	public void setPaymentGw(String paymentGw) {
		this.paymentGw = paymentGw;
	}
	public String getAccessId() {
		return accessId;
	}
	public void setAccessId(String accessId) {
		this.accessId = accessId;
	}
	public String getAccessPass() {
		return accessPass;
	}
	public void setAccessPass(String accessPass) {
		this.accessPass = accessPass;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	
}
