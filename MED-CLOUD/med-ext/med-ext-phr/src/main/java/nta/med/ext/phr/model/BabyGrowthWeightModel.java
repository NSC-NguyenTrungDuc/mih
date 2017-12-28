package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class BabyGrowthWeightModel {

	@JsonProperty("growth_id")
	private BigInteger id;

	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp timeMeasure;

	@JsonProperty("weight")
	private BigDecimal weight;

	@JsonProperty("doctor_note")
	private String doctorNote;
	
	@JsonProperty("parent_note")
	private String parentNote;
	
	@JsonProperty("medical_record_url")
	private String medicalRecordUrl;

	@JsonProperty("count")
	private BigInteger count;

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Timestamp getTimeMeasure() {
		return timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
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

	public BigInteger getCount() {
		return count;
	}

	public void setCount(BigInteger count) {
		this.count = count;
	}
}