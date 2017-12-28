package nta.med.core.domain.emr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the SYS_PROPERTY database table.
 * 
 */
@Entity
@Table(name="SYS_PROPERTY")
@NamedQuery(name="SysProperty.findAll", query="SELECT s FROM SysProperty s")
public class SysProperty implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="PROPERTY_ID")
	private int propertyId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	@Column(name="DEFAULT_FLG")
	private BigDecimal defaultFlg;

	private String description;

	@Column(name="HOSP_CODE")
	private String hospCode;

	private String locale;

	@Column(name="MODULE_TYPE")
	private String moduleType;

	@Column(name="PROPERTY_CODE")
	private String propertyCode;

	@Column(name="PROPERTY_NAME")
	private String propertyName;

	@Column(name="PROPERTY_TYPE")
	private String propertyType;

	@Column(name="PROPERTY_VALUE")
	private String propertyValue;

	@Column(name="SORT_NO")
	private int sortNo;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public SysProperty() {
	}

	public int getPropertyId() {
		return this.propertyId;
	}

	public void setPropertyId(int propertyId) {
		this.propertyId = propertyId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public BigDecimal getDefaultFlg() {
		return this.defaultFlg;
	}

	public void setDefaultFlg(BigDecimal defaultFlg) {
		this.defaultFlg = defaultFlg;
	}

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getModuleType() {
		return this.moduleType;
	}

	public void setModuleType(String moduleType) {
		this.moduleType = moduleType;
	}

	public String getPropertyCode() {
		return this.propertyCode;
	}

	public void setPropertyCode(String propertyCode) {
		this.propertyCode = propertyCode;
	}

	public String getPropertyName() {
		return this.propertyName;
	}

	public void setPropertyName(String propertyName) {
		this.propertyName = propertyName;
	}

	public String getPropertyType() {
		return this.propertyType;
	}

	public void setPropertyType(String propertyType) {
		this.propertyType = propertyType;
	}

	public String getPropertyValue() {
		return this.propertyValue;
	}

	public void setPropertyValue(String propertyValue) {
		this.propertyValue = propertyValue;
	}

	public int getSortNo() {
		return this.sortNo;
	}

	public void setSortNo(int sortNo) {
		this.sortNo = sortNo;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}