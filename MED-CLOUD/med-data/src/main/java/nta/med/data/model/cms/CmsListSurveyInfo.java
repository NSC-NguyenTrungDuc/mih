/**
 * 
 */
package nta.med.data.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

/**
 * @author admin
 *
 */
public class CmsListSurveyInfo {
						

	private String patientCode;
	private String patientName;
	private String departmentCode;
	private String departmentName;
	private BigInteger surveyPatientId;
	private BigDecimal statusFlg;
	private String title;
	private Date reservationDate;
	private String reservationTime;
	private BigInteger surveyId;
	
	public CmsListSurveyInfo(String patientCode, String patientName, String departmentCode, String departmentName,
			BigInteger surveyPatientId, BigDecimal statusFlg, String title, Date reservationDate, String reservationTime, BigInteger surveyId) {
		super();
		this.patientCode = patientCode;
		this.patientName = patientName;
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.surveyPatientId = surveyPatientId;
		this.statusFlg = statusFlg;
		this.title = title;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.surveyId = surveyId;
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
	
	public BigInteger getSurveyPatientId() {
		return surveyPatientId;
	}
	
	public void setSurveyPatientId(BigInteger surveyPatientId) {
		this.surveyPatientId = surveyPatientId;
	}
	
	public BigDecimal getStatusFlg() {
		return statusFlg;
	}
	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
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
	public BigInteger getSurveyId() {
		return surveyId;
	}
	public void setSurveyId(BigInteger surveyId) {
		this.surveyId = surveyId;
	}
}
