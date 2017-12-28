package nta.med.data.model.ihis.invs;

public class INV6002U00GrdINV6002AfterInfo {

	private String jaeryoCode;
	private String jaeryoName;
	private Double existCount;
	private String subulDanuiName;
	private String inputDate;
	private String inputUser;
	private String jaryoGubun;

	public INV6002U00GrdINV6002AfterInfo(String jaeryoCode, String jaeryoName, Double existCount, String subulDanuiName,
			String inputDate, String inputUser, String jaryoGubun) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.existCount = existCount;
		this.subulDanuiName = subulDanuiName;
		this.inputDate = inputDate;
		this.inputUser = inputUser;
		this.jaryoGubun = jaryoGubun;
	}

	public String getJaeryoName() {
		return jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}

	public Double getExistCount() {
		return existCount;
	}

	public void setExistCount(Double existCount) {
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

	public String getJaeryoCode() {
		return jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}

}
