package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.Column;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_PROFILE database table.
 * 
 */

public class ProfileModel {

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

	@JsonProperty("birthday")
	//@NotNull(message = "birthday.required")
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
	
	@JsonProperty("gender")
	//@NotNull(message = "gender.required")
	private String gender;

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

	@JsonProperty("token")
	private String token;

	@JsonProperty("baby_growth_model")
	private BabyGrowthModel babyGrowthModel;

	@JsonProperty("bmi")
	private BigDecimal bmi;

	@JsonProperty("calories")
	private BigDecimal kcal;

	@JsonProperty("temperature")
	private BigDecimal temperature;

	@JsonProperty("quantity")
	private String quantity;

	@JsonProperty("method")
	private String method;

	@JsonProperty("total_time_sleep")
	private Integer totalTimeSleep;
	
	@JsonProperty("baby_sync_id")
	private String udid;
	
	@JsonProperty("standard_sync_flg")
	private BigDecimal syncFlg;
	
	@JsonProperty("phone")
	private String phone;

	private List<StandardFoodMenuModel> listFoodMenuModel;

	private List<BabyMilkModel> listBabyMilk;

	private List<BabyFoodModel> listBabyFood;

	private List<BabyDiaperModel> listBabyDiaper;

	private List<MedicineModel> listMedicine;

	private List<BabyGrowthModel> listBabyGrowth;

	private List<AccountClinicModel> listAccountClinic;

	private List<BabySleepModel> listBabySleep;

	public ProfileModel() {
	}

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

	public BabyGrowthModel getBabyGrowthModel() {
		return babyGrowthModel;
	}

	public void setBabyGrowthModel(BabyGrowthModel babyGrowthModel) {
		this.babyGrowthModel = babyGrowthModel;
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
		return totalTimeSleep;
	}

	public void setTotalTimeSleep(Integer totalTimeSleep) {
		this.totalTimeSleep = totalTimeSleep;
	}

	public List<StandardFoodMenuModel> getListFoodMenuModel() {
		return listFoodMenuModel;
	}

	public void setListFoodMenuModel(
			List<StandardFoodMenuModel> listFoodMenuModel) {
		this.listFoodMenuModel = listFoodMenuModel;
	}

	public List<BabyMilkModel> getListBabyMilk() {
		return listBabyMilk;
	}

	public void setListBabyMilk(List<BabyMilkModel> listBabyMilk) {
		this.listBabyMilk = listBabyMilk;
	}

	public List<BabyFoodModel> getListBabyFood() {
		return listBabyFood;
	}

	public void setListBabyFood(List<BabyFoodModel> listBabyFood) {
		this.listBabyFood = listBabyFood;
	}

	public List<BabyDiaperModel> getListBabyDiaper() {
		return listBabyDiaper;
	}

	public void setListBabyDiaper(List<BabyDiaperModel> listBabyDiaper) {
		this.listBabyDiaper = listBabyDiaper;
	}

	public List<MedicineModel> getListMedicine() {
		return listMedicine;
	}

	public void setListMedicine(List<MedicineModel> listMedicine) {
		this.listMedicine = listMedicine;
	}

	public List<BabyGrowthModel> getListBabyGrowth() {
		return listBabyGrowth;
	}

	public void setListBabyGrowth(List<BabyGrowthModel> listBabyGrowth) {
		this.listBabyGrowth = listBabyGrowth;
	}

	public List<AccountClinicModel> getListAccountClinic() {
		return listAccountClinic;
	}

	public void setListAccountClinic(List<AccountClinicModel> listAccountClinic) {
		this.listAccountClinic = listAccountClinic;
	}

	public List<BabySleepModel> getListBabySleep() {
		return listBabySleep;
	}

	public void setListBabySleep(List<BabySleepModel> listBabySleep) {
		this.listBabySleep = listBabySleep;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public BigDecimal getSyncFlg() {
		return syncFlg;
	}

	public void setSyncFlg(BigDecimal syncFlg) {
		this.syncFlg = syncFlg;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	
}