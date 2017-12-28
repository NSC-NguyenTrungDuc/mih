package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SurveyStatusInform {
	@JsonProperty("survey_list")
	private List<SurveyStatusModel> surveyStatusList;
	
	@JsonProperty("records_total")
	private int recordsTotal;
	
	@JsonProperty("records_filtered")
	private int recordsFiltered;

	public List<SurveyStatusModel> getSurveyStatusList() {
		return surveyStatusList;
	}

	public void setSurveyStatusList(List<SurveyStatusModel> surveyStatusList) {
		this.surveyStatusList = surveyStatusList;
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
