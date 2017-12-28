package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AccountClinicKcckModel {

	
	@JsonProperty("HOSP_CODE")
	private String hospCode;

	@JsonProperty("PATIENT_CODE")
	private String patientCode;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
}
