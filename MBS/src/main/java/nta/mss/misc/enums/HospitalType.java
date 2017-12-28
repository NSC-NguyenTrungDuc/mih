package nta.mss.misc.enums;

/**
 * The Enum HospitalType.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum HospitalType {
	
	/** The hospital. */
	HOSPITAL(1), 
	
	/** The clinic. */
	CLINIC(2);
	
	private Integer value;
	
	/**
	 * Instantiates a new hospital type.
	 * 
	 * @param value
	 *            the value
	 */
	private HospitalType(Integer value) {
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
	 * @return the hospital type
	 */
	public static HospitalType newInstance(Integer value) {
		for (HospitalType item : HospitalType.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
