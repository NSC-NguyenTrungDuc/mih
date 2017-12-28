package nta.mss.entity;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.mss.model.TransactionModel;

/**
 * The persistent class for the transaction database table.
 * 
 */
@Entity
@Table(name = "transaction")
public class Transaction extends BaseEntity<TransactionModel> {

	private static final long serialVersionUID = 1106525391206782370L;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id", unique = true, nullable = false)
	private Integer id;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;

	@Column(name = "request_id", unique = true, nullable = false, length = 50)
	private String requestId;
	
	@Column(name = "ref_id", unique = true, nullable = false, length = 50)
	private String refId;
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "executed_datetime")
	private Date executedDatetime;
	
	@Column(name = "amount", nullable = false)
	private Integer amount;
	
	@Column(name = "currency", nullable = false, length = 5)
	private String currency;
	
	@Column(name = "status", nullable = false, length = 5)
	private Integer status;
	
	@Column(name = "error_code", length = 50)
	private String errorCode;

	@Column(name = "payment_gw", length = 50)
	private String paymentGw;
	
	@Column(name = "sys_id", length = 10)
	private String sysId;
	
	@Column(name = "upd_id", length = 10)
	private String updId;
	
	@Column(name = "accessid", nullable = false, length = 100)
	private String accessId;
	
	@Column(name = "accesspass", nullable = false, length = 100)
	private String accessPass;

	/**
	 * Instantiates a new session.
	 */
	public Transaction() {
		super(TransactionModel.class);
	}
	
	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
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

	public Integer getStatus() {
		return status;
	}

	public void setStatus(Integer status) {
		this.status = status;
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

	public Hospital getHospital() {
		return hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}
	
}