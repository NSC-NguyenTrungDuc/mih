package nta.med.data.model.ihis.nuro;

public class OUT1001P03GrdOrderInfo {
	private Double pkocskey;
	private String orderGubun;
	private String orderGubunName;
	private String hangmogCode;
	private String hangmogName;
	private Double suryang;
	private String ordDanui;
	private Double nalsu;
	public OUT1001P03GrdOrderInfo(Double pkocskey, String orderGubun,
			String orderGubunName, String hangmogCode, String hangmogName,
			Double suryang, String ordDanui, Double nalsu) {
		super();
		this.pkocskey = pkocskey;
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.nalsu = nalsu;
	}
	public Double getPkocskey() {
		return pkocskey;
	}
	public void setPkocskey(Double pkocskey) {
		this.pkocskey = pkocskey;
	}
	public String getOrderGubun() {
		return orderGubun;
	}
	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}
	public String getOrderGubunName() {
		return orderGubunName;
	}
	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public Double getNalsu() {
		return nalsu;
	}
	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}
}
