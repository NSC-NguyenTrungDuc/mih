package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class TotalFatModel {
	
	@JsonProperty("food_id")
	private BigInteger foodId;

	@JsonProperty("rating_satisfied")
	private Integer rating;

	@JsonProperty("eating_time")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp eatingTime;

	@JsonProperty("total_fat")
	private BigDecimal totalFat;

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

	public BigDecimal getTotalFat() {
		return totalFat;
	}

	public void setTotalFat(BigDecimal totalFat) {
		this.totalFat = totalFat;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}
}