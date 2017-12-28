package nta.med.data.model.ihis.ocsi;

public class OCS6010U10PopupTAgrdNUR0114Info {
	private String chk ;
    private String nurActCode ;
    private String nurActName ;
	public OCS6010U10PopupTAgrdNUR0114Info(String chk, String nurActCode, String nurActName) {
		super();
		this.chk = chk;
		this.nurActCode = nurActCode;
		this.nurActName = nurActName;
	}
	public String getChk() {
		return chk;
	}
	public void setChk(String chk) {
		this.chk = chk;
	}
	public String getNurActCode() {
		return nurActCode;
	}
	public void setNurActCode(String nurActCode) {
		this.nurActCode = nurActCode;
	}
	public String getNurActName() {
		return nurActName;
	}
	public void setNurActName(String nurActName) {
		this.nurActName = nurActName;
	}
    
}
