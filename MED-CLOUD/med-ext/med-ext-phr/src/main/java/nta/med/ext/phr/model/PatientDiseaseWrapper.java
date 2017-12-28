package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientDiseaseWrapper {

	private List<PatientDisease> diseaseList;
	private String hospName;

	@JsonProperty("disease_list")
	public List<PatientDisease> getDiseaseList() {
		return diseaseList;
	}

	public void setDiseaseList(List<PatientDisease> diseaseList) {
		this.diseaseList = diseaseList;
	}

	@JsonProperty("hosp_name")
	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

}
