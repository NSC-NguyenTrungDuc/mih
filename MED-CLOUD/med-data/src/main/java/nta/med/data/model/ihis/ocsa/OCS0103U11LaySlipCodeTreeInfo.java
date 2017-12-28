package nta.med.data.model.ihis.ocsa;

public class OCS0103U11LaySlipCodeTreeInfo {
	private String slipGubun;
	private String slipGubunName;
	private String slipCode;
	private String slipName;
	private String orderByKey;

	public OCS0103U11LaySlipCodeTreeInfo(String slipGubun,
			String slipGubunName, String slipCode, String slipName,
			String orderByKey) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.orderByKey = orderByKey;
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

	public String getOrderByKey() {
		return orderByKey;
	}

	public void setOrderByKey(String orderByKey) {
		this.orderByKey = orderByKey;
	}

}
