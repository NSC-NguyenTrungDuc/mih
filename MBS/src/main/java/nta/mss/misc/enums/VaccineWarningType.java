package nta.mss.misc.enums;

/**
 * The Enum VaccineWarningType.
 *
 * @author MinhLS
 * @crtDate 2015/02/03
 */
public enum VaccineWarningType {
	
	/** The support fee. */
	SUPPORT_FEE(0),
	
	/** The limit age. */
	LIMIT_AGE(1);
	
	/** The type. */
	private Integer type;
	
	/**
	 * Instantiates a new vaccine warning type.
	 *
	 * @param type the type
	 */
	private VaccineWarningType(Integer type) {
		this.type = type;
	}

	/**
	 * Gets the single instance of VaccineWarningType.
	 *
	 * @param type the type
	 * @return single instance of VaccineWarningType
	 */
	public VaccineWarningType getInstance(Integer type) {
		for (VaccineWarningType vaccineWarningType : VaccineWarningType.values()) {
			if (vaccineWarningType.toInt().equals(type)) {
				return vaccineWarningType;
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
		return this.type;
	}
	
}
