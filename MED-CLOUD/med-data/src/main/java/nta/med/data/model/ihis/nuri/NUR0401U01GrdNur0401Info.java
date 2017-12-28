package nta.med.data.model.ihis.nuri;

public class NUR0401U01GrdNur0401Info {

	private String nurPlanJin;
	private String nurPlanJinName;
	private String nurPlanBunryu;
	private String vald;
	private Double sortKey;

	public NUR0401U01GrdNur0401Info(String nurPlanJin, String nurPlanJinName, String nurPlanBunryu, String vald,
			Double sortKey) {
		super();
		this.nurPlanJin = nurPlanJin;
		this.nurPlanJinName = nurPlanJinName;
		this.nurPlanBunryu = nurPlanBunryu;
		this.vald = vald;
		this.sortKey = sortKey;
	}

	public String getNurPlanJin() {
		return nurPlanJin;
	}

	public void setNurPlanJin(String nurPlanJin) {
		this.nurPlanJin = nurPlanJin;
	}

	public String getNurPlanJinName() {
		return nurPlanJinName;
	}

	public void setNurPlanJinName(String nurPlanJinName) {
		this.nurPlanJinName = nurPlanJinName;
	}

	public String getNurPlanBunryu() {
		return nurPlanBunryu;
	}

	public void setNurPlanBunryu(String nurPlanBunryu) {
		this.nurPlanBunryu = nurPlanBunryu;
	}

	public String getVald() {
		return vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

}
