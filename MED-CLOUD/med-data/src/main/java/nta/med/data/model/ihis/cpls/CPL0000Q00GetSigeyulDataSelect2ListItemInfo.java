package nta.med.data.model.ihis.cpls;

public class CPL0000Q00GetSigeyulDataSelect2ListItemInfo {
	private String cplResult;
    private String standardYn;
    private String gumsaName;
    private String fromStandard;
    private String toStandard;
	public CPL0000Q00GetSigeyulDataSelect2ListItemInfo(String cplResult,
			String standardYn, String gumsaName, String fromStandard,
			String toStandard) {
		super();
		this.cplResult = cplResult;
		this.standardYn = standardYn;
		this.gumsaName = gumsaName;
		this.fromStandard = fromStandard;
		this.toStandard = toStandard;
	}
	public String getCplResult() {
		return cplResult;
	}
	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}
	public String getStandardYn() {
		return standardYn;
	}
	public void setStandardYn(String standardYn) {
		this.standardYn = standardYn;
	}
	public String getGumsaName() {
		return gumsaName;
	}
	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}
	public String getFromStandard() {
		return fromStandard;
	}
	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}
	public String getToStandard() {
		return toStandard;
	}
	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
	}
}
