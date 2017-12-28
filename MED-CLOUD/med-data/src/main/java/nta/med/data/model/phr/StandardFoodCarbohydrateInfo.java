package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

public class StandardFoodCarbohydrateInfo {

	private BigInteger foodId;
	
	private Integer rating;

	private Timestamp eatingTime;

	private BigDecimal carbohydrate;

	private String note;
	
	private String perDay;

	public StandardFoodCarbohydrateInfo(BigInteger foodId, Integer rating, Timestamp eatingTime, BigDecimal carbohydrate, String note, String perDay) {
		super();
		this.foodId = foodId;
		this.rating = rating;
		this.eatingTime = eatingTime;
		this.carbohydrate = carbohydrate;
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

	public BigDecimal getCarbohydrate() {
		return carbohydrate;
	}

	public void setCarbohydrate(BigDecimal carbohydrate) {
		this.carbohydrate = carbohydrate;
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