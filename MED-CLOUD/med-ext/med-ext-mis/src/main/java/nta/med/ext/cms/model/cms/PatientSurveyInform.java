package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientSurveyInform {
	@JsonProperty("patient_survey_list")
	private List<PatientSurveyModel> patientSurveyList;
	
	@JsonProperty("records_total")
	private int recordsTotal;
	
	@JsonProperty("records_filtered")
	private int recordsFiltered;

	public List<PatientSurveyModel> getPatientSurveyList() {
		return patientSurveyList;
	}

	public void setPatientSurveyList(List<PatientSurveyModel> patientSurveyList) {
		this.patientSurveyList = patientSurveyList;
	}

	public int getRecordsTotal() {
		return recordsTotal;
	}

	public void setRecordsTotal(int recordsTotal) {
		this.recordsTotal = recordsTotal;
	}

	public int getRecordsFiltered() {
		return recordsFiltered;
	}

	public void setRecordsFiltered(int recordsFiltered) {
		this.recordsFiltered = recordsFiltered;
	}
	
	
}
