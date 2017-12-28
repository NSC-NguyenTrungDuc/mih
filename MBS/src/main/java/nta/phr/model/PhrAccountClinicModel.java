package nta.phr.model;

public class PhrAccountClinicModel {

	private Long master_profile_id;	

	private String hosp_code;

	private String hosp_name;

	private String patient_code;

	private String baby_udid;

	public Long getMaster_profile_id() {
		return master_profile_id;
	}

	public void setMaster_profile_id(Long master_profile_id) {
		this.master_profile_id = master_profile_id;
	}

	public String getHosp_code() {
		return hosp_code;
	}

	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}

	public String getHosp_name() {
		return hosp_name;
	}

	public void setHosp_name(String hosp_name) {
		this.hosp_name = hosp_name;
	}

	public String getPatient_code() {
		return patient_code;
	}

	public void setPatient_code(String patient_code) {
		this.patient_code = patient_code;
	}

	public String getBaby_udid() {
		return baby_udid;
	}

	public void setBaby_udid(String baby_udid) {
		this.baby_udid = baby_udid;
	}
	
	
}
