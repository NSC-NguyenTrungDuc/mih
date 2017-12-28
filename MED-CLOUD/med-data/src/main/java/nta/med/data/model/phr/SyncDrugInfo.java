/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigInteger;
import java.util.Date;

/**
 * @author DEV-HuanLT
 *
 */
public class SyncDrugInfo {
	
	private String datetimeRecord;
	private Double prescriptionName;
	private BigInteger prescriptionId;
	private Date presciptionCreated;
	private Date presciptionUpdated;
	private BigInteger medicineId;
	private String medicineName;
	private Double dose;
	private String unitCode;
	private String unit;
	private Double frequency;
	private Double days;
	private String note;
	private String medicineMethod;
	private String hospName;
	private Date created;
	private Date updated;
	
	public SyncDrugInfo(String datetimeRecord, Double prescriptionName, BigInteger prescriptionId,
			Date presciptionCreated, Date presciptionUpdated, BigInteger medicineId, String medicineName, Double dose,
			String unitCode, String unit, Double frequency, Double days, String note, String medicineMethod,
			String hospName, Date created, Date updated) {
		super();
		this.datetimeRecord = datetimeRecord;
		this.prescriptionName = prescriptionName;
		this.prescriptionId = prescriptionId;
		this.presciptionCreated = presciptionCreated;
		this.presciptionUpdated = presciptionUpdated;
		this.medicineId = medicineId;
		this.medicineName = medicineName;
		this.dose = dose;
		this.unitCode = unitCode;
		this.unit = unit;
		this.frequency = frequency;
		this.days = days;
		this.note = note;
		this.medicineMethod = medicineMethod;
		this.hospName = hospName;
		this.created = created;
		this.updated = updated;
	}
	
	public BigInteger getPrescriptionId() {
		return prescriptionId;
	}
	public void setPrescriptionId(BigInteger prescriptionId) {
		this.prescriptionId = prescriptionId;
	}
	public Date getPresciptionCreated() {
		return presciptionCreated;
	}
	public void setPresciptionCreated(Date presciptionCreated) {
		this.presciptionCreated = presciptionCreated;
	}
	public Date getPresciptionUpdated() {
		return presciptionUpdated;
	}
	public void setPresciptionUpdated(Date presciptionUpdated) {
		this.presciptionUpdated = presciptionUpdated;
	}
	public String getDatetimeRecord() {
		return datetimeRecord;
	}
	public void setDatetimeRecord(String datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}
	public Double getPrescriptionName() {
		return prescriptionName;
	}
	public void setPrescriptionName(Double prescriptionName) {
		this.prescriptionName = prescriptionName;
	}
	public BigInteger getMedicineId() {
		return medicineId;
	}
	public void setMedicineId(BigInteger medicineId) {
		this.medicineId = medicineId;
	}
	public String getMedicineName() {
		return medicineName;
	}
	public void setMedicineName(String medicineName) {
		this.medicineName = medicineName;
	}
	public Double getDose() {
		return dose;
	}
	public void setDose(Double dose) {
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
	public Double getFrequency() {
		return frequency;
	}
	public void setFrequency(Double frequency) {
		this.frequency = frequency;
	}
	public Double getDays() {
		return days;
	}
	public void setDays(Double days) {
		this.days = days;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
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
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
}
