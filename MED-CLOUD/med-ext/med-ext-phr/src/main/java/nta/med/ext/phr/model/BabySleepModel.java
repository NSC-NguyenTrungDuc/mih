package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_BABY_SLEEP database table.
 * 
 */

public class BabySleepModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("alert")
	private BigDecimal alert;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("time_start_sleep")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	@NotNull(message = "TimeStartSleep is required")
	private Timestamp timeStartSleep;
	
	@JsonProperty("time_wake_up")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeWakeUp;

	@JsonProperty("total_hour_sleep")
	private Integer totalHourSleep;

	@JsonProperty("morning_time_sleep")
	private Integer morningTimeSleep;

	@JsonProperty("afternoon_time_sleep")
	private Integer afternoonTimeSleep;

	@JsonProperty("night_time_sleep")
	private Integer nightTimeSleep;

	public BabySleepModel() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
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

	public Timestamp getTimeStartSleep() {
		return timeStartSleep;
	}

	public void setTimeStartSleep(Timestamp timeStartSleep) {
		this.timeStartSleep = timeStartSleep;
	}

	public Timestamp getTimeWakeUp() {
		return timeWakeUp;
	}

	public void setTimeWakeUp(Timestamp timeWakeUp) {
		this.timeWakeUp = timeWakeUp;
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