package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientMedicineWrapper {

	private List<PatientMedicine> medicineList;
	private String hospName;

	@JsonProperty("medicine_list")
	public List<PatientMedicine> getMedicineList() {
		return medicineList;
	}

	public void setMedicineList(List<PatientMedicine> medicineList) {
		this.medicineList = medicineList;
	}

	@JsonProperty("hosp_name")
	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

}
