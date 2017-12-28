package nta.sfd.validation;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author linh.nguyen.trong
 * 
 * The Class RegularExpressionValidateString.
 */
public class RegularExpressionValidateString {

	/**
	 * Regular expression validate.
	 *
	 * @param strValidate the str validate
	 * @param pattern the pattern
	 * @return true, if successful
	 */
	public boolean regularExpressionValidate(String strValidate, Pattern pattern) {

		Matcher mtch = pattern.matcher(strValidate);
		if (mtch.matches()) {
			return true;
		}
		return false;
	}
}
