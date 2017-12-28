package nta.med.core.utils;


import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.TimeZone;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;
/**
 * 
 * @author Nguyen.Xuan.Bach
 *
 */
public class DateUtil {
	private static final Log LOGGER = LogFactory.getLog(DateUtil.class);
	
	public static final String PATTERN_DDMMYYYY_DOT = "dd.MM.yyyy";
	public static final String PATTERN_DDMMYYYY = "dd/MM/yyyy";
	public static final String PATTERN_MMDDYYYY_BLANK = "MMddyyyy";
	public static final String PATTERN_DDMMYYYYHHMMSS = "dd/MM/yyyy HH:mm:ss";
	public static final String PATTERN_MMDDYYYY = "MM/dd/yyyy";
	public static final String PATTERN_MMYYYY = "MM/yyyy";
	public static final String PATTERN_MMDDYYYY_HHMMSS = "MM/dd/yyyy HH:mm:ss";
	public static final String PATTERN_MMDDYYYY_HHMM = "MM/dd/yyyy HH:mm";
	public static final String PATTERN_YYMMDD = "yyyy/MM/dd";
	public static final String PATTERN_YYMMDD_HH_MM = "yyyy/MM/dd HH:mm";
	public static final String PATTERN_YYMMDD_BLANK = "yyyyMMdd";
	public static final String PATTERN_YYYYMMDD_BLANK = "yyyyMMdd";
	public static final String PATTERN_YYYYMMDD_HH_COLON_MM = "yyyyMMdd HH:mm";
	public static final String PATTERN_SLASH_YYYYMMDD_HH_COLON_MM = "yyyy/MM/dd HH:mm";
	public static final String PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS = "yyyy/MM/dd HH:mm:ss";
	public static final String PATTERN_FOR_GEN_ID = "MMddHHmm";
	public static final String PATTERN_YYYMMDD_HHMMSS = "yyyyMMdd HH:mm:ss";
	public static final String PATTERN_YYYMMDD_HHMMSS_FULL = "yyyy-MM-dd HH:mm:ss";
	public static final String PATTERN_YYYY_MM_DD = "yyyy-MM-dd";
	public static final String PATTERN_YYMMDD_HHMMSS_BLANK = "yyyyMMddHHmmss";
	public static final String PATTERN_CSV_FILE = "MMddyyyy_kkmmss";
	public static final String PATTERN_DDMMYYYY_BLANK = "ddMMyyyy";
	public static final String PATTERN_DDMMYYYY_HHMMSS = "dd/MM/yyyy HH:mm:ss";
	public static final String PATTERN_YYYYMM_BLANK = "yyyyMM";
	public static final String PATTERN_YYMMDD_HHMMSSS="yyyy-MM-dd HH:mm:ss.S";
	public static final String PATTERN_HHMM="HHmm";
	public static final String PATTERN_HHMMSS_COLON="HH:mm:ss";
	public static final String PATTERN_HHMMSS="HHmmss";
	public static final String PATTERN_YYYY_MM_DD_HHMM = "yyyy-MM-dd HHmm";
	/**
	 * compare date縲�br>
	 * 1: dateFrom > dateTo.<br>
	 * 0: dateFrom = dateTo<br>
	 * -1: dateFrom < dateTo
	 * 
	 * @param
	 * @return 1: dateFrom > dateTo <br>
	 *         0: dateFrom = dateTo<br>
	 *         -1: dateFrom < dateTo
	 * @throws ParseException
	 * @auth Nguyen.Xuan.Bach
	 * @CrDate Mar 1, 2012
	 * @MdDate
	 */
	public static int compare(String dateFrom, String dateTo, String pattern)
			throws ParseException {
		Date dFrom = toDate(dateFrom, pattern);
		Date dTo = toDate(dateTo, pattern);
		if (dFrom != null && dTo != null) {
			long t1 = dFrom.getTime();
			long t2 = dTo.getTime();

			if (t1 - t2 > 0) {
				return 1;
			} else if (t1 == t2) {
				return 0;
			} else
				return -1;
		} else {
			throw new ParseException(pattern, 0);
		}
	}

