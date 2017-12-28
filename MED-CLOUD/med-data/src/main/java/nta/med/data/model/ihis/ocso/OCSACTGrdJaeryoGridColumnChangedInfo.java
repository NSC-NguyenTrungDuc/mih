package nta.med.data.model.ihis.ocso;

public class OCSACTGrdJaeryoGridColumnChangedInfo {
	private String hangmogName;
	private String suryang;
	private String danui;
	private String danuiName;
	private String bunCode;
	private String inputControl;

	public OCSACTGrdJaeryoGridColumnChangedInfo(String hangmogName,
			String suryang, String danui, String danuiName, String bunCode,
			String inputControl) {
		super();
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.danui = danui;
		this.danuiName = danuiName;
		this.bunCode = bunCode;
		this.inputControl = inputControl;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getSuryang() {
		return suryang;
	}

	public void setSuryang(String suryang) {
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

	public String getBunCode() {
		return bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}

	public String getInputControl() {
		return inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}

}