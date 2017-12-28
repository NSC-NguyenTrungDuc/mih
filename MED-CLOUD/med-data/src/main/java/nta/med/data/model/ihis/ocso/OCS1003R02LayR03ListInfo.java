package nta.med.data.model.ihis.ocso;

public class OCS1003R02LayR03ListInfo {

	private String gwaName;
	private String bunho;
	private String suname;
	private String balheangDate;
	private String birth;
	private String naewonDate;
	private String bunho1;
	public OCS1003R02LayR03ListInfo(String gwaName, String bunho,
			String suname, String balheangDate, String birth,
			String naewonDate, String bunho1) {
		super();
		this.gwaName = gwaName;
		this.bunho = bunho;
		this.suname = suname;
		this.balheangDate = balheangDate;
		this.birth = birth;
		this.naewonDate = naewonDate;
		this.bunho1 = bunho1;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getBalheangDate() {
		return balheangDate;
	}
	public void setBalheangDate(String balheangDate) {
		this.balheangDate = balheangDate;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getBunho1() {
		return bunho1;
	}
	public void setBunho1(String bunho1) {
		this.bunho1 = bunho1;
	}
	
}