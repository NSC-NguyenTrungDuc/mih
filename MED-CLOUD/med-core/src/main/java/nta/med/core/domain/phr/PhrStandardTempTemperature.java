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
 * The persistent class for the phr_standard_temp_temperature database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_TEMP_TEMPERATURE")
@NamedQuery(name="PhrStandardTempTemperature.findAll", query="SELECT p FROM PhrStandardTempTemperature p")
public class PhrStandardTempTemperature  extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="DATE_MEASURE")
	private Timestamp dateMeasure;

	@Column(name="NOTE")
	private String note;

	@Column(name="PROFILE_ID")
	private Long profileId;

	@Column(name="SOURCE")
	private String source;

	@Column(name="SYNC_ID")
	private BigInteger syncId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="TEMPERATURE")
	private BigDecimal temperature;

	@Column(name="UPD_ID")
	private String updId;

	public PhrStandardTempTemperature() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getDateMeasure() {
		return this.dateMeasure;
	}

	public void setDateMeasure(Timestamp dateMeasure) {
		this.dateMeasure = dateMeasure;
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

	public String getSource() {
		return this.source;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public BigInteger getSyncId() {
		return this.syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public BigDecimal getTemperature() {
		return this.temperature;
	}

	public void setTemperature(BigDecimal temperature) {
		this.temperature = temperature;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}
}