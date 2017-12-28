package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG2020 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg2020.findAll", query="SELECT d FROM Drg2020 d")
public class Drg2020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double cnt;
	private double drgBunho;
	private String hospCode;
	private Date jubsuDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg2020() {
	}


	public double getCnt() {
		return this.cnt;
	}

	public void setCnt(double cnt) {
		this.cnt = cnt;
	}


	@Column(name="DRG_BUNHO")
	public double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
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