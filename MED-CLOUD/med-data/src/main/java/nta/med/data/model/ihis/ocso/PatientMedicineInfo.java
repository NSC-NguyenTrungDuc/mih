package nta.med.data.model.ihis.ocso;

import java.math.BigInteger;

public class PatientMedicineInfo {

	private BigInteger id;
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
	private String hospName;
	private Double neawonKey;
	private String hangmogCode;
	

	public PatientMedicineInfo(BigInteger id, String datetimeRecord, String prescriptionName, String medicineName,
			String dose, String unitCode, String unit, String frequency, String days, String dosage,
			String medicineMethod, String hospName, Double neawonKey, String hangmogCode) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.prescriptionName = prescriptionName;
		this.medicineName = medicineName;
		this.dose = dose;
		this.unitCode = unitCode;
		this.unit = unit;
		this.frequency = frequency;
		this.days = days;
		this.dosage = dosage;
		this.medicineMethod = medicineMethod;
		this.hospName = hospName;
		this.neawonKey = neawonKey;
		this.hangmogCode = hangmogCode;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(String datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public String getPrescriptionName() {
		return prescriptionName;
	}

	public void setPrescriptionName(String prescriptionName) {
		this.prescriptionName = prescriptionName;
	}

	public String getMedicineName() {
		return medicineName;
	}

	public void setMedicineName(String medicineName) {
		this.medicineName = medicineName;
	}

	public String getDose() {
		return dose;
	}

	public void setDose(String dose) {
		this.dose = dose;
	}

	public String getUnitCode() {
		return unitCode;
	}

	public void setUnitCode(String unitCode) {
		this.unitCode = unitCode;
	}

	public String getUnit() {
		return unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
	}

	public String getFrequency() {
		return frequency;
	}

	public void setFrequency(String frequency) {
		this.frequency = frequency;
	}

	public String getDays() {
		return days;
	}

	public void setDays(String days) {
		this.days = days;
	}

	public String getDosage() {
		return dosage;
	}

	public void setDosage(String dosage) {
		this.dosage = dosage;
	}

	public String getMedicineMethod() {
		return medicineMethod;
	}

	public void setMedicineMethod(String medicineMethod) {
		this.medicineMethod = medicineMethod;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public Double getNeawonKey() {
		return neawonKey;
	}

	public void setNeawonKey(Double neawonKey) {
		this.neawonKey = neawonKey;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

}
