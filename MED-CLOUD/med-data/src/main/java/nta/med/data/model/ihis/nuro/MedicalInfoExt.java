package nta.med.data.model.ihis.nuro;

public class MedicalInfoExt {
	private String medicalClass;
	private Double medicalClassNumber;
	private String medicationNumber;
	private String medicationCode;
	public MedicalInfoExt(String medicalClass, Double medicalClassNumber, String medicationNumber,
			String medicationCode) {
		super();
		this.medicalClass = medicalClass;
		this.medicalClassNumber = medicalClassNumber;
		this.medicationNumber = medicationNumber;
		this.medicationCode = medicationCode;
	}
	public String getMedicalClass() {
		return medicalClass;
	}
	public void setMedicalClass(String medicalClass) {
		this.medicalClass = medicalClass;
	}
	public Double getMedicalClassNumber() {
		return medicalClassNumber;
	}
	public void setMedicalClassNumber(Double medicalClassNumber) {
		this.medicalClassNumber = medicalClassNumber;
	}
	public String getMedicationNumber() {
		return medicationNumber;
	}
	public void setMedicationNumber(String medicationNumber) {
		this.medicationNumber = medicationNumber;
	}
	public String getMedicationCode() {
		return medicationCode;
	}
	public void setMedicationCode(String medicationCode) {
		this.medicationCode = medicationCode;
	}
	
}
