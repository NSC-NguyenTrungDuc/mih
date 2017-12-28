package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG3020 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg3020.findAll", query="SELECT d FROM Drg3020 d")
public class Drg3020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actFlag;
	private String hospCode;
	private String magamBunho;
	private String magamCancel;
	private Date magamDate;
	private String magamGubun;
	private String magamGubun2;
	private double magamSer;
	private String magamTime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg3020() {
	}


	@Column(name="ACT_FLAG")
	public String getActFlag() {
		return this.actFlag;
	}

	public void setActFlag(String actFlag) {
		this.actFlag = actFlag;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MAGAM_BUNHO")
	public String getMagamBunho() {
		return this.magamBunho;
	}

	public void setMagamBunho(String magamBunho) {
		this.magamBunho = magamBunho;
	}


	@Column(name="MAGAM_CANCEL")
	public String getMagamCancel() {
		return this.magamCancel;
	}

	public void setMagamCancel(String magamCancel) {
		this.magamCancel = magamCancel;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	@Column(name="MAGAM_GUBUN")
	public String getMagamGubun() {
		return this.magamGubun;
	}

	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}


	@Column(name="MAGAM_GUBUN2")
	public String getMagamGubun2() {
		return this.magamGubun2;
	}

	public void setMagamGubun2(String magamGubun2) {
		this.magamGubun2 = magamGubun2;
	}


	@Column(name="MAGAM_SER")
	public double getMagamSer() {
		return this.magamSer;
	}

	public void setMagamSer(double magamSer) {
		this.magamSer = magamSer;
	}


	@Column(name="MAGAM_TIME")
	public String getMagamTime() {
		return this.magamTime;
	}

	public void setMagamTime(String magamTime) {
		this.magamTime = magamTime;
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