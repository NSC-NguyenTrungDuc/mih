package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;


/**
 * The persistent class for the PHR_STANDARD_PROGRESS database table.
 * 
 */

public class StandardProgressDetailModel {

	@JsonProperty("content")
	private String content;

	@JsonProperty("version")
	private String version;

	@JsonProperty("patient_code")
	private String patientCode;

	@JsonProperty("hosp_name")
	private String hospName;

	@JsonProperty("hosp_code")
	private String hospCode;

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getVersion() {
		return version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
}