package nta.med.core.glossary;

public enum ReservationStatus {

	/** The booking accepted. */
	BOOKING_ACCEPTED("0"),

	/** The booking completed. */
	BOOKING_COMPLETED("1"),

	/** The health checking. */
	HEALTH_CHECKING("2"),

	/** The finish health check. */
	FINISH_HEALTH_CHECK("3"),

	/** The patient pending. */
	PATIENT_PENDING("4"),

	/** The cancelled. */
	CANCELLED("5");

	private String value;

	ReservationStatus(String value) {
		this.value = value;
	}

	public static ReservationStatus get(String value) {
		for (ReservationStatus reservationStatus : ReservationStatus.values()) {
			if (reservationStatus.value.equals(value))
				return reservationStatus;
		}
		return null;
	}

	public String getValue() {
		return value;
	}

}
