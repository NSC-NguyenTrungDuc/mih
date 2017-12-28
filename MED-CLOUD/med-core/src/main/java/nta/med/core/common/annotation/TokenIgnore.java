package nta.med.core.common.annotation;

import java.lang.annotation.*;

/**
 * @author dainguyen.
 */
@Target({ElementType.METHOD, ElementType.TYPE, ElementType.PARAMETER})
@Retention(RetentionPolicy.RUNTIME)
@Inherited
@Documented
public @interface TokenIgnore {
    boolean authenticate() default false;

}