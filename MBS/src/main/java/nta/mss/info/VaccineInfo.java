package nta.mss.info;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.DateTimeFormat;

public class VaccineInfo implements Serializable{

	private static final long serialVersionUID = -5890174151817676452L;
	
	private Integer vaccineId;
	private BigInteger typeSupport;
	private String vaccineType;
	private Integer totalInject;
	private String vaccineName;
	private String color;
	private Integer vaccineGroupId;
	private Integer limitAgeFromMonth;
	private Integer limitAgeToMonth;
	private BigDecimal vaccineStatus;
	private Timestamp fromDate;
	private Date fromDateType;
	private Timestamp toDate;
	private Date toDateType;
	private String recommendAge;
	private String supportFeeAge;
	private Integer warningDays;
	private String vaccineCd;
	private Integer injectedNo;
	private Integer dayMin;
	private Integer dayMax;
	private String description;
	private String formattedLimitAge;
	private List<String> formattedRecommendAge;
	private List<String> formattedSupportFeeDate;
	private String formattedExpiredDate;
	private List<String> formattedSupportFeeByMonth;
	
	public VaccineInfo(Integer vaccineId, BigInteger typeSupport,
			String vaccineType, Integer totalInject, String vaccineName,
			String color, Integer vaccineGroupId, Integer limitAgeFromMonth,
			Integer limitAgeToMonth, BigDecimal vaccineStatus,
			Timestamp fromDate, Timestamp toDate, String recommendAge,
			String supportFeeAge, Integer warningDays, String vaccineCd,
			Integer injectedNo, Integer dayMin, Integer dayMax,
			String description) {
		super();
		this.vaccineId = vaccineId;
		this.typeSupport = typeSupport;
		this.vaccineType = vaccineType;
		this.totalInject = totalInject;
		this.vaccineName = vaccineName;
		this.color = color;
		this.vaccineGroupId = vaccineGroupId;
		this.limitAgeFromMonth = limitAgeFromMonth;
		this.limitAgeToMonth = limitAgeToMonth;
		this.vaccineStatus = vaccineStatus;
		this.fromDate = fromDate;
		this.toDate = toDate;
		this.recommendAge = recommendAge;
		this.supportFeeAge = supportFeeAge;
		this.warningDays = warningDays;
		this.vaccineCd = vaccineCd;
		this.injectedNo = injectedNo;
		this.dayMin = dayMin;
		this.dayMax = dayMax;
		this.description = description;
	}
	public Integer getVaccineId() {
		return vaccineId;
	}
	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}
	public BigInteger getTypeSupport() {
		return typeSupport;
	}
	public void setTypeSupport(BigInteger typeSupport) {
		this.typeSupport = typeSupport;
	}
	public String getVaccineType() {
		return vaccineType;
	}
	public void setVaccineType(String vaccineType) {
		this.vaccineType = vaccineType;
	}
	public Integer getTotalInject() {
		return totalInject;
	}
	public void setTotalInject(Integer totalInject) {
		this.totalInject = totalInject;
	}
	public String getVaccineName() {
		return vaccineName;
	}
	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}
	public String getColor() {
		return color;
	}
	public void setColor(String color) {
		this.color = color;
	}
	public Integer getVaccineGroupId() {
		return vaccineGroupId;
	}
	public void setVaccineGroupId(Integer vaccineGroupId) {
		this.vaccineGroupId = vaccineGroupId;
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
	public BigDecimal getVaccineStatus() {
		return vaccineStatus;
	}
	public void setVaccineStatus(BigDecimal vaccineStatus) {
		this.vaccineStatus = vaccineStatus;
	}
	public Timestamp getFromDate() {
		return fromDate;
	}
	public void setFromDate(Timestamp fromDate) {
		this.fromDate = fromDate;
	}
	public Date getFromDateType() {
		return getFromDate() != null ? new Date(getFromDate().getTime()) : null;
	}
	public void setFromDateType(Date fromDateType) {
		this.fromDateType = fromDateType;
	}
	public Timestamp getToDate() {
		return toDate;
	}
	public void setToDate(Timestamp toDate) {
		this.toDate = toDate;
	}
	public Date getToDateType() {
		return getToDate() != null ? new Date(getToDate().getTime()) : null;
	}
	public void setToDateType(Date toDateType) {
		this.toDateType = toDateType;
	}
	public String getRecommendAge() {
		return recommendAge;
	}
	public void setRecommendAge(String recommendAge) {
		this.recommendAge = recommendAge;
	}
	public String getSupportFeeAge() {
		return supportFeeAge;
	}
	public void setSupportFeeAge(String supportFeeAge) {
		this.supportFeeAge = supportFeeAge;
	}
	public Integer getWarningDays() {
		return warningDays;
	}
	public void setWarningDays(Integer warningDays) {
		this.warningDays = warningDays;
	}
	public String getVaccineCd() {
		return vaccineCd;
	}
	public void setVaccineCd(String vaccineCd) {
		this.vaccineCd = vaccineCd;
	}
	public Integer getInjectedNo() {
		return injectedNo;
	}
	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}
	public Integer getDayMin() {
		return dayMin;
	}
	public void setDayMin(Integer dayMin) {
		this.dayMin = dayMin;
	}
	public Integer getDayMax() {
		return dayMax;
	}
	public void setDayMax(Integer dayMax) {
		this.dayMax = dayMax;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getFormattedLimitAge() {
		return VaccineUtils.getRangeOfAgeText(limitAgeFromMonth, limitAgeToMonth, MssContextHolder.getLocale());
	}
	public void setFormattedLimitAge(String formattedLimitAge) {
		this.formattedLimitAge = formattedLimitAge;
	}
	public List<String> getFormattedRecommendAge() {
		return VaccineUtils.getRangeOfAgeTextInCombinedString(getRecommendAge(), MssContextHolder.getLocale());
	}
	public void setFormattedRecommendAge(List<String> formattedRecommendAge) {
		this.formattedRecommendAge = formattedRecommendAge;
	}
	public List<String> getFormattedSupportFeeDate() {
		return formattedSupportFeeDate;
	}
	public void setFormattedSupportFeeDate(Date childBirthDay) {
		this.formattedSupportFeeDate = VaccineUtils.getRangeOfDateTextInCombinedString(childBirthDay, getSupportFeeAge(), DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
	}
	public String getFormattedExpiredDate() {
		return VaccineUtils.getRangeOfDateText(getFromDate(), getToDate(), MssContextHolder.getLocale());
	}
	public void setFormattedExpiredDate(String formattedExpiredDate) {
		this.formattedExpiredDate = formattedExpiredDate;
	}
	public List<String> getFormattedSupportFeeByMonth() {
		return VaccineUtils.getRangeOfAgeTextInCombinedString(getSupportFeeAge(), MssContextHolder.getLocale());
	}
	public void setFormattedSupportFeeByMonth(List<String> formattedSupportFeeByMonth) {
		this.formattedSupportFeeByMonth = formattedSupportFeeByMonth;
	}
	
}
