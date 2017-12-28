package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1017U00GrdNUR1017ListItemInfo {
	private String infeCode;
	private String bunho;
	private Date startDate;
	private Date endDate;
	private String infeJaeryo;
	private String endSayu;
	private String inputText;
	private String yValue;
	private Double pknur1017;
	private String rowState;

	public NUR1017U00GrdNUR1017ListItemInfo(String infeCode, String bunho,
			Date startDate, Date endDate, String infeJaeryo, String endSayu,
			String inputText, String yValue, Double pknur1017, String rowState) {
		super();
		this.infeCode = infeCode;
		this.bunho = bunho;
		this.startDate = startDate;
		this.endDate = endDate;
		this.infeJaeryo = infeJaeryo;
		this.endSayu = endSayu;
		this.inputText = inputText;
		this.yValue = yValue;
		this.pknur1017 = pknur1017;
		this.rowState = rowState;
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

	public String getInfeJaeryo() {
		return infeJaeryo;
	}

	public void setInfeJaeryo(String infeJaeryo) {
		this.infeJaeryo = infeJaeryo;
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

	public Double getPknur1017() {
		return pknur1017;
	}

	public void setPknur1017(Double pknur1017) {
		this.pknur1017 = pknur1017;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}
