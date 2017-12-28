package nta.med.ext.phr.glossary;

/**
 * The Enum SessionMode.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum SessionMode {
	
	/** The front mode. */
	FRONT_MODE(1),
	
	/** The back mode. */
	BACK_MODE(2);
	
	private Integer mode;
	
	/**
	 * Instantiates a new session mode.
	 * 
	 * @param mode
	 *            the mode
	 */
	private SessionMode(Integer mode) {
		this.mode = mode;
	}
	
	/**
	 * Gets the single instance of SessionMode.
	 * 
	 * @param mode
	 *            the mode
	 * @return single instance of SessionMode
	 */
	public static SessionMode getInstance(Integer mode) {
		for (SessionMode sessionMode : SessionMode.values()) {
			if (sessionMode.toInt().equals(mode)) {
				return sessionMode;
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
		return this.mode;
	}
}
