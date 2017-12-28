package nta.med.ext.phr.model;

import java.sql.Timestamp;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

public class PrescriptionDetailModel {
	
	@JsonProperty("prescription_id")
	private Long id;
	
	@JsonProperty("prescription_name")
	private String prescriptionName;
	
	@JsonProperty("datetime_record")
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
	private Timestamp created;
	
	@JsonProperty("note")
	private String note;
	
	@JsonProperty("prescription_url")
	private String prescriptionUrl;
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("medicine_list")
	List<MedicineModel> medicineList;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getPrescriptionName() {
		return prescriptionName;
	}

	public void setPrescriptionName(String prescriptionName) {
		this.prescriptionName = prescriptionName;
	}

	public Timestamp getCreated() {
		return created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
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

	public List<MedicineModel> getMedicineList() {
		return medicineList;
	}

	public void setMedicineList(List<MedicineModel> medicineList) {
		this.medicineList = medicineList;
	}
}
