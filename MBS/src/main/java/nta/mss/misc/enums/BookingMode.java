package nta.mss.misc.enums;

/**
 * The Enum BookingMode.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum BookingMode {
	
	/** The new booking. */
	NEW_BOOKING(1),
	
	/** The re examination. */
	RE_EXAMINATION(2),
	/**
	 * The new booking online
	 */
	NEW_BOOKING_ONLINE(3),
	/**
	 * The re examination online
	 */
	RE_EXAMINATION_ONLINE(4);
	
	private Integer value;
	
	/**
	 * Instantiates a new booking mode.
	 * 
	 * @param value
	 *            the value
	 */
	private BookingMode(Integer value) {
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
	 * @return the booking mode
	 */
	public static BookingMode newInstance(Integer value) {
		for (BookingMode item : BookingMode.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
