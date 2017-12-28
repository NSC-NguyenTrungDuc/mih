package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class GrowthInfoBaseOnTypeModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("growth_info")
	private List<BabyGrowthHeightWeightModel> growthModel;
	
	@JsonIgnore
	private String message;

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}

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

	public List<BabyGrowthHeightWeightModel> getGrowthModel() {
		return growthModel;
	}

	public void setGrowthModel(List<BabyGrowthHeightWeightModel> growthModel) {
		this.growthModel = growthModel;
	}
}
