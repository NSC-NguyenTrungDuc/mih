package nta.mss.misc.enums;

/**
 * The Enum JuniorFlag.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum JuniorFlag {
	
	/** The senior. */
	SENIOR(0), 
	
	/** The junior. */
	JUNIOR(1);
	
	private Integer value;
	
	/**
	 * Instantiates a new junior flag.
	 * 
	 * @param value
	 *            the value
	 */
	private JuniorFlag(Integer value) {
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
	 * @return the junior flag
	 */
	public static JuniorFlag newInstance(Integer value) {
		for (JuniorFlag item : JuniorFlag.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
