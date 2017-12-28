package nta.med.data.model.mss;

/**
 * The Class ReservationOnlineInfo.
 */
public class ReservationOnlineInfo {
	
	private Integer reservation_id;   
	private String reservation_code;
	private String mt_calling_id;
	private Integer patient_id;
	private Integer hospital_id;
	private Integer dept_id;
	private Integer doctor_id;
	
	public ReservationOnlineInfo(Integer reservation_id, String reservation_code, String mt_calling_id,
			Integer patient_id, Integer hospital_id, Integer dept_id, Integer doctor_id) {
		super();
		this.reservation_id = reservation_id;
		this.reservation_code = reservation_code;
		this.mt_calling_id = mt_calling_id;
		this.patient_id = patient_id;
		this.hospital_id = hospital_id;
		this.dept_id = dept_id;
		this.doctor_id = doctor_id;
	}

	public Integer getReservation_id() {
		return reservation_id;
	}
	public void setReservation_id(Integer reservation_id) {
		this.reservation_id = reservation_id;
	}
	public String getReservation_code() {
		return reservation_code;
	}
	public void setReservation_code(String reservation_code) {
		this.reservation_code = reservation_code;
	}
	public String getMt_calling_id() {
		return mt_calling_id;
	}
	public void setMt_calling_id(String mt_calling_id) {
		this.mt_calling_id = mt_calling_id;
	}
	public Integer getPatient_id() {
		return patient_id;
	}
	public void setPatient_id(Integer patient_id) {
		this.patient_id = patient_id;
	}
	public Integer getHospital_id() {
		return hospital_id;
	}
	public void setHospital_id(Integer hospital_id) {
		this.hospital_id = hospital_id;
	}
	public Integer getDept_id() {
		return dept_id;
	}
	public void setDept_id(Integer dept_id) {
		this.dept_id = dept_id;
	}
	public Integer getDoctor_id() {
		return doctor_id;
	}
	public void setDoctor_id(Integer doctor_id) {
		this.doctor_id = doctor_id;
	}
}

