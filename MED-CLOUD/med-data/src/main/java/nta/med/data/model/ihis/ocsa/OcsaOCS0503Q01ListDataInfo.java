package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OcsaOCS0503Q01ListDataInfo {
	private String ioGubun;
	private String bunho;
	private Date reqDate;
	private Date jinryoPreDate;
	private String reqGwa;
	private String reqDoctor;
	private Date appDate;
	private String consultGwa;
	private String consultDoctor;
	private String reqGwaName;
	private String reqDoctorName;
	private String consultGwaName;
	private String consultDoctorName;

	public OcsaOCS0503Q01ListDataInfo(String ioGubun, String bunho,
			Date reqDate, Date jinryoPreDate, String reqGwa, String reqDoctor,
			Date appDate, String consultGwa, String consultDoctor,
			String reqGwaName, String reqDoctorName, String consultGwaName,
			String consultDoctorName) {
		super();
		this.ioGubun = ioGubun;
		this.bunho = bunho;
		this.reqDate = reqDate;
		this.jinryoPreDate = jinryoPreDate;
		this.reqGwa = reqGwa;
		this.reqDoctor = reqDoctor;
		this.appDate = appDate;
		this.consultGwa = consultGwa;
		this.consultDoctor = consultDoctor;
		this.reqGwaName = reqGwaName;
		this.reqDoctorName = reqDoctorName;
		this.consultGwaName = consultGwaName;
		this.consultDoctorName = consultDoctorName;
	}

	public String getIoGubun() {
		return ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Date getReqDate() {
		return reqDate;
	}

	public void setReqDate(Date reqDate) {
		this.reqDate = reqDate;
	}

	public Date getJinryoPreDate() {
		return jinryoPreDate;
	}

	public void setJinryoPreDate(Date jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}

	public String getReqGwa() {
		return reqGwa;
	}

	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}

	public String getReqDoctor() {
		return reqDoctor;
	}

	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}

	public Date getAppDate() {
		return appDate;
	}

	public void setAppDate(Date appDate) {
		this.appDate = appDate;
	}

	public String getConsultGwa() {
		return consultGwa;
	}

	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}

	public String getConsultDoctor() {
		return consultDoctor;
	}

	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}

	public String getReqGwaName() {
		return reqGwaName;
	}

	public void setReqGwaName(String reqGwaName) {
		this.reqGwaName = reqGwaName;
	}

	public String getReqDoctorName() {
		return reqDoctorName;
	}

	public void setReqDoctorName(String reqDoctorName) {
		this.reqDoctorName = reqDoctorName;
	}

	public String getConsultGwaName() {
		return consultGwaName;
	}

	public void setConsultGwaName(String consultGwaName) {
		this.consultGwaName = consultGwaName;
	}

	public String getConsultDoctorName() {
		return consultDoctorName;
	}

	public void setConsultDoctorName(String consultDoctorName) {
		this.consultDoctorName = consultDoctorName;
	}

}