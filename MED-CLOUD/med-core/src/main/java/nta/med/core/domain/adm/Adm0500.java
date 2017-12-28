package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the ADM0500 database table.
 * 
 */
@Entity
@Table(name = "ADM0500")
public class Adm0500 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String pgmId;
	private String pgmSysId;
	private Double seq;
	private String sysId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String hospCode;

	public Adm0500() {
	}

	@Column(name = "CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}

	@Column(name = "CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}

	@Column(name = "PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}

	@Column(name = "PGM_SYS_ID")
	public String getPgmSysId() {
		return this.pgmSysId;
	}

	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}

	@Column(name = "UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
}