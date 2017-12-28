package nta.med.ext.phr.glossary;

import java.math.BigDecimal;

/**
 * @author DEV-TiepNM
 */
public class Constant {
	
	public static String PHR_PATH_VERIFY = "accounts/verify/";
	public static String PHR_VERIFY_METHOD = "verifyAccount";
	
	public static String MAIL_TYPE_CONFIRM_REGISTER = "CONFIRM_REGISTER";
	public static String MAIL_TYPE_RESET_PASSWORD = "CONFIRM_RESET_PASSWORD";
	public static String MAIL_TYPE_SEND_PASSWORD = "SEND_PASSWORD";
	
	public static BigDecimal BABY_FLG_INACTIVE = new BigDecimal(0);
	public static BigDecimal BABY_FLG_ACTIVE = new BigDecimal(1);
	
	public static BigDecimal SYNC_FLG_INACTIVE = new BigDecimal(0);
	public static BigDecimal SYNC_FLG_ACTIVE = new BigDecimal(1);

	public static BigDecimal PROFILE_FLG_INACTIVE = new BigDecimal(0);
	public static BigDecimal PROFILE_FLG_ACTIVE = new BigDecimal(1);

	public static String PERSONAL_FAMILY = "PERSONAL";
	public static String MEMBER_FAMILY = "MEMBER";
	
	public static String HOSP_CODE_DEFAULT = "NTA"; 
	public static String HOSP_NAME_DEFAULT = "NTA";
	
	public static String PREFIX_USER_NAME = "PHR_COM_";
	
	public static String JA_LOCALE = "JA";
	public static String EN_LOCALE = "EN";
	
	public static String NTA = "NTA";

	public static String PHR ="PHR";
	
	public static String ICON_USER_IMG = "icon-user.png";
	public static String ICON_LOCK_IMG = "icon-lock.png";
	public static String ICON_LOCK_OPEN_IMG = "icon-lock-open.png";
}
