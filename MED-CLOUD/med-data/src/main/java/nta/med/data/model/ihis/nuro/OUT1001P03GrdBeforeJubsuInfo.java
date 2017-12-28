package nta.med.data.model.ihis.nuro;

import java.sql.Date;
import java.sql.Timestamp;

public class OUT1001P03GrdBeforeJubsuInfo {
	private String ioGubun;
	private Double pkKey;
	private String bunho;
	private String suname;
	private Timestamp naewonDate;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String naewonTime;
	private String selectYn;
	private String comments;
	private String bunhoType;
	private String reserYn;
	private String reserGubun;
	public OUT1001P03GrdBeforeJubsuInfo(String ioGubun, Double pkKey,
			String bunho, String suname, Timestamp naewonDate, String gwa,
			String gwaName, String doctor, String doctorName,
			String naewonTime, String selectYn, String comments,
			String bunhoType, String reserYn, String reserGubun) {
		super();
		this.ioGubun = ioGubun;
		this.pkKey = pkKey;
		this.bunho = bunho;
		this.suname = suname;
		this.naewonDate = naewonDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.naewonTime = naewonTime;
		this.selectYn = selectYn;
		this.comments = comments;
		this.bunhoType = bunhoType;
		this.reserYn = reserYn;
		this.reserGubun = reserGubun;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	public Double getPkKey() {
		return pkKey;
	}
	public void setPkKey(Double pkKey) {
		this.pkKey = pkKey;
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
	public Timestamp getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Timestamp naewonDate) {
		this.naewonDate = naewonDate;
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
	public String getNaewonTime() {
		return naewonTime;
	}
	public void setNaewonTime(String naewonTime) {
		this.naewonTime = naewonTime;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public String getBunhoType() {
		return bunhoType;
	}
	public void setBunhoType(String bunhoType) {
		this.bunhoType = bunhoType;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getReserGubun() {
		return reserGubun;
	}
	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
	}
}
