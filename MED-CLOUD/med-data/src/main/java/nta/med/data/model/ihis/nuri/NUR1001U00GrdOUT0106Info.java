package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdOUT0106Info {
	private String comments;
	private String ser;
	private String displayYn;
	private String dataRowState;
	
	public NUR1001U00GrdOUT0106Info(String comments, String ser, String displayYn, String dataRowState) {
		super();
		this.comments = comments;
		this.ser = ser;
		this.displayYn = displayYn;
		this.dataRowState = dataRowState;
	}

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public String getSer() {
		return ser;
	}

	public void setSer(String ser) {
		this.ser = ser;
	}

	public String getDisplayYn() {
		return displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
