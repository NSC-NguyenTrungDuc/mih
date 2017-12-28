package nta.med.data.model.ihis.system;

public class GetDefaultOrdDanuiInfo {
	private String ordDanui ;
	private String codeName ;
	public GetDefaultOrdDanuiInfo(String ordDanui, String codeName) {
		super();
		this.ordDanui = ordDanui;
		this.codeName = codeName;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	

}
