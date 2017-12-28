package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientDisease {

	private String id;
	private String datetimeRecord;
	private String disease;

	public PatientDisease(String id, String datetimeRecord, String disease) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.disease = disease;
	}

	@JsonProperty("id")
	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	@JsonProperty("datetime_record")
	public String getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(String datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	@JsonProperty("disease")
	public String getDisease() {
		return disease;
	}

	public void setDisease(String disease) {
		this.disease = disease;
	}

}
