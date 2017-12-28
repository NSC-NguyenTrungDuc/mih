package nta.mss.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

import org.apache.commons.lang.StringUtils;

public class CheckSpecialConstraintValidator implements
		ConstraintValidator<CheckSpecialChar, String> {
	private static final String CHAR_NOT_SPECIAL = "^[a-zA-Z_0-9]*$";
	
	@Override
	public void initialize(CheckSpecialChar String) {
	}

	@Override
	public boolean isValid(String str, ConstraintValidatorContext cxt) {
		if (StringUtils.isNotBlank(str)) {
			return str.matches(CHAR_NOT_SPECIAL);
		}
		return true;
	}
}