package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.math.BigInteger;

public class OCS2015U09EmrTagGetTemplateTagsInfo {
	private BigInteger tagId;
	private String tagCode;
	private String tagName;
	private String type;
	private String defaultContent;
	private String tagDisplayText;
	private String description;
	private BigDecimal filterFlg;
	private String sysId;
	private String tagParent;
	private String tagChild;
	private Integer emrTemplateId;
	public OCS2015U09EmrTagGetTemplateTagsInfo(BigInteger tagId, String tagCode, String tagName, String type,
			String defaultContent, String tagDisplayText, String description, BigDecimal filterFlg, String sysId,
			String tagParent, String tagChild, Integer emrTemplateId) {
		super();
		this.tagId = tagId;
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.type = type;
		this.defaultContent = defaultContent;
		this.tagDisplayText = tagDisplayText;
		this.description = description;
		this.filterFlg = filterFlg;
		this.sysId = sysId;
		this.tagParent = tagParent;
		this.tagChild = tagChild;
		this.emrTemplateId = emrTemplateId;
	}
	public BigInteger getTagId() {
		return tagId;
	}
	public void setTagId(BigInteger tagId) {
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
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getDefaultContent() {
		return defaultContent;
	}
	public void setDefaultContent(String defaultContent) {
		this.defaultContent = defaultContent;
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
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
	}
	public String getTagChild() {
		return tagChild;
	}
	public void setTagChild(String tagChild) {
		this.tagChild = tagChild;
	}
	public Integer getEmrTemplateId() {
		return emrTemplateId;
	}
	public void setEmrTemplateId(Integer emrTemplateId) {
		this.emrTemplateId = emrTemplateId;
	}
	
}
