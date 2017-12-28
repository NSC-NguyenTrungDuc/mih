package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR0401U01GrdNur0403Info {

	private String nurPlanJin;
	private String nurPlanPro;
	private String nurPlan;
	private Date fromDate;
	private Date endDate;
	private String nurPlanName;
	private String nurPlanOte;
	private String sortKey;
	private String vald;

	public NUR0401U01GrdNur0403Info(String nurPlanJin, String nurPlanPro, String nurPlan, Date fromDate, Date endDate,
			String nurPlanName, String nurPlanOte, String sortKey, String vald) {
		super();
		this.nurPlanJin = nurPlanJin;
		this.nurPlanPro = nurPlanPro;
		this.nurPlan = nurPlan;
		this.fromDate = fromDate;
		this.endDate = endDate;
		this.nurPlanName = nurPlanName;
		this.nurPlanOte = nurPlanOte;
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

	public String getNurPlanName() {
		return nurPlanName;
	}

	public void setNurPlanName(String nurPlanName) {
		this.nurPlanName = nurPlanName;
	}

	public String getNurPlanOte() {
		return nurPlanOte;
	}

	public void setNurPlanOte(String nurPlanOte) {
		this.nurPlanOte = nurPlanOte;
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
