package nta.mss.misc.enums;

/**
 * The Enum ReservationStatus.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum ReservationStatus {
	
	/** The booking accepted. */
	BOOKING_ACCEPTED(0),
	
	/** The booking completed. */
	BOOKING_COMPLETED(1),
	
	/** The health checking. */
	HEALTH_CHECKING(2),
	
	/** The finish health check. */
	FINISH_HEALTH_CHECK(3),
	
	/** The patient pending. */
	PATIENT_PENDING(4),
	
	/** The cancelled. */
	CANCELLED(5);
	
	private Integer status;
	
	/**
	 * Instantiates a new reservation status.
	 * 
	 * @param status
	 *            the status
	 */
	private ReservationStatus(Integer status) {
		this.status = status;
	}

	/**
	 * Gets the single instance of ReservationStatus.
	 * 
	 * @param status
	 *            the status
	 * @return single instance of ReservationStatus
	 */
	public ReservationStatus getInstance(Integer status) {
		for (ReservationStatus revervationStt : ReservationStatus.values()) {
			if (revervationStt.toInt().equals(status)) {
				return revervationStt;
			}
		}
		return null;
	}
	
	/**
	 * To int.
	 * 
	 * @return the integer
	 */
	public Integer toInt() {
		return this.status;
	}
	
}
