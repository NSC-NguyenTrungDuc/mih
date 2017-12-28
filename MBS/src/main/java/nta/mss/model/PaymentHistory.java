package nta.mss.model;

import java.math.BigDecimal;

public class PaymentHistory {

	private String transactionIdShort;
    private String transactionId;
    private String transactionDateTime;
    private BigDecimal amount;
    private String orderId;
    private String examDate;
    private String invoiceNo;
    private String paymentDateTime;
    private String status;
    private String valueStatus;
    private String statusName;
    private String link;
    private String patientCode;
    private String patientName;
    private String fkOut;
  
    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public BigDecimal getAmount() {
        return amount;
    }

    public void setAmount(BigDecimal amount) {
        this.amount = amount;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public String getExamDate() {
        return examDate;
    }

    public void setExamDate(String examDate) {
        this.examDate = examDate;
    }

    public String getInvoiceNo() {
        return invoiceNo;
    }

    public void setInvoiceNo(String invoiceNo) {
        this.invoiceNo = invoiceNo;
    }
  
    public String getTransactionDateTime() {
		return transactionDateTime;
	}

	public void setTransactionDateTime(String transactionDateTime) {
		this.transactionDateTime = transactionDateTime;
	}

	public String getPaymentDateTime() {
		return paymentDateTime;
	}

	public void setPaymentDateTime(String paymentDateTime) {
		this.paymentDateTime = paymentDateTime;
	}

	public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getLink() {
        return link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public String getPatientCode() {
        return patientCode;
    }

    public String getPatientName() {
        return patientName;
    }

    public void setPatientName(String patientName) {
        this.patientName = patientName;
    }

    public void setPatientCode(String patientCode) {
        this.patientCode = patientCode;
    }

	public String getFkOut() {
		return fkOut;
	}

	public void setFkOut(String fkOut) {
		this.fkOut = fkOut;
	}

    public String getStatusName() {
        return statusName;
    }

    public void setStatusName(String statusName) {
        this.statusName = statusName;
    }

    public String getValueStatus() {
        return valueStatus;
    }

    public void setValueStatus(String valueStatus) {
        this.valueStatus = valueStatus;
    }

	public String getTransactionIdShort() {
		return transactionIdShort;
	}

	public void setTransactionIdShort(String transactionIdShort) {
		this.transactionIdShort = transactionIdShort;
	}
    
}
