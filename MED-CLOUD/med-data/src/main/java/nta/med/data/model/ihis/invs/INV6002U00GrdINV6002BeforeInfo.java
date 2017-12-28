package nta.med.data.model.ihis.invs;

public class INV6002U00GrdINV6002BeforeInfo {

	private String jaeryoCode;
	private String jaeryoName;
	private String subulDanuiName;
	private String jaryoGubun;

	public INV6002U00GrdINV6002BeforeInfo(String jaeryoCode, String jaeryoName, String subulDanuiName,
			String jaryoGubun) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.subulDanuiName = subulDanuiName;
		this.jaryoGubun = jaryoGubun;
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

	public String getSubulDanuiName() {
		return subulDanuiName;
	}

	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}

	public String getJaryoGubun() {
		return jaryoGubun;
	}

	public void setJaryoGubun(String jaryoGubun) {
		this.jaryoGubun = jaryoGubun;
	}

}
