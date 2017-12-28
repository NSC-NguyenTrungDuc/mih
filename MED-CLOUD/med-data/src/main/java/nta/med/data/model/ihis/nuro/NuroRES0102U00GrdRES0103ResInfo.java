package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroRES0102U00GrdRES0103ResInfo {
	private String doctor;
    private Date jinryoPreDate;
    private String resAmStartHhmm;
    private String resAmEndHhmm;
    private String resPmStartHhmm;
    private String resPmEndHhmm;
    private String remark;
    private String amGwaRoom;
    private String pmGwaRoom;
	public NuroRES0102U00GrdRES0103ResInfo(String doctor, Date jinryoPreDate,
			String resAmStartHhmm, String resAmEndHhmm, String resPmStartHhmm,
			String resPmEndHhmm, String remark, String amGwaRoom,
			String pmGwaRoom) {
		super();
		this.doctor = doctor;
		this.jinryoPreDate = jinryoPreDate;
		this.resAmStartHhmm = resAmStartHhmm;
		this.resAmEndHhmm = resAmEndHhmm;
		this.resPmStartHhmm = resPmStartHhmm;
		this.resPmEndHhmm = resPmEndHhmm;
		this.remark = remark;
		this.amGwaRoom = amGwaRoom;
		this.pmGwaRoom = pmGwaRoom;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public Date getJinryoPreDate() {
		return jinryoPreDate;
	}
	public void setJinryoPreDate(Date jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}
	public String getResAmStartHhmm() {
		return resAmStartHhmm;
	}
	public void setResAmStartHhmm(String resAmStartHhmm) {
		this.resAmStartHhmm = resAmStartHhmm;
	}
	public String getResAmEndHhmm() {
		return resAmEndHhmm;
	}
	public void setResAmEndHhmm(String resAmEndHhmm) {
		this.resAmEndHhmm = resAmEndHhmm;
	}
	public String getResPmStartHhmm() {
		return resPmStartHhmm;
	}
	public void setResPmStartHhmm(String resPmStartHhmm) {
		this.resPmStartHhmm = resPmStartHhmm;
	}
	public String getResPmEndHhmm() {
		return resPmEndHhmm;
	}
	public void setResPmEndHhmm(String resPmEndHhmm) {
		this.resPmEndHhmm = resPmEndHhmm;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getAmGwaRoom() {
		return amGwaRoom;
	}
	public void setAmGwaRoom(String amGwaRoom) {
		this.amGwaRoom = amGwaRoom;
	}
	public String getPmGwaRoom() {
		return pmGwaRoom;
	}
	public void setPmGwaRoom(String pmGwaRoom) {
		this.pmGwaRoom = pmGwaRoom;
	}
    
}
