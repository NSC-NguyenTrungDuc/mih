package nta.med.ext.phr.glossary;

/**
 * The Enum MailCode.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum MailCode {
	
	/** The booking new accepted. */
	BOOKING_NEW_ACCEPTED("BOOKING_NEW_ACCEPTED"),
	
	/** The booking new completed. */
	BOOKING_NEW_COMPLETED("BOOKING_NEW_COMPLETED"),
	
	/** The booking change. */
	BOOKING_CHANGE("BOOKING_CHANGE"),
	
	/** The booking change accepted. */
	BOOKING_CHANGE_ACCEPTED("BOOKING_CHANGE_ACCEPTED"),
	
	/** The booking change completed. */
	BOOKING_CHANGE_COMPLETED("BOOKING_CHANGE_COMPLETED"),
	
	/** The cancel reservation. */
	CANCEL_RESERVATION("CANCEL_RESERVATION"),
	
	/** The change doctor. */
	CHANGE_DOCTOR("CHANGE_DOCTOR"),
	
	/** The verify account. */
	VERIFY_ACCOUNT("VERIFY_ACCOUNT"),

	/** The forget password. */
	FORGET_PASSWORD("FORGET_PASSWORD"),
	
	BOOKING_VACCINE_NEW_ACCEPTED("BOOKING_VACCINE_NEW_ACCEPTED");
	
	private final String text;

    /**
     * Instantiates a new mail code.
     *
     * @param text the text
     */
    private MailCode(final String text) {
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