	/*
	 * Convert date to String follow pattern DD/MM/YYYY YYYY/MM/DD ...
	 * 
	 * @param date
	 * 
	 * @param pattern
	 * 
	 * @return
	 */
	public static String toString(Date date, String pattern) {
		if (date == null) {
			return "";
		}
		DateFormat df = new SimpleDateFormat(pattern);
		return df.format(date);
	}

	public static String toString(Calendar date, String pattern) {
		if (date == null) {
			return "";
		}
		DateFormat df = new SimpleDateFormat(pattern);
		return df.format(date.getTime());
	}
	
	public static String toString(Timestamp date, String pattern) {
		if (date == null) {
			return "";
		}
		DateFormat df = new SimpleDateFormat(pattern);
		return df.format(date.getTime());
	}

	public static Date toDate(String datetime, String pattern) {
		Date date = null;
		if (!StringUtils.isEmpty(datetime)) {
			try {
				DateFormat formatter = new SimpleDateFormat(pattern);
				formatter.setLenient(false);
				date = formatter.parse(datetime);
			} catch (ParseException e) {
				LOGGER.error("Invalid format " + datetime);
			}
		}
		return date;
	}

	public static Timestamp toTimestamp(String datetime, String pattern) {
		if (StringUtils.isEmpty(datetime))
			return null;
		Date date = null;
		try {
			DateFormat formatter = new SimpleDateFormat(pattern);
			formatter.setLenient(false);
			date = (Date) formatter.parse(datetime);
		} catch (ParseException e) {
			LOGGER.error("toTimestamp " + datetime);
		}

		if (date == null) {
			return null;
		}

		return new Timestamp(date.getTime());
	}

	private static Calendar toCalendar(String datetime, String pattern) {
		if (StringUtils.isEmpty(datetime)) {
			return null;
		}
		Calendar calendar = Calendar.getInstance();
		Date date = null;
		try {
			DateFormat formatter = new SimpleDateFormat(pattern);
			formatter.setLenient(false);
			date = (Date) formatter.parse(datetime);
		} catch (ParseException e) {
//			LOGGER.error("ERROR", e);
			LOGGER.error("parse date exception " + (datetime == null ? "null" : datetime));
		}

		if (date == null) {
			return calendar;
		}

		calendar.setTime(date);
		return calendar;
	}

	public static String convertBetweenDateFormat(String value, String sourceFormat, String destFormat) {
		if (!StringUtils.isEmpty(value)) {
			try {
				SimpleDateFormat sdfSource = new SimpleDateFormat(sourceFormat);
				Date date = sdfSource.parse(value);
			    SimpleDateFormat sdfDestination = new SimpleDateFormat(destFormat);
			    value = sdfDestination.format(date);
			    return value;
			} catch (Exception e) {
//				LOGGER.error("ERROR", e);
			}
		}
		return null;
	}

	public static boolean isValidDate(String inDate, String pattern) {

		if (inDate == null)
			return false;

		// set the format to use as a constructor argument
		SimpleDateFormat dateFormat = new SimpleDateFormat(pattern);

		if (inDate.trim().length() != dateFormat.toPattern().length())
			return false;

		dateFormat.setLenient(false);

		try {
			// parse the inDate parameter
			dateFormat.parse(inDate.trim());
		} catch (ParseException pe) {
			return false;
		}
		return true;
	}
	/**
	 * 
	 * get GMT Time
	 * @param
	 * @return
	 * @auth QuyTM
	 * @CrDate May 15, 2012
	 * @MdDate
	 */
	public static Date getGMTTime(Date date, String gmt, String pattern) {
		Date gmtDate = null;
		DateFormat converter = new SimpleDateFormat(pattern);
		converter.setTimeZone(TimeZone.getTimeZone(gmt));
		gmtDate = toDate(converter.format(date), pattern);		
		return gmtDate;
	}
	/**
	 *  get CurrentHourMinusSecond 01:01:01
	 * @param
	 * @return
	 * @throws
	 * @author nguyen.manh.hung
	 * @CrDate Oct 30, 2012
	 */
	public static String getCurrentHourMinusSecond() {
		return DateUtil.toString(new Date(), DateUtil.PATTERN_HHMMSS_COLON);
	}
	public static String getCurrentDateTime(String format) {
		DateFormat dateFormat = new SimpleDateFormat(format);
		Calendar cal = Calendar.getInstance();
		return dateFormat.format(cal.getTime());
	}
	public static String getOtherDateFromDate(String fromdate,int days, String patterm) {	
		String targetDate = "";
		Calendar calendar = toCalendar(fromdate,patterm);		
		if (calendar == null) {
			return targetDate;
		}
		calendar.add(Calendar.DAY_OF_MONTH, days);
		try {
			SimpleDateFormat formatter =  new SimpleDateFormat(patterm);
			targetDate = formatter.format(calendar.getTime());
		} catch (Exception e) {				
		}			
		return targetDate;
	}
	
