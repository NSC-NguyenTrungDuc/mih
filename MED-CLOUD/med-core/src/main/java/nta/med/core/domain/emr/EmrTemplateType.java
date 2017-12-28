package nta.med.core.domain.emr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the EMR_TEMPLATE_TYPE database table.
 * 
 */
@Entity
@Table(name="EMR_TEMPLATE_TYPE")
@NamedQuery(name="EmrTemplateType.findAll", query="SELECT e FROM EmrTemplateType e")
public class EmrTemplateType implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="TEMPLATE_TYPE_ID")
	private int templateTypeId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	private String description;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="TYPE_CODE")
	private String typeCode;

	@Column(name="TYPE_NAME")
	private String typeName;

	@Column(name="TYPE_TAG")
	private String typeTag;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public EmrTemplateType() {
	}

	public int getTemplateTypeId() {
		return this.templateTypeId;
	}

	public void setTemplateTypeId(int templateTypeId) {
		this.templateTypeId = templateTypeId;
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

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTypeCode() {
		return this.typeCode;
	}

	public void setTypeCode(String typeCode) {
		this.typeCode = typeCode;
	}

	public String getTypeName() {
		return this.typeName;
	}

	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}

	public String getTypeTag() {
		return this.typeTag;
	}

	public void setTypeTag(String typeTag) {
		this.typeTag = typeTag;
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

}