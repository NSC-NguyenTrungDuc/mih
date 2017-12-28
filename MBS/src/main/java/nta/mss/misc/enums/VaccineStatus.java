package nta.mss.misc.enums;

public enum VaccineStatus {
	/** The inactive. */
	INACTIVE(0),
	
	/** The active. */
	ACTIVE(1);
	
	private Integer value;
	
	/**
	 * Instantiates a new active flag.
	 * 
	 * @param value
	 *            the value
	 */
	private VaccineStatus(Integer value) {
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
	public static VaccineStatus newInstance(Integer value) {
		for (VaccineStatus item : VaccineStatus.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
