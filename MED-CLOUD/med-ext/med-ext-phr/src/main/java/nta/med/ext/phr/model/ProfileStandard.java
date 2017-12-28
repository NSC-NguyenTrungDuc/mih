package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.Column;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class ProfileStandard {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("account_id")
	private Long accountId;

	@JsonProperty("active_profile_flg")
	private BigDecimal activeProfileFlg;

	@JsonProperty("address")
	private String address;

	@JsonProperty("baby_flg")
	private BigDecimal babyFlg;

	//@NotNull(message = "birthday.required")
	@JsonProperty("birthday")
	private String birthday;

	@JsonProperty("city")
	private String city;

	@JsonProperty("family_member_type")
	private String familyMemberType;

	@JsonProperty("full_name")
	private String fullName;

	@JsonProperty("full_name_kana")
	private String fullNameKana;

	@JsonProperty("locale")
	private String locale;

	@JsonProperty("nickname")
	private String nickname;

	@JsonProperty("occupation")
	private String occupation;

	@JsonProperty("picture_profile_url")
	private String pictureProfileUrl;

	@JsonProperty("prefecture")
	private String prefecture;

	@JsonProperty("relationship")
	private String relationship;

	@JsonProperty("zip_code")
	private String zipCode;

	@JsonIgnore
	//@JsonProperty("token")
	private String token;

	@JsonProperty("list_account_clinic")
	private List<AccountClinicModel> listAccountClinic;
	
	///@NotNull(message = "gender.required")
	@JsonProperty("gender")
	private String gender;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Long getAccountId() {
		return accountId;
	}

	public void setAccountId(Long accountId) {
		this.accountId = accountId;
	}

	public BigDecimal getActiveProfileFlg() {
		return activeProfileFlg;
	}

	public void setActiveProfileFlg(BigDecimal activeProfileFlg) {
		this.activeProfileFlg = activeProfileFlg;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public BigDecimal getBabyFlg() {
		return babyFlg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.babyFlg = babyFlg;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getFamilyMemberType() {
		return familyMemberType;
	}

	public void setFamilyMemberType(String familyMemberType) {
		this.familyMemberType = familyMemberType;
	}

	public String getFullName() {
		return fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	public String getFullNameKana() {
		return fullNameKana;
	}

	public void setFullNameKana(String fullNameKana) {
		this.fullNameKana = fullNameKana;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getNickname() {
		return nickname;
	}

	public void setNickname(String nickname) {
		this.nickname = nickname;
	}

	public String getOccupation() {
		return occupation;
	}

	public void setOccupation(String occupation) {
		this.occupation = occupation;
	}

	public String getPictureProfileUrl() {
		return pictureProfileUrl;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.pictureProfileUrl = pictureProfileUrl;
	}

	public String getPrefecture() {
		return prefecture;
	}

	public void setPrefecture(String prefecture) {
		this.prefecture = prefecture;
	}

	public String getRelationship() {
		return relationship;
	}

	public void setRelationship(String relationship) {
		this.relationship = relationship;
	}

	public String getZipCode() {
		return zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public List<AccountClinicModel> getListAccountClinic() {
		return listAccountClinic;
	}

	public void setListAccountClinic(List<AccountClinicModel> listAccountClinic) {
		this.listAccountClinic = listAccountClinic;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

}
