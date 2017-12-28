package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR0902 database table.
 * 
 */
@Entity
@Table(name = "NUR0902")
public class Nur0902 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hoDong;
	private String hospCode;
	private String soapBun1;
	private String soapBun2;
	private String soapBun2Name;
	private String soapGubun;
	private double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur0902() {
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


	@Column(name="SOAP_BUN1")
	public String getSoapBun1() {
		return this.soapBun1;
	}

	public void setSoapBun1(String soapBun1) {
		this.soapBun1 = soapBun1;
	}


	@Column(name="SOAP_BUN2")
	public String getSoapBun2() {
		return this.soapBun2;
	}

	public void setSoapBun2(String soapBun2) {
		this.soapBun2 = soapBun2;
	}


	@Column(name="SOAP_BUN2_NAME")
	public String getSoapBun2Name() {
		return this.soapBun2Name;
	}

	public void setSoapBun2Name(String soapBun2Name) {
		this.soapBun2Name = soapBun2Name;
	}


	@Column(name="SOAP_GUBUN")
	public String getSoapGubun() {
		return this.soapGubun;
	}

	public void setSoapGubun(String soapGubun) {
		this.soapGubun = soapGubun;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}