package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SurveyInfoModel {
	
	/*
	 * @JsonProperty("survey_title")
	private String surveyTitle;

	@JsonProperty("description")
	private String description;
	
	@JsonProperty("question_group")
	private List<SurveyQuestionGroupModel> listQuestionGroups;
	 * 
	 */
	@JsonProperty("survey_id")
	private Long id;
	@JsonProperty("survey_title")
	private String title;
	@JsonProperty("description")
	private String description;
	@JsonProperty("default_flg")
	private BigDecimal defaultFlg;
	@JsonProperty("hosp_code")
	private String hospCode;
	@JsonProperty("department_code")
	private String departmentCode;
	@JsonProperty("question_group")
	private List<SurveyQuestionGroupModel> listquestionGroup = new ArrayList<>();
	public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public BigDecimal getDefaultFlg() {
		return defaultFlg;
	}
	public void setDefaultFlg(BigDecimal defaultFlg) {
		this.defaultFlg = defaultFlg;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getDepartmentCode() {
		return departmentCode;
	}
	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}
	public List<SurveyQuestionGroupModel> getListquestionGroup() {
		return listquestionGroup;
	}
	public void setListquestionGroup(List<SurveyQuestionGroupModel> listquestionGroup) {
		this.listquestionGroup = listquestionGroup;
	}
	
	
	
}
