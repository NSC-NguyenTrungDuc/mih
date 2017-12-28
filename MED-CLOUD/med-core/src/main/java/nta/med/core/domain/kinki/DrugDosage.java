package nta.med.core.domain.kinki;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_DOSAGE database table.
 * 
 */
@Entity
@Table(name="DRUG_DOSAGE")
@NamedQuery(name="DrugDosage.findAll", query="SELECT d FROM DrugDosage d")
public class DrugDosage  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a12;

	private String a13;

	private Integer a4;

	private Integer a5;

	private String a8;

	private BigDecimal activeFlg;

	private String adaptation;

	private String adaptationRelated;

	private String ageClassification;

	private String appropriate;

	private String appropriateCondition;

	private String branchNumber;

	private Timestamp created;

	private String dosageBranchNumber;

	private String drugId;

	private String oneDose;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public DrugDosage() {
	}

	public String getA12() {
		return this.a12;
	}

	public void setA12(String a12) {
		this.a12 = a12;
	}

	public String getA13() {
		return this.a13;
	}

	public void setA13(String a13) {
		this.a13 = a13;
	}

	public Integer getA4() {
		return this.a4;
	}

	public void setA4(Integer a4) {
		this.a4 = a4;
	}

	public Integer getA5() {
		return this.a5;
	}

	public void setA5(Integer a5) {
		this.a5 = a5;
	}

	public String getA8() {
		return this.a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}

	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getAdaptation() {
		return this.adaptation;
	}

	public void setAdaptation(String adaptation) {
		this.adaptation = adaptation;
	}

	@Column(name="ADAPTATION_RELATED")
	public String getAdaptationRelated() {
		return this.adaptationRelated;
	}

	public void setAdaptationRelated(String adaptationRelated) {
		this.adaptationRelated = adaptationRelated;
	}

	@Column(name="AGE_CLASSIFICATION")
	public String getAgeClassification() {
		return this.ageClassification;
	}

	public void setAgeClassification(String ageClassification) {
		this.ageClassification = ageClassification;
	}

	public String getAppropriate() {
		return this.appropriate;
	}

	public void setAppropriate(String appropriate) {
		this.appropriate = appropriate;
	}

	@Column(name="APPROPRIATE_CONDITION")
	public String getAppropriateCondition() {
		return this.appropriateCondition;
	}

	public void setAppropriateCondition(String appropriateCondition) {
		this.appropriateCondition = appropriateCondition;
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

	@Column(name="ONE_DOSE")
	public String getOneDose() {
		return this.oneDose;
	}

	public void setOneDose(String oneDose) {
		this.oneDose = oneDose;
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