package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;

public class OCS2015U30EmrTagSaveLayoutInfo {
	private Integer tagId;
	private String tagName;
	private String tagCode;
	private String tagDisplayText;
	private String description;
	private String tagLevel;
	private String tagParent;
	private BigDecimal filterFlg;
	private String rowState;
	private String sysId;
	public OCS2015U30EmrTagSaveLayoutInfo(Integer tagId, String tagName,
			String tagCode, String tagDisplayText, String description,
			String tagLevel, String tagParent, BigDecimal filterFlg,
			String rowState, String sysId) {
		super();
		this.tagId = tagId;
		this.tagName = tagName;
		this.tagCode = tagCode;
		this.tagDisplayText = tagDisplayText;
		this.description = description;
		this.tagLevel = tagLevel;
		this.tagParent = tagParent;
		this.filterFlg = filterFlg;
		this.rowState = rowState;
		this.sysId = sysId;
	}
	public Integer getTagId() {
		return tagId;
	}
	public void setTagId(Integer tagId) {
		this.tagId = tagId;
	}
	public String getTagName() {
		return tagName;
	}
	public void setTagName(String tagName) {
		this.tagName = tagName;
	}
	public String getTagCode() {
		return tagCode;
	}
	public void setTagCode(String tagCode) {
		this.tagCode = tagCode;
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
	public String getTagLevel() {
		return tagLevel;
	}
	public void setTagLevel(String tagLevel) {
		this.tagLevel = tagLevel;
	}
	public String getTagParent() {
		return tagParent;
	}
	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
	}
	public BigDecimal getFilterFlg() {
		return filterFlg;
	}
	public void setFilterFlg(BigDecimal filterFlg) {
		this.filterFlg = filterFlg;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	
}
