package nta.med.data.model.ihis.ocsa;

public class OCS0103U11LaySlipCodeTreeListItemInfo {
	private String slipGubun ;
	private String slipGubunName ;
	private String slipCode ;
	private String slipName ;
	private String orderbykey ;
	public OCS0103U11LaySlipCodeTreeListItemInfo(String slipGubun,
			String slipGubunName, String slipCode, String slipName,
			String orderbykey) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.orderbykey = orderbykey;
	}
	public String getSlipGubun() {
		return slipGubun;
	}
	public void setSlipGubun(String slipGubun) {
		this.slipGubun = slipGubun;
	}
	public String getSlipGubunName() {
		return slipGubunName;
	}
	public void setSlipGubunName(String slipGubunName) {
		this.slipGubunName = slipGubunName;
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
	public String getOrderbykey() {
		return orderbykey;
	}
	public void setOrderbykey(String orderbykey) {
		this.orderbykey = orderbykey;
	}
	
}
