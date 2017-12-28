package nta.med.core.domain.cms;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the cms_survey database table.
 * 
 */
@Entity
@Table(name = "cms_survey")
public class CmsSurvey extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private Timestamp created;

	private BigDecimal defaultFlg;

	private String departmentCode;

	private String departmentName;

	private String description;

	private BigDecimal displayFlg;

	private String hospCode;

	private String locale;

	private String sysId;

	private String title;

	private String updId;

	private Timestamp updated;

	public CmsSurvey() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "DEFAULT_FLG")
	public BigDecimal getDefaultFlg() {
		return this.defaultFlg;
	}

	public void setDefaultFlg(BigDecimal defaultFlg) {
		this.defaultFlg = defaultFlg;
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

	@Column(name = "DISPLAY_FLG")
	public BigDecimal getDisplayFlg() {
		return this.displayFlg;
	}

	public void setDisplayFlg(BigDecimal displayFlg) {
		this.displayFlg = displayFlg;
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