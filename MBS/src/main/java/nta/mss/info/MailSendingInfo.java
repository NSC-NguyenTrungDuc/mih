package nta.mss.info;

import java.math.BigDecimal;

public class MailSendingInfo {
	private Integer doctorId;
	private String doctorName;
	private String reservationDate;
	private String reservationTime;
	private String patientName;
	private String email;
	private String phoneNumber;
	private Integer readingFlg;
	private BigDecimal sendingStatus;
	private String subject;
	
	public MailSendingInfo(Integer doctorId, String doctorName, String reservationDate, String reservationTime,
			String patientName, String email, String phoneNumber, Integer readingFlg, BigDecimal sendingStatus,
			String subject) {
		super();
		this.doctorId = doctorId;
		this.doctorName = doctorName;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.patientName = patientName;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.readingFlg = readingFlg;
		this.sendingStatus = sendingStatus;
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
	public BigDecimal getSendingStatus() {
		return sendingStatus;
	}
	public void setSendingStatus(BigDecimal sendingStatus) {
		this.sendingStatus = sendingStatus;
	}
	public String getSubject() {
		return subject;
	}
	public void setSubject(String subject) {
		this.subject = subject;
	}
	
	
	
}
