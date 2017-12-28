package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PhrAccountModel {
	@JsonProperty("patien_id")
	private String patientCode;
	@JsonProperty("hosp_code")
	private String hospCode;
	@JsonProperty("password")
	private String patientPwd;
	@JsonProperty("patient_name")
	private String patientName;
	@JsonProperty("answer_date")
	private String answerDate;

	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getPatientPwd() {
		return patientPwd;
	}
	public void setPatientPwd(String patientPwd) {
		this.patientPwd = patientPwd;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getAnswerDate() {
		return answerDate;
	}

	public void setAnswerDate(String answerDate) {
		this.answerDate = answerDate;
	}
}
