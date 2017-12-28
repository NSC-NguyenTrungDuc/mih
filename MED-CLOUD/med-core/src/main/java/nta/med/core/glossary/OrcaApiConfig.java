package nta.med.core.glossary;

public enum OrcaApiConfig {

	API_RESULT_SUCCESS("00"),
	API_ACCEPT_MOD_SUCCESS_W1("K1"),
	API_ACCEPT_MOD_SUCCESS_W2("K2"),
	API_ACCEPT_MOD_SUCCESS_W3("K3"),
	API_ACCEPT_MOD_SUCCESS_W4("K4"),
	API_ACCEPT_MOD_SUCCESS_W5("K5"),
	
	PATIENT_MOD_NEW("01"),
	PATIENT_MOD_UPDATE_INFO("02"),
	PATIENT_MOD_DELETE("03"),
	PATIENT_MOD_UPDATE_INS("04"),
	
	ACCEPT_NEW("01"),
	ACCEPT_DELETE("02"),
	
	ELEMENT_TYPE_RECORD("record"),
	ELEMENT_TYPE_ARRAY("array"),
	
	PATIENT_CODE_DEFAULT("00000000*"),
	PATIENT_CODE_CREATE_NEW("*"),
	
	PHONE_TYPE_1("1"),
	PHONE_TYPE_2("2"),
	PHONE_TYPE_3("3"),
	PHONE_TYPE_4("4"),
	PHONE_TYPE_5("5"),
	
	SEX_MALE("1"),
	SEX_FEMALE("2")
	;
	
	private String value;

	OrcaApiConfig(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
