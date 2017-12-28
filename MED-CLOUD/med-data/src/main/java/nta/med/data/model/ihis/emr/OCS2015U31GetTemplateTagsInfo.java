package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;

public class OCS2015U31GetTemplateTagsInfo {
	private Integer tagId;
	private String tagCode;
	private String tagName;
	private BigDecimal type;
	private String defaultContent;
	private String tagParent;
	private String tagLevel;
	public OCS2015U31GetTemplateTagsInfo(Integer tagId, String tagCode, String tagName, BigDecimal type,
			String defaultContent, String tagParent, String tagLevel) {
		super();
		this.tagId = tagId;
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.type = type;
		this.defaultContent = defaultContent;
		this.tagParent = tagParent;
		this.tagLevel = tagLevel;
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
	public BigDecimal getType() {
		return type;
	}
	public void setType(BigDecimal type) {
		this.type = type;
	}
	public String getDefaultContent() {
		return defaultContent;
	}
	public void setDefaultContent(String defaultContent) {
		this.defaultContent = defaultContent;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
	}
	public String getTagLevel() {
		return tagLevel;
	}
	public void setTagLevel(String tagLevel) {
		this.tagLevel = tagLevel;
	}

}