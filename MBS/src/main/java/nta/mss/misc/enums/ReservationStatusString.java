package nta.mss.misc.enums;

/**
 * The Enum DateTimeFormat.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum ReservationStatusString {
	
	/** The booking accepted. */
	BOOKING_NEW("general.reservation.status.new"),
	
	/** The booking completed. */
	BOOKING_COMPLETED("general.reservation.status.completed"),
	
	/** The health checking. */
	HEALTH_CHECKING("general.reservation.status.checking"),
	
	/** The finish health check. */
	FINISH_HEALTH_CHECK("general.reservation.status.checked"),
	
	/** The patient pending. */
	PATIENT_PENDING("general.reservation.status.pending"),
	
	/** The cancelled. */
	CANCELLED("general.reservation.status.cancel");

    private final String text;

    /**
	 * Instantiates a new date time format.
	 * 
	 * @param text
	 *            the text
	 */
    private ReservationStatusString(final String text) {
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