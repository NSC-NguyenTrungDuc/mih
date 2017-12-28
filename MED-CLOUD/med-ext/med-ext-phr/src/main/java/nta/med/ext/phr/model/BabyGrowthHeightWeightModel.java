package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_BABY_GROWTH database table.
 * 
 */

public class BabyGrowthHeightWeightModel {
	
	@JsonProperty("growth_id")
	private Long id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeMeasure;
	
	@JsonProperty("height")
	private BigDecimal height;
	
	@JsonProperty("weight")
	private BigDecimal weight;
	
	@JsonProperty("doctor_note")
	private String doctorNote;

	@JsonProperty("parent_note")
	private String parentNote;
	
	@JsonProperty("baby_medical_file_url")
	private String medicalRecordUrl;
	
	@JsonProperty("source")
	private String source;
	
	@JsonIgnore
	private String message;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getTimeMeasure() {
		return timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
	}

	public BigDecimal getHeight() {
		return height;
	}

	public void setHeight(BigDecimal height) {
		this.height = height;
	}

	public BigDecimal getWeight() {
		return weight;
	}

	public void setWeight(BigDecimal weight) {
		this.weight = weight;
	}

	public String getDoctorNote() {
		return doctorNote;
	}

	public void setDoctorNote(String doctorNote) {
		this.doctorNote = doctorNote;
	}

	public String getParentNote() {
		return parentNote;
	}

	public void setParentNote(String parentNote) {
		this.parentNote = parentNote;
	}

	public String getMedicalRecordUrl() {
		return medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}
}