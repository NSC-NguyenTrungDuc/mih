package nta.med.core.domain.bill;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the BIL0102 database table.
 * 
 */
@Entity
// @NamedQuery(name="Bil0102.findAll", query="SELECT b FROM Bil0102 b")
@Table(name = "BIL0102")
public class Bil0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private BigDecimal activeFlg;
	private BigDecimal amount;
	private String bunho;
	private Date created;
	private String deptExcCd;
	private String deptExcNm;
	private String deptReqCd;
	private String deptReqNm;
	private BigDecimal discount;
	private String doctorExc;
	private String doctorExcNm;
	private String doctorReq;
	private String doctorReqNm;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private BigDecimal insurancePay;
	private String invoiceNo;
	private Date orderDate;
	private String orderGrp;
	private String orderGrpNm;
	private BigDecimal otherPay;
	private BigDecimal patientPay;
	private BigDecimal price;
	private String quantity;
	private String sysId;
	private String unit;
	private String updId;
	private Date updated;
	private String discountReason;
	private String orderSubGrp;
	private String orderSubGrpNm;
	private Double fkocs1003;
	
	public Bil0102() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
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

	@Temporal(TemporalType.TIMESTAMP)
	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	@Column(name = "DEPT_EXC_CD")
	public String getDeptExcCd() {
		return this.deptExcCd;
	}

	public void setDeptExcCd(String deptExcCd) {
		this.deptExcCd = deptExcCd;
	}

	@Column(name = "DEPT_EXC_NM")
	public String getDeptExcNm() {
		return this.deptExcNm;
	}

	public void setDeptExcNm(String deptExcNm) {
		this.deptExcNm = deptExcNm;
	}

	@Column(name = "DEPT_REQ_CD")
	public String getDeptReqCd() {
		return this.deptReqCd;
	}

	public void setDeptReqCd(String deptReqCd) {
		this.deptReqCd = deptReqCd;
	}

	@Column(name = "DEPT_REQ_NM")
	public String getDeptReqNm() {
		return this.deptReqNm;
	}

	public void setDeptReqNm(String deptReqNm) {
		this.deptReqNm = deptReqNm;
	}

	public BigDecimal getDiscount() {
		return this.discount;
	}

	public void setDiscount(BigDecimal discount) {
		this.discount = discount;
	}

	@Column(name = "DOCTOR_EXC")
	public String getDoctorExc() {
		return this.doctorExc;
	}

	public void setDoctorExc(String doctorExc) {
		this.doctorExc = doctorExc;
	}

	@Column(name = "DOCTOR_EXC_NM")
	public String getDoctorExcNm() {
		return this.doctorExcNm;
	}

	public void setDoctorExcNm(String doctorExcNm) {
		this.doctorExcNm = doctorExcNm;
	}

	@Column(name = "DOCTOR_REQ")
	public String getDoctorReq() {
		return this.doctorReq;
	}

	public void setDoctorReq(String doctorReq) {
		this.doctorReq = doctorReq;
	}

	@Column(name = "DOCTOR_REQ_NM")
	public String getDoctorReqNm() {
		return this.doctorReqNm;
	}

	public void setDoctorReqNm(String doctorReqNm) {
		this.doctorReqNm = doctorReqNm;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INSURANCE_PAY")
	public BigDecimal getInsurancePay() {
		return this.insurancePay;
	}

	public void setInsurancePay(BigDecimal insurancePay) {
		this.insurancePay = insurancePay;
	}

	@Column(name = "INVOICE_NO")
	public String getInvoiceNo() {
		return this.invoiceNo;
	}

	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name = "ORDER_GRP")
	public String getOrderGrp() {
		return this.orderGrp;
	}

	public void setOrderGrp(String orderGrp) {
		this.orderGrp = orderGrp;
	}

	@Column(name = "ORDER_GRP_NM")
	public String getOrderGrpNm() {
		return this.orderGrpNm;
	}

	public void setOrderGrpNm(String orderGrpNm) {
		this.orderGrpNm = orderGrpNm;
	}

	@Column(name = "OTHER_PAY")
	public BigDecimal getOtherPay() {
		return this.otherPay;
	}

	public void setOtherPay(BigDecimal otherPay) {
		this.otherPay = otherPay;
	}

	@Column(name = "PATIENT_PAY")
	public BigDecimal getPatientPay() {
		return this.patientPay;
	}

	public void setPatientPay(BigDecimal patientPay) {
		this.patientPay = patientPay;
	}

	public BigDecimal getPrice() {
		return this.price;
	}

	public void setPrice(BigDecimal price) {
		this.price = price;
	}

	public String getQuantity() {
		return this.quantity;
	}

	public void setQuantity(String quantity) {
		this.quantity = quantity;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUnit() {
		return this.unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
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

	@Column(name = "DISCOUNT_REASON")
	public String getDiscountReason() {
		return discountReason;
	}

	public void setDiscountReason(String discountReason) {
		this.discountReason = discountReason;
	}

	@Column(name = "ORDER_SUB_GRP")
	public String getOrderSubGrp() {
		return orderSubGrp;
	}

	public void setOrderSubGrp(String orderSubGrp) {
		this.orderSubGrp = orderSubGrp;
	}

	@Column(name = "ORDER_SUB_GRP_NM")
	public String getOrderSubGrpNm() {
		return orderSubGrpNm;
	}

	public void setOrderSubGrpNm(String orderSubGrpNm) {
		this.orderSubGrpNm = orderSubGrpNm;
	}
	@Column(name = "FKOCS1003")
	public Double getFkocs1003() {
		return fkocs1003;
	}

	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}
	
}