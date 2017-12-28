package nta.med.ext.phr.model;

import java.sql.Timestamp;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;
public class StandardDiseasModel {

	@JsonProperty("id")
	private Long id;

	@NotNull(message = "hospital is a required field")
	@JsonProperty("hospital")
	private String hospital;
	
	@NotNull(message="datetime_record is a required field")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	@JsonProperty("datetime_record")
	private Timestamp datetimeRecord;
	

	@NotNull(message = "medical_record_url is a required field")
	@JsonProperty("medical_record_url")
	private String medicalRecordUrl;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@NotNull(message = "disease_name is a required field")
	@JsonProperty("disease_name")
	private String status;
	
	
	@JsonProperty("start_date")
	private String diseaseStartDate;
	
	@JsonProperty("end_date")
	private String diseaseEndDate;
	
	@JsonProperty("outcome")
	private String diseaseOutcome;

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

	public String getHospital() {
		return hospital;
	}

	public void setHospital(String hospital) {
		this.hospital = hospital;
	}

	public String getMedicalRecordUrl() {
		return medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getDiseaseStartDate() {
		return diseaseStartDate;
	}

	public void setDiseaseStartDate(String diseaseStartDate) {
		this.diseaseStartDate = diseaseStartDate;
	}

	public String getDiseaseEndDate() {
		return diseaseEndDate;
	}

	public void setDiseaseEndDate(String diseaseEndDate) {
		this.diseaseEndDate = diseaseEndDate;
	}

	public String getDiseaseOutcome() {
		return diseaseOutcome;
	}

	public void setDiseaseOutcome(String diseaseOutcome) {
		this.diseaseOutcome = diseaseOutcome;
	}
	
	
}
