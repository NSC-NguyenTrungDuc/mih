package nta.mss.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

import org.apache.commons.lang.StringUtils;

public class EmailConstraintValidator implements
		ConstraintValidator<Email, String> {
	private static final String EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
	
	@Override
	public void initialize(Email String) {
	}

	@Override
	public boolean isValid(String emailField, ConstraintValidatorContext cxt) {
		if (StringUtils.isNotBlank(emailField)) {
			return emailField.matches(EMAIL_PATTERN);
		}
		return true;
	}
}