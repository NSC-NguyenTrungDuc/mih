package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the ADM0100 database table.
 * 
 */
@Entity
@Table(name="ADM0100")
public class Adm0100 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String dispGrpId;
	private String grpDesc;
	private String grpId;
	private String grpNm;
	private Double grpSeq;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String language;

	public Adm0100() {
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


	@Column(name="DISP_GRP_ID")
	public String getDispGrpId() {
		return this.dispGrpId;
	}

	public void setDispGrpId(String dispGrpId) {
		this.dispGrpId = dispGrpId;
	}


	@Column(name="GRP_DESC")
	public String getGrpDesc() {
		return this.grpDesc;
	}

	public void setGrpDesc(String grpDesc) {
		this.grpDesc = grpDesc;
	}


	@Column(name="GRP_ID")
	public String getGrpId() {
		return this.grpId;
	}

	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}


	@Column(name="GRP_NM")
	public String getGrpNm() {
		return this.grpNm;
	}

	public void setGrpNm(String grpNm) {
		this.grpNm = grpNm;
	}


	@Column(name="GRP_SEQ")
	public Double getGrpSeq() {
		return this.grpSeq;
	}

	public void setGrpSeq(Double grpSeq) {
		this.grpSeq = grpSeq;
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}

}