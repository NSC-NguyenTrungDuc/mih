package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR2004U00layCurrentBedInfo {

	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String hoDong1;
	private String hoCode1;
	private String bedNo;
	private String suname;
	private Date ipwonDate;
	private Date toiwonResDate;
	private String toiwonResYn;
	private String totBed;
	private Double pkinp1001;
	private String transCnt;
	private String buDoctorList;
	private String hoGrade1;
	private String kaikeiHodong;
	private String kaikeiHocode;

	public NUR2004U00layCurrentBedInfo(String gwa, String gwaName, String doctor, String doctorName, String hoDong1,
			String hoCode1, String bedNo, String suname, Date ipwonDate, Date toiwonResDate, String toiwonResYn,
			String totBed, Double pkinp1001, String transCnt, String buDoctorList, String hoGrade1, String kaikeiHodong,
			String kaikeiHocode) {
		super();
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hoDong1 = hoDong1;
		this.hoCode1 = hoCode1;
		this.bedNo = bedNo;
		this.suname = suname;
		this.ipwonDate = ipwonDate;
		this.toiwonResDate = toiwonResDate;
		this.toiwonResYn = toiwonResYn;
		this.totBed = totBed;
		this.pkinp1001 = pkinp1001;
		this.transCnt = transCnt;
		this.buDoctorList = buDoctorList;
		this.hoGrade1 = hoGrade1;
		this.kaikeiHodong = kaikeiHodong;
		this.kaikeiHocode = kaikeiHocode;
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

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
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

	public Date getToiwonResDate() {
		return toiwonResDate;
	}

	public void setToiwonResDate(Date toiwonResDate) {
		this.toiwonResDate = toiwonResDate;
	}

	public String getToiwonResYn() {
		return toiwonResYn;
	}

	public void setToiwonResYn(String toiwonResYn) {
		this.toiwonResYn = toiwonResYn;
	}

	public String getTotBed() {
		return totBed;
	}

	public void setTotBed(String totBed) {
		this.totBed = totBed;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getTransCnt() {
		return transCnt;
	}

	public void setTransCnt(String transCnt) {
		this.transCnt = transCnt;
	}

	public String getBuDoctorList() {
		return buDoctorList;
	}

	public void setBuDoctorList(String buDoctorList) {
		this.buDoctorList = buDoctorList;
	}

	public String getHoGrade1() {
		return hoGrade1;
	}

	public void setHoGrade1(String hoGrade1) {
		this.hoGrade1 = hoGrade1;
	}

	public String getKaikeiHodong() {
		return kaikeiHodong;
	}

	public void setKaikeiHodong(String kaikeiHodong) {
		this.kaikeiHodong = kaikeiHodong;
	}

	public String getKaikeiHocode() {
		return kaikeiHocode;
	}

	public void setKaikeiHocode(String kaikeiHocode) {
		this.kaikeiHocode = kaikeiHocode;
	}

}
