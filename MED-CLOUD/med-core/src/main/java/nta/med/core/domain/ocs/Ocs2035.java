package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2035 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2035.findAll", query="SELECT o FROM Ocs2035 o")
public class Ocs2035 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actDate;
	private String actId;
	private double changeQty;
	private double dv;
	private Date endDate;
	private String endTime;
	private double fio2;
	private double fkocs2005;
	private String hospCode;
	private double pkocs2035;
	private String startTime;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2035() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_DATE")
	public Date getActDate() {
		return this.actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}


	@Column(name="ACT_ID")
	public String getActId() {
		return this.actId;
	}

	public void setActId(String actId) {
		this.actId = actId;
	}


	@Column(name="CHANGE_QTY")
	public double getChangeQty() {
		return this.changeQty;
	}

	public void setChangeQty(double changeQty) {
		this.changeQty = changeQty;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="END_TIME")
	public String getEndTime() {
		return this.endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}


	public double getFio2() {
		return this.fio2;
	}

	public void setFio2(double fio2) {
		this.fio2 = fio2;
	}


	public double getFkocs2005() {
		return this.fkocs2005;
	}

	public void setFkocs2005(double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPkocs2035() {
		return this.pkocs2035;
	}

	public void setPkocs2035(double pkocs2035) {
		this.pkocs2035 = pkocs2035;
	}


	@Column(name="START_TIME")
	public String getStartTime() {
		return this.startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
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