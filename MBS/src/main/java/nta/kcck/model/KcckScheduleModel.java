package nta.kcck.model;

import java.util.List;

public class KcckScheduleModel {
	private String res_am_start_hhmm;
	private String res_am_end_hhmm;
	private String res_pm_start_hhmm;
	private String res_pm_end_hhmm;
	private String avg_time;
	private List<KcckTimeSlot> enable_slot;

	public String getRes_am_start_hhmm() {
		return res_am_start_hhmm;
	}

	public void setRes_am_start_hhmm(String res_am_start_hhmm) {
		this.res_am_start_hhmm = res_am_start_hhmm;
	}

	public String getRes_am_end_hhmm() {
		return res_am_end_hhmm;
	}

	public void setRes_am_end_hhmm(String res_am_end_hhmm) {
		this.res_am_end_hhmm = res_am_end_hhmm;
	}

	public String getRes_pm_start_hhmm() {
		return res_pm_start_hhmm;
	}

	public void setRes_pm_start_hhmm(String res_pm_start_hhmm) {
		this.res_pm_start_hhmm = res_pm_start_hhmm;
	}

	public String getRes_pm_end_hhmm() {
		return res_pm_end_hhmm;
	}

	public void setRes_pm_end_hhmm(String res_pm_end_hhmm) {
		this.res_pm_end_hhmm = res_pm_end_hhmm;
	}

	public String getAvg_time() {
		return avg_time;
	}

	public void setAvg_time(String avg_time) {
		this.avg_time = avg_time;
	}

	public List<KcckTimeSlot> getEnable_slot() {
		return enable_slot;
	}

	public void setEnable_slot(List<KcckTimeSlot> enable_slot) {
		this.enable_slot = enable_slot;
	}

}
