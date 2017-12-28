package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdNUR1017Info {
	private String startDate;
	private String infeJaeryo;
	private String infeCode;
	private String dataRowState;
	
	public NUR1001U00GrdNUR1017Info(String startDate, String infeJaeryo, String infeCode, String dataRowState) {
		super();
		this.startDate = startDate;
		this.infeJaeryo = infeJaeryo;
		this.infeCode = infeCode;
		this.dataRowState = dataRowState;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getInfeJaeryo() {
		return infeJaeryo;
	}

	public void setInfeJaeryo(String infeJaeryo) {
		this.infeJaeryo = infeJaeryo;
	}

	public String getInfeCode() {
		return infeCode;
	}

	public void setInfeCode(String infeCode) {
		this.infeCode = infeCode;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
