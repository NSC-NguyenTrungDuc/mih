package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201U99ReserListInfo {
	private Date naewonDate;
	private String jinryoPreTime;
	private String gwaName;
	private String doctorName;

	public SchsSCH0201U99ReserListInfo(Date naewonDate, String jinryoPreTime,
			String gwaName, String doctorName) {
		super();
		this.naewonDate = naewonDate;
		this.jinryoPreTime = jinryoPreTime;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
	}

	public Date getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getJinryoPreTime() {
		return jinryoPreTime;
	}

	public void setJinryoPreTime(String jinryoPreTime) {
		this.jinryoPreTime = jinryoPreTime;
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

}
