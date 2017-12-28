package nta.mss.misc.enums;

// TODO: Auto-generated Javadoc
/**
 * The Enum UserStatus.
 *
 * @author MinhLS
 * @crtDate 2015/01/26
 */
public enum VaccineHistoryStatus {
	
	/** The recommended. */
	RECOMMENDED(0),
	
	/** The booked inside. */
	BOOKED_INSIDE(1),
	
	/** The booked outside. */
	BOOKED_OUTSIDE(2),
	
	/** The completed. */
	COMPLETED(3);
		
	/** The status. */
	private Integer status;
	
	/**
	 * Instantiates a new user status.
	 *
	 * @param status the status
	 */
	private VaccineHistoryStatus(Integer status) {
		this.status = status;
	}

	/**
	 * Gets the single instance of UserStatus.
	 *
	 * @param status the status
	 * @return single instance of UserStatus
	 */
	public VaccineHistoryStatus getInstance(Integer status) {
		for (VaccineHistoryStatus vaccineHistoryStatus : VaccineHistoryStatus.values()) {
			if (vaccineHistoryStatus.toInt().equals(status)) {
				return vaccineHistoryStatus;
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
