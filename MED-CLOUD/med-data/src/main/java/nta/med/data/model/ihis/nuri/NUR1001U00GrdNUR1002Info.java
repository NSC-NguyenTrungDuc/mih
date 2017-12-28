package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdNUR1002Info {
	private Double fkinp1001;
	private String bunho;
	private String insertDate;
	private String ser;
	private String drugComment;
	private String dataRowState;
	
	public NUR1001U00GrdNUR1002Info(Double fkinp1001, String bunho, String insertDate, String ser, String drugComment,
			String dataRowState) {
		super();
		this.fkinp1001 = fkinp1001;
		this.bunho = bunho;
		this.insertDate = insertDate;
		this.ser = ser;
		this.drugComment = drugComment;
		this.dataRowState = dataRowState;
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

	public String getInsertDate() {
		return insertDate;
	}

	public void setInsertDate(String insertDate) {
		this.insertDate = insertDate;
	}

	public String getSer() {
		return ser;
	}

	public void setSer(String ser) {
		this.ser = ser;
	}

	public String getDrugComment() {
		return drugComment;
	}

	public void setDrugComment(String drugComment) {
		this.drugComment = drugComment;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
