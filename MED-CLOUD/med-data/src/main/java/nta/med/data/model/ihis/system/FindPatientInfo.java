package nta.med.data.model.ihis.system;

import java.sql.Timestamp;

public class FindPatientInfo {
	private String patientCode;
    private String patientName;
    private String patientName2;
    private String sex;
    private Timestamp birth;
    private Timestamp lastCommingDate;
    private String address;
    private String ipwonYn;
    private String treatmentArea;
    private String tel;
	
	public FindPatientInfo(String patientCode, String patientName,
			String patientName2, String sex, Timestamp birth,
			Timestamp lastCommingDate, String address, String ipwonYn,
			String treatmentArea, String tel) {
		super();
		this.patientCode = patientCode;
		this.patientName = patientName;
		this.patientName2 = patientName2;
		this.sex = sex;
		this.birth = birth;
		this.lastCommingDate = lastCommingDate;
		this.address = address;
		this.ipwonYn = ipwonYn;
		this.treatmentArea = treatmentArea;
		this.tel = tel;
	}
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getPatientName2() {
		return patientName2;
	}
	public void setPatientName2(String patientName2) {
		this.patientName2 = patientName2;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Timestamp getBirth() {
		return birth;
	}
	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}
	public Timestamp getLastCommingDate() {
		return lastCommingDate;
	}
	public void setLastCommingDate(Timestamp lastCommingDate) {
		this.lastCommingDate = lastCommingDate;
	}
	public String getIpwonYn() {
		return ipwonYn;
	}
	public void setIpwonYn(String ipwonYn) {
		this.ipwonYn = ipwonYn;
	}
	public String getTreatmentArea() {
		return treatmentArea;
	}
	public void setTreatmentArea(String treatmentArea) {
		this.treatmentArea = treatmentArea;
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
