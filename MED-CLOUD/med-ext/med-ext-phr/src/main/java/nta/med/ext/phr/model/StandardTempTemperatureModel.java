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
public class StandardTempTemperatureModel {

	@JsonProperty("temperature_id")
	private Long id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp dateMeasure;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("temperature")
	private BigDecimal temperature;

	@JsonProperty("note")
	private String note;

	@JsonProperty("count")
	private BigInteger count;

	public StandardTempTemperatureModel() {
		super();
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getDateMeasure() {
		return dateMeasure;
	}

	public void setDateMeasure(Timestamp dateMeasure) {
		this.dateMeasure = dateMeasure;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public BigDecimal getTemperature() {
		return temperature;
	}

	public void setTemperature(BigDecimal temperature) {
		this.temperature = temperature;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public BigInteger getCount() {
		return count;
	}

	public void setCount(BigInteger count) {
		this.count = count;
	}
}