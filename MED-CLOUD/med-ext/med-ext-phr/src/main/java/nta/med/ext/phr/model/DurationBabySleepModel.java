package nta.med.ext.phr.model;

import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class DurationBabySleepModel {
	
	@JsonProperty("sleep_id")
	private BigInteger id;
	
	@JsonProperty("time_start_sleep")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp timeStartSleep;
	
	@JsonProperty("total_sleep_time")
	private Integer totalHourSleep;
	
	@JsonProperty("morning_time_sleep")
	private Integer morningTimeSleep;
	
	@JsonProperty("afternoon_time_sleep")
	private Integer afternoonTimeSleep;
	
	@JsonProperty("night_time_sleep")
	private Integer nightTimeSleep;
	
	@JsonIgnore
	private String message;
	
	public DurationBabySleepModel() {
		
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

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}