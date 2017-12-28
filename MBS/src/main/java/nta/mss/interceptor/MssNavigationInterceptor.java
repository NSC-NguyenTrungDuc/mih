package nta.mss.interceptor;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.ArrayUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.method.HandlerMethod;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.handler.HandlerInterceptorAdapter;

import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.BookingMode;
import nta.mss.misc.navigation.Navigation;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.misc.navigation.NavigationItem;

/**
 * The navigation interceptor use for configuring the navigation of the system.
 * Use {@link NavigationConfig} annotation to configure the controller.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 *
 */
public class MssNavigationInterceptor extends HandlerInterceptorAdapter {
	@Autowired
	private Navigation navigation;

	/**
	 * Post handle.
	 * 
	 * @param request
	 *            the request
	 * @param response
	 *            the response
	 * @param handler
	 *            the handler
	 * @param modelAndView
	 *            the model and view
	 */
	public void postHandle(HttpServletRequest request, HttpServletResponse response, Object handler,
			ModelAndView modelAndView) {
		if (navigation == null || navigation.getNavigationsList() == null || navigation.getNavigationsList().isEmpty()
				|| modelAndView == null || !(handler instanceof HandlerMethod)) {
			return;
		}

		HandlerMethod handlerMethod = (HandlerMethod) handler;
		Method method = handlerMethod.getMethod();
		NavigationConfig classNavAnnotation = null;
		NavigationConfig methodNavAnnotation = null;

		Annotation[] classAnnotations = method.getDeclaringClass().getAnnotations();
		Annotation[] methodAnnotations = method.getAnnotations();
		for (Annotation annotation : classAnnotations) {
			if (annotation instanceof NavigationConfig) {
				classNavAnnotation = (NavigationConfig) annotation;
				break;
			}
		}

		for (Annotation annotation : methodAnnotations) {
			if (annotation instanceof NavigationConfig) {
				methodNavAnnotation = (NavigationConfig) annotation;
				break;
			}
		}
		String urIRequest = request.getRequestURI();
		byte isUseMovieTalk = MssContextHolder.getIsUseMt();
		List<NavigationItem> leftMenu = this.resolveLeftMenu(classNavAnnotation, methodNavAnnotation, urIRequest);
		List<NavigationItem> breadcrumb = this.resolveBreadcrumb(methodNavAnnotation);
		// Reset state movietalk navigation
		resetStateHideOnShowMovieTalk(leftMenu);
		if (isUseMovieTalk == 1) {
			leftMenu = resolveHideOnShowMovieTalk(leftMenu);
		}
		if (classNavAnnotation!=null && classNavAnnotation.leftMenuType() == NavigationType.DOCTOR_VIEW_MENU) {
			String mode = MssContextHolder.getMode();
			List<NavigationItem> leftMenuNew = new ArrayList<>();
			for (NavigationItem item : leftMenu) {
				if (item.getChildren() == null) {
						if (!item.getLink().equals("/doctor/movies-talk") || (item.getLink().equals("/doctor/movies-talk")&&!mode.equals("3")))
							leftMenuNew.add(item);
				} else {
					List<NavigationItem> itemChildNew = new ArrayList<>();
					List<NavigationItem> itemChild = item.getChildren();
					NavigationItem itemNew = item;
					if (mode.equals("3")) {
						for (NavigationItem temp : itemChild) {
							if (temp.getLink().equals("/doctor/movietalk-history"))
								continue;
							itemChildNew.add(temp);
						}
						itemNew.setChildren(itemChildNew);
					}
					leftMenuNew.add(itemNew);

				}
			}
			if (!leftMenuNew.isEmpty()) {
				modelAndView.addObject("leftMenuItems", leftMenuNew);
			}
		} else {
			if (!leftMenu.isEmpty()) {
				modelAndView.addObject("leftMenuItems", leftMenu);
			}
		}

		if (!breadcrumb.isEmpty()) {
			modelAndView.addObject("breadcrumb", breadcrumb);
		}
	}

