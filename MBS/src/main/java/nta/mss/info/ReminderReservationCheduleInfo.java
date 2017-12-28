package nta.mss.info;

/**
 * 
 */
public class ReminderReservationCheduleInfo {
	
	private String patientName;

	private Integer reminderTime;
	
	private String reservationCode;
	
	private String departCode;
	
	private String deptName;

	private String reservationDate;

	private String reservationTime;
	
	private String email;
	
	private String hospitalName;
	
	private String locale;
	
	private Integer hospitalId;
	
	private String hospitalEmail;
	
	private String phoneNumber;
	
	private String cardNumber;
	
	

	public ReminderReservationCheduleInfo(String patientName, Integer reminderTime, String reservationCode, String departCode,
			String deptName, String reservationDate, String reservationTime, String email, String hospitalName,
			String locale, Integer hospitalId, String hospitalEmail, String phoneNumber, String cardNumber) {
		super();
		this.patientName = patientName;
		this.reminderTime = reminderTime;
		this.reservationCode = reservationCode;
		this.departCode = departCode;
		this.deptName = deptName;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.email = email;
		this.hospitalName = hospitalName;
		this.locale = locale;
		this.hospitalId = hospitalId;
		this.hospitalEmail = hospitalEmail;
		this.phoneNumber = phoneNumber;
		this.cardNumber = cardNumber;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public Integer getReminderTime() {
		return reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
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

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getHospitalName() {
		return hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getHospitalEmail() {
		return hospitalEmail;
	}

	public void setHospitalEmail(String hospitalEmail) {
		this.hospitalEmail = hospitalEmail;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getCardNumber() {
		return cardNumber;
	}

	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getDepartCode() {
		return departCode;
	}

	public void setDepartCode(String departCode) {
		this.departCode = departCode;
	}
}
