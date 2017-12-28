package nta.med.data.model.ihis.cpls;

public class CPL0001U00GrdSlipInfo {
	private String slipCode;
	private String slipName;
	private String slipNameRe;
	private String jundalGubun;

	public CPL0001U00GrdSlipInfo(String slipCode, String slipName,
			String slipNameRe, String jundalGubun) {
		super();
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.slipNameRe = slipNameRe;
		this.jundalGubun = jundalGubun;
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

	public String getSlipNameRe() {
		return slipNameRe;
	}

	public void setSlipNameRe(String slipNameRe) {
		this.slipNameRe = slipNameRe;
	}

	public String getJundalGubun() {
		return jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}

}
