package nta.med.data.model.ihis.invs;

public class INV6002U00GrdINV6002Info {
	private String jaeryoCode          ;
	private String jaeryoName          ;
	private String existCount          ;
	private String subulDanuiName     ;
	private String inputDate           ;
	private String inputUser           ;
	private String jaryoGubun          ;
	private String magamMonth          ;
	public INV6002U00GrdINV6002Info(String jaeryoCode, String jaeryoName, String existCount, String subulDanuiName,
			String inputDate, String inputUser, String jaryoGubun, String magamMonth) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.existCount = existCount;
		this.subulDanuiName = subulDanuiName;
		this.inputDate = inputDate;
		this.inputUser = inputUser;
		this.jaryoGubun = jaryoGubun;
		this.magamMonth = magamMonth;
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
	public String getExistCount() {
		return existCount;
	}
	public void setExistCount(String existCount) {
		this.existCount = existCount;
	}
	public String getSubulDanuiName() {
		return subulDanuiName;
	}
	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}
	public String getInputDate() {
		return inputDate;
	}
	public void setInputDate(String inputDate) {
		this.inputDate = inputDate;
	}
	public String getInputUser() {
		return inputUser;
	}
	public void setInputUser(String inputUser) {
		this.inputUser = inputUser;
	}
	public String getJaryoGubun() {
		return jaryoGubun;
	}
	public void setJaryoGubun(String jaryoGubun) {
		this.jaryoGubun = jaryoGubun;
	}
	public String getMagamMonth() {
		return magamMonth;
	}
	public void setMagamMonth(String magamMonth) {
		this.magamMonth = magamMonth;
	}
}
