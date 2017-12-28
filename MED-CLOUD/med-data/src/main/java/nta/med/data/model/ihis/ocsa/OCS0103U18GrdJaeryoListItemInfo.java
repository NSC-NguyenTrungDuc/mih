package nta.med.data.model.ihis.ocsa;

public class OCS0103U18GrdJaeryoListItemInfo {
	private String slipCode;
	private String slipName;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private String wonnaeDrgYn;

	public OCS0103U18GrdJaeryoListItemInfo(String slipCode, String slipName,
			String hangmogCode, String hangmogName, String hospCode,
			String wonnaeDrgYn) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.hospCode = hospCode;
		this.wonnaeDrgYn = wonnaeDrgYn;
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

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getWonnaeDrgYn() {
		return wonnaeDrgYn;
	}

	public void setWonnaeDrgYn(String wonnaeDrgYn) {
		this.wonnaeDrgYn = wonnaeDrgYn;
	}

}
