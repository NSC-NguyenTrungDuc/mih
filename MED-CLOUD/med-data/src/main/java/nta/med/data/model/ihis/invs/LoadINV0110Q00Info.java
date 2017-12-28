package nta.med.data.model.ihis.invs;

public class LoadINV0110Q00Info {

	private String jaeryoCode;
	private String jaeryoName;
	private String subulDanui;
	private String subulDanuiName;
	private String subulDanga;

	public LoadINV0110Q00Info(String jaeryoCode, String jaeryoName, String subulDanui, String subulDanuiName,
			String subulDanga) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.subulDanui = subulDanui;
		this.subulDanuiName = subulDanuiName;
		this.subulDanga = subulDanga;
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

	public String getSubulDanui() {
		return subulDanui;
	}

	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}

	public String getSubulDanuiName() {
		return subulDanuiName;
	}

	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}

	public String getSubulDanga() {
		return subulDanga;
	}

	public void setSubulDanga(String subulDanga) {
		this.subulDanga = subulDanga;
	}

}
