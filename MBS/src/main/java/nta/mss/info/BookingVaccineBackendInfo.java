package nta.mss.info;

import java.math.BigInteger;
import java.sql.Timestamp;

public class BookingVaccineBackendInfo {
	private Integer totalInject;
	private BigInteger injectdNoCurrent;
	private Integer limitAgeFromMonth;
	private Integer limitAgeToMonth;
	private Timestamp fromDate;
	private Timestamp toDate;
	private String fromDateFormat;
	private String strFromDate;
	private String fromYear;
	private String toYear;
	
	public BookingVaccineBackendInfo(Integer totalInject,
			BigInteger injectdNoCurrent, Integer limitAgeFromMonth,
			Integer limitAgeToMonth, Timestamp fromDate, Timestamp toDate) {
		this.totalInject = totalInject;
		this.injectdNoCurrent = injectdNoCurrent;
		this.limitAgeFromMonth = limitAgeFromMonth;
		this.limitAgeToMonth = limitAgeToMonth;
		this.fromDate = fromDate;
		this.toDate = toDate;
	}

	public Integer getTotalInject() {
		return totalInject;
	}

	public void setTotalInject(Integer totalInject) {
		this.totalInject = totalInject;
	}

	public BigInteger getInjectdNoCurrent() {
		return injectdNoCurrent;
	}

	public void setInjectdNoCurrent(BigInteger injectdNoCurrent) {
		this.injectdNoCurrent = injectdNoCurrent;
	}

	public Integer getLimitAgeFromMonth() {
		return limitAgeFromMonth;
	}

	public void setLimitAgeFromMonth(Integer limitAgeFromMonth) {
		this.limitAgeFromMonth = limitAgeFromMonth;
	}

	public Integer getLimitAgeToMonth() {
		return limitAgeToMonth;
	}

	public void setLimitAgeToMonth(Integer limitAgeToMonth) {
		this.limitAgeToMonth = limitAgeToMonth;
	}

	public Timestamp getFromDate() {
		return fromDate;
	}

	public void setFromDate(Timestamp fromDate) {
		this.fromDate = fromDate;
	}

	public Timestamp getToDate() {
		return toDate;
	}

	public void setToDate(Timestamp toDate) {
		this.toDate = toDate;
	}

	public String getFromDateFormat() {
		return fromDateFormat;
	}

	public void setFromDateFormat(String fromDateFormat) {
		this.fromDateFormat = fromDateFormat;
	}

	public String getStrFromDate() {
		return strFromDate;
	}

	public void setStrFromDate(String strFromDate) {
		this.strFromDate = strFromDate;
	}

	public String getFromYear() {
		return fromYear;
	}

	public void setFromYear(String fromYear) {
		this.fromYear = fromYear;
	}

	public String getToYear() {
		return toYear;
	}

	public void setToYear(String toYear) {
		this.toYear = toYear;
	}
	
}
