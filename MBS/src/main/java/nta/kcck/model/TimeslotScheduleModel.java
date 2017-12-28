package nta.kcck.model;

import java.util.*;
import java.util.List;

public class TimeslotScheduleModel {
	private List<String> timeslots;
	private Map<String, List<KcckBookingSlotModel>> schedule;
	private String avgTime;

	public TimeslotScheduleModel(){
		this.timeslots = new ArrayList<>();
		this.schedule = new HashMap<String, List<KcckBookingSlotModel>>();
	};

	public TimeslotScheduleModel(List<String> timeslots, Map<String, List<KcckBookingSlotModel>> schedule, String avgTime) {
		this.timeslots = timeslots;
		this.schedule = schedule;
		this.avgTime = avgTime;
	}

	public List<String> getTimeslots() {
		return timeslots;
	}

	public void setTimeslots(List<String> timeslots) {
		this.timeslots = timeslots;
	}

	public Map<String, List<KcckBookingSlotModel>> getSchedule() {
		return schedule;
	}

	public void setSchedule(Map<String, List<KcckBookingSlotModel>> schedule) {
		this.schedule = schedule;
	}

	public String getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(String avgTime) {
		this.avgTime = avgTime;
	}
}
