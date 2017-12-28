package nta.med.data.model.ihis.nuro;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class KCCKGetEnableScheduleDoctorInfo {

	@JsonProperty("enable_date_slot")
	private String enableDateSlot;

	@JsonProperty("enable_time_slot")
	private String enableTimeSlot;

	@JsonProperty("enable_booking")
	private List<KCCKGetEnableBookDoctorInfo> enableBookingSlot;

	public KCCKGetEnableScheduleDoctorInfo() {

	}

	public KCCKGetEnableScheduleDoctorInfo(String enableDateSlot, String enableTimeSlot) {
		super();
		this.enableDateSlot = enableDateSlot;
		this.enableTimeSlot = enableTimeSlot;

	}

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

	public List<KCCKGetEnableBookDoctorInfo> getEnableBookingSlot() {
		return enableBookingSlot;
	}

	public void setEnableBookingSlot(List<KCCKGetEnableBookDoctorInfo> enableBookingSlot) {
		this.enableBookingSlot = enableBookingSlot;
	}
}
