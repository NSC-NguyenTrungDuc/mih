package nta.med.data.model.ihis.nuri;

public class NUR1001R09grdINP1001Info {
	private String gwa;
	private String gwaName;
	private String bunho;
	private String suname;
	private String suname2;
	private String sex;
	private String age;
	private String birth;
	private String address;
	private String doctor;
	private String doctorName;
	private String n;
	
	public NUR1001R09grdINP1001Info(String gwa, String gwaName, String bunho, String suname, String suname2, String sex,
			String age, String birth, String address, String doctor, String doctorName, String n) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.sex = sex;
		this.age = age;
		this.birth = birth;
		this.address = address;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.n = n;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getN() {
		return n;
	}

	public void setN(String n) {
		this.n = n;
	}
	
}
