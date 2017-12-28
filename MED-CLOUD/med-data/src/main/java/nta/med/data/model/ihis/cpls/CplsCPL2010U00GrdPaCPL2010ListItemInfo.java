package nta.med.data.model.ihis.cpls;

import java.math.BigInteger;
import java.util.Date;

public class CplsCPL2010U00GrdPaCPL2010ListItemInfo {
	private String bunho ;
	private String suname ;
	private String inOutGubun ;
	private String gwaName ;
	private String reserYn ;
	private String doctor ;
	private String doctorName ;
	private Date kijunDate ;
	private String emergencyYn ;
	private String naewonTime ;
	private BigInteger numProtocol;
	public CplsCPL2010U00GrdPaCPL2010ListItemInfo(String bunho, String suname,
			String inOutGubun, String gwaName, String reserYn, String doctor,
			String doctorName, Date kijunDate, String emergencyYn,
			String naewonTime, BigInteger numProtocol) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.inOutGubun = inOutGubun;
		this.gwaName = gwaName;
		this.reserYn = reserYn;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.kijunDate = kijunDate;
		this.emergencyYn = emergencyYn;
		this.naewonTime = naewonTime;
		this.numProtocol = numProtocol;
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
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
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
	public Date getKijunDate() {
		return kijunDate;
	}
	public void setKijunDate(Date kijunDate) {
		this.kijunDate = kijunDate;
	}
	public String getEmergencyYn() {
		return emergencyYn;
	}
	public void setEmergencyYn(String emergencyYn) {
		this.emergencyYn = emergencyYn;
	}
	public String getNaewonTime() {
		return naewonTime;
	}
	public void setNaewonTime(String naewonTime) {
		this.naewonTime = naewonTime;
	}
	public BigInteger getNumProtocol() {
		return numProtocol;
	}
	public void setNumProtocol(BigInteger numProtocol) {
		this.numProtocol = numProtocol;
	}
}
