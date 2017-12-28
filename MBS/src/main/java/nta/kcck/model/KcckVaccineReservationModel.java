package nta.kcck.model;

public class KcckVaccineReservationModel {
	private String hosp_code;
	private String department_code;
	private String department_name;
	private String doctor_code;
	private String doctor_name;
	private String patient_code;
	private String vaccine_code;
	private String reservation_date;
	private String reservation_time;
	private String locale;
	private String uid_type;
	private String reservation_code;
	private String booking_vaccine_code;


	public String getBooking_vaccine_code() {
		return booking_vaccine_code;
	}
	public void setBooking_vaccine_code(String booking_vaccine_code) {
		this.booking_vaccine_code = booking_vaccine_code;
	}
	public String getVaccine_code() {
		return vaccine_code;
	}
	public void setVaccine_code(String vaccine_code) {
		this.vaccine_code = vaccine_code;
	}
	public String getUid_type() {
		return uid_type;
	}
	public void setUid_type(String uid_type) {
		this.uid_type = uid_type;
	}
	public String getHosp_code() {
		return hosp_code;
	}
	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}
	public String getDepartment_code() {
		return department_code;
	}
	public void setDepartment_code(String department_code) {
		this.department_code = department_code;
	}
	public String getDoctor_code() {
		return doctor_code;
	}
	public void setDoctor_code(String doctor_code) {
		this.doctor_code = doctor_code;
	}
	public String getReservation_date() {
		return reservation_date;
	}
	public void setReservation_date(String reservation_date) {
		this.reservation_date = reservation_date;
	}
	public String getReservation_time() {
		return reservation_time;
	}
	public void setReservation_time(String reservation_time) {
		this.reservation_time = reservation_time;
	}
	public String getPatient_code() {
		return patient_code;
	}
	public void setPatient_code(String patient_code) {
		this.patient_code = patient_code;
	}
	public String getLocale() {
		return locale;
	}
	public void setLocale(String locale) {
		this.locale = locale;
	}
	public String getDoctor_name() {
		return doctor_name;
	}
	public void setDoctor_name(String doctor_name) {
		this.doctor_name = doctor_name;
	}
	public String getDepartment_name() {
		return department_name;
	}
	public void setDepartment_name(String department_name) {
		this.department_name = department_name;
	}
	public String getReservation_code() {
		return reservation_code;
	}
	public void setReservation_code(String reservation_code) {
		this.reservation_code = reservation_code;
	}
	public KcckVaccineReservationModel(String hosp_code, String department_code, String doctor_code, String reservation_date,
									   String reservation_time, String patient_code, String locale,
									   String doctor_name, String department_name, String reservation_code, String vaccine_code, String booking_vaccine_code, String uid_type) {
		super();
		this.hosp_code = hosp_code;
		this.department_code = department_code;
		this.doctor_code = doctor_code;
		this.reservation_date = reservation_date;
		this.reservation_time = reservation_time;
		this.patient_code = patient_code;
		this.locale = locale;
		this.doctor_name = doctor_name;
		this.department_name = department_name;
		this.reservation_code = reservation_code;
		this.vaccine_code = vaccine_code;
		this.booking_vaccine_code = booking_vaccine_code;
		this.uid_type = uid_type;
	}
	public KcckVaccineReservationModel() {
	
	}
	 
}
