package nta.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.math.BigInteger;

/**
 * The persistent class for the PHR_ACCOUNT database table.
 * 
 */
public class SocialAccountModel {


	private BigInteger facebook_id;

	@JsonProperty("token")
	private String token;
	
	@JsonProperty("access_token")
	private String access_token;

	@JsonProperty("email")
	private String email;

	@JsonProperty("name")
	private String name;

	@JsonProperty("birthday")
	private String birthday;

	@JsonProperty("gender")
	private String gender;

	@JsonProperty("profile_image_url")
	private String profile_image_url;
	
	@JsonProperty("udid")
	private String udid;

	@JsonProperty("hosp_code")
	private String hosp_code;

	@JsonProperty("master_profile_id")
	private Long master_profile_id;

	private String  phone;
	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	public BigInteger getFacebook_id() {
		return facebook_id;
	}

	public void setFacebook_id(BigInteger facebook_id) {
		this.facebook_id = facebook_id;
	}

	public String getAccess_token() {
		return access_token;
	}

	public void setAccess_token(String access_token) {
		this.access_token = access_token;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getProfile_image_url() {
		return profile_image_url;
	}

	public void setProfile_image_url(String profile_image_url) {
		this.profile_image_url = profile_image_url;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public String getHosp_code() {
		return hosp_code;
	}

	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}

	public Long getMaster_profile_id() {
		return master_profile_id;
	}

	public void setMaster_profile_id(Long master_profile_id) {
		this.master_profile_id = master_profile_id;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}
	
}
