package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class DurationTypeStandardFoodModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("calories_info")
	List<CaloriesModel> caloriesInfo;
	
	@JsonProperty("carbohydrate_info")
	List<CarbohydrateModel> carbohydrateInfo;
	
	@JsonProperty("total_fat_info")
	List<TotalFatModel> totalFatInfo;
	
	@JsonIgnore
	private String message;
	
	public DurationTypeStandardFoodModel() {
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

	public List<CaloriesModel> getCaloriesInfo() {
		return caloriesInfo;
	}

	public void setCaloriesInfo(List<CaloriesModel> caloriesInfo) {
		this.caloriesInfo = caloriesInfo;
	}

	public List<CarbohydrateModel> getCarbohydrateInfo() {
		return carbohydrateInfo;
	}

	public void setCarbohydrateInfo(List<CarbohydrateModel> carbohydrateInfo) {
		this.carbohydrateInfo = carbohydrateInfo;
	}

	public List<TotalFatModel> getTotalFatInfo() {
		return totalFatInfo;
	}

	public void setTotalFatInfo(List<TotalFatModel> totalFatInfo) {
		this.totalFatInfo = totalFatInfo;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}