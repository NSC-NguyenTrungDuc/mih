package nta.med.ext.phr.model;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_ACCOUNT database table.
 * 
 */
// @JsonSerialize(include=JsonSerialize.Inclusion.NON_NULL)
public class PhrAccountModel {

	@JsonProperty("id")
	private Long id;
	@JsonProperty("hosp_code")
	private String hospcode;
	
	@JsonProperty("patient_code")
	private String patientcode;
	
	@JsonProperty("hosp_name")
	private String hospname;
	
	@JsonProperty("name")
	private String name;
	
	@JsonProperty("name_furigana")
	private String nameFurigana;
	
	@JsonProperty("phone_number")
	private String phoneNumber;
	
	
	public String getHospcode() {
		return hospcode;
	}

	public void setHospcode(String hospcode) {
		this.hospcode = hospcode;
	}

	public String getPatientcode() {
		return patientcode;
	}

	public void setPatientcode(String patientcode) {
		this.patientcode = patientcode;
	}

	public String getHospname() {
		return hospname;
	}

	public void setHospname(String hospname) {
		this.hospname = hospname;
	}

	@JsonProperty("baby_background_url")
	private String babyBackgroundUrl;

	@JsonProperty("email")
	private String email;

	@JsonProperty("password")
	private String password;

	@JsonProperty("new_password")
	private String newPassword;

	@JsonProperty("standard_background_url")
	private String standardBackgroundUrl;

	@JsonProperty("status")
	private BigDecimal status;

	@JsonProperty("type")
	private int type;
	
	@JsonProperty("login_type")
	private BigDecimal loginType;
	
	@JsonProperty("profile")
	private ProfileModel profile;

	@JsonProperty("baby_profile_id")
	private Long babyProfileId;

	@JsonProperty("standard_profile_id")
	private Long standardProfileId;

	@JsonProperty("token")
	private String token;
	
	@JsonProperty("gender")
	private String gender;
	
	@JsonProperty("baby_sync_flg")
	private BigDecimal babySyncFlg;
	
	@JsonProperty("baby_udid")
	private String babyUdid;
	
	@JsonProperty("standard_sync_flg")
	private BigDecimal standardSyncFlg;
	
	@JsonProperty("standard_udid")
	private String standardUdid;
	
	@JsonProperty("master_profile_id")
	private Long masterProfileId;
	
	@JsonProperty("udid")
	private String udid;

	@JsonIgnore
	private boolean resultIsVerify;
	@JsonIgnore
	private boolean resultIsChangePass;
	@JsonIgnore
	private boolean resultTokenInvalid;
	@JsonIgnore
	private boolean resultTokenIsRequired;
	
	@JsonProperty("phone")
	private String phone;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getBabyBackgroundUrl() {
		return babyBackgroundUrl;
	}

	public void setBabyBackgroundUrl(String babyBackgroundUrl) {
		this.babyBackgroundUrl = babyBackgroundUrl;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getNewPassword() {
		return newPassword;
	}

	public void setNewPassword(String newPassword) {
		this.newPassword = newPassword;
	}

	public String getStandardBackgroundUrl() {
		return standardBackgroundUrl;
	}

	public void setStandardBackgroundUrl(String standardBackgroundUrl) {
		this.standardBackgroundUrl = standardBackgroundUrl;
	}

	public BigDecimal getStatus() {
		return status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public ProfileModel getProfile() {
		return profile;
	}

	public void setProfile(ProfileModel profile) {
		this.profile = profile;
	}

	public Long getBabyProfileId() {
		return babyProfileId;
	}

	public void setBabyProfileId(Long babyProfileId) {
		this.babyProfileId = babyProfileId;
	}

	public Long getStandardProfileId() {
		return standardProfileId;
	}

	public void setStandardProfileId(Long standardProfileId) {
		this.standardProfileId = standardProfileId;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public boolean isResultIsVerify() {
		return resultIsVerify;
	}

	public void setResultIsVerify(boolean resultIsVerify) {
		this.resultIsVerify = resultIsVerify;
	}

	public boolean isResultIsChangePass() {
		return resultIsChangePass;
	}

	public void setResultIsChangePass(boolean resultIsChangePass) {
		this.resultIsChangePass = resultIsChangePass;
	}

	public boolean isResultTokenInvalid() {
		return resultTokenInvalid;
	}

	public void setResultTokenInvalid(boolean resultTokenInvalid) {
		this.resultTokenInvalid = resultTokenInvalid;
	}

	public boolean isResultTokenIsRequired() {
		return resultTokenIsRequired;
	}

	public void setResultTokenIsRequired(boolean resultTokenIsRequired) {
		this.resultTokenIsRequired = resultTokenIsRequired;
	}

	public BigDecimal getLoginType() {
		return loginType;
	}

	public void setLoginType(BigDecimal loginType) {
		this.loginType = loginType;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public BigDecimal getBabySyncFlg() {
		return babySyncFlg;
	}

	public void setBabySyncFlg(BigDecimal babySyncFlg) {
		this.babySyncFlg = babySyncFlg;
	}

	public String getBabyUdid() {
		return babyUdid;
	}

	public void setBabyUdid(String babyUdid) {
		this.babyUdid = babyUdid;
	}

	public BigDecimal getStandardSyncFlg() {
		return standardSyncFlg;
	}

	public void setStandardSyncFlg(BigDecimal standardSyncFlg) {
		this.standardSyncFlg = standardSyncFlg;
	}

	public String getStandardUdid() {
		return standardUdid;
	}

	public void setStandardUdid(String standardUdid) {
		this.standardUdid = standardUdid;
	}	

	public Long getMasterProfileId() {
		return masterProfileId;
	}

	public void setMasterProfileId(Long masterProfileId) {
		this.masterProfileId = masterProfileId;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
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

	@Override
	public String toString() {
		return "PhrAccountModel [id=" + id + ", babyBackgroundUrl=" + babyBackgroundUrl + ", email=" + email
				+ ", password=" + password + ", newPassword=" + newPassword + ", standardBackgroundUrl="
				+ standardBackgroundUrl + ", status=" + status + ", type=" + type + ", loginType=" + loginType
				+ ", profile=" + profile + ", babyProfileId=" + babyProfileId + ", standardProfileId="
				+ standardProfileId + ", token=" + token + ", gender=" + gender + ", resultIsVerify=" + resultIsVerify
				+ ", resultIsChangePass=" + resultIsChangePass + ", resultTokenInvalid=" + resultTokenInvalid
				+ ", resultTokenIsRequired=" + resultTokenIsRequired + ", phone=" + phone + "]";
	}
}