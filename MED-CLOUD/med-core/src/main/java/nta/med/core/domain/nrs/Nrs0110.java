package nta.med.core.domain.nrs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NRS0110 database table.
 * 
 */
@Entity
@NamedQuery(name="Nrs0110.findAll", query="SELECT n FROM Nrs0110 n")
public class Nrs0110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buseoCode;
	private String dutyGroup;
	private Date endDate;
	private Date fromDate;
	private String hospCode;
	private String nurseGrade;
	private String sabun;
	private String sabunName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nrs0110() {
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="DUTY_GROUP")
	public String getDutyGroup() {
		return this.dutyGroup;
	}

	public void setDutyGroup(String dutyGroup) {
		this.dutyGroup = dutyGroup;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NURSE_GRADE")
	public String getNurseGrade() {
		return this.nurseGrade;
	}

	public void setNurseGrade(String nurseGrade) {
		this.nurseGrade = nurseGrade;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
	}


	@Column(name="SABUN_NAME")
	public String getSabunName() {
		return this.sabunName;
	}

	public void setSabunName(String sabunName) {
		this.sabunName = sabunName;
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