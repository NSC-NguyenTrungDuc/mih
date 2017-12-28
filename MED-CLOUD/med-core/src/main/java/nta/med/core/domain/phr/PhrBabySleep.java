package nta.med.core.domain.phr;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_BABY_SLEEP database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_SLEEP")
@NamedQuery(name = "PhrBabySleep.findAll", query = "SELECT p FROM PhrBabySleep p")
public class PhrBabySleep extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private BigDecimal alert;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_START_SLEEP")
	private Timestamp timeStartSleep;

	@Column(name = "TIME_WAKE_UP")
	private Timestamp timeWakeUp;

	@Column(name = "TOTAL_HOUR_SLEEP")
	private Integer totalHourSleep;

	@Column(name = "UPD_ID")
	private String updId;

	@Column(name = "MORNING_TIME_SLEEP")
	private Integer morningTimeSleep;

	@Column(name = "AFTERNOON_TIME_SLEEP")
	private Integer afternoonTimeSleep;

	@Column(name = "NIGHT_TIME_SLEEP")
	private Integer nightTimeSleep;

	public PhrBabySleep() {
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

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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
		return totalHourSleep;
	}

	public void setTotalHourSleep(Integer totalHourSleep) {
		this.totalHourSleep = totalHourSleep;
	}

	public Integer getMorningTimeSleep() {
		return morningTimeSleep;
	}

	public void setMorningTimeSleep(Integer morningTimeSleep) {
		this.morningTimeSleep = morningTimeSleep;
	}

	public Integer getAfternoonTimeSleep() {
		return afternoonTimeSleep;
	}

	public void setAfternoonTimeSleep(Integer afternoonTimeSleep) {
		this.afternoonTimeSleep = afternoonTimeSleep;
	}

	public Integer getNightTimeSleep() {
		return nightTimeSleep;
	}

	public void setNightTimeSleep(Integer nightTimeSleep) {
		this.nightTimeSleep = nightTimeSleep;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Override
	public Timestamp getTimestamp() {
		return timeStartSleep;
	}
}