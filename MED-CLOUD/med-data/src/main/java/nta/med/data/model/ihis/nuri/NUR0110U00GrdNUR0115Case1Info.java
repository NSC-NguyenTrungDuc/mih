package nta.med.data.model.ihis.nuri;

public class NUR0110U00GrdNUR0115Case1Info {

	private String hangmogName;
	private String slipCode;

	public NUR0110U00GrdNUR0115Case1Info(String hangmogName, String slipCode) {
		super();
		this.hangmogName = hangmogName;
		this.slipCode = slipCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

}
