package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5011 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5011.findAll", query="SELECT n FROM Nur5011 n")
public class Nur5011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private Date nurWrdt;
	private String nurseGrade;
	private String nurseId;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double workTime;
	private String workType;

	public Nur5011() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}


	@Column(name="NURSE_GRADE")
	public String getNurseGrade() {
		return this.nurseGrade;
	}

	public void setNurseGrade(String nurseGrade) {
		this.nurseGrade = nurseGrade;
	}


	@Column(name="NURSE_ID")
	public String getNurseId() {
		return this.nurseId;
	}

	public void setNurseId(String nurseId) {
		this.nurseId = nurseId;
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


	@Column(name="WORK_TIME")
	public double getWorkTime() {
		return this.workTime;
	}

	public void setWorkTime(double workTime) {
		this.workTime = workTime;
	}


	@Column(name="WORK_TYPE")
	public String getWorkType() {
		return this.workType;
	}

	public void setWorkType(String workType) {
		this.workType = workType;
	}

}