/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;


public class HealthBmiInfo {

	private BigInteger id;
	private Timestamp datetimeRecord;
	private BigDecimal bmi;
	private String note;
	private String perDay;
	private BigInteger count;
	public HealthBmiInfo(BigInteger id, Timestamp datetimeRecord, BigDecimal bmi, String note, String perDay, BigInteger count) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.bmi = bmi;
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

	public Timestamp getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(Timestamp datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public BigDecimal getBmi() {
		return bmi;
	}

	public void setBmi(BigDecimal bmi) {
		this.bmi = bmi;
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
