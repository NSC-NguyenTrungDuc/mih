package nta.mss.misc.common;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import nta.mss.info.VaccineWarningInfo;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.VaccineWarningType;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.stereotype.Component;

/**
 * The Class VaccineUtils.
 *
 * @author MinhLS
 * @crtDate 2015/02/10
 */
@Component
public class VaccineUtils {
	
	/** The message source. */
	private static MessageSource messageSource;
	
	/**
	 * Instantiates a new vaccine utils.
	 *
	 * @param messageSource the message source
	 */
	@Autowired
	public VaccineUtils(MessageSource messageSource){
		VaccineUtils.messageSource = messageSource;
	}
    
	/**
	 * Gets the range of age text in combined string.
	 *
	 * @param combinedStr the combined str
	 * @param locale the locale
	 * @return the range of age text in combined string
	 */
	public static List<String> getRangeOfAgeTextInCombinedString (String combinedStr, Locale locale) {
		List<String> result = new ArrayList<String>();
		if (combinedStr != null || StringUtils.isNotBlank(combinedStr)) {
			List<String> dateRangeArray = Arrays.asList(combinedStr.split(","));
			Collections.sort(dateRangeArray);
			for (int i = 0; i < dateRangeArray.size(); i ++) {
				String[] date = dateRangeArray.get(i).split("-");
				result.add(getRangeOfAgeText(Integer.valueOf(date[0]), Integer.valueOf(date[1]), locale));
			}
		}
		return result;
	}
	
	/**
	 * Gets the range of age text.
	 *
	 * @param monthsFrom the months from
	 * @param monthsTo the months to
	 * @param locale the locale
	 * @return the range of age text
	 */
	public static String getRangeOfAgeText (Integer monthsFrom, Integer monthsTo, Locale locale) {
		String from = getMonthAndYearText(monthsFrom, locale);
		String to = getMonthAndYearText(monthsTo, locale);
		StringBuilder sb = new StringBuilder();
		if (StringUtils.isNotBlank(from) && StringUtils.isNotBlank(to)) {
			sb.append(messageSource.getMessage("general.vaccine.date.from", new Object[]{from}, locale));
			sb.append(messageSource.getMessage("general.vaccine.date.to", new Object[]{to}, locale));
		}
		else if (StringUtils.isNotBlank(from)) {
			sb.append(messageSource.getMessage("general.vaccine.date.more.than", new Object[]{from}, locale));
		}
		else if (StringUtils.isNotBlank(to)) {
			sb.append(messageSource.getMessage("general.vaccine.date.less.than", new Object[]{to}, locale));
		}
		else {
			sb.append(messageSource.getMessage("general.vaccine.date.no.limitation", null, locale));
		}
		return sb.toString();
	}
	
	/**
	 * Gets the month and year text.
	 *
	 * @param months the months
	 * @param isFrom the is from
	 * @param locale the locale
	 * @return the month and year text
	 */
	public static String getMonthAndYearText (Integer months, Locale locale) {
		StringBuilder sb = new StringBuilder();
		String monthText = "general.vaccine.date.month";
		String yearText = "general.vaccine.date.year";
		if (months != null && months != 0) {
			if (months < 12) {
				sb.append(messageSource.getMessage(monthText, new Object[]{months}, locale));
			}
			else {
				sb.append(messageSource.getMessage(yearText, new Object[]{months / 12}, locale));
			}
			if (months > 12 && months % 12 != 0) {
				sb.append(messageSource.getMessage(monthText, new Object[]{months % 12}, locale));
			}
		}
		return sb.toString();
	}
	
