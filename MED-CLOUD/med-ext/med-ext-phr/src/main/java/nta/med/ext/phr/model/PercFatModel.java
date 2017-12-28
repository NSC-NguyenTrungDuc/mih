package nta.med.ext.phr.model;

import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class PercFatModel {
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("perc_fat_data")
	private String percFatData;
	
	@JsonProperty("health_id")
	private String healthId;
	
	@JsonProperty("datetime_record")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp datetimeRecord;
	
	@JsonProperty("perc_fat")
	private String percFat;
	
	@JsonProperty("note")
	private String note;

	@JsonProperty("count")
	private BigInteger count;

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getPercFatData() {
		return percFatData;
	}

	public void setPercFatData(String percFatData) {
		this.percFatData = percFatData;
	}

	public String getHealthId() {
		return healthId;
	}

	public void setHealthId(String healthId) {
		this.healthId = healthId;
	}

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public String getPercFat() {
		return percFat;
	}

	public void setPercFat(String percFat) {
		this.percFat = percFat;
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
