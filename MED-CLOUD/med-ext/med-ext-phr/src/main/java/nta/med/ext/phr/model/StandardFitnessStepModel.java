package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardFitnessStepModel {

	@JsonProperty("fitness_id")
	private BigInteger id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp datetimeRecord;

	@JsonProperty("steps_count")
	private BigDecimal stepsCount;

	@JsonProperty("note")
	private String note;

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
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

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}
}