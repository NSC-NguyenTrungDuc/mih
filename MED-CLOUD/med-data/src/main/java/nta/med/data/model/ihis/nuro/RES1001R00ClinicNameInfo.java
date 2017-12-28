package nta.med.data.model.ihis.nuro;

public class RES1001R00ClinicNameInfo {
	private String yoyngName;
	private String address;
	private String tel;
	public RES1001R00ClinicNameInfo(String yoyngName, String address, String tel) {
		super();
		this.yoyngName = yoyngName;
		this.address = address;
		this.tel = tel;
	}
	public String getYoyngName() {
		return yoyngName;
	}
	public void setYoyngName(String yoyngName) {
		this.yoyngName = yoyngName;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	
}
