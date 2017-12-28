/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;


public class HealthWeightInfo {

	private BigInteger id;
	private Timestamp datetimeRecord;
	private BigDecimal weight;
	private String note;
	private String perDay;
	private BigInteger count;
	public HealthWeightInfo(BigInteger id, Timestamp datetimeRecord, BigDecimal weight, String note, String perDay, BigInteger count) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.weight = weight;
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

	public BigDecimal getWeight() {
		return weight;
	}

	public void setWeight(BigDecimal weight) {
		this.weight = weight;
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
