package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class AccountClinicModel {

	//@JsonIgnore
	@JsonProperty("account_clinic_id")
	private Long id;

	@JsonProperty("hosp_code")
	//@JsonIgnore
	private String hospCode;

	//@JsonIgnore
	@JsonProperty("hosp_name")
	private String hospName;

	//@JsonIgnore
	@JsonProperty("patient_code")
	private String patientCode;

	@JsonIgnore
	//@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("user_name")
	private String username;

	@JsonProperty("password")
	private String password;
	
	@JsonProperty("active_clinic_account_flg")
	private Integer activeClinicAccountFlg;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospName() {
		return hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Integer getActiveClinicAccountFlg() {
		return activeClinicAccountFlg;
	}

	public void setActiveClinicAccountFlg(Integer activeClinicAccountFlg) {
		this.activeClinicAccountFlg = activeClinicAccountFlg;
	}
}
