package nta.med.ext.phr.model;

import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_BABY_FOOD database table.
 * 
 */

public class BabyFoodModel {

	@JsonProperty("food_id")
	private Long id;

	@JsonProperty("eating_time")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp eatingTime;

	@JsonProperty("food")
	private String food;

	@JsonProperty("image_url")
	private String imageUrl;

	@JsonProperty("calories")
	private String kcal;

	@JsonProperty("meal_type")
	private String mealType;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	public BabyFoodModel() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getEatingTime() {
		return eatingTime;
	}

	public void setEatingTime(Timestamp eatingTime) {
		this.eatingTime = eatingTime;
	}

	public String getFood() {
		return food;
	}

	public void setFood(String food) {
		this.food = food;
	}

	public String getImageUrl() {
		return imageUrl;
	}

	public void setImageUrl(String imageUrl) {
		this.imageUrl = imageUrl;
	}

	public String getKcal() {
		return kcal;
	}

	public void setKcal(String kcal) {
		this.kcal = kcal;
	}

	public String getMealType() {
		return mealType;
	}

	public void setMealType(String mealType) {
		this.mealType = mealType;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}
}