	public static Date getDateTime(Date date, String pattern) {
		Date gmtDate = null;
		DateFormat converter = new SimpleDateFormat(pattern);
		gmtDate = toDate(converter.format(date), pattern);		
		return gmtDate;
	}
	
	public static String getCurrentHH24MI() {
		return DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM);
	}

	public static Date getDatePlusMMSS(Date date, String hhmm)
	{
		Calendar cal = Calendar.getInstance();
		cal.setTime(date);
		String hours = hhmm.substring(0,2);
		String minutes = hhmm.substring(2,4);
		cal.add(Calendar.HOUR, Integer.parseInt(hours));
		cal.add(Calendar.MINUTE, Integer.parseInt(minutes));

		return cal.getTime();
	}
	
	@SuppressWarnings("deprecation")
	public static String addTimeHHmm(String firstTime, String secondTime) {
		SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
		SimpleDateFormat sdf2 = new SimpleDateFormat("HHmm");
		
		Date reslt = null ;
		Date time2 = null;
		try {
			reslt = sdf.parse(firstTime);
			time2 = sdf2.parse(secondTime);
		} catch (ParseException e) {
			LOGGER.error("subTimeHHmm can not addTimeHHmm start time" + firstTime + " end time " + secondTime);
		}
		reslt.setHours( reslt.getHours() + time2.getHours());
		reslt.setMinutes( reslt.getMinutes() + time2.getMinutes());
		return sdf.format(reslt);
	}
	
	@SuppressWarnings("deprecation")
	public static Integer subTimeHHmm(String startTime, String endTime) {
		SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
		SimpleDateFormat sdf2 = new SimpleDateFormat("HHmm");
		
		Date reslt = null ;
		Date time2 = null;
		try {
			reslt = sdf.parse(endTime);
			time2 = sdf2.parse(startTime);
		} catch (ParseException e) {
			LOGGER.error("subTimeHHmm can not subtime start time" + startTime + " end time " + endTime);
			return null;
		}
		reslt.setHours(reslt.getHours() - time2.getHours());
		reslt.setMinutes(reslt.getMinutes() - time2.getMinutes());
		return reslt.getHours() * 60 + reslt.getMinutes();
	}

	public static Long subTwoDates(String startDate, String enDate, String pattern) {

		try
		{
			DateFormat df = new SimpleDateFormat(pattern);
			Date startDateTime = df.parse(startDate);
			Date endDateTime = df.parse(enDate);

			long diff = Math.abs(endDateTime.getTime() - startDateTime.getTime());
			long diffDays = diff / (24 * 60 * 60 * 1000);
			return diffDays;
		}
		catch (Exception e)
		{
			return 0L;
		}



	}

	public static Date increaseDateByOne(Date date){
		Calendar c = Calendar.getInstance();
		c.setTime(date);
		c.add(Calendar.DATE, 1);
		return c.getTime();
	}
	
	public static int getDateDiff(Date d1, Date d2) {
		if (d1 == null || d2 == null)
			return 0;
		
		return (int) ((d2.getTime() - d1.getTime()) / (1000 * 60 * 60 * 24));
	}
	
	public static Date increaseDate(Date date, int inc){
		Calendar c = Calendar.getInstance();
		c.setTime(date);
		c.add(Calendar.DATE, inc);
		return c.getTime();
	}
}
