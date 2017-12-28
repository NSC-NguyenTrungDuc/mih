package nta.med.data.model.ihis.nuri;

public class NuriNUR1017U00ManageInfectionInfo {
    private String infeCode;
    private String bunho;
    private String startDate;
    private String endDate;
    private String infeFaeryo; 
    private String endSayu;
    private String inputText;
    private String y;
    private String pknur1017;
    
	public NuriNUR1017U00ManageInfectionInfo(String infeCode, String bunho,
			String startDate, String endDate, String infeFaeryo,
			String endSayu, String inputText, String y, String pknur1017) {
		super();
		this.infeCode = infeCode;
		this.bunho = bunho;
		this.startDate = startDate;
		this.endDate = endDate;
		this.infeFaeryo = infeFaeryo;
		this.endSayu = endSayu;
		this.inputText = inputText;
		this.y = y;
		this.pknur1017 = pknur1017;
	}
	
	public String getInfeCode() {
		return infeCode;
	}
	public void setInfeCode(String infeCode) {
		this.infeCode = infeCode;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
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
	public String getInfeFaeryo() {
		return infeFaeryo;
	}
	public void setInfeFaeryo(String infeFaeryo) {
		this.infeFaeryo = infeFaeryo;
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
	public String getY() {
		return y;
	}
	public void setY(String y) {
		this.y = y;
	}
	public String getPknur1017() {
		return pknur1017;
	}
	public void setPknur1017(String pknur1017) {
		this.pknur1017 = pknur1017;
	}
	
}
