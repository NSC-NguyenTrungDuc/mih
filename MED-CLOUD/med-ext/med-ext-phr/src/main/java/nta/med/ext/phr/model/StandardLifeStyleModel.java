package nta.med.ext.phr.model;

import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_STANDARD_LIFE_STYLE database table.
 * 
 */
public class StandardLifeStyleModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("rating_sleep")
	private Integer ratingSleep;

	@JsonProperty("time_awake")
	private Integer timeAwake;
	
	@JsonProperty("time_start_sleep")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeStartSleep;

	@JsonProperty("time_wake_up")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeWakeUp;

	@JsonProperty("total_hour_sleep")
	private Integer totalHourSleep;
	
	@JsonProperty("source")
	private String source;
	
	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public StandardLifeStyleModel() {

	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
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

	public Integer getRatingSleep() {
		return ratingSleep;
	}

	public void setRatingSleep(Integer ratingSleep) {
		this.ratingSleep = ratingSleep;
	}

	public Integer getTimeAwake() {
		return timeAwake;
	}

	public void setTimeAwake(Integer timeAwake) {
		this.timeAwake = timeAwake;
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
}