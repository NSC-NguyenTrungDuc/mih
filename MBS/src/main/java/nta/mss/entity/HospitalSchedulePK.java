package nta.mss.entity;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the hospital_schedule database table.
 * 
 */
@Embeddable
public class HospitalSchedulePK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(name="hospital_id", insertable=false, updatable=false, unique=true, nullable=false)
	private Integer hospitalId;

	@Column(name="working_date", unique=true, nullable=false, length=8)
	private String workingDate;

	/**
	 * Instantiates a new hospital schedule pk.
	 */
	public HospitalSchedulePK() {
	}
	public Integer getHospitalId() {
		return this.hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getWorkingDate() {
		return this.workingDate;
	}
	public void setWorkingDate(String workingDate) {
		this.workingDate = workingDate;
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
		if (!(other instanceof HospitalSchedulePK)) {
			return false;
		}
		HospitalSchedulePK castOther = (HospitalSchedulePK)other;
		return 
			(this.hospitalId.equals(castOther.hospitalId))
			&& this.workingDate.equals(castOther.workingDate);
	}

	/**
	 * Hash code.
	 * 
	 * @return the int
	 */
	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.hospitalId;
		hash = hash * prime + this.workingDate.hashCode();
		
		return hash;
	}
}