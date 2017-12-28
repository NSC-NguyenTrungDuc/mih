package nta.med.data.model.ihis.emr;

public class OCS2015U31EmrTemplateInfo {
	private Integer templateId;
	private Integer templateTypeId;
	private String templateContent;
	private String templateName;
	private String description;
	private String permissionType; 
	private String hospCode;
	private String typeName;
	private String sysId;
	public OCS2015U31EmrTemplateInfo(Integer templateId,
			Integer templateTypeId, String templateContent, 
			String templateName, String description, String permissionType,
			String hospCode, String typeName, String sysId) {
		super();
		this.templateId = templateId;
		this.templateTypeId = templateTypeId;
		this.templateName = templateName;
		this.templateContent = templateContent;
		this.description = description;
		this.permissionType = permissionType;
		this.hospCode = hospCode;
		this.typeName = typeName;
		this.sysId = sysId;
	}
	
	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTypeName() {
		return typeName;
	}

	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}

	public Integer getTemplateId() {
		return templateId;
	}
	public void setTemplateId(Integer templateId) {
		this.templateId = templateId;
	}
	public Integer getTemplateTypeId() {
		return templateTypeId;
	}
	public void setTemplateTypeId(Integer templateTypeId) {
		this.templateTypeId = templateTypeId;
	}
	public String getTemplateName() {
		return templateName;
	}
	public void setTemplateName(String templateName) {
		this.templateName = templateName;
	}
	public String getTemplateContent() {
		return templateContent;
	}
	public void setTemplateContent(String templateContent) {
		this.templateContent = templateContent;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getPermissionType() {
		return permissionType;
	}
	public void setPermissionType(String permissionType) {
		this.permissionType = permissionType;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	
}
