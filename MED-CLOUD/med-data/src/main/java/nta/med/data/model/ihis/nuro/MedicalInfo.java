package nta.med.data.model.ihis.nuro;

public class MedicalInfo {

	private String medicalClass;
	private String medicalClassNumber;
	private String medicationNumber;
	private String medicationCode;

	public MedicalInfo(String medicalClass, String medicalClassNumber, String medicationNumber, String medicationCode) {
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

	public String getMedicalClassNumber() {
		return medicalClassNumber;
	}

	public void setMedicalClassNumber(String medicalClassNumber) {
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
