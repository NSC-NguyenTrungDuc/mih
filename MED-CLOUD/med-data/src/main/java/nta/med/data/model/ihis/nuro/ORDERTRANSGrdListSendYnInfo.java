package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORDERTRANSGrdListSendYnInfo {
	private Double fkout1001;
	private String bunho;
	private String suname;
	private Date actingDate;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String gubun;
	private String gubunName;
	private String orderByKey;
	private Double pkout1001;

	public ORDERTRANSGrdListSendYnInfo(Double fkout1001, String bunho, String suname, Date actingDate, String gwa,
			String gwaName, String doctor, String doctorName, String gubun, String gubunName, String orderByKey,
			Double pkout1001) {
		super();
		this.fkout1001 = fkout1001;
		this.bunho = bunho;
		this.suname = suname;
		this.actingDate = actingDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.orderByKey = orderByKey;
		this.pkout1001 = pkout1001;
	}

	public Double getFkout1001() {
		return fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
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

	public Date getActingDate() {
		return actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
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

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getOrderByKey() {
		return orderByKey;
	}

	public void setOrderByKey(String orderByKey) {
		this.orderByKey = orderByKey;
	}

	public Double getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}

}
