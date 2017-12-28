package nta.sfd.core.misc.common;

import java.io.Serializable;
import java.util.Locale;

// TODO: Auto-generated Javadoc
/**
 * The Class MedSessionContext.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MedSessionContext implements Serializable {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 3570571102529580094L;
	
	/** The user language. */
	private String userLanguage;
	
	/** The locale. */
	private Locale locale;
	
	/** The session mode. */
	private Integer sessionMode;
	
	/**
	 * Gets the user language.
	 * 
	 * @return the user language
	 */
	public String getUserLanguage() {
		return userLanguage;
	}
	
	/**
	 * Sets the user language.
	 * 
	 * @param userLanguage
	 *            the new user language
	 */
	public void setUserLanguage(String userLanguage) {
		this.userLanguage = userLanguage;
	}
	
	/**
	 * Gets the locale.
	 * 
	 * @return the locale
	 */
	public Locale getLocale() {
		return locale;
	}
	
	/**
	 * Sets the locale.
	 * 
	 * @param locale
	 *            the new locale
	 */
	public void setLocale(Locale locale) {
		this.locale = locale;
	}
	
	/**
	 * Gets the session mode.
	 * 
	 * @return the session mode
	 */
	public Integer getSessionMode() {
		return sessionMode;
	}
	
	/**
	 * Sets the session mode.
	 * 
	 * @param sessionMode
	 *            the new session mode
	 */
	public void setSessionMode(Integer sessionMode) {
		this.sessionMode = sessionMode;
	}
	
	/**
	 * Removes the session mode.
	 */
	public void removeSessionMode() {
		this.sessionMode = null;
	}
}
