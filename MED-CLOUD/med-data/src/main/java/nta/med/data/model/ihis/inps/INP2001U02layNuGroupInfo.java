package nta.med.data.model.ihis.inps;

public class INP2001U02layNuGroupInfo {

	private Double pkOut1001;
	private String gwaName;
	private String naewonDate;
	private String jubsuGubun;

	public INP2001U02layNuGroupInfo(Double pkOut1001, String gwaName, String naewonDate, String jubsuGubun) {
		super();
		this.pkOut1001 = pkOut1001;
		this.gwaName = gwaName;
		this.naewonDate = naewonDate;
		this.jubsuGubun = jubsuGubun;
	}

	public Double getPkOut1001() {
		return pkOut1001;
	}

	public void setPkOut1001(Double pkOut1001) {
		this.pkOut1001 = pkOut1001;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getJubsuGubun() {
		return jubsuGubun;
	}

	public void setJubsuGubun(String jubsuGubun) {
		this.jubsuGubun = jubsuGubun;
	}

}
