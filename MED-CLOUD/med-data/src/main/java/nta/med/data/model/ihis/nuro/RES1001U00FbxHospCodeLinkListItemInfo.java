package nta.med.data.model.ihis.nuro;

public class RES1001U00FbxHospCodeLinkListItemInfo {
	private String hospCode;
	private String hospName;
	private String address;
	private String telephone;
	public RES1001U00FbxHospCodeLinkListItemInfo(String hospCode, String hospName, String address, String telephone) {
		super();
		this.hospCode = hospCode;
		this.hospName = hospName;
		this.address = address;
		this.telephone = telephone;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getHospName() {
		return hospName;
	}
	public void setHospName(String hospName) {
		this.hospName = hospName;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTelephone() {
		return telephone;
	}
	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}
	
}
