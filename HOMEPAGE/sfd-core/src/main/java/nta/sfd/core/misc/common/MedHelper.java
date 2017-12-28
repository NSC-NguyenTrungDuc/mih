package nta.sfd.core.misc.common;


/**
 * The Class MedHelper.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MedHelper {
	
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
