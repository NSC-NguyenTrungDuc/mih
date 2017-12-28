package nta.med.data.model.ihis.nuri;

public class NUR4001U00GrdNUR4001Info {
	private Double pknur4001;
	private Double fkinp1001;
	private String bunho;
	private String nurPlanJin;
	private String nurPlanJinName;
	private String planDate;
	private String endDate;
	private String reserDate;
	private String planUser;
	private String planUserName;
	private String sortKey;
	private String purpose;
	
	public NUR4001U00GrdNUR4001Info(Double pknur4001, Double fkinp1001, String bunho, String nurPlanJin,
			String nurPlanJinName, String planDate, String endDate, String reserDate, String planUser,
			String planUserName, String sortKey, String purpose) {
		super();
		this.pknur4001 = pknur4001;
		this.fkinp1001 = fkinp1001;
		this.bunho = bunho;
		this.nurPlanJin = nurPlanJin;
		this.nurPlanJinName = nurPlanJinName;
		this.planDate = planDate;
		this.endDate = endDate;
		this.reserDate = reserDate;
		this.planUser = planUser;
		this.planUserName = planUserName;
		this.sortKey = sortKey;
		this.purpose = purpose;
	}

	public Double getPknur4001() {
		return pknur4001;
	}

	public void setPknur4001(Double pknur4001) {
		this.pknur4001 = pknur4001;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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

	public String getPlanDate() {
		return planDate;
	}

	public void setPlanDate(String planDate) {
		this.planDate = planDate;
	}

	public String getEndDate() {
		return endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}

	public String getPlanUser() {
		return planUser;
	}

	public void setPlanUser(String planUser) {
		this.planUser = planUser;
	}

	public String getPlanUserName() {
		return planUserName;
	}

	public void setPlanUserName(String planUserName) {
		this.planUserName = planUserName;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

	public String getPurpose() {
		return purpose;
	}

	public void setPurpose(String purpose) {
		this.purpose = purpose;
	}
}
