package nta.med.data.model.cms;

import java.security.Timestamp;
import java.util.Date;

public class CmsSurveyInfo {

	private String surveyPatientId;

	private String departmentCode;

	private String departmentName;

	private Date patientCode;

	private Timestamp patientName;

	private String surveyTitle;

	private String surveyStatus;

	public String getSurveyPatientId() {
		return surveyPatientId;
	}

	public void setSurveyPatientId(String surveyPatientId) {
		this.surveyPatientId = surveyPatientId;
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

	public Date getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(Date patientCode) {
		this.patientCode = patientCode;
	}

	public Timestamp getPatientName() {
		return patientName;
	}

	public void setPatientName(Timestamp patientName) {
		this.patientName = patientName;
	}

	public String getSurveyTitle() {
		return surveyTitle;
	}

	public void setSurveyTitle(String surveyTitle) {
		this.surveyTitle = surveyTitle;
	}

	public String getSurveyStatus() {
		return surveyStatus;
	}

	public void setSurveyStatus(String surveyStatus) {
		this.surveyStatus = surveyStatus;
	}
	
	
}
