package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC0101 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc0101.findAll", query="SELECT d FROM Doc0101 d")
public class Doc0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String certEuse;
	private String certIuse;
	private String certJncd;
	private String certJnnm;
	private String certOuse;
	private String certRqgb;
	private String certVald;
	private String certWmcd;
	private String certWuse;
	private String dataWin;
	private String hospCode;
	private String outGubun;
	private double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String useGubun;

	public Doc0101() {
	}


	@Column(name="CERT_EUSE")
	public String getCertEuse() {
		return this.certEuse;
	}

	public void setCertEuse(String certEuse) {
		this.certEuse = certEuse;
	}


	@Column(name="CERT_IUSE")
	public String getCertIuse() {
		return this.certIuse;
	}

	public void setCertIuse(String certIuse) {
		this.certIuse = certIuse;
	}


	@Column(name="CERT_JNCD")
	public String getCertJncd() {
		return this.certJncd;
	}

	public void setCertJncd(String certJncd) {
		this.certJncd = certJncd;
	}


	@Column(name="CERT_JNNM")
	public String getCertJnnm() {
		return this.certJnnm;
	}

	public void setCertJnnm(String certJnnm) {
		this.certJnnm = certJnnm;
	}


	@Column(name="CERT_OUSE")
	public String getCertOuse() {
		return this.certOuse;
	}

	public void setCertOuse(String certOuse) {
		this.certOuse = certOuse;
	}


	@Column(name="CERT_RQGB")
	public String getCertRqgb() {
		return this.certRqgb;
	}

	public void setCertRqgb(String certRqgb) {
		this.certRqgb = certRqgb;
	}


	@Column(name="CERT_VALD")
	public String getCertVald() {
		return this.certVald;
	}

	public void setCertVald(String certVald) {
		this.certVald = certVald;
	}


	@Column(name="CERT_WMCD")
	public String getCertWmcd() {
		return this.certWmcd;
	}

	public void setCertWmcd(String certWmcd) {
		this.certWmcd = certWmcd;
	}


	@Column(name="CERT_WUSE")
	public String getCertWuse() {
		return this.certWuse;
	}

	public void setCertWuse(String certWuse) {
		this.certWuse = certWuse;
	}


	@Column(name="DATA_WIN")
	public String getDataWin() {
		return this.dataWin;
	}

	public void setDataWin(String dataWin) {
		this.dataWin = dataWin;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="OUT_GUBUN")
	public String getOutGubun() {
		return this.outGubun;
	}

	public void setOutGubun(String outGubun) {
		this.outGubun = outGubun;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
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


	@Column(name="USE_GUBUN")
	public String getUseGubun() {
		return this.useGubun;
	}

	public void setUseGubun(String useGubun) {
		this.useGubun = useGubun;
	}

}