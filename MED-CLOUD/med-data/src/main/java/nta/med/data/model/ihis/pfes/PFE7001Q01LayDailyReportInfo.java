package nta.med.data.model.ihis.pfes;

public class PFE7001Q01LayDailyReportInfo {
	private String gumsaDate   ;
	private String ioGubun     ;
	private String bunho        ;
	private String suname       ;
	private String gwa          ;
	private String doctorName  ;
	private String jundalPart  ;
	private String hangmogCode ;
	private String hangmogName ;
	public PFE7001Q01LayDailyReportInfo(String gumsaDate, String ioGubun,
			String bunho, String suname, String gwa, String doctorName,
			String jundalPart, String hangmogCode, String hangmogName) {
		super();
		this.gumsaDate = gumsaDate;
		this.ioGubun = ioGubun;
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.jundalPart = jundalPart;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
	}
	public String getGumsaDate() {
		return gumsaDate;
	}
	public void setGumsaDate(String gumsaDate) {
		this.gumsaDate = gumsaDate;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
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
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	
}
