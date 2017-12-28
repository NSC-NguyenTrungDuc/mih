package nta.med.data.model.ihis.orca;

public class ORCALibGetDocInfo {
	private String yoyangGiho       ;
	private String yoyangName       ;
	private String zipCode          ;
	private String address           ;
	private String tel               ;
	private String presidentName    ;
	private String orcaGigwanCode  ;
	public ORCALibGetDocInfo(String yoyangGiho, String yoyangName,
			String zipCode, String address, String tel, String presidentName,
			String orcaGigwanCode) {
		super();
		this.yoyangGiho = yoyangGiho;
		this.yoyangName = yoyangName;
		this.zipCode = zipCode;
		this.address = address;
		this.tel = tel;
		this.presidentName = presidentName;
		this.orcaGigwanCode = orcaGigwanCode;
	}
	public String getYoyangGiho() {
		return yoyangGiho;
	}
	public void setYoyangGiho(String yoyangGiho) {
		this.yoyangGiho = yoyangGiho;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getZipCode() {
		return zipCode;
	}
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getPresidentName() {
		return presidentName;
	}
	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}
	public String getOrcaGigwanCode() {
		return orcaGigwanCode;
	}
	public void setOrcaGigwanCode(String orcaGigwanCode) {
		this.orcaGigwanCode = orcaGigwanCode;
	}
	
}
