package nta.mss.misc.enums;

// TODO: Auto-generated Javadoc
/**
 * The Enum ReadingFlg.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum ReadingFlg {
	
	/** The unread. */
	UNREAD(0),
	
	/** The read. */
	READ(1);
	
	private Integer value;
	
	/**
	 * Instantiates a new reading flg.
	 * 
	 * @param value
	 *            the value
	 */
	private ReadingFlg(Integer value) {
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
	 * @return the reading flg
	 */
	public static ReadingFlg newInstance(Integer value) {
		for (ReadingFlg item : ReadingFlg.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
