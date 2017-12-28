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
 * The persistent class for the PHR_MEDICINE database table.
 * 
 */
@Entity
@Table(name = "PHR_MEDICINE")
@NamedQuery(name = "PhrMedicine.findAll", query = "SELECT p FROM PhrMedicine p")
public class PhrMedicine extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private BigDecimal alert;

	private BigDecimal dose;

	private String method;

	private String name;

	private String note;

	@Column(name = "PRESCRIPTION_URL")
	private String prescriptionUrl;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	private BigDecimal quantity;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_TAKE_MEDICINE")
	private Timestamp timeTakeMedicine;

	private String unit;

	@Column(name = "UPD_ID")
	private String updId;
	
	@Column(name = "PRESCRIPTION_ID")
	private Long prescriptionId;
	
	@Column(name = "FREQUENCY")
	private BigDecimal frequency;

	@Column(name="SYNC_ID")
	private BigInteger syncId;
	
	public PhrMedicine() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return this.alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public BigDecimal getDose() {
		return this.dose;
	}

	public void setDose(BigDecimal dose) {
		this.dose = dose;
	}

	public String getMethod() {
		return this.method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getPrescriptionUrl() {
		return this.prescriptionUrl;
	}

	public void setPrescriptionUrl(String prescriptionUrl) {
		this.prescriptionUrl = prescriptionUrl;
	}

	public Long getProfileId() {
		return this.profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public BigDecimal getQuantity() {
		return this.quantity;
	}

	public void setQuantity(BigDecimal quantity) {
		this.quantity = quantity;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Timestamp getTimeTakeMedicine() {
		return this.timeTakeMedicine;
	}

	public void setTimeTakeMedicine(Timestamp timeTakeMedicine) {
		this.timeTakeMedicine = timeTakeMedicine;
	}

	public String getUnit() {
		return this.unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Override
	public Timestamp getTimestamp() {
		return timeTakeMedicine;
	}

	public Long getPrescriptionId() {
		return prescriptionId;
	}

	public void setPrescriptionId(Long prescriptionId) {
		this.prescriptionId = prescriptionId;
	}

	public BigDecimal getFrequency() {
		return frequency;
	}

	public void setFrequency(BigDecimal frequency) {
		this.frequency = frequency;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}
}