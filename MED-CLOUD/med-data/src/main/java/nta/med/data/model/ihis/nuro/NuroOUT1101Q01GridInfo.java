package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroOUT1101Q01GridInfo {
	 private String bunho;
     private String suname;
     private String suname2;
     private String birth;
     private String naewonDateJp;
     private Timestamp naewonDate;
     private String sujinNo;
     private Double jubsuNo;
     private String gwa;
     private String gwaName;
     private String doctor;
     private String doctorName;
     private String jubsuGubun;
     private String gubunName;
     private String jubsuTime;
     private String yoyangName;
	public NuroOUT1101Q01GridInfo(String bunho, String suname, String suname2,
			String birth, String naewonDateJp, Timestamp naewonDate,
			String sujinNo, Double jubsuNo, String gwa, String gwaName,
			String doctor, String doctorName, String jubsuGubun,
			String gubunName, String jubsuTime, String yoyangName) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.naewonDateJp = naewonDateJp;
		this.naewonDate = naewonDate;
		this.sujinNo = sujinNo;
		this.jubsuNo = jubsuNo;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.jubsuGubun = jubsuGubun;
		this.gubunName = gubunName;
		this.jubsuTime = jubsuTime;
		this.yoyangName = yoyangName;
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
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getNaewonDateJp() {
		return naewonDateJp;
	}
	public void setNaewonDateJp(String naewonDateJp) {
		this.naewonDateJp = naewonDateJp;
	}
	public Timestamp getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Timestamp naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getSujinNo() {
		return sujinNo;
	}
	public void setSujinNo(String sujinNo) {
		this.sujinNo = sujinNo;
	}
	public Double getJubsuNo() {
		return jubsuNo;
	}
	public void setJubsuNo(Double jubsuNo) {
		this.jubsuNo = jubsuNo;
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
	public String getJubsuGubun() {
		return jubsuGubun;
	}
	public void setJubsuGubun(String jubsuGubun) {
		this.jubsuGubun = jubsuGubun;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	
}
