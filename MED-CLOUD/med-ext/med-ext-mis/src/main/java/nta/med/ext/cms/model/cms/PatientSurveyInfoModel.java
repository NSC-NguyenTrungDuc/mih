package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientSurveyInfoModel {

	@JsonProperty("hosp_code")
	private String hospCode;

	@JsonProperty("patient_code")
	private String patientCode;

	@JsonProperty("patient_survey_id")
	private String id;

	@JsonProperty("agreement_flg")
	private BigDecimal agreementFlg;

	@JsonProperty("question_group")
	private PatientSurveyStore patientSurvey = new PatientSurveyStore();

	@JsonIgnore
	private String error;
	
	@JsonProperty("token")
	private String token;

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

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public PatientSurveyStore getPatientSurvey() {
		return patientSurvey;
	}

	public void setPatientSurvey(PatientSurveyStore patientSurvey) {
		this.patientSurvey = patientSurvey;
	}

	public String getError() {
		return error;
	}

	public void setError(String error) {
		this.error = error;
	}

	public BigDecimal getAgreementFlg() {
		return agreementFlg;
	}

	public void setAgreementFlg(BigDecimal agreementFlg) {
		this.agreementFlg = agreementFlg;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}
	
}
