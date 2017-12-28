package nta.med.ext.cms.model.cms;

import java.util.List;

import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonProperty;

public class QuestionDetailModel {

	@JsonProperty("hosp_code")
	private String hospCode;
	
	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;
	
	@JsonProperty("question_id")
	private Long id;
	
	@JsonProperty("question_type")
	@NotNull(message = "question_type is required field")
	private String questionType;
	
	@JsonProperty("question_content")
	@NotNull(message = "question_content is required field")
	private String content;
	
	@JsonProperty("description")
	private String description;
	
	@JsonProperty("answer_list")
	private List<SurveyAnswerModel> answerList;

	@JsonProperty("limit_answer")
	private Integer limitAnswer;

	@JsonProperty("has_other_answer")
	private Boolean hasOtherAnswer;

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getQuestionType() {
		return questionType;
	}

	public void setQuestionType(String questionType) {
		this.questionType = questionType;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public List<SurveyAnswerModel> getAnswerList() {
		return answerList;
	}

	public void setAnswerList(List<SurveyAnswerModel> answerList) {
		this.answerList = answerList;
	}

	public Integer getLimitAnswer() {
		return limitAnswer;
	}

	public void setLimitAnswer(Integer limitAnswer) {
		this.limitAnswer = limitAnswer;
	}

	public Boolean getHasOtherAnswer() {
		return hasOtherAnswer;
	}

	public void setHasOtherAnswer(Boolean hasOtherAnswer) {
		this.hasOtherAnswer = hasOtherAnswer;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}
}
