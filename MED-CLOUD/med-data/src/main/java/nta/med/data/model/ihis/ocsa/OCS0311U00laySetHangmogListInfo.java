package nta.med.data.model.ihis.ocsa;

public class OCS0311U00laySetHangmogListInfo {
	private String hangmogName ;
	private String ordDanui ;
	private String codeName ;
	public OCS0311U00laySetHangmogListInfo(String hangmogName, String ordDanui,
			String codeName) {
		super();
		this.hangmogName = hangmogName;
		this.ordDanui = ordDanui;
		this.codeName = codeName;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
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
