package nta.mss.info;

import java.math.BigInteger;

/**
 * The Class ReminderBookingVaccineInfo.
 *
 * @author MinhLS
 * @crtDate 2015/02/13
 */
public class ReminderBookingVaccineInfo {
	
	/** The user id. */
	private Integer userId;
	
	/** The user name. */
	private String userName;
	
	/** The email. */
	private String email;
	
	/** The phoneNumber. */
	private String phoneNumber;
	
	/** The child id. */
	private Integer childId;
	
	/** The child name. */
	private String childName;
	
	/** The dob. */
	private String dob;
	
	/** The vaccine id. */
	private Integer vaccineId;
	
	/** The vaccine name. */
	private String vaccineName;
	
	/** The limit age to month. */
	private Integer limitAgeToMonth;
	
	/** The support fee age. */
	private String supportFeeAge;
	
	/** The injected no. */
	private BigInteger injectedNo;
	
	/** The warning days. */
	private Integer warningDays;
	
	/** The warning msg. */
	private String warningMsg;
	
	/** The birth day. */
	private String birthDay;
	
	/** locale. */
	private String locale;
	
	private Integer hospitalId;
	
	/**
	 * Instantiates a new reminder booking vaccine info.
	 *
	 * @param userId the user id
	 * @param userName the user name
	 * @param email the email
	 * @param childId the child id
	 * @param childName the child name
	 * @param dob the dob
	 * @param vaccineId the vaccine id
	 * @param vaccineName the vaccine name
	 * @param limitAgeToMonth the limit age to month
	 * @param supportFeeAge the support fee age
	 * @param injectedNo the injected no
	 * @param warningDays the warning days
	 */
	public ReminderBookingVaccineInfo(Integer userId, String userName,
			String email, String phoneNumber, Integer childId, String childName, String dob,
			Integer vaccineId, String vaccineName, Integer limitAgeToMonth,
			String supportFeeAge, BigInteger injectedNo, Integer warningDays, Integer hospitalId, String locale) {
		super();
		this.userId = userId;
		this.userName = userName;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.childId = childId;
		this.childName = childName;
		this.dob = dob;
		this.vaccineId = vaccineId;
		this.vaccineName = vaccineName;
		this.limitAgeToMonth = limitAgeToMonth;
		this.supportFeeAge = supportFeeAge;
		this.injectedNo = injectedNo;
		this.warningDays = warningDays;
		this.hospitalId = hospitalId;
		this.locale = locale;
	}
	
	
	/**
	 * Gets the user id.
	 *
	 * @return the user id
	 */
	public Integer getUserId() {
		return userId;
	}
	
	/**
	 * Sets the user id.
	 *
	 * @param userId the new user id
	 */
	public void setUserId(Integer userId) {
		this.userId = userId;
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
	 * Gets the limit age to month.
	 *
	 * @return the limit age to month
	 */
	public Integer getLimitAgeToMonth() {
		return limitAgeToMonth;
	}
	
	/**
	 * Sets the limit age to month.
	 *
	 * @param limitAgeToMonth the new limit age to month
	 */
	public void setLimitAgeToMonth(Integer limitAgeToMonth) {
		this.limitAgeToMonth = limitAgeToMonth;
	}
	
	/**
	 * Gets the support fee age.
	 *
	 * @return the support fee age
	 */
	public String getSupportFeeAge() {
		return supportFeeAge;
	}
	
	/**
	 * Sets the support fee age.
	 *
	 * @param supportFeeAge the new support fee age
	 */
	public void setSupportFeeAge(String supportFeeAge) {
		this.supportFeeAge = supportFeeAge;
	}
	
	/**
	 * Gets the injected no.
	 *
	 * @return the injected no
	 */
	public BigInteger getInjectedNo() {
		return injectedNo;
	}
	
	/**
	 * Sets the injected no.
	 *
	 * @param injectedNo the new injected no
	 */
	public void setInjectedNo(BigInteger injectedNo) {
		this.injectedNo = injectedNo;
	}
	
	/**
	 * Gets the warning days.
	 *
	 * @return the warning days
	 */
	public Integer getWarningDays() {
		return warningDays;
	}
	
	/**
	 * Sets the warning days.
	 *
	 * @param warningDays the new warning days
	 */
	public void setWarningDays(Integer warningDays) {
		this.warningDays = warningDays;
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
	
	
	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	/**
	 * Gets the warning msg.
	 *
	 * @return the warning msg
	 */
	public String getWarningMsg() {
		return warningMsg;
	}
	
	/**
	 * Sets the warning msg.
	 *
	 * @param warningMsg the new warning msg
	 */
	public void setWarningMsg(String warningMsg) {
		this.warningMsg = warningMsg;
	}
	
	/**
	 * Gets the birth day.
	 *
	 * @return the birth day
	 */
	public String getBirthDay() {
		return birthDay;
	}
	
	/**
	 * Sets the birth day.
	 *
	 * @param birthDay the new birth day
	 */
	public void setBirthDay(String birthDay) {
		this.birthDay = birthDay;
	}
	
	/**
	 * Gets the locale.
	 *
	 * @return the locale
	 */
	public String getLocale() {
		return locale;
	}
	
	/**
	 * Sets the locale.
	 *
	 * @param locale the locale
	 */
	public void setLocale(String locale) {
		this.locale = locale;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
}
