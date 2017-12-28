package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0404 database table.
 * 
 */
@Entity
@Table(name = "NUR0404")
public class Nur0404 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private Date fromDate;
	private String hospCode;
	private Double nurPlan;
	private String nurPlanDename;
	private String nurPlanDetail;
	private String nurPlanJin;
	private String nurPlanPro;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur0404() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NUR_PLAN")
	public Double getNurPlan() {
		return this.nurPlan;
	}

	public void setNurPlan(Double nurPlan) {
		this.nurPlan = nurPlan;
	}

	@Column(name = "NUR_PLAN_DENAME")
	public String getNurPlanDename() {
		return this.nurPlanDename;
	}

	public void setNurPlanDename(String nurPlanDename) {
		this.nurPlanDename = nurPlanDename;
	}

	@Column(name = "NUR_PLAN_DETAIL")
	public String getNurPlanDetail() {
		return this.nurPlanDetail;
	}

	public void setNurPlanDetail(String nurPlanDetail) {
		this.nurPlanDetail = nurPlanDetail;
	}

	@Column(name = "NUR_PLAN_JIN")
	public String getNurPlanJin() {
		return this.nurPlanJin;
	}

	public void setNurPlanJin(String nurPlanJin) {
		this.nurPlanJin = nurPlanJin;
	}

	@Column(name = "NUR_PLAN_PRO")
	public String getNurPlanPro() {
		return this.nurPlanPro;
	}

	public void setNurPlanPro(String nurPlanPro) {
		this.nurPlanPro = nurPlanPro;
	}

	@Column(name = "SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
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