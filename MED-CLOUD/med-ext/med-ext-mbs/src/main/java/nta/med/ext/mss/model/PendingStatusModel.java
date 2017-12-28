/**
 * 
 */
package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-HuanLT
 *
 */
public class PendingStatusModel {

	// current_time: hh:mm
	@JsonProperty("current_time")
	private String currentTime;
	
	// max_reservation_time: hh:mm
	@JsonProperty("max_reservation_time")
	private String maxReservationTime;

	public String getCurrentTime() {
		return currentTime;
	}

	public void setCurrentTime(String currentTime) {
		this.currentTime = currentTime;
	}

	public String getMaxReservationTime() {
		return maxReservationTime;
	}

	public void setMaxReservationTime(String maxReservationTime) {
		this.maxReservationTime = maxReservationTime;
	}
}
