package nta.med.core.domain.kinki;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRUG_GENERIC_NAME database table.
 * 
 */
@Entity
@Table(name="DRUG_GENERIC_NAME")
@NamedQuery(name="DrugGenericName.findAll", query="SELECT d FROM DrugGenericName d")
public class DrugGenericName  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String a6;

	private Integer a8;

	private BigDecimal activeFlg;

	private String branchNumber;

	private String comment1;

	private String comment2;

	private Timestamp created;

	private Integer describedClassification;

	private String drugId;

	private Integer orderNote;

	private String sysId;

	private String updId;

	private Timestamp updated;

	private String yj9Code;

	private String yj9CodeEffect;

	public DrugGenericName() {
	}

	public String getA6() {
		return this.a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}

	public Integer getA8() {
		return this.a8;
	}

	public void setA8(Integer a8) {
		this.a8 = a8;
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

	public String getComment1() {
		return this.comment1;
	}

	public void setComment1(String comment1) {
		this.comment1 = comment1;
	}

	public String getComment2() {
		return this.comment2;
	}

	public void setComment2(String comment2) {
		this.comment2 = comment2;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name="DESCRIBED_CLASSIFICATION")
	public Integer getDescribedClassification() {
		return this.describedClassification;
	}

	public void setDescribedClassification(Integer describedClassification) {
		this.describedClassification = describedClassification;
	}

	@Column(name="DRUG_ID")
	public String getDrugId() {
		return this.drugId;
	}

	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}

	@Column(name="ORDER_NOTE")
	public Integer getOrderNote() {
		return this.orderNote;
	}

	public void setOrderNote(Integer orderNote) {
		this.orderNote = orderNote;
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

	@Column(name="YJ9_CODE")
	public String getYj9Code() {
		return this.yj9Code;
	}

	public void setYj9Code(String yj9Code) {
		this.yj9Code = yj9Code;
	}

	@Column(name="YJ9_CODE_EFFECT")
	public String getYj9CodeEffect() {
		return this.yj9CodeEffect;
	}

	public void setYj9CodeEffect(String yj9CodeEffect) {
		this.yj9CodeEffect = yj9CodeEffect;
	}

}