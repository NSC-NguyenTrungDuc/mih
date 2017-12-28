package nta.med.data.model.ihis.ocsa;

public class OCS0208Q01GrdOCS0208Info {
	private String gubun ;
	private String bogyongCode ;
	private String bogyongName ;
	private String userYn ;
	private String bogyongGubun ;
	private Double seq ;
	public OCS0208Q01GrdOCS0208Info(String gubun, String bogyongCode,
			String bogyongName, String userYn, String bogyongGubun, Double seq) {
		super();
		this.gubun = gubun;
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.userYn = userYn;
		this.bogyongGubun = bogyongGubun;
		this.seq = seq;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getUserYn() {
		return userYn;
	}
	public void setUserYn(String userYn) {
		this.userYn = userYn;
	}
	public String getBogyongGubun() {
		return bogyongGubun;
	}
	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	
}
