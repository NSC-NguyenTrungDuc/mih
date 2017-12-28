package nta.kcck.info;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;

public class KcckReservationInfo {
	 
	/** The reservation id. */
	private Integer reservationId;    
	
	/** The hospital id. */
	private Integer hospitalId;   
	
	/** The dept id. */
	private Integer deptId;           
	
	/** The doctor id. */
	private Integer doctorId;         
	
	
	/** The patient id. */
	private Integer patientId;   
	
	/** The patient name. */
	private String patientName;   
	
    
	
	/** The name furigana. */
	private String nameFurigana;     
     
	
   
	
	/** The phone number. */
	private String phoneNumber;    
	
	/** The email. */
	private String email;             
	
	/** The reservation date. */
	private String reservationDate;  

	/** The reservation time. */
	private String reservationTime;
	
	private String sessionId;
	

	/** The reservation code. */
	private String reservationCode;  
	
	private Integer reminderTime;
	
	private String doctorName;
	
	private String doctorCode;

	private String deptName;
	
	private String deptCode;
	
	private String patientCode;
	
	private String patientGender;
	
	private Date patientBirthDay;
	

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public Integer getDeptId() {
		return deptId;
	}

	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}

	public Integer getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
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

	public String getNameFurigana() {
		return nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
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

	public String getSessionId() {
		return sessionId;
	}

	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}
	
	

	public Integer getReminderTime() {
		return reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}
	

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}
	

	public String getDeptCode() {
		return deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientGender() {
		return patientGender;
	}

	public void setPatientGender(String patientGender) {
		this.patientGender = patientGender;
	}

	public Date getPatientBirthDay() {
		return patientBirthDay;
	}

	public void setPatientBirthDay(Date patientBirthDay) {
		this.patientBirthDay = patientBirthDay;
	}

	public KcckReservationInfo(Integer reservationId, Integer hospitalId, Integer deptId, Integer doctorId,
			Integer patientId, String patientName, String nameFurigana, String phoneNumber, String email,
			String reservationDate, String reservationTime, String sessionId, String reservationCode,
			Integer reminderTime, String doctorName, String doctorCode, String deptName, String deptCode,
			String patientCode, String patientGender, Date patientBirthDay) {
		super();
		this.reservationId = reservationId;
		this.hospitalId = hospitalId;
		this.deptId = deptId;
		this.doctorId = doctorId;
		this.patientId = patientId;
		this.patientName = patientName;
		this.nameFurigana = nameFurigana;
		this.phoneNumber = phoneNumber;
		this.email = email;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.sessionId = sessionId;
		this.reservationCode = reservationCode;
		this.reminderTime = reminderTime;
		this.doctorName = doctorName;
		this.doctorCode = doctorCode;
		this.deptName = deptName;
		this.deptCode = deptCode;
		this.patientCode = patientCode;
		this.patientGender = patientGender;
		this.patientBirthDay = patientBirthDay;
	}

	
	
}
