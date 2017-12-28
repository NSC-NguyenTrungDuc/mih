package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardTempBpModel {

	@JsonProperty("temperature_id")
	private Long id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp dateMeasure;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("low_blood_pressure")
	private BigDecimal bpFrom;

	@JsonProperty("high_blood_pressure")
	private BigDecimal bpTo;

	@JsonProperty("note")
	private String note;

	public StandardTempBpModel() {
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
}