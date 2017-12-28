package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

public class BIL2016U02PrintAmountInfo {
	BigDecimal amount;
	BigDecimal amountPaid;
	BigDecimal totalAmountPaid;
	BigDecimal amountDebt;
	public BIL2016U02PrintAmountInfo(BigDecimal amount, BigDecimal amountPaid, BigDecimal totalAmountPaid,
			BigDecimal amountDebt) {
		super();
		this.amount = amount;
		this.amountPaid = amountPaid;
		this.totalAmountPaid = totalAmountPaid;
		this.amountDebt = amountDebt;
	}
	public BigDecimal getAmount() {
		return amount;
	}
	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}
	public BigDecimal getAmountPaid() {
		return amountPaid;
	}
	public void setAmountPaid(BigDecimal amountPaid) {
		this.amountPaid = amountPaid;
	}
	public BigDecimal getTotalAmountPaid() {
		return totalAmountPaid;
	}
	public void setTotalAmountPaid(BigDecimal totalAmountPaid) {
		this.totalAmountPaid = totalAmountPaid;
	}
	public BigDecimal getAmountDebt() {
		return amountDebt;
	}
	public void setAmountDebt(BigDecimal amountDebt) {
		this.amountDebt = amountDebt;
	}
	
}
