package nta.med.data.model.ihis.emr;

public class OCS2015U09GetTemplateComboBoxInfo {
    private Integer templateId;
    private Integer templateTypeId;
    private String templateName;
    private String templateContent;
    private String description;
    private String permissionType;
    private String sysId; 
    private String updId;
    private String defaultFlg;
	public OCS2015U09GetTemplateComboBoxInfo(Integer templateId,
			Integer templateTypeId, String templateName, String templateContent,
			String description, String permissionType,
			String sysId, String updId, String defaultFlg) {
		super();
		this.templateId = templateId;
		this.templateTypeId = templateTypeId;
		this.templateName = templateName;
		this.templateContent = templateContent;
		this.description = description;
		this.permissionType = permissionType;
		this.sysId = sysId;
		this.updId = updId;
		this.defaultFlg = defaultFlg;
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
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public String getDefaultFlg() {
		return defaultFlg;
	}
	public void setDefaultFlg(String defaultFlg) {
		this.defaultFlg = defaultFlg;
	}
}
