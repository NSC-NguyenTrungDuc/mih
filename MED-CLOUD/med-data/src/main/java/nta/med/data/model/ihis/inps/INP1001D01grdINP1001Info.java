package nta.med.data.model.ihis.inps;

import java.math.BigInteger;

public class INP1001D01grdINP1001Info {
	private Double pkInp1001;
	private String bunho;
	private String suname;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String hoDong;
	private String hoDongName;
	private String hoCode;
	private String bedNo;
	private String ipwonDate;
	private String toiwonGojiDate;
	private BigInteger toiRes;
	public INP1001D01grdINP1001Info(Double pkInp1001, String bunho, String suname, String gwa, String gwaName,
			String doctor, String doctorName, String hoDong, String hoDongName, String hoCode, String bedNo,
			String ipwonDate, String toiwonGojiDate, BigInteger toiRes) {
		super();
		this.pkInp1001 = pkInp1001;
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoDongName = hoDongName;
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.ipwonDate = ipwonDate;
		this.toiwonGojiDate = toiwonGojiDate;
		this.toiRes = toiRes;
	}
	public Double getPkInp1001() {
		return pkInp1001;
	}
	public void setPkInp1001(Double pkInp1001) {
		this.pkInp1001 = pkInp1001;
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
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoDongName() {
		return hoDongName;
	}
	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getBedNo() {
		return bedNo;
	}
	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}
	public String getIpwonDate() {
		return ipwonDate;
	}
	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}
	public String getToiwonGojiDate() {
		return toiwonGojiDate;
	}
	public void setToiwonGojiDate(String toiwonGojiDate) {
		this.toiwonGojiDate = toiwonGojiDate;
	}
	public BigInteger getToiRes() {
		return toiRes;
	}
	public void setToiRes(BigInteger toiRes) {
		this.toiRes = toiRes;
	}
	
}
