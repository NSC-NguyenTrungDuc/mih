package nta.med.data.model.ihis.xrts;

public class XRT1002U00GrdPaStatusInfo {
	private String bunho;
	private String patStatus;
	private String patStatusName;
	private String patStatusCode;
	private String patStatusCodeName;
	private String ment;
	private Double seq;
	private String indispensableYn;
	private String contKey;
	public XRT1002U00GrdPaStatusInfo(String bunho, String patStatus,
			String patStatusName, String patStatusCode,
			String patStatusCodeName, String ment, Double seq,
			String indispensableYn, String contKey) {
		super();
		this.bunho = bunho;
		this.patStatus = patStatus;
		this.patStatusName = patStatusName;
		this.patStatusCode = patStatusCode;
		this.patStatusCodeName = patStatusCodeName;
		this.ment = ment;
		this.seq = seq;
		this.indispensableYn = indispensableYn;
		this.contKey = contKey;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
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
	public String getPatStatusCode() {
		return patStatusCode;
	}
	public void setPatStatusCode(String patStatusCode) {
		this.patStatusCode = patStatusCode;
	}
	public String getPatStatusCodeName() {
		return patStatusCodeName;
	}
	public void setPatStatusCodeName(String patStatusCodeName) {
		this.patStatusCodeName = patStatusCodeName;
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
	public String getIndispensableYn() {
		return indispensableYn;
	}
	public void setIndispensableYn(String indispensableYn) {
		this.indispensableYn = indispensableYn;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
	
}
