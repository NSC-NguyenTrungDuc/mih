package nta.med.data.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;

public class CmsSurveyStatusInfo {
	
	
	private java.math.BigInteger cmsSurveyId;
	private String title;
	private String description;
	private BigDecimal defaultFlg;
	private BigDecimal Answered;
	private BigDecimal Waiting;
	
	public CmsSurveyStatusInfo(BigInteger cmsSurveyId, String title, String description, BigDecimal defaultFlg, BigDecimal answered,
			BigDecimal waiting) {
		super();
		this.cmsSurveyId = cmsSurveyId;
		this.title = title;
		this.description = description;
		this.defaultFlg = defaultFlg;
		this.Answered = answered;
		this.Waiting = waiting;
	}
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
