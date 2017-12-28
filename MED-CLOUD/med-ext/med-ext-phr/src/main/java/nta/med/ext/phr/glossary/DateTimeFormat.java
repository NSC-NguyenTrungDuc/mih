package nta.med.ext.phr.glossary;

/**
 * The Enum DateTimeFormat.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
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
	 * To string.
	 * 
	 * @return the string
	 */
    @Override
    public String toString() {
        return text;
    }
}