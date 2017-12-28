package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardTempBreathInfo {

	private BigInteger id;

	private Timestamp dateMeasure;

	private BigDecimal breath;

	private String note;
	
	private String perDay;

	private BigInteger count;

	public StandardTempBreathInfo(BigInteger id, Timestamp dateMeasure, BigDecimal breath, String note, String perDay, BigInteger count) {
		super();
		this.id = id;
		this.dateMeasure = dateMeasure;
		this.breath = breath;
		this.note = note;
		this.perDay = perDay;
		this.count = count;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Timestamp getDateMeasure() {
		return dateMeasure;
	}

	public void setDateMeasure(Timestamp dateMeasure) {
		this.dateMeasure = dateMeasure;
	}

	public BigDecimal getBreath() {
		return breath;
	}

	public void setBreath(BigDecimal breath) {
		this.breath = breath;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
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