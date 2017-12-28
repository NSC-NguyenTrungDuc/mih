package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_survey_question_group database table.
 * 
 */
@Entity
@Table(name = "cms_survey_question_group")
public class CmsSurveyQuestionGroup extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private java.math.BigInteger cmsSurveyId;

	private Timestamp created;

	private String hospCode;

	private String locale;

	private Integer sequence;

	private String sysId;

	private String title;

	private String updId;

	private Timestamp updated;

	public CmsSurveyQuestionGroup() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "CMS_SURVEY_ID")
	public java.math.BigInteger getCmsSurveyId() {
		return this.cmsSurveyId;
	}

	public void setCmsSurveyId(java.math.BigInteger cmsSurveyId) {
		this.cmsSurveyId = cmsSurveyId;
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

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public Integer getSequence() {
		return this.sequence;
	}

	public void setSequence(Integer sequence) {
		this.sequence = sequence;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
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