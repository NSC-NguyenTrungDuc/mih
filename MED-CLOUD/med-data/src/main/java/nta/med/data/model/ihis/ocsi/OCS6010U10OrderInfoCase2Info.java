package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10OrderInfoCase2Info {
	private Double pkocs2016 ;
    private Double fkocs2015 ;
    private Date actDate ;
    private String timeGubun ;
    private String actTime ;
    private String suryang ;
    private Double bloodSugar ;
    private String userNmAct ;
	public OCS6010U10OrderInfoCase2Info(Double pkocs2016, Double fkocs2015, Date actDate, String timeGubun,
			String actTime, String suryang, Double bloodSugar, String userNmAct) {
		super();
		this.pkocs2016 = pkocs2016;
		this.fkocs2015 = fkocs2015;
		this.actDate = actDate;
		this.timeGubun = timeGubun;
		this.actTime = actTime;
		this.suryang = suryang;
		this.bloodSugar = bloodSugar;
		this.userNmAct = userNmAct;
	}
	public Double getPkocs2016() {
		return pkocs2016;
	}
	public void setPkocs2016(Double pkocs2016) {
		this.pkocs2016 = pkocs2016;
	}
	public Double getFkocs2015() {
		return fkocs2015;
	}
	public void setFkocs2015(Double fkocs2015) {
		this.fkocs2015 = fkocs2015;
	}
	public Date getActDate() {
		return actDate;
	}
	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}
	public String getTimeGubun() {
		return timeGubun;
	}
	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}
	public String getActTime() {
		return actTime;
	}
	public void setActTime(String actTime) {
		this.actTime = actTime;
	}
	public String getSuryang() {
		return suryang;
	}
	public void setSuryang(String suryang) {
		this.suryang = suryang;
	}
	public Double getBloodSugar() {
		return bloodSugar;
	}
	public void setBloodSugar(Double bloodSugar) {
		this.bloodSugar = bloodSugar;
	}
	public String getUserNmAct() {
		return userNmAct;
	}
	public void setUserNmAct(String userNmAct) {
		this.userNmAct = userNmAct;
	}
    
}
