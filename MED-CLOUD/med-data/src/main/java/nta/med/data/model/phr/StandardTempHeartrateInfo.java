package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * The persistent class for the PHR_STANDARD_TEMPERATURE database table.
 * 
 */
public class StandardTempHeartrateInfo {

	private BigInteger id;
	
	private Timestamp dateMeasure;

	private BigDecimal minHeartrate;

	private BigDecimal maxHeartrate;

	private String note;
	
	private String perDay;



	public StandardTempHeartrateInfo(BigInteger id, Timestamp dateMeasure, BigDecimal minHeartrate, BigDecimal maxHeartrate, String note, String perDay) {
		super();
		this.id = id;
		this.dateMeasure = dateMeasure;
		this.minHeartrate = minHeartrate;
		this.maxHeartrate = maxHeartrate;
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

	public BigDecimal getMinHeartrate() {
		return minHeartrate;
	}

	public void setMinHeartrate(BigDecimal minHeartrate) {
		this.minHeartrate = minHeartrate;
	}

	public BigDecimal getMaxHeartrate() {
		return maxHeartrate;
	}

	public void setMaxHeartrate(BigDecimal maxHeartrate) {
		this.maxHeartrate = maxHeartrate;
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