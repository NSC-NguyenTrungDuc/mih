package nta.phr.model;

import java.math.BigDecimal;
import java.util.List;




public class ProfileModel {
	private Long id;

	private String  phone;
	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public Long getAccount_id() {
		return account_id;
	}

	public void setAccount_id(Long account_id) {
		this.account_id = account_id;
	}

	public BigDecimal getActive_profile_flg() {
		return active_profile_flg;
	}

	public void setActive_profile_flg(BigDecimal active_profile_flg) {
		this.active_profile_flg = active_profile_flg;
	}

	public BigDecimal getBaby_flg() {
		return baby_flg;
	}

	public void setBaby_flg(BigDecimal baby_flg) {
		this.baby_flg = baby_flg;
	}

	public String getFamily_member_type() {
		return family_member_type;
	}

	public void setFamily_member_type(String family_member_type) {
		this.family_member_type = family_member_type;
	}

	public String getFull_name() {
		return full_name;
	}

	public void setFull_name(String full_name) {
		this.full_name = full_name;
	}

	public String getFull_name_kana() {
		return full_name_kana;
	}

	public void setFull_name_kana(String full_name_kana) {
		this.full_name_kana = full_name_kana;
	}

	public String getPicture_profile_url() {
		return picture_profile_url;
	}

	public void setPicture_profile_url(String picture_profile_url) {
		this.picture_profile_url = picture_profile_url;
	}

	public String getZip_code() {
		return zip_code;
	}

	public void setZip_code(String zip_code) {
		this.zip_code = zip_code;
	}

	public String getBaby_sync_id() {
		return baby_sync_id;
	}

	public void setBaby_sync_id(String baby_sync_id) {
		this.baby_sync_id = baby_sync_id;
	}

	public Integer getTotal_time_sleep() {
		return total_time_sleep;
	}

	public void setTotal_time_sleep(Integer total_time_sleep) {
		this.total_time_sleep = total_time_sleep;
	}

	public BigDecimal getStandard_sync_flg() {
		return standard_sync_flg;
	}

	public void setStandard_sync_flg(BigDecimal standard_sync_flg) {
		this.standard_sync_flg = standard_sync_flg;
	}

	private Long account_id;

	private BigDecimal active_profile_flg;

	private String address;

	private BigDecimal baby_flg;

	private String birthday;

	private String city;
	
	private String family_member_type;

	private String full_name;

	private String full_name_kana;

	private String locale;

	private String nickname;
	
	//@NotNull(message = "gender.required")
	private String gender;

	private String occupation;

	private String picture_profile_url;

	private String prefecture;

	private String relationship;

	private String zip_code;

	private String token;
	private String baby_sync_id;
	private Integer total_time_sleep;
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Long getAccountId() {
		return account_id;
	}

	public void setAccountId(Long accountId) {
		this.account_id = accountId;
	}

	public BigDecimal getActiveProfileFlg() {
		return active_profile_flg;
	}

	public void setActiveProfileFlg(BigDecimal activeProfileFlg) {
		this.active_profile_flg = activeProfileFlg;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public BigDecimal getBabyFlg() {
		return baby_flg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.baby_flg = babyFlg;
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
		return family_member_type;
	}

	public void setFamilyMemberType(String familyMemberType) {
		this.family_member_type = familyMemberType;
	}

	public String getFullName() {
		return full_name;
	}

	public void setFullName(String fullName) {
		this.full_name = fullName;
	}

	public String getFullNameKana() {
		return full_name_kana;
	}

	public void setFullNameKana(String fullNameKana) {
		this.full_name_kana = fullNameKana;
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

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getOccupation() {
		return occupation;
	}

	public void setOccupation(String occupation) {
		this.occupation = occupation;
	}

	public String getPictureProfileUrl() {
		return picture_profile_url;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.picture_profile_url = pictureProfileUrl;
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
		return zip_code;
	}

	public void setZipCode(String zipCode) {
		this.zip_code = zipCode;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public BigDecimal getBmi() {
		return bmi;
	}

	public void setBmi(BigDecimal bmi) {
		this.bmi = bmi;
	}

	public BigDecimal getKcal() {
		return kcal;
	}

	public void setKcal(BigDecimal kcal) {
		this.kcal = kcal;
	}

	public BigDecimal getTemperature() {
		return temperature;
	}

	public void setTemperature(BigDecimal temperature) {
		this.temperature = temperature;
	}

	public String getQuantity() {
		return quantity;
	}

	public void setQuantity(String quantity) {
		this.quantity = quantity;
	}

	public String getMethod() {
		return method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public Integer getTotalTimeSleep() {
		return total_time_sleep;
	}

	public void setTotalTimeSleep(Integer totalTimeSleep) {
		this.total_time_sleep = totalTimeSleep;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public BigDecimal getSyncFlg() {
		return standard_sync_flg;
	}

	public void setSyncFlg(BigDecimal syncFlg) {
		this.standard_sync_flg = syncFlg;
	}

	private BigDecimal bmi;

	private BigDecimal kcal;

	private BigDecimal temperature;

	private String quantity;

	private String method;
	
	private String udid;
	
	private BigDecimal standard_sync_flg;

	
}
