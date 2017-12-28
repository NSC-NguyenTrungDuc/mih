package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientModel {

	@JsonProperty("hosp_code")
	private String hospCode;

	@JsonProperty("hosp_name")
	private String hospName;

	@JsonProperty("patient_code")
	private String patientCode;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

}
