package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10LoadIpwonLstInfo {
	private Double pkinp1001   ;
	private String bunho       ;
	private Date ipwonDate  ;
	private String gwa         ;
	private String gwaName    ;
	private String doctor      ;
	private String doctorName ;                        
	private String gubun       ;
	private String gubunName  ;
	public OCS6010U10LoadIpwonLstInfo(Double pkinp1001, String bunho, Date ipwonDate, String gwa, String gwaName,
			String doctor, String doctorName, String gubun, String gubunName) {
		super();
		this.pkinp1001 = pkinp1001;
		this.bunho = bunho;
		this.ipwonDate = ipwonDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gubun = gubun;
		this.gubunName = gubunName;
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
	public Date getIpwonDate() {
		return ipwonDate;
	}
	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
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
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}
	
}
