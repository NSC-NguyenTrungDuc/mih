package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR4001 database table.
 * 
 */
@Entity
@Table(name = "NUR4001")
public class Nur4001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date endDate;
	private Date evalDate;
	private Double fkinp1001;
	private String hospCode;
	private String nurPlanJin;
	private String nurPlanJinName;
	private Double pknur4001;
	private Date planDate;
	private String planUser;
	private String purpose;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur4001() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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
	@Column(name = "EVAL_DATE")
	public Date getEvalDate() {
		return this.evalDate;
	}

	public void setEvalDate(Date evalDate) {
		this.evalDate = evalDate;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NUR_PLAN_JIN")
	public String getNurPlanJin() {
		return this.nurPlanJin;
	}

	public void setNurPlanJin(String nurPlanJin) {
		this.nurPlanJin = nurPlanJin;
	}

	@Column(name = "NUR_PLAN_JIN_NAME")
	public String getNurPlanJinName() {
		return this.nurPlanJinName;
	}

	public void setNurPlanJinName(String nurPlanJinName) {
		this.nurPlanJinName = nurPlanJinName;
	}

	public Double getPknur4001() {
		return this.pknur4001;
	}

	public void setPknur4001(Double pknur4001) {
		this.pknur4001 = pknur4001;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PLAN_DATE")
	public Date getPlanDate() {
		return this.planDate;
	}

	public void setPlanDate(Date planDate) {
		this.planDate = planDate;
	}

	@Column(name = "PLAN_USER")
	public String getPlanUser() {
		return this.planUser;
	}

	public void setPlanUser(String planUser) {
		this.planUser = planUser;
	}

	public String getPurpose() {
		return this.purpose;
	}

	public void setPurpose(String purpose) {
		this.purpose = purpose;
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