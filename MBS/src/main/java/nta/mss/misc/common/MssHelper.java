package nta.mss.misc.common;


/**
 * The Class MssHelper.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssHelper {
	
	/**
	 * Generate booking number.
	 * 
	 * @param prefixChar
	 *            the prefix char
	 * @param orgNumber
	 *            the org number
	 * @return the string
	 * @throws Exception
	 *             the exception
	 */
	public static String generateBookingNumber(String prefixChar, String orgNumber) throws Exception {
		if(orgNumber != null) {
			StringBuilder bookingNumber = new StringBuilder(prefixChar);
			Integer numberSize = MssConfiguration.getInstance().getBookingNumberSize();
			if(orgNumber.length() < numberSize - 1) {
				for(int i = 0; i < numberSize - 1 - orgNumber.length(); i ++) {
					bookingNumber.append("0"); 
				}
			}
			bookingNumber.append(orgNumber);
			return bookingNumber.toString();
		} 
		return "";
	}
	
	/**
	 * Generate random string.
	 *
	 * @param length the length
	 * @return the string
	 * @throws Exception the exception
	 */
	public static String generateRandomString(int length) throws Exception {

		StringBuffer buffer = new StringBuffer();
		String characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
		
		int charactersLength = characters.length();

		for (int i = 0; i < length; i++) {
			double index = Math.random() * charactersLength;
			buffer.append(characters.charAt((int) index));
		}
		return buffer.toString();
	}
}
