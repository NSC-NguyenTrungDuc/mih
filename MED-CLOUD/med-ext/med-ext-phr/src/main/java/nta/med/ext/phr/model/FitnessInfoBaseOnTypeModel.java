package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class FitnessInfoBaseOnTypeModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("fitness_data")
	private List<StandardFitnessModel> standardFitnessModel;

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

	public List<StandardFitnessModel> getStandardFitnessModel() {
		return standardFitnessModel;
	}

	public void setStandardFitnessModel(List<StandardFitnessModel> standardFitnessModel) {
		this.standardFitnessModel = standardFitnessModel;
	}
}
