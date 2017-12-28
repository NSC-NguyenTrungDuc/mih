package nta.med.data.model.ihis.ocsa;

import java.sql.Timestamp;

public class OCS0503Q00FilteringTheInformationInfo {
	private String reserYn;
    private String jinryoTime;        
    private String gwaName;
    private String doctorName;
    private String naewonYn;
    private String bunho;
    private Timestamp naewonDate;
    private String gwa;
    private String doctor;
    private String naewonType;
    private Double jubsuNo;
	public OCS0503Q00FilteringTheInformationInfo(String reserYn,
			String jinryoTime, String gwaName, String doctorName,
			String naewonYn, String bunho, Timestamp naewonDate, String gwa,
			String doctor, String naewonType, Double jubsuNo) {
		super();
		this.reserYn = reserYn;
		this.jinryoTime = jinryoTime;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.naewonYn = naewonYn;
		this.bunho = bunho;
		this.naewonDate = naewonDate;
		this.gwa = gwa;
		this.doctor = doctor;
		this.naewonType = naewonType;
		this.jubsuNo = jubsuNo;
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
	public String getNaewonYn() {
		return naewonYn;
	}
	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
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
}