	/**
	 * Gets the range of date text in combined string.
	 *
	 * @param childBirthDay the child birth day
	 * @param combinedStr the combined str
	 * @param format the format
	 * @param locale the locale
	 * @return the range of date text in combined string
	 */
	public static List<String> getRangeOfDateTextInCombinedString (Date childBirthDay, String combinedStr, DateTimeFormat format, Locale locale) {
		List<String> result = new ArrayList<String>();
		StringBuilder sb;
		if (combinedStr != null || StringUtils.isNotBlank(combinedStr)) {
			List<String> dateRangeArray = Arrays.asList(combinedStr.split(","));
			Collections.sort(dateRangeArray);
			for (int i = 0; i < dateRangeArray.size(); i ++) {
				String[] date = dateRangeArray.get(i).split("-");
				sb = new StringBuilder(MssDateTimeUtil.convertDateToStringByLocale(MssDateTimeUtil.addMonthToDate(childBirthDay, Integer.valueOf(date[0])), format, locale));
				sb.append(" ~ ");
				sb.append(MssDateTimeUtil.convertDateToStringByLocale(MssDateTimeUtil.addMonthToDate(childBirthDay, Integer.valueOf(date[1])), format, locale));
				result.add(sb.toString());
			}
		}
		return result;
	}
	
	/**
	 * Compare limit age by month.
	 *
	 * @param startDate the start date
	 * @param limitAgeByMonth the limit age by month
	 * @param bookingDate the booking date
	 * @return the integer
	 */
	public static Integer compareLimitAgeByMonth (Date startDate, Integer limitAgeByMonth, Date bookingDate) {
		Calendar limitDateCal = Calendar.getInstance();
		limitDateCal.setTime(startDate);
		limitDateCal.add(Calendar.MONTH, limitAgeByMonth);
		limitDateCal = MssDateTimeUtil.setToStandardTime(limitDateCal);
		Calendar currentCal = Calendar.getInstance();
		
		if (bookingDate != null) {
			currentCal.setTime(bookingDate);
		}
		currentCal = MssDateTimeUtil.setToStandardTime(currentCal);
		
		if (limitDateCal.before(currentCal)) {
			return -1;
		}
		else if (limitDateCal.equals(currentCal)){
			return 0;
		}
		return 1;
	}
	
	/**
	 * Gets the vaccine warning info.
	 *
	 * @param childBirthDay the child birth day
	 * @param monthsTo the months to
	 * @param combinedStr the combined str
	 * @return the vaccine warning info
	 */
	public static VaccineWarningInfo getVaccineWarningInfo (Date childBirthDay, Integer monthsTo, String combinedStr) {
		VaccineWarningInfo vaccineWarningInfo = new VaccineWarningInfo();
		Date currentDate = new Date();
		Date supportFeeDate = null;
		Date limitAgeDate = null;
		// check support fee age
		if (combinedStr != null || StringUtils.isNotBlank(combinedStr)) {
			String[] dateRangeArray = combinedStr.split(",");
			for (int i = 0; i < dateRangeArray.length; i ++) {
				String[] date = dateRangeArray[i].split("-");
				supportFeeDate = MssDateTimeUtil.addMonthToDate(childBirthDay, Integer.valueOf(date[1]));
				if (MssDateTimeUtil.compareDate(currentDate, supportFeeDate) <= 0) {
					vaccineWarningInfo.setWarningType(VaccineWarningType.SUPPORT_FEE.toInt());
					vaccineWarningInfo.setRemainingDays(MssDateTimeUtil.getNumberOfDateBetweenDate(currentDate, supportFeeDate));
					return vaccineWarningInfo;
				}
			}
		}
		// check limit age
		if (monthsTo != null) {
			limitAgeDate = MssDateTimeUtil.addMonthToDate(childBirthDay, monthsTo);
			if (MssDateTimeUtil.compareDate(currentDate, limitAgeDate) <= 0) {
				vaccineWarningInfo.setWarningType(VaccineWarningType.LIMIT_AGE.toInt());
				vaccineWarningInfo.setRemainingDays(MssDateTimeUtil.getNumberOfDateBetweenDate(currentDate, limitAgeDate));
				return vaccineWarningInfo;
			}
		}
		return null;
	}
	
