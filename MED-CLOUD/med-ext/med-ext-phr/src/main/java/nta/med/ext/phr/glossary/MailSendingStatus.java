package nta.med.ext.phr.glossary;

/**
 * The Enum MailSendingStatus.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum MailSendingStatus {
	
	/** The inprogress. */
	INPROGRESS(0),
	
	/** The success. */
	SUCCESS(1),
	
	/** The fail. */
	FAIL(2);
	
	private Integer value;
	
	/**
	 * Instantiates a new mail sending status.
	 * 
	 * @param value
	 *            the value
	 */
	private MailSendingStatus(Integer value) {
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
	 * @return the mail sending status
	 */
	public static MailSendingStatus newInstance(Integer value) {
		for (MailSendingStatus item : MailSendingStatus.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
