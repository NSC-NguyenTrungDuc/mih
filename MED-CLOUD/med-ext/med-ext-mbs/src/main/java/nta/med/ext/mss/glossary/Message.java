package nta.med.ext.mss.glossary;

/**
 * @author DEV-TiepNM
 */
public enum Message {
	
	// booking message key
	RESERVATION_DATE_INVALID("reservation.date.invalid"), 
	BIRTH_DATE_INVALID("birth.date.invalid"), 
	SURNAME1_REQUIRED("surname1.required"), 
	SURNAME2_REQUIRED("surname2.required"),
	// survey message key
	PATIENT_SURVEY_NOT_FOUND("patient.survey.not.found"),
	SURVEY_NOT_FOUND("survey.not.found"),
	SURVEY_QUESTION_GROUP_NOT_FOUND("survey.question.group.not.found"),
	SURVEY_QUESTION_NOT_FOUND("survey.question.not.found"),
	ANSWER_QUESTION_NOT_FOUND("answer.question.not.found"),

	//verify account
	VERIFY_ACCOUNT_SUCCESS_CODE("00"),
	VERIFY_ACCOUNT_SUCCESS_MSG("verify.account.success"),
	VERIFY_ACCOUNT_FAIL_CODE("30"),
	VERIFY_ACCOUNT_FAIL_MSG("verify.account.fail"),
	
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
