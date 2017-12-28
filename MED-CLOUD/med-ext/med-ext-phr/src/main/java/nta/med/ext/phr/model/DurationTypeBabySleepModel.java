package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class DurationTypeBabySleepModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("baby_sleep_info")
	List<DurationBabySleepModel> durationBabySleepModel;
	
	@JsonIgnore
	private String message;
	
	public DurationTypeBabySleepModel() {
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public List<DurationBabySleepModel> getDurationBabySleepModel() {
		return durationBabySleepModel;
	}

	public void setDurationBabySleepModel(List<DurationBabySleepModel> durationBabySleepModel) {
		this.durationBabySleepModel = durationBabySleepModel;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}