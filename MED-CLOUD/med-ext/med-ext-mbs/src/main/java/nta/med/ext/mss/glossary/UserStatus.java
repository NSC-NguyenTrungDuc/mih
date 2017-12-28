package nta.med.ext.mss.glossary;

// TODO: Auto-generated Javadoc
/**
 * The Enum UserStatus.
 *
 * @author MinhLS
 * @crtDate 2015/01/26
 */
public enum UserStatus {
	
	/** The register accepted. */
	REGISTER_ACCEPTED(0),
	
	/** The register completed. */
	REGISTER_COMPLETED(1);
	
	/** The status. */
	private Integer status;
	
	/**
	 * Instantiates a new user status.
	 *
	 * @param status the status
	 */
	private UserStatus(Integer status) {
		this.status = status;
	}

	/**
	 * Gets the single instance of UserStatus.
	 *
	 * @param status the status
	 * @return single instance of UserStatus
	 */
	public UserStatus getInstance(Integer status) {
		for (UserStatus userStatus : UserStatus.values()) {
			if (userStatus.toInt().equals(status)) {
				return userStatus;
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
