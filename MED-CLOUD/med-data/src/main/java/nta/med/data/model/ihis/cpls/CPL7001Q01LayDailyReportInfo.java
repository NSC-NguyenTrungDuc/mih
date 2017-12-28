package nta.med.data.model.ihis.cpls;

public class CPL7001Q01LayDailyReportInfo {
	private String gumsaDate;
    private String bunho;
    private String suname;
    private String gwa;
    private String doctorName;
    private String hangmogCode;
    private String hangmogName;
    private String specimenSer;
    private String specimenName;
	public CPL7001Q01LayDailyReportInfo(String gumsaDate, String bunho,
			String suname, String gwa, String doctorName, String hangmogCode,
			String hangmogName, String specimenSer, String specimenName) {
		super();
		this.gumsaDate = gumsaDate;
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.specimenSer = specimenSer;
		this.specimenName = specimenName;
	}
	public String getGumsaDate() {
		return gumsaDate;
	}
	public void setGumsaDate(String gumsaDate) {
		this.gumsaDate = gumsaDate;
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
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
}
