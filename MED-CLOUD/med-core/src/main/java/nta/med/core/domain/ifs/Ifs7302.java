package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7302 database table.
 * 
 */
@Entity
@Table(name="IFS7302")
public class Ifs7302 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private String drgCode;
	private Double drgSeq;
	private String drgType;
	private Double fkifs7301;
	private String hospCode;
	private String nalsu;
	private String recGubunDrg;
	private String suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7302() {
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="DRG_CODE")
	public String getDrgCode() {
		return this.drgCode;
	}

	public void setDrgCode(String drgCode) {
		this.drgCode = drgCode;
	}


	@Column(name="DRG_SEQ")
	public Double getDrgSeq() {
		return this.drgSeq;
	}

	public void setDrgSeq(Double drgSeq) {
		this.drgSeq = drgSeq;
	}


	@Column(name="DRG_TYPE")
	public String getDrgType() {
		return this.drgType;
	}

	public void setDrgType(String drgType) {
		this.drgType = drgType;
	}


	public Double getFkifs7301() {
		return this.fkifs7301;
	}

	public void setFkifs7301(Double fkifs7301) {
		this.fkifs7301 = fkifs7301;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(String nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="REC_GUBUN_DRG")
	public String getRecGubunDrg() {
		return this.recGubunDrg;
	}

	public void setRecGubunDrg(String recGubunDrg) {
		this.recGubunDrg = recGubunDrg;
	}


	public String getSuryang() {
		return this.suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
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