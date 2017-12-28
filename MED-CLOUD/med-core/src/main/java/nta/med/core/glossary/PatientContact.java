package nta.med.core.glossary;

public enum PatientContact {

	EMAIL("0"),
	PHONE("1"),
	ALL("2");

	private String value;

	PatientContact(String value) {
		this.value = value;
	}

	public static PatientContact get(String value) {
		for (PatientContact flg : PatientContact.values()) {
			if (flg.value.equals(value))
				return flg;
		}
		return null;
	}

	public String getValue() {
		return value;
	}
}
