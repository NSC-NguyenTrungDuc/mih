package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0002 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0002.findAll", query="SELECT b FROM Bas0002 b")
public class Bas0002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double dpcRate;
	private String dpcRateGubun;
	private double dpcRate1;
	private Date endDate;
	private String hospCode;
	private String remark;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Bas0002() {
	}


	@Column(name="DPC_RATE")
	public double getDpcRate() {
		return this.dpcRate;
	}

	public void setDpcRate(double dpcRate) {
		this.dpcRate = dpcRate;
	}


	@Column(name="DPC_RATE_GUBUN")
	public String getDpcRateGubun() {
		return this.dpcRateGubun;
	}

	public void setDpcRateGubun(String dpcRateGubun) {
		this.dpcRateGubun = dpcRateGubun;
	}


	@Column(name="DPC_RATE1")
	public double getDpcRate1() {
		return this.dpcRate1;
	}

	public void setDpcRate1(double dpcRate1) {
		this.dpcRate1 = dpcRate1;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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