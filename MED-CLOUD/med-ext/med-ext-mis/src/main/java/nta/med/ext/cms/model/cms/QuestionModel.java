package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

public class QuestionModel {

	@JsonProperty("question_id")
	private Long id;

	@JsonProperty("department_code")
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;

	@JsonProperty("question_type")
	private String questionType;

	@JsonProperty("question_content")
	private String content;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
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

}
