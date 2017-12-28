package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardTempBpInfo {

	private BigInteger id;

	private Timestamp dateMeasure;

	private BigDecimal minBpFrom;
	private BigDecimal maxBpFrom;
	private BigDecimal minBpTo;
	private BigDecimal maxBpTo;

	private String note;
	
	private String perDay;


	public StandardTempBpInfo(BigInteger id, Timestamp dateMeasure, BigDecimal minBpFrom,
							  BigDecimal maxBpFrom, BigDecimal minBpTo, BigDecimal maxBpTo, String note, String perDay) {
		this.id = id;
		this.dateMeasure = dateMeasure;
		this.minBpFrom = minBpFrom;
		this.maxBpFrom = maxBpFrom;
		this.minBpTo = minBpTo;
		this.maxBpTo = maxBpTo;
		this.note = note;
		this.perDay = perDay;
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

	public BigDecimal getMinBpFrom() {
		return minBpFrom;
	}

	public void setMinBpFrom(BigDecimal minBpFrom) {
		this.minBpFrom = minBpFrom;
	}

	public BigDecimal getMaxBpFrom() {
		return maxBpFrom;
	}

	public void setMaxBpFrom(BigDecimal maxBpFrom) {
		this.maxBpFrom = maxBpFrom;
	}

	public BigDecimal getMinBpTo() {
		return minBpTo;
	}

	public void setMinBpTo(BigDecimal minBpTo) {
		this.minBpTo = minBpTo;
	}

	public BigDecimal getMaxBpTo() {
		return maxBpTo;
	}

	public void setMaxBpTo(BigDecimal maxBpTo) {
		this.maxBpTo = maxBpTo;
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
}