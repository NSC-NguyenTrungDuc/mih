package nta.med.data.model.ihis.ocsa;

public class OCS0801U00GrdOCS0801ListItemInfo {
	private String patStatus;
	private String patStatusName;
	private String ment;
	private Double seq;
	private String rowSate;

	public OCS0801U00GrdOCS0801ListItemInfo(String patStatus,
			String patStatusName, String ment, Double seq, String rowSate) {
		super();
		this.patStatus = patStatus;
		this.patStatusName = patStatusName;
		this.ment = ment;
		this.seq = seq;
		this.rowSate = rowSate;
	}

	public String getPatStatus() {
		return patStatus;
	}

	public void setPatStatus(String patStatus) {
		this.patStatus = patStatus;
	}

	public String getPatStatusName() {
		return patStatusName;
	}

	public void setPatStatusName(String patStatusName) {
		this.patStatusName = patStatusName;
	}

	public String getMent() {
		return ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getRowSate() {
		return rowSate;
	}

	public void setRowSate(String rowSate) {
		this.rowSate = rowSate;
	}

}
