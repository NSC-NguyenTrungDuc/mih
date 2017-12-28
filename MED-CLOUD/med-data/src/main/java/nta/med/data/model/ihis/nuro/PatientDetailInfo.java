package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;

public class PatientDetailInfo {
    
	private String lastGoHospital;
	private String diseaseName;
	private String patientName;
	private String patientSex;
	private String birth;
	private BigInteger patientAge;
	private String patientEmail;
	private String patientTel;
	private String statusOfDisease;

	public PatientDetailInfo(String lastGoHospital, String diseaseName, String patientName, String patientSex,
			String birth, BigInteger patientAge, String patientEmail, String patientTel, String statusOfDisease) {
		super();
		this.lastGoHospital = lastGoHospital;
		this.diseaseName = diseaseName;
		this.patientName = patientName;
		this.patientSex = patientSex;
		this.birth = birth;
		this.patientAge = patientAge;
		this.patientEmail = patientEmail;
		this.patientTel = patientTel;
		this.statusOfDisease = statusOfDisease;
	}

	public String getLastGoHospital() {
		return lastGoHospital;
	}

	public void setLastGoHospital(String lastGoHospital) {
		this.lastGoHospital = lastGoHospital;
	}

	public String getDiseaseName() {
		return diseaseName;
	}

	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public BigInteger getPatientAge() {
		return patientAge;
	}

	public void setPatientAge(BigInteger patientAge) {
		this.patientAge = patientAge;
	}

	public String getPatientEmail() {
		return patientEmail;
	}

	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
	}

	public String getStatusOfDisease() {
		return statusOfDisease;
	}

	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}
}
