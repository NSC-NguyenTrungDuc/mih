package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;

public class OCS2015U31EmrTagGetTemplateTagsInfo {
	private Integer tagId;
	private String tagCode;
	private String tagName;
	private String tagDisplayText;
	private String description;
	private BigDecimal filterFlg;
	private String tagParent;
	private String sysId;
	public OCS2015U31EmrTagGetTemplateTagsInfo(Integer tagId, String tagCode,
			String tagName, String tagDisplayText, String description,
			BigDecimal filterFlg, String tagParent, String sysId) {
		super();
		this.tagId = tagId;
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.tagDisplayText = tagDisplayText;
		this.description = description;
		this.filterFlg = filterFlg;
		this.tagParent = tagParent;
		this.sysId = sysId;
	}
	public Integer getTagId() {
		return tagId;
	}
	public void setTagId(Integer tagId) {
		this.tagId = tagId;
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
	public String getTagDisplayText() {
		return tagDisplayText;
	}
	public void setTagDisplayText(String tagDisplayText) {
		this.tagDisplayText = tagDisplayText;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public BigDecimal getFilterFlg() {
		return filterFlg;
	}
	public void setFilterFlg(BigDecimal filterFlg) {
		this.filterFlg = filterFlg;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	
}
