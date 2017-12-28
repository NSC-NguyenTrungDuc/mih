package nta.med.data.model.ihis.invs;

public class CheckRemainingInventoryInfo {
	private String hangmogCode;
	private String hangmogName;
	private Double  jaeryoQty;
	private Double reverveQty;
	public CheckRemainingInventoryInfo(String hangmogCode, String hangmogName, Double jaeryoQty, Double reverveQty) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.jaeryoQty = jaeryoQty;
		this.reverveQty = reverveQty;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getJaeryoQty() {
		return jaeryoQty;
	}
	public void setJaeryoQty(Double jaeryoQty) {
		this.jaeryoQty = jaeryoQty;
	}
	public Double getReverveQty() {
		return reverveQty;
	}
	public void setReverveQty(Double reverveQty) {
		this.reverveQty = reverveQty;
	}
	
}
