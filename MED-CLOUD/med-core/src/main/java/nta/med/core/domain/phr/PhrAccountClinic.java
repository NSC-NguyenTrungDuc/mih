package nta.med.core.domain.phr;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_ACCOUNT_CLINIC database table.
 * 
 */
@Entity
@Table(name = "PHR_ACCOUNT_CLINIC")
@NamedQuery(name = "PhrAccountClinic.findAll", query = "SELECT p FROM PhrAccountClinic p")
public class PhrAccountClinic extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "HOSP_CODE")
	private String hospCode;

	@Column(name = "HOSP_NAME")
	private String hospName;

	@Column(name = "PATIENT_CODE")
	private String patientCode;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "ACTIVE_CLINIC_ACCOUNT_FLG")
	private Integer activeClinicAccountFlg;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	private String username;

	public PhrAccountClinic() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getHospName() {
		return this.hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}

	public String getPatientCode() {
		return this.patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public Long getProfileId() {
		return this.profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getUsername() {
		return this.username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public Integer getActiveClinicAccountFlg() {
		return activeClinicAccountFlg;
	}

	public void setActiveClinicAccountFlg(Integer activeClinicAccountFlg) {
		this.activeClinicAccountFlg = activeClinicAccountFlg;
	}

}