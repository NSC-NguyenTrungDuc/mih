package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U06EmrTagInfo {
    private Integer tagId;
    private String tagCode;
    private String tagName;
    private String tagLevel;
    private String tagParent;
    private String description;
    private String hospCode;
    private String userId;
    private BigDecimal filterFlg;
    private BigDecimal activeFlg;
    private Date created; 
    private Date updated;
    
	public OCS2015U06EmrTagInfo(Integer tagId, String tagCode, String tagName,
			String tagLevel, String tagParent, String description,
			String hospCode, String userId, BigDecimal filterFlg,
			BigDecimal activeFlg, Date created, Date updated) {
		super();
		this.tagId = tagId;
		this.tagCode = tagCode;
		this.tagName = tagName;
		this.tagLevel = tagLevel;
		this.tagParent = tagParent;
		this.description = description;
		this.hospCode = hospCode;
		this.userId = userId;
		this.filterFlg = filterFlg;
		this.activeFlg = activeFlg;
		this.created = created;
		this.updated = updated;
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
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public BigDecimal getFilterFlg() {
		return filterFlg;
	}
	public void setFilterFlg(BigDecimal filterFlg) {
		this.filterFlg = filterFlg;
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
