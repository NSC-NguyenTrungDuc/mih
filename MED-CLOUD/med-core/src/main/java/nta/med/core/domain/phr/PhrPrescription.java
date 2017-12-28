package nta.med.core.domain.phr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;


/**
 * The persistent class for the phr_prescription database table.
 * 
 */
@Entity
@Table(name="PHR_PRESCRIPTION")
@NamedQuery(name="PhrPrescription.findAll", query="SELECT p FROM PhrPrescription p")
public class PhrPrescription implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private Timestamp created;

	@Column(name="DATETIME_RECORD")
	private Timestamp datetimeRecord;

	private String note;

	@Column(name="PRESCRIPTION_NAME")
	private String prescriptionName;

	@Column(name="PROFILE_ID")
	private Long profileId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;
	
	@Column(name="SYNC_ID")
	private BigInteger syncId;
	
	@Column(name="SOURCE")
	private String source;

	private Timestamp updated;

	public PhrPrescription() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public Timestamp getDatetimeRecord() {
		return this.datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getPrescriptionName() {
		return this.prescriptionName;
	}

	public void setPrescriptionName(String prescriptionName) {
		this.prescriptionName = prescriptionName;
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

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}
}