	/**
	 * Gets the months age.
	 *
	 * @param birthDate the birth date
	 * @return the months age
	 */
	public static Integer getMonthsAge(Date birthDate) {
		Integer years = 0;
		Integer months = 0;
		// create calendar object for birth day
		Calendar birthDay = Calendar.getInstance();
		birthDay.setTimeInMillis(birthDate.getTime());
		// create calendar object for current day
		long currentTime = System.currentTimeMillis();
		Calendar now = Calendar.getInstance();
		now.setTimeInMillis(currentTime);
		// Get difference between years
		years = now.get(Calendar.YEAR) - birthDay.get(Calendar.YEAR);
		int currMonth = now.get(Calendar.MONTH) + 1;
		int birthMonth = birthDay.get(Calendar.MONTH) + 1;
		// Get difference between months
		months = currMonth - birthMonth;
		// if month difference is in negative then reduce years by one and
		// calculate the number of months.
		if (months < 0) {
			years--;
			months = 12 - birthMonth + currMonth;
			if (now.get(Calendar.DATE) < birthDay.get(Calendar.DATE))
				months--;
		} else if (months == 0
				&& now.get(Calendar.DATE) < birthDay.get(Calendar.DATE)) {
			years--;
			months = 11;
		}

		return years * 12 + months;
	}
	
	/**
	 * Gets the day age.
	 *
	 * @param birthDate the birth date
	 * @param dateCurrent the date current
	 * @return the day age
	 */
	public static String getDayAge(Date birthDate, Date dateCurrent, Locale locale) {
		StringBuilder sb = new StringBuilder();
		String dayText = "general.vaccine.date.day";
		String monthText = "general.vaccine.date.month";
		String yearText = "general.vaccine.date.year";
		int years = 0;
		int months = 0;
		int days = 0;
		try {
			// create calendar object for birth day
			Calendar birthDay = Calendar.getInstance();
			birthDay.setTimeInMillis(birthDate.getTime());
			
			// create calendar object for current day
			Calendar now = Calendar.getInstance();
			now.setTimeInMillis(dateCurrent.getTime());
			
			// Get difference between years
			years = now.get(Calendar.YEAR) - birthDay.get(Calendar.YEAR);
			int currMonth = now.get(Calendar.MONTH) + 1;
			int birthMonth = birthDay.get(Calendar.MONTH) + 1;
			// Get difference between months
			months = currMonth - birthMonth;
			// if month difference is in negative then reduce years by one and
			// calculate the number of months.
			if (months < 0) {
				years--;
				months = 12 - birthMonth + currMonth;
				if (now.get(Calendar.DATE) < birthDay.get(Calendar.DATE))
					months--;
			} else if (months == 0
					&& now.get(Calendar.DATE) < birthDay.get(Calendar.DATE)) {
				years--;
				months = 11;
			}
			// Calculate the days
			if (now.get(Calendar.DATE) > birthDay.get(Calendar.DATE))
				days = now.get(Calendar.DATE) - birthDay.get(Calendar.DATE);
			else if (now.get(Calendar.DATE) < birthDay.get(Calendar.DATE)) {
				int today = now.get(Calendar.DAY_OF_MONTH);
				now.add(Calendar.MONTH, -1);
				days = now.getActualMaximum(Calendar.DAY_OF_MONTH)
						- birthDay.get(Calendar.DAY_OF_MONTH) + today;
			} else {
				days = 0;
				if (months == 12) {
					years++;
					months = 0;
				}
			}
			
		} catch (Exception e) {
			
		}
		
		sb.append(messageSource.getMessage(yearText, new Object[]{years}, locale));
		sb.append(messageSource.getMessage(monthText, new Object[]{months}, locale));
		sb.append(messageSource.getMessage(dayText, new Object[]{days}, locale));
		
		return sb.toString();
	}
	
	/**
	 * Gets the range of date text.
	 *
	 * @param from the from
	 * @param to the to
	 * @param locale the locale
	 * @return the range of date text
	 */
	public static String getRangeOfDateText (Date from, Date to, Locale locale) {
		StringBuilder sb = new StringBuilder();
		if (from != null) {
			String fromDate = MssDateTimeUtil.convertDateToStringByLocale(from, DateTimeFormat.DATE_FORMAT_YYYYMMDD, locale);
			sb.append(messageSource.getMessage("general.vaccine.date.from", new Object[]{fromDate}, locale));
		}
		if (to != null) {
			String toDate = MssDateTimeUtil.convertDateToStringByLocale(to, DateTimeFormat.DATE_FORMAT_YYYYMMDD, locale);
			sb.append(messageSource.getMessage("general.vaccine.date.to", new Object[]{toDate}, locale));
		}
		return sb.toString();
	}
}
