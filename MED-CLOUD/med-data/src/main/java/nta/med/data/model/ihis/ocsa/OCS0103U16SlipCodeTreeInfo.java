package nta.med.data.model.ihis.ocsa;

public class OCS0103U16SlipCodeTreeInfo {
	private String slipCode       ;
	private String slipName       ;
	private String xrayBuwi       ;
	private String buwiName       ;
	private String xrayCodeYn    ;
	private String orderByKey      ;
	public OCS0103U16SlipCodeTreeInfo(String slipCode, String slipName,
			String xrayBuwi, String buwiName, String xrayCodeYn,
			String orderByKey) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.xrayBuwi = xrayBuwi;
		this.buwiName = buwiName;
		this.xrayCodeYn = xrayCodeYn;
		this.orderByKey = orderByKey;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}
	public String getXrayBuwi() {
		return xrayBuwi;
	}
	public void setXrayBuwi(String xrayBuwi) {
		this.xrayBuwi = xrayBuwi;
	}
	public String getBuwiName() {
		return buwiName;
	}
	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}
	public String getXrayCodeYn() {
		return xrayCodeYn;
	}
	public void setXrayCodeYn(String xrayCodeYn) {
		this.xrayCodeYn = xrayCodeYn;
	}
	public String getOrderByKey() {
		return orderByKey;
	}
	public void setOrderByKey(String orderByKey) {
		this.orderByKey = orderByKey;
	}
	

}
