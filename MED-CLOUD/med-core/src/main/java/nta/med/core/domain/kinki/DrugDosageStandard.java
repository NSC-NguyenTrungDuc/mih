package nta.med.core.domain.kinki;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_DOSAGE_STANDARD database table.
 * 
 */
@Entity
@Table(name="DRUG_DOSAGE_STANDARD")
@NamedQuery(name="DrugDosageStandard.findAll", query="SELECT d FROM DrugDosageStandard d")
public class DrugDosageStandard  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a44;

	private String a45;

	private String a46;

	private String a47;

	private String a48;

	private String a49;

	private String a50;

	private String a51;

	private String a52;

	private String a53;

	private String a54;

	private String a55;

	private String a56;

	private String a57;

	private String a58;

	private String a59;

	private String a60;

	private String a61;

	private String a62;

	private String a63;

	private String a64;

	private String a65;

	private String a66;

	private String a67;

	private String a68;

	private String a69;

	private String a70;

	private String a71;

	private String a72;

	private BigDecimal activeFlg;

	private String branchNumber;

	private Timestamp created;

	private String dosageBranchNumber;

	private String drugId;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public DrugDosageStandard() {
	}

	public String getA44() {
		return this.a44;
	}

	public void setA44(String a44) {
		this.a44 = a44;
	}

	public String getA45() {
		return this.a45;
	}

	public void setA45(String a45) {
		this.a45 = a45;
	}

	public String getA46() {
		return this.a46;
	}

	public void setA46(String a46) {
		this.a46 = a46;
	}

	public String getA47() {
		return this.a47;
	}

	public void setA47(String a47) {
		this.a47 = a47;
	}

	public String getA48() {
		return this.a48;
	}

	public void setA48(String a48) {
		this.a48 = a48;
	}

	public String getA49() {
		return this.a49;
	}

	public void setA49(String a49) {
		this.a49 = a49;
	}

	public String getA50() {
		return this.a50;
	}

	public void setA50(String a50) {
		this.a50 = a50;
	}

	public String getA51() {
		return this.a51;
	}

	public void setA51(String a51) {
		this.a51 = a51;
	}

	public String getA52() {
		return this.a52;
	}

	public void setA52(String a52) {
		this.a52 = a52;
	}

	public String getA53() {
		return this.a53;
	}

	public void setA53(String a53) {
		this.a53 = a53;
	}

	public String getA54() {
		return this.a54;
	}

	public void setA54(String a54) {
		this.a54 = a54;
	}

	public String getA55() {
		return this.a55;
	}

	public void setA55(String a55) {
		this.a55 = a55;
	}

	public String getA56() {
		return this.a56;
	}

	public void setA56(String a56) {
		this.a56 = a56;
	}

	public String getA57() {
		return this.a57;
	}

	public void setA57(String a57) {
		this.a57 = a57;
	}

	public String getA58() {
		return this.a58;
	}

	public void setA58(String a58) {
		this.a58 = a58;
	}

	public String getA59() {
		return this.a59;
	}

	public void setA59(String a59) {
		this.a59 = a59;
	}

	public String getA60() {
		return this.a60;
	}

	public void setA60(String a60) {
		this.a60 = a60;
	}

	public String getA61() {
		return this.a61;
	}

	public void setA61(String a61) {
		this.a61 = a61;
	}

	public String getA62() {
		return this.a62;
	}

	public void setA62(String a62) {
		this.a62 = a62;
	}

	public String getA63() {
		return this.a63;
	}

	public void setA63(String a63) {
		this.a63 = a63;
	}

	public String getA64() {
		return this.a64;
	}

	public void setA64(String a64) {
		this.a64 = a64;
	}

	public String getA65() {
		return this.a65;
	}

	public void setA65(String a65) {
		this.a65 = a65;
	}

	public String getA66() {
		return this.a66;
	}

	public void setA66(String a66) {
		this.a66 = a66;
	}

	public String getA67() {
		return this.a67;
	}

	public void setA67(String a67) {
		this.a67 = a67;
	}

	public String getA68() {
		return this.a68;
	}

	public void setA68(String a68) {
		this.a68 = a68;
	}

	public String getA69() {
		return this.a69;
	}

	public void setA69(String a69) {
		this.a69 = a69;
	}

	public String getA70() {
		return this.a70;
	}

	public void setA70(String a70) {
		this.a70 = a70;
	}

	public String getA71() {
		return this.a71;
	}

	public void setA71(String a71) {
		this.a71 = a71;
	}

	public String getA72() {
		return this.a72;
	}

	public void setA72(String a72) {
		this.a72 = a72;
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

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name="DOSAGE_BRANCH_NUMBER")
	public String getDosageBranchNumber() {
		return this.dosageBranchNumber;
	}

	public void setDosageBranchNumber(String dosageBranchNumber) {
		this.dosageBranchNumber = dosageBranchNumber;
	}

	@Column(name="DRUG_ID")
	public String getDrugId() {
		return this.drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
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

}