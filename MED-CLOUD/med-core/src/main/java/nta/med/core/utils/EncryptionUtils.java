/**
 * 
 */
package nta.med.core.utils;

import java.nio.charset.Charset;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

import org.apache.commons.codec.binary.Base64;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author DEV-HuanLT
 *
 */
public class EncryptionUtils {
	
	private static MessageDigest md;
	
	/** The Constant LOG. */
	private static final Log LOG = LogFactory.getLog(DateUtil.class);
	
	/** The Constant ENCODING_UTF8. */
	private static final String ENCODING_UTF8 = "UTF-8";
	
	/** The Constant ENCRYPT_ALGORITHM_AES. */
	public static final String ENCRYPT_ALGORITHM_AES = "AES";
	
	/** The Constant ENCRYPT_TRANSFORMATION_AES_CBC_PADDING. */
	public static final String ENCRYPT_TRANSFORMATION_AES_CBC_PADDING = "AES/CBC/PKCS5PADDING";

	/**
	 * Encrypt.
	 *
	 * @param value the value
	 * @param secretKey the secret key
	 * @param algorithm the algorithm
	 * @param transformation the transformation
	 * @return the string
	 */
	public static String encrypt(String value, String secretKey, String algorithm, String transformation) {
		try {
			SecretKeySpec skeySpec = new SecretKeySpec(secretKey.getBytes(), algorithm);
			Cipher cipher = Cipher.getInstance(transformation);
			cipher.init(Cipher.ENCRYPT_MODE, skeySpec, new IvParameterSpec(new byte[16]));
			byte[] encrypted = cipher.doFinal(value.getBytes(Charset.forName(ENCODING_UTF8)));
			return Base64.encodeBase64URLSafeString(encrypted);
		} catch (Exception ex) {
			LOG.warn("Error when encrypt token key", ex);
			return null;
		}

	}

	/**
	 * Decrypt.
	 *
	 * @param value the value
	 * @param secretKey the secret key
	 * @param algorithm the algorithm
	 * @param transformation the transformation
	 * @return the string
	 */
	public static String decrypt(String value, String secretKey, String algorithm, String transformation) {
		if (!StringUtils.isEmpty(value)) {
			try {
				SecretKeySpec skeySpec = new SecretKeySpec(secretKey.getBytes(), algorithm);
				Cipher cipher = Cipher.getInstance(transformation);
				cipher.init(Cipher.DECRYPT_MODE, skeySpec, new IvParameterSpec(new byte[16]));
				byte[] original = cipher.doFinal(Base64.decodeBase64(value.getBytes()));

				return new String(original, Charset.forName(ENCODING_UTF8));
			} catch (Exception ex) {
				//LOG.warn("Error when decrypt token key", ex);
				LOG.warn("DECRYPT_WARN!!! Data input encrypted string invalid !!!, input=" + value + ", DECRYPTION FAIL!!!" + ex.getMessage());
				return "";
			}
		}
		return "";	
	}
	
	/**
	 * Crypt with md5.
	 *
	 * @param pass the pass
	 * @return the string
	 */
	public static String cryptWithMD5(String pass) {
		try {
			md = MessageDigest.getInstance("MD5");
			byte[] passBytes = pass.getBytes();
			md.reset();
			byte[] digested = md.digest(passBytes);
			StringBuffer sb = new StringBuffer();
			for (int i = 0; i < digested.length; i++) {
				int halfbyte = (digested[i] >>> 4) & 0x0F;
				int two_halfs = 0;
				do {
					if ((0 <= halfbyte) && (halfbyte <= 9)) {
						sb.append((char) ('0' + halfbyte));
					} else {
						sb.append((char) ('a' + (halfbyte - 10)));
					}
					halfbyte = digested[i] & 0x0F;
				} while (two_halfs++ < 1);
			}
			return sb.toString();
		} catch (NoSuchAlgorithmException ex) {
			LOG.warn("No algorithm found.", ex);
		}
		return null;
	}
}
