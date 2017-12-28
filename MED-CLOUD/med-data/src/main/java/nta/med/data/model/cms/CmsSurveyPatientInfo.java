package nta.med.data.model.cms;

import java.math.BigInteger;
import java.util.Date;

public class CmsSurveyPatientInfo {

	private java.math.BigInteger id;

	private java.math.BigInteger cmsSurveyId;

	private String patientCode;

	private String patientName;

	private Date reservationDate;

	private String reservationTime;

	private String departmentCode;

	private String departmentName;

	private String title;

	public CmsSurveyPatientInfo(BigInteger id, BigInteger cmsSurveyId, String patientCode, String patientName,
			Date reservationDate, String reservationTime, String departmentCode, String departmentName, String title) {
		super();
		this.id = id;
		this.cmsSurveyId = cmsSurveyId;
		this.patientCode = patientCode;
		this.patientName = patientName;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.title = title;
	}

	public java.math.BigInteger getCmsSurveyId() {
		return cmsSurveyId;
	}

	public void setCmsSurveyId(java.math.BigInteger cmsSurveyId) {
		this.cmsSurveyId = cmsSurveyId;
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

	public Date getReservationDate() {
		return reservationDate;
	}

	public void setReservationDate(Date reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
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

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}
}
