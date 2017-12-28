package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U06EmrTemplateInfo {
    private Integer templateId;
    private Integer templateTypeId;
    private String templateCode;
    private String templateName;
    private String templateContent;
    private String hospCode;
    private String gwa;
    private String userId; 
    private String permissionType;
    private BigDecimal activeFlg;
    private Date created; 
    private Date updated;
    
	public OCS2015U06EmrTemplateInfo(Integer templateId,
			Integer templateTypeId, String templateCode, String templateName,
			String templateContent, String hospCode, String gwa, String userId,
			String permissionType, BigDecimal activeFlg, Date created,
			Date updated) {
		super();
		this.templateId = templateId;
		this.templateTypeId = templateTypeId;
		this.templateCode = templateCode;
		this.templateName = templateName;
		this.templateContent = templateContent;
		this.hospCode = hospCode;
		this.gwa = gwa;
		this.userId = userId;
		this.permissionType = permissionType;
		this.activeFlg = activeFlg;
		this.created = created;
		this.updated = updated;
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
	public String getTemplateContent() {
		return templateContent;
	}
	public void setTemplateContent(String templateContent) {
		this.templateContent = templateContent;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getPermissionType() {
		return permissionType;
	}
	public void setPermissionType(String permissionType) {
		this.permissionType = permissionType;
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
