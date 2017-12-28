package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NuriManageAllergyListItemInfo {
	private Double pknur1016;
    private String bunho;
    private String allergyGubun;
    private String allergyInfo;
    private Date startDate;
    private Date endDate;
    private String endSayu;
    private String inputText;
	public NuriManageAllergyListItemInfo(Double pknur1016, String bunho,
			String allergyGubun, String allergyInfo, Date startDate,
			Date endDate, String endSayu, String inputText) {
		super();
		this.pknur1016 = pknur1016;
		this.bunho = bunho;
		this.allergyGubun = allergyGubun;
		this.allergyInfo = allergyInfo;
		this.startDate = startDate;
		this.endDate = endDate;
		this.endSayu = endSayu;
		this.inputText = inputText;
	}
	public Double getPknur1016() {
		return pknur1016;
	}
	public void setPknur1016(Double pknur1016) {
		this.pknur1016 = pknur1016;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getAllergyGubun() {
		return allergyGubun;
	}
	public void setAllergyGubun(String allergyGubun) {
		this.allergyGubun = allergyGubun;
	}
	public String getAllergyInfo() {
		return allergyInfo;
	}
	public void setAllergyInfo(String allergyInfo) {
		this.allergyInfo = allergyInfo;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getEndSayu() {
		return endSayu;
	}
	public void setEndSayu(String endSayu) {
		this.endSayu = endSayu;
	}
	public String getInputText() {
		return inputText;
	}
	public void setInputText(String inputText) {
		this.inputText = inputText;
	}
}