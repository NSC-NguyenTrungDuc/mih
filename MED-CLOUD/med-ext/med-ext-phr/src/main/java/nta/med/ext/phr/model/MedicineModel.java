package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * The persistent class for the PHR_MEDICINE database table.
 * 
 */

public class MedicineModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("alert")
	private BigDecimal alert;

	@JsonProperty("dose")
	private BigDecimal dose;

	@JsonProperty("method")
	private String method;

	@JsonProperty("name")
	private String name;

	@JsonProperty("note")
	private String note;

	@JsonProperty("prescription_url")
	private String prescriptionUrl;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("quantity")
	private BigDecimal quantity;
	
	@JsonProperty("time_take_medicine")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timeTakeMedicine;

	@JsonProperty("unit")
	private String unit;
	
	@JsonProperty("prescription_id")
	private Long prescriptionId;
	
	@JsonProperty("frequency")
	private BigDecimal frequency;

	@JsonProperty("created")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp created;
	
	@JsonProperty("updated")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp updated;
	
	@JsonProperty("source")
	private String source;
	
	@JsonProperty("prescription_name")
	private String prescriptionName;
	
	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp datetimeRecord;
	
	@JsonIgnore
	private String message;
	
	public MedicineModel() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public BigDecimal getDose() {
		return dose;
	}

	public void setDose(BigDecimal dose) {
		this.dose = dose;
	}

	public String getMethod() {
		return method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getPrescriptionUrl() {
		return prescriptionUrl;
	}

	public void setPrescriptionUrl(String prescriptionUrl) {
		this.prescriptionUrl = prescriptionUrl;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public BigDecimal getQuantity() {
		return quantity;
	}

	public void setQuantity(BigDecimal quantity) {
		this.quantity = quantity;
	}

	public Timestamp getTimeTakeMedicine() {
		return timeTakeMedicine;
	}

	public void setTimeTakeMedicine(Timestamp timeTakeMedicine) {
		this.timeTakeMedicine = timeTakeMedicine;
	}

	public String getUnit() {
		return unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
	}

	public Long getPrescriptionId() {
		return prescriptionId;
	}

	public void setPrescriptionId(Long prescriptionId) {
		this.prescriptionId = prescriptionId;
	}

	public BigDecimal getFrequency() {
		return frequency;
	}

	public void setFrequency(BigDecimal frequency) {
		this.frequency = frequency;
	}

	public Timestamp getCreated() {
		return created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public Timestamp getUpdated() {
		return updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
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

	public String getPrescriptionName() {
		return prescriptionName;
	}

	public void setPrescriptionName(String prescriptionName) {
		this.prescriptionName = prescriptionName;
	}

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}
}