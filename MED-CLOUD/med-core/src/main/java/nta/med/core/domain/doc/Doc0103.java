package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC0103 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc0103.findAll", query="SELECT d FROM Doc0103 d")
public class Doc0103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String certCcmt;
	private String certColm;
	private String certJncd;
	private String certVald;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc0103() {
	}


	@Column(name="CERT_CCMT")
	public String getCertCcmt() {
		return this.certCcmt;
	}

	public void setCertCcmt(String certCcmt) {
		this.certCcmt = certCcmt;
	}


	@Column(name="CERT_COLM")
	public String getCertColm() {
		return this.certColm;
	}

	public void setCertColm(String certColm) {
		this.certColm = certColm;
	}


	@Column(name="CERT_JNCD")
	public String getCertJncd() {
		return this.certJncd;
	}

	public void setCertJncd(String certJncd) {
		this.certJncd = certJncd;
	}


	@Column(name="CERT_VALD")
	public String getCertVald() {
		return this.certVald;
	}

	public void setCertVald(String certVald) {
		this.certVald = certVald;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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