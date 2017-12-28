package nta.med.core.domain.phr;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_BABY_GROWTH database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_GROWTH")
@NamedQuery(name = "PhrBabyGrowth.findAll", query = "SELECT p FROM PhrBabyGrowth p")
public class PhrBabyGrowth extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "DOCTOR_NOTE")
	private String doctorNote;

	@Column(name = "HEAD_SIZE")
	private String headSize;

	private String height;

	@Column(name = "MEDICAL_RECORD_URL")
	private String medicalRecordUrl;

	@Column(name = "PARENT_NOTE")
	private String parentNote;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_MEASURE")
	private Timestamp timeMeasure;

	@Column(name = "UPD_ID")
	private String updId;

	private String weight;

	public PhrBabyGrowth() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getDoctorNote() {
		return this.doctorNote;
	}

	public void setDoctorNote(String doctorNote) {
		this.doctorNote = doctorNote;
	}

	public String getHeadSize() {
		return this.headSize;
	}

	public void setHeadSize(String headSize) {
		this.headSize = headSize;
	}

	public String getHeight() {
		return this.height;
	}

	public void setHeight(String height) {
		this.height = height;
	}

	public String getMedicalRecordUrl() {
		return this.medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getParentNote() {
		return this.parentNote;
	}

	public void setParentNote(String parentNote) {
		this.parentNote = parentNote;
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

	public Timestamp getTimeMeasure() {
		return this.timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

	@Override
	public Timestamp getTimestamp() {
		return timeMeasure;
	}
}