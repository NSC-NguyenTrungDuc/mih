package nta.med.data.model.ihis.drgs;

public class DrgsDRG0130U00GrdDrg0130ListItemInfo {
	private String cautionCode;
	private String cautionName;
	private String cautionName2;
	private String jobType;

	public DrgsDRG0130U00GrdDrg0130ListItemInfo(String cautionCode,
			String cautionName, String cautionName2, String jobType) {
		this.cautionCode = cautionCode;
		this.cautionName = cautionName;
		this.cautionName2 = cautionName2;
		this.jobType = jobType;
	}

	public String getCautionCode() {
		return cautionCode;
	}

	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}

	public String getCautionName() {
		return cautionName;
	}

	public void setCautionName(String cautionName) {
		this.cautionName = cautionName;
	}

	public String getCautionName2() {
		return cautionName2;
	}

	public void setCautionName2(String cautionName2) {
		this.cautionName2 = cautionName2;
	}

	public String getJobType() {
		return jobType;
	}

	public void setJobType(String jobType) {
		this.jobType = jobType;
	}

}
