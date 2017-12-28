package nta.mss.misc.common;

import nta.mss.misc.enums.DateTimeFormat;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.*;

/**
 * The Utility class about date time.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssDateTimeUtil {
	
	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(MssDateTimeUtil.class);
    
	/**
	 * Parse date from string.
	 *
	 * @param dateString the date string
	 * @param format the format
	 * @return the date
	 */
	public static Date dateFromString(String dateString, DateTimeFormat format) {
		if(org.springframework.util.StringUtils.isEmpty(dateString)){
			return null;
		}
		Date date = null;
		try {
			SimpleDateFormat sdf = new SimpleDateFormat(format.toString());
			date = sdf.parse(dateString);
		} catch (Exception e) {
			LOG.error("Date string: ", dateString);
			LOG.error("Format: ", format);
		}
		return date;
	}
	
	public static String formatDateString(String dateInput)
	{
		String outPut = "";
		try{
		String year = dateInput.substring(0,4);
		String month = dateInput.substring(4,6);
		String day = dateInput.substring(6,8);
		String hour = dateInput.substring(8,10);
		String min = dateInput.substring(10,12);
		String second = dateInput.substring(12,14);
		outPut = year+"/"+month+"/"+day + "  " + hour + ":"+min + ":" +second; 
		}
		catch(Exception e)
		{
			outPut = "";
			}
		return outPut;		
	}
	/**
	 * Format date to string.
	 *
	 * @param date the date
	 * @param format the format
	 * @return the string
	 */
	public static String dateToString(Date date, DateTimeFormat format) {
		if(date==null){
			return null;
		}
		String dateString = "";
		try {
			SimpleDateFormat sdf = new SimpleDateFormat(format.toString());
			dateString = sdf.format(date);
		} catch (Exception e) {
			return dateString;
		}
		return dateString;
	}
	
	/**
	 * Convert string date.
	 *
	 * @param stringDate the string date
	 * @param inputFormat the input format
	 * @param outputFormat the output format
	 * @return the string
	 */
	public static String convertStringDate(String stringDate, DateTimeFormat inputFormat, DateTimeFormat outputFormat) {
		String currentDate = "";
		if(stringDate == null) {
			return currentDate;
		}
		try {
			DateFormat df = new SimpleDateFormat(inputFormat.toString());
			Date date = null;
			date = df.parse(stringDate);

			if (date != null) {
				Calendar cal = Calendar.getInstance();
				cal.setTime(date);
				SimpleDateFormat sdf = new SimpleDateFormat(outputFormat.toString());
				currentDate = sdf.format(cal.getTime());
			}
		} catch (ParseException e) {
			LOG.error("Error when convert string date: " + stringDate);
			//e.printStackTrace();
		}
		return currentDate;
	}
	
	/**
	 * Convert string date time.
	 *
	 * @param stringDate the string date
	 * @param stringTime the string time
	 * @param inputFormat the input format
	 * @param outputFormat the output format
	 * @return the string
	 */
	public static String convertStringDateTime(String stringDate, String stringTime, DateTimeFormat inputFormat, DateTimeFormat outputFormat) {
		String currentDateTime = "";
		if(stringDate == null || stringTime == null) {
			return currentDateTime;
		}
		try {
			DateFormat df = new SimpleDateFormat(inputFormat.toString());
			Date date = null;
			date = df.parse(stringDate + stringTime);
			
			if (date != null) {
				Calendar cal = Calendar.getInstance();
				cal.setTime(date);
				SimpleDateFormat sdf = new SimpleDateFormat(outputFormat.toString());
				currentDateTime = sdf.format(cal.getTime());
			}
		} catch (ParseException e) {
			LOG.error("Error when convert string time");
			//e.printStackTrace();
		}
		return currentDateTime;
	}
	
	/**
	 * function compare two time with format hh:mm.
	 * 
	 * @param originalTime
	 *            the original time
	 * @param targetTime
	 *            the target time
	 * @return int
	 */
	public static long compareTime(String originalTime, String targetTime) {
		SimpleDateFormat sdf = new SimpleDateFormat(DateTimeFormat.TIME_FORMAT_HH_MM_DEFAULT.toString());
		long diff = 0;
		try {
			Date a = sdf.parse(originalTime);
			Date b = sdf.parse(targetTime);

			diff = a.getTime() - b.getTime();
		} catch (ParseException e) {
			LOG.error("Error when compare string time");
			//e.printStackTrace();
		}
		return diff;
	}

	/**
	 * function compare two time with format hhmm.
	 * 
	 * @param originalTime
	 *            the original time
	 * @param targetTime
	 *            the target time
	 * @return int
	 */
	public static long compareTimeFormatHHmm(String originalTime, String targetTime) {
		long diff = 0;
		try {
			diff = Long.valueOf(originalTime) - Long.valueOf(targetTime);
		} catch (Exception e) {
			LOG.error("Error when compare string time");
			//e.printStackTrace();
		}
		return diff;
	}

	
	/**
	 * concatenate date and time to new string with underscore.
	 * 
	 * @param dateString
	 *            the date string
	 * @param timeString
	 *            the time string
	 * @return the string
	 */
	public static String concatenateDateTime(String dateString, String timeString) {
		return dateString + "_" + timeString;
	}
	
	/**
	 * Convert string date by locale.
	 *
	 * @param date            the date
	 * @param sourceFormat            the source format
	 * @param locale            the locale
	 * @return the string
	 */
	public static String convertStringDateByLocale(String date, DateTimeFormat sourceFormat, Locale locale) {
		try {
			DateFormat sourceFormatter = new SimpleDateFormat(sourceFormat.toString());
			Date sourceDate = sourceFormatter.parse(date);
			DateFormat df = DateFormat.getDateInstance(DateFormat.FULL, locale);
			if (locale.toString().equals("vi")) {
				String[] ArrMonthString = { "thÃ¡ng má»™t", "thÃ¡ng hai", "thÃ¡ng ba", "thÃ¡ng tÆ°", "thÃ¡ng nÄƒm", "thÃ¡ng sÃ¡u",
						"thÃ¡ng báº£y", "thÃ¡ng tÃ¡m", "thÃ¡ng chÃ­n", "thÃ¡ng mÆ°á»�i", "thÃ¡ng mÆ°á»�i má»™t", "thÃ¡ng mÆ°á»�i hai" };
				String ResultTmp = df.format(sourceDate);
				for (int i = 0; i <= ArrMonthString.length - 3; i++) {
					if (ResultTmp.indexOf("mÆ°á»�i hai") != -1) {
						return ResultTmp.replace("thÃ¡ng mÆ°á»�i hai", "thÃ¡ng 12");
					} else if (ResultTmp.indexOf("mÆ°á»�i má»™t") != -1) {
						return ResultTmp.replace("thÃ¡ng mÆ°á»�i má»™t", "thÃ¡ng 11");
					} else if (ResultTmp.indexOf(ArrMonthString[i]) != -1) {
						return ResultTmp.replace(ArrMonthString[i], "thÃ¡ng " + (i + 1));
					}
					
				}
			}

			return df.format(sourceDate);
		} catch (ParseException pe) {
			LOG.warn("Error while converting date.", pe);
			return StringUtils.EMPTY;
		}
	}
	
	/**
	 * Convert date to string by locale.
	 *
	 * @param date the date
	 * @param sourceFormat the source format
	 * @param locale the locale
	 * @return the string
	 */
	public static String convertDateToStringByLocale(Date date, DateTimeFormat sourceFormat, Locale locale) {
		DateFormat df = DateFormat.getDateInstance(DateFormat.FULL, locale);
		return df.format(date);
	}
	
	/**
	 * Convert string time by locale.
	 *
	 * @param time            the time
	 * @param sourceFormat            the source format
	 * @param locale            the locale
	 * @return the string
	 */
	public static String convertStringTimeByLocale(String time, DateTimeFormat sourceFormat, Locale locale) {
		try {
 			DateFormat sourceFormatter = new SimpleDateFormat(sourceFormat.toString());
			Date sourceDate = sourceFormatter.parse(time);
			if (locale.equals(new Locale("ja"))) {
				DateFormat df = DateFormat.getTimeInstance(DateFormat.FULL, locale);
				String formattedTime = df.format(sourceDate);
				// remove time zone and seconds in result
				return formattedTime.substring(0, formattedTime.length() - 7);
			}
			else {
				DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, locale);
				return df.format(sourceDate);
			}
		} catch (ParseException pe) {
			LOG.warn("Error while converting time.", pe);
			return StringUtils.EMPTY;
		}
	}
	
	/**
	 * Gets the first date of next month.
	 *
	 * @param nowDate the now date
	 * @return the first date of next month
	 */
	public static Date getFirstDateOfNextMonth(Date nowDate) {
		Calendar c = Calendar.getInstance();
	    c.setTime(nowDate);
	    c.add(Calendar.MONTH, 1);
	    c.set(Calendar.DATE, c.getMinimum(Calendar.DATE));
	    Date nextDate = c.getTime();
	    return nextDate;
	}
	
	/**
	 * Gets the month name.
	 *
	 * @param date the date
	 * @param locale the locale
	 * @return the month name
	 */
	public static String getMonthName(Date date, Locale locale) {
		DateFormat formatter = new SimpleDateFormat("MMMM", locale);
		Calendar c = Calendar.getInstance();
		c.setTime(date);
	    return formatter.format(c.getTime());
	}
	
	/**
	 * Gets the days in week map between.
	 *
	 * @param startDateStr the start date str
	 * @param endDateStr the end date str
	 * @return the days in week map between
	 * @throws ParseException the parse exception
	 */
	public static Map<String, List<String>> getDaysInWeekMapBetween(String startDateStr, String endDateStr) throws ParseException {
		try{
			Map<String, List<String>> result = new HashMap<String, List<String>>();
			List<String> formattedDateList;
			String dayInWeek;
			DateFormat formatter = new SimpleDateFormat("yyyyMMdd");
			Date startDate = (Date)formatter.parse(startDateStr); 
			Date endDate = (Date)formatter.parse(endDateStr);
			
			// start date calendar
			Calendar cal = Calendar.getInstance();
			cal.setTime(startDate);
			// end date calendar
			Calendar lastDate = Calendar.getInstance();
			lastDate.setTime(endDate);
			lastDate.add(Calendar.DATE, 1);
			while (cal.before(lastDate)) {
				Integer day = cal.get(Calendar.DAY_OF_WEEK) == 1 ? 7 : cal.get(Calendar.DAY_OF_WEEK) - 1;
				dayInWeek = String.valueOf(day);
				if(result.containsKey(dayInWeek)) {
					formattedDateList = result.get(dayInWeek);
				}
				else {
					formattedDateList = new ArrayList<String>();
				}
				formattedDateList.add(formatter.format(cal.getTime()));
				result.put(dayInWeek, formattedDateList);
				cal.add(Calendar.DATE, 1);		    
			}
			return result;
		}
		catch (ParseException pe) {
			LOG.warn("Error while converting date.", pe);
			return null;
		}
	}
	
	/**
	 * Compare date string.
	 *
	 * @param beforeDateStr the before date str
	 * @param afterDateStr the after date str
	 * @return true, if successful
	 */
	public static boolean compareDateString (String beforeDateStr, String afterDateStr) {
		try {
			DateFormat formatter = new SimpleDateFormat("yyyyMMdd");
			Date beforeDate = (Date)formatter.parse(beforeDateStr); 
			Date afterDate = (Date)formatter.parse(afterDateStr);
			Calendar beforeDateCal = Calendar.getInstance();
			beforeDateCal.setTime(beforeDate);
			Calendar afterDateCal = Calendar.getInstance();
			afterDateCal.setTime(afterDate);
			if(beforeDateCal.before(afterDateCal) || beforeDateCal.equals(afterDateCal)) {
				return true;
			}
			else {
				return false;
			}
		} catch (ParseException pe) {
			LOG.warn("Error while comparing dates.", pe);
			return false;
		}
	}
	
	/**
	 * Gets the date from month and year.
	 *
	 * @param month the month
	 * @param year the year
	 * @param isFirstDateInMonth the is first date in month
	 * @return the date from month and year
	 */
	public static String getDateFromMonthAndYear (Integer month, Integer year, boolean isFirstDateInMonth) {
		Calendar calendar = Calendar.getInstance();
	    calendar.set(year, month - 1, 1);
	    if (!isFirstDateInMonth) {
	    	calendar.set(Calendar.DATE, calendar.getActualMaximum(Calendar.DATE));
	    }
	    Date date = calendar.getTime();
	    DateFormat DATE_FORMAT = new SimpleDateFormat(DateTimeFormat.DATE_FORMAT_YYYYMMDD.toString());
	    return DATE_FORMAT.format(date);
	}
	
	/**
	 * Gets the date between.
	 *
	 * @param startDateStr the start date str
	 * @param endDateStr the end date str
	 * @return the date between
	 */
	public static List<String> getDateBetween (String startDateStr, String endDateStr) {
		try{
			List<String> result = new ArrayList<String>();;
			DateFormat formatter = new SimpleDateFormat(DateTimeFormat.DATE_FORMAT_YYYYMMDD.toString());
			DateFormat extendFormatter = new SimpleDateFormat(DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND.toString());
			Date startDate = (Date)formatter.parse(startDateStr); 
			Date endDate = (Date)formatter.parse(endDateStr);
			
			// start date calendar
			Calendar cal = Calendar.getInstance();
			cal.setTime(startDate);
			// end date calendar
			Calendar lastDate = Calendar.getInstance();
			lastDate.setTime(endDate);
			lastDate.add(Calendar.DATE, 1);
			while (cal.before(lastDate)) {
				result.add(extendFormatter.format(cal.getTime()));
				cal.add(Calendar.DATE, 1);		    
			}
			return result;
		} catch (ParseException pe) {
			LOG.warn("Error while get dates in month.", pe);
			return null;
		}
	}
	
	/**
	 * Gets the first day of week.
	 *
	 * @param isFirstDay the is first day
	 * @param currentDateStr the current date str
	 * @param format the format
	 * @return the first day of week
	 */
	public static String getFirstDayOfWeek (Boolean isFirstDay, String currentDateStr, DateTimeFormat format) {
		try{
		DateFormat formatter = new SimpleDateFormat(DateTimeFormat.DATE_FORMAT_YYYYMMDD.toString());
		Date currentDate = (Date)formatter.parse(currentDateStr);
		
		Calendar cal = Calendar.getInstance();
		cal.setTime(currentDate);
		cal.setFirstDayOfWeek(Calendar.SUNDAY);
		cal.set(Calendar.DAY_OF_WEEK, cal.getFirstDayOfWeek());
		if (!isFirstDay) {
			cal.add(Calendar.DATE, 6);
		}
		return formatter.format(cal.getTime());
		} catch (ParseException pe) {
			LOG.warn("Error while get first day of week.", pe);
			return null;
		}
	}
	
	/**
	 * Gets the time start date.
	 *
	 * @param fromDate the from date
	 * @return the time start date
	 */
	public static Date getTimeStartDate(Date fromDate) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(fromDate);
		calendar = setToStandardTime(calendar);
		return calendar.getTime();
	}
	
	/**
	 * Gets the time end date.
	 *
	 * @param toDate the to date
	 * @return the time end date
	 */
	public static Date getTimeEndDate(Date toDate) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(toDate);
		calendar.add(Calendar.DAY_OF_YEAR, 1);
		calendar.add(Calendar.SECOND, -1);
		return calendar.getTime();
	}
	
	/**
	 * Gets the current time.
	 *
	 * @return the current time
	 */
	public static String getCurrentTime(DateTimeFormat format) {
		DateFormat dateFormat = new SimpleDateFormat(format.toString());
		Calendar cal = Calendar.getInstance();
		return dateFormat.format(cal.getTime());
	}
	
	public static Date currentDate () {
		Calendar c = Calendar.getInstance();
		return c.getTime();
	}
	
	
	
	/**
	 * Convert string to timestamp.
	 *
	 * @param valueDate the value date
	 * @param format the format
	 * @return the timestamp
	 */
	public static Timestamp convertStringToTimestamp(String valueDate, DateTimeFormat format) {
		if (StringUtils.isBlank(valueDate)) {
			return null;
		}
		try {
			DateFormat formatter = new SimpleDateFormat(format.toString());
			Date date = (Date)formatter.parse(valueDate); 
			
			Timestamp timestamp = new java.sql.Timestamp(date.getTime());
			return timestamp;
		} catch (Exception e) {
			return null;
		}
	}
	
	/**
	 * Compare date.
	 *
	 * @param beforeDate the before date
	 * @param afterDate the after date
	 * @return the int
	 */
	public static int compareDate (Date beforeDate, Date afterDate) {
		Calendar beforeDateCal = Calendar.getInstance();
		beforeDateCal.setTime(beforeDate);
		beforeDateCal = setToStandardTime(beforeDateCal);
		
		Calendar afterDateCal = Calendar.getInstance();
		afterDateCal.setTime(afterDate);
		afterDateCal = setToStandardTime(afterDateCal);
		
		if (beforeDateCal.before(afterDateCal)) {
			return -1;
		}
		else if (beforeDateCal.equals(afterDateCal)){
			return 0;
		}
		return 1;
	}
	
	/**
	 * Gets the number of date between date.
	 *
	 * @param beforeDate the before date
	 * @param afterDate the after date
	 * @return the number of date between date
	 */
	public static int getNumberOfDateBetweenDate (Date beforeDate, Date afterDate) {
		Calendar beforeDateCal = Calendar.getInstance();
		beforeDateCal.setTime(beforeDate);
		beforeDateCal = setToStandardTime(beforeDateCal);
		Calendar afterDateCal = Calendar.getInstance();
		afterDateCal.setTime(afterDate);
		afterDateCal = setToStandardTime(afterDateCal);
		return (int)( (afterDateCal.getTimeInMillis() - beforeDateCal.getTimeInMillis()) / (1000 * 60 * 60 * 24));
	}
	
	/**
	 * Adds the month to date.
	 *
	 * @param date the date
	 * @param months the months
	 * @return the date
	 */
	public static Date addMonthToDate (Date date, Integer months) {
		Calendar childBirthDayCal = Calendar.getInstance();
		childBirthDayCal.setTime(date);
		childBirthDayCal.add(Calendar.MONTH, months);
		return childBirthDayCal.getTime();
	}
	
	/**
	 * Adds the day to date.
	 *
	 * @param date the date
	 * @param days the days
	 * @return the date
	 */
	public static Date addDayToDate (Date date, Integer days) {
		Calendar childBirthDayCal = Calendar.getInstance();
		childBirthDayCal.setTime(date);
		childBirthDayCal.add(Calendar.DATE, days);
		return childBirthDayCal.getTime();
	}
	
	/**
	 * Sets the to standard time.
	 *
	 * @param cal the cal
	 * @return the calendar
	 */
	public static Calendar setToStandardTime(Calendar cal) {
		cal.set(Calendar.HOUR_OF_DAY, 0);
		cal.set(Calendar.MINUTE, 0);
		cal.set(Calendar.SECOND, 0);
		cal.set(Calendar.MILLISECOND, 0);
		return cal;
	}
	
	/**
	 * Convert timestamp to string.
	 *
	 * @param dateTimestamp the date timestamp
	 * @param format the format
	 * @return the string
	 */
	public static String convertTimestampToString(Timestamp dateTimestamp, DateTimeFormat format) {
		String dateString = "";
		try {
			if (dateTimestamp != null) {
				Date date = new Date(dateTimestamp.getTime());
				dateString = dateToString(date, format);
			}
			return dateString;
		} catch (Exception e) {
			return null;
		}
	}
	
	public static String convertBetweenDateFormat(String value, DateTimeFormat sourceFormat, DateTimeFormat destFormat) {
		if (!StringUtils.isEmpty(value)) {
			try {
				SimpleDateFormat sdfSource = new SimpleDateFormat(sourceFormat.toString());
				Date date = sdfSource.parse(value);
			    SimpleDateFormat sdfDestination = new SimpleDateFormat(destFormat.toString());
			    value = sdfDestination.format(date);
			    return value;
			} catch (Exception e) {
				e.printStackTrace();
				return null;
			}
		}
		return null;
	}

	/**
	 * @param avgTime
	 * @param start
	 * @param end
	 * @return
	 */
	public static List<String> timeList(String avgTime, String start, String end) {
		List<String> result = new ArrayList<String>();
		if (StringUtils.isNotBlank(start) && StringUtils.isNotBlank(end)) {
			LocalTime startLt = LocalTime.parse(start, DateTimeFormatter.ofPattern("HHmm"));
			LocalDateTime startLtDateTime = LocalDateTime.parse("2016/01/01" + " " + start, DateTimeFormatter.ofPattern("yyyy/MM/dd HHmm"));
			LocalDateTime endLtDateTime = LocalDateTime.parse("2016/01/01" + " " + end, DateTimeFormatter.ofPattern("yyyy/MM/dd HHmm"));
			LocalTime tmpLt = startLt;
			while (startLtDateTime.isBefore(endLtDateTime)) {
				result.add(tmpLt.format(DateTimeFormatter.ofPattern("HHmm")));
				tmpLt = tmpLt.plusMinutes(Long.valueOf(avgTime));
				startLtDateTime= startLtDateTime.plusMinutes(Long.valueOf(avgTime));
			}
		}
		return result;
	}
}
