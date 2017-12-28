package nta.med.data.model.ihis.emr;

public class OCS2015U31EmrTemplateSaveLayoutInfo {
	private Integer templateId;
	private Integer templateTypeId;
	private String templateName;
	private String templateContent;
	private String description;
	private String permissionType;
	private String hospCode;
	private String rowState;
	public OCS2015U31EmrTemplateSaveLayoutInfo(Integer templateId,
			Integer templateTypeId, String templateName,
			String templateContent, String description, String permissionType,
			String hospCode, String rowState) {
		super();
		this.templateId = templateId;
		this.templateTypeId = templateTypeId;
		this.templateName = templateName;
		this.templateContent = templateContent;
		this.description = description;
		this.permissionType = permissionType;
		this.hospCode = hospCode;
		this.rowState = rowState;
	}
	
	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
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
