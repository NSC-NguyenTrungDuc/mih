package nta.med.core.glossary;


public enum MailSendingStatus {
	
	/** The inprogress. */
	INPROGRESS("0"),
	
	/** The success. */
	SUCCESS("1"),
	
	/** The fail. */
	FAIL("2");
	
	private String value;
	
	/**
	 * Instantiates a new mail sending status.
	 * 
	 * @param value
	 *            the value
	 */
	private MailSendingStatus(String value) {
		this.value = value;
	}
	
	/**
	 * To int.
	 * 
	 * @return the String
	 */
	public String getValue() {
		return this.value;
	}
	
	/**
	 * New instance.
	 * 
	 * @param value
	 *            the value
	 * @return the mail sending status
	 */
	public static MailSendingStatus newInstance(String value) {
		for (MailSendingStatus item : MailSendingStatus.values()) {
			if (item.equals(value)) {
				return item;
			}
		}
		return null;
	}
}
