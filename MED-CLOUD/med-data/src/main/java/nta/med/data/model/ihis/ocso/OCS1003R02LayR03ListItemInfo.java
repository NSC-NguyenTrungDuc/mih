package nta.med.data.model.ihis.ocso;

import java.util.Date;

public class OCS1003R02LayR03ListItemInfo {
	private String gwa ;
	private String gwaName ;
	private String bunho ;
	private String suname ;
	private String balheangDate ;
	private String birth ;
	private String naewonDate ;
	private String moveName ;
	private String bunho1 ;
	private Date hopeDate ;
	public OCS1003R02LayR03ListItemInfo(String gwa, String gwaName,
			String bunho, String suname, String balheangDate, String birth,
			String naewonDate, String moveName, String bunho1, Date hopeDate) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.bunho = bunho;
		this.suname = suname;
		this.balheangDate = balheangDate;
		this.birth = birth;
		this.naewonDate = naewonDate;
		this.moveName = moveName;
		this.bunho1 = bunho1;
		this.hopeDate = hopeDate;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
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
	public String getMoveName() {
		return moveName;
	}
	public void setMoveName(String moveName) {
		this.moveName = moveName;
	}
	public String getBunho1() {
		return bunho1;
	}
	public void setBunho1(String bunho1) {
		this.bunho1 = bunho1;
	}
	public Date getHopeDate() {
		return hopeDate;
	}
	public void setHopeDate(Date hopeDate) {
		this.hopeDate = hopeDate;
	}
	
}
