package nta.med.data.model.ihis.inps;

public class INP1001U01LoadBoheomChildListInfo {

	private String pkinp1002;
	private String gubun;
	private String gubunName;
	private String ipwonDate;

	public INP1001U01LoadBoheomChildListInfo(String pkinp1002, String gubun, String gubunName, String ipwonDate) {
		super();
		this.pkinp1002 = pkinp1002;
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.ipwonDate = ipwonDate;
	}

	public String getPkinp1002() {
		return pkinp1002;
	}

	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

}
