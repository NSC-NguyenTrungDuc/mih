package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_FOOD_MENU database table.
 * 
 */

public class StandardFoodMenuModel {
	
	@JsonProperty("id")
	private Long id;
	
	@NotNull(message = "eating_time.required")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	@JsonProperty("eating_time")
	
	private Timestamp eatingTime;

	@JsonProperty("from_hour")
	private Integer fromHour;

	@JsonProperty("full")
	private Integer full;

	@JsonProperty("image_url")
	private String imageUrl;

	@JsonProperty("calories")
	private BigDecimal kcal;
	
	@JsonProperty("carbohydrate")
	private BigDecimal carbohydrate;
	
	@JsonProperty("total_fat")
	private BigDecimal totalFat;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("rating")
	private Integer rating;

	@JsonProperty("to_hour")
	private Integer toHour;

	public StandardFoodMenuModel() {
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

	public Integer getFromHour() {
		return fromHour;
	}

	public void setFromHour(Integer fromHour) {
		this.fromHour = fromHour;
	}

	public Integer getFull() {
		return full;
	}

	public void setFull(Integer full) {
		this.full = full;
	}

	public String getImageUrl() {
		return imageUrl;
	}

	public void setImageUrl(String imageUrl) {
		this.imageUrl = imageUrl;
	}

	public BigDecimal getKcal() {
		return kcal;
	}

	public void setKcal(BigDecimal kcal) {
		this.kcal = kcal;
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

	public Integer getRating() {
		return rating;
	}

	public void setRating(Integer rating) {
		this.rating = rating;
	}

	public Integer getToHour() {
		return toHour;
	}

	public void setToHour(Integer toHour) {
		this.toHour = toHour;
	}

	public BigDecimal getCarbohydrate() {
		return carbohydrate;
	}

	public void setCarbohydrate(BigDecimal carbohydrate) {
		this.carbohydrate = carbohydrate;
	}

	public BigDecimal getTotalFat() {
		return totalFat;
	}

	public void setTotalFat(BigDecimal totalFat) {
		this.totalFat = totalFat;
	}
}