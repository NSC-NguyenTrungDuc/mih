package nta.med.data.model.ihis.ocsa;

public class OCS0103U13LaySpecimenTreeListInfo {
	private String slipGubun ;
	private String slipGubunName ;
	private String slipCode ;
	private String slipName ;
	private String cplCodeYn;
	private Double zero ;
	public OCS0103U13LaySpecimenTreeListInfo(String slipGubun,
			String slipGubunName, String slipCode, String slipName,
			String cplCodeYn, Double zero) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.cplCodeYn = cplCodeYn;
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
	public String getCplCodeYn() {
		return cplCodeYn;
	}
	public void setCplCodeYn(String cplCodeYn) {
		this.cplCodeYn = cplCodeYn;
	}
	public Double getZero() {
		return zero;
	}
	public void setZero(Double zero) {
		this.zero = zero;
	}
	
}
