package nta.med.data.model.ihis.nuro;

public class NuroRES1001U00ReservationScheduleConditionListItemInfo {
	private String amStartTime;
	private String amEndTime;
	private String pmStartTime;
	private String pmEndTime;
	
	public NuroRES1001U00ReservationScheduleConditionListItemInfo(
			String amStartTime, String amEndTime, String pmStartTime,
			String pmEndTime) {
		this.amStartTime = amStartTime;
		this.amEndTime = amEndTime;
		this.pmStartTime = pmStartTime;
		this.pmEndTime = pmEndTime;
	}

	public String getAmStartTime() {
		return amStartTime;
	}

	public void setAmStartTime(String amStartTime) {
		this.amStartTime = amStartTime;
	}

	public String getAmEndTime() {
		return amEndTime;
	}

	public void setAmEndTime(String amEndTime) {
		this.amEndTime = amEndTime;
	}

	public String getPmStartTime() {
		return pmStartTime;
	}

	public void setPmStartTime(String pmStartTime) {
		this.pmStartTime = pmStartTime;
	}

	public String getPmEndTime() {
		return pmEndTime;
	}

	public void setPmEndTime(String pmEndTime) {
		this.pmEndTime = pmEndTime;
	}
}
