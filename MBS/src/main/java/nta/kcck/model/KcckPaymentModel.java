package nta.kcck.model;

import java.util.List;

public class KcckPaymentModel {
	private List<KcckOrderMedicineModel> order_medicine;
	private KcckPaymentInfoModel payment_info ;
	private KcckPaymentProcessModel payment_process;
	private String expire_link;
	public KcckPaymentModel(){};

	public KcckPaymentModel(List<KcckOrderMedicineModel> order_medicine, KcckPaymentInfoModel payment_info, KcckPaymentProcessModel payment_process) {
		this.order_medicine = order_medicine;
		this.payment_info = payment_info;
		this.payment_process = payment_process;
	}

	public List<KcckOrderMedicineModel> getOrder_medicine() {
		return order_medicine;
	}

	public void setOrder_medicine(List<KcckOrderMedicineModel> order_medicine) {
		this.order_medicine = order_medicine;
	}

	public KcckPaymentInfoModel getPayment_info() {
		return payment_info;
	}

	public void setPayment_info(KcckPaymentInfoModel payment_info) {
		this.payment_info = payment_info;
	}

	public KcckPaymentProcessModel getPayment_process() {
		return payment_process;
	}

	public void setPayment_process(KcckPaymentProcessModel payment_process) {
		this.payment_process = payment_process;
	}

	public String getExpire_link() {
		return expire_link;
	}

	public void setExpire_link(String expire_link) {
		this.expire_link = expire_link;
	}
}
