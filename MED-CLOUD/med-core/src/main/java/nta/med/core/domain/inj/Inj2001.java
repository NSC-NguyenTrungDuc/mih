package nta.med.core.domain.inj;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INJ2001 database table.
 * 
 */
@Entity
@NamedQuery(name="Inj2001.findAll", query="SELECT i FROM Inj2001 i")
public class Inj2001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actingJangso;
	private double cnt;
	private String gwa;
	private String hospCode;
	private Date magamDate;
	private double slipCnt;
	private Date sysDate;
	private String sysId;
	private String tonggyeCode;
	private Date updDate;
	private String updId;

	public Inj2001() {
	}


	@Column(name="ACTING_JANGSO")
	public String getActingJangso() {
		return this.actingJangso;
	}

	public void setActingJangso(String actingJangso) {
		this.actingJangso = actingJangso;
	}


	public double getCnt() {
		return this.cnt;
	}

	public void setCnt(double cnt) {
		this.cnt = cnt;
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
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	@Column(name="SLIP_CNT")
	public double getSlipCnt() {
		return this.slipCnt;
	}

	public void setSlipCnt(double slipCnt) {
		this.slipCnt = slipCnt;
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


	@Column(name="TONGGYE_CODE")
	public String getTonggyeCode() {
		return this.tonggyeCode;
	}

	public void setTonggyeCode(String tonggyeCode) {
		this.tonggyeCode = tonggyeCode;
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