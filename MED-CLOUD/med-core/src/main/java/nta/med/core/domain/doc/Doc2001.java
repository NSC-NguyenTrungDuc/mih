package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC2001 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc2001.findAll", query="SELECT d FROM Doc2001 d")
public class Doc2001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String certColm;
	private String certInfo;
	private String certJncd;
	private double certPgno;
	private Date certRqdt;
	private double certSeqn;
	private String certVald;
	private Date certWrdt;
	private double fkdoc1001;
	private String gwa;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc2001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CERT_COLM")
	public String getCertColm() {
		return this.certColm;
	}

	public void setCertColm(String certColm) {
		this.certColm = certColm;
	}


	@Column(name="CERT_INFO")
	public String getCertInfo() {
		return this.certInfo;
	}

	public void setCertInfo(String certInfo) {
		this.certInfo = certInfo;
	}


	@Column(name="CERT_JNCD")
	public String getCertJncd() {
		return this.certJncd;
	}

	public void setCertJncd(String certJncd) {
		this.certJncd = certJncd;
	}


	@Column(name="CERT_PGNO")
	public double getCertPgno() {
		return this.certPgno;
	}

	public void setCertPgno(double certPgno) {
		this.certPgno = certPgno;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CERT_RQDT")
	public Date getCertRqdt() {
		return this.certRqdt;
	}

	public void setCertRqdt(Date certRqdt) {
		this.certRqdt = certRqdt;
	}


	@Column(name="CERT_SEQN")
	public double getCertSeqn() {
		return this.certSeqn;
	}

	public void setCertSeqn(double certSeqn) {
		this.certSeqn = certSeqn;
	}


	@Column(name="CERT_VALD")
	public String getCertVald() {
		return this.certVald;
	}

	public void setCertVald(String certVald) {
		this.certVald = certVald;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CERT_WRDT")
	public Date getCertWrdt() {
		return this.certWrdt;
	}

	public void setCertWrdt(Date certWrdt) {
		this.certWrdt = certWrdt;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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