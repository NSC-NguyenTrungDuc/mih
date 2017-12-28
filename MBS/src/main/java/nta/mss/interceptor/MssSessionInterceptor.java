package nta.mss.interceptor;

import java.lang.annotation.Annotation;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.web.method.HandlerMethod;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.handler.HandlerInterceptorAdapter;
import org.springframework.web.servlet.view.RedirectView;

import nta.mss.controller.BookingController;
import nta.mss.misc.common.MSSSession;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.common.SessionValidate.ValidationEnable;
import nta.mss.misc.common.TokenManager;
import nta.mss.misc.enums.SessionMode;

/**
 * The interceptor class to validate booking session.
 * Only check the methods in {@link BookingController} with {@link SessionValidate} annotation.
 * 
 * @author DinhNX
 * @CrtDate Jul 18, 2014
 */
public class MssSessionInterceptor extends HandlerInterceptorAdapter {
	private static final Logger LOG = LogManager.getLogger(MssSessionInterceptor.class);
	
	/** The fallback url. */
	private final String DOCTOR_URL= "(.*)/doctor/(.*)";
	private final String FALLBACK_URL = "../booking/index";
	private final String FRONT_BOOKING_URL_PATTERN = "(.*)/booking/(.*)";

	private TokenManager<MSSSession> cache;

	//private static final Integer DEFAULT_HOSPITAL_ID = 1;
	
	/**
	 *  Check the request if the booking info is existed in session or not.
	 *  If not, redirect to fall-back URL.
	 *
	 * @param request the request
	 * @param response the response
	 * @param handler the handler
	 * @return true, if successful
	 * @throws Exception the exception
	 */
	@Override
	public boolean preHandle(HttpServletRequest request, HttpServletResponse response, Object handler) throws Exception {
		if (!(handler instanceof HandlerMethod)) {
			return true;
		}

		if (request.getRequestURI().matches(FRONT_BOOKING_URL_PATTERN)) {
			MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		} else {
			MssContextHolder.setSessionMode(SessionMode.BACK_MODE.toInt());
		}
//		if(request.getRequestURI().matches(DOCTOR_URL))
//		{
//			MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
//			String token = request.getParameter("token");
//			if(StringUtils.isEmpty(token) || cache.get(token) == null)
//			{
//				return false;
//			}
//
//		}
		boolean cont = false;
		HandlerMethod handlerMethod = (HandlerMethod) handler;
		Annotation[] annotations = handlerMethod.getMethod().getAnnotations();
		for (Annotation annotation : annotations) {
			if (annotation instanceof SessionValidate) {
				cont = ((SessionValidate) annotation).enable().equals(ValidationEnable.ENABLE);
				break;
			}
		}
		if (cont) {
			if (MssContextHolder.getBookingInfo() == null) {
				LOG.info("Booking info is null.");
				response.sendRedirect(FALLBACK_URL);
			}
		} else {
			if (MssContextHolder.getHospitalId() == null) {
				//MssContextHolder.setHospitalId(DEFAULT_HOSPITAL_ID);
			}
		}
		return true;
	}
	
	public void postHandle(HttpServletRequest request, HttpServletResponse response, Object handler, ModelAndView modelAndView)
			throws Exception {
		if (modelAndView == null || modelAndView.getView() instanceof RedirectView) {
			return;
		}
		if (StringUtils.isNotBlank(MssContextHolder.getHospitalName())) {
			modelAndView.getModelMap().addAttribute("hospitalId", MssContextHolder.getHospitalId());
			modelAndView.getModelMap().addAttribute("hospitalName", MssContextHolder.getHospitalName());
		}
		if(StringUtils.isNotBlank(MssContextHolder.getHospitalIconPath())){
			modelAndView.getModelMap().addAttribute("hospitalIconPath", MssContextHolder.getHospitalIconPath());
		}

	}

	public TokenManager<MSSSession> getCache() {
		return cache;
	}

	public void setCache(TokenManager<MSSSession> cache) {
		this.cache = cache;
	}
}
