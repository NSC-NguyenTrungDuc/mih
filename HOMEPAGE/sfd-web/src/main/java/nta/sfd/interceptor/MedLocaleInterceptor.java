package nta.sfd.interceptor;

import nta.sfd.common.MedContextHolder;
import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.LocaleResolver;
import org.springframework.web.servlet.i18n.LocaleChangeInterceptor;
import org.springframework.web.servlet.support.RequestContextUtils;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * The Class MedLocaleInterceptor.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MedLocaleInterceptor extends LocaleChangeInterceptor {
	
	/**
	 * Handle the locale change request.
	 * 
	 * @param request
	 *            the request
	 * @param response
	 *            the response
	 * @param handler
	 *            the handler
	 * @return true, if successful
	 * @throws ServletException
	 *             the servlet exception
	 */
	public boolean preHandle(HttpServletRequest request, HttpServletResponse response, Object handler) throws ServletException {
		boolean result = super.preHandle(request, response, handler);
		String locale = request.getParameter(this.getParamName());
		if (StringUtils.isBlank(locale)) {
			locale = MedContextHolder.getUserLanguage();
			if (StringUtils.isBlank(locale)) {
				locale = MedContextHolder.DEFAULT_USER_LANGUAGE;
				MedContextHolder.setUserLanguage(locale);
			}
			LocaleResolver localeResolver = RequestContextUtils.getLocaleResolver(request);
			if (localeResolver == null) {
				throw new IllegalStateException("No LocaleResolver found: not in a DispatcherServlet request?");
			}
			localeResolver.setLocale(request, response, org.springframework.util.StringUtils.parseLocaleString(locale));
		} else {
			MedContextHolder.setUserLanguage(locale);
		}
		
		return result;
	}
}
