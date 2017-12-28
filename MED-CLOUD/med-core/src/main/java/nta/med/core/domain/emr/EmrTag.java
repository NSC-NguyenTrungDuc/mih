package nta.med.core.domain.emr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the EMR_TAG database table.
 * 
 */
@Entity
@Table(name="EMR_TAG")
public class EmrTag implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="EMR_TAG_ID")
	private int emrTagId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	private String description;

	@Column(name="FILTER_FLG")
	private BigDecimal filterFlg;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Column(name="PERMISSION_TYPE")
	private String permissionType;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="TAG_CODE")
	private String tagCode;

	@Column(name="TAG_DISPLAY_TEXT")
	private String tagDisplayText;

	@Column(name="TAG_LEVEL")
	private String tagLevel;

	@Column(name="TAG_NAME")
	private String tagName;

	@Column(name="TAG_PARENT")
	private String tagParent;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public EmrTag() {
	}

	public int getEmrTagId() {
		return this.emrTagId;
	}

	public void setTagId(int emrTagId) {
		this.emrTagId = emrTagId;
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

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public BigDecimal getFilterFlg() {
		return this.filterFlg;
	}

	public void setFilterFlg(BigDecimal filterFlg) {
		this.filterFlg = filterFlg;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getPermissionType() {
		return this.permissionType;
	}

	public void setPermissionType(String permissionType) {
		this.permissionType = permissionType;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTagCode() {
		return this.tagCode;
	}

	public void setTagCode(String tagCode) {
		this.tagCode = tagCode;
	}

	public String getTagDisplayText() {
		return this.tagDisplayText;
	}

	public void setTagDisplayText(String tagDisplayText) {
		this.tagDisplayText = tagDisplayText;
	}

	public String getTagLevel() {
		return this.tagLevel;
	}

	public void setTagLevel(String tagLevel) {
		this.tagLevel = tagLevel;
	}

	public String getTagName() {
		return this.tagName;
	}

	public void setTagName(String tagName) {
		this.tagName = tagName;
	}

	public String getTagParent() {
		return this.tagParent;
	}

	public void setTagParent(String tagParent) {
		this.tagParent = tagParent;
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