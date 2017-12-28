package nta.med.ext.phr.model;

import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class HealthDataModel {
	@JsonProperty("health_id")
	private Long id;
	
	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp datetimeRecord;
	
	@JsonProperty("bmi")
	private String bmi;
	
	@JsonProperty("height")
	private String height;
	
	@JsonProperty("weight")
	private String weight;
	
	@JsonProperty("perc_fat")
	private String percFat;
	
	@JsonProperty("note")
	private String note;
	
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
	public String getBmi() {
		return bmi;
	}
	public void setBmi(String bmi) {
		this.bmi = bmi;
	}
	public String getHeight() {
		return height;
	}
	public void setHeight(String height) {
		this.height = height;
	}
	public String getWeight() {
		return weight;
	}
	public void setWeight(String weight) {
		this.weight = weight;
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
}
