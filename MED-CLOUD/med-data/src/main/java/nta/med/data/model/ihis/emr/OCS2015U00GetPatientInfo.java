package nta.med.data.model.ihis.emr;

public class OCS2015U00GetPatientInfo {
	private String suname;
	private String birth;
	private String sex;
	private String address;
	private String tel;
	public OCS2015U00GetPatientInfo(String suname, String birth, String sex, String address, String tel) {
		super();
		this.suname = suname;
		this.birth = birth;
		this.sex = sex;
		this.address = address;
		this.tel = tel;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
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
