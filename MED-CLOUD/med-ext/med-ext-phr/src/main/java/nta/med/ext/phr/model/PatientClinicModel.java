package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PatientClinicModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("hosp_code")
	private String hospCode;

	@JsonProperty("hosp_name")
	private String hospName;

	@JsonProperty("patient_code")
	private String patientCode;

	@JsonProperty("active_clinic_account_flg")
	private Integer activeClinicAccountFlg;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
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

	public Integer getActiveClinicAccountFlg() {
		return activeClinicAccountFlg;
	}

	public void setActiveClinicAccountFlg(Integer activeClinicAccountFlg) {
		this.activeClinicAccountFlg = activeClinicAccountFlg;
	}

}
