package nta.med.core.domain.emr;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the EMR_TAG_RELATION database table.
 * 
 */
@Entity
@Table(name = "EMR_TAG_RELATION")
@NamedQuery(name = "EmrTagRelation.findAll", query = "SELECT e FROM EmrTagRelation e")
public class EmrTagRelation implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "EMR_TAG_RELATION_ID")
	private Integer emrTagRelationId;

	@Column(name = "ACTIVE_FLG")
	private Integer activeFlg;

	private Timestamp created;

	@Column(name = "EMR_TEMPLATE_ID")
	private Integer emrTemplateId;

	@Column(name = "HOSP_CODE")
	private String hospCode;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TAG_CHILD")
	private String tagChild;

	@Column(name = "TAG_PARENT")
	private String tagParent;

	@Column(name = "UPD_ID")
	private String updId;

	private Timestamp updated;

	@Column(name = "TAG_TYPE")
	private BigDecimal tagType;

	@Column(name = "DEFAULT_CONTENT")
	private String defaultContent;

	public EmrTagRelation() {
	}

	public Integer getEmrTagRelationId() {
		return this.emrTagRelationId;
	}

	public void setEmrTagRelationId(Integer emrTagRelationId) {
		this.emrTagRelationId = emrTagRelationId;
	}

	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public Integer getEmrTemplateId() {
		return this.emrTemplateId;
	}

	public void setEmrTemplateId(Integer emrTemplateId) {
		this.emrTemplateId = emrTemplateId;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTagChild() {
		return this.tagChild;
	}

	public void setTagChild(String tagChild) {
		this.tagChild = tagChild;
	}

	public String getTagParent() {
		return this.tagParent;
	}

	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
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

	public BigDecimal getTagType() {
		return tagType;
	}

	public void setTagType(BigDecimal tagType) {
		this.tagType = tagType;
	}

	public String getDefaultContent() {
		return defaultContent;
	}

	public void setDefaultContent(String defaultContent) {
		this.defaultContent = defaultContent;
	}

}