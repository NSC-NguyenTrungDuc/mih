package nta.med.core.domain.kinki;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the DRUG_KINKI_DISEASE database table.
 * 
 */
@Entity
@Table(name="DRUG_KINKI_DISEASE")
@NamedQuery(name="DrugKinkiDisease.findAll", query="SELECT d FROM DrugKinkiDisease d")
public class DrugKinkiDisease  extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;
	private String comment;
	private Timestamp created;
	private BigDecimal decisionFlg;
	private String diseaseCode;
	private String diseaseName;
	private String icd10;
	private String indexTerm;
	private String kinkiId;
	private String standardDiseaseName;
	private String sysId;
	private String updId;
	private Timestamp updated;

	public DrugKinkiDisease() {
	}

	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
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

	@Column(name="DECISION_FLG")
	public BigDecimal getDecisionFlg() {
		return this.decisionFlg;
	}

	public void setDecisionFlg(BigDecimal decisionFlg) {
		this.decisionFlg = decisionFlg;
	}

	@Column(name="DISEASE_CODE")
	public String getDiseaseCode() {
		return this.diseaseCode;
	}

	public void setDiseaseCode(String diseaseCode) {
		this.diseaseCode = diseaseCode;
	}

	@Column(name="DISEASE_NAME")
	public String getDiseaseName() {
		return this.diseaseName;
	}

	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}

	public String getIcd10() {
		return this.icd10;
	}

	public void setIcd10(String icd10) {
		this.icd10 = icd10;
	}

	@Column(name="INDEX_TERM")
	public String getIndexTerm() {
		return this.indexTerm;
	}

	public void setIndexTerm(String indexTerm) {
		this.indexTerm = indexTerm;
	}

	@Column(name="KINKI_ID")
	public String getKinkiId() {
		return this.kinkiId;
	}

	public void setKinkiId(String kinkiId) {
		this.kinkiId = kinkiId;
	}

	@Column(name="STANDARD_DISEASE_NAME")
	public String getStandardDiseaseName() {
		return this.standardDiseaseName;
	}

	public void setStandardDiseaseName(String standardDiseaseName) {
		this.standardDiseaseName = standardDiseaseName;
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