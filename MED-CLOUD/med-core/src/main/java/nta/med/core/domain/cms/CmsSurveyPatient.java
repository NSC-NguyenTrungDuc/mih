package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Lob;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_survey_patient database table.
 * 
 */
@Entity
@Table(name = "cms_survey_patient")
public class CmsSurveyPatient extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal accountFlg;

	private BigDecimal activeFlg;

	private BigDecimal agreementFlg;

	private Timestamp answerDate;

	private java.math.BigInteger cmsSurveyId;

	private Timestamp created;

	private String departmentCode;

	private String departmentName;

	private String hospCode;

	private String patientCode;

	private String patientName;

	private String patientPwd;

	private String reservationCode;

	private Date reservationDate;

	private String reservationTime;

	@Lob
	private String result;

	private String resultMetadata;

	private BigDecimal statusFlg;

	private String sysId;

	private String updId;

	private Timestamp updated;
	
	private String token;

	public CmsSurveyPatient() {
	}

	@Column(name = "ACCOUNT_FLG")
	public BigDecimal getAccountFlg() {
		return this.accountFlg;
	}

	public void setAccountFlg(BigDecimal accountFlg) {
		this.accountFlg = accountFlg;
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "AGREEMENT_FLG")
	public BigDecimal getAgreementFlg() {
		return this.agreementFlg;
	}

	public void setAgreementFlg(BigDecimal agreementFlg) {
		this.agreementFlg = agreementFlg;
	}

	@Column(name = "ANSWER_DATE")
	public Timestamp getAnswerDate() {
		return this.answerDate;
	}

	public void setAnswerDate(Timestamp answerDate) {
		this.answerDate = answerDate;
	}

	@Column(name = "CMS_SURVEY_ID")
	public java.math.BigInteger getCmsSurveyId() {
		return this.cmsSurveyId;
	}

	public void setCmsSurveyId(java.math.BigInteger cmsSurveyId) {
		this.cmsSurveyId = cmsSurveyId;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "DEPARTMENT_CODE")
	public String getDepartmentCode() {
		return this.departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	@Column(name = "DEPARTMENT_NAME")
	public String getDepartmentName() {
		return this.departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "PATIENT_CODE")
	public String getPatientCode() {
		return this.patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	@Column(name = "PATIENT_NAME")
	public String getPatientName() {
		return this.patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	@Column(name = "PATIENT_PWD")
	public String getPatientPwd() {
		return this.patientPwd;
	}

	public void setPatientPwd(String patientPwd) {
		this.patientPwd = patientPwd;
	}

	@Column(name = "RESERVATION_CODE")
	public String getReservationCode() {
		return this.reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	@Temporal(TemporalType.DATE)
	@Column(name = "RESERVATION_DATE")
	public Date getReservationDate() {
		return this.reservationDate;
	}

	public void setReservationDate(Date reservationDate) {
		this.reservationDate = reservationDate;
	}

	@Column(name = "RESERVATION_TIME")
	public String getReservationTime() {
		return this.reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public String getResult() {
		return this.result;
	}

	public void setResult(String result) {
		this.result = result;
	}

	@Column(name = "RESULT_METADATA")
	public String getResultMetadata() {
		return this.resultMetadata;
	}

	public void setResultMetadata(String resultMetadata) {
		this.resultMetadata = resultMetadata;
	}

	@Column(name = "STATUS_FLG")
	public BigDecimal getStatusFlg() {
		return this.statusFlg;
	}

	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	@Column(name = "TOKEN")
	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}
	
}