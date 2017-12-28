package nta.med.data.model.ihis.cpls;

public class CPL2010U01grdPaListInfo {
	private String bunho;
    private String suname ;
    private String gwaName ;
    private String doctor ;
    private String doctorName ;
    private String hoDong ;
    private String hoCode ;
    private String reserYn ;
    private String emergencyYn ;
	public CPL2010U01grdPaListInfo(String bunho, String suname, String gwaName, String doctor, String doctorName,
			String hoDong, String hoCode, String reserYn, String emergencyYn) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.reserYn = reserYn;
		this.emergencyYn = emergencyYn;
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
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getEmergencyYn() {
		return emergencyYn;
	}
	public void setEmergencyYn(String emergencyYn) {
		this.emergencyYn = emergencyYn;
	}
    
}
