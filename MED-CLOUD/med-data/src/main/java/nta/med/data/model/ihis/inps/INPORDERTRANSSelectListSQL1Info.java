package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INPORDERTRANSSelectListSQL1Info {
	private Double pkinp1001;
	private String bunho     ;
	private String suname ;
	private Date ipwonDate ;
	private String ipwonTime ;
	private String gwa ;
	private String doctor ;
	private String gwaName ;
	private String doctorName ;
	private String hoDong ;
	private String hoCode ;
	private Date sendDate ;
	private String transYn ;
	public INPORDERTRANSSelectListSQL1Info(Double pkinp1001, String bunho, String suname, Date ipwonDate,
			String ipwonTime, String gwa, String doctor, String gwaName, String doctorName, String hoDong,
			String hoCode, Date sendDate, String transYn) {
		super();
		this.pkinp1001 = pkinp1001;
		this.bunho = bunho;
		this.suname = suname;
		this.ipwonDate = ipwonDate;
		this.ipwonTime = ipwonTime;
		this.gwa = gwa;
		this.doctor = doctor;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.sendDate = sendDate;
		this.transYn = transYn;
	}
	public Double getPkinp1001() {
		return pkinp1001;
	}
	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
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
	public Date getIpwonDate() {
		return ipwonDate;
	}
	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}
	public String getIpwonTime() {
		return ipwonTime;
	}
	public void setIpwonTime(String ipwonTime) {
		this.ipwonTime = ipwonTime;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
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
	public Date getSendDate() {
		return sendDate;
	}
	public void setSendDate(Date sendDate) {
		this.sendDate = sendDate;
	}
	public String getTransYn() {
		return transYn;
	}
	public void setTransYn(String transYn) {
		this.transYn = transYn;
	}
	
}
