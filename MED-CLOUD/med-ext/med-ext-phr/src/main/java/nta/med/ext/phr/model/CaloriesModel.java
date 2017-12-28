package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class CaloriesModel {
	

	@JsonProperty("food_id")
	private BigInteger foodId;

	@JsonProperty("rating_satisfied")
	private Integer rating;

	@JsonProperty("eating_time")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp eatingTime;

	@JsonProperty("calories")
	private BigDecimal kcal;

	@JsonProperty("note")
	private String note;

	public BigInteger getFoodId() {
		return foodId;
	}

	public void setFoodId(BigInteger foodId) {
		this.foodId = foodId;
	}

	public Integer getRating() {
		return rating;
	}

	public void setRating(Integer rating) {
		this.rating = rating;
	}

	public Timestamp getEatingTime() {
		return eatingTime;
	}

	public void setEatingTime(Timestamp eatingTime) {
		this.eatingTime = eatingTime;
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
}