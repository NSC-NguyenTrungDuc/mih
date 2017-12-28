package nta.mss.info;

import java.io.Serializable;
import java.util.List;
import java.util.Map;

// TODO: Auto-generated Javadoc
/**
 * The Class MailInfo.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class SmsInfo implements Serializable{
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -157511726959290226L;
	
	/** The session id. */
	private String sessionId;
	
	/** The hospital name. */
	private String hospitalName;
	
	/** The hospital phone. */
	private String hospitalPhone;
	
	/** The reservation datetime. */
	private String reservationDatetime;
	
	/** The reservation code. */
	private String reservationCode;
	
	/** The reminder time. */
	private String reminderTime;
	
	/** The department name. */
	private String departmentName;
	
	/** The doctor id. */
	private String doctorId;
	
	/** The doctor name. */
	private String doctorName;
	
	/** The new doctor name. */
	private String newDoctorName;
	
	/** The content. */
	private String content;
	
	/** The patient name. */
	private String patientName;
	
	/** The server address. */
	private String serverAddress;
	
	/** The patient id. */
	private Integer patientId;
	
	/** The reservation id. */
	private Integer reservationId;
	
	/** The child name. */
	private String childName;
	
	/** The dob. */
	private String dob;
	
	/** The sex. */
	private String sex;
	
	/** The vaccine name. */
	private String vaccineName;
	
	/** The date booking. */
	private String dateBooking;
	
	/** The times using. */
	private String timesUsing;
	
	/** The mail info list. */
	private List<MailInfo> mailInfoList;
	
	/** The mail id. */
	private String mailId;
	
	/** The link reminder email. */
	private String linkReminderEmail;
	
	/** The link booking complete. */
	private String linkBookingComplete = "";
	
	/** The link authorized email. */
	private String linkAuthorizedEmail = "";
	
	/** The link thank you. */
	private String linkThankYou;
	
	/** The link booking change info. */
	private String linkBookingChangeInfo;
	
	/** The link booking change complete. */
	private String linkBookingChangeComplete;
	
	/** The link booking vaccine complete. */
	private String linkBookingVaccineComplete;
	
	/** The link reset password. */
	private String linkResetPassword;
	
	/** The booking vaccine. */
	private boolean bookingVaccine;
	
	/** The login id. */
	private String loginId;
	
	/** The password. */
	private String password;
	
	/** The link verify account. */
	private String linkVerifyAccount;
	
	/** The user name. */
	private String userName;
	
	/** The patient code. */
	private String patientCode;
	
	/** The children. */
	private Map<Integer, List<ReminderBookingVaccineInfo>> children;
	
	/** The link top page. */
	private String linkTopPage;
	
	/**
	 * Gets the hospital name.
	 * 
	 * @return the hospital name
	 */
	public String getHospitalName() {
		return hospitalName;
	}
	
	/**
	 * Sets the hospital name.
	 * 
	 * @param hospitalName
	 *            the new hospital name
	 */
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	
	/**
	 * Gets the reservation datetime.
	 * 
	 * @return the reservation datetime
	 */
	public String getReservationDatetime() {
		return reservationDatetime;
	}
	
	/**
	 * Sets the reservation datetime.
	 * 
	 * @param reservationDatetime
	 *            the new reservation datetime
	 */
	public void setReservationDatetime(String reservationDatetime) {
		this.reservationDatetime = reservationDatetime;
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
	 * @param reservationCode
	 *            the new reservation code
	 */
	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}
	
	/**
	 * Gets the reminder time.
	 * 
	 * @return the reminder time
	 */
	public String getReminderTime() {
		return reminderTime;
	}
	
	/**
	 * Sets the reminder time.
	 * 
	 * @param reminderTime
	 *            the new reminder time
	 */
	public void setReminderTime(String reminderTime) {
		this.reminderTime = reminderTime;
	}
	
	/**
	 * Gets the department name.
	 * 
	 * @return the department name
	 */
	public String getDepartmentName() {
		return departmentName;
	}
	
	/**
	 * Sets the department name.
	 * 
	 * @param departmentName
	 *            the new department name
	 */
	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
	
	/**
	 * Gets the doctor name.
	 * 
	 * @return the doctor name
	 */
	public String getDoctorName() {
		return doctorName;
	}
	
	/**
	 * Sets the doctor name.
	 * 
	 * @param doctorName
	 *            the new doctor name
	 */
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	
	/**
	 * Gets the new doctor name.
	 *
	 * @return the new doctor name
	 */
	public String getNewDoctorName() {
		return newDoctorName;
	}

	/**
	 * Sets the new doctor name.
	 *
	 * @param newDoctorName the new new doctor name
	 */
	public void setNewDoctorName(String newDoctorName) {
		this.newDoctorName = newDoctorName;
	}

	/**
	 * Gets the session id.
	 * 
	 * @return the session id
	 */
	public String getSessionId() {
		return sessionId;
	}
	
	/**
	 * Sets the session id.
	 * 
	 * @param sessionId
	 *            the new session id
	 */
	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	/**
	 * Gets the hospital phone.
	 *
	 * @return the hospital phone
	 */
	public String getHospitalPhone() {
		return hospitalPhone;
	}

	/**
	 * Sets the hospital phone.
	 *
	 * @param hospitalPhone the new hospital phone
	 */
	public void setHospitalPhone(String hospitalPhone) {
		this.hospitalPhone = hospitalPhone;
	}

	/**
	 * Gets the content.
	 *
	 * @return the content
	 */
	public String getContent() {
		return content;
	}

	/**
	 * Sets the content.
	 *
	 * @param content the new content
	 */
	public void setContent(String content) {
		this.content = content;
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
	 * Gets the server address.
	 *
	 * @return the server address
	 */
	public String getServerAddress() {
		return serverAddress;
	}

	/**
	 * Sets the server address.
	 *
	 * @param serverAddress the new server address
	 */
	public void setServerAddress(String serverAddress) {
		this.serverAddress = serverAddress;
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
	 * Gets the mail info list.
	 *
	 * @return the mail info list
	 */
	public List<MailInfo> getMailInfoList() {
		return mailInfoList;
	}

	/**
	 * Sets the mail info list.
	 *
	 * @param mailInfoList the new mail info list
	 */
	public void setMailInfoList(List<MailInfo> mailInfoList) {
		this.mailInfoList = mailInfoList;
	}

	/**
	 * Gets the mail id.
	 *
	 * @return the mail id
	 */
	public String getMailId() {
		return mailId;
	}

	/**
	 * Sets the mail id.
	 *
	 * @param mailId the new mail id
	 */
	public void setMailId(String mailId) {
		this.mailId = mailId;
	}

	/**
	 * Gets the doctor id.
	 *
	 * @return the doctorId
	 */
	public String getDoctorId() {
		return doctorId;
	}

	/**
	 * Sets the doctor id.
	 *
	 * @param doctorId the doctorId to set
	 */
	public void setDoctorId(String doctorId) {
		this.doctorId = doctorId;
	}

	/**
	 * Gets the link reminder email.
	 *
	 * @return the linkReminderEmail
	 */
	public String getLinkReminderEmail() {
		return linkReminderEmail;
	}

	/**
	 * Sets the link reminder email.
	 *
	 * @param linkReminderEmail the linkReminderEmail to set
	 */
	public void setLinkReminderEmail(String linkReminderEmail) {
		this.linkReminderEmail = linkReminderEmail;
	}

	/**
	 * Gets the link booking complete.
	 *
	 * @return the linkBookingComplete
	 */
	public String getLinkBookingComplete() {
		return linkBookingComplete;
	}

	/**
	 * Sets the link booking complete.
	 *
	 * @param linkBookingComplete the linkBookingComplete to set
	 */
	public void setLinkBookingComplete(String linkBookingComplete) {
		this.linkBookingComplete = linkBookingComplete;
	}

	/**
	 * Gets the link thank you.
	 *
	 * @return the linkThankYou
	 */
	public String getLinkThankYou() {
		return linkThankYou;
	}

	/**
	 * Sets the link thank you.
	 *
	 * @param linkThankYou the linkThankYou to set
	 */
	public void setLinkThankYou(String linkThankYou) {
		this.linkThankYou = linkThankYou;
	}

	/**
	 * Gets the link authorized email.
	 *
	 * @return the linkAuthorizedEmail
	 */
	public String getLinkAuthorizedEmail() {
		return linkAuthorizedEmail;
	}

	/**
	 * Sets the link authorized email.
	 *
	 * @param linkAuthorizedEmail the linkAuthorizedEmail to set
	 */
	public void setLinkAuthorizedEmail(String linkAuthorizedEmail) {
		this.linkAuthorizedEmail = linkAuthorizedEmail;
	}

	/**
	 * Gets the link booking change info.
	 *
	 * @return the linkBookingChangeInfo
	 */
	public String getLinkBookingChangeInfo() {
		return linkBookingChangeInfo;
	}

	/**
	 * Sets the link booking change info.
	 *
	 * @param linkBookingChangeInfo the linkBookingChangeInfo to set
	 */
	public void setLinkBookingChangeInfo(String linkBookingChangeInfo) {
		this.linkBookingChangeInfo = linkBookingChangeInfo;
	}

	/**
	 * Gets the link booking change complete.
	 *
	 * @return the linkBookingChangeComplete
	 */
	public String getLinkBookingChangeComplete() {
		return linkBookingChangeComplete;
	}

	/**
	 * Sets the link booking change complete.
	 *
	 * @param linkBookingChangeComplete the linkBookingChangeComplete to set
	 */
	public void setLinkBookingChangeComplete(String linkBookingChangeComplete) {
		this.linkBookingChangeComplete = linkBookingChangeComplete;
	}

	/**
	 * Gets the login id.
	 *
	 * @return the login id
	 */
	public String getLoginId() {
		return loginId;
	}

	/**
	 * Sets the login id.
	 *
	 * @param loginId the new login id
	 */
	public void setLoginId(String loginId) {
		this.loginId = loginId;
	}

	/**
	 * Gets the password.
	 *
	 * @return the password
	 */
	public String getPassword() {
		return password;
	}

	/**
	 * Sets the password.
	 *
	 * @param password the new password
	 */
	public void setPassword(String password) {
		this.password = password;
	}

	/**
	 * Gets the link verify account.
	 *
	 * @return the link verify account
	 */
	public String getLinkVerifyAccount() {
		return linkVerifyAccount;
	}

	/**
	 * Sets the link verify account.
	 *
	 * @param linkVerifyAccount the new link verify account
	 */
	public void setLinkVerifyAccount(String linkVerifyAccount) {
		this.linkVerifyAccount = linkVerifyAccount;
	}
	
	/**
	 * Gets the child name.
	 *
	 * @return the child name
	 */
	public String getChildName() {
		return childName;
	}

	/**
	 * Sets the child name.
	 *
	 * @param childName the new child name
	 */
	public void setChildName(String childName) {
		this.childName = childName;
	}

	/**
	 * Gets the dob.
	 *
	 * @return the dob
	 */
	public String getDob() {
		return dob;
	}

	/**
	 * Sets the dob.
	 *
	 * @param dob the new dob
	 */
	public void setDob(String dob) {
		this.dob = dob;
	}

	/**
	 * Gets the sex.
	 *
	 * @return the sex
	 */
	public String getSex() {
		return sex;
	}

	/**
	 * Sets the sex.
	 *
	 * @param sex the new sex
	 */
	public void setSex(String sex) {
		this.sex = sex;
	}

	/**
	 * Gets the vaccine name.
	 *
	 * @return the vaccine name
	 */
	public String getVaccineName() {
		return vaccineName;
	}

	/**
	 * Sets the vaccine name.
	 *
	 * @param vaccineName the new vaccine name
	 */
	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}

	/**
	 * Gets the date booking.
	 *
	 * @return the date booking
	 */
	public String getDateBooking() {
		return dateBooking;
	}

	/**
	 * Sets the date booking.
	 *
	 * @param dateBooking the new date booking
	 */
	public void setDateBooking(String dateBooking) {
		this.dateBooking = dateBooking;
	}

	/**
	 * Gets the times using.
	 *
	 * @return the times using
	 */
	public String getTimesUsing() {
		return timesUsing;
	}

	/**
	 * Sets the times using.
	 *
	 * @param timesUsing the new times using
	 */
	public void setTimesUsing(String timesUsing) {
		this.timesUsing = timesUsing;
	}

	/**
	 * Checks if is booking vaccine.
	 *
	 * @return true, if is booking vaccine
	 */
	public boolean isBookingVaccine() {
		return bookingVaccine;
	}

	/**
	 * Sets the booking vaccine.
	 *
	 * @param bookingVaccine the new booking vaccine
	 */
	public void setBookingVaccine(boolean bookingVaccine) {
		this.bookingVaccine = bookingVaccine;
	}

	/**
	 * Gets the link booking vaccine complete.
	 *
	 * @return the link booking vaccine complete
	 */
	public String getLinkBookingVaccineComplete() {
		return linkBookingVaccineComplete;
	}

	/**
	 * Sets the link booking vaccine complete.
	 *
	 * @param linkBookingVaccineComplete the new link booking vaccine complete
	 */
	public void setLinkBookingVaccineComplete(String linkBookingVaccineComplete) {
		this.linkBookingVaccineComplete = linkBookingVaccineComplete;
	}

	/**
	 * Gets the user name.
	 *
	 * @return the user name
	 */
	public String getUserName() {
		return userName;
	}

	/**
	 * Sets the user name.
	 *
	 * @param userName the new user name
	 */
	public void setUserName(String userName) {
		this.userName = userName;
	}

	
	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	/**
	 * Gets the children.
	 *
	 * @return the children
	 */
	public Map<Integer, List<ReminderBookingVaccineInfo>> getChildren() {
		return children;
	}

	/**
	 * Sets the children.
	 *
	 * @param children the children
	 */
	public void setChildren(Map<Integer, List<ReminderBookingVaccineInfo>> children) {
		this.children = children;
	}

	/**
	 * Gets the link top page.
	 *
	 * @return the link top page
	 */
	public String getLinkTopPage() {
		return linkTopPage;
	}

	/**
	 * Sets the link top page.
	 *
	 * @param linkTopPage the new link top page
	 */
	public void setLinkTopPage(String linkTopPage) {
		this.linkTopPage = linkTopPage;
	}

	public String getLinkResetPassword() {
		return linkResetPassword;
	}

	public void setLinkResetPassword(String linkResetPassword) {
		this.linkResetPassword = linkResetPassword;
	}

	@Override
	public String toString() {
		return "SmsInfo [hospitalName=" + hospitalName + ", hospitalPhone=" + hospitalPhone + ", reservationDatetime="
				+ reservationDatetime + ", reservationCode=" + reservationCode + ", reminderTime=" + reminderTime
				+ ", departmentName=" + departmentName + ", doctorId=" + doctorId + ", doctorName=" + doctorName
				+ ", newDoctorName=" + newDoctorName + ", content=" + content + ", patientName=" + patientName
				+ ", serverAddress=" + serverAddress + ", patientId=" + patientId + ", reservationId=" + reservationId
				+ ", childName=" + childName + ", dob=" + dob + ", sex=" + sex + ", vaccineName=" + vaccineName
				+ ", dateBooking=" + dateBooking + ", userName=" + userName + ", patientCode=" + patientCode + "]";
	}
	
}
