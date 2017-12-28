package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_answer database table.
 * 
 */
@Entity
@Table(name = "cms_answer")
public class CmsAnswer extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private Long cmsQuestionId;

	private String content;

	private BigDecimal correctFlg;

	private Timestamp created;

	private String hospCode;

	private String hospName;

	private String locale;

	private Integer sequence;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public CmsAnswer() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "CMS_QUESTION_ID")
	public Long getCmsQuestionId() {
		return this.cmsQuestionId;
	}

	public void setCmsQuestionId(Long cmsQuestionId) {
		this.cmsQuestionId = cmsQuestionId;
	}

	@Column(name = "CONTENT")
	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	@Column(name = "CORRECT_FLG")
	public BigDecimal getCorrectFlg() {
		return this.correctFlg;
	}

	public void setCorrectFlg(BigDecimal correctFlg) {
		this.correctFlg = correctFlg;
	}

	@Column(name = "CREATED")
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

	@Column(name = "HOSP_NAME")
	public String getHospName() {
		return this.hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	@Column(name = "LOCALE")
	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	@Column(name = "SEQUENCE")
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

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "UPDATED")
	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}