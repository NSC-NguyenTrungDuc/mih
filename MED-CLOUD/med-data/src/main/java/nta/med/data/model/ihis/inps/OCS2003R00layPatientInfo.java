package nta.med.data.model.ihis.inps;

public class OCS2003R00layPatientInfo {
	private String bunho ;
	private String suname ;
	private String suname2 ;
	private String birth ;
	private String sexAge ;
	private String doctor ;
	private String doctorName;
	private String gwa ;
	private String gwaName ;
	private String orderDate ;
	private String inputGubun ;
	public OCS2003R00layPatientInfo(String bunho, String suname, String suname2, String birth, String sexAge,
			String doctor, String doctorName, String gwa, String gwaName, String orderDate, String inputGubun) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.sexAge = sexAge;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.orderDate = orderDate;
		this.inputGubun = inputGubun;
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
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getSexAge() {
		return sexAge;
	}
	public void setSexAge(String sexAge) {
		this.sexAge = sexAge;
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
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getInputGubun() {
		return inputGubun;
	}
	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

}
