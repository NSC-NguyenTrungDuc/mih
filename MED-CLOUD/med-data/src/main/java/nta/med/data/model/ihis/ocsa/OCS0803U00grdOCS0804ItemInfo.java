package nta.med.data.model.ihis.ocsa;

public class OCS0803U00grdOCS0804ItemInfo {
	private String patStatusGr  ;      
	private String patStatus   ;        
	private String patStatusName   ;    
	private String indispensableYn    ; 
	private String breakPatStatusCode ;
	private String patStatusCodeName ;
	private String ment ;              
	private Double seq ;
	public OCS0803U00grdOCS0804ItemInfo(String patStatusGr, String patStatus,
			String patStatusName, String indispensableYn,
			String breakPatStatusCode, String patStatusCodeName, String ment,
			Double seq) {
		super();
		this.patStatusGr = patStatusGr;
		this.patStatus = patStatus;
		this.patStatusName = patStatusName;
		this.indispensableYn = indispensableYn;
		this.breakPatStatusCode = breakPatStatusCode;
		this.patStatusCodeName = patStatusCodeName;
		this.ment = ment;
		this.seq = seq;
	}
	public String getPatStatusGr() {
		return patStatusGr;
	}
	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
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
	public String getIndispensableYn() {
		return indispensableYn;
	}
	public void setIndispensableYn(String indispensableYn) {
		this.indispensableYn = indispensableYn;
	}
	public String getBreakPatStatusCode() {
		return breakPatStatusCode;
	}
	public void setBreakPatStatusCode(String breakPatStatusCode) {
		this.breakPatStatusCode = breakPatStatusCode;
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
	

}
