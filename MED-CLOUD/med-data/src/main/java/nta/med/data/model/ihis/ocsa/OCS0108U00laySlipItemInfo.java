package nta.med.data.model.ihis.ocsa;

public class OCS0108U00laySlipItemInfo {
	private String slipGubun;
	private String slipGubunName;
	private String slipCode;
	private String slipName;
	public OCS0108U00laySlipItemInfo(String slipGubun, String slipGubunName,
			String slipCode, String slipName) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
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
	
	

}
