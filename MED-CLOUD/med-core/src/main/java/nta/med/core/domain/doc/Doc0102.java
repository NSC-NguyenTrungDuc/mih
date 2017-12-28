package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC0102 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc0102.findAll", query="SELECT d FROM Doc0102 d")
public class Doc0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String certJncd;
	private String certVald;
	private String gwa;
	private String hospCode;
	private double sort;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc0102() {
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


	public double getSort() {
		return this.sort;
	}

	public void setSort(double sort) {
		this.sort = sort;
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