package nta.med.core.domain.phr;

import java.math.BigInteger;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_STANDARD_DISEASES database table.
 * 
 */
@Entity
@Table(name = "PHR_STANDARD_DISEASES")
@NamedQuery(name = "PhrStandardDiseas.findAll", query = "SELECT p FROM PhrStandardDiseas p")
public class PhrStandardDiseas extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "DATETIME_RECORD")
	private Timestamp datetimeRecord;

	private String hospital;

	@Column(name = "MEDICAL_RECORD_URL")
	private String medicalRecordUrl;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "DISEASE_NAME")
	private String status;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;
	
	@Column(name = "DISEASE_START_DATE")
	private Date diseaseStartDate;
	
	@Column(name = "DISEASE_END_DATE")
	private Date diseaseEndDate;
	
	@Column(name = "DISEASE_OUTCOME")
	private String diseaseOutcome;
	
	@Column(name = "SYNC_ID")
	private BigInteger syncId;		

	public PhrStandardDiseas() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getDatetimeRecord() {
		return this.datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public String getHospital() {
		return this.hospital;
	}

	public void setHospital(String hospital) {
		this.hospital = hospital;
	}

	public String getMedicalRecordUrl() {
		return this.medicalRecordUrl;
	}

	public void setMedicalRecordUrl(String medicalRecordUrl) {
		this.medicalRecordUrl = medicalRecordUrl;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return this.profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getStatus() {
		return this.status;
	}

	public void setStatus(String status) {
		this.status = status;
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

	public Date getDiseaseStartDate() {
		return diseaseStartDate;
	}

	public void setDiseaseStartDate(Date diseaseStartDate) {
		this.diseaseStartDate = diseaseStartDate;
	}

	public Date getDiseaseEndDate() {
		return diseaseEndDate;
	}

	public void setDiseaseEndDate(Date diseaseEndDate) {
		this.diseaseEndDate = diseaseEndDate;
	}

	public String getDiseaseOutcome() {
		return diseaseOutcome;
	}

	public void setDiseaseOutcome(String diseaseOutcome) {
		this.diseaseOutcome = diseaseOutcome;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}
}