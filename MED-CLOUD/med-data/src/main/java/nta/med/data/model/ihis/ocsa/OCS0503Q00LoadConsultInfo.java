package nta.med.data.model.ihis.ocsa;

import java.sql.Timestamp;

public class OCS0503Q00LoadConsultInfo{
	private String ioGubun;
    private String answerYn;        
    private String gwaConsultYn;
    private Timestamp naewonDate;
    private String jinryoTime ;
    private String bunho   ;
    private String suname ;
    private String suname2 ;
    private String hoDong ;
    private String sexAge;
    private String gubunName;
    private String gwa;
    private String doctor;
    private String naewonType;
    private Double jubsuNo;
    private String chojae;
    private String chojaeName;
    private Double pkNaewon;
    private String naewonYn;
    private Timestamp reqDate;
    private String reqGwa;
    private String reqDoctor;
    private String consultGwa;
    private String consultDoctor;
    private String reqIoGubun;
    private String gwaName;
    private String doctorName;
    private String answerUpdYn;
    private Timestamp appDate;
    private Double pkocs0503;
    private String orderEndYn;
	public OCS0503Q00LoadConsultInfo(String ioGubun, String answerYn,
			String gwaConsultYn, Timestamp naewonDate, String jinryoTime,
			String bunho, String suname, String suname2, String hoDong,
			String sexAge, String gubunName, String gwa, String doctor,
			String naewonType, Double jubsuNo, String chojae,
			String chojaeName, Double pkNaewon, String naewonYn,
			Timestamp reqDate, String reqGwa, String reqDoctor,
			String consultGwa, String consultDoctor, String reqIoGubun,
			String gwaName, String doctorName, String answerUpdYn,
			Timestamp appDate, Double pkocs0503, String orderEndYn) {
		super();
		this.ioGubun = ioGubun;
		this.answerYn = answerYn;
		this.gwaConsultYn = gwaConsultYn;
		this.naewonDate = naewonDate;
		this.jinryoTime = jinryoTime;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.hoDong = hoDong;
		this.sexAge = sexAge;
		this.gubunName = gubunName;
		this.gwa = gwa;
		this.doctor = doctor;
		this.naewonType = naewonType;
		this.jubsuNo = jubsuNo;
		this.chojae = chojae;
		this.chojaeName = chojaeName;
		this.pkNaewon = pkNaewon;
		this.naewonYn = naewonYn;
		this.reqDate = reqDate;
		this.reqGwa = reqGwa;
		this.reqDoctor = reqDoctor;
		this.consultGwa = consultGwa;
		this.consultDoctor = consultDoctor;
		this.reqIoGubun = reqIoGubun;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.answerUpdYn = answerUpdYn;
		this.appDate = appDate;
		this.pkocs0503 = pkocs0503;
		this.orderEndYn = orderEndYn;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	public String getAnswerYn() {
		return answerYn;
	}
	public void setAnswerYn(String answerYn) {
		this.answerYn = answerYn;
	}
	public String getGwaConsultYn() {
		return gwaConsultYn;
	}
	public void setGwaConsultYn(String gwaConsultYn) {
		this.gwaConsultYn = gwaConsultYn;
	}
	public Timestamp getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Timestamp naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getJinryoTime() {
		return jinryoTime;
	}
	public void setJinryoTime(String jinryoTime) {
		this.jinryoTime = jinryoTime;
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
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getSexAge() {
		return sexAge;
	}
	public void setSexAge(String sexAge) {
		this.sexAge = sexAge;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
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
	public String getChojae() {
		return chojae;
	}
	public void setChojae(String chojae) {
		this.chojae = chojae;
	}
	public String getChojaeName() {
		return chojaeName;
	}
	public void setChojaeName(String chojaeName) {
		this.chojaeName = chojaeName;
	}
	public Double getPkNaewon() {
		return pkNaewon;
	}
	public void setPkNaewon(Double pkNaewon) {
		this.pkNaewon = pkNaewon;
	}
	public String getNaewonYn() {
		return naewonYn;
	}
	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}
	public Timestamp getReqDate() {
		return reqDate;
	}
	public void setReqDate(Timestamp reqDate) {
		this.reqDate = reqDate;
	}
	public String getReqGwa() {
		return reqGwa;
	}
	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}
	public String getReqDoctor() {
		return reqDoctor;
	}
	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}
	public String getConsultGwa() {
		return consultGwa;
	}
	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}
	public String getConsultDoctor() {
		return consultDoctor;
	}
	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}
	public String getReqIoGubun() {
		return reqIoGubun;
	}
	public void setReqIoGubun(String reqIoGubun) {
		this.reqIoGubun = reqIoGubun;
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
	public String getAnswerUpdYn() {
		return answerUpdYn;
	}
	public void setAnswerUpdYn(String answerUpdYn) {
		this.answerUpdYn = answerUpdYn;
	}
	public Timestamp getAppDate() {
		return appDate;
	}
	public void setAppDate(Timestamp appDate) {
		this.appDate = appDate;
	}
	public Double getPkocs0503() {
		return pkocs0503;
	}
	public void setPkocs0503(Double pkocs0503) {
		this.pkocs0503 = pkocs0503;
	}
	public String getOrderEndYn() {
		return orderEndYn;
	}
	public void setOrderEndYn(String orderEndYn) {
		this.orderEndYn = orderEndYn;
	}
}