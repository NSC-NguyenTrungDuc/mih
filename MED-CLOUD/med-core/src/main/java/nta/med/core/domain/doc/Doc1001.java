package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1001.findAll", query="SELECT d FROM Doc1001 d")
public class Doc1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String certBigo;
	private String certIogb;
	private String certJncd;
	private String certPrgb;
	private Date certRqdt;
	private double certRqnu;
	private double certSeqn;
	private String certVald;
	private Date certWrdt;
	private String certWrgb;
	private String certWrid;
	private double fkinp1001;
	private String fkout1001;
	private String gwa;
	private String hoDong;
	private String hospCode;
	private double pkdoc1001;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc1001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CERT_BIGO")
	public String getCertBigo() {
		return this.certBigo;
	}

	public void setCertBigo(String certBigo) {
		this.certBigo = certBigo;
	}


	@Column(name="CERT_IOGB")
	public String getCertIogb() {
		return this.certIogb;
	}

	public void setCertIogb(String certIogb) {
		this.certIogb = certIogb;
	}


	@Column(name="CERT_JNCD")
	public String getCertJncd() {
		return this.certJncd;
	}

	public void setCertJncd(String certJncd) {
		this.certJncd = certJncd;
	}


	@Column(name="CERT_PRGB")
	public String getCertPrgb() {
		return this.certPrgb;
	}

	public void setCertPrgb(String certPrgb) {
		this.certPrgb = certPrgb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CERT_RQDT")
	public Date getCertRqdt() {
		return this.certRqdt;
	}

	public void setCertRqdt(Date certRqdt) {
		this.certRqdt = certRqdt;
	}


	@Column(name="CERT_RQNU")
	public double getCertRqnu() {
		return this.certRqnu;
	}

	public void setCertRqnu(double certRqnu) {
		this.certRqnu = certRqnu;
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


	@Column(name="CERT_WRGB")
	public String getCertWrgb() {
		return this.certWrgb;
	}

	public void setCertWrgb(String certWrgb) {
		this.certWrgb = certWrgb;
	}


	@Column(name="CERT_WRID")
	public String getCertWrid() {
		return this.certWrid;
	}

	public void setCertWrid(String certWrid) {
		this.certWrid = certWrid;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPkdoc1001() {
		return this.pkdoc1001;
	}

	public void setPkdoc1001(double pkdoc1001) {
		this.pkdoc1001 = pkdoc1001;
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