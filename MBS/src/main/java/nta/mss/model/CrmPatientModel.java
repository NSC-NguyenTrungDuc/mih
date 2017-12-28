package nta.mss.model;

public class CrmPatientModel {

	private String patientName;
	private String diseaseName;
	private String statusOfDisease;
	private String patientSex;
	private String patientEmail;
	private String patientTel;
	private String lastestGoHospital;
	private Integer PatientAge;

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getDiseaseName() {
		return diseaseName;
	}

	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}

	public String getStatusOfDisease() {
		return statusOfDisease;
	}

	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public String getPatientEmail() {
		return patientEmail;
	}

	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
	}

	public String getLastestGoHospital() {
		return lastestGoHospital;
	}

	public void setLastestGoHospital(String lastestGoHospital) {
		this.lastestGoHospital = lastestGoHospital;
	}

	public Integer getPatientAge() {
		return PatientAge;
	}

	public void setPatientAge(Integer patientAge) {
		PatientAge = patientAge;
	}
	
	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}

	@Override
	public String toString() {
		return "CrmPatientModel [patientName=" + patientName + ", diseaseName=" + diseaseName + ", statusOfDisease="
				+ statusOfDisease + ", patientSex=" + patientSex + ", patientEmail=" + patientEmail + ", patientTel="
				+ patientTel + ", lastestGoHospital=" + lastestGoHospital + ", PatientAge=" + PatientAge + "]";
	}

	
}
