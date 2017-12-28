package nta.mss.misc.enums;

public enum GenderChild {
	/** The inactive. */
	FEMALE("0"),
	
	/** The active. */
	MALE("1");
	
	/** The text. */
	private final String gender;

	/**
	 * Instantiates a new doctor schedule field.
	 *
	 * @param text the text
	 */
	private GenderChild(final String gender) {
		this.gender = gender;
	}

	/**
	 * To string.
	 *
	 * @return the string
	 */
	@Override
	public String toString() {
		return gender;
	}
}
