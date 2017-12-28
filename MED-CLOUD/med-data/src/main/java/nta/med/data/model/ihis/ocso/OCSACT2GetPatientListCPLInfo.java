package nta.med.data.model.ihis.ocso;

import java.math.BigInteger;

public class OCSACT2GetPatientListCPLInfo {
	private String bunho             ;
	private String suname            ;
	private String inOutGubun      ;
	private String gwa               ;
	private String gwaName          ;
	private String reserYn          ;
	private String doctor            ;
	private String doctorName       ;
	private String kijunDate        ;
	private String emergencyYn      ;
	private String naewonTime       ;
	private BigInteger numProtocol;
	private String suname2           ;
	private Double pkocs1003         ;
	private Double pkout1001         ;
	private String jundalTable      ;
	public OCSACT2GetPatientListCPLInfo(String bunho, String suname, String inOutGubun, String gwa, String gwaName,
			String reserYn, String doctor, String doctorName, String kijunDate, String emergencyYn, String naewonTime,
			BigInteger numProtocol, String suname2, Double pkocs1003, Double pkout1001, String jundalTable) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.inOutGubun = inOutGubun;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.reserYn = reserYn;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.kijunDate = kijunDate;
		this.emergencyYn = emergencyYn;
		this.naewonTime = naewonTime;
		this.numProtocol = numProtocol;
		this.suname2 = suname2;
		this.pkocs1003 = pkocs1003;
		this.pkout1001 = pkout1001;
		this.jundalTable = jundalTable;
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
	public String getKijunDate() {
		return kijunDate;
	}
	public void setKijunDate(String kijunDate) {
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
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public Double getPkocs1003() {
		return pkocs1003;
	}
	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	
}
