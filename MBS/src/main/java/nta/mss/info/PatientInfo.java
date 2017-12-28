package nta.mss.info;

import java.util.Map;

import nta.mss.entity.Patient;
import nta.mss.misc.enums.ReminderTime;
import nta.mss.validation.CheckSpecialChar;
import nta.mss.validation.Email;
import nta.mss.validation.FuriganaText;
import nta.mss.validation.Phone;

import org.hibernate.validator.constraints.NotBlank;

/**
 * The Class PatientModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
@SuppressWarnings("unused")
public class PatientInfo {
	private static final long serialVersionUID = 1L;
	
	@NotBlank
	private String name;
	@NotBlank
//	@FuriganaText
	private String nameFurigana;
	@NotBlank
	@Phone
	private String phoneNumber;
	@Email
	private String email;
	@NotBlank
	private String gender;
	private String dob;
	private Integer reminderTime = ReminderTime.BEFORE_30_MINUTES.toKey();
	@CheckSpecialChar
	private String cardNumber;
	private Map<Integer,String> mapReminderTime;
	
	private Integer patientId;
	private boolean isNewBooking;
	private Integer userId;
	private Integer vaccineId;
	private Integer childId;
	private String timeUsing;
	
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

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getCardNumber() {
		return cardNumber;
	}

	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getNameFurigana() {
		return nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public Integer getReminderTime() {
		return reminderTime;
	}
	
	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}

	public Map<Integer, String> getMapReminderTime() {
		return mapReminderTime;
	}

	public void setMapReminderTime(Map<Integer, String> mapReminderTime) {
		this.mapReminderTime = mapReminderTime;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Override
	public String toString() {
		return "PatientInfo [name=" + name + ", nameFurigana=" + nameFurigana
				+ ", phoneNumber=" + phoneNumber + ", email=" + email
				+ ", reminderTime=" + reminderTime + ", cardNumber="
				+ cardNumber ;
	}

	public boolean isNewBooking() {
		return isNewBooking;
	}

	public void setNewBooking(boolean isNewBooking) {
		this.isNewBooking = isNewBooking;
	}

	public Integer getUserId() {
		return userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public Integer getChildId() {
		return childId;
	}

	public void setChildId(Integer childId) {
		this.childId = childId;
	}

	public String getTimeUsing() {
		return timeUsing;
	}

	public void setTimeUsing(String timeUsing) {
		this.timeUsing = timeUsing;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getDob() {
		return dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}
	
}
