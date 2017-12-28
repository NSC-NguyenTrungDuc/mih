package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class HealthInfoBaseOnTypeModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("health_info")
	private List<HealthDataModel> healthInfo;

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

	public List<HealthDataModel> getHealthInfo() {
		return healthInfo;
	}

	public void setHealthInfo(List<HealthDataModel> healthInfo) {
		this.healthInfo = healthInfo;
	}
}
