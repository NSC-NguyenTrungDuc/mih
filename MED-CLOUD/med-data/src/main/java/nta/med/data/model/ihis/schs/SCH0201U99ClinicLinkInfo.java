package nta.med.data.model.ihis.schs;

public class SCH0201U99ClinicLinkInfo {
	private String yoyangName;
	private String tel;
	private String address;
	
	public SCH0201U99ClinicLinkInfo(String yoyangName, String tel, String address) {
		super();
		this.yoyangName = yoyangName;
		this.tel = tel;
		this.address = address;
	}
	
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
}
