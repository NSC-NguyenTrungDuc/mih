package nta.mss.model;

import java.util.List;

import javax.validation.constraints.Size;

import nta.mss.entity.User;
import nta.mss.validation.Email;
import nta.mss.validation.FuriganaText;
import nta.mss.validation.Phone;

import org.hibernate.validator.constraints.NotBlank;

/**
 * The Class UserModel.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class UserModel extends BaseModel<User> {

	private static final long serialVersionUID = 1682544182310808355L;

	private Integer userId;

	@NotBlank
	private String dob;

//	@NotBlank
	private String address;

	@NotBlank
	@Email
	private String email;



	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	/*
	 * @NotBlank
	 * 
	 * @Size(min = 6)
	 */
	private String loginId;
	@NotBlank
	private String name;
	@NotBlank
	private String nameFurigana;
//	@NotBlank
//	@Size(min = 6)
	private String password;
//	@NotBlank
//	@Size(min = 6)
	private String passwordConfirm;
	@NotBlank
	@Phone
	private String phoneNumber;
	private String sex;
	private List<UserChildModel> userChilds;
	private Integer userStatus;
	private Integer vaccineId;
	private Integer hospitalId;
	private String hospitalCode;
	private String hospitalName;
	private String tokenId;
	private Integer patientId;
	private String patientCode;

	private Boolean isFaceBook;

	//
	private String token;
	private Long masterProfileId;
	
	public UserModel() {
		super(User.class);
	}

	public Integer getUserId() {
		return this.userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getLoginId() {
		return this.loginId;
	}

	public void setLoginId(String loginId) {
		this.loginId = loginId;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNameFurigana() {
		return this.nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getPasswordConfirm() {
		return passwordConfirm;
	}

	public void setPasswordConfirm(String passwordConfirm) {
		this.passwordConfirm = passwordConfirm;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public List<UserChildModel> getUserChilds() {
		return this.userChilds;
	}

	public void setUserChilds(List<UserChildModel> userChilds) {
		this.userChilds = userChilds;
	}

	public Integer getUserStatus() {
		return userStatus;
	}

	public void setUserStatus(Integer userStatus) {
		this.userStatus = userStatus;
	}

	@Override
	public String toString() {
		return "UserModel [userId=" + userId + ", dob=" + dob + ", email=" + email + ", loginId=" + loginId + ", name="
				+ name + ", nameFurigana=" + nameFurigana + ", password=" + password + ", passwordConfirm="
				+ passwordConfirm + ", phoneNumber=" + phoneNumber + ", sex=" + sex + ", userChilds=" + userChilds
				+ ", userStatus=" + userStatus + ", masterProfileId=" + masterProfileId + "]";
	}

	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}

	public String getTokenId() {
		return tokenId;
	}

	public void setTokenId(String tokenId) {
		this.tokenId = tokenId;
	}

	public String getHospitalName() {
		return hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public Long getMasterProfileId() {
		return masterProfileId;
	}

	public void setMasterProfileId(Long masterProfileId) {
		this.masterProfileId = masterProfileId;
	}

	public Boolean getIsFaceBook() {
		return isFaceBook;
	}

	public void setIsFaceBook(Boolean isFaceBook) {
		this.isFaceBook = isFaceBook;
	}
}