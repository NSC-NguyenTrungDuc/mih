package nta.mss.misc.enums;

/**
 * The Enum MailTemplateType.
 */
public enum SendType {
	
	/** The send mail. */
	MAIL(1), 
	/** The send sms. */
	SMS(2);

	/** The value. */
	private Integer value;

	/**
	 * Instantiates a new active flag.
	 * 
	 * @param value
	 *            the value
	 */
	private SendType(Integer value) {
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
	public static SendType newInstance(Integer value) {
		for (SendType item : SendType.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
