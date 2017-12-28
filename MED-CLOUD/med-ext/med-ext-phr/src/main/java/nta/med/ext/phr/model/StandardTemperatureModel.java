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
public class StandardTemperatureModel {

	@JsonProperty("temperature_id")
	private Long id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp dateMeasure;

	@JsonProperty("temperature")
	private BigDecimal temperature;

	@JsonProperty("pulse")
	private BigDecimal heartrate;

	@JsonProperty("breath")
	private BigDecimal breath;

	@JsonProperty("low_blood_pressure")
	private BigDecimal bpFrom;

	@JsonProperty("high_blood_pressure")
	private BigDecimal bpTo;

	@JsonProperty("note")
	private String note;
	
	@JsonProperty("source")
	private String source;
	
	@JsonIgnore
	private String message;

	public StandardTemperatureModel() {
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

	public BigDecimal getTemperature() {
		return temperature;
	}

	public void setTemperature(BigDecimal temperature) {
		this.temperature = temperature;
	}

	public BigDecimal getHeartrate() {
		return heartrate;
	}

	public void setHeartrate(BigDecimal heartrate) {
		this.heartrate = heartrate;
	}

	public BigDecimal getBreath() {
		return breath;
	}

	public void setBreath(BigDecimal breath) {
		this.breath = breath;
	}

	public BigDecimal getBpFrom() {
		return bpFrom;
	}

	public void setBpFrom(BigDecimal bpFrom) {
		this.bpFrom = bpFrom;
	}

	public BigDecimal getBpTo() {
		return bpTo;
	}

	public void setBpTo(BigDecimal bpTo) {
		this.bpTo = bpTo;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}