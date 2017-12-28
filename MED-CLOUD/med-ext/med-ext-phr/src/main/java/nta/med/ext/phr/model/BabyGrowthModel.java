package nta.med.ext.phr.model;

import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_BABY_GROWTH database table.
 * 
 */

public class BabyGrowthModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("doctor_note")
	private String doctorNote;

	@JsonProperty("head_size")
	private String headSize;

	@JsonProperty("height")
	private String height;

	@JsonProperty("medical_record_url")
	private String medicalRecordUrl;

	@JsonProperty("parent_note")
	private String parentNote;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("time_measure")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeMeasure;

	@JsonProperty("weight")
	private String weight;

	public BabyGrowthModel() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getDoctorNote() {
		return doctorNote;
	}

	public void setDoctorNote(String doctorNote) {
		this.doctorNote = doctorNote;
	}

	public String getHeadSize() {
		return headSize;
	}

	public void setHeadSize(String headSize) {
		this.headSize = headSize;
	}

	public String getHeight() {
		return height;
	}

	public void setHeight(String height) {
		this.height = height;
	}

	public String getMedicalRecordUrl() {
		return medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getParentNote() {
		return parentNote;
	}

	public void setParentNote(String parentNote) {
		this.parentNote = parentNote;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public Timestamp getTimeMeasure() {
		return timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
	}

	public String getWeight() {
		return weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}
}