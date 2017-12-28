package nta.med.data.model.ihis.emr;

public class OCS2015U31EmrTemplateTypeInfo {
	private Integer templateTypeId;
	private String typeCode;
	private String typeName;
	private String description;
	public OCS2015U31EmrTemplateTypeInfo(Integer templateTypeId,
			String typeCode, String typeName, String description) {
		super();
		this.templateTypeId = templateTypeId;
		this.typeCode = typeCode;
		this.typeName = typeName;
		this.description = description;
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
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
}
