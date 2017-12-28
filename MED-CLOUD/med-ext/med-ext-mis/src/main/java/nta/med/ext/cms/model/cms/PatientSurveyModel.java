/**
 * 
 */
package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author admin
 *
 */
public class PatientSurveyModel {

	@JsonProperty("survey_patient_id")
	private BigInteger surveyPatientId;

	@JsonProperty("patient_code")
	private String patientCode;

	@JsonProperty("patient_name")
	private String patientName;

	@JsonProperty("reservation_date")
	private String reservationDate;

	@JsonProperty("reservation_time")
	private String reservationTime;

	@JsonProperty("answer_date")
	private Timestamp answerDate;

	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;

	@JsonProperty("survey_title")
	private String title;

	@JsonProperty("survey_status")
	private BigDecimal statusFlg;

	@JsonProperty("survey_information")
	private SurveyInfoModel surveyInfoModel;

	@JsonProperty("search")
	private String search;

	@JsonProperty("patient")
	private String patientText;

	@JsonProperty("type")
	private Integer searchType;

	@JsonProperty("reservation_from")
	private String reservationFrom;

	@JsonProperty("reservation_to")
	private String reservationTo;
	
	@JsonProperty("survey_id")
	private BigInteger surveyId;

	@JsonIgnore
	private boolean result;

	@JsonIgnore
	private String error;

	public BigInteger getSurveyPatientId() {
		return surveyPatientId;
	}

	public void setSurveyPatientId(BigInteger surveyPatientId) {
		this.surveyPatientId = surveyPatientId;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getReservationDate() {
		return reservationDate;
	}

	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public Timestamp getAnswerDate() {
		return answerDate;
	}

	public void setAnswerDate(Timestamp answerDate) {
		this.answerDate = answerDate;
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

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public BigDecimal getStatusFlg() {
		return statusFlg;
	}

	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}

	public SurveyInfoModel getSurveyInfoModel() {
		return surveyInfoModel;
	}

	public void setSurveyInfoModel(SurveyInfoModel surveyInfoModel) {
		this.surveyInfoModel = surveyInfoModel;
	}

	public String getSearch() {
		return search;
	}

	public void setSearch(String search) {
		this.search = search;
	}

	public boolean isResult() {
		return result;
	}

	public void setResult(boolean result) {
		this.result = result;
	}

	public String getError() {
		return error;
	}

	public void setError(String error) {
		this.error = error;
	}

	public String getPatientText() {
		return patientText;
	}

	public void setPatientText(String patientText) {
		this.patientText = patientText;
	}

	public Integer getSearchType() {
		return searchType;
	}

	public void setSearchType(Integer searchType) {
		this.searchType = searchType;
	}

	public String getReservationFrom() {
		return reservationFrom;
	}

	public void setReservationFrom(String reservationFrom) {
		this.reservationFrom = reservationFrom;
	}

	public String getReservationTo() {
		return reservationTo;
	}

	public void setReservationTo(String reservationTo) {
		this.reservationTo = reservationTo;
	}

	public BigInteger getSurveyId() {
		return surveyId;
	}

	public void setSurveyId(BigInteger surveyId) {
		this.surveyId = surveyId;
	}
}
