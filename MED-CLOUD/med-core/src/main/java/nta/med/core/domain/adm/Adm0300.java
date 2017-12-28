package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the ADM0300 database table.
 * 
 */
@Entity
@Table(name="ADM0300")
public class Adm0300 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String asmName;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String endYn;
	private String mangMemb;
	private String pgmAcsYn;
	private String pgmDupYn;
	private Double pgmEntGrad;
	private String pgmId;
	private String pgmNm;
	private String pgmScrt;
	private String pgmTp;
	private Double pgmUpdGrad;
	private String prodId;
	private String srvcId;
	private String sysId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String language;

	public Adm0300() {
	}
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}

	@Column(name="ASM_NAME")
	public String getAsmName() {
		return this.asmName;
	}

	public void setAsmName(String asmName) {
		this.asmName = asmName;
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


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	@Column(name="MANG_MEMB")
	public String getMangMemb() {
		return this.mangMemb;
	}

	public void setMangMemb(String mangMemb) {
		this.mangMemb = mangMemb;
	}


	@Column(name="PGM_ACS_YN")
	public String getPgmAcsYn() {
		return this.pgmAcsYn;
	}

	public void setPgmAcsYn(String pgmAcsYn) {
		this.pgmAcsYn = pgmAcsYn;
	}


	@Column(name="PGM_DUP_YN")
	public String getPgmDupYn() {
		return this.pgmDupYn;
	}

	public void setPgmDupYn(String pgmDupYn) {
		this.pgmDupYn = pgmDupYn;
	}


	@Column(name="PGM_ENT_GRAD")
	public Double getPgmEntGrad() {
		return this.pgmEntGrad;
	}

	public void setPgmEntGrad(Double pgmEntGrad) {
		this.pgmEntGrad = pgmEntGrad;
	}


	@Column(name="PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}


	@Column(name="PGM_NM")
	public String getPgmNm() {
		return this.pgmNm;
	}

	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}


	@Column(name="PGM_SCRT")
	public String getPgmScrt() {
		return this.pgmScrt;
	}

	public void setPgmScrt(String pgmScrt) {
		this.pgmScrt = pgmScrt;
	}


	@Column(name="PGM_TP")
	public String getPgmTp() {
		return this.pgmTp;
	}

	public void setPgmTp(String pgmTp) {
		this.pgmTp = pgmTp;
	}


	@Column(name="PGM_UPD_GRAD")
	public Double getPgmUpdGrad() {
		return this.pgmUpdGrad;
	}

	public void setPgmUpdGrad(Double pgmUpdGrad) {
		this.pgmUpdGrad = pgmUpdGrad;
	}


	@Column(name="PROD_ID")
	public String getProdId() {
		return this.prodId;
	}

	public void setProdId(String prodId) {
		this.prodId = prodId;
	}


	@Column(name="SRVC_ID")
	public String getSrvcId() {
		return this.srvcId;
	}

	public void setSrvcId(String srvcId) {
		this.srvcId = srvcId;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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