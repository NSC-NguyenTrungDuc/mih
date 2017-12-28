package nta.med.data.model.ihis.ocsa;

public class Ocs0103Q00LoadOcs0103ItemInfo {
	private String orderGubun;
	private String slipCode;
	private String slipName;
	private String hangmogName;
	private String sgCode;
	private String bulyongCheck;
	private String inputControl;
	private String bunCode;
	private Double seq;
	public Ocs0103Q00LoadOcs0103ItemInfo(String orderGubun, String slipCode,
			String slipName, String hangmogName, String sgCode,
			String bulyongCheck, String inputControl, String bunCode, Double seq) {
		super();
		this.orderGubun = orderGubun;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.hangmogName = hangmogName;
		this.sgCode = sgCode;
		this.bulyongCheck = bulyongCheck;
		this.inputControl = inputControl;
		this.bunCode = bunCode;
		this.seq = seq;
	}
	public String getOrderGubun() {
		return orderGubun;
	}
	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
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
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	public String getBulyongCheck() {
		return bulyongCheck;
	}
	public void setBulyongCheck(String bulyongCheck) {
		this.bulyongCheck = bulyongCheck;
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
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
}
