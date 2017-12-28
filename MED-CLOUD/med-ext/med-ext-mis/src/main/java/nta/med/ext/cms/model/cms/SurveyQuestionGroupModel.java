package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SurveyQuestionGroupModel {
	/*
	 * 
	 * @JsonProperty("group_id")
	private Long groupId;
	
	@JsonProperty( "title")
	private String title;
	
	@JsonProperty("group_sequence")
	private Integer sequence;
	
	@JsonProperty("question_list")
	private List<SurveyQuestionModel> listQuestionList;
	 */
	
	@JsonProperty("group_id")
	private java.math.BigInteger id;
	@JsonProperty("title")
	private String title;
	@JsonProperty("group_sequence")
	private Integer sequence;
	@JsonProperty("question_list")
	private List<SurveyQuestionModel> listQuestion;
	public java.math.BigInteger getId() {
		return id;
	}
	public void setId(java.math.BigInteger id) {
		this.id = id;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public Integer getSequence() {
		return sequence;
	}
	public void setSequence(Integer sequence) {
		this.sequence = sequence;
	}
	public List<SurveyQuestionModel> getListQuestion() {
		return listQuestion;
	}
	public void setListQuestion(List<SurveyQuestionModel> listQuestion) {
		this.listQuestion = listQuestion;
	}
	
}
