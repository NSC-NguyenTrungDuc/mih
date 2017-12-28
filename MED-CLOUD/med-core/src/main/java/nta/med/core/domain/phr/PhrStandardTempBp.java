package nta.med.core.domain.phr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.math.BigInteger;


/**
 * The persistent class for the phr_standard_temp_bp database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_TEMP_BP")
@NamedQuery(name="PhrStandardTempBp.findAll", query="SELECT p FROM PhrStandardTempBp p")
public class PhrStandardTempBp extends PhrBaseEntity implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="BP_FROM")
	private BigDecimal bpFrom;

	@Column(name="BP_TO")
	private BigDecimal bpTo;

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

	public PhrStandardTempBp() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getBpFrom() {
		return this.bpFrom;
	}

	public void setBpFrom(BigDecimal bpFrom) {
		this.bpFrom = bpFrom;
	}

	public BigDecimal getBpTo() {
		return this.bpTo;
	}

	public void setBpTo(BigDecimal bpTo) {
		this.bpTo = bpTo;
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