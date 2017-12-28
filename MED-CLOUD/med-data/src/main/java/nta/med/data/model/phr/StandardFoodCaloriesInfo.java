package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

public class StandardFoodCaloriesInfo {

	private BigInteger foodId;
	
	private Integer rating;

	private Timestamp eatingTime;

	private BigDecimal kcal;

	private String note;
	
	private String perDay;

	public StandardFoodCaloriesInfo(BigInteger foodId, Integer rating, Timestamp eatingTime, BigDecimal kcal, String note, String perDay) {
		super();
		this.foodId = foodId;
		this.rating = rating;
		this.eatingTime = eatingTime;
		this.kcal = kcal;
		this.note = note;
		this.perDay = perDay;
	}


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

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}
}