package nta.med.data.model.phr;

import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class BabySleepInfo {

	private BigInteger id;

	private Timestamp timeStartSleep;

	private Integer totalHourSleep;

	private Integer morningTimeSleep;

	private Integer afternoonTimeSleep;

	private Integer nightTimeSleep;
	
	private String perDay;

	public BabySleepInfo(BigInteger id, Timestamp timeStartSleep, Integer totalHourSleep, Integer morningTimeSleep,
			Integer afternoonTimeSleep, Integer nightTimeSleep, String perDay) {
		super();
		this.id = id;
		this.timeStartSleep = timeStartSleep;
		this.totalHourSleep = totalHourSleep;
		this.morningTimeSleep = morningTimeSleep;
		this.afternoonTimeSleep = afternoonTimeSleep;
		this.nightTimeSleep = nightTimeSleep;
		this.perDay = perDay;
	}

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Timestamp getTimeStartSleep() {
		return timeStartSleep;
	}

	public void setTimeStartSleep(Timestamp timeStartSleep) {
		this.timeStartSleep = timeStartSleep;
	}

	public Integer getTotalHourSleep() {
		return totalHourSleep;
	}

	public void setTotalHourSleep(Integer totalHourSleep) {
		this.totalHourSleep = totalHourSleep;
	}

	public Integer getMorningTimeSleep() {
		return morningTimeSleep;
	}

	public void setMorningTimeSleep(Integer morningTimeSleep) {
		this.morningTimeSleep = morningTimeSleep;
	}

	public Integer getAfternoonTimeSleep() {
		return afternoonTimeSleep;
	}

	public void setAfternoonTimeSleep(Integer afternoonTimeSleep) {
		this.afternoonTimeSleep = afternoonTimeSleep;
	}

	public Integer getNightTimeSleep() {
		return nightTimeSleep;
	}

	public void setNightTimeSleep(Integer nightTimeSleep) {
		this.nightTimeSleep = nightTimeSleep;
	}
}