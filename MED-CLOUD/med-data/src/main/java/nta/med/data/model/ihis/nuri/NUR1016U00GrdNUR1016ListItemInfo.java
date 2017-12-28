package nta.med.data.model.ihis.nuri;




public class NUR1016U00GrdNUR1016ListItemInfo {
	private Double pknur1016;
	private String bunho;
	private String allergyGubun;
	private String allergyInfo;
	private String startDate;
	private String endDate;
	private String endSayu;
	private String inputText;
	private String yValue;
	private String rowState;
	public NUR1016U00GrdNUR1016ListItemInfo(Double pknur1016, String bunho,
			String allergyGubun, String allergyInfo, String startDate,
			String endDate, String endSayu, String inputText, String yValue,
			String rowState) {
		super();
		this.pknur1016 = pknur1016;
		this.bunho = bunho;
		this.allergyGubun = allergyGubun;
		this.allergyInfo = allergyInfo;
		this.startDate = startDate;
		this.endDate = endDate;
		this.endSayu = endSayu;
		this.inputText = inputText;
		this.yValue = yValue;
		this.rowState = rowState;
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
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
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
	public String getyValue() {
		return yValue;
	}
	public void setyValue(String yValue) {
		this.yValue = yValue;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

	
}
