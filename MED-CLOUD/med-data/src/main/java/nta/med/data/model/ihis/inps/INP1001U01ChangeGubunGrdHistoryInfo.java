package nta.med.data.model.ihis.inps;

public class INP1001U01ChangeGubunGrdHistoryInfo {

	private String gubun;
	private String gubunName;
	private String gubunIpwonDate1;
	private String pkinp1002;
	private String gubunIpwonDate2;
	private Double fkinp1001;

	public INP1001U01ChangeGubunGrdHistoryInfo(String gubun, String gubunName, String gubunIpwonDate1, String pkinp1002,
			String gubunIpwonDate2, Double fkinp1001) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.gubunIpwonDate1 = gubunIpwonDate1;
		this.pkinp1002 = pkinp1002;
		this.gubunIpwonDate2 = gubunIpwonDate2;
		this.fkinp1001 = fkinp1001;
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

	public String getGubunIpwonDate1() {
		return gubunIpwonDate1;
	}

	public void setGubunIpwonDate1(String gubunIpwonDate1) {
		this.gubunIpwonDate1 = gubunIpwonDate1;
	}

	public String getPkinp1002() {
		return pkinp1002;
	}

	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}

	public String getGubunIpwonDate2() {
		return gubunIpwonDate2;
	}

	public void setGubunIpwonDate2(String gubunIpwonDate2) {
		this.gubunIpwonDate2 = gubunIpwonDate2;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

}
