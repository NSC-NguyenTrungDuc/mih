package nta.med.core.domain.kinki;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_KINKI_MESSAGE database table.
 * 
 */
@Entity
@Table(name="DRUG_KINKI_MESSAGE")
@NamedQuery(name="DrugKinkiMessage.findAll", query="SELECT d FROM DrugKinkiMessage d")
public class DrugKinkiMessage  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;
	private String branchNumber;
	private String category;
	private Timestamp created;
	private String drugId;
	private String kinkiId;
	private String message;
	private String sysId;
	private String updId;
	private Timestamp updated;
	private BigDecimal warningLevel;

	public DrugKinkiMessage() {
	}
	
	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name="BRANCH_NUMBER")
	public String getBranchNumber() {
		return this.branchNumber;
	}

	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}

	public String getCategory() {
		return this.category;
	}

	public void setCategory(String category) {
		this.category = category;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name="DRUG_ID")
	public String getDrugId() {
		return this.drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}

	@Column(name="KINKI_ID")
	public String getKinkiId() {
		return this.kinkiId;
	}

	public void setKinkiId(String kinkiId) {
		this.kinkiId = kinkiId;
	}

	public String getMessage() {
		return this.message;
	}

	public void setMessage(String message) {
		this.message = message;
	}

	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name="UPD_ID")
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

	@Column(name="WARNING_LEVEL")
	public BigDecimal getWarningLevel() {
		return this.warningLevel;
	}

	public void setWarningLevel(BigDecimal warningLevel) {
		this.warningLevel = warningLevel;
	}

}