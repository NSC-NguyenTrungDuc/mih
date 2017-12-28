package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonProperty;

//cms 14
public class SurveyStatusModel {

	@JsonProperty("id")
	private java.math.BigInteger cmsSurveyId;
	
	@JsonProperty("survey_title")
	private String title;
	
	@JsonProperty("description")
	private String description;
	
	@JsonProperty("default_flg")
	private BigDecimal defaultFlg;
	
	@JsonProperty("answered")
	private BigDecimal Answered;
	
	@JsonProperty("waiting")
	private BigDecimal Waiting;

	public java.math.BigInteger getCmsSurveyId() {
		return cmsSurveyId;
	}

	public void setCmsSurveyId(java.math.BigInteger cmsSurveyId) {
		this.cmsSurveyId = cmsSurveyId;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public BigDecimal getDefaultFlg() {
		return defaultFlg;
	}

	public void setDefaultFlg(BigDecimal defaultFlg) {
		this.defaultFlg = defaultFlg;
	}

	public BigDecimal getAnswered() {
		return Answered;
	}

	public void setAnswered(BigDecimal answered) {
		Answered = answered;
	}

	public BigDecimal getWaiting() {
		return Waiting;
	}

	public void setWaiting(BigDecimal waiting) {
		Waiting = waiting;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
}
