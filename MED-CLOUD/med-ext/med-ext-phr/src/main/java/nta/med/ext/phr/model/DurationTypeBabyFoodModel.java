package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class DurationTypeBabyFoodModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("baby_food_info")
	List<DurationBabyFoodModel> durationBabyFoodModel;
	
	@JsonIgnore
	private String message;

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public List<DurationBabyFoodModel> getDurationBabyFoodModel() {
		return durationBabyFoodModel;
	}

	public void setDurationBabyFoodModel(List<DurationBabyFoodModel> durationBabyFoodModel) {
		this.durationBabyFoodModel = durationBabyFoodModel;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}