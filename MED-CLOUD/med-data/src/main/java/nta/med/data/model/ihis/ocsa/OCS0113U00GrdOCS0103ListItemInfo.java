package nta.med.data.model.ihis.ocsa;

public class OCS0113U00GrdOCS0103ListItemInfo {
	private String slipCode;
	private String hangmongCode;
	private String hangmogName;

	public OCS0113U00GrdOCS0103ListItemInfo(String slipCode,
			String hangmongCode, String hangmogName) {
		super();
		this.slipCode = slipCode;
		this.hangmongCode = hangmongCode;
		this.hangmogName = hangmogName;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	public String getHangmongCode() {
		return hangmongCode;
	}

	public void setHangmongCode(String hangmongCode) {
		this.hangmongCode = hangmongCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

}
