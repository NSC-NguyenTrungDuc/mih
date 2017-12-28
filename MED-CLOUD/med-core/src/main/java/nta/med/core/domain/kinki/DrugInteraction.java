package nta.med.core.domain.kinki;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the DRUG_INTERACTION database table.
 * 
 */
@Entity
@Table(name="DRUG_INTERACTION")
@NamedQuery(name="DrugInteraction.findAll", query="SELECT d FROM DrugInteraction d")
public class DrugInteraction  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private Integer a11;

	private String a5;

	private String a6;

	private Integer a7;

	private Integer a8;

	private Integer a9;


	private BigDecimal activeFlg;


	private String branchNumber;

	private String comment;

	private Timestamp created;


	private Integer describedClassification;


	private String drugId;


	private Integer orderNote;


	private String sysId;


	private String updId;

	private Timestamp updated;


	private String yj9Code;

	public DrugInteraction() {
	}

	public Integer getA11() {
		return this.a11;
	}

	public void setA11(Integer a11) {
		this.a11 = a11;
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

	public Integer getA7() {
		return this.a7;
	}

	public void setA7(Integer a7) {
		this.a7 = a7;
	}

	public Integer getA8() {
		return this.a8;
	}

	public void setA8(Integer a8) {
		this.a8 = a8;
	}

	public Integer getA9() {
		return this.a9;
	}

	public void setA9(Integer a9) {
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

	public String getComment() {
		return this.comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
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

}