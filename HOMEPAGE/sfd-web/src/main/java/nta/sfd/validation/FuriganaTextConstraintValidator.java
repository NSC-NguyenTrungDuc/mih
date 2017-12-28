package nta.sfd.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

import org.apache.commons.lang.StringUtils;

/**
 * @author linh.nguyen.trong
 * 
 * The Class FuriganaTextConstraintValidator.
 */
public class FuriganaTextConstraintValidator implements
		ConstraintValidator<FuriganaText, String> {
	private static final String FURIGANA_CHAR = "^[\u3041-\u3093\u30A1-\u30F3]*$";
	
	@Override
	public void initialize(FuriganaText String) {
	}

	@Override
	public boolean isValid(String furiganaText, ConstraintValidatorContext cxt) {
		if (StringUtils.isNotBlank(furiganaText)) {
			return furiganaText.matches(FURIGANA_CHAR);
		}
		return true;
	}
}