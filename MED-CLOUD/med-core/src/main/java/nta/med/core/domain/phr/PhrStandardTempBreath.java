package nta.med.core.domain.phr;

import java.io.Serializable;
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
 * The persistent class for the phr_standard_temp_breath database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_TEMP_BREATH")
@NamedQuery(name="PhrStandardTempBreath.findAll", query="SELECT p FROM PhrStandardTempBreath p")
public class PhrStandardTempBreath extends PhrBaseEntity implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="BREATH")
	private BigDecimal breath;

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

	@Column(name="UPD_ID")
	private String updId;
	
	public PhrStandardTempBreath() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getBreath() {
		return this.breath;
	}

	public void setBreath(BigDecimal breath) {
		this.breath = breath;
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

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}
}