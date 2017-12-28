package nta.mss.misc.enums;

/**
 * The Enum DoctorScheduleField.
 * 
 * @author MinhLS
 * @crtDate Aug 5, 2014
 */
public enum DoctorScheduleField {

	/** The check date. */
	CHECK_DATE("checkDate"),

	/** The start time. */
	START_TIME("startTime"),

	/** The doctor id. */
	DOCTOR_ID("doctorId"),

	/** The kpi. */
	KPI("kpi");

	/** The text. */
	private final String text;

	/**
	 * Instantiates a new doctor schedule field.
	 *
	 * @param text the text
	 */
	private DoctorScheduleField(final String text) {
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
