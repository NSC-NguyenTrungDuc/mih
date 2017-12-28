package nta.med.data.model.ihis.endo;

public class END1001U02DsvLDOCS0801Info {
	private String patStatus            ;
	private String patStatusName       ;
	private String patStatusCode       ;
	private String patStatusCodeName  ;
	private String indispensableYn      ;
	public END1001U02DsvLDOCS0801Info(String patStatus, String patStatusName,
			String patStatusCode, String patStatusCodeName,
			String indispensableYn) {
		super();
		this.patStatus = patStatus;
		this.patStatusName = patStatusName;
		this.patStatusCode = patStatusCode;
		this.patStatusCodeName = patStatusCodeName;
		this.indispensableYn = indispensableYn;
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
	public String getIndispensableYn() {
		return indispensableYn;
	}
	public void setIndispensableYn(String indispensableYn) {
		this.indispensableYn = indispensableYn;
	}
	
}
