package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR4004 database table.
 * 
 */
@Entity
@Table(name = "NUR4004")
public class Nur4004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double fknur4003;
	private String hospCode;
	private Date inputDate;
	private Double nurPlan;
	private String nurPlanDename;
	private String nurPlanDetail;
	private Double pknur4004;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur4004() {
	}


	public Double getFknur4003() {
		return this.fknur4003;
	}

	public void setFknur4003(Double fknur4003) {
		this.fknur4003 = fknur4003;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INPUT_DATE")
	public Date getInputDate() {
		return this.inputDate;
	}

	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}


	@Column(name="NUR_PLAN")
	public Double getNurPlan() {
		return this.nurPlan;
	}

	public void setNurPlan(Double nurPlan) {
		this.nurPlan = nurPlan;
	}


	@Column(name="NUR_PLAN_DENAME")
	public String getNurPlanDename() {
		return this.nurPlanDename;
	}

	public void setNurPlanDename(String nurPlanDename) {
		this.nurPlanDename = nurPlanDename;
	}


	@Column(name="NUR_PLAN_DETAIL")
	public String getNurPlanDetail() {
		return this.nurPlanDetail;
	}

	public void setNurPlanDetail(String nurPlanDetail) {
		this.nurPlanDetail = nurPlanDetail;
	}


	public Double getPknur4004() {
		return this.pknur4004;
	}

	public void setPknur4004(Double pknur4004) {
		this.pknur4004 = pknur4004;
	}


	@Column(name="SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
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