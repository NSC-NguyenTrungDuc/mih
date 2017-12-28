package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class DurationTypeStandardHealthModel {
	@JsonProperty("profile_id")
	private String profileId;
	
	@JsonProperty("height_info")
	List<HeightModel> heightInfo;
	
	@JsonProperty("weight_info")
	List<WeightModel> weightInfo;
	
	@JsonProperty("perc_fat_info")
	List<PercFatModel> percFatInfo;
	
	@JsonProperty("bmi_info")
	List<BmiModel> bmiInfo;

	public String getProfileId() {
		return profileId;
	}

	public void setProfileId(String profileId) {
		this.profileId = profileId;
	}

	public List<HeightModel> getHeightInfo() {
		return heightInfo;
	}

	public void setHeightInfo(List<HeightModel> heightInfo) {
		this.heightInfo = heightInfo;
	}

	public List<WeightModel> getWeightInfo() {
		return weightInfo;
	}

	public void setWeightInfo(List<WeightModel> weightInfo) {
		this.weightInfo = weightInfo;
	}

	public List<PercFatModel> getPercFatInfo() {
		return percFatInfo;
	}

	public void setPercFatInfo(List<PercFatModel> percFatInfo) {
		this.percFatInfo = percFatInfo;
	}

	public List<BmiModel> getBmiInfo() {
		return bmiInfo;
	}

	public void setBmiInfo(List<BmiModel> bmiInfo) {
		this.bmiInfo = bmiInfo;
	}

}
