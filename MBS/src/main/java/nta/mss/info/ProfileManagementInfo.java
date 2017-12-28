package nta.mss.info;

import java.util.List;

import nta.mss.model.UserChildModel;
import nta.mss.validation.FuriganaText;
import nta.mss.validation.Phone;

import org.hibernate.validator.constraints.NotBlank;

// TODO: Auto-generated Javadoc
/**
 * The Class ProfileManagementInfo.
 */
public class ProfileManagementInfo {
	
	/** The user id. */
	private Integer userId;
	
	/** The dob. */
	private String dob;
	
	/** The email. */
	private String email;
	
	/** The login id. */
	private String loginId;
	
	/** The login id. */
	private String patientCode;
	
	/** The name. */
	@NotBlank
	private String name;
	
	/** The name furigana. */
	@NotBlank
//	@FuriganaText
	private String nameFurigana;
	
	/** The password. */
	private String password;
	
	/** The password confirm. */
	private String passwordConfirm;
	
	/** The phone number. */
	@NotBlank
	@Phone
	private String phoneNumber;
	
	/** The sex. */
	private String sex;
	
	/** Master profileId **/
	private Long masterProfileId;
	/** The user childs. */
	private List<UserChildModel> userChilds;
	
	private String changePass;
	/**
	 * Instantiates a new profile management info.
	 */
	public ProfileManagementInfo() {
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
	 * Gets the name.
	 *
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * Sets the name.
	 *
	 * @param name the new name
	 */
	public void setName(String name) {
		this.name = name;
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
	 * Gets the password confirm.
	 *
	 * @return the password confirm
	 */
	public String getPasswordConfirm() {
		return passwordConfirm;
	}

	/**
	 * Sets the password confirm.
	 *
	 * @param passwordConfirm the new password confirm
	 */
	public void setPasswordConfirm(String passwordConfirm) {
		this.passwordConfirm = passwordConfirm;
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

	public List<UserChildModel> getUserChilds() {
		return userChilds;
	}

	public void setUserChilds(List<UserChildModel> userChilds) {
		this.userChilds = userChilds;
	}

	public String getChangePass() {
		return changePass;
	}

	public void setChangePass(String changePass) {
		this.changePass = changePass;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public Long getMasterProfileId() {
		return masterProfileId;
	}

	public void setMasterProfileId(Long masterProfileId) {
		this.masterProfileId = masterProfileId;
	}	
}
