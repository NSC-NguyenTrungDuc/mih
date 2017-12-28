package nta.sfd.common;

import nta.sfd.core.misc.common.MedSessionContext;
import org.apache.commons.lang.StringUtils;
import org.springframework.web.context.request.RequestAttributes;
import org.springframework.web.context.request.RequestContextHolder;

import java.util.Locale;

/**
 * The class to access the data in session.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MedContextHolder {
	
	/** The Constant DEFAULT_USER_LANGUAGE. */
	public static final String DEFAULT_USER_LANGUAGE = "ja";
	
	/** The Constant MED_SESSION_CONTEXT. */
	public static final String MED_SESSION_CONTEXT = "MED_CONTEXT";
	
	/**
	 * Current session context.
	 * 
	 * @return the med session context
	 */
	public static MedSessionContext currentSessionContext() {
		MedSessionContext sessionContext = (MedSessionContext) RequestContextHolder
				.currentRequestAttributes().getAttribute(MED_SESSION_CONTEXT, RequestAttributes.SCOPE_SESSION);
		
		if (sessionContext == null) {
			sessionContext = new MedSessionContext();
			RequestContextHolder.currentRequestAttributes().setAttribute(MED_SESSION_CONTEXT, sessionContext, RequestAttributes.SCOPE_SESSION);
		}
		return sessionContext;
	}
	
	/**
	 * Sets the session mode.
	 * 
	 * @param sessionMode
	 *            the new session mode
	 */
	public static void setSessionMode(Integer sessionMode) {
		currentSessionContext().setSessionMode(sessionMode);
	}
	
	/**
	 * Gets the session mode.
	 * 
	 * @return the session mode
	 */
	public static Integer getSessionMode() {
		return currentSessionContext().getSessionMode();
	}
	
	/**
	 * Sets the user language.
	 * 
	 * @param userLanguage
	 *            the new user language
	 */
	public static void setUserLanguage(String userLanguage) {
		MedSessionContext medContext = currentSessionContext();
		medContext.setUserLanguage(userLanguage);
		medContext.setLocale(org.springframework.util.StringUtils.parseLocaleString(userLanguage));
	}
	
	/**
	 * Gets the user language.
	 * 
	 * @return the user language
	 */
	public static String getUserLanguage() {
		MedSessionContext medContext = currentSessionContext();
		String lang = medContext.getUserLanguage();
		if (StringUtils.isBlank(lang)) {
			return DEFAULT_USER_LANGUAGE;
		} else {
			return lang;
		}
	}
	
	/**
	 * Gets the locale.
	 * 
	 * @return the locale
	 */
	public static Locale getLocale() {
		MedSessionContext medContext = currentSessionContext();
		String lang = medContext.getUserLanguage();
		if (StringUtils.isBlank(lang)) {
			return org.springframework.util.StringUtils.parseLocaleString(DEFAULT_USER_LANGUAGE);
		} else {
			return org.springframework.util.StringUtils.parseLocaleString(lang);
		}
	}
}
