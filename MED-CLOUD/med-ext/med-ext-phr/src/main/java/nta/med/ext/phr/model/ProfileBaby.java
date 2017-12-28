package nta.med.ext.phr.model;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class ProfileBaby {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("account_id")
	private Long accountId;

	@JsonProperty("active_profile_flg")
	private BigDecimal activeProfileFlg;

	@JsonProperty("baby_flg")
	private BigDecimal babyFlg;

	@JsonProperty("birthday")
	private String birthday;

	@JsonProperty("full_name")
	private String fullName;

	@JsonProperty("full_name_kana")
	private String fullNameKana;

	@JsonProperty("locale")
	private String locale;

	@JsonProperty("nickname")
	private String nickname;

	@JsonProperty("picture_profile_url")
	private String pictureProfileUrl;

	@JsonProperty("relationship")
	private String relationship;

	@JsonProperty("gender")
	private String gender;
	
	@JsonProperty("age")
	private BigDecimal age;

	@JsonProperty("baby_growth_height_mode")
	private BabyGrowthHeightModel babyGrowthHeightModel;
	
	@JsonProperty("baby_growth_weight_mode")
	private BabyGrowthWeightModel babyGrowthWeightModel;

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

	public String getPictureProfileUrl() {
		return pictureProfileUrl;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.pictureProfileUrl = pictureProfileUrl;
	}

	public String getRelationship() {
		return relationship;
	}

	public void setRelationship(String relationship) {
		this.relationship = relationship;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public BigDecimal getAge() {
		return age;
	}

	public void setAge(BigDecimal age) {
		this.age = age;
	}

	public BabyGrowthHeightModel getBabyGrowthHeightModel() {
		return babyGrowthHeightModel;
	}

	public void setBabyGrowthHeightModel(BabyGrowthHeightModel babyGrowthHeightModel) {
		this.babyGrowthHeightModel = babyGrowthHeightModel;
	}

	public BabyGrowthWeightModel getBabyGrowthWeightModel() {
		return babyGrowthWeightModel;
	}

	public void setBabyGrowthWeightModel(BabyGrowthWeightModel babyGrowthWeightModel) {
		this.babyGrowthWeightModel = babyGrowthWeightModel;
	}
}
