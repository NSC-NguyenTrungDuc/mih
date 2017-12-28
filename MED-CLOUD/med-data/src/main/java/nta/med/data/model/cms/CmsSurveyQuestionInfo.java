package nta.med.data.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;

public class CmsSurveyQuestionInfo {
	private BigInteger id;
	private String content;
	private String description;
	private int sequence;
	private BigDecimal requiredFlg;
	private BigDecimal allowOtherFlg;	
	private String questionType;
	private java.math.BigInteger cmsSurveyQuestionGroupId;
	public CmsSurveyQuestionInfo(BigInteger id, String content, String description, int sequence,
			BigDecimal requiredFlg, BigDecimal allowOtherFlg, String questionType,
			BigInteger cmsSurveyQuestionGroupId) {
		super();
		this.id = id;
		this.content = content;
		this.description = description;
		this.sequence = sequence;
		this.requiredFlg = requiredFlg;
		this.allowOtherFlg = allowOtherFlg;
		this.questionType = questionType;
		this.cmsSurveyQuestionGroupId = cmsSurveyQuestionGroupId;
	}
	public BigInteger getId() {
		return id;
	}
	public void setId(BigInteger id) {
		this.id = id;
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
	public java.math.BigInteger getCmsSurveyQuestionGroupId() {
		return cmsSurveyQuestionGroupId;
	}
	public void setCmsSurveyQuestionGroupId(java.math.BigInteger cmsSurveyQuestionGroupId) {
		this.cmsSurveyQuestionGroupId = cmsSurveyQuestionGroupId;
	}
	
	
}
