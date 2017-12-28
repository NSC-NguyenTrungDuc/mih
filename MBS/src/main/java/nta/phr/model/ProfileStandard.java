package nta.phr.model;

import java.math.BigDecimal;
import java.util.List;

public class ProfileStandard {

	private Long id;
	
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

	private String occupation;

	private String picture_profile_url;

	private String prefecture;

	private String relationship;

	private String zip_code;

	private List<AccountClinicModel> list_account_clinic;
	private String gender;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
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

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public BigDecimal getBaby_flg() {
		return baby_flg;
	}

	public void setBaby_flg(BigDecimal baby_flg) {
		this.baby_flg = baby_flg;
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

	public String getPicture_profile_url() {
		return picture_profile_url;
	}

	public void setPicture_profile_url(String picture_profile_url) {
		this.picture_profile_url = picture_profile_url;
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

	public String getZip_code() {
		return zip_code;
	}

	public void setZip_code(String zip_code) {
		this.zip_code = zip_code;
	}

	public List<AccountClinicModel> getList_account_clinic() {
		return list_account_clinic;
	}

	public void setList_account_clinic(List<AccountClinicModel> list_account_clinic) {
		this.list_account_clinic = list_account_clinic;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}
	
}
