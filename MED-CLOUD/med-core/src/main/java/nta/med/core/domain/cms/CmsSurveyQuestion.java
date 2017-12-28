package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_survey_question database table.
 * 
 */
@Entity
@Table(name = "cms_survey_question")
public class CmsSurveyQuestion extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private java.math.BigInteger cmsQuestionId;

	private java.math.BigInteger cmsSurveyQuestionGroupId;

	private Timestamp created;

	private String hospCode;

	private BigDecimal requiredFlg;

	private int sequence;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public CmsSurveyQuestion() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "CMS_QUESTION_ID")
	public java.math.BigInteger getCmsQuestionId() {
		return this.cmsQuestionId;
	}

	public void setCmsQuestionId(java.math.BigInteger cmsQuestionId) {
		this.cmsQuestionId = cmsQuestionId;
	}

	@Column(name = "CMS_SURVEY_QUESTION_GROUP_ID")
	public java.math.BigInteger getCmsSurveyQuestionGroupId() {
		return this.cmsSurveyQuestionGroupId;
	}

	public void setCmsSurveyQuestionGroupId(java.math.BigInteger cmsSurveyQuestionGroupId) {
		this.cmsSurveyQuestionGroupId = cmsSurveyQuestionGroupId;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "REQUIRED_FLG")
	public BigDecimal getRequiredFlg() {
		return this.requiredFlg;
	}

	public void setRequiredFlg(BigDecimal requiredFlg) {
		this.requiredFlg = requiredFlg;
	}

	public int getSequence() {
		return this.sequence;
	}

	public void setSequence(int sequence) {
		this.sequence = sequence;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}