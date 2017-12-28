package nta.med.data.model.ihis.nuri;

public class NUR0401U01GrdNur0102Info {

	private String nurPlanBunryu;
	private String nurPlanBunryuName;
	private Double sortKey;

	public NUR0401U01GrdNur0102Info(String nurPlanBunryu, String nurPlanBunryuName, Double sortKey) {
		super();
		this.nurPlanBunryu = nurPlanBunryu;
		this.nurPlanBunryuName = nurPlanBunryuName;
		this.sortKey = sortKey;
	}

	public String getNurPlanBunryu() {
		return nurPlanBunryu;
	}

	public void setNurPlanBunryu(String nurPlanBunryu) {
		this.nurPlanBunryu = nurPlanBunryu;
	}

	public String getNurPlanBunryuName() {
		return nurPlanBunryuName;
	}

	public void setNurPlanBunryuName(String nurPlanBunryuName) {
		this.nurPlanBunryuName = nurPlanBunryuName;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

}
