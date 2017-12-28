package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

public class LoadGridBIL2016U02SumInfo {
	BigDecimal sumAmount;
	BigDecimal sumDiscount;
	BigDecimal sumAmountPaid;
	BigDecimal sumAmountDept;
	public LoadGridBIL2016U02SumInfo(BigDecimal sumAmount, BigDecimal sumDiscount, BigDecimal sumAmountPaid,
			BigDecimal sumAmountDept) {
		super();
		this.sumAmount = sumAmount;
		this.sumDiscount = sumDiscount;
		this.sumAmountPaid = sumAmountPaid;
		this.sumAmountDept = sumAmountDept;
	}
	public BigDecimal getSumAmount() {
		return sumAmount;
	}
	public void setSumAmount(BigDecimal sumAmount) {
		this.sumAmount = sumAmount;
	}
	public BigDecimal getSumDiscount() {
		return sumDiscount;
	}
	public void setSumDiscount(BigDecimal sumDiscount) {
		this.sumDiscount = sumDiscount;
	}
	public BigDecimal getSumAmountPaid() {
		return sumAmountPaid;
	}
	public void setSumAmountPaid(BigDecimal sumAmountPaid) {
		this.sumAmountPaid = sumAmountPaid;
	}
	public BigDecimal getSumAmountDept() {
		return sumAmountDept;
	}
	public void setSumAmountDept(BigDecimal sumAmountDept) {
		this.sumAmountDept = sumAmountDept;
	}
	
}
