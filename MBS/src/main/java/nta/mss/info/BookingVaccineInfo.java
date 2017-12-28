package nta.mss.info;

/**
 * The Class BookingVaccineInfo.
 */
public class BookingVaccineInfo {
	
	/** The user id. */
	private String userId;
	
	/** The dept id. */
	private String deptId;
	
	/** The child id. */
	private String childId;
	
	/** The vaccine id. */
	private String vaccineId;
	
	/**
	 * Instantiates a new booking vaccine info.
	 */
	public BookingVaccineInfo() {
		
	}

	/**
	 * Gets the user id.
	 *
	 * @return the user id
	 */
	public String getUserId() {
		return userId;
	}


	/**
	 * Sets the user id.
	 *
	 * @param userId the new user id
	 */
	public void setUserId(String userId) {
		this.userId = userId;
	}


	/**
	 * Gets the child id.
	 *
	 * @return the child id
	 */
	public String getChildId() {
		return childId;
	}


	/**
	 * Sets the child id.
	 *
	 * @param childId the new child id
	 */
	public void setChildId(String childId) {
		this.childId = childId;
	}


	/**
	 * Gets the vaccine id.
	 *
	 * @return the vaccine id
	 */
	public String getVaccineId() {
		return vaccineId;
	}


	/**
	 * Sets the vaccine id.
	 *
	 * @param vaccineId the new vaccine id
	 */
	public void setVaccineId(String vaccineId) {
		this.vaccineId = vaccineId;
	}


	/**
	 * Instantiates a new booking vaccine info.
	 *
	 * @param userId the user id
	 * @param childId the child id
	 * @param vaccineId the vaccine id
	 */
	public BookingVaccineInfo(String userId, String childId, String vaccineId) {
		this.userId = userId;
		this.childId = childId;
		this.vaccineId = vaccineId;
	}

	/**
	 * Gets the dept id.
	 *
	 * @return the dept id
	 */
	public String getDeptId() {
		return deptId;
	}

	/**
	 * Sets the dept id.
	 *
	 * @param deptId the new dept id
	 */
	public void setDeptId(String deptId) {
		this.deptId = deptId;
	}
	
}
