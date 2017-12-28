package nta.med.data.model.ihis.ocso;

public class OcsoOCS1003P01LayJinryoGwaInfo {
	private String gwa;
    private String gwaName;
	public OcsoOCS1003P01LayJinryoGwaInfo(String gwa, String gwaName) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
    
}
