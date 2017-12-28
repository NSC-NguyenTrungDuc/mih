package nta.med.data.model.ihis.nuro;

public class NuroRES0102U00UpdateRES0103Info {
	private String userId;
    private String doctor;
    private String amStartHhmm;
    private String pmStartHhmm;
    private String remark;
    private String jinryoPreDate;
    private String amEndHhmm;
    private String pmEndHhmm;
    private String amGwaRoom;
    private String pmGwaRoom;
    
	public NuroRES0102U00UpdateRES0103Info(String userId, String doctor,
			String amStartHhmm, String pmStartHhmm, String remark,
			String jinryoPreDate, String amEndHhmm, String pmEndHhmm,
			String amGwaRoom, String pmGwaRoom) {
		super();
		this.userId = userId;
		this.doctor = doctor;
		this.amStartHhmm = amStartHhmm;
		this.pmStartHhmm = pmStartHhmm;
		this.remark = remark;
		this.jinryoPreDate = jinryoPreDate;
		this.amEndHhmm = amEndHhmm;
		this.pmEndHhmm = pmEndHhmm;
		this.amGwaRoom = amGwaRoom;
		this.pmGwaRoom = pmGwaRoom;
	}
	public String getUserId() {
		return userId;
	}
	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getAmStartHhmm() {
		return amStartHhmm;
	}
	public void setAmStartHhmm(String amStartHhmm) {
		this.amStartHhmm = amStartHhmm;
	}
	public String getPmStartHhmm() {
		return pmStartHhmm;
	}
	public void setPmStartHhmm(String pmStartHhmm) {
		this.pmStartHhmm = pmStartHhmm;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getJinryoPreDate() {
		return jinryoPreDate;
	}
	public void setJinryoPreDate(String jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}
	public String getAmEndHhmm() {
		return amEndHhmm;
	}
	public void setAmEndHhmm(String amEndHhmm) {
		this.amEndHhmm = amEndHhmm;
	}
	public String getPmEndHhmm() {
		return pmEndHhmm;
	}
	public void setPmEndHhmm(String pmEndHhmm) {
		this.pmEndHhmm = pmEndHhmm;
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
