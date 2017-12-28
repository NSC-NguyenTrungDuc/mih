package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10OrderInfoCaseDfltInfo {
	private Date actDate ;
    private String actId ;
    private Double suryang ;
    private String startTime ;
    private Date endDate ;
    private String endTime ;
    private String userNmAct ;
    private String hangmogName ;
    private String actTime ;
    private String totalMinute;
	public OCS6010U10OrderInfoCaseDfltInfo(Date actDate, String actId, Double suryang, String startTime, Date endDate,
			String endTime, String userNmAct, String hangmogName, String actTime, String totalMinute) {
		super();
		this.actDate = actDate;
		this.actId = actId;
		this.suryang = suryang;
		this.startTime = startTime;
		this.endDate = endDate;
		this.endTime = endTime;
		this.userNmAct = userNmAct;
		this.hangmogName = hangmogName;
		this.actTime = actTime;
		this.totalMinute = totalMinute;
	}
	public Date getActDate() {
		return actDate;
	}
	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}
	public String getActId() {
		return actId;
	}
	public void setActId(String actId) {
		this.actId = actId;
	}
	public Double getSuryang() {
		return suryang;
	}
	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}
	public String getStartTime() {
		return startTime;
	}
	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getEndTime() {
		return endTime;
	}
	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}
	public String getUserNmAct() {
		return userNmAct;
	}
	public void setUserNmAct(String userNmAct) {
		this.userNmAct = userNmAct;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getActTime() {
		return actTime;
	}
	public void setActTime(String actTime) {
		this.actTime = actTime;
	}
	public String getTotalMinute() {
		return totalMinute;
	}
	public void setTotalMinute(String totalMinute) {
		this.totalMinute = totalMinute;
	}
	  
}
