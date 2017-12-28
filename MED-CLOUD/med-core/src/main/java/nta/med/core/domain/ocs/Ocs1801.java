package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS1801 database table.
 * 
 */
@Entity
@Table(name="OCS1801")
public class Ocs1801 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String hospCode;
	private String ment;
	private String patStatus;
	private String patStatusCode;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs1801() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Column(name="PAT_STATUS")
	public String getPatStatus() {
		return this.patStatus;
	}

	public void setPatStatus(String patStatus) {
		this.patStatus = patStatus;
	}


	@Column(name="PAT_STATUS_CODE")
	public String getPatStatusCode() {
		return this.patStatusCode;
	}

	public void setPatStatusCode(String patStatusCode) {
		this.patStatusCode = patStatusCode;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}