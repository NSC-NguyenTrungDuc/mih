package nta.med.data.model.ihis.nuri;

public class NUR4001U00FwkJinInfo {
	private String nurPlanJin;
	private String nurPlanJinName;
	private String sortKey;
	
	public NUR4001U00FwkJinInfo(String nurPlanJin, String nurPlanJinName, String sortKey) {
		super();
		this.nurPlanJin = nurPlanJin;
		this.nurPlanJinName = nurPlanJinName;
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

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}
	
}
