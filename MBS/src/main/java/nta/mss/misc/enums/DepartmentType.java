package nta.mss.misc.enums;

/**
 * The Enum DepartmentType.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum DepartmentType {
	
	/** The internal. */
	INTERNAL(0), 
	
	/** The surgery. */
	SURGERY(1),
	
	/** The vaccine. */
	VACCINE(2),
	
	/** The new born. */
	NEWBORNS(3);
	
	private Integer value;
	
	/**
	 * Instantiates a new department type.
	 * 
	 * @param value
	 *            the value
	 */
	private DepartmentType(Integer value) {
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
	 * @return the department type
	 */
	public static DepartmentType newInstance(Integer value) {
		for (DepartmentType item : DepartmentType.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