	/**
	 * Reset state movie talk navigation
	 * 
	 * @author TungLT
	 */
	private List<NavigationItem> resetStateHideOnShowMovieTalk(List<NavigationItem> leftMenu) {
		List<NavigationItem> result = new ArrayList<>();
		for (NavigationItem item : leftMenu) {
			if (item.getChildren() != null) {
				List<NavigationItem> childList = new ArrayList<>();
				for (NavigationItem child : item.getChildren()) {
					if (child.getLink().equals("/booking/online-booking-new")
							|| child.getLink().equals("/booking/online-re-examination")) {
						child.setNotIsMovieTalk(true);
					}
					childList.add(child);
				}
				item.setChildren(childList);
			}
			result.add(item);
		}
		return result;
	}

	/**
	 * Resolve Menu Item where set hide by movie talk or not
	 * 
	 * @author TungLT
	 */
	private List<NavigationItem> resolveHideOnShowMovieTalk(List<NavigationItem> leftMenu) {
		List<NavigationItem> result = new ArrayList<>();
		for (NavigationItem item : leftMenu) {
			if (item.isNotIsMovieTalk()) {
				item.setNotIsMovieTalk(false);
			}
			if (item.getChildren() != null) {
				List<NavigationItem> childNew = resolveHideOnShowMovieTalk(item.getChildren());
				item.setChildren(childNew);
			}
			result.add(item);
		}
		return result;
	}

	/**
	 * Get and configure the breadcrumb.
	 * 
	 * @param methodNavAnnotation
	 *            the method navigation annotation
	 * @return the list
	 */
	private List<NavigationItem> resolveBreadcrumb(NavigationConfig methodNavAnnotation) {
		List<NavigationItem> breadcrumb = new ArrayList<NavigationItem>();

		if (methodNavAnnotation != null) {
			NavigationType breadcrumbType = methodNavAnnotation.stepType();
			List<NavigationItem> navItems = navigation.getNavigationsList().get(breadcrumbType);
			if (!breadcrumbType.equals(NavigationType.NONE) && navItems != null) {
				for (NavigationItem item : navItems) {
					item.setActive(ArrayUtils.contains(methodNavAnnotation.group(), item.getGroup()));
					breadcrumb.add(item);
				}
			}
		}

		return breadcrumb;
	}

