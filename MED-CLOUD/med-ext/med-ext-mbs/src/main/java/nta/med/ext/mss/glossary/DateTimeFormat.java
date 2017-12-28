package nta.med.ext.mss.glossary;


import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public enum DateTimeFormat {
	
	/** The time format HH:mm. */
	TIME_FORMAT_HH_MM_DEFAULT("HH:mm"),
	
	/** The time format HHmm. */
	TIME_FORMAT_HH_MM("HHmm"),
	
	/** The date time format yyyyMMdd. */
	DATE_FORMAT_YYYYMMDD("yyyyMMdd"),
	
	/** The date format yyyy/mm/dd extend. */
	DATE_FORMAT_YYYYMMDD_EXTEND("yyyy/MM/dd"),
	
	/** The date time format yyyyMMddHHmm. */
	DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM("yyyyMMddHHmm"),

	/** The date time format blank yyyy/mm/dd hh:mm extend. */
	DATE_TIME_FORMAT_BLANK_YYYYMMDDHHMM_EXTEND("yyyy/MM/dd HH:mm"),
	
	/** The date time format mm/dd. */
	DATE_TIME_FORMAT_MMDD("MM/dd"),
	
	/** The date time format mm/dd/yyyy extend. */
	DATE_TIME_FORMAT_MMDDYYYY_EXTEND("MM/dd/yyyy"),
	
	/** The date time format timestamp. */
	DATE_TIME_FORMAT_TIMESTAMP("yyyy-MM-dd hh:mm:ss.SSS"),
	
	/** The date time format yyyymmdd hhmm. */
	DATE_TIME_FORMAT_YYYYMMDD_HHMMSS("yyyyMMdd_HHmmss");
	
    private final String text;

	private static final Logger LOG = LogManager.getLogger(DateTimeFormat.class);

    /**
	 * Instantiates a new date time format.
	 * 
	 * @param text
	 *            the text
	 */
    private DateTimeFormat(final String text) {
        this.text = text;
    }
	
	/**
	 *  Convert string date by locale
	 * @param date
	 * @param sourceFormat
	 * @param locale
	 * @return
	 */
	public String convertStringDateByLocale(String date, Locale locale) {
		try {
			DateFormat sourceFormatter = new SimpleDateFormat(text);
			Date sourceDate = sourceFormatter.parse(date);
			DateFormat df = DateFormat.getDateInstance(DateFormat.FULL, locale);
			return df.format(sourceDate);
		} catch (ParseException pe) {
			LOG.warn("Error while converting date.", pe);
			return StringUtils.EMPTY;
		}
	}
	
	/**
	 * Convert string time by locale.
	 *
	 * @param time            the time
	 * @param sourceFormat            the source format
	 * @param locale            the locale
	 * @return the string
	 */
	public String convertStringTimeByLocale(String time, Locale locale) {
		try {
 			DateFormat sourceFormatter = new SimpleDateFormat(text);
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
	 * To string.
	 * 
	 * @return the string
	 */
    @Override
    public String toString() {
        return text;
    }
}