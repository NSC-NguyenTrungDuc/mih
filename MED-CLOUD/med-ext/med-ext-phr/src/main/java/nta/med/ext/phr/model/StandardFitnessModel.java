package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardFitnessModel {
	
	@JsonProperty("fitness_id")
	private Long id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp datetimeRecord;

	@JsonProperty("steps_count")
	private BigDecimal stepsCount;

	@JsonProperty("walk_run_distance")
	private BigDecimal walkRunDistance;

	@JsonProperty("note")
	private String note;
	
	@JsonProperty("source")
	private String source;
	
	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}
	
	@JsonIgnore
	private String message;

	public StandardFitnessModel() {
		super();
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public BigDecimal getStepsCount() {
		return stepsCount;
	}

	public void setStepsCount(BigDecimal stepsCount) {
		this.stepsCount = stepsCount;
	}

	public BigDecimal getWalkRunDistance() {
		return walkRunDistance;
	}

	public void setWalkRunDistance(BigDecimal walkRunDistance) {
		this.walkRunDistance = walkRunDistance;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}