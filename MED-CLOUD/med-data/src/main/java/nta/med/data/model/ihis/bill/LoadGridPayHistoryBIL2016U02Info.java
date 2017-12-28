package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class LoadGridPayHistoryBIL2016U02Info {
	private String invoiceNo         ;
	private Timestamp invoiceDate       ;        
	private BigDecimal amount             ;
	private BigDecimal discount           ;
	private BigDecimal amountPaid        ;
	private String parentInvoiceNo  ;                
	private String activeFlg         ;
	private BigDecimal amountDebt        ;
	public LoadGridPayHistoryBIL2016U02Info(String invoiceNo, Timestamp invoiceDate, BigDecimal amount, BigDecimal discount,
			BigDecimal amountPaid, String parentInvoiceNo, String activeFlg, BigDecimal amountDebt) {
		super();
		this.invoiceNo = invoiceNo;
		this.invoiceDate = invoiceDate;
		this.amount = amount;
		this.discount = discount;
		this.amountPaid = amountPaid;
		this.parentInvoiceNo = parentInvoiceNo;
		this.activeFlg = activeFlg;
		this.amountDebt = amountDebt;
	}
	public String getInvoiceNo() {
		return invoiceNo;
	}
	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}
	public Timestamp getInvoiceDate() {
		return invoiceDate;
	}
	public void setInvoiceDate(Timestamp invoiceDate) {
		this.invoiceDate = invoiceDate;
	}
	public BigDecimal getAmount() {
		return amount;
	}
	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}
	public BigDecimal getDiscount() {
		return discount;
	}
	public void setDiscount(BigDecimal discount) {
		this.discount = discount;
	}
	public BigDecimal getAmountPaid() {
		return amountPaid;
	}
	public void setAmountPaid(BigDecimal amountPaid) {
		this.amountPaid = amountPaid;
	}
	public String getParentInvoiceNo() {
		return parentInvoiceNo;
	}
	public void setParentInvoiceNo(String parentInvoiceNo) {
		this.parentInvoiceNo = parentInvoiceNo;
	}
	public String getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(String activeFlg) {
		this.activeFlg = activeFlg;
	}
	public BigDecimal getAmountDebt() {
		return amountDebt;
	}
	public void setAmountDebt(BigDecimal amountDebt) {
		this.amountDebt = amountDebt;
	}

}
