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
 * The persistent class for the phr_standard_health_bfp database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_HEALTH_BFP")
@NamedQuery(name="PhrStandardHealthBfp.findAll", query="SELECT p FROM PhrStandardHealthBfp p")
public class PhrStandardHealthBfp extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="DATETIME_RECORD")
	private Timestamp datetimeRecord;

	private String note;

	@Column(name="PERC_FAT")
	private BigDecimal percFat;

	@Column(name="PROFILE_ID")
	private Long profileId;

	private String source;

	@Column(name="SYNC_ID")
	private BigInteger syncId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	public PhrStandardHealthBfp() {
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

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public BigDecimal getPercFat() {
		return this.percFat;
	}

	public void setPercFat(BigDecimal percFat) {
		this.percFat = percFat;
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