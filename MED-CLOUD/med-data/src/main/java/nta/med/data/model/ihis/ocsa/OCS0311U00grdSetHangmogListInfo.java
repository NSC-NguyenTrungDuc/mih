package nta.med.data.model.ihis.ocsa;

public class OCS0311U00grdSetHangmogListInfo {
	
	private String setPart ;
	private String hangCode ;
	private String setCode;
	private String setHangmogCode ;
	private String hangmogName ;
	private Double suryang ;
	private String danui ;
	private String danuiName ;
	private String bulyongYn ;
	public OCS0311U00grdSetHangmogListInfo(String setPart, String hangCode,
			String setCode, String setHangmogCode, String hangmogName,
			Double suryang, String danui, String danuiName, String bulyongYn) {
		super();
		this.setPart = setPart;
		this.hangCode = hangCode;
		this.setCode = setCode;
		this.setHangmogCode = setHangmogCode;
		this.hangmogName = hangmogName;
		this.suryang = suryang;
		this.danui = danui;
		this.danuiName = danuiName;
		this.bulyongYn = bulyongYn;
	}
	public String getSetPart() {
		return setPart;
	}
	public void setSetPart(String setPart) {
		this.setPart = setPart;
	}
	public String getHangCode() {
		return hangCode;
	}
	public void setHangCode(String hangCode) {
		this.hangCode = hangCode;
	}
	public String getSetCode() {
		return setCode;
	}
	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}
	public String getSetHangmogCode() {
		return setHangmogCode;
	}
	public void setSetHangmogCode(String setHangmogCode) {
		this.setHangmogCode = setHangmogCode;
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
	

}
