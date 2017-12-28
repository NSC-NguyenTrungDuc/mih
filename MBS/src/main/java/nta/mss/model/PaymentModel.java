package nta.mss.model;



import java.util.List;

public class PaymentModel {
	private List<OrderMedicineModel> orderMedicine;
	private PaymentInfoModel paymentInfo;
	private PaymentProcessModel paymentProcess;
	private String expireLink;

	public PaymentModel(){};

	public PaymentModel(List<OrderMedicineModel> orderMedicine, PaymentInfoModel paymentInfo,
						PaymentProcessModel paymentProcess) {
		super();
		this.orderMedicine = orderMedicine;
		this.paymentInfo = paymentInfo;
		this.paymentProcess = paymentProcess;
	}

	public List<OrderMedicineModel> getOrderMedicine() {
		return orderMedicine;
	}

	public void setOrderMedicine(List<OrderMedicineModel> orderMedicine) {
		this.orderMedicine = orderMedicine;
	}

	public PaymentInfoModel getPaymentInfo() {
		return paymentInfo;
	}
	public void setPaymentInfo(PaymentInfoModel paymentInfo) {
		this.paymentInfo = paymentInfo;
	}
	public PaymentProcessModel getPaymentProcess() {
		return paymentProcess;
	}
	public void setPaymentProcess(PaymentProcessModel paymentProcess) {
		this.paymentProcess = paymentProcess;
	}

	public String getExpireLink() {
		return expireLink;
	}

	public void setExpireLink(String expireLink) {
		this.expireLink = expireLink;
	}
}
