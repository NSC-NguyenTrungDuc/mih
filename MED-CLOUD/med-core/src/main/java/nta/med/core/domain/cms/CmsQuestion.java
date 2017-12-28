package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_question database table.
 * 
 */
@Entity
@Table(name = "cms_question")
public class CmsQuestion extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private BigDecimal allowOtherFlg;

	private String content;

	private Timestamp created;

	private String departmentCode;

	private String departmentName;

	private String description;

	private String hospCode;

	private Integer limitAnswer;

	private String locale;

	private String questionType;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public CmsQuestion() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "ALLOW_OTHER_FLG")
	public BigDecimal getAllowOtherFlg() {
		return this.allowOtherFlg;
	}

	public void setAllowOtherFlg(BigDecimal allowOtherFlg) {
		this.allowOtherFlg = allowOtherFlg;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "DEPARTMENT_CODE")
	public String getDepartmentCode() {
		return this.departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	@Column(name = "DEPARTMENT_NAME")
	public String getDepartmentName() {
		return this.departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "LIMIT_ANSWER")
	public Integer getLimitAnswer() {
		return this.limitAnswer;
	}

	public void setLimitAnswer(Integer limitAnswer) {
		this.limitAnswer = limitAnswer;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	@Column(name = "QUESTION_TYPE")
	public String getQuestionType() {
		return this.questionType;
	}

	public void setQuestionType(String questionType) {
		this.questionType = questionType;
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