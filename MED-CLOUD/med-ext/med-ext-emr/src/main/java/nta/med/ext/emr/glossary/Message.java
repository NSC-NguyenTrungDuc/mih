package nta.med.ext.emr.glossary;

/**
 * @author DEV-TiepNM
 */
public enum Message {
	MESSAGE_SUCCESS("message.success"), 
	MESSAGE_FAIL("message.fail"), 
	MESSAGE_TOKEN_INVALID("token.invalid"),
	MESSAGE_REQUEST_INPUT_FAIL("fail.input"),
	SUCCESS("1"), FAIL("0");

	private String value;

	Message(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
