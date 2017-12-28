package nta.med.ext.cms.model.cms;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientSurveyBaseModel {

	@JsonProperty("survey_id")
	private BigInteger surveyId;

	@JsonProperty("patient_code")
	private String patientCode;

	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;

	public BigInteger getSurveyId() {
		return surveyId;
	}

	public void setSurveyId(BigInteger surveyId) {
		this.surveyId = surveyId;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	@Override
	public String toString() {
		return "PatientSurveyBaseModel [surveyId=" + surveyId + ", patientCode=" + patientCode + ", departmentCode="
				+ departmentCode + ", departmentName=" + departmentName + "]";
	}
}
