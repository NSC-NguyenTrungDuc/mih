package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import javax.validation.constraints.NotNull;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class CancelBookingModel {

	// BEGIN REQUEST MODEL
	@JsonProperty("hosp_code")
	@NotNull
	private String hospCode; // string required
	
	@JsonProperty("patient_code")
	@NotNull
	private String patientCode; // string required
	
	@JsonProperty("locale")
	private String locale; // string
	
	@JsonProperty("reservation_code")
	@NotNull
	private String reservationCode; // 980 (pkout1001)
	
	@JsonIgnore
	private boolean result;
	
	@JsonIgnore
	private String error;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public boolean isResult() {
		return result;
	}

	public void setResult(boolean result) {
		this.result = result;
	}

	public String getError() {
		return error;
	}

	public void setError(String error) {
		this.error = error;
	}

	@Override
	public String toString() {
		return "CancelBookingModel [hospCode=" + hospCode + ", patientCode=" + patientCode + ", locale=" + locale
				+ ", reservationCode=" + reservationCode + ", result=" + result + ", error=" + error + "]";
	}
}
