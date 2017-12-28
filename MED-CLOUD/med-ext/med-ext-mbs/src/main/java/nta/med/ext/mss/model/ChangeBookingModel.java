package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import javax.validation.constraints.NotNull;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class ChangeBookingModel {

	@JsonProperty("hosp_code")
	@NotNull
	private String hospCode; // string required
	
	@JsonProperty("department_code")
	@NotNull
	private String departmentCode; // required in back-end)
	
	@JsonProperty("doctor_code")
	@NotNull
	private String doctorCode; // required in back-end)
	
	@JsonProperty("patient_code")
	@NotNull
	private String patientCode; // string
	
	@JsonProperty("locale")
	private String locale; // string
	
	@JsonProperty("doctor_name")
	 private String doctorName; // "石川"
	 
	@JsonProperty("department_name")
	private String departmentName; // 内科"
	 
	@JsonProperty("reservation_code")
	@NotNull
	private String reservationCode; // 980 (pkout1001)
	 
	@JsonProperty("reservation_date")
	@NotNull
	private String reservationDate; // "20160310"
	
	@JsonProperty("reservation_time")
	@NotNull
	private String reservationTime; // "0900"
	
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

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
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

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public String getReservationDate() {
		return reservationDate;
	}

	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
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
		return "ChangeBookingModel [hospCode=" + hospCode + ", departmentCode=" + departmentCode + ", doctorCode="
				+ doctorCode + ", patientCode=" + patientCode + ", locale=" + locale + ", doctorName=" + doctorName
				+ ", departmentName=" + departmentName + ", reservationCode=" + reservationCode + ", reservationDate="
				+ reservationDate + ", reservationTime=" + reservationTime + ", result=" + result + ", error=" + error
				+ "]";
	}
}
