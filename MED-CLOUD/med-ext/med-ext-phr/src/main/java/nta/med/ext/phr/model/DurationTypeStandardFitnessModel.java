package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class DurationTypeStandardFitnessModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("steps_count_info")
	private List<StandardFitnessStepModel> standardFitnessStepModel;

	@JsonProperty("walk_run_distance_info")
	private List<StandardFitnessDistanceModel> standardFitnessDistanceModel;
	
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

	public List<StandardFitnessStepModel> getStandardFitnessStepModel() {
		return standardFitnessStepModel;
	}

	public void setStandardFitnessStepModel(List<StandardFitnessStepModel> standardFitnessStepModel) {
		this.standardFitnessStepModel = standardFitnessStepModel;
	}

	public List<StandardFitnessDistanceModel> getStandardFitnessDistanceModel() {
		return standardFitnessDistanceModel;
	}

	public void setStandardFitnessDistanceModel(List<StandardFitnessDistanceModel> standardFitnessDistanceModel) {
		this.standardFitnessDistanceModel = standardFitnessDistanceModel;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}
