package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SurveyQuestionModel {
	
	/*
	 * @JsonProperty("question_id")
	private BigInteger questionId;
	
	@JsonProperty("question")
	private String content;
	
	@JsonProperty("question_sequence")
	private int sequence;
	
	@JsonProperty("question_description")
	private String description;
	
	@JsonProperty("required_flg")
	private BigDecimal requiredFlg;
	
	@JsonProperty("type")
	private String questionType;
	
	@JsonProperty("answer_list")
	private List<SurveyAnswerModel> listAnswerList;
	 * 
	 */
	
	@JsonProperty("question_id")
	private Long id;
	
	@JsonProperty("question_content")
	private String content;
	
	@JsonProperty("question_sequence")
	private int sequence;
	
	@JsonProperty("required_flg")
	private BigDecimal requiredFlg;
	
	@JsonProperty("has_other_answer")
	private BigDecimal allowOtherFlg;
	
	@JsonProperty("description")
	private String description;
	
	@JsonProperty("question_type")	
	private String questionType;
	
	@JsonProperty("answer_list")	
	private List<SurveyAnswerModel> listAnswer;
	
	public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public int getSequence() {
		return sequence;
	}
	public void setSequence(int sequence) {
		this.sequence = sequence;
	}
	public BigDecimal getRequiredFlg() {
		return requiredFlg;
	}
	public void setRequiredFlg(BigDecimal requiredFlg) {
		this.requiredFlg = requiredFlg;
	}
	public BigDecimal getAllowOtherFlg() {
		return allowOtherFlg;
	}
	public void setAllowOtherFlg(BigDecimal allowOtherFlg) {
		this.allowOtherFlg = allowOtherFlg;
	}
	public String getQuestionType() {
		return questionType;
	}
	public void setQuestionType(String questionType) {
		this.questionType = questionType;
	}
	public List<SurveyAnswerModel> getListAnswer() {
		return listAnswer;
	}
	public void setListAnswer(List<SurveyAnswerModel> listAnswer) {
		this.listAnswer = listAnswer;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
	
}
