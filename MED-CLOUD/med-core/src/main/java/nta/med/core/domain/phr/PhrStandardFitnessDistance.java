package nta.med.core.domain.phr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.math.BigInteger;


/**
 * The persistent class for the phr_standard_fitness_distance database table.
 * 
 */
@Entity
@Table(name="PHR_STANDARD_FITNESS_DISTANCE")
@NamedQuery(name="PhrStandardFitnessDistance.findAll", query="SELECT p FROM PhrStandardFitnessDistance p")
public class PhrStandardFitnessDistance extends PhrBaseEntity implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name="DATETIME_RECORD")
	private Timestamp datetimeRecord;

	private String note;

	@Column(name="PROFILE_ID")
	private Long profileId;

	private String source;

	@Column(name="SYNC_ID")
	private BigInteger syncId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	@Column(name="WALK_RUN_DISTANCE")
	private BigDecimal walkRunDistance;

	public PhrStandardFitnessDistance() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
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

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public BigDecimal getWalkRunDistance() {
		return walkRunDistance;
	}

	public void setWalkRunDistance(BigDecimal walkRunDistance) {
		this.walkRunDistance = walkRunDistance;
	}
}