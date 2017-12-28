package nta.med.core.domain.bill;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

/**
 * The persistent class for the BIL0101 database table.
 * 
 */
@Entity
@Table(name = "BIL0101")
public class Bil0101 implements Serializable {
	private static final long serialVersionUID = 1L;
	private String invoiceNo;
	private BigDecimal activeFlg;
	private BigDecimal amount;
	private String bunho;
	private String cashierNm;
	private Date created;
	private String deptCd;
	private String deptNm;
	private BigDecimal discount;
	private String doctor;
	private String doctorNm;
	private double fkout1001;
	private String hospCode;
	private Date invoiceDate;
	private String paidName;
	private String patientAddr;
	private Date patientDob;
	private String patientGender;
	private String patientGrp;
	private String patientGrpNm;
	private String patientNm;
	private String paymentCd;
	private String paymentNm;
	private BigDecimal statusFlg;
	private String sysId;
	private String updId;
	private Date updated;
	private Date visitDate;
	private String revertType;
	private String revertComment;
	private String patientTel;
	private String patientMobile;
	private String discountComment;
	private String discountType;
	private BigDecimal amountPaid;
	private BigDecimal amountDebt;
	private String parentInvoiceNo;
	public Bil0101() {
	}

	@Id
	@Column(name = "INVOICE_NO", nullable = false)
	public String getInvoiceNo() {
		return this.invoiceNo;
	}

	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public BigDecimal getAmount() {
		return this.amount;
	}

	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CASHIER_NM")
	public String getCashierNm() {
		return this.cashierNm;
	}

	public void setCashierNm(String cashierNm) {
		this.cashierNm = cashierNm;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	@Column(name = "DEPT_CD")
	public String getDeptCd() {
		return this.deptCd;
	}

	public void setDeptCd(String deptCd) {
		this.deptCd = deptCd;
	}

	@Column(name = "DEPT_NM")
	public String getDeptNm() {
		return this.deptNm;
	}

	public void setDeptNm(String deptNm) {
		this.deptNm = deptNm;
	}

	public BigDecimal getDiscount() {
		return this.discount;
	}

	public void setDiscount(BigDecimal discount) {
		this.discount = discount;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	@Column(name = "DOCTOR_NM")
	public String getDoctorNm() {
		return this.doctorNm;
	}

	public void setDoctorNm(String doctorNm) {
		this.doctorNm = doctorNm;
	}

	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "INVOICE_DATE")
	public Date getInvoiceDate() {
		return this.invoiceDate;
	}

	public void setInvoiceDate(Date invoiceDate) {
		this.invoiceDate = invoiceDate;
	}

	@Column(name = "PAID_NAME")
	public String getPaidName() {
		return this.paidName;
	}

	public void setPaidName(String paidName) {
		this.paidName = paidName;
	}

	@Column(name = "PATIENT_ADDR")
	public String getPatientAddr() {
		return this.patientAddr;
	}

	public void setPatientAddr(String patientAddr) {
		this.patientAddr = patientAddr;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PATIENT_DOB")
	public Date getPatientDob() {
		return this.patientDob;
	}

	public void setPatientDob(Date patientDob) {
		this.patientDob = patientDob;
	}

	@Column(name = "PATIENT_GENDER")
	public String getPatientGender() {
		return this.patientGender;
	}

	public void setPatientGender(String patientGender) {
		this.patientGender = patientGender;
	}

	@Column(name = "PATIENT_GRP")
	public String getPatientGrp() {
		return this.patientGrp;
	}

	public void setPatientGrp(String patientGrp) {
		this.patientGrp = patientGrp;
	}

	@Column(name = "PATIENT_GRP_NM")
	public String getPatientGrpNm() {
		return this.patientGrpNm;
	}

	public void setPatientGrpNm(String patientGrpNm) {
		this.patientGrpNm = patientGrpNm;
	}

	@Column(name = "PATIENT_NM")
	public String getPatientNm() {
		return this.patientNm;
	}

	public void setPatientNm(String patientNm) {
		this.patientNm = patientNm;
	}

	@Column(name = "PAYMENT_CD")
	public String getPaymentCd() {
		return this.paymentCd;
	}

	public void setPaymentCd(String paymentCd) {
		this.paymentCd = paymentCd;
	}

	@Column(name = "PAYMENT_NM")
	public String getPaymentNm() {
		return this.paymentNm;
	}

	public void setPaymentNm(String paymentNm) {
		this.paymentNm = paymentNm;
	}

	@Column(name = "STATUS_FLG")
	public BigDecimal getStatusFlg() {
		return this.statusFlg;
	}

	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "VISIT_DATE")
	public Date getVisitDate() {
		return this.visitDate;
	}

	public void setVisitDate(Date visitDate) {
		this.visitDate = visitDate;
	}

	@Column(name = "REVERT_TYPE")
	public String getRevertType() {
		return revertType;
	}

	public void setRevertType(String revertType) {
		this.revertType = revertType;
	}

	@Column(name = "REVERT_COMMENT")
	public String getRevertComment() {
		return revertComment;
	}

	public void setRevertComment(String revertComment) {
		this.revertComment = revertComment;
	}

	@Column(name = "PATIENT_TEL")
	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}

	@Column(name = "PATIENT_MOBILE")
	public String getPatientMobile() {
		return patientMobile;
	}

	public void setPatientMobile(String patientMobile) {
		this.patientMobile = patientMobile;
	}

	@Column(name = "DISCOUNT_COMMENT")
	public String getDiscountComment() {
		return discountComment;
	}

	public void setDiscountComment(String discountComment) {
		this.discountComment = discountComment;
	}

	@Column(name = "DISCOUNT_TYPE")
	public String getDiscountType() {
		return discountType;
	}

	public void setDiscountType(String discountType) {
		this.discountType = discountType;
	}
	
	@Column(name = "AMOUNT_PAID")
	public BigDecimal getAmountPaid() {
		return amountPaid;
	}

	public void setAmountPaid(BigDecimal amountPaid) {
		this.amountPaid = amountPaid;
	}

	@Column(name = "AMOUNT_DEBT")
	public BigDecimal getAmountDebt() {
		return amountDebt;
	}

	public void setAmountDebt(BigDecimal amountDebt) {
		this.amountDebt = amountDebt;
	}

	@Column(name = "PARENT_INVOICE_NO")
	public String getParentInvoiceNo() {
		return parentInvoiceNo;
	}

	public void setParentInvoiceNo(String parentInvoiceNo) {
		this.parentInvoiceNo = parentInvoiceNo;
	}
	
}