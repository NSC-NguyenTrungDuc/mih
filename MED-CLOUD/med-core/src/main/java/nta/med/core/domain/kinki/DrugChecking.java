package nta.med.core.domain.kinki;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRUG_CHECKING database table.
 * 
 */
@Entity
@Table(name="DRUG_CHECKING")
@NamedQuery(name="DrugChecking.findAll", query="SELECT d FROM DrugChecking d")
public class DrugChecking  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a11;

	private String a12;

	private String a13;

	private String a14;

	private String a15;

	private String a16;

	private String a17;

	private String a18;

	private Integer a19;

	private String a20;

	private Integer a21;

	private Integer a22;

	private String a23;

	private String a24;

	private Date a25;

	private Date a26;

	private Date a27;

	private Date a28;

	private String a3;

	private String a4;

	private String a5;

	private String a6;

	private String a7;

	private String a8;

	private String a9;

	private BigDecimal activeFlg;

	private String branchNumber;

	private Timestamp created;

	private String drugId;

	private String sysId;

	private String updId;

	private Timestamp updated;

	private String yjCode;

	public DrugChecking() {
	}

	public String getA11() {
		return this.a11;
	}

	public void setA11(String a11) {
		this.a11 = a11;
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

	public String getA14() {
		return this.a14;
	}

	public void setA14(String a14) {
		this.a14 = a14;
	}

	public String getA15() {
		return this.a15;
	}

	public void setA15(String a15) {
		this.a15 = a15;
	}

	public String getA16() {
		return this.a16;
	}

	public void setA16(String a16) {
		this.a16 = a16;
	}

	public String getA17() {
		return this.a17;
	}

	public void setA17(String a17) {
		this.a17 = a17;
	}

	public String getA18() {
		return this.a18;
	}

	public void setA18(String a18) {
		this.a18 = a18;
	}

	public Integer getA19() {
		return this.a19;
	}

	public void setA19(Integer a19) {
		this.a19 = a19;
	}

	public String getA20() {
		return this.a20;
	}

	public void setA20(String a20) {
		this.a20 = a20;
	}

	public Integer getA21() {
		return this.a21;
	}

	public void setA21(Integer a21) {
		this.a21 = a21;
	}

	public Integer getA22() {
		return this.a22;
	}

	public void setA22(Integer a22) {
		this.a22 = a22;
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

	@Temporal(TemporalType.TIMESTAMP)
	public Date getA25() {
		return this.a25;
	}

	public void setA25(Date a25) {
		this.a25 = a25;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getA26() {
		return this.a26;
	}

	public void setA26(Date a26) {
		this.a26 = a26;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getA27() {
		return this.a27;
	}

	public void setA27(Date a27) {
		this.a27 = a27;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getA28() {
		return this.a28;
	}

	public void setA28(Date a28) {
		this.a28 = a28;
	}

	public String getA3() {
		return this.a3;
	}

	public void setA3(String a3) {
		this.a3 = a3;
	}

	public String getA4() {
		return this.a4;
	}

	public void setA4(String a4) {
		this.a4 = a4;
	}

	public String getA5() {
		return this.a5;
	}

	public void setA5(String a5) {
		this.a5 = a5;
	}

	public String getA6() {
		return this.a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}

	public String getA7() {
		return this.a7;
	}

	public void setA7(String a7) {
		this.a7 = a7;
	}

	public String getA8() {
		return this.a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}

	public String getA9() {
		return this.a9;
	}

	public void setA9(String a9) {
		this.a9 = a9;
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

	@Column(name="YJ_CODE")
	public String getYjCode() {
		return this.yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}

}