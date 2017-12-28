package nta.med.data.model.ihis.inps;

public class INP1001U01FwkGubunInfo {

	private String gubun;
	private String gubunName;
	private String sysDate;
	private String gongbiYn;
	private String johapGubun;
	private String johapName;

	public INP1001U01FwkGubunInfo(String gubun, String gubunName, String sysDate, String gongbiYn, String johapGubun,
			String johapName) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.sysDate = sysDate;
		this.gongbiYn = gongbiYn;
		this.johapGubun = johapGubun;
		this.johapName = johapName;
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

	public String getSysDate() {
		return sysDate;
	}

	public void setSysDate(String sysDate) {
		this.sysDate = sysDate;
	}

	public String getGongbiYn() {
		return gongbiYn;
	}

	public void setGongbiYn(String gongbiYn) {
		this.gongbiYn = gongbiYn;
	}

	public String getJohapGubun() {
		return johapGubun;
	}

	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}

	public String getJohapName() {
		return johapName;
	}

	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}

}
