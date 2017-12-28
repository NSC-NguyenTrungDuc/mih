package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;

public class BIL2016R01GrdReportPaidDisCountInfo {
	BigDecimal totalPaid;
	BigDecimal totalDiscount;
	public BIL2016R01GrdReportPaidDisCountInfo(BigDecimal totalPaid, BigDecimal totalDiscount) {
		super();
		this.totalPaid = totalPaid;
		this.totalDiscount = totalDiscount;
	}
	public BigDecimal getTotalPaid() {
		return totalPaid;
	}
	public void setTotalPaid(BigDecimal totalPaid) {
		this.totalPaid = totalPaid;
	}
	public BigDecimal getTotalDiscount() {
		return totalDiscount;
	}
	public void setTotalDiscount(BigDecimal totalDiscount) {
		this.totalDiscount = totalDiscount;
	}
}
