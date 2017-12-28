package nta.med.data.model.ihis.ocsa;

public class OCS0311Q00LayDownListInfo {
	private String setPart          ;
	private String hangmogCode      ;
	private String setCode          ;
	private String hangmogCodeSet  ;
	private String hangmogName      ;
	private Double suryang           ;
	private String danui             ;
	private String danuiName        ;
	private String bulyongYn        ;
	private String slipName         ;
	private String inputControl     ;
	private String bunCode          ;
	public OCS0311Q00LayDownListInfo(String setPart, String hangmogCode,
			String setCode, String hangmogCodeSet, String hangmogName,
			Double suryang, String danui, String danuiName, String bulyongYn,
			String slipName, String inputControl, String bunCode) {
		super();
		this.setPart = setPart;
		this.hangmogCode = hangmogCode;
		this.setCode = setCode;
		this.hangmogCodeSet = hangmogCodeSet;
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.danui = danui;
		this.danuiName = danuiName;
		this.bulyongYn = bulyongYn;
		this.slipName = slipName;
		this.inputControl = inputControl;
		this.bunCode = bunCode;
	}
	public String getSetPart() {
		return setPart;
	}
	public void setSetPart(String setPart) {
		this.setPart = setPart;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getSetCode() {
		return setCode;
	}
	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}
	public String getHangmogCodeSet() {
		return hangmogCodeSet;
	}
	public void setHangmogCodeSet(String hangmogCodeSet) {
		this.hangmogCodeSet = hangmogCodeSet;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public String getDanuiName() {
		return danuiName;
	}
	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}
	public String getBulyongYn() {
		return bulyongYn;
	}
	public void setBulyongYn(String bulyongYn) {
		this.bulyongYn = bulyongYn;
	}
	public String getSlipName() {
		return slipName;
	}
	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}
	public String getInputControl() {
		return inputControl;
	}
	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}
	public String getBunCode() {
		return bunCode;
	}
	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}
	
}
