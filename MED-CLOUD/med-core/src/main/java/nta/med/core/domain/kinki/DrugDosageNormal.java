package nta.med.core.domain.kinki;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRUG_DOSAGE_NORMAL database table.
 * 
 */
@Entity
@Table(name="DRUG_DOSAGE_NORMAL")
@NamedQuery(name="DrugDosageNormal.findAll", query="SELECT d FROM DrugDosageNormal d")
public class DrugDosageNormal  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a21;
	
	private String a22;

	private String a23;

	private String a24;

	private String a25;

	private String a26;

	private String a27;

	private String a28;

	private String a29;

	private String a30;

	private String a31;

	private String a32;

	private String a33;

	private String a34;

	private String a35;

	private String a36;

	private String a37;

	private String a38;

	private String a39;

	private String a40;

	private String a41;

	private String a42;

	private String a43;


	private BigDecimal activeFlg;


	private String branchNumber;

	private Timestamp created;


	private String dailyDoesContent;


	private String dailyDose;


	private String dailyDoseForm;


	private String dailyNumberDoses;


	private String dosageBranchNumber;


	private String dosageFormUnit;


	private String doseForm;


	private String drugId;


	private String sysId;


	private String updId;

	private Timestamp updated;

	public DrugDosageNormal() {
	}

	public String getA21() {
		return this.a21;
	}

	public void setA21(String a21) {
		this.a21 = a21;
	}

	public String getA22() {
		return this.a22;
	}

	public void setA22(String a22) {
		this.a21 = a22;
	}
	
	public String getA23() {
		return this.a23;
	}

	public void setA23(String a23) {
		this.a23 = a23;
	}

	public String getA24() {
		return this.a24;
	}

	public void setA24(String a24) {
		this.a24 = a24;
	}

	public String getA25() {
		return this.a25;
	}

	public void setA25(String a25) {
		this.a25 = a25;
	}

	public String getA26() {
		return this.a26;
	}

	public void setA26(String a26) {
		this.a26 = a26;
	}

	public String getA27() {
		return this.a27;
	}

	public void setA27(String a27) {
		this.a27 = a27;
	}

	public String getA28() {
		return this.a28;
	}

	public void setA28(String a28) {
		this.a28 = a28;
	}

	public String getA29() {
		return this.a29;
	}

	public void setA29(String a29) {
		this.a29 = a29;
	}

	public String getA30() {
		return this.a30;
	}

	public void setA30(String a30) {
		this.a30 = a30;
	}

	public String getA31() {
		return this.a31;
	}

	public void setA31(String a31) {
		this.a31 = a31;
	}

	public String getA32() {
		return this.a32;
	}

	public void setA32(String a32) {
		this.a32 = a32;
	}

	public String getA33() {
		return this.a33;
	}

	public void setA33(String a33) {
		this.a33 = a33;
	}

	public String getA34() {
		return this.a34;
	}

	public void setA34(String a34) {
		this.a34 = a34;
	}

	public String getA35() {
		return this.a35;
	}

	public void setA35(String a35) {
		this.a35 = a35;
	}

	public String getA36() {
		return this.a36;
	}

	public void setA36(String a36) {
		this.a36 = a36;
	}

	public String getA37() {
		return this.a37;
	}

	public void setA37(String a37) {
		this.a37 = a37;
	}

	public String getA38() {
		return this.a38;
	}

	public void setA38(String a38) {
		this.a38 = a38;
	}

	public String getA39() {
		return this.a39;
	}

	public void setA39(String a39) {
		this.a39 = a39;
	}

	public String getA40() {
		return this.a40;
	}

	public void setA40(String a40) {
		this.a40 = a40;
	}

	public String getA41() {
		return this.a41;
	}

	public void setA41(String a41) {
		this.a41 = a41;
	}

	public String getA42() {
		return this.a42;
	}

	public void setA42(String a42) {
		this.a42 = a42;
	}

	public String getA43() {
		return this.a43;
	}

	public void setA43(String a43) {
		this.a43 = a43;
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
	@Column(name="DAILY_DOES_CONTENT")
	public String getDailyDoesContent() {
		return this.dailyDoesContent;
	}

	public void setDailyDoesContent(String dailyDoesContent) {
		this.dailyDoesContent = dailyDoesContent;
	}
	@Column(name="DAILY_DOSE")
	public String getDailyDose() {
		return this.dailyDose;
	}

	public void setDailyDose(String dailyDose) {
		this.dailyDose = dailyDose;
	}
	@Column(name="DAILY_DOSE_FORM")
	public String getDailyDoseForm() {
		return this.dailyDoseForm;
	}

	public void setDailyDoseForm(String dailyDoseForm) {
		this.dailyDoseForm = dailyDoseForm;
	}
	@Column(name="DAILY_NUMBER_DOSES")
	public String getDailyNumberDoses() {
		return this.dailyNumberDoses;
	}

	public void setDailyNumberDoses(String dailyNumberDoses) {
		this.dailyNumberDoses = dailyNumberDoses;
	}
	@Column(name="DOSAGE_BRANCH_NUMBER")
	public String getDosageBranchNumber() {
		return this.dosageBranchNumber;
	}

	public void setDosageBranchNumber(String dosageBranchNumber) {
		this.dosageBranchNumber = dosageBranchNumber;
	}
	@Column(name="DOSAGE_FORM_UNIT")
	public String getDosageFormUnit() {
		return this.dosageFormUnit;
	}

	public void setDosageFormUnit(String dosageFormUnit) {
		this.dosageFormUnit = dosageFormUnit;
	}
	@Column(name="DOSE_FORM")
	public String getDoseForm() {
		return this.doseForm;
	}

	public void setDoseForm(String doseForm) {
		this.doseForm = doseForm;
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