package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import javax.validation.constraints.NotNull;

public class VaccineBookingModel {

	@JsonProperty("hosp_code")
	@NotNull
	private String hospCode;

	@JsonProperty("department_code")
	@NotNull
	private String departmentCode;

	@JsonProperty("department_name")
	private String departmentName;
	
	@JsonProperty("doctor_code")
	@NotNull
	private String doctorCode;

	@JsonProperty("doctor_name")
	private String doctorName;
	
	@JsonProperty("patient_code")
	@NotNull
	private String patientCode;

	@JsonProperty("vaccine_code")
	@NotNull
	private String vaccineCode;

	@JsonProperty("reservation_date")
	@NotNull
	private String reservationDate;

	@JsonProperty("reservation_time")
	@NotNull
	private String reservationTime;

	@JsonProperty("locale")
	@NotNull
	private String locale;

	@JsonProperty("uid_type")
	@NotNull
	private String uidType;

	@JsonProperty("reservation_code")
	@NotNull
	private String reservationCode;

	@JsonProperty("booking_vaccine_code")
	@NotNull
	private String bookingVaccineCode;

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

	public String getVaccineCode() {
		return vaccineCode;
	}

	public void setVaccineCode(String vaccineCode) {
		this.vaccineCode = vaccineCode;
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

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getUidType() {
		return uidType;
	}

	public void setUidType(String uidType) {
		this.uidType = uidType;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public String getBookingVaccineCode() {
		return bookingVaccineCode;
	}

	public void setBookingVaccineCode(String bookingVaccineCode) {
		this.bookingVaccineCode = bookingVaccineCode;
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

}
