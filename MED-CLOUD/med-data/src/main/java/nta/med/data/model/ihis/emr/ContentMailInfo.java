package nta.med.data.model.ihis.emr;

import java.util.Date;

public class ContentMailInfo {
	private String hospitalName;
	private String patientCode;
	private String patientName;
	//private double receptionCode;
	private String doctorName;
	private String doctorCode;
	private Date updateTime;
	private String log;
	
	public ContentMailInfo(String hospitalName, String patientCode,
			String patientName, /*double receptionCode,*/ String doctorName,
			String doctorCode, Date updateTime, String log) {
		super();
		this.hospitalName = hospitalName;
		this.patientCode = patientCode;
		this.patientName = patientName;
		//this.receptionCode = receptionCode;
		this.doctorName = doctorName;
		this.doctorCode = doctorCode;
		this.updateTime = updateTime;
		this.log = log;
	}
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public String getPatientCode() {
		return patientCode;
	}
	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getDoctorCode() {
		return doctorCode;
	}
	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	public Date getUpdateTime() {
		return updateTime;
	}
	public void setUpdateTime(Date updateTime) {
		this.updateTime = updateTime;
	}
	public String getLog() {
		return log;
	}
	public void setLog(String log) {
		this.log = log;
	}
	
	
	
}
