package nta.med.data.model.ihis.ocso;

public class OCSACTDefaultJearyoInfo {
	private String setHangmogCode ;
	private String suryang          ;
	private String danui            ;
	private String danuiName       ;
	public OCSACTDefaultJearyoInfo(String setHangmogCode, String suryang,
			String danui, String danuiName) {
		super();
		this.setHangmogCode = setHangmogCode;
		this.suryang = suryang;
		this.danui = danui;
		this.danuiName = danuiName;
	}
	public String getSetHangmogCode() {
		return setHangmogCode;
	}
	public void setSetHangmogCode(String setHangmogCode) {
		this.setHangmogCode = setHangmogCode;
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
	

}
