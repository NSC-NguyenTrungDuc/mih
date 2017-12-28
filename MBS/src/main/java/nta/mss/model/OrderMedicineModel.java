package nta.mss.model;

public class OrderMedicineModel {
	private String hangmogName;
	private String hangmogCode;
	private String codeName;
	private String price;
	private String quantity;
	private String calPrice;

	public OrderMedicineModel() {
	}

	public OrderMedicineModel(String hangmogName, String hangmogCode, String codeName, String price,
								  String quantity, String calPrice) {
		super();
		this.hangmogName = hangmogName;
		this.hangmogCode = hangmogCode;
		this.codeName = codeName;
		this.price = price;
		this.quantity = quantity;
		this.calPrice = calPrice;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
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
	public String getCalPrice() {
		return calPrice;
	}
	public void setCalPrice(String calPrice) {
		this.calPrice = calPrice;
	}

}	
