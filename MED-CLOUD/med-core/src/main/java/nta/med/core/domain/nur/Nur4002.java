package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR4002 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur4002.findAll", query="SELECT n FROM Nur4002 n")
public class Nur4002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fknur4001;
	private String hospCode;
	private String nurPlanPro;
	private String nurPlanProName;
	private double pknur4002;
	private Date planDate;
	private String planUser;
	private double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur4002() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFknur4001() {
		return this.fknur4001;
	}

	public void setFknur4001(double fknur4001) {
		this.fknur4001 = fknur4001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUR_PLAN_PRO")
	public String getNurPlanPro() {
		return this.nurPlanPro;
	}

	public void setNurPlanPro(String nurPlanPro) {
		this.nurPlanPro = nurPlanPro;
	}


	@Column(name="NUR_PLAN_PRO_NAME")
	public String getNurPlanProName() {
		return this.nurPlanProName;
	}

	public void setNurPlanProName(String nurPlanProName) {
		this.nurPlanProName = nurPlanProName;
	}


	public double getPknur4002() {
		return this.pknur4002;
	}

	public void setPknur4002(double pknur4002) {
		this.pknur4002 = pknur4002;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PLAN_DATE")
	public Date getPlanDate() {
		return this.planDate;
	}

	public void setPlanDate(Date planDate) {
		this.planDate = planDate;
	}


	@Column(name="PLAN_USER")
	public String getPlanUser() {
		return this.planUser;
	}

	public void setPlanUser(String planUser) {
		this.planUser = planUser;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}