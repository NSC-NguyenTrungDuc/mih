package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR0401U01GrdNur0404Info {

	private String nurPlanJin;
	private String nurPlanPro;
	private String nurPlan;
	private String nurPlanDetail;
	private Date fromDate;
	private Date endDate;
	private String nurPlanDename;
	private String sortKey;
	private String vald;

	public NUR0401U01GrdNur0404Info(String nurPlanJin, String nurPlanPro, String nurPlan, String nurPlanDetail,
			Date fromDate, Date endDate, String nurPlanDename, String sortKey, String vald) {
		super();
		this.nurPlanJin = nurPlanJin;
		this.nurPlanPro = nurPlanPro;
		this.nurPlan = nurPlan;
		this.nurPlanDetail = nurPlanDetail;
		this.fromDate = fromDate;
		this.endDate = endDate;
		this.nurPlanDename = nurPlanDename;
		this.sortKey = sortKey;
		this.vald = vald;
	}

	public String getNurPlanJin() {
		return nurPlanJin;
	}

	public void setNurPlanJin(String nurPlanJin) {
		this.nurPlanJin = nurPlanJin;
	}

	public String getNurPlanPro() {
		return nurPlanPro;
	}

	public void setNurPlanPro(String nurPlanPro) {
		this.nurPlanPro = nurPlanPro;
	}

	public String getNurPlan() {
		return nurPlan;
	}

	public void setNurPlan(String nurPlan) {
		this.nurPlan = nurPlan;
	}

	public String getNurPlanDetail() {
		return nurPlanDetail;
	}

	public void setNurPlanDetail(String nurPlanDetail) {
		this.nurPlanDetail = nurPlanDetail;
	}

	public Date getFromDate() {
		return fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getNurPlanDename() {
		return nurPlanDename;
	}

	public void setNurPlanDename(String nurPlanDename) {
		this.nurPlanDename = nurPlanDename;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

	public String getVald() {
		return vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}
