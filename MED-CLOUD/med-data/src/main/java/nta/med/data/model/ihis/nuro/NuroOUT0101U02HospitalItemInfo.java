package nta.med.data.model.ihis.nuro;

public class NuroOUT0101U02HospitalItemInfo {
	private String yoyangName;
	private String address;
	private String tel;
	private String password;
	private String patientName;

	public NuroOUT0101U02HospitalItemInfo(String yoyangName, String address, String tel, String password, String patientName) {
		super();
		this.yoyangName = yoyangName;
		this.address = address;
		this.tel = tel;
		this.password = password;
		this.patientName = patientName;
	}

	public String getYoyangName() {
		return yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
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

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
}
