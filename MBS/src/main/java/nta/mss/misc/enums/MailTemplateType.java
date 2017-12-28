package nta.mss.misc.enums;

/**
 * The Enum MailTemplateType.
 */
public enum MailTemplateType {
	
	/** The system mail. */
	SYSTEM_MAIL(0), 
	/** The customize mail. */
	CUSTOMIZE_MAIL(1);

	/** The value. */
	private Integer value;

	/**
	 * Instantiates a new active flag.
	 * 
	 * @param value
	 *            the value
	 */
	private MailTemplateType(Integer value) {
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
	public static MailTemplateType newInstance(Integer value) {
		for (MailTemplateType item : MailTemplateType.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
