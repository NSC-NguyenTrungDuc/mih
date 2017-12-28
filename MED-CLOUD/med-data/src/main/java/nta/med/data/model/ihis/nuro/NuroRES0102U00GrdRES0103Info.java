package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroRES0102U00GrdRES0103Info {
	private String doctor;
	private Date jinryoPreDate;
	private String amStartHhmm;
	private String amEndHhmm;
	private String pmStartHhmm;
	private String pmEndHhmm;
	private String remark;
	private String amGwaRoom;
	private String pmGwaRoom;
	public NuroRES0102U00GrdRES0103Info(String doctor, Date jinryoPreDate,
			String amStartHhmm, String amEndHhmm, String pmStartHhmm,
			String pmEndHhmm, String remark, String amGwaRoom, String pmGwaRoom) {
		super();
		this.doctor = doctor;
		this.jinryoPreDate = jinryoPreDate;
		this.amStartHhmm = amStartHhmm;
		this.amEndHhmm = amEndHhmm;
		this.pmStartHhmm = pmStartHhmm;
		this.pmEndHhmm = pmEndHhmm;
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
	public String getAmStartHhmm() {
		return amStartHhmm;
	}
	public void setAmStartHhmm(String amStartHhmm) {
		this.amStartHhmm = amStartHhmm;
	}
	public String getAmEndHhmm() {
		return amEndHhmm;
	}
	public void setAmEndHhmm(String amEndHhmm) {
		this.amEndHhmm = amEndHhmm;
	}
	public String getPmStartHhmm() {
		return pmStartHhmm;
	}
	public void setPmStartHhmm(String pmStartHhmm) {
		this.pmStartHhmm = pmStartHhmm;
	}
	public String getPmEndHhmm() {
		return pmEndHhmm;
	}
	public void setPmEndHhmm(String pmEndHhmm) {
		this.pmEndHhmm = pmEndHhmm;
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
