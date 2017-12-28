package nta.med.data.model.ihis.ocsa;

public class OCS0311Q00LayDownListQueryEndResInfo {
	private String hangmogName   ;
	private String ordDanui      ;
	private String ordDanuiName ;
	private String slipName      ;
	private String bulyongYn     ;
	public OCS0311Q00LayDownListQueryEndResInfo(String hangmogName,
			String ordDanui, String ordDanuiName, String slipName,
			String bulyongYn) {
		super();
		this.hangmogName = hangmogName;
		this.ordDanui = ordDanui;
		this.ordDanuiName = ordDanuiName;
		this.slipName = slipName;
		this.bulyongYn = bulyongYn;
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
	public String getOrdDanuiName() {
		return ordDanuiName;
	}
	public void setOrdDanuiName(String ordDanuiName) {
		this.ordDanuiName = ordDanuiName;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}
	public String getBulyongYn() {
		return bulyongYn;
	}
	public void setBulyongYn(String bulyongYn) {
		this.bulyongYn = bulyongYn;
	}
	

}
