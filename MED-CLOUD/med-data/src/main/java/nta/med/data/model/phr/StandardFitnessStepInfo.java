package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardFitnessStepInfo {

	private BigInteger id;

	private Timestamp datetimeRecord;

	private BigDecimal stepsCount;

	private String note;
	
	private String perDay;

	public StandardFitnessStepInfo(BigInteger id, Timestamp datetimeRecord, BigDecimal stepsCount, String note,
			String perDay) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.stepsCount = stepsCount;
		this.note = note;
		this.perDay = perDay;
	}

	public String getPerDay() {
		return perDay;
	}

	public void setPerDay(String perDay) {
		this.perDay = perDay;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public BigDecimal getStepsCount() {
		return stepsCount;
	}

	public void setStepsCount(BigDecimal stepsCount) {
		this.stepsCount = stepsCount;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}
}