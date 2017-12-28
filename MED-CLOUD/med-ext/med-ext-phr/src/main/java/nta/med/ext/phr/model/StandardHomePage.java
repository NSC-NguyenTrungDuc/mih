package nta.med.ext.phr.model;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class StandardHomePage {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("account_id")
	private Long accountId;

	@JsonProperty("active_profile_flg")
	private BigDecimal activeProfileFlg;

	@JsonProperty("baby_flg")
	private BigDecimal babyFlg;

	@JsonProperty("full_name")
	private String fullName;

	@JsonProperty("full_name_kana")
	private String fullNameKana;

	@JsonProperty("nickname")
	private String nickname;

	@JsonProperty("picture_profile_url")
	private String pictureProfileUrl;

	@JsonProperty("birthday")
	private String birthday;
	
	@JsonProperty("gender")
	private String gender;
	
	@JsonProperty("age")
	private BigDecimal age;

	//1. Get Health data
	@JsonProperty("lastest_height")
	private HeightModel  standardHealthHeightModel;
	
	@JsonProperty("lastest_weight")
	private WeightModel  standardHealthWeightModel;
	
	@JsonProperty("lastest_bmi")
	private BmiModel  standardHealthBmiModel;
	
	@JsonProperty("lastest_perc_fat")
	private PercFatModel  standardHealthBfpModel;
	
	//2. Get Food data
	@JsonProperty("lastest_calories")
	private CaloriesModel  standardFoodCaloryModel;
	
	@JsonProperty("lastest_carbohydrate")
	private CarbohydrateModel  standardFoodCarbohydrateModel;
	
	@JsonProperty("lastest_total_fat")
	private TotalFatModel  standardFoodTotalFatModel;
	
	//3. Get Temperature/ Physiological data
	@JsonProperty("lastest_temperature")
	private StandardTempTemperatureModel  standardTempTemperatureModel;
	
	@JsonProperty("lastest_heartrate")
	private StandardTempHeartrateModel  standardTempHeartrateModel;
	
	@JsonProperty("lastest_breath")
	private StandardTempBreathModel  standardTempBreathModel;
	
	@JsonProperty("lastest_blood_pressure")
	private StandardTempBpModel  standardTempBpModel;
	
	//4. Get Fitness data
	@JsonProperty("lastest_steps_count")
	private StandardFitnessStepModel  standardFitnessStepModel;
	
	@JsonProperty("lastest_walk_run_distance")
	private StandardFitnessDistanceModel  standardFitnessDistanceModel;
	
	//5. Get life style note
	@JsonProperty("lastest_sleep")
	private StandardLifeDataStyleNoteModel  standardLifeStyleModel;

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

	public BigDecimal getAge() {
		return age;
	}

	public void setAge(BigDecimal age) {
		this.age = age;
	}

	public HeightModel getStandardHealthHeightModel() {
		return standardHealthHeightModel;
	}

	public void setStandardHealthHeightModel(HeightModel standardHealthHeightModel) {
		this.standardHealthHeightModel = standardHealthHeightModel;
	}

	public WeightModel getStandardHealthWeightModel() {
		return standardHealthWeightModel;
	}

	public void setStandardHealthWeightModel(WeightModel standardHealthWeightModel) {
		this.standardHealthWeightModel = standardHealthWeightModel;
	}

	public BmiModel getStandardHealthBmiModel() {
		return standardHealthBmiModel;
	}

	public void setStandardHealthBmiModel(BmiModel standardHealthBmiModel) {
		this.standardHealthBmiModel = standardHealthBmiModel;
	}

	public PercFatModel getStandardHealthBfpModel() {
		return standardHealthBfpModel;
	}

	public void setStandardHealthBfpModel(PercFatModel standardHealthBfpModel) {
		this.standardHealthBfpModel = standardHealthBfpModel;
	}

	public CaloriesModel getStandardFoodCaloryModel() {
		return standardFoodCaloryModel;
	}

	public void setStandardFoodCaloryModel(CaloriesModel standardFoodCaloryModel) {
		this.standardFoodCaloryModel = standardFoodCaloryModel;
	}

	public CarbohydrateModel getStandardFoodCarbohydrateModel() {
		return standardFoodCarbohydrateModel;
	}

	public void setStandardFoodCarbohydrateModel(CarbohydrateModel standardFoodCarbohydrateModel) {
		this.standardFoodCarbohydrateModel = standardFoodCarbohydrateModel;
	}

	public TotalFatModel getStandardFoodTotalFatModel() {
		return standardFoodTotalFatModel;
	}

	public void setStandardFoodTotalFatModel(TotalFatModel standardFoodTotalFatModel) {
		this.standardFoodTotalFatModel = standardFoodTotalFatModel;
	}

	public StandardTempTemperatureModel getStandardTempTemperatureModel() {
		return standardTempTemperatureModel;
	}

	public void setStandardTempTemperatureModel(StandardTempTemperatureModel standardTempTemperatureModel) {
		this.standardTempTemperatureModel = standardTempTemperatureModel;
	}

	public StandardTempHeartrateModel getStandardTempHeartrateModel() {
		return standardTempHeartrateModel;
	}

	public void setStandardTempHeartrateModel(StandardTempHeartrateModel standardTempHeartrateModel) {
		this.standardTempHeartrateModel = standardTempHeartrateModel;
	}

	public StandardTempBreathModel getStandardTempBreathModel() {
		return standardTempBreathModel;
	}

	public void setStandardTempBreathModel(StandardTempBreathModel standardTempBreathModel) {
		this.standardTempBreathModel = standardTempBreathModel;
	}

	public StandardTempBpModel getStandardTempBpModel() {
		return standardTempBpModel;
	}

	public void setStandardTempBpModel(StandardTempBpModel standardTempBpModel) {
		this.standardTempBpModel = standardTempBpModel;
	}

	public StandardFitnessStepModel getStandardFitnessStepModel() {
		return standardFitnessStepModel;
	}

	public void setStandardFitnessStepModel(StandardFitnessStepModel standardFitnessStepModel) {
		this.standardFitnessStepModel = standardFitnessStepModel;
	}

	public StandardFitnessDistanceModel getStandardFitnessDistanceModel() {
		return standardFitnessDistanceModel;
	}

	public void setStandardFitnessDistanceModel(StandardFitnessDistanceModel standardFitnessDistanceModel) {
		this.standardFitnessDistanceModel = standardFitnessDistanceModel;
	}

	public StandardLifeDataStyleNoteModel getStandardLifeStyleModel() {
		return standardLifeStyleModel;
	}

	public void setStandardLifeStyleModel(StandardLifeDataStyleNoteModel standardLifeStyleModel) {
		this.standardLifeStyleModel = standardLifeStyleModel;
	}
}

