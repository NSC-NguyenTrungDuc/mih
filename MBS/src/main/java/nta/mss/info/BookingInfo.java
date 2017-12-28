package nta.mss.info;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang.StringUtils;

import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.ReminderTime;
import nta.mss.model.ReservationModel;

// TODO: Auto-generated Javadoc
/**
 * The Class BookingInfo.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class BookingInfo implements Serializable {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -3621510023910770785L;
	
	/** The token id. */
	private String tokenId;
	
	/** The reservation id. */
	private Integer reservationId;
	
	/** The dept id. */
	private Integer deptId;
	
	/** The dept name. */
	private String deptName;
	
	/** The dept type. */
	private Integer deptType;
	
	/** The patient id. */
	private Integer patientId;
	
	/** The patient name. */
	private String patientName;
	
	/** The patient furigana. */
	private String patientFurigana;
	
	/** The doctor id. */
	private Integer doctorId;

	private String doctorCode;
	
	/** The doctor name. */
	private String doctorName;
	
	/** The phone number. */
	private String phoneNumber;
	
	/** The email. */
	private String email;
	
	/** The reminder time. */
	private Integer reminderTime = ReminderTime.BEFORE_30_MINUTES.toKey();
	
	/** The card number. */
	private String cardNumber;
	
	/** The reservation code. */
	private String reservationCode;
	
	/** The reservation date. */
	private String reservationDate;
	
	/** The reservation time. */
	private String reservationTime;
	
	/** The formatted reservation date. */
	private String formattedReservationDate;
	
	/** The formatted reservation time. */
	private String formattedReservationTime;
	
	/** The vaccine id. */
	private Integer vaccineId; 
	
	/** The child id. */
	private Integer childId;
	
	/** The child name. */
	private String childName;
	
	/** The dob. */
	private String dob;
	
	/** The sex. */
	private String sex;
	
	/** The dob. */
	private String patientDob;
	
	/** The sex. */
	private String patientGender;
	
	private String userSex;
	
	private String userDob;
	
	private Date patientBitrhday;
	
	/** The vaccine name. */
	private String vaccineName;
	
	/** The date booking. */
	private String dateBooking;
	
	/** The times using. */
	private String timesUsing;
	
	/** The vaccine child history id. */
	private Integer vaccineChildHistoryId;
	
	private List<ReservationModel> listLastestReservation;
	
	private Integer userId;
	
	private String patientIconPath;
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
	 * @param reservationId
	 *            the new reservation id
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
	 * @param deptId
	 *            the new dept id
	 */
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	
	/**
	 * Gets the dept name.
	 * 
	 * @return the dept name
	 */
	public String getDeptName() {
		return deptName;
	}
	
	/**
	 * Sets the dept name.
	 * 
	 * @param deptName
	 *            the new dept name
	 */
	public void setDeptName(String deptName) {
		this.deptName = deptName;
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
	 * @param doctorId
	 *            the new doctor id
	 */
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
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
	 * @param phoneNumber
	 *            the new phone number
	 */
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
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
	 * @param email
	 *            the new email
	 */
	public void setEmail(String email) {
		this.email = email;
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
	 * @param reminderTime
	 *            the new reminder time
	 */
	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}
	
	/**
	 * Gets the card number.
	 * 
	 * @return the card number
	 */
	public String getCardNumber() {
		return cardNumber;
	}
	
	/**
	 * Sets the card number.
	 * 
	 * @param cardNumber
	 *            the new card number
	 */
	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
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
	 * @param patientId
	 *            the new patient id
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
	 * @param patientName
	 *            the new patient name
	 */
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	
	/**
	 * Gets the patient furigana.
	 * 
	 * @return the patient furigana
	 */
	public String getPatientFurigana() {
		return patientFurigana;
	}
	
	/**
	 * Sets the patient furigana.
	 * 
	 * @param patientFurigana
	 *            the new patient furigana
	 */
	public void setPatientFurigana(String patientFurigana) {
		this.patientFurigana = patientFurigana;
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
	 * @param reservationDate
	 *            the new reservation date
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
	 * @param reservationTime
	 *            the new reservation time
	 */
	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}
	
	/**
	 * Gets the formatted reservation date.
	 * 
	 * @return the formatted reservation date
	 */
	public String getFormattedReservationDate() {
		return MssDateTimeUtil.convertStringDateByLocale(reservationDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
	}

	/**
	 * Sets the formatted reservation date.
	 *
	 * @param formattedReservationDate the new formatted reservation date
	 */
	public void setFormattedReservationDate(String formattedReservationDate) {
		this.formattedReservationDate = formattedReservationDate;
	}

	/**
	 * Gets the formatted reservation time.
	 * 
	 * @return the formatted reservation time
	 */
	public String getFormattedReservationTime() {
		if (StringUtils.isBlank(formattedReservationTime)) {
			formattedReservationTime = MssDateTimeUtil.convertStringTimeByLocale(reservationTime, DateTimeFormat.TIME_FORMAT_HH_MM, MssContextHolder.getLocale());
		}
		return formattedReservationTime;
	}
	
	/**
	 * Sets the formatted reservation time.
	 *
	 * @param formattedReservationTime the new formatted reservation time
	 */
	public void setFormattedReservationTime(String formattedReservationTime) {
		this.formattedReservationTime = formattedReservationTime;
	}
	
	/**
	 * Gets the token id.
	 * 
	 * @return the token id
	 */
	public String getTokenId() {
		return tokenId;
	}
	
	/**
	 * Sets the token id.
	 * 
	 * @param tokenId
	 *            the new token id
	 */
	public void setTokenId(String tokenId) {
		this.tokenId = tokenId;
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

	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@Override
	public String toString() {
		return "BookingInfo [tokenId=" + tokenId + ", reservationId="
				+ reservationId + ", deptId=" + deptId + ", deptName="
				+ deptName + ", patientId=" + patientId + ", patientName="
				+ patientName + ", patientFurigana=" + patientFurigana
				+ ", doctorId=" + doctorId + ", doctorName=" + doctorName
				+ ", phoneNumber=" + phoneNumber + ", email=" + email
				+ ", reminderTime=" + reminderTime + ", cardNumber="
				+ cardNumber + ", reservationCode=" + reservationCode
				+ ", reservationDate=" + reservationDate + ", reservationTime="
				+ reservationTime + ", formattedReservationDate="
				+ formattedReservationDate + ", formattedReservationTime="
				+ formattedReservationTime + "]";
	}

	public Integer getDeptType() {
		return deptType;
	}

	public void setDeptType(Integer deptType) {
		this.deptType = deptType;
	}

	public Integer getVaccineChildHistoryId() {
		return vaccineChildHistoryId;
	}

	public void setVaccineChildHistoryId(Integer vaccineChildHistoryId) {
		this.vaccineChildHistoryId = vaccineChildHistoryId;
	}

	public Integer getUserId() {
		return userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public List<ReservationModel> getListLastestReservation() {
		return listLastestReservation;
	}

	public void setListLastestReservation(List<ReservationModel> listLastestReservation) {
		this.listLastestReservation = listLastestReservation;
	}

	public String getPatientDob() {
		return patientDob;
	}

	public void setPatientDob(String patientDob) {
		this.patientDob = patientDob;
	}

	public String getPatientGender() {
		return patientGender;
	}

	public void setPatientGender(String patientGender) {
		this.patientGender = patientGender;
	}
	public Date getPatientBitrhday() {
		 return patientBitrhday;
	}

	public void setPatientBitrhday(Date patientBitrhday) {
		this.patientBitrhday = patientBitrhday;
	}

	public String getUserSex() {
		return userSex;
	}

	public void setUserSex(String userSex) {
		this.userSex = userSex;
	}

	public String getUserDob() {
		return userDob;
	}

	public void setUserDob(String userDob) {
		this.userDob = userDob;
	}

	public String getPatientIconPath() {
		return patientIconPath;
	}

	public void setPatientIconPath(String patientIconPath) {
		this.patientIconPath = patientIconPath;
	}
	
}
