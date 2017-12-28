package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0801 database table.
 * 
 */
@Entity
@Table(name="OCS0801")
public class Ocs0801 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String defaultPatStatusCode;
	private String ment;
	private String patStatus;
	private String patStatusName;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Ocs0801() {
	}


	@Column(name="DEFAULT_PAT_STATUS_CODE")
	public String getDefaultPatStatusCode() {
		return this.defaultPatStatusCode;
	}

	public void setDefaultPatStatusCode(String defaultPatStatusCode) {
		this.defaultPatStatusCode = defaultPatStatusCode;
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


	@Column(name="PAT_STATUS_NAME")
	public String getPatStatusName() {
		return this.patStatusName;
	}

	public void setPatStatusName(String patStatusName) {
		this.patStatusName = patStatusName;
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}
}