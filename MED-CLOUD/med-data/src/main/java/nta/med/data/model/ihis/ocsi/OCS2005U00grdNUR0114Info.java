package nta.med.data.model.ihis.ocsi;

public class OCS2005U00grdNUR0114Info {
    private String nurSoCode;
    private String nurSoName;
	public OCS2005U00grdNUR0114Info(String nurSoCode, String nurSoName) {
		super();
		this.nurSoCode = nurSoCode;
		this.nurSoName = nurSoName;
	}
	public String getNurSoCode() {
		return nurSoCode;
	}
	public void setNurSoCode(String nurSoCode) {
		this.nurSoCode = nurSoCode;
	}
	public String getNurSoName() {
		return nurSoName;
	}
	public void setNurSoName(String nurSoName) {
		this.nurSoName = nurSoName;
	}
    
}
