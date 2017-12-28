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
 * The persistent class for the PHR_STANDARD_LIFE_STYLE database table.
 * 
 */
@Entity
@Table(name = "PHR_STANDARD_LIFE_STYLE")
@NamedQuery(name = "PhrStandardLifeStyle.findAll", query = "SELECT p FROM PhrStandardLifeStyle p")
public class PhrStandardLifeStyle extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "RATING_SLEEP")
	private Integer ratingSleep;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_AWAKE")
	private Integer timeAwake;

	@Column(name = "TIME_START_SLEEP")
	private Timestamp timeStartSleep;

	@Column(name = "TIME_WAKE_UP")
	private Timestamp timeWakeUp;

	@Column(name = "TOTAL_HOUR_SLEEP")
	private Integer totalHourSleep;

	@Column(name = "UPD_ID")
	private String updId;
	
	@Column(name = "SOURCE")
	private String source;

	public PhrStandardLifeStyle() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
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

	public Integer getRatingSleep() {
		return this.ratingSleep;
	}

	public void setRatingSleep(Integer ratingSleep) {
		this.ratingSleep = ratingSleep;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Integer getTimeAwake() {
		return this.timeAwake;
	}

	public void setTimeAwake(Integer timeAwake) {
		this.timeAwake = timeAwake;
	}

	public Timestamp getTimeStartSleep() {
		return this.timeStartSleep;
	}

	public void setTimeStartSleep(Timestamp timeStartSleep) {
		this.timeStartSleep = timeStartSleep;
	}

	public Timestamp getTimeWakeUp() {
		return this.timeWakeUp;
	}

	public void setTimeWakeUp(Timestamp timeWakeUp) {
		this.timeWakeUp = timeWakeUp;
	}

	public Integer getTotalHourSleep() {
		return this.totalHourSleep;
	}

	public void setTotalHourSleep(Integer totalHourSleep) {
		this.totalHourSleep = totalHourSleep;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}
}