package nta.mss.misc.enums;

/**
 * The Enum CalendarStatus. 
 *
 * @author MinhLS
 * @crtDate Sep 23, 2014
 */
public enum CalendarStatus {
	
	/** The full. */
	FULL(0),
	
	/** The half full. */
	HALF_FULL(1),
	
	/** The none. */
	NONE(2);
	
	/** The value. */
	private Integer value;
	
	/**
	 * Instantiates a new active flag.
	 * 
	 * @param value
	 *            the value
	 */
	private CalendarStatus(Integer value) {
		this.value = value;
	}
	
	/**
	 * To int.
	 * 
	 * @return the integer
	 */
	public Integer toInt() {
		return this.value;
	}
	
	/**
	 * New instance.
	 * 
	 * @param value
	 *            the value
	 * @return the active flag
	 */
	public static CalendarStatus newInstance(Integer value) {
		for (CalendarStatus item : CalendarStatus.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
