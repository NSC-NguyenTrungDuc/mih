package nta.mss.misc.common;

import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import nta.mss.misc.enums.TokenValidationResult;
import nta.mss.model.SessionModel;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;

/**
 * The Utility class for token generating and validating.
 *
 * @author DinhNX
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
		String secretKey = MssConfiguration.getInstance().getSecretKey();
		String secretSpec = MssConfiguration.getInstance().getSecretSpec();
		StringBuilder tokenString = new StringBuilder();
		tokenString.append(uuid);
		tokenString.append(secretSpec);
		tokenString.append(timestamp);
		
		return EncryptionUtils.encrypt(tokenString.toString(), secretKey, 
				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
	}
	
	/**
	 * Generate register token.
	 *
	 * @param email the email
	 * @return the string
	 * @throws Exception the exception
	 */
	public static String generateRegisterToken(String email) throws Exception {
		long timestamp = System.currentTimeMillis();
		String secretKey = MssConfiguration.getInstance().getSecretKey();
		String secretSpec = MssConfiguration.getInstance().getSecretSpec();
		StringBuilder tokenString = new StringBuilder();
		tokenString.append(email);
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
			String secretKey = MssConfiguration.getInstance().getSecretKey();
			String secretSpec = MssConfiguration.getInstance().getSecretSpec();
			String decodedToken = EncryptionUtils.decrypt(token, secretKey, 
					EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
			// Empty or null decoded token then return invalid
			if (StringUtils.isBlank(decodedToken)) {
				return TokenValidationResult.INVALID;
			}
			String[] tokenValues = decodedToken.split(secretSpec);
			// The decoded token must be in predefine structure {email}{added_text}{timestamp} if not return invalid
			if (tokenValues.length != 2) {
				return TokenValidationResult.INVALID;
			}
			String tokenCreatedTime = tokenValues[1];
			// Timestamp is invalid
			if (!NumberUtils.isDigits(tokenCreatedTime)) {
				return TokenValidationResult.INVALID;
			}
//			Calendar expiredTime = Calendar.getInstance();
//			expiredTime.setTimeInMillis(Long.parseLong(tokenCreatedTime));
//			expiredTime.add(Calendar.HOUR_OF_DAY, 1);
//			// Return expired in case of it pass over 1 hour from timestamp
//			if (expiredTime.getTime().before(new Date())) {
//				return TokenValidationResult.EXPIRED;
//			}
			// Else return valid
			return TokenValidationResult.VALID;
		} else {
			return TokenValidationResult.INVALID;
		}
	}
	
	/**
	 * Validate token.
	 *
	 * @param session the session
	 * @return the token validation result
	 */
	public static TokenValidationResult validateToken(SessionModel session) {
		if (session == null || session.getExpired() == null) {
			return TokenValidationResult.INVALID;
		}
		if (session.getExpired().before(new Date())) {
				return TokenValidationResult.EXPIRED;
		}
		return TokenValidationResult.VALID;
	}
	
	public static String validateTokenAndCheckExpiredTime(String token) throws Exception {
		if (StringUtils.isNotBlank(token)) {
			String secretKey = MssConfiguration.getInstance().getSecretKey();
			String secretSpec = MssConfiguration.getInstance().getSecretSpec();
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
	
	/**
	 * Generate mail id token.
	 *
	 * @param mailId the mail id
	 * @return the string
	 * @throws Exception the exception
	 */
	public static String generateMailIdToken(List<String> mailIdList) throws Exception {
		String secretKey = MssConfiguration.getInstance().getSecretKey();
		String secretSpec = MssConfiguration.getInstance().getSecretSpec();
		StringBuilder tokenString = new StringBuilder();
		for (int i = 0; i < mailIdList.size(); i++){
			tokenString.append(mailIdList.get(i));
			if (i != mailIdList.size() - 1) {
				tokenString.append(secretSpec);
			}
		}
		return EncryptionUtils.encrypt(tokenString.toString(), secretKey, 
				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
	}
	
	/**
	 * Decode mail id token.
	 *
	 * @param token the token
	 * @return the string
	 * @throws Exception 
	 */
	public static String[] decodeMailIdToken(String token) throws Exception {
		String secretKey = MssConfiguration.getInstance().getSecretKey();
		String secretSpec = MssConfiguration.getInstance().getSecretSpec();
		String decodedToken = EncryptionUtils.decrypt(token, secretKey, 
				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
		return decodedToken.split(secretSpec);
	}
}
