package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
/**
 * The persistent class for the PHR_STANDARD_HEALTH database table.
 * 
 */

public class StandardHealthModel {

	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("health_id")
	private Long id;

	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	@JsonProperty("datetime_record")
	private Timestamp datetimeRecord;

	@JsonProperty("height")
	private BigDecimal height;

	@JsonProperty("weight")
	private BigDecimal weight;

	@JsonProperty("bmi")
	private BigDecimal bmi;

	@JsonProperty("perc_fat")
	private BigDecimal percFat;
	
	@JsonProperty("note")
	private String note;
	
	@JsonProperty("source")
	private String source;

	@JsonProperty("health_type")
	private String healthType;
	
	@JsonIgnore
	private String message;

	public StandardHealthModel() {
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

	public BigDecimal getHeight() {
		return height;
	}

	public void setHeight(BigDecimal height) {
		this.height = height;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public BigDecimal getPercFat() {
		return percFat;
	}

	public void setPercFat(BigDecimal percFat) {
		this.percFat = percFat;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public BigDecimal getWeight() {
		return weight;
	}

	public void setWeight(BigDecimal weight) {
		this.weight = weight;
	}

	public BigDecimal getBmi() {
		return bmi;
	}

	public void setBmi(BigDecimal bmi) {
		this.bmi = bmi;
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

	public String getHealthType() {
		return healthType;
	}

	public void setHealthType(String healthType) {
		this.healthType = healthType;
	}
}