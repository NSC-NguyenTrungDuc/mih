package nta.med.data.model.ihis.drug;

public class DRGOCSCHKGrdOcsChkInfo {
	private String jaeryoCode;
	private String jaeryoName;
	private String drgPackYn;
	private String phamarcyYn;
	private String powerYn;
	private String hubalChangeYn;
	private String mayakYn; 
	private String smallCode;
	private String smallCodeName;
	private String cautionCode;
	private String cautionName;
	public DRGOCSCHKGrdOcsChkInfo(String jaeryoCode, String jaeryoName,
			String drgPackYn, String phamarcyYn, String powerYn,
			String hubalChangeYn, String mayakYn, String smallCode,
			String smallCodeName, String cautionCode, String cautionName) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.drgPackYn = drgPackYn;
		this.phamarcyYn = phamarcyYn;
		this.powerYn = powerYn;
		this.hubalChangeYn = hubalChangeYn;
		this.mayakYn = mayakYn;
		this.smallCode = smallCode;
		this.smallCodeName = smallCodeName;
		this.cautionCode = cautionCode;
		this.cautionName = cautionName;
	}
	public String getJaeryoCode() {
		return jaeryoCode;
	}
	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public String getDrgPackYn() {
		return drgPackYn;
	}
	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}
	public String getPhamarcyYn() {
		return phamarcyYn;
	}
	public void setPhamarcyYn(String phamarcyYn) {
		this.phamarcyYn = phamarcyYn;
	}
	public String getPowerYn() {
		return powerYn;
	}
	public void setPowerYn(String powerYn) {
		this.powerYn = powerYn;
	}
	public String getHubalChangeYn() {
		return hubalChangeYn;
	}
	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}
	public String getMayakYn() {
		return mayakYn;
	}
	public void setMayakYn(String mayakYn) {
		this.mayakYn = mayakYn;
	}
	public String getSmallCode() {
		return smallCode;
	}
	public void setSmallCode(String smallCode) {
		this.smallCode = smallCode;
	}
	public String getSmallCodeName() {
		return smallCodeName;
	}
	public void setSmallCodeName(String smallCodeName) {
		this.smallCodeName = smallCodeName;
	}
	public String getCautionCode() {
		return cautionCode;
	}
	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}
	public String getCautionName() {
		return cautionName;
	}
	public void setCautionName(String cautionName) {
		this.cautionName = cautionName;
	}
}