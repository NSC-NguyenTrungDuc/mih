package nta.med.core.domain.emr;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * The persistent class for the EMR_TEMPLATE database table.
 * 
 */
@Entity
@Table(name = "EMR_TEMPLATE")
public class EmrTemplate implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "EMR_TEMPLATE_ID")
	private Integer emrTemplateId;

	@Column(name = "ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	@Column(name = "HOSP_CODE")
	private String hospCode;

	@Column(name = "PERMISSION_TYPE")
	private String permissionType;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TEMPLATE_NAME")
	private String templateName;

	@Column(name = "EMR_TEMPLATE_TYPE_ID")
	private Integer emrTemplateTypeId;

	@Column(name = "UPD_ID")
	private String updId;

	@Column(name = "DESCRIPTION")
	private String description;

	private Timestamp updated;

	@Column(name = "TEMPLATE_CODE")
	private String templateCode;

	@Column(name = "DEFAULT_FLG")
	private String defaultFlg;

	@Column(name = "SABUN")
	private String sabun;

	@Column(name = "GWA")
	private String gwa;

	@Column(name = "LEVEL")
	private BigDecimal level;

	public EmrTemplate() {
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Integer getEmrTemplateId() {
		return this.emrTemplateId;
	}

	public void setEmrTemplateId(Integer emrTemplateId) {
		this.emrTemplateId = emrTemplateId;
	}

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

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getPermissionType() {
		return this.permissionType;
	}

	public void setPermissionType(String permissionType) {
		this.permissionType = permissionType;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTemplateName() {
		return this.templateName;
	}

	public void setTemplateName(String templateName) {
		this.templateName = templateName;
	}

	public Integer getEmrTemplateTypeId() {
		return this.emrTemplateTypeId;
	}

	public void setEmrTemplateTypeId(Integer emrTemplateTypeId) {
		this.emrTemplateTypeId = emrTemplateTypeId;
	}

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

	public String getTemplateCode() {
		return templateCode;
	}

	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	public String getDefaultFlg() {
		return defaultFlg;
	}

	public void setDefaultFlg(String defaultFlg) {
		this.defaultFlg = defaultFlg;
	}

	public String getSabun() {
		return sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public BigDecimal getLevel() {
		return level;
	}

	public void setLevel(BigDecimal level) {
		this.level = level;
	}

}