package nta.med.data.model.ihis.nuro;

public class KCCKGetLimitScheduleDoctorInfo {
	private String maxBookingSlot;
	private String maxBookingOther;
	private String maxBookingOutHos;
	public KCCKGetLimitScheduleDoctorInfo(String maxBookingSlot, String maxBookingOther, String maxBookingOutHos) {
		super();
		this.maxBookingSlot = maxBookingSlot;
		this.maxBookingOther = maxBookingOther;
		this.maxBookingOutHos = maxBookingOutHos;
	}
	public String getMaxBookingSlot() {
		return maxBookingSlot;
	}
	public void setMaxBookingSlot(String maxBookingSlot) {
		this.maxBookingSlot = maxBookingSlot;
	}
	public String getMaxBookingOther() {
		return maxBookingOther;
	}
	public void setMaxBookingOther(String maxBookingOther) {
		this.maxBookingOther = maxBookingOther;
	}
	public String getMaxBookingOutHos() {
		return maxBookingOutHos;
	}
	public void setMaxBookingOutHos(String maxBookingOutHos) {
		this.maxBookingOutHos = maxBookingOutHos;
	}
}
