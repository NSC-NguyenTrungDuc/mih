package nta.mss.misc.common;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class MssNumberUtils {

	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(MssNumberUtils.class);

	/** Add areacode to phonenumber */
	public static String StandardNumber(String phone, String locale) {
		String phoneNumber = new String();
		String checkPhone;
		switch (locale) {
		case "vi":
			checkPhone = checkNumber(phone);
			phoneNumber = "84" + checkPhone;
			break;
		case "en":
			checkPhone = checkNumber(phone);
			phoneNumber = "44" + checkPhone;
			break;

		case "ja":
			checkPhone = checkNumber(phone);
			phoneNumber = "81" + checkPhone;
			break;
		}
		return phoneNumber;
	}
	/** Delete first "0" in phonenumber */
	private static String checkNumber(String phone) {
		String phone2 = new String();
		if (phone.indexOf("0") == 0||phone.indexOf("+") == 0) {
			phone2 = phone.substring(1);
			return phone2;
		}
		return phone;
	}
	/** Check type of phone number*/
	public static String checkLocaleNumber(String phone) {
		String digit = phone.substring(0, 2);
		if(digit.equals("81")||digit.equals("84")||digit.equals("+8")){
			String phoneNumber = checkNumber(phone);
			return phoneNumber;
		}
		return null;
	}
	/** Auto fill auto fill 0 to patient code if length of patient code < 9 - With KCCK hospital*/
	public static String kcckPatientCode(String patientCode){
		String kcckPatientCode;
		try {
			kcckPatientCode = String.format("%09d", Integer.parseInt(patientCode));
		} catch (NumberFormatException e) {
			return patientCode;
		}
		return kcckPatientCode;
	}
	
	
}
