package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0112 database table.
 * 
 */
@Entity
@Table(name = "NUR0112")
public class Nur0112 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String ment;
	private String nurGrCode;
	private String nurMdCode;
	private String nurSoCode;
	private String nurSoName;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur0112() {
	}

	@Column(name = "HOSP_CODE")
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

	@Column(name = "NUR_GR_CODE")
	public String getNurGrCode() {
		return this.nurGrCode;
	}

	public void setNurGrCode(String nurGrCode) {
		this.nurGrCode = nurGrCode;
	}

	@Column(name = "NUR_MD_CODE")
	public String getNurMdCode() {
		return this.nurMdCode;
	}

	public void setNurMdCode(String nurMdCode) {
		this.nurMdCode = nurMdCode;
	}

	@Column(name = "NUR_SO_CODE")
	public String getNurSoCode() {
		return this.nurSoCode;
	}

	public void setNurSoCode(String nurSoCode) {
		this.nurSoCode = nurSoCode;
	}

	@Column(name = "NUR_SO_NAME")
	public String getNurSoName() {
		return this.nurSoName;
	}

	public void setNurSoName(String nurSoName) {
		this.nurSoName = nurSoName;
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