package nta.med.data.model.phr;

import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class BabyFoodInfo {

	private BigInteger id;

	private Timestamp eatingTime;
	
	private String food;
	
	private String kcal;
	
	private String mealType;
	
	private String perDay;

	public BabyFoodInfo(BigInteger id, Timestamp eatingTime, String food, String kcal, String mealType, String perDay) {
		super();
		this.id = id;
		this.eatingTime = eatingTime;
		this.food = food;
		this.kcal = kcal;
		this.mealType = mealType;
		this.perDay = perDay;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
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

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}
}