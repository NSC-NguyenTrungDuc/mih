package nta.med.ext.phr.glossary;

/**
 * The Enum ActiveFlag.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum ActiveFlag {

	/** The inactive. */
	INACTIVE(0),

	/** The active. */
	ACTIVE(1);

	private Integer value;

	/**
	 * Instantiates a new active flag.
	 * 
	 * @param value
	 *            the value
	 */
	private ActiveFlag(Integer value) {
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
	public static ActiveFlag newInstance(Integer value) {
		for (ActiveFlag item : ActiveFlag.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
