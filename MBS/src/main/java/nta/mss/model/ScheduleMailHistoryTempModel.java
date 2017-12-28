package nta.mss.model;

import java.io.Serializable;

/**
 * The Class ScheduleMailHistoryTempModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class ScheduleMailHistoryTempModel implements Serializable{

	private static final long serialVersionUID = 6648687614253112684L;
	
	private String checkDate;
	private String timeSlot;
	private Integer patientId;
	private String patientName;
	private String email;
	private String phoneNumber;
	private Integer readingFlg;
	private Integer sendingStatus;
	private String subject;
	private Integer doctorId;
	private String doctorName;
	private Integer departmentId;
	private String departmentCode;
	private String departmentName;
	
	public String getCheckDate() {
		return checkDate;
	}
	public void setCheckDate(String checkDate) {
		this.checkDate = checkDate;
	}
	public String getTimeSlot() {
		return timeSlot;
	}
	public void setTimeSlot(String timeSlot) {
		this.timeSlot = timeSlot;
	}
	public Integer getPatientId() {
		return patientId;
	}
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPhoneNumber() {
		return phoneNumber;
	}
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	public Integer getReadingFlg() {
		return readingFlg;
	}
	public void setReadingFlg(Integer readingFlg) {
		this.readingFlg = readingFlg;
	}
	public Integer getSendingStatus() {
		return sendingStatus;
	}
	public void setSendingStatus(Integer sendingStatus) {
		this.sendingStatus = sendingStatus;
	}
	public String getSubject() {
		return subject;
	}
	public void setSubject(String subject) {
		this.subject = subject;
	}
	public Integer getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Integer getDepartmentId() {
		return departmentId;
	}
	public void setDepartmentId(Integer departmentId) {
		this.departmentId = departmentId;
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
}
