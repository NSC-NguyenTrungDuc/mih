package nta.kcck.model;

public class KcckOrderMedicineModel {
	private String hangmog_name;
	private String hangmog_code;
	private String code_name;
	private String price;
	private String quantity;
	private String cal_price;

	public KcckOrderMedicineModel(String hangmog_name, String hangmog_code, String code_name, String price, String quantity, String cal_price) {
		this.hangmog_name = hangmog_name;
		this.hangmog_code = hangmog_code;
		this.code_name = code_name;
		this.price = price;
		this.quantity = quantity;
		this.cal_price = cal_price;
	}

	public String getHangmog_name() {
		return hangmog_name;
	}

	public void setHangmog_name(String hangmog_name) {
		this.hangmog_name = hangmog_name;
	}

	public String getHangmog_code() {
		return hangmog_code;
	}

	public void setHangmog_code(String hangmog_code) {
		this.hangmog_code = hangmog_code;
	}

	public String getCode_name() {
		return code_name;
	}

	public void setCode_name(String code_name) {
		this.code_name = code_name;
	}

	public String getPrice() {
		return price;
	}

	public void setPrice(String price) {
		this.price = price;
	}

	public String getQuantity() {
		return quantity;
	}

	public void setQuantity(String quantity) {
		this.quantity = quantity;
	}

	public String getCal_price() {
		return cal_price;
	}

	public void setCal_price(String cal_price) {
		this.cal_price = cal_price;
	}
}
