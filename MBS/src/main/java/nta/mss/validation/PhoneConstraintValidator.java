package nta.mss.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

import org.apache.commons.lang.StringUtils;

/**
 * @author linh.nguyen.trong
 * 
 * The Class PhoneConstraintValidator.
 */
public class PhoneConstraintValidator implements
		ConstraintValidator<Phone, String> {
	
	public static final String PHONE_FORMAT = "^[0-9()-+]*$";
	
	@Override
	public void initialize(Phone String) {
	}

	@Override
	public boolean isValid(String phoneField, ConstraintValidatorContext cxt) {
		if (StringUtils.isNotBlank(phoneField)) {
			return phoneField.matches(PHONE_FORMAT);
		}
		return true;
	}
}