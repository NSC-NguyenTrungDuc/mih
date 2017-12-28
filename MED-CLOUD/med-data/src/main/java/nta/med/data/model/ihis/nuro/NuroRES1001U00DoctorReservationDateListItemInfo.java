package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroRES1001U00DoctorReservationDateListItemInfo {
	private String doctorCode;
	private String date;
	private Timestamp resDate;
	private String resFlag;
	private String resInwon;
	private String resOutwon;
	public NuroRES1001U00DoctorReservationDateListItemInfo(String doctorCode, String date, Timestamp resDate,
			String resFlag, String resInwon, String resOutwon) {
		super();
		this.doctorCode = doctorCode;
		this.date = date;
		this.resDate = resDate;
		this.resFlag = resFlag;
		this.resInwon = resInwon;
		this.resOutwon = resOutwon;
	}
	public String getDoctorCode() {
		return doctorCode;
	}
	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	public String getDate() {
		return date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public Timestamp getResDate() {
		return resDate;
	}
	public void setResDate(Timestamp resDate) {
		this.resDate = resDate;
	}
	public String getResFlag() {
		return resFlag;
	}
	public void setResFlag(String resFlag) {
		this.resFlag = resFlag;
	}
	public String getResInwon() {
		return resInwon;
	}
	public void setResInwon(String resInwon) {
		this.resInwon = resInwon;
	}
	public String getResOutwon() {
		return resOutwon;
	}
	public void setResOutwon(String resOutwon) {
		this.resOutwon = resOutwon;
	}
	
}
