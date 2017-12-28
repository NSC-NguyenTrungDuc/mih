package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdNUR1029Info {
	private Double pknur1029;
	private String startDate;
	private String buwi;
	private String buwiComment;
	private String dataRowState;
	
	public NUR1001U00GrdNUR1029Info(Double pknur1029, String startDate, String buwi, String buwiComment,
			String dataRowState) {
		super();
		this.pknur1029 = pknur1029;
		this.startDate = startDate;
		this.buwi = buwi;
		this.buwiComment = buwiComment;
		this.dataRowState = dataRowState;
	}

	public Double getPknur1029() {
		return pknur1029;
	}

	public void setPknur1029(Double pknur1029) {
		this.pknur1029 = pknur1029;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getBuwi() {
		return buwi;
	}

	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}

	public String getBuwiComment() {
		return buwiComment;
	}

	public void setBuwiComment(String buwiComment) {
		this.buwiComment = buwiComment;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
