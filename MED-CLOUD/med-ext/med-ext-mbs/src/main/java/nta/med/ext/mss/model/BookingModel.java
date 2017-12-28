package nta.med.ext.mss.model;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class BookingModel {

	// BEGIN REQUEST MODEL
	@JsonProperty("hosp_code")
	@NotNull
	private String hospCode; // string required
	
	@JsonProperty("department_code")
	@NotNull
	private String departmentCode; // string required
	
	@JsonProperty("doctor_code")
	private String doctorCode; // string
	
	@JsonProperty("reservation_date")
	@NotNull
	private String reservationDate; // string required
	
	@JsonProperty("reservation_time")
	@NotNull
	private String reservationTime; // string required
	
	@JsonProperty("patient_code")
	private String patientCode; // string
	
	@JsonProperty("patient_name_kanji")
	private String patientNameKanji; // string required
	
	@JsonProperty("patient_name_kana")
	private String patientNameKana; // string required
	
	@JsonProperty("patient_tel")
	private String patientTel; // string
	
	@JsonProperty("patient_email")
	private String patientEmail; // string
	
	@JsonProperty("patient_sex")
	private String patientSex; // string (F or M)
	
	@JsonProperty("patient_birthday")
	private String patientBirthday; // string
	
	@JsonProperty("locale")
	private String locale; // string
	
	@JsonProperty("doctor_name")
	 private String doctorName; // "石川"
	 
	@JsonProperty("department_name")
	private String departmentName; // 内科"
	
	@JsonProperty("reservation_code")
	private String reservationCode; // 980 (pkout1001)
	
	@JsonIgnore
	private boolean result;
	
	@JsonIgnore
	private String error;
	
	@JsonProperty("parent_code")
	private String parentCode;
	
	@JsonProperty("child_code_list")
	private String childCodeList;
	
	@JsonProperty("hangmog_code")
	private String hangmogCode;
	
	@JsonProperty("hangmog_name")
	private String hangmogName;
	
	@JsonProperty("doctor_grade")
	private String doctorGrade;

	@JsonProperty("sys_id")
	private String sysId; // string

	@JsonProperty("mis_survey_link")
	private String misSurveyLink;
	
	@JsonProperty("survey_yn")
	private String surveyYn;
	
	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
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

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientNameKanji() {
		return patientNameKanji;
	}

	public void setPatientNameKanji(String patientNameKanji) {
		this.patientNameKanji = patientNameKanji;
	}

	public String getPatientNameKana() {
		return patientNameKana;
	}

	public void setPatientNameKana(String patientNameKana) {
		this.patientNameKana = patientNameKana;
	}

	public String getPatientTel() {
		return patientTel;
	}

	public void setPatientTel(String patientTel) {
		this.patientTel = patientTel;
	}

	public String getPatientEmail() {
		return patientEmail;
	}

	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public String getPatientBirthday() {
		return patientBirthday;
	}

	public void setPatientBirthday(String patientBirthday) {
		this.patientBirthday = patientBirthday;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
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

	public String getParentCode() {
		return parentCode;
	}

	public void setParentCode(String parentCode) {
		this.parentCode = parentCode;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getChildCodeList() {
		return childCodeList;
	}

	public void setChildCodeList(String childCodeList) {
		this.childCodeList = childCodeList;
	}

	public String getDoctorGrade() {
		return doctorGrade;
	}

	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	
	public String getMisSurveyLink() {
		return misSurveyLink;
	}

	public void setMisSurveyLink(String misSurveyLink) {
		this.misSurveyLink = misSurveyLink;
	}

	public String getSurveyYn() {
		return surveyYn;
	}

	public void setSurveyYn(String surveyYn) {
		this.surveyYn = surveyYn;
	}

	@Override
	public String toString() {
		return "BookingModel [hospCode=" + hospCode + ", departmentCode=" + departmentCode + ", doctorCode="
				+ doctorCode + ", reservationDate=" + reservationDate + ", reservationTime=" + reservationTime
				+ ", patientCode=" + patientCode + ", patientNameKanji=" + patientNameKanji + ", patientNameKana="
				+ patientNameKana + ", patientTel=" + patientTel + ", patientEmail=" + patientEmail + ", patientSex="
				+ patientSex + ", patientBirthday=" + patientBirthday + ", locale=" + locale + ", doctorName="
				+ doctorName + ", departmentName=" + departmentName + ", reservationCode=" + reservationCode
				+ ", result=" + result + ", error=" + error + ", parentCode=" + parentCode + ", childCodeList="
				+ childCodeList + ", hangmogCode=" + hangmogCode + ", hangmogName=" + hangmogName + ", doctorGrade="
				+ doctorGrade + ", surveyYn=" + surveyYn + "]";
	}
}
