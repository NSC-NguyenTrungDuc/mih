package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class OUT1001R01GrdListInfo {
	private String bunho;
	private String suname;
	private String suname2;
	private String dateConvert1;
	private String dateConvert2;
	private Timestamp naewonDate;
	private Double sujinNo;
	private Double jubsuNo;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String jubsuGubun;
	private String gubunName;
	private String jubsuTime;
	private String chojaeName;
	private String reserYn;
	private String arriveTime;
	private String naewonYn;
	private String yoyangName;
	private String sortKey;
	private String jundalPart;
	public OUT1001R01GrdListInfo(String bunho, String suname, String suname2,
			String dateConvert1, String dateConvert2, Timestamp naewonDate,
			Double sujinNo, Double jubsuNo, String gwa, String gwaName,
			String doctor, String doctorName, String jubsuGubun,
			String gubunName, String jubsuTime, String chojaeName,
			String reserYn, String arriveTime, String naewonYn,
			String yoyangName, String sortKey, String jundalPart) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.dateConvert1 = dateConvert1;
		this.dateConvert2 = dateConvert2;
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
		this.chojaeName = chojaeName;
		this.reserYn = reserYn;
		this.arriveTime = arriveTime;
		this.naewonYn = naewonYn;
		this.yoyangName = yoyangName;
		this.sortKey = sortKey;
		this.jundalPart = jundalPart;
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
	public String getDateConvert1() {
		return dateConvert1;
	}
	public void setDateConvert1(String dateConvert1) {
		this.dateConvert1 = dateConvert1;
	}
	public String getDateConvert2() {
		return dateConvert2;
	}
	public void setDateConvert2(String dateConvert2) {
		this.dateConvert2 = dateConvert2;
	}
	public Timestamp getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Timestamp naewonDate) {
		this.naewonDate = naewonDate;
	}
	public Double getSujinNo() {
		return sujinNo;
	}
	public void setSujinNo(Double sujinNo) {
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
	public String getChojaeName() {
		return chojaeName;
	}
	public void setChojaeName(String chojaeName) {
		this.chojaeName = chojaeName;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getArriveTime() {
		return arriveTime;
	}
	public void setArriveTime(String arriveTime) {
		this.arriveTime = arriveTime;
	}
	public String getNaewonYn() {
		return naewonYn;
	}
	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getSortKey() {
		return sortKey;
	}
	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
}
