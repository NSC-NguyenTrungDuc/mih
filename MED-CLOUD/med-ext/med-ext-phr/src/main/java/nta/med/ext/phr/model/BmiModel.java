package nta.med.ext.phr.model;

import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class BmiModel {
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("bmi_data")
	private String bmiData;
	
	@JsonProperty("health_id")
	private String healthId;
	
	@JsonProperty("datetime_record")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp datetimeRecord;
	
	@JsonProperty("bmi")
	private String bmi;
	
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

	public String getBmiData() {
		return bmiData;
	}

	public void setBmiData(String bmiData) {
		this.bmiData = bmiData;
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

	public String getBmi() {
		return bmi;
	}

	public void setBmi(String bmi) {
		this.bmi = bmi;
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
