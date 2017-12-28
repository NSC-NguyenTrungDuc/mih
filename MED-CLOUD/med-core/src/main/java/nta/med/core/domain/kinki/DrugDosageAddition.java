package nta.med.core.domain.kinki;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_DOSAGE_ADDITION database table.
 * 
 */
@Entity
@Table(name="DRUG_DOSAGE_ADDITION")
@NamedQuery(name="DrugDosageAddition.findAll", query="SELECT d FROM DrugDosageAddition d")
public class DrugDosageAddition  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a100;

	private Integer a101;

	private String a73;

	private String a74;

	private String a75;

	private String a76;

	private String a77;

	private String a78;

	private String a79;

	private String a80;

	private String a81;

	private String a82;

	private String a83;

	private String a84;

	private String a85;

	private String a86;

	private String a87;

	private String a88;

	private String a89;

	private String a90;

	private String a91;

	private String a92;

	private String a93;

	private String a94;

	private String a95;

	private String a96;

	private String a97;

	private String a98;

	private String a99;


	private BigDecimal activeFlg;


	private String branchNumber;

	private Timestamp created;


	private String dosageBranchNumber;


	private String drugId;


	private String sysId;


	private String updId;

	private Timestamp updated;

	public DrugDosageAddition() {
	}

	public String getA100() {
		return this.a100;
	}

	public void setA100(String a100) {
		this.a100 = a100;
	}

	public Integer getA101() {
		return this.a101;
	}

	public void setA101(Integer a101) {
		this.a101 = a101;
	}

	public String getA73() {
		return this.a73;
	}

	public void setA73(String a73) {
		this.a73 = a73;
	}

	public String getA74() {
		return this.a74;
	}

	public void setA74(String a74) {
		this.a74 = a74;
	}

	public String getA75() {
		return this.a75;
	}

	public void setA75(String a75) {
		this.a75 = a75;
	}

	public String getA76() {
		return this.a76;
	}

	public void setA76(String a76) {
		this.a76 = a76;
	}

	public String getA77() {
		return this.a77;
	}

	public void setA77(String a77) {
		this.a77 = a77;
	}

	public String getA78() {
		return this.a78;
	}

	public void setA78(String a78) {
		this.a78 = a78;
	}

	public String getA79() {
		return this.a79;
	}

	public void setA79(String a79) {
		this.a79 = a79;
	}

	public String getA80() {
		return this.a80;
	}

	public void setA80(String a80) {
		this.a80 = a80;
	}

	public String getA81() {
		return this.a81;
	}

	public void setA81(String a81) {
		this.a81 = a81;
	}

	public String getA82() {
		return this.a82;
	}

	public void setA82(String a82) {
		this.a82 = a82;
	}

	public String getA83() {
		return this.a83;
	}

	public void setA83(String a83) {
		this.a83 = a83;
	}

	public String getA84() {
		return this.a84;
	}

	public void setA84(String a84) {
		this.a84 = a84;
	}

	public String getA85() {
		return this.a85;
	}

	public void setA85(String a85) {
		this.a85 = a85;
	}

	public String getA86() {
		return this.a86;
	}

	public void setA86(String a86) {
		this.a86 = a86;
	}

	public String getA87() {
		return this.a87;
	}

	public void setA87(String a87) {
		this.a87 = a87;
	}

	public String getA88() {
		return this.a88;
	}

	public void setA88(String a88) {
		this.a88 = a88;
	}

	public String getA89() {
		return this.a89;
	}

	public void setA89(String a89) {
		this.a89 = a89;
	}

	public String getA90() {
		return this.a90;
	}

	public void setA90(String a90) {
		this.a90 = a90;
	}

	public String getA91() {
		return this.a91;
	}

	public void setA91(String a91) {
		this.a91 = a91;
	}

	public String getA92() {
		return this.a92;
	}

	public void setA92(String a92) {
		this.a92 = a92;
	}

	public String getA93() {
		return this.a93;
	}

	public void setA93(String a93) {
		this.a93 = a93;
	}

	public String getA94() {
		return this.a94;
	}

	public void setA94(String a94) {
		this.a94 = a94;
	}

	public String getA95() {
		return this.a95;
	}

	public void setA95(String a95) {
		this.a95 = a95;
	}

	public String getA96() {
		return this.a96;
	}

	public void setA96(String a96) {
		this.a96 = a96;
	}

	public String getA97() {
		return this.a97;
	}

	public void setA97(String a97) {
		this.a97 = a97;
	}

	public String getA98() {
		return this.a98;
	}

	public void setA98(String a98) {
		this.a98 = a98;
	}

	public String getA99() {
		return this.a99;
	}

	public void setA99(String a99) {
		this.a99 = a99;
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