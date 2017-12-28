package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientMedicine {

	private String id;
	private String datetimeRecord;
	private String prescriptionName;
	private String medicineName;
	private String dose;
	private String unitCode;
	private String unit;
	private String frequency;
	private String days;
	private String dosage;
	private String medicineMethod;
	private String neawonKey;
	private String hangmogCode;


	public PatientMedicine(String id, String datetimeRecord, String prescriptionName, String medicineName, String dose, String unitCode, String unit, String frequency, String days, String dosage,
			String medicineMethod, String neawonKey, String hangmogCode) {
		super();                                                                              
		this.id = id;                                                                    
		this.datetimeRecord = datetimeRecord;                                              
		this.prescriptionName = prescriptionName; 
		this.medicineMethod = medicineMethod;
		this.dose = dose;
		this.unitCode = unitCode;
		this.unit = unit;
		this.frequency = frequency;
		this.dosage = dosage;
		this.medicineMethod = medicineMethod;
		this.neawonKey = neawonKey;
		this.hangmogCode = hangmogCode;
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
	@JsonProperty("prescription_name")
	public String getPrescriptionName() {
		return prescriptionName;
	}

	public void setPrescriptionName(String prescriptionName) {
		this.prescriptionName = prescriptionName;
	}
	@JsonProperty("medicine_name")
	public String getMedicineName() {
		return medicineName;
	}

	public void setMedicineName(String medicineName) {
		this.medicineName = medicineName;
	}
	@JsonProperty("dose")
	public String getDose() {
		return dose;
	}

	public void setDose(String dose) {
		this.dose = dose;
	}
	@JsonProperty("unit_code")
	public String getUnitCode() {
		return unitCode;
	}

	public void setUnitCode(String unitCode) {
		this.unitCode = unitCode;
	}
	@JsonProperty("unit")
	public String getUnit() {
		return unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
	}
	@JsonProperty("frequency")
	public String getFrequency() {
		return frequency;
	}

	public void setFrequency(String frequency) {
		this.frequency = frequency;
	}
	@JsonProperty("days")
	public String getDays() {
		return days;
	}

	public void setDays(String days) {
		this.days = days;
	}
	@JsonProperty("dosage")
	public String getDosage() {
		return dosage;
	}

	public void setDosage(String dosage) {
		this.dosage = dosage;
	}
	@JsonProperty("medicine_method")
	public String getMedicineMethod() {
		return medicineMethod;
	}

	public void setMedicineMethod(String medicineMethod) {
		this.medicineMethod = medicineMethod;
	}

	@JsonProperty("neawon_key")
	public String getNeawonKey() {
		return neawonKey;
	}

	public void setNeawonKey(String neawonKey) {
		this.neawonKey = neawonKey;
	}
	
	@JsonProperty("hangmog_code")
	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

}
