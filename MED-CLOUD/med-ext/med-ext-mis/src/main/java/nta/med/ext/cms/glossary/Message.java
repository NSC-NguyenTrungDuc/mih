package nta.med.ext.cms.glossary;

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
	PATIENT_SURVEY_IN_COMPLETE("patient.survey.in.complete"),
	SURVEY_NOT_FOUND("survey.not.found"),
	SURVEY_QUESTION_GROUP_NOT_FOUND("survey.question.group.not.found"),
	SURVEY_QUESTION_NOT_FOUND("survey.question.not.found"),
	ANSWER_QUESTION_NOT_FOUND("answer.question.not.found"),
	SURVEY_USED("can.not.delete.survey.used"),
	PATIENT_NOT_FOUND("patient.not.found"),
	
	HOSP_CODE_INVALID("hospital.code.invalid"),

	QUESTION_INVALID("question.invalid"),
	QUESTION_HAS_AT_LEAST_ANSWER("question.has_at_least_answer"),
	CREATE_SURVEY_QUESTION_GROUP_REQUIRED("survey.question.group.required"),
	CREATE_SURVEY_QUESTION_REQUIRED("survey.question.required"),
	SURVEY_ANSWER_QUESTION_GROUP_REQUIRED("survey.answer.question.group.required"),
	SURVEY_ANSWER_QUESTION_IN_GROUP_REQUIRED("survey.answer.question.in.group.required"),
	SURVEY_ANSWER_ANSWER_IN_QUESTION_REQUIRED("survey.answer.answer.in.question.required"),
	SURVEY_ANSWER_QUESTION_GROUP_NOT_EXIST("survey.answer.question.group.not.exist"),
	SURVEY_ANSWER_QUESTION_NOT_EXIST("survey.answer.question.not.exist"),
	SURVEY_ANSWER_ANSWER_NOT_EXIST("answer.answer.answer.not.exist"),
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
