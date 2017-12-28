package nta.med.data.model.ihis.emr;

public class OCS2015U09GetTagsForContextInfo {
    private Integer emRTagId;
    private String tagCode;
    private String tagName;
    private String tagLevel;
    private String tagDisplayText;
    private String tagParent;
    private String description;
    private String permissionType;
    private String sysId;
    private String updId;
	public OCS2015U09GetTagsForContextInfo(Integer emRTagId, String tagCode,
			String tagName, String tagLevel, String tagDisplayText,
			String tagParent, String description, String permissionType,
			String sysId, String updId) {
		super();
		this.emRTagId = emRTagId;
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.tagLevel = tagLevel;
		this.tagDisplayText = tagDisplayText;
		this.tagParent = tagParent;
		this.description = description;
		this.permissionType = permissionType;
		this.sysId = sysId;
		this.updId = updId;
	}
	public Integer getEmRTagId() {
		return emRTagId;
	}
	public void setEmRTagId(Integer emRTagId) {
		this.emRTagId = emRTagId;
	}
	public String getTagCode() {
		return tagCode;
	}
	public void setTagCode(String tagCode) {
		this.tagCode = tagCode;
	}
	public String getTagName() {
		return tagName;
	}
	public void setTagName(String tagName) {
		this.tagName = tagName;
	}
	public String getTagLevel() {
		return tagLevel;
	}
	public void setTagLevel(String tagLevel) {
		this.tagLevel = tagLevel;
	}
	public String getTagDisplayText() {
		return tagDisplayText;
	}
	public void setTagDisplayText(String tagDisplayText) {
		this.tagDisplayText = tagDisplayText;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
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
    
}
