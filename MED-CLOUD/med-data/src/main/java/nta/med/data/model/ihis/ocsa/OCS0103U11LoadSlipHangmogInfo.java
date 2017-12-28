package nta.med.data.model.ihis.ocsa;

public class OCS0103U11LoadSlipHangmogInfo {
	private String hangmogCode;
	private String hangmogName;
	private String orderGubun;
	private String orderGubunName;
	private String specificComment;
	private String trialFlag;
	public OCS0103U11LoadSlipHangmogInfo(String hangmogCode,
			String hangmogName, String orderGubun, String orderGubunName,
			String specificComment, String trialFlag) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.specificComment = specificComment;
		this.trialFlag = trialFlag;
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

	public String getSpecificComment() {
		return specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}

	public String getTrialFlag() {
		return trialFlag;
	}

	public void setTrialFlag(String trialFlag) {
		this.trialFlag = trialFlag;
	}
}
