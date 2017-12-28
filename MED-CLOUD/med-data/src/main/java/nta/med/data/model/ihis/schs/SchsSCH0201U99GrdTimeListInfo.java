package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201U99GrdTimeListInfo {
	private String fromTime;
	private String bunho;
	private String suname;
	private String hangmogName;
	private String doctorName;
	private Date inputDate;
	private Date orderDate;
	private Date reserDate;
	private Double pksch0201;
	private String outHospCode;
	private String yoyangName;
	public SchsSCH0201U99GrdTimeListInfo(String fromTime, String bunho,
			String suname, String hangmogName, String doctorName,
			Date inputDate, Date orderDate, Date reserDate, Double pksch0201, String outHospCode, String yoyangName) {
		super();
		this.fromTime = fromTime;
		this.bunho = bunho;
		this.suname = suname;
		this.hangmogName = hangmogName;
		this.doctorName = doctorName;
		this.inputDate = inputDate;
		this.orderDate = orderDate;
		this.reserDate = reserDate;
		this.pksch0201 = pksch0201;
		this.outHospCode = outHospCode;
		this.yoyangName = yoyangName;
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
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public Date getInputDate() {
		return inputDate;
	}
	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public Date getReserDate() {
		return reserDate;
	}
	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}
	public Double getPksch0201() {
		return pksch0201;
	}
	public void setPksch0201(Double pksch0201) {
		this.pksch0201 = pksch0201;
	}

	public String getOutHospCode() {
		return outHospCode;
	}

	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}

	public String getYoyangName() {
		return yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
}