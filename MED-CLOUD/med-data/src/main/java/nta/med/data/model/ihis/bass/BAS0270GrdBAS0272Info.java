package nta.med.data.model.ihis.bass;

import java.sql.Timestamp;

public class BAS0270GrdBAS0272Info {
	private String doctor;
	private String doctorGwa;
	private String doctorGwaName;
	private String mainGwaYn;
	private Timestamp startDate;
	private Timestamp endDate;
	private String sabun;
	private String endYn;
	private String outDiscussYn; // OUT_DISCUSS_YN;
	private String reserOutYn; // RESER_OUT_YN;
	public BAS0270GrdBAS0272Info(String doctor, String doctorGwa,
			String doctorGwaName, String mainGwaYn, Timestamp startDate,
			Timestamp endDate, String sabun, String endYn, String outDiscussYn, String reserOutYn) {
		super();
		this.doctor = doctor;
		this.doctorGwa = doctorGwa;
		this.doctorGwaName = doctorGwaName;
		this.mainGwaYn = mainGwaYn;
		this.startDate = startDate;
		this.endDate = endDate;
		this.sabun = sabun;
		this.endYn = endYn;
		this.outDiscussYn = outDiscussYn;
		this.reserOutYn = reserOutYn;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorGwa() {
		return doctorGwa;
	}
	public void setDoctorGwa(String doctorGwa) {
		this.doctorGwa = doctorGwa;
	}
	public String getDoctorGwaName() {
		return doctorGwaName;
	}
	public void setDoctorGwaName(String doctorGwaName) {
		this.doctorGwaName = doctorGwaName;
	}
	public String getMainGwaYn() {
		return mainGwaYn;
	}
	public void setMainGwaYn(String mainGwaYn) {
		this.mainGwaYn = mainGwaYn;
	}
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public Timestamp getEndDate() {
		return endDate;
	}
	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}
	public String getSabun() {
		return sabun;
	}
	public void setSabun(String sabun) {
		this.sabun = sabun;
	}
	public String getEndYn() {
		return endYn;
	}
	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}
	
	public String getOutDiscussYn() {
		return outDiscussYn;
	}
	public void setOutDiscussYn(String outDiscussYn) {
		this.outDiscussYn = outDiscussYn;
	}
	public String getReserOutYn() {
		return reserOutYn;
	}
	public void setReserOutYn(String reserOutYn) {
		this.reserOutYn = reserOutYn;
	}
}
