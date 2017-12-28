package nta.med.ext.mss.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-HoanPC
 */
public class ReservationCodeModel {
	
	@JsonProperty("reservation_codes")
    private List<String> reservationCodes;

    @JsonProperty("hospital_id")
    private String hospitalId;

	public List<String> getReservationCodes() {
		return reservationCodes;
	}

	public void setReservationCodes(List<String> reservationCodes) {
		this.reservationCodes = reservationCodes;
	}

	public String getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(String hospitalId) {
		this.hospitalId = hospitalId;
	}
    
}
