package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10OrderInfoCaseOcsInfo {
	private String userNmPickup;
	private Date nursePickupDate;
	private String pickupTime;
	private Date nurseConfirmDate;
	private String nurseConfirmTime;
	private String actingDate;
	private String actingTime;
	public OCS6010U10OrderInfoCaseOcsInfo(String userNmPickup, Date nursePickupDate, String pickupTime,
			Date nurseConfirmDate, String nurseConfirmTime, String actingDate, String actingTime) {
		super();
		this.userNmPickup = userNmPickup;
		this.nursePickupDate = nursePickupDate;
		this.pickupTime = pickupTime;
		this.nurseConfirmDate = nurseConfirmDate;
		this.nurseConfirmTime = nurseConfirmTime;
		this.actingDate = actingDate;
		this.actingTime = actingTime;
	}
	public String getUserNmPickup() {
		return userNmPickup;
	}
	public void setUserNmPickup(String userNmPickup) {
		this.userNmPickup = userNmPickup;
	}
	public Date getNursePickupDate() {
		return nursePickupDate;
	}
	public void setNursePickupDate(Date nursePickupDate) {
		this.nursePickupDate = nursePickupDate;
	}
	public String getPickupTime() {
		return pickupTime;
	}
	public void setPickupTime(String pickupTime) {
		this.pickupTime = pickupTime;
	}
	public Date getNurseConfirmDate() {
		return nurseConfirmDate;
	}
	public void setNurseConfirmDate(Date nurseConfirmDate) {
		this.nurseConfirmDate = nurseConfirmDate;
	}
	public String getNurseConfirmTime() {
		return nurseConfirmTime;
	}
	public void setNurseConfirmTime(String nurseConfirmTime) {
		this.nurseConfirmTime = nurseConfirmTime;
	}
	public String getActingDate() {
		return actingDate;
	}
	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}
	public String getActingTime() {
		return actingTime;
	}
	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}
	
}
