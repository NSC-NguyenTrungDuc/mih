package nta.mss.model;

public class SearchPaymentTransaction {

	private String payment_date_from;
    private String payment_date_end;
    private String invoice_no ;
    private String exam_date_from;
    private String exam_date_end;
    private String transaction_id ;
    private String amount_from ;
    private String amount_end ;
    private String status ;
    private String patient_code ;
    private String page_number ;
    private String offset ;
    private String sort_column_name;
    private String hosp_code;
    
    public SearchPaymentTransaction(){  	
    }
	public SearchPaymentTransaction(String paymentDateFrom, String paymentDateEnd, String invoiceNo,
									String examDateFrom, String examDateEnd, String transactionId, String amountFrom, String amountEnd,
									String status, String patientCode, String pageNumber, String offset,String sort_column_name, String hosp_code) {
		super();
		this.payment_date_from = paymentDateFrom;
		this.payment_date_end = paymentDateEnd;
		this.invoice_no = invoiceNo;
		this.exam_date_from = examDateFrom;
		this.exam_date_end = examDateEnd;
		this.transaction_id = transactionId;
		this.amount_from = amountFrom;
		this.amount_end = amountEnd;
		this.status = status;
		this.patient_code = patientCode;
		this.page_number = pageNumber;
		this.offset = offset;
		this.sort_column_name = sort_column_name;
		this.hosp_code = hosp_code;
	}
	public String getPayment_date_from() {
		return payment_date_from;
	}
	public void setPayment_date_from(String payment_date_from) {
		this.payment_date_from = payment_date_from;
	}
	public String getPayment_date_end() {
		return payment_date_end;
	}
	public void setPayment_date_end(String payment_date_end) {
		this.payment_date_end = payment_date_end;
	}

	public String getInvoice_no() {
		return invoice_no;
	}

	public void setInvoice_no(String invoice_no) {
		this.invoice_no = invoice_no;
	}

	public String getExam_date_from() {
		return exam_date_from;
	}
	public void setExam_date_from(String exam_date_from) {
		this.exam_date_from = exam_date_from;
	}
	public String getExam_date_end() {
		return exam_date_end;
	}
	public void setExam_date_end(String exam_date_end) {
		this.exam_date_end = exam_date_end;
	}

	public String getTransaction_id() {
		return transaction_id;
	}

	public void setTransaction_id(String transaction_id) {
		this.transaction_id = transaction_id;
	}

	public String getAmount_from() {
		return amount_from;
	}

	public void setAmount_from(String amount_from) {
		this.amount_from = amount_from;
	}

	public String getAmount_end() {
		return amount_end;
	}

	public void setAmount_end(String amount_end) {
		this.amount_end = amount_end;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getPatient_code() {
		return patient_code;
	}

	public void setPatient_code(String patient_code) {
		this.patient_code = patient_code;
	}

	public String getPage_number() {
		return page_number;
	}

	public void setPage_number(String page_number) {
		this.page_number = page_number;
	}

	public String getOffset() {
		return offset;
	}
	public void setOffset(String offset) {
		this.offset = offset;
	}
	public String getHosp_code() {
		return hosp_code;
	}
	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}
	public String getSort_column_name() {
		return sort_column_name;
	}
	public void setSort_column_name(String sort_column_name) {
		this.sort_column_name = sort_column_name;
	}    
}
