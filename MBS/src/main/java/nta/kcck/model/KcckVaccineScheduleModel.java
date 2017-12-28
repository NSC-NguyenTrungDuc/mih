package nta.kcck.model;

import java.util.List;

public class KcckVaccineScheduleModel {
	private String start_time_hhmm;
	private String end_time_hhmm;
	private String avg_time;
	private List<KcckBookingSlot> enable_slot;

	public String getStart_time_hhmm() {
		return start_time_hhmm;
	}

	public void setStart_time_hhmm(String start_time_hhmm) {
		this.start_time_hhmm = start_time_hhmm;
	}

	public String getEnd_time_hhmm() {
		return end_time_hhmm;
	}

	public void setEnd_time_hhmm(String end_time_hhmm) {
		this.end_time_hhmm = end_time_hhmm;
	}

	public String getAvg_time() {
		return avg_time;
	}

	public void setAvg_time(String avg_time) {
		this.avg_time = avg_time;
	}

	public List<KcckBookingSlot> getEnable_slot() {
		return enable_slot;
	}

	public void setEnable_slot(List<KcckBookingSlot> enable_slot) {
		this.enable_slot = enable_slot;
	}

}
