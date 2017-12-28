package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;

public class BookinglabSchedule {

	@JsonProperty("start_time_hhmm")
	private String startTimeHhmm;

	@JsonProperty("end_time_hhmm")
	private String endTimeHhmm;
	
	@JsonProperty("avg_time")
	private Integer avgTime;

	@JsonProperty("enable_slot")
	private List<EnableSlot> enableSlotList;

	public String getStartTimeHhmm() {
		return startTimeHhmm;
	}

	public void setStartTimeHhmm(String startTimeHhmm) {
		this.startTimeHhmm = startTimeHhmm;
	}

	public String getEndTimeHhmm() {
		return endTimeHhmm;
	}

	public void setEndTimeHhmm(String endTimeHhmm) {
		this.endTimeHhmm = endTimeHhmm;
	}

	public List<EnableSlot> getEnableSlotList() {
		return enableSlotList;
	}

	public void setEnableSlotList(List<EnableSlot> enableSlotList) {
		this.enableSlotList = enableSlotList;
	}
	
	public Integer getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(Integer avgTime) {
		this.avgTime = avgTime;
	}

	public void fData(){
		//this.enableSlotList = enableSlotList;
		EnableSlot e1 = new EnableSlot();
		e1.setEnableDateSlot("20160310");
		e1.setEnableTimeSlot("0900");
		
		EnableSlot e2 = new EnableSlot();
		e2.setEnableDateSlot("20160410");
		e2.setEnableTimeSlot("1000");
		
		List<EnableSlot> lst = new ArrayList<EnableSlot>();
		lst.add(e1);
		lst.add(e2);
		
		this.setEnableSlotList(lst);
	}
	
}

class EnableSlot {

	@JsonProperty("enable_date_slot")
	private String enableDateSlot;

	@JsonProperty("enable_time_slot")
	private String enableTimeSlot;

	public String getEnableDateSlot() {
		return enableDateSlot;
	}

	public void setEnableDateSlot(String enableDateSlot) {
		this.enableDateSlot = enableDateSlot;
	}

	public String getEnableTimeSlot() {
		return enableTimeSlot;
	}

	public void setEnableTimeSlot(String enableTimeSlot) {
		this.enableTimeSlot = enableTimeSlot;
	}

}
