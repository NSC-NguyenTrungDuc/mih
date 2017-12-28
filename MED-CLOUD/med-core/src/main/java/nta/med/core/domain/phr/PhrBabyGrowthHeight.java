package nta.med.core.domain.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;


/**
 * The persistent class for the phr_baby_growth_height database table.
 * 
 */
@Entity
@Table(name="PHR_BABY_GROWTH_HEIGHT")
@NamedQuery(name="PhrBabyGrowthHeight.findAll", query="SELECT p FROM PhrBabyGrowthHeight p")
public class PhrBabyGrowthHeight extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="DOCTOR_NOTE")
	private String doctorNote;

	private BigDecimal height;

	@Column(name="MEDICAL_RECORD_URL")
	private String medicalRecordUrl;

	@Column(name="PARENT_NOTE")
	private String parentNote;

	@Column(name="PROFILE_ID")
	private Long profileId;

	private String source;

	@Column(name="SYNC_ID")
	private BigInteger syncId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="TIME_MEASURE")
	private Timestamp timeMeasure;

	@Column(name="UPD_ID")
	private String updId;

	public PhrBabyGrowthHeight() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getDoctorNote() {
		return doctorNote;
	}

	public void setDoctorNote(String doctorNote) {
		this.doctorNote = doctorNote;
	}

	public BigDecimal getHeight() {
		return height;
	}

	public void setHeight(BigDecimal height) {
		this.height = height;
	}

	public String getMedicalRecordUrl() {
		return medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getParentNote() {
		return parentNote;
	}

	public void setParentNote(String parentNote) {
		this.parentNote = parentNote;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Timestamp getTimeMeasure() {
		return timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}
	
	@Override
	public Timestamp getTimestamp() {
		return timeMeasure;
	}
}