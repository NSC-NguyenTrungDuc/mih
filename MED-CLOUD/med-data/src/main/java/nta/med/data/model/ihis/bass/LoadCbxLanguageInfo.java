package nta.med.data.model.ihis.bass;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class LoadCbxLanguageInfo {
	
	private Integer propertyId;
	private String propertyCode;
	private String propertyName;
	private String propertyValue;
	private String propertyType;
	private String moduleType;
	private BigDecimal defaultFlg;
	private Integer sortNo;
	private String description;
	private String locale;
	private String sysId;
	private String updId;
	private Timestamp created;
	private Timestamp updated;
	private BigDecimal activeFlg;
	public LoadCbxLanguageInfo(Integer propertyId, String propertyCode, String propertyName, String propertyValue,
			String propertyType, String moduleType, BigDecimal defaultFlg, Integer sortNo, String description,
			String locale, String sysId, String updId, Timestamp created, Timestamp updated, BigDecimal activeFlg) {
		super();
		this.propertyId = propertyId;
		this.propertyCode = propertyCode;
		this.propertyName = propertyName;
		this.propertyValue = propertyValue;
		this.propertyType = propertyType;
		this.moduleType = moduleType;
		this.defaultFlg = defaultFlg;
		this.sortNo = sortNo;
		this.description = description;
		this.locale = locale;
		this.sysId = sysId;
		this.updId = updId;
		this.created = created;
		this.updated = updated;
		this.activeFlg = activeFlg;
	}
	public Integer getPropertyId() {
		return propertyId;
	}
	public void setPropertyId(Integer propertyId) {
		this.propertyId = propertyId;
	}
	public String getPropertyCode() {
		return propertyCode;
	}
	public void setPropertyCode(String propertyCode) {
		this.propertyCode = propertyCode;
	}
	public String getPropertyName() {
		return propertyName;
	}
	public void setPropertyName(String propertyName) {
		this.propertyName = propertyName;
	}
	public String getPropertyValue() {
		return propertyValue;
	}
	public void setPropertyValue(String propertyValue) {
		this.propertyValue = propertyValue;
	}
	public String getPropertyType() {
		return propertyType;
	}
	public void setPropertyType(String propertyType) {
		this.propertyType = propertyType;
	}
	public String getModuleType() {
		return moduleType;
	}
	public void setModuleType(String moduleType) {
		this.moduleType = moduleType;
	}
	public BigDecimal getDefaultFlg() {
		return defaultFlg;
	}
	public void setDefaultFlg(BigDecimal defaultFlg) {
		this.defaultFlg = defaultFlg;
	}
	public Integer getSortNo() {
		return sortNo;
	}
	public void setSortNo(Integer sortNo) {
		this.sortNo = sortNo;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getLocale() {
		return locale;
	}
	public void setLocale(String locale) {
		this.locale = locale;
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
	public Timestamp getCreated() {
		return created;
	}
	public void setCreated(Timestamp created) {
		this.created = created;
	}
	public Timestamp getUpdated() {
		return updated;
	}
	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	
}
