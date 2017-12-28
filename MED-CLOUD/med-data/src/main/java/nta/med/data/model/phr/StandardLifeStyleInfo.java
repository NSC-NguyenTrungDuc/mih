package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_FOOD_CALORIES database table.
 * 
 */

public class StandardLifeStyleInfo {

	private BigInteger id;

	private String note;

	private Integer profileId;

	private Integer ratingSleep;

	private Integer timeAwake;

	private Timestamp timeStartSleep;

	private Timestamp timeWakeUp;

	private BigDecimal totalHourSleep;
	
	private String perDay;

	public StandardLifeStyleInfo(BigInteger id, String note, Integer profileId, Integer ratingSleep, Integer timeAwake,
			Timestamp timeStartSleep, Timestamp timeWakeUp, BigDecimal totalHourSleep, String perDay) {
		super();
		this.id = id;
		this.note = note;
		this.profileId = profileId;
		this.ratingSleep = ratingSleep;
		this.timeAwake = timeAwake;
		this.timeStartSleep = timeStartSleep;
		this.timeWakeUp = timeWakeUp;
		this.totalHourSleep = totalHourSleep;
		this.perDay = perDay;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Integer getProfileId() {
		return profileId;
	}

	public void setProfileId(Integer profileId) {
		this.profileId = profileId;
	}

	public Integer getRatingSleep() {
		return ratingSleep;
	}

	public void setRatingSleep(Integer ratingSleep) {
		this.ratingSleep = ratingSleep;
	}

	public Integer getTimeAwake() {
		return timeAwake;
	}

	public void setTimeAwake(Integer timeAwake) {
		this.timeAwake = timeAwake;
	}

	public Timestamp getTimeStartSleep() {
		return timeStartSleep;
	}

	public void setTimeStartSleep(Timestamp timeStartSleep) {
		this.timeStartSleep = timeStartSleep;
	}

	public Timestamp getTimeWakeUp() {
		return timeWakeUp;
	}

	public void setTimeWakeUp(Timestamp timeWakeUp) {
		this.timeWakeUp = timeWakeUp;
	}

	public BigDecimal getTotalHourSleep() {
		return totalHourSleep;
	}

	public void setTotalHourSleep(BigDecimal totalHourSleep) {
		this.totalHourSleep = totalHourSleep;
	}

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}
}