package nta.med.data.model.ihis.nuro;

import com.fasterxml.jackson.annotation.JsonProperty;

public class KCCKGetEnableBookDoctorInfo {

	@JsonProperty("doctor_code")
	private String doctorCode;

	@JsonProperty("start_time")
	private String startTime;

	@JsonProperty("end_time")
	private String endTime;

	public KCCKGetEnableBookDoctorInfo() {

	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}
}
