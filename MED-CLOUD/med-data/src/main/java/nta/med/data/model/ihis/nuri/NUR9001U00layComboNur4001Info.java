package nta.med.data.model.ihis.nuri;

public class NUR9001U00layComboNur4001Info {
	private Double pknur4001;
	private String nurPlanJinName;
	private String sortKey;
	
	public NUR9001U00layComboNur4001Info(Double pknur4001, String nurPlanJinName, String sortKey) {
		super();
		this.pknur4001 = pknur4001;
		this.nurPlanJinName = nurPlanJinName;
		this.sortKey = sortKey;
	}

	public Double getPknur4001() {
		return pknur4001;
	}

	public void setPknur4001(Double pknur4001) {
		this.pknur4001 = pknur4001;
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
