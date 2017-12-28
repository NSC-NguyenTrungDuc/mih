package nta.sfd.misc.navigation;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * The annotation for navigation.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@Retention(RetentionPolicy.RUNTIME)
@Target({ElementType.TYPE, ElementType.METHOD})
public @interface NavigationConfig {
	
	/**
	 * The Enum NavigationType.
	 * 
	 * @author DinhNX
	 * @CrtDate Jul 23, 2014
	 */
	public enum NavigationType {
		
		/** The none. */
		NONE,
		
		/** The front left menu. */
		FRONT_LEFT_MENU,
		
		/** The back left menu. */
		BACK_LEFT_MENU,
		
		/** The booking steps. */
		BOOKING_STEPS, 
		
		/** The change steps. */
		CHANGE_STEPS,
		
		/** The booking vaccine steps. */
		BOOKING_VACCINEE_STEPS
	}
	
	/**
	 * The Enum NavigationGroup.
	 * 
	 * @author DinhNX
	 * @CrtDate Jul 23, 2014
	 */
	public enum NavigationGroup {
		
		/** The none. */
		NONE,
		// Left menu
		/** The top service. */
		TOP_SERVICE,
		
		/** The booking new. */
		BOOKING_NEW,
		
		/** The reexamine. */
		REEXAMINE,
		
		/** The edit booking. */
		EDIT_BOOKING,
		
		/** The pending status. */
		PENDING_STATUS,
		
		// Booking steps
		/** The choose department. */
		CHOOSE_DEPARTMENT,
		
		/** The choose time. */
		CHOOSE_TIME,
		
		/** The input info. */
		INPUT_INFO,
		
		/** The confirm. */
		CONFIRM,
		
		/** The temp schedule. */
		TEMP_SCHEDULE,
		
		/** The finish schedule. */
		FINISH_SCHEDULE,
		
		// Change steps
		/** The change choose time. */
		CHANGE_CHOOSE_TIME,
		
		/** The change confirm. */
		CHANGE_CONFIRM,
		
		/** The change accept. */
		CHANGE_ACCEPT,
		
		/** The change complete. */
		CHANGE_COMPLETE,
		
		// Back-end left menu
		/** The manage reservation. */
		MANAGE_RESERVATION,
		
		/** The search reservation. */
		SEARCH_RESERVATION,
		
		/** The schedule management. */
		SCHEDULE_MANAGEMENT,
		
		/** The input department doctor. */
		INPUT_DEPARTMENT_DOCTOR,
		
		/** The column settings. */
		COMA_SETTINGS,
		
		/** The comma register change. */
		COMA_REGISTER_CHANGE,
		
		/** The schedule mail history. */
		SCHEDULE_MAIL_HISTORY,
		
		/** The mail template. */
		MAIL_TEMPLATE,
		
		/** The reminder mail. */
		REMINDER_MAIL,
		
		/** The mailing list. */
		MAILING_LIST,
		
		/** The mail history. */
		MAIL_HISTORY,
		
		/** The user management. */
		USER_MANAGEMENT,
		
		/** The vaccine management. */
		VACCINE_MANAGEMENT,
		
		/** The vaccine list. */
		VACCINE_LIST,
		
		/** The vaccine report. */
		VACCINE_REPORT,
		
		/** The account customer management. */
		ACCOUNT_MANAGEMENT,
		
		// The booking vaccine step.
		/** Contact information confirm. */
		VACCINE_RECOMMENDATION
	}
	
	/**
	 * Left menu type.
	 */
	NavigationType leftMenuType() default NavigationType.NONE;
	
	/**
	 * Step type.
	 */
	NavigationType stepType() default NavigationType.NONE;
	
	/**
	 * Group - add all groups that the request in.
	 */
	NavigationGroup[] group() default NavigationGroup.NONE;
}
