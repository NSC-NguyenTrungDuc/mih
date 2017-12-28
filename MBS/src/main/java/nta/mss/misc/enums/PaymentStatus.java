package nta.mss.misc.enums;

public enum PaymentStatus {
	/*Payment state pending */
	REQUESTING(5),
	/*Payment state inprogess */
	INPROGESS(6),
	/*Payment state success */
	FINISHED(1),
	/*Payment state failed */
	FORCE_CANCEL(4),
	CANCEL(7),
	FAILED(2),
	FORCE_FINISHED(3),
	AUTHORIZATION(8),
	OTHER_ERROR(9)
	;
	private Integer value;
	
	private PaymentStatus(Integer value)
	{
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
	public static PaymentStatus newInstance(Integer value) {
		for (PaymentStatus item : PaymentStatus.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
