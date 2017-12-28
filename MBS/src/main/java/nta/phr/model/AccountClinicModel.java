
/**
 * @author TungLT
 */
package nta.phr.model;

public class AccountClinicModel {

	private Long account_clinic_id;

	private String hosp_code;

	private String hosp_name;

	private String patient_code;

	private String user_name;

	private String password;

	private Integer active_clinic_account_flg;

	public Long getAccount_clinic_id() {
		return account_clinic_id;
	}

	public void setAccount_clinic_id(Long account_clinic_id) {
		this.account_clinic_id = account_clinic_id;
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
	
	public String getUser_name() {
		return user_name;
	}

	public void setUser_name(String user_name) {
		this.user_name = user_name;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Integer getActive_clinic_account_flg() {
		return active_clinic_account_flg;
	}

	public void setActive_clinic_account_flg(Integer active_clinic_account_flg) {
		this.active_clinic_account_flg = active_clinic_account_flg;
	}


}
