/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;


public class HealthHeightInfo {
	
	private BigInteger id;
	private Timestamp datetimeRecord;
	private BigDecimal height;
	private String note;
	private String perDay;
	private BigInteger count;
	
	public HealthHeightInfo(BigInteger id, Timestamp datetimeRecord, BigDecimal height, String note, String perDay, BigInteger count) {
		super();
		this.id = id;
		this.datetimeRecord = datetimeRecord;
		this.height = height;
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

	public BigDecimal getHeight() {
		return height;
	}

	public void setHeight(BigDecimal height) {
		this.height = height;
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
