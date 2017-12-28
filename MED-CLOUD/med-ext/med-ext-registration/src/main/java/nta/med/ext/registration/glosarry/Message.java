package nta.med.ext.registration.glosarry;

/**
 * @author DEV-TiepNM
 */
public enum Message {

	MESSAGE_REQUEST_INPUT_FAIL("fail.input"),
	EMAIL_INVALID("fail.email_invalid"),
	CLINIC_INVALID("fail.clinic_invalid"),
	EMAIL_HAS_EXISTED("fail.email_has_existed"),
	RECAPCHA_VERIFY_FAIL("fail.recapcha_verify_fail"),
	TELEPHONE_INVALID("fail.telephone_invalid"),
	ADDRESS_INVALID("fail.address_invalid"),
	MESSAGE_SUCCESS("message.success"),
	SUCCESS("1"), FAIL("0");

	private String value;

	Message(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
