package nta.med.data.model.ihis.nuro;

public class NuroOUT1001U01GetTypeInfo {
	private String gubun ;
    private String gubunName;
    private String lastCheckDate;
    private String gongbiYn;
	public NuroOUT1001U01GetTypeInfo(String gubun, String gubunName,
			String lastCheckDate, String gongbiYn) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.lastCheckDate = lastCheckDate;
		this.gongbiYn = gongbiYn;
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
	public String getLastCheckDate() {
		return lastCheckDate;
	}
	public void setLastCheckDate(String lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}
	public String getGongbiYn() {
		return gongbiYn;
	}
	public void setGongbiYn(String gongbiYn) {
		this.gongbiYn = gongbiYn;
	}
    
}
