package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

public class LoadGridBIL2016U02Info {

	private String hangmogCode;
	private String hangmogName;
	private String unit;
	private BigDecimal price;
	private String quantity;
	private BigDecimal amount;
	private BigDecimal insurancePay;
	private BigDecimal patientPay;
	private BigDecimal discount;
	private String deptReqCd;
	private String deptReqNm;
	private String doctorReqCd;
	private String doctorReqNm;
	private String deptExcCd;
	private String deptExcNm;
	private String doctorExcCd;
	private String doctorExcNm;
	private String orderGroupCd;
	private String orderGroupNm;
	private String orderDate;
	private String actingDate;
	private String paymentName;
	private String paymentCode;
	private String paidName;
	private String discountReason;
	private Double fkocs1003;
	private BigDecimal totalDiscount;
	private String discountType;
	private String discountReasonMaster;
	private String revertType;
	private String revertComment;
	private BigDecimal amountPaid;
	private BigDecimal amountDebt;
	public LoadGridBIL2016U02Info(String hangmogCode, String hangmogName, String unit, BigDecimal price,
			String quantity, BigDecimal amount, BigDecimal insurancePay, BigDecimal patientPay, BigDecimal discount,
			String deptReqCd, String deptReqNm, String doctorReqCd, String doctorReqNm, String deptExcCd,
			String deptExcNm, String doctorExcCd, String doctorExcNm, String orderGroupCd, String orderGroupNm,
			String orderDate, String actingDate, String paymentName, String paymentCode, String paidName,
			String discountReason, Double fkocs1003, BigDecimal totalDiscount, String discountType,
			String discountReasonMaster, String revertType, String revertComment, BigDecimal amountPaid,
			BigDecimal amountDebt) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.unit = unit;
		this.price = price;
		this.quantity = quantity;
		this.amount = amount;
		this.insurancePay = insurancePay;
		this.patientPay = patientPay;
		this.discount = discount;
		this.deptReqCd = deptReqCd;
		this.deptReqNm = deptReqNm;
		this.doctorReqCd = doctorReqCd;
		this.doctorReqNm = doctorReqNm;
		this.deptExcCd = deptExcCd;
		this.deptExcNm = deptExcNm;
		this.doctorExcCd = doctorExcCd;
		this.doctorExcNm = doctorExcNm;
		this.orderGroupCd = orderGroupCd;
		this.orderGroupNm = orderGroupNm;
		this.orderDate = orderDate;
		this.actingDate = actingDate;
		this.paymentName = paymentName;
		this.paymentCode = paymentCode;
		this.paidName = paidName;
		this.discountReason = discountReason;
		this.fkocs1003 = fkocs1003;
		this.totalDiscount = totalDiscount;
		this.discountType = discountType;
		this.discountReasonMaster = discountReasonMaster;
		this.revertType = revertType;
		this.revertComment = revertComment;
		this.amountPaid = amountPaid;
		this.amountDebt = amountDebt;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getUnit() {
		return unit;
	}
	public void setUnit(String unit) {
		this.unit = unit;
	}
	public BigDecimal getPrice() {
		return price;
	}
	public void setPrice(BigDecimal price) {
		this.price = price;
	}
	public String getQuantity() {
		return quantity;
	}
	public void setQuantity(String quantity) {
		this.quantity = quantity;
	}
	public BigDecimal getAmount() {
		return amount;
	}
	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}
	public BigDecimal getInsurancePay() {
		return insurancePay;
	}
	public void setInsurancePay(BigDecimal insurancePay) {
		this.insurancePay = insurancePay;
	}
	public BigDecimal getPatientPay() {
		return patientPay;
	}
	public void setPatientPay(BigDecimal patientPay) {
		this.patientPay = patientPay;
	}
	public BigDecimal getDiscount() {
		return discount;
	}
	public void setDiscount(BigDecimal discount) {
		this.discount = discount;
	}
	public String getDeptReqCd() {
		return deptReqCd;
	}
	public void setDeptReqCd(String deptReqCd) {
		this.deptReqCd = deptReqCd;
	}
	public String getDeptReqNm() {
		return deptReqNm;
	}
	public void setDeptReqNm(String deptReqNm) {
		this.deptReqNm = deptReqNm;
	}
	public String getDoctorReqCd() {
		return doctorReqCd;
	}
	public void setDoctorReqCd(String doctorReqCd) {
		this.doctorReqCd = doctorReqCd;
	}
	public String getDoctorReqNm() {
		return doctorReqNm;
	}
	public void setDoctorReqNm(String doctorReqNm) {
		this.doctorReqNm = doctorReqNm;
	}
	public String getDeptExcCd() {
		return deptExcCd;
	}
	public void setDeptExcCd(String deptExcCd) {
		this.deptExcCd = deptExcCd;
	}
	public String getDeptExcNm() {
		return deptExcNm;
	}
	public void setDeptExcNm(String deptExcNm) {
		this.deptExcNm = deptExcNm;
	}
	public String getDoctorExcCd() {
		return doctorExcCd;
	}
	public void setDoctorExcCd(String doctorExcCd) {
		this.doctorExcCd = doctorExcCd;
	}
	public String getDoctorExcNm() {
		return doctorExcNm;
	}
	public void setDoctorExcNm(String doctorExcNm) {
		this.doctorExcNm = doctorExcNm;
	}
	public String getOrderGroupCd() {
		return orderGroupCd;
	}
	public void setOrderGroupCd(String orderGroupCd) {
		this.orderGroupCd = orderGroupCd;
	}
	public String getOrderGroupNm() {
		return orderGroupNm;
	}
	public void setOrderGroupNm(String orderGroupNm) {
		this.orderGroupNm = orderGroupNm;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getActingDate() {
		return actingDate;
	}
	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}
	public String getPaymentName() {
		return paymentName;
	}
	public void setPaymentName(String paymentName) {
		this.paymentName = paymentName;
	}
	public String getPaymentCode() {
		return paymentCode;
	}
	public void setPaymentCode(String paymentCode) {
		this.paymentCode = paymentCode;
	}
	public String getPaidName() {
		return paidName;
	}
	public void setPaidName(String paidName) {
		this.paidName = paidName;
	}
	public String getDiscountReason() {
		return discountReason;
	}
	public void setDiscountReason(String discountReason) {
		this.discountReason = discountReason;
	}
	public Double getFkocs1003() {
		return fkocs1003;
	}
	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}
	public BigDecimal getTotalDiscount() {
		return totalDiscount;
	}
	public void setTotalDiscount(BigDecimal totalDiscount) {
		this.totalDiscount = totalDiscount;
	}
	public String getDiscountType() {
		return discountType;
	}
	public void setDiscountType(String discountType) {
		this.discountType = discountType;
	}
	public String getDiscountReasonMaster() {
		return discountReasonMaster;
	}
	public void setDiscountReasonMaster(String discountReasonMaster) {
		this.discountReasonMaster = discountReasonMaster;
	}
	public String getRevertType() {
		return revertType;
	}
	public void setRevertType(String revertType) {
		this.revertType = revertType;
	}
	public String getRevertComment() {
		return revertComment;
	}
	public void setRevertComment(String revertComment) {
		this.revertComment = revertComment;
	}
	public BigDecimal getAmountPaid() {
		return amountPaid;
	}
	public void setAmountPaid(BigDecimal amountPaid) {
		this.amountPaid = amountPaid;
	}
	public BigDecimal getAmountDebt() {
		return amountDebt;
	}
	public void setAmountDebt(BigDecimal amountDebt) {
		this.amountDebt = amountDebt;
	}
	
}
