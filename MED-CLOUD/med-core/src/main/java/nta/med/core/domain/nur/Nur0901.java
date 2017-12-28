package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0901 database table.
 * 
 */
@Entity
@Table(name = "NUR0901")
public class Nur0901 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hoDong;
	private String hospCode;
	private String soapBun1;
	private String soapBun1Name;
	private String soapGubun;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur0901() {
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "SOAP_BUN1")
	public String getSoapBun1() {
		return this.soapBun1;
	}

	public void setSoapBun1(String soapBun1) {
		this.soapBun1 = soapBun1;
	}

	@Column(name = "SOAP_BUN1_NAME")
	public String getSoapBun1Name() {
		return this.soapBun1Name;
	}

	public void setSoapBun1Name(String soapBun1Name) {
		this.soapBun1Name = soapBun1Name;
	}

	@Column(name = "SOAP_GUBUN")
	public String getSoapGubun() {
		return this.soapGubun;
	}

	public void setSoapGubun(String soapGubun) {
		this.soapGubun = soapGubun;
	}

	@Column(name = "SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
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