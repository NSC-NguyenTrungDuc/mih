package nta.mss.misc.common;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * The annotation for purpose of marking the method needs to be checked.
 * 
 * @author DinhNX
 * @CrtDate Jul 18, 2014
 */
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.METHOD)
public @interface SessionValidate {
	
	/**
	 * The Enum ValidationEnable.
	 * 
	 * @author DinhNX
	 * @CrtDate Jul 18, 2014
	 */
	public enum ValidationEnable {
		
		/** Enable. */
		ENABLE, 
		/** Disable. */
		DISABLE
	}
	
	/**
	 * Configure enable the validation.
	 */
	ValidationEnable enable() default ValidationEnable.ENABLE;
}
