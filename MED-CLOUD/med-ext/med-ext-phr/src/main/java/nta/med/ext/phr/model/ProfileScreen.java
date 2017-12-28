package nta.med.ext.phr.model;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class ProfileScreen {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("full_name")
	private String fullName;

	@JsonProperty("full_name_kana")
	private String fullNameKana;

	@JsonProperty("nickname")
	private String nickname;

	@JsonProperty("picture_profile_url")
	private String pictureProfileUrl;

	@JsonProperty("active_profile_flg")
	private BigDecimal activeProfileFlg;

	@JsonProperty("baby_flg")
	private BigDecimal babyFlg;
	
	@JsonProperty("family_member_type")
	private String familyMemberType;
	
	@JsonProperty("udid")
	private String udid;
	
	@JsonProperty("master_flg")
	private Integer masterFlg;

	@JsonProperty("birthday")
	private String birthday;
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
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

	public String getNickname() {
		return nickname;
	}

	public void setNickname(String nickname) {
		this.nickname = nickname;
	}

	public String getPictureProfileUrl() {
		return pictureProfileUrl;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.pictureProfileUrl = pictureProfileUrl;
	}

	public BigDecimal getActiveProfileFlg() {
		return activeProfileFlg;
	}

	public void setActiveProfileFlg(BigDecimal activeProfileFlg) {
		this.activeProfileFlg = activeProfileFlg;
	}

	public BigDecimal getBabyFlg() {
		return babyFlg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.babyFlg = babyFlg;
	}
	
	public String getFamilyMemberType() {
		return familyMemberType;
	}

	public void setFamilyMemberType(String familyMemberType) {
		this.familyMemberType = familyMemberType;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public Integer getMasterFlg() {
		return masterFlg;
	}

	public void setMasterFlg(Integer masterFlg) {
		this.masterFlg = masterFlg;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}
}
