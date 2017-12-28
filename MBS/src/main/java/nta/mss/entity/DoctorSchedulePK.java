package nta.mss.entity;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the doctor_schedule database table.
 * 
 */
@Embeddable
public class DoctorSchedulePK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(name="doctor_id", insertable=false, updatable=false, unique=true, nullable=false)
	private Integer doctorId;

	@Column(name="check_date", unique=true, nullable=false, length=8)
	private String checkDate;

	@Column(name="start_time", unique=true, nullable=false, length=6)
	private String startTime;

	/**
	 * Instantiates a new doctor schedule pk.
	 */
	public DoctorSchedulePK() {
	}
	
	/**
	 * Instantiates a new doctor schedule pk.
	 * 
	 * @param doctorId
	 *            the doctor id
	 * @param checkDate
	 *            the check date
	 * @param startTime
	 *            the start time
	 */
	public DoctorSchedulePK(Integer doctorId, String checkDate, String startTime) {
		super();
		this.doctorId = doctorId;
		this.checkDate = checkDate;
		this.startTime = startTime;
	}

	public Integer getDoctorId() {
		return this.doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public String getCheckDate() {
		return this.checkDate;
	}
	public void setCheckDate(String checkDate) {
		this.checkDate = checkDate;
	}
	public String getStartTime() {
		return this.startTime;
	}
	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	/**
	 * Equals.
	 * 
	 * @param other
	 *            the other
	 * @return true, if successful
	 */
	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof DoctorSchedulePK)) {
			return false;
		}
		DoctorSchedulePK castOther = (DoctorSchedulePK)other;
		return 
			(this.doctorId.equals(castOther.doctorId))
			&& this.checkDate.equals(castOther.checkDate)
			&& this.startTime.equals(castOther.startTime);
	}

	/**
	 * Hash code.
	 * 
	 * @return the int
	 */
	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.doctorId;
		hash = hash * prime + this.checkDate.hashCode();
		hash = hash * prime + this.startTime.hashCode();
		
		return hash;
	}

	@Override
	public String toString() {
		return "DoctorSchedulePK [doctorId=" + doctorId + ", checkDate="
				+ checkDate + ", startTime=" + startTime + "]";
	}
}