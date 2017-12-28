package nta.med.ext.mss.model;

import javax.validation.constraints.Digits;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class PatientModel {

	@JsonProperty("patient_name") // "石川"
	private String patientName;

	@JsonProperty("disease_name") // string
	private String diseaseName;

	@JsonProperty("status") // 1
	private Integer status;

	@JsonProperty("last_go_hospital") // "20151216"
	private String lastGoHospital;

	@JsonProperty("patient_age") // number
	@Digits(integer = 6, fraction = 2)
	private Integer patientAge;

	@JsonProperty("patient_sex") // string (F or M)
	private String patientSex;
	
	@JsonProperty("patient_tel")
	private String patientTel;

	@JsonProperty("patient_email") // "example@gmail.com"
	private String patientEmail;

	@JsonProperty("status_of_disease") // %|1|2|..|7
	private String statusOfDisease;

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

	public Integer getStatus() {
		return status;
	}

	public void setStatus(Integer status) {
		this.status = status;
	}

	public String getLastGoHospital() {
		return lastGoHospital;
	}

	public void setLastGoHospital(String lastGoHospital) {
		this.lastGoHospital = lastGoHospital;
	}

	public Integer getPatientAge() {
		return patientAge;
	}

	public void setPatientAge(Integer patientAge) {
		this.patientAge = patientAge;
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

	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}

	public String getStatusOfDisease() {
		return statusOfDisease;
	}

	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}
}
