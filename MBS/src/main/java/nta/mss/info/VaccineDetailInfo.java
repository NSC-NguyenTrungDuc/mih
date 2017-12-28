package nta.mss.info;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.VaccineUtils;
import nta.mss.misc.enums.DateTimeFormat;

public class VaccineDetailInfo implements Serializable, Comparable<VaccineDetailInfo> {

	private static final long serialVersionUID = -5932782177071351578L;
	
	private Integer vaccineId;
	private Integer typeSupport;
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
	private String hospitalName;
	private Timestamp injectedDate;
	private Date injectedDateType;
	private String formattedInjectedDate;
	private Integer reservationId;
	private BigInteger childId;
	private String status;
	private Date dateCanBooking;
	private String formattedDateCanBooking;
	private String dateCanBookingStr;
	private String formattedLimitAge;
	private List<String> formattedRecommendAge;
	private List<String> formattedSupportFeeDate;
	private Integer remainingDays;
	private String warningDaysText;
	
	public VaccineDetailInfo(Integer vaccineId, Integer typeSupport,
			String vaccineType, Integer totalInject, String vaccineName,
			String color, Integer vaccineGroupId, Integer limitAgeFromMonth,
			Integer limitAgeToMonth, BigDecimal vaccineStatus,
			Timestamp fromDate, Timestamp toDate, String recommendAge,
			String supportFeeAge, Integer warningDays, String vaccineCd,
			Integer injectedNo, Integer dayMin, Integer dayMax,
			String description, String hospitalName, Timestamp injectedDate,
			Integer reservationId, BigInteger childId, String status) {
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
		this.hospitalName = hospitalName;
		this.injectedDate = injectedDate;
		this.reservationId = reservationId;
		this.childId = childId;
		this.status = status;
	}
	public Integer getVaccineId() {
		return vaccineId;
	}
	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}
	public Integer getTypeSupport() {
		return typeSupport;
	}
	public void setTypeSupport(Integer typeSupport) {
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
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public Timestamp getInjectedDate() {
		return injectedDate;
	}
	public void setInjectedDate(Timestamp injectedDate) {
		this.injectedDate = injectedDate;
	}
	public Date getInjectedDateType() {
		return getInjectedDate() != null ? new Date(getInjectedDate().getTime()) : null;
	}
	public void setInjectedDateType(Date injectedDateType) {
		this.injectedDateType = injectedDateType;
	}
	public Integer getReservationId() {
		return reservationId;
	}
	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	public BigInteger getChildId() {
		return childId;
	}
	public void setChildId(BigInteger childId) {
		this.childId = childId;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public Date getDateCanBooking() {
		return dateCanBooking;
	}
	public void setDateCanBooking(Date dateCanBooking) {
		this.dateCanBooking = dateCanBooking;
	}
	public String getFormattedDateCanBooking() {
		if (dateCanBooking != null) {
			return MssDateTimeUtil.convertDateToStringByLocale(dateCanBooking, DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
		}
		return null;
	}
	public void setFormattedDateCanBooking(String formattedDateCanBooking) {
		this.formattedDateCanBooking = formattedDateCanBooking;
	}
	public String getDateCanBookingStr() {
		if (dateCanBooking != null) {
			return MssDateTimeUtil.dateToString(dateCanBooking, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
		}
		return null;
	}
	public void setDateCanBookingStr(String dateCanBookingStr) {
		this.dateCanBookingStr = dateCanBookingStr;
	}
	public String getFormattedInjectedDate() {
		if (injectedDate != null) {
			return MssDateTimeUtil.convertDateToStringByLocale(new Date(injectedDate.getTime()), DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
		}
		return null;
	}
	public void setFormattedInjectedDate(String formattedInjectedDate) {
		this.formattedInjectedDate = formattedInjectedDate;
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
		this.formattedSupportFeeDate = VaccineUtils.getRangeOfDateTextInCombinedString(childBirthDay, supportFeeAge, DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
	}
	public Integer getRemainingDays() {
		return remainingDays;
	}
	public void setRemainingDays(Integer remainingDays) {
		this.remainingDays = remainingDays;
	}
	public String getWarningDaysText() {
		return warningDaysText;
	}
	public void setWarningDaysText(String warningDaysText) {
		this.warningDaysText = warningDaysText;
	}
	@Override
	public int compareTo(VaccineDetailInfo o) {
		return o.getDateCanBooking().compareTo(getDateCanBooking());
	}
}
