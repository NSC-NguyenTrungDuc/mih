package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;

public class DOC4003U00GetHospInfo implements Serializable {
	private String zipCode;
	private String address;
	private String tel;
	private String yoyangName;
	public DOC4003U00GetHospInfo(String zipCode, String address, String tel,
			String yoyangName) {
		this.zipCode = zipCode;
		this.address = address;
		this.tel = tel;
		this.yoyangName = yoyangName;
	}
	public String getZipCode() {
		return zipCode;
	}
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
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
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
}
