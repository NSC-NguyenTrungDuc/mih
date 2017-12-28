package nta.med.data.model.ihis.emr;

public class OCS2015U31GetEmrTemplateInfo {
	private Integer templateId;
	private String templateCode;
	private String templateName;
	private String description;
	private Integer typeId;
	private String sysId;
	private String defaultFlg;

	public OCS2015U31GetEmrTemplateInfo(Integer templateId,
			String templateCode, String templateName, String description,
			Integer typeId, String sysId, String defaultFlg) {
		super();
		this.templateId = templateId;
		this.templateCode = templateCode;
		this.templateName = templateName;
		this.description = description;
		this.typeId = typeId;
		this.sysId = sysId;
		this.defaultFlg = defaultFlg;
	}

	public Integer getTemplateId() {
		return templateId;
	}

	public void setTemplateId(Integer templateId) {
		this.templateId = templateId;
	}

	public String getTemplateCode() {
		return templateCode;
	}

	public void setTemplateCode(String templateCode) {
		this.templateCode = templateCode;
	}

	public String getTemplateName() {
		return templateName;
	}

	public void setTemplateName(String templateName) {
		this.templateName = templateName;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Integer getTypeId() {
		return typeId;
	}

	public void setTypeId(Integer typeId) {
		this.typeId = typeId;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getDefaultFlg() {
		return defaultFlg;
	}

	public void setDefaultFlg(String defaultFlg) {
		this.defaultFlg = defaultFlg;
	}

}