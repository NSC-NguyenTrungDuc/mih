package nta.med.data.model.ihis.ocsa;

public class OCS0208U00GrdOCS0208Info {
	private String gubun;
	private String bogyongCode;
	private String banghyang;
	private String bogyongName;
	private String donbogYn;
	private String dv;
	private Double soryKey;
	private String userYn;
	private String ioGubun;
	public OCS0208U00GrdOCS0208Info(String gubun, String bogyongCode,
			String banghyang, String bogyongName, String donbogYn, String dv,
			Double soryKey, String userYn, String ioGubun) {
		super();
		this.gubun = gubun;
		this.bogyongCode = bogyongCode;
		this.banghyang = banghyang;
		this.bogyongName = bogyongName;
		this.donbogYn = donbogYn;
		this.dv = dv;
		this.soryKey = soryKey;
		this.userYn = userYn;
		this.ioGubun = ioGubun;
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
	public String getBanghyang() {
		return banghyang;
	}
	public void setBanghyang(String banghyang) {
		this.banghyang = banghyang;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getDonbogYn() {
		return donbogYn;
	}
	public void setDonbogYn(String donbogYn) {
		this.donbogYn = donbogYn;
	}
	public String getDv() {
		return dv;
	}
	public void setDv(String dv) {
		this.dv = dv;
	}
	public Double getSoryKey() {
		return soryKey;
	}
	public void setSoryKey(Double soryKey) {
		this.soryKey = soryKey;
	}
	public String getUserYn() {
		return userYn;
	}
	public void setUserYn(String userYn) {
		this.userYn = userYn;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	
}
