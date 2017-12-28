package nta.med.data.model.ihis.ocso;

public class OCS0801U00GrdOCS0802ListItemInfo {
	private String patStatus;
	private String patStatusCode;
	private String patStatusName;
	private String ment;
	private Double seq;
	private String contKey;
	public OCS0801U00GrdOCS0802ListItemInfo(String patStatus,
			String patStatusCode, String patStatusName, String ment,
			Double seq, String contKey) {
		super();
		this.patStatus = patStatus;
		this.patStatusCode = patStatusCode;
		this.patStatusName = patStatusName;
		this.ment = ment;
		this.seq = seq;
		this.contKey = contKey;
	}
	public String getPatStatus() {
		return patStatus;
	}
	public void setPatStatus(String patStatus) {
		this.patStatus = patStatus;
	}
	public String getPatStatusCode() {
		return patStatusCode;
	}
	public void setPatStatusCode(String patStatusCode) {
		this.patStatusCode = patStatusCode;
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
	public String getcontKey() {
		return contKey;
	}
	public void setcontKey(String contKey) {
		this.contKey = contKey;
	}


}