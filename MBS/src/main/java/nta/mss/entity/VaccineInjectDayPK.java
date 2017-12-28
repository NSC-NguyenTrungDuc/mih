package nta.mss.entity;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the vaccing_inject_day database table.
 * 
 */
@Embeddable
public class VaccineInjectDayPK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(name="injected_no", unique=true, nullable=false)
	private Integer injectedNo;

	@Column(name="vaccine_id", insertable=false, updatable=false, unique=true, nullable=false)
	private Integer vaccineId;

	public VaccineInjectDayPK() {
	}
	public Integer getInjectedNo() {
		return this.injectedNo;
	}
	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}
	public Integer getVaccineId() {
		return this.vaccineId;
	}
	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof VaccineInjectDayPK)) {
			return false;
		}
		VaccineInjectDayPK castOther = (VaccineInjectDayPK)other;
		return 
			(this.injectedNo == castOther.injectedNo)
			&& (this.vaccineId == castOther.vaccineId);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.injectedNo;
		hash = hash * prime + this.vaccineId;
		
		return hash;
	}
}