package nta.med.data.model.ihis.ocso;

import java.util.Date;

public class OCS1003Q02GridOUT1001Info {
    private String jubsu ;
	private String reserYn ;
	private String jinryoTime ;
	private String gwaName ;
	private String doctorName ;
	private String naewonYnName ;
	private String bunho ;
	private Date naewonDate;
	private String gwa ;
	private String doctor ;
	private String naewonType ;
	private Double jubsuNo ;
	private Double pkNaewon ;
	private String orderEndYn ;
	public OCS1003Q02GridOUT1001Info(String jubsu, String reserYn,
			String jinryoTime, String gwaName, String doctorName,
			String naewonYnName, String bunho, Date naewonDate, String gwa,
			String doctor, String naewonType, Double jubsuNo, Double pkNaewon,
			String orderEndYn) {
		super();
		this.jubsu = jubsu;
		this.reserYn = reserYn;
		this.jinryoTime = jinryoTime;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.naewonYnName = naewonYnName;
		this.bunho = bunho;
		this.naewonDate = naewonDate;
		this.gwa = gwa;
		this.doctor = doctor;
		this.naewonType = naewonType;
		this.jubsuNo = jubsuNo;
		this.pkNaewon = pkNaewon;
		this.orderEndYn = orderEndYn;
	}
	public String getJubsu() {
		return jubsu;
	}
	public void setJubsu(String jubsu) {
		this.jubsu = jubsu;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getJinryoTime() {
		return jinryoTime;
	}
	public void setJinryoTime(String jinryoTime) {
		this.jinryoTime = jinryoTime;
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
	public String getNaewonYnName() {
		return naewonYnName;
	}
	public void setNaewonYnName(String naewonYnName) {
		this.naewonYnName = naewonYnName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Date getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
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
	public String getNaewonType() {
		return naewonType;
	}
	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}
	public Double getJubsuNo() {
		return jubsuNo;
	}
	public void setJubsuNo(Double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}
	public Double getPkNaewon() {
		return pkNaewon;
	}
	public void setPkNaewon(Double pkNaewon) {
		this.pkNaewon = pkNaewon;
	}
	public String getOrderEndYn() {
		return orderEndYn;
	}
	public void setOrderEndYn(String orderEndYn) {
		this.orderEndYn = orderEndYn;
	}
	
}
