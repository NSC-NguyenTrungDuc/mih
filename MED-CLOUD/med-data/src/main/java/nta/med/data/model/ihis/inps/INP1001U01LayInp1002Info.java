package nta.med.data.model.ihis.inps;

public class INP1001U01LayInp1002Info {

	private String gubun;
	private String gubunName;
	private String pkinp1002;
	private String gubunIpwonDate;

	public INP1001U01LayInp1002Info(String gubun, String gubunName, String pkinp1002, String gubunIpwonDate) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.pkinp1002 = pkinp1002;
		this.gubunIpwonDate = gubunIpwonDate;
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

	public String getPkinp1002() {
		return pkinp1002;
	}

	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}

	public String getGubunIpwonDate() {
		return gubunIpwonDate;
	}

	public void setGubunIpwonDate(String gubunIpwonDate) {
		this.gubunIpwonDate = gubunIpwonDate;
	}

}
