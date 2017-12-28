package nta.mss.interceptor;

import javax.persistence.Column;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.servlet.LocaleResolver;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.i18n.LocaleChangeInterceptor;
import org.springframework.web.servlet.support.RequestContextUtils;

import nta.kcck.service.impl.KcckDepartmentService;
import nta.mss.controller.BookingController;
import nta.mss.info.BookingInfo;
import nta.mss.info.HospitalDto;
import nta.mss.info.ScheduleInfo;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.BookingMode;
import nta.mss.service.IHospitalService;
import nta.mss.service.IHospitalTrackingService;
import nta.mss.service.impl.HospitalTrackingService;

/**
 * The Class MssLocaleInterceptor.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MssLocaleInterceptor extends LocaleChangeInterceptor {
	
	@Autowired
	private IHospitalService hospitalService;
	@Autowired
	private IHospitalTrackingService hospitalTrackingService;
	private static final Logger LOG = LogManager.getLogger(MssLocaleInterceptor.class);
	
	private KcckDepartmentService kcckDepartmentService = new KcckDepartmentService();

	private Cookie createCookie(String cookieName, String cookieValue) {
		Cookie cookie = new Cookie(cookieName, cookieValue);
		cookie.setPath("/");
		cookie.setMaxAge(72*60*60);
		//cookie.set(true);
		cookie.setSecure(true);
		return cookie;
	}
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
		String tokenHospCode = request.getParameter("tokenHospCode");
		if(MssContextHolder.getTokenHospCode() == null && !Strings.isEmpty(tokenHospCode))
		{
			response.addCookie(createCookie("tokenHospCode", tokenHospCode));
		}

		boolean result = super.preHandle(request, response, handler);

		LOG.info("URL: " + request.getRequestURL().toString() + "?" + request.getQueryString());
		LOG.info("tokenHospCode: " + tokenHospCode);
		LOG.info("MssContextHolder.getTokenHospCode(): " + MssContextHolder.getTokenHospCode());
		if(StringUtils.isBlank(MssContextHolder.getTokenHospCode()) && StringUtils.isBlank(tokenHospCode)){
			Cookie cookie[]=request.getCookies();
			Cookie cook;

			if (cookie != null) {
				for (int i = 0; i < cookie.length; i++) {
					cook = cookie[i];
					if(cook.getName().equalsIgnoreCase("tokenHospCode"))
					{
						tokenHospCode = cook.getValue();
						break;
					}
				}
			}
		}
		//If no hopital in session and no tokenHospCode is present, redirect to portal page
		if(StringUtils.isBlank(MssContextHolder.getTokenHospCode()) && StringUtils.isBlank(tokenHospCode)){
			return this.redirectToPotal(response);
		}
		if(!StringUtils.isBlank(tokenHospCode)){
			if(StringUtils.isBlank(MssContextHolder.getTokenHospCode()) || !tokenHospCode.equals(MssContextHolder.getTokenHospCode())){
				LOG.info("Need to update hopital information");
				//Clear session
				HttpSession session = request.getSession(false);
				if (session != null) {
					session.invalidate();
				}
				SecurityContextHolder.clearContext();
				//start get hospital information
				String hospCode = "";
				try {
					hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(), 
							EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
					if(StringUtils.isEmpty(hospCode)){
						return this.redirectToPotal(response);
					}
				} catch (Exception e) {
					e.printStackTrace();
				}
 				HospitalDto hospital = this.hospitalService.getHospitalModelByHospitalCode(hospCode);
				if(hospital == null){
					return this.redirectToPotal(response);
				}
				
				
				if (CollectionUtils.isEmpty(MssContextHolder.getTrackingScript()) ){
					MssContextHolder.setTrackingScript(hospitalTrackingService.getTrackingCodeByHospitalCode(hospital.getHospitalId()));
				}
				LOG.info("New hopital information: " + hospital.toString());
				
				MssContextHolder.setHospitalId(hospital.getHospitalId());
				MssContextHolder.setHospitalName(hospital.getHospitalName());
				MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
				MssContextHolder.setTokenHospCode(tokenHospCode);
				MssContextHolder.setHospCode(hospCode);
				MssContextHolder.setUserLanguage(hospital.getLocale());
				MssContextHolder.setHospitalLocale(hospital.getLocale());
				MssContextHolder.setHospitalEmail(hospital.getEmail());
				MssContextHolder.setTimeZone(hospital.getTimeZone());
				MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());
				MssContextHolder.setIsUseVaccine(hospital.getIsUseVaccine()== null? 0: hospital.getIsUseVaccine());
				MssContextHolder.setIsUseMt(hospital.getIsUseMt());				
				MssContextHolder.setHospital(hospital);
				MssContextHolder.setBookingInfo(new BookingInfo());
				
				MssContextHolder.setScheduleInfo(new ScheduleInfo());

				MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
				MssContextHolder.setKcckDepartmentList(kcckDepartmentService.getListDepartment(hospCode, hospital.getLocale()));
				request.getSession().setAttribute("isHide", MssContextHolder.isKcck());
			}
		}
		//Priority locale from request param
		String locale = request.getParameter(this.getParamName());
		if (StringUtils.isBlank(locale)) {//If does not have locale on param, get local of hopital
			locale = MssContextHolder.getUserLanguage();
			if(StringUtils.isBlank(locale)){//if hospital does not have locale => set default is language
				locale = MssContextHolder.DEFAULT_USER_LANGUAGE;
			}

		}
		MssContextHolder.setUserLanguage(locale);
		LocaleResolver localeResolver = RequestContextUtils.getLocaleResolver(request);
		if (localeResolver == null) {
			throw new IllegalStateException("No LocaleResolver found: not in a DispatcherServlet request?");
		}
		localeResolver.setLocale(request, response, org.springframework.util.StringUtils.parseLocaleString(locale));
		return result;
	}

	private boolean redirectToPotal(HttpServletResponse response){
		response.setStatus(HttpServletResponse.SC_MOVED_PERMANENTLY);
		try {
			response.setHeader("Location", MssConfiguration.getInstance().getPortalUrl());
		} catch (Exception e) {
			e.printStackTrace();
		}
		return false;
	}
}
