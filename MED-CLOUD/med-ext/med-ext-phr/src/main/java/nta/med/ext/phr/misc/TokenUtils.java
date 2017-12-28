package nta.med.ext.phr.misc;

import java.util.Calendar;
import java.util.Date;
import java.util.UUID;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;

import nta.med.ext.phr.glossary.TokenValidationResult;

/**
 * The Utility class for token generating and validating.
 *
 * @author MinhLS
 * @CrtDate Jul 15, 2014
 */
public class TokenUtils {
	/**
	 * Generate token from email and timestamp.
	 *
	 * @param email the email
	 * @param timestamp the timestamp
	 * @return the string
	 * @throws Exception the exception
	 */
	public static String generateToken() throws Exception {
		String uuid = UUID.randomUUID().toString();
		long timestamp = System.currentTimeMillis();
		String secretKey = MedConfiguration.getInstance().getSecretKey();
		String secretSpec = MedConfiguration.getInstance().getSecretSpec();
		StringBuilder tokenString = new StringBuilder();
		tokenString.append(uuid);
		tokenString.append(secretSpec);
		tokenString.append(timestamp);
		
		return EncryptionUtils.encrypt(tokenString.toString(), secretKey, 
				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
	}
	
	/**
	 * Validate token: <br />
	 * - return INVALID if token is not in predefined structure <br />
	 * - return EXPIRED if over 1 hour from created time <br />
	 * - else return VALID .
	 * 
	 * @param token
	 *            the token
	 * @return the token validation result
	 * @throws Exception
	 *             the exception
	 */
	public static TokenValidationResult validateToken(String token) throws Exception {
		if (StringUtils.isNotBlank(token)) {
			String secretKey = MedConfiguration.getInstance().getSecretKey();
			String secretSpec = MedConfiguration.getInstance().getSecretSpec();
			String decodedToken = EncryptionUtils.decrypt(token, secretKey, 
					EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
			// Empty or null decoded token then return invalid
			if (StringUtils.isBlank(decodedToken)) {
				return TokenValidationResult.INVALID;
			}
			String[] tokenValues = decodedToken.split(secretSpec);
			// The decoded token must be in predefine structure {uuid}{secretSpec}{timestamp} if not return invalid
			if (tokenValues.length != 2) {
				return TokenValidationResult.INVALID;
			}
			String tokenCreatedTime = tokenValues[1];
			// Timestamp is invalid
			if (!NumberUtils.isDigits(tokenCreatedTime)) {
				return TokenValidationResult.INVALID;
			}
			Calendar expiredTime = Calendar.getInstance();
			expiredTime.setTimeInMillis(Long.parseLong(tokenCreatedTime));
			expiredTime.add(Calendar.MINUTE, Integer.parseInt(MedConfiguration.getInstance().getMailExpiredTime()));
			// Return expired in case of it pass over xx minute from configuration file
			if (expiredTime.getTime().before(new Date())) {
				return TokenValidationResult.INVALID;
			}
			return TokenValidationResult.VALID;
		} else {
			return TokenValidationResult.INVALID;
		}
	}
	
	public static String validateTokenAndCheckExpiredTime(String token) throws Exception {
		if (StringUtils.isNotBlank(token)) {
			String secretKey = MedConfiguration.getInstance().getSecretKey();
			String secretSpec = MedConfiguration.getInstance().getSecretSpec();
			String decodedToken = EncryptionUtils.decrypt(token, secretKey, 
					EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
			// Empty or null decoded token then return invalid
			if (StringUtils.isBlank(decodedToken)) {
				return null;
			}
			String[] tokenValues = decodedToken.split(secretSpec);
			// The decoded token must be in predefine structure {email}{added_text}{timestamp} if not return invalid
			if (tokenValues.length != 2) {
				return null;
			}
			String tokenCreatedTime = tokenValues[1];
			// Timestamp is invalid
			if (!NumberUtils.isDigits(tokenCreatedTime)) {
				return null;
			}
			Calendar expiredTime = Calendar.getInstance();
			expiredTime.setTimeInMillis(Long.parseLong(tokenCreatedTime));
			expiredTime.add(Calendar.HOUR_OF_DAY, 1);
			// Return expired in case of it pass over 1 hour from timestamp
			if (expiredTime.getTime().before(new Date())) {
				return null;
			}
			// Else return email
			return tokenValues[0];
		} else {
			return null;
		}
	}
}
