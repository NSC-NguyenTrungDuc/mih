package nta.mss.misc.navigation;

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
		BOOKING_VACCINEE_STEPS,
		/** The doctor view menu*/
		DOCTOR_VIEW_MENU
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
		
		/** The online booking new. */
		ONLINE_BOOKING_NEW,
		
		/** The online reexamine. */
		REEXAMINE,
		
		/** The reexamine. */
		ONLINE_REEXAMINE,
		BOOKING_NEW_PARENT,
		RE_BOOKING_PARENT,
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
		
		/** The default schedule of department. */
		DEFAULT_SCHEDULE_DEPARTMENT,
		/** The mail template. */
		TEMPLATE,
		
		/** The mail template. */
		MAIL_TEMPLATE,
		
		/** The sms template. */
		SMS_TEMPLATE,
		
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
		VACCINE_RECOMMENDATION,
		
		/** The hospital management.*/
		HOSPITAL_MANAGEMENT,
		
		/** The hospital management.*/
		CRM_MANAGEMENT,
		/** The Doctor movie talk.*/
		MOVIES_TALK,
		/** The Doctor profile heath.*/
		PERSONAL_HEATH,
		/** The Doctor profile info.*/
		PROFILE_INFO,
		/** The Doctor body measurement.*/
		BODY_MEASUREMENT,
		/** The Doctor vital.*/
		VITAL,
		/** The Doctor fitness.*/
		FITNESS,
		/** The Doctor food.*/
		FOOD,
		/** The Doctor sleep.*/
		SLEEP,
		/** The Doctor movie talk history.*/
		MOVIE_TALK_HISTORY,
		/** The Patient movie talk history.*/
		PATIENT_MOVIE_TALK_HISTORY,
		/** The Payment history.*/
		PAYMENT_HISTORY,
		BACK_PAYMENT_HISTORY
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
