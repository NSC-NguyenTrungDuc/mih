package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201U99LayoutTimeListInfo {

	private Date reserDate;
	private String fromTime;
	private String bunho;
	private String suname;
	private String hangmogCode;
	private String hangmogName;
	private String gwa;
	private String doctorName;
	private String actYn;

	public SchsSCH0201U99LayoutTimeListInfo(Date reserDate, String fromTime,
			String bunho, String suname, String hangmogCode,
			String hangmogName, String gwa, String doctorName, String actYn) {
		super();
		this.reserDate = reserDate;
		this.fromTime = fromTime;
		this.bunho = bunho;
		this.suname = suname;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.gwa = gwa;
		this.doctorName = doctorName;
		this.actYn = actYn;
	}

	public Date getReserDate() {
		return reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	public String getFromTime() {
		return fromTime;
	}

	public void setFromTime(String fromTime) {
		this.fromTime = fromTime;
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

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getActYn() {
		return actYn;
	}

	public void setActYn(String actYn) {
		this.actYn = actYn;
	}

}
