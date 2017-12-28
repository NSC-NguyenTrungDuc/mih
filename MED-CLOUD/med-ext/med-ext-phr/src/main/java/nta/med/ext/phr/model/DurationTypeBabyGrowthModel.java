package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class DurationTypeBabyGrowthModel {

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("type")
	private String type;

	@JsonProperty("height_info")
	private List<BabyGrowthHeightModel> babyGrowthHeightModel;

	@JsonProperty("weight_info")
	private List<BabyGrowthWeightModel> babyGrowthWeightModel;

	@JsonIgnore
	private String message;

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public List<BabyGrowthHeightModel> getBabyGrowthHeightModel() {
		return babyGrowthHeightModel;
	}

	public void setBabyGrowthHeightModel(List<BabyGrowthHeightModel> babyGrowthHeightModel) {
		this.babyGrowthHeightModel = babyGrowthHeightModel;
	}

	public List<BabyGrowthWeightModel> getBabyGrowthWeightModel() {
		return babyGrowthWeightModel;
	}

	public void setBabyGrowthWeightModel(List<BabyGrowthWeightModel> babyGrowthWeightModel) {
		this.babyGrowthWeightModel = babyGrowthWeightModel;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}

}
