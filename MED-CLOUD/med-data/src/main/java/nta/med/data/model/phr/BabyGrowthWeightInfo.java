package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class BabyGrowthWeightInfo {

	private BigInteger id;

	private Timestamp timeMeasure;

	private BigDecimal weight;

	private String doctorNote;
	
	private String parentNote;
	
	private String perDay;

	private BigInteger count;

	public BabyGrowthWeightInfo(BigInteger id, Timestamp timeMeasure, BigDecimal weight, String doctorNote,
			String parentNote, String perDay, BigInteger count) {
		super();
		this.id = id;
		this.timeMeasure = timeMeasure;
		this.weight = weight;
		this.doctorNote = doctorNote;
		this.parentNote = parentNote;
		this.perDay = perDay;
		this.count = count;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Timestamp getTimeMeasure() {
		return timeMeasure;
	}

	public void setTimeMeasure(Timestamp timeMeasure) {
		this.timeMeasure = timeMeasure;
	}

	public BigDecimal getWeight() {
		return weight;
	}

	public void setWeight(BigDecimal weight) {
		this.weight = weight;
	}

	public String getDoctorNote() {
		return doctorNote;
	}

	public void setDoctorNote(String doctorNote) {
		this.doctorNote = doctorNote;
	}

	public String getParentNote() {
		return parentNote;
	}

	public void setParentNote(String parentNote) {
		this.parentNote = parentNote;
	}

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}

	public BigInteger getCount() {
		return count;
	}

	public void setCount(BigInteger count) {
		this.count = count;
	}
}