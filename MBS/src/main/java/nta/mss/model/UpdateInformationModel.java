package nta.mss.model;

import java.io.Serializable;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.validation.Email;

/**
 * 
 * @author TungLT
 *
 */
public class UpdateInformationModel implements Serializable {

	private static final long serialVersionUID = 1682544182310808355L;

	@NotBlank
	@Email
	private String email;

	@NotBlank
	private String password;
	
	@NotBlank
	private String new_password;
	
	@NotBlank
	private String name;
	
	@NotBlank
	private String name_furigana;

	@NotBlank
	private String gender;
	
	@NotBlank
	private String phone_number;

	@NotBlank
	private Long master_profile_id;

	private String hosp_code;
	

	UpdateInformationModel() {
	}

	public UpdateInformationModel(String email, String password, String new_password, String name, String name_furigana,
			String gender, String phone_number, Long master_profile_id, String hosp_code) {
		super();
		this.email = email;
		this.password = password;
		this.new_password = new_password;
		this.name = name;
		this.name_furigana = name_furigana;
		this.gender = gender;
		this.phone_number = phone_number;
		this.master_profile_id = master_profile_id;
		this.hosp_code = hosp_code;
	}
	

	@Override
	public String toString() {
		return "UserChangePassModel [email=" + email + ", password=" + password + ", new_password=" + new_password
				+ "]";
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getNew_password() {
		return new_password;
	}

	public void setNew_password(String new_password) {
		this.new_password = new_password;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getName_furigana() {
		return name_furigana;
	}

	public void setName_furigana(String name_furigana) {
		this.name_furigana = name_furigana;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

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

	public String getPhone_number() {
		return phone_number;
	}

	public void setPhone_number(String phone_number) {
		this.phone_number = phone_number;
	}


}