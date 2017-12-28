package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class TemperatureInfoBaseOnTypeModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("temperature_info")
	private List<StandardTemperatureModel> standardTemperatureModel;
	
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

	public List<StandardTemperatureModel> getStandardTemperatureModel() {
		return standardTemperatureModel;
	}

	public void setStandardTemperatureModel(List<StandardTemperatureModel> standardTemperatureModel) {
		this.standardTemperatureModel = standardTemperatureModel;
	}
}
