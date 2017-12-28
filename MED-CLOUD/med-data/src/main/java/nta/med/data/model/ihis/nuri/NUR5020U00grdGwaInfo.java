package nta.med.data.model.ihis.nuri;

public class NUR5020U00grdGwaInfo {

	private String nurWrdt;
	private String hoDong;
	private String gwa;
	private String gwaName;
	private String paCnt;

	public NUR5020U00grdGwaInfo(String nurWrdt, String hoDong, String gwa, String gwaName, String paCnt) {
		super();
		this.nurWrdt = nurWrdt;
		this.hoDong = hoDong;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.paCnt = paCnt;
	}

	public String getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(String nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
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

	public String getPaCnt() {
		return paCnt;
	}

	public void setPaCnt(String paCnt) {
		this.paCnt = paCnt;
	}

}
