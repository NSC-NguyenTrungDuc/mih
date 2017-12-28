package nta.med.ext.phr.model;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_ACCOUNT database table.
 * 
 */
public class SocialAccountModel {

	@JsonProperty("facebook_id")
	private BigInteger facebookId;

	@JsonProperty("access_token")
	private String accessToken;

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
	private String hospCode;

	private String  phone;
	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public BigInteger getFacebookId() {
		return facebookId;
	}

	public void setFacebookId(BigInteger facebookId) {
		this.facebookId = facebookId;
	}

	public String getAccessToken() {
		return accessToken;
	}

	public void setAccessToken(String accessToken) {
		this.accessToken = accessToken;
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

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Override
	public String toString() {
		return "SocialAccountModel [facebookId=" + facebookId + ", accessToken=" + accessToken + ", email=" + email
				+ ", name=" + name + ", birthday=" + birthday + ", gender=" + gender + ", profile_image_url="
				+ profile_image_url + "]";
	}
}