	/**
	 * Get and configure the left menu.
	 * 
	 * @param classNavAnnotation
	 *            the class navigation annotation
	 * @param methodNavAnnotation
	 *            the method navigation annotation
	 * @return the list
	 */
	private List<NavigationItem> resolveLeftMenu(NavigationConfig classNavAnnotation,
			NavigationConfig methodNavAnnotation, String urIRequest) {
		List<NavigationItem> leftMenu = new ArrayList<NavigationItem>();
		if (classNavAnnotation != null) {
			NavigationType leftMenuType = classNavAnnotation.leftMenuType();
			List<NavigationItem> navItems = navigation.getNavigationsList().get(leftMenuType);
			if (!leftMenuType.equals(NavigationType.NONE) && navItems != null) {
				for (NavigationItem item : navItems) {
					if (methodNavAnnotation == null && urIRequest.equals("/mss-web/booking/login")) {
						if (!(item.getChildren() == null || item.getChildren().isEmpty())) {
							for (NavigationItem child : item.getChildren()) {
								child.setActive(false);
							}
						}
					}
					if (methodNavAnnotation != null) {
						if (leftMenuType == NavigationType.FRONT_LEFT_MENU) {
							this.resolveChildrenBooking(item, methodNavAnnotation, urIRequest);
						} else {
							this.resolveChildren(item, methodNavAnnotation);
						}

					}
					NavigationItem newItem = new NavigationItem(item);
					if (methodNavAnnotation != null) {
						NavigationGroup[] groupsToCheck = { NavigationGroup.EDIT_BOOKING,
								NavigationGroup.PENDING_STATUS, NavigationGroup.TOP_SERVICE,
								NavigationGroup.MOVIES_TALK };
						boolean isContain = ArrayUtils.contains(methodNavAnnotation.group(), newItem.getGroup());
						if (isContain) {
							newItem.setActive(isContain);
						} else if (!this.containsAny(methodNavAnnotation.group(), groupsToCheck)) {
							if (BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())
									|| BookingMode.NEW_BOOKING_ONLINE.toInt()
											.equals(MssContextHolder.getReservationMode())) {
								newItem.setActive(newItem.getGroup().equals(NavigationGroup.BOOKING_NEW_PARENT));
							} else if (BookingMode.RE_EXAMINATION_ONLINE.toInt()
									.equals(MssContextHolder.getReservationMode())
									|| BookingMode.RE_EXAMINATION.toInt()
											.equals(MssContextHolder.getReservationMode())) {
								newItem.setActive(newItem.getGroup().equals(NavigationGroup.RE_BOOKING_PARENT));
							}
						}
					}
					leftMenu.add(newItem);
				}
			}
		}
		return leftMenu;
	}

	/**
	 * @author TungLT
	 * @param navItem
	 * @param methodNavAnnotation
	 * @param urIRequest
	 */
	private void resolveChildrenBooking(NavigationItem navItem, NavigationConfig methodNavAnnotation,
			String urIRequest) {
		if (navItem.getChildren() == null || navItem.getChildren().isEmpty()) {
			return;
		}

		for (NavigationItem child : navItem.getChildren()) {
			child.setActive(ArrayUtils.contains(methodNavAnnotation.group(), child.getGroup())
					&& urIRequest.contains(child.getLink()));
			String urlLink[] = { "/mss-web/booking/booking-new", "/mss-web/booking/online-booking-new",
					"/mss-web/booking/re-examination", "/mss-web/booking/online-re-examination",
					"/mss-web/booking/index", "/mss-web/booking/authorized-email", "/mss-web/booking/pending-status",
					"/mss-web/movie-talk/index","/mss-web/movie-talk/movietalk-history" ,"/mss-web/payment-history/index" };
			boolean checkContainlink = ArrayUtils.contains(urlLink, urIRequest);
			if (!checkContainlink) {
				if (BookingMode.NEW_BOOKING.toInt().equals(MssContextHolder.getReservationMode())) {
					child.setActive(child.getGroup().equals(NavigationGroup.BOOKING_NEW));
				}

				else if (BookingMode.NEW_BOOKING_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
					child.setActive(child.getGroup().equals(NavigationGroup.ONLINE_BOOKING_NEW));
				}

				else if (BookingMode.RE_EXAMINATION.toInt().equals(MssContextHolder.getReservationMode())) {
					child.setActive(child.getGroup().equals(NavigationGroup.REEXAMINE));
				}

				else if (BookingMode.RE_EXAMINATION_ONLINE.toInt().equals(MssContextHolder.getReservationMode())) {
					child.setActive(child.getGroup().equals(NavigationGroup.ONLINE_REEXAMINE));
				}
				;
			}

		}
	}

	private void resolveChildren(NavigationItem navItem, NavigationConfig methodNavAnnotation) {
		if (navItem.getChildren() == null || navItem.getChildren().isEmpty()) {
			return;
		}

		for (NavigationItem child : navItem.getChildren()) {
			child.setActive(ArrayUtils.contains(methodNavAnnotation.group(), child.getGroup()));
		}
	}

	private boolean containsAny(NavigationGroup[] groupsToFind, NavigationGroup[] groupsArray) {
		for (NavigationGroup group : groupsArray) {
			if (ArrayUtils.contains(groupsToFind, group)) {
				return true;
			}
		}
		return false;
	}
}
