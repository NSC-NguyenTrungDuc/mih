package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class QuestionInform {
	
	@JsonProperty("question_list")
	private List<QuestionModel> questionlist;
	
	@JsonProperty("records_total")
	private int recordsTotal;
	
	@JsonProperty("records_filtered")
	private int recordsFiltered;

	public List<QuestionModel> getQuestionlist() {
		return questionlist;
	}

	public void setQuestionlist(List<QuestionModel> questionlist) {
		this.questionlist = questionlist;
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
