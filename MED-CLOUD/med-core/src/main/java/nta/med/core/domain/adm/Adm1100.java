package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM1100 database table.
 * 
 */
@Entity
@Table(name="ADM1100")
public class Adm1100 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cmmt;
	private String colId;
	private Double colLen;
	private String colNm;
	private Double colScal;
	private String colTp;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String upMemb;
	private Date upTime;
	private String upTrm;

	public Adm1100() {
	}


	public String getCmmt() {
		return this.cmmt;
	}

	public void setCmmt(String cmmt) {
		this.cmmt = cmmt;
	}


	@Column(name="COL_ID")
	public String getColId() {
		return this.colId;
	}

	public void setColId(String colId) {
		this.colId = colId;
	}


	@Column(name="COL_LEN")
	public Double getColLen() {
		return this.colLen;
	}

	public void setColLen(Double colLen) {
		this.colLen = colLen;
	}


	@Column(name="COL_NM")
	public String getColNm() {
		return this.colNm;
	}

	public void setColNm(String colNm) {
		this.colNm = colNm;
	}


	@Column(name="COL_SCAL")
	public Double getColScal() {
		return this.colScal;
	}

	public void setColScal(Double colScal) {
		this.colScal = colScal;
	}


	@Column(name="COL_TP")
	public String getColTp() {
		return this.colTp;
	}

	public void setColTp(String colTp) {
		this.colTp = colTp;
	}


	@Column(name="CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}

}