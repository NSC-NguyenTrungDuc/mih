package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U06EmrTemplateTypeInfo {
    private Integer templateTypeId;
    private String typeCode;
    private String typeName;
    private String typeTag;
    private String description;
    private BigDecimal activeFlg;
    private Date created;
    private Date updated;
    
    
	public OCS2015U06EmrTemplateTypeInfo(Integer templateTypeId,
			String typeCode, String typeName, String typeTag,
			String description, BigDecimal activeFlg, Date created, Date updated) {
		super();
		this.templateTypeId = templateTypeId;
		this.typeCode = typeCode;
		this.typeName = typeName;
		this.typeTag = typeTag;
		this.description = description;
		this.activeFlg = activeFlg;
		this.created = created;
		this.updated = updated;
	}
	public Integer getTemplateTypeId() {
		return templateTypeId;
	}
	public void setTemplateTypeId(Integer templateTypeId) {
		this.templateTypeId = templateTypeId;
	}
	public String getTypeCode() {
		return typeCode;
	}
	public void setTypeCode(String typeCode) {
		this.typeCode = typeCode;
	}
	public String getTypeName() {
		return typeName;
	}
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}
	public String getTypeTag() {
		return typeTag;
	}
	public void setTypeTag(String typeTag) {
		this.typeTag = typeTag;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
    
    
}
