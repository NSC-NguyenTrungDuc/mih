package nta.mss.misc.enums;

/**
 * The Enum TokenValidationResult.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum TokenValidationResult {
	
	/** Valid. */
	VALID	(0, ""),
	
	/** Invalid. */
	INVALID	(1, "general.token.invalid"),
	
	/** Expired. */
	EXPIRED	(2, "general.token.expired");
	
	private Integer resultCode;
	private String messageKey;
	
	/**
	 * Instantiates a new token validation result.
	 * 
	 * @param resultCode
	 *            the result code
	 * @param messageKey
	 *            the message key
	 */
	private TokenValidationResult(Integer resultCode, String messageKey) {
		this.resultCode = resultCode;
		this.messageKey = messageKey;
	}
	
	/**
	 * From int.
	 * 
	 * @param resultCode
	 *            the result code
	 * @return the token validation result
	 */
	public static TokenValidationResult fromInt(Integer resultCode) {
		for (TokenValidationResult result : TokenValidationResult.values()) {
			if (result.toInt().equals(resultCode)) {
				return result;
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
		return this.resultCode;
	}
	
	/**
	 * Gets the message key.
	 * 
	 * @return the message key
	 */
	public String getMessageKey() {
		return this.messageKey;
	}
}
