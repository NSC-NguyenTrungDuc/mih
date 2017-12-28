package nta.med.data.model.ihis.ocsa;

public class OCS0103U17LayHangwiGubunInfo {
	private String slipGubun;
	private String slipGubunName;
	private String slipCode;
	private String slipName;
	private String codeYn;
	private Double zeroValue;

	public OCS0103U17LayHangwiGubunInfo(String slipGubun, String slipGubunName,
			String slipCode, String slipName, String codeYn, Double zeroValue) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.codeYn = codeYn;
		this.zeroValue = zeroValue;
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

	public String getCodeYn() {
		return codeYn;
	}

	public void setCodeYn(String codeYn) {
		this.codeYn = codeYn;
	}

	public Double getZeroValue() {
		return zeroValue;
	}

	public void setZeroValue(Double zeroValue) {
		this.zeroValue = zeroValue;
	}

}
