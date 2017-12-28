package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1008 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1008.findAll", query="SELECT d FROM Doc1008 d")
public class Doc1008 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String danui;
	private double dvTime;
	private double fkdoc1007;
	private String hangmogCode;
	private String hospCode;
	private String kyukyeok;
	private double nalsu;
	private double seq;
	private String suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc1008() {
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DV_TIME")
	public double getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(double dvTime) {
		this.dvTime = dvTime;
	}


	public double getFkdoc1007() {
		return this.fkdoc1007;
	}

	public void setFkdoc1007(double fkdoc1007) {
		this.fkdoc1007 = fkdoc1007;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getKyukyeok() {
		return this.kyukyeok;
	}

	public void setKyukyeok(String kyukyeok) {
		this.kyukyeok = kyukyeok;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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