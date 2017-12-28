package nta.mss.info;

import java.math.BigDecimal;

// TODO: Auto-generated Javadoc
/**
 * The Class ReservationInfo.
 */
public class ReservationInfo {
	
	/** The booking newborns child id. */
	private Integer bookingNewbornsChildId;          
	
	/** The child id. */
	private Integer childId;          
	
	/** The vaccine child id. */
	private Integer vaccineChildId;
	
	/** The injected times. */
	private Integer injectedNo;    
	
	/** The vaccine id. */
	private Integer vaccineId;        
	
	/** The reservation id. */
	private Integer reservationId;    
	
	/** The active flg. */
	private BigDecimal activeFlg;        
	
	/** The dept id. */
	private Integer deptId;  
	
	/** The dept name. */
	private String deptName;       
	
	/** The doctor id. */
	private Integer doctorId;         
	
	/** The email. */
	private String email;             
	
	/** The hospital id. */
	private Integer hospitalId;       
	
	/** The name furigana. */
	private String nameFurigana;     
	
	/** The patient id. */
	private Integer patientId;        
	
	/** The patient name. */
	private String patientName;      
	
	/** The phone number. */
	private String phoneNumber;      
	
	/** The reg user. */
	private String regUser;          
	
	/** The reminder time. */
	private Integer reminderTime;     
	
	/** The reservation code. */
	private String reservationCode;  
	
	/** The reservation date. */
	private String reservationDate;  
	
	/** The reservation status. */
	private BigDecimal reservationStatus;
	
	/** The reservation time. */
	private String reservationTime;
	
	private String patientCode;
	
	/** The info booking. */
	private String infoBooking;
	
	
//	/**
//	 * Instantiates a new reservation info.
//	 */
//	public ReservationInfo() {
//	}
	
	/**
 * Instantiates a new reservation info.
 *
 * @param bookingNewbornsChildId the booking newborns child id
 * @param childId the child id
 * @param vaccineChildId the vaccine child id
 * @param injectedNo the injected times
 * @param vaccineId the vaccine id
 * @param reservationId the reservation id
 * @param activeFlg the active flg
 * @param deptId the dept id
 * @param doctorId the doctor id
 * @param email the email
 * @param hospitalId the hospital id
 * @param nameFurigana the name furigana
 * @param patientId the patient id
 * @param patientName the patient name
 * @param phoneNumber the phone number
 * @param regUser the reg user
 * @param reminderTime the reminder time
 * @param reservationCode the reservation code
 * @param reservationDate the reservation date
 * @param reservationStatus the reservation status
 * @param reservationTime the reservation time
 */
	public ReservationInfo(Integer bookingNewbornsChildId, Integer childId, Integer vaccineChildId,
			Integer injectedNo, Integer vaccineId, Integer reservationId,
			BigDecimal activeFlg, Integer deptId,String deptName, Integer doctorId,
			String email, Integer hospitalId, String nameFurigana,
			Integer patientId, String patientName, String phoneNumber,
			String regUser, Integer reminderTime, String reservationCode,
			String reservationDate, BigDecimal reservationStatus,
			String reservationTime, String patientCode) {
		super();
		this.bookingNewbornsChildId = bookingNewbornsChildId;
		this.childId = childId;
		this.vaccineChildId = vaccineChildId;
		this.injectedNo = injectedNo;
		this.vaccineId = vaccineId;
		this.reservationId = reservationId;
		this.activeFlg = activeFlg;
		this.deptId = deptId;
		this.deptName = deptName;
		this.doctorId = doctorId;
		this.email = email;
		this.hospitalId = hospitalId;
		this.nameFurigana = nameFurigana;
		this.patientId = patientId;
		this.patientName = patientName;
		this.phoneNumber = phoneNumber;
		this.regUser = regUser;
		this.reminderTime = reminderTime;
		this.reservationCode = reservationCode;
		this.reservationDate = reservationDate;
		this.reservationStatus = reservationStatus;
		this.reservationTime = reservationTime;
		this.patientCode = patientCode;
	}

	/*public ReservationInfo(Integer bookingNewbornsChildId, Integer childId,
			Integer reservationId, BigDecimal activeFlg, Integer deptId,
			Integer doctorId, String email, Integer hospitalId,
			String nameFurigana, Integer patientId, String patientName,
			String phoneNumber, String regUser, Integer reminderTime,
			String reservationCode, String reservationDate,
			BigDecimal reservationStatus, String reservationTime,
			String infoBooking) {
		super();
		this.bookingNewbornsChildId = bookingNewbornsChildId;
		this.childId = childId;
		this.reservationId = reservationId;
		this.activeFlg = activeFlg;
		this.deptId = deptId;
		this.doctorId = doctorId;
		this.email = email;
		this.hospitalId = hospitalId;
		this.nameFurigana = nameFurigana;
		this.patientId = patientId;
		this.patientName = patientName;
		this.phoneNumber = phoneNumber;
		this.regUser = regUser;
		this.reminderTime = reminderTime;
		this.reservationCode = reservationCode;
		this.reservationDate = reservationDate;
		this.reservationStatus = reservationStatus;
		this.reservationTime = reservationTime;
		this.infoBooking = infoBooking;
	}*/



	/**
	 * Gets the booking newborns child id.
	 *
	 * @return the booking newborns child id
	 */
	public Integer getBookingNewbornsChildId() {
		return bookingNewbornsChildId;
	}
	
	/**
	 * Sets the booking newborns child id.
	 *
	 * @param bookingNewbornsChildId the new booking newborns child id
	 */
	public void setBookingNewbornsChildId(Integer bookingNewbornsChildId) {
		this.bookingNewbornsChildId = bookingNewbornsChildId;
	}
	
	/**
	 * Gets the child id.
	 *
	 * @return the child id
	 */
	public Integer getChildId() {
		return childId;
	}
	
	/**
	 * Sets the child id.
	 *
	 * @param childId the new child id
	 */
	public void setChildId(Integer childId) {
		this.childId = childId;
	}
	
	/**
	 * Gets the injected times.
	 *
	 * @return the injected times
	 */
	public Integer getInjectedNo() {
		return injectedNo;
	}
	
	/**
	 * Sets the injected times.
	 *
	 * @param injectedNo the new injected times
	 */
	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}
	
	/**
	 * Gets the vaccine id.
	 *
	 * @return the vaccine id
	 */
	public Integer getVaccineId() {
		return vaccineId;
	}
	
	/**
	 * Sets the vaccine id.
	 *
	 * @param vaccineId the new vaccine id
	 */
	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}
	
	/**
	 * Gets the reservation id.
	 *
	 * @return the reservation id
	 */
	public Integer getReservationId() {
		return reservationId;
	}
	
	/**
	 * Sets the reservation id.
	 *
	 * @param reservationId the new reservation id
	 */
	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	
	/**
	 * Gets the dept id.
	 *
	 * @return the dept id
	 */
	public Integer getDeptId() {
		return deptId;
	}
	
	/**
	 * Sets the dept id.
	 *
	 * @param deptId the new dept id
	 */
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	
	/**
	 * Gets the doctor id.
	 *
	 * @return the doctor id
	 */
	public Integer getDoctorId() {
		return doctorId;
	}
	
	/**
	 * Sets the doctor id.
	 *
	 * @param doctorId the new doctor id
	 */
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	
	/**
	 * Gets the email.
	 *
	 * @return the email
	 */
	public String getEmail() {
		return email;
	}
	
	/**
	 * Sets the email.
	 *
	 * @param email the new email
	 */
	public void setEmail(String email) {
		this.email = email;
	}
	
	/**
	 * Gets the hospital id.
	 *
	 * @return the hospital id
	 */
	public Integer getHospitalId() {
		return hospitalId;
	}
	
	/**
	 * Sets the hospital id.
	 *
	 * @param hospitalId the new hospital id
	 */
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	
	/**
	 * Gets the name furigana.
	 *
	 * @return the name furigana
	 */
	public String getNameFurigana() {
		return nameFurigana;
	}
	
	/**
	 * Sets the name furigana.
	 *
	 * @param nameFurigana the new name furigana
	 */
	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}
	
	/**
	 * Gets the patient id.
	 *
	 * @return the patient id
	 */
	public Integer getPatientId() {
		return patientId;
	}
	
	/**
	 * Sets the patient id.
	 *
	 * @param patientId the new patient id
	 */
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}
	
	/**
	 * Gets the patient name.
	 *
	 * @return the patient name
	 */
	public String getPatientName() {
		return patientName;
	}
	
	/**
	 * Sets the patient name.
	 *
	 * @param patientName the new patient name
	 */
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	
	/**
	 * Gets the phone number.
	 *
	 * @return the phone number
	 */
	public String getPhoneNumber() {
		return phoneNumber;
	}
	
	/**
	 * Sets the phone number.
	 *
	 * @param phoneNumber the new phone number
	 */
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	
	/**
	 * Gets the reg user.
	 *
	 * @return the reg user
	 */
	public String getRegUser() {
		return regUser;
	}
	
	/**
	 * Sets the reg user.
	 *
	 * @param regUser the new reg user
	 */
	public void setRegUser(String regUser) {
		this.regUser = regUser;
	}
	
	/**
	 * Gets the reminder time.
	 *
	 * @return the reminder time
	 */
	public Integer getReminderTime() {
		return reminderTime;
	}
	
	/**
	 * Sets the reminder time.
	 *
	 * @param reminderTime the new reminder time
	 */
	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}
	
	/**
	 * Gets the reservation code.
	 *
	 * @return the reservation code
	 */
	public String getReservationCode() {
		return reservationCode;
	}
	
	/**
	 * Sets the reservation code.
	 *
	 * @param reservationCode the new reservation code
	 */
	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}
	
	/**
	 * Gets the reservation date.
	 *
	 * @return the reservation date
	 */
	public String getReservationDate() {
		return reservationDate;
	}
	
	/**
	 * Sets the reservation date.
	 *
	 * @param reservationDate the new reservation date
	 */
	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}
	
	/**
	 * Gets the reservation time.
	 *
	 * @return the reservation time
	 */
	public String getReservationTime() {
		return reservationTime;
	}
	
	/**
	 * Sets the reservation time.
	 *
	 * @param reservationTime the new reservation time
	 */
	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	/**
	 * Gets the active flg.
	 *
	 * @return the active flg
	 */
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	/**
	 * Sets the active flg.
	 *
	 * @param activeFlg the new active flg
	 */
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	/**
	 * Gets the reservation status.
	 *
	 * @return the reservation status
	 */
	public BigDecimal getReservationStatus() {
		return reservationStatus;
	}

	/**
	 * Sets the reservation status.
	 *
	 * @param reservationStatus the new reservation status
	 */
	public void setReservationStatus(BigDecimal reservationStatus) {
		this.reservationStatus = reservationStatus;
	}

	/**
	 * Gets the vaccine child id.
	 *
	 * @return the vaccine child id
	 */
	public Integer getVaccineChildId() {
		return vaccineChildId;
	}

	/**
	 * Sets the vaccine child id.
	 *
	 * @param vaccineChildId the new vaccine child id
	 */
	public void setVaccineChildId(Integer vaccineChildId) {
		this.vaccineChildId = vaccineChildId;
	}

	/**
	 * Gets the info booking.
	 *
	 * @return the info booking
	 */
	public String getInfoBooking() {
		return infoBooking;
	}

	/**
	 * Sets the info booking.
	 *
	 * @param infoBooking the new info booking
	 */
	public void setInfoBooking(String infoBooking) {
		this.infoBooking = infoBooking;
	}

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	

}
