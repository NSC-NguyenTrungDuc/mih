package nta.med.data.model.ihis.ocsa;

public class OCS0103U14LaySlipCodeTreeInfo {
	private String slipGubun       ;
	private String slipGubunName  ;
	private String slipCode        ;
	private String slipName        ;
	private String pfeCodeYn      ;
	private Double zero             ;
	public OCS0103U14LaySlipCodeTreeInfo(String slipGubun,
			String slipGubunName, String slipCode, String slipName,
			String pfeCodeYn, Double zero) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.pfeCodeYn = pfeCodeYn;
		this.zero = zero;
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
	public String getPfeCodeYn() {
		return pfeCodeYn;
	}
	public void setPfeCodeYn(String pfeCodeYn) {
		this.pfeCodeYn = pfeCodeYn;
	}
	public Double getZero() {
		return zero;
	}
	public void setZero(Double zero) {
		this.zero = zero;
	}
	

}
