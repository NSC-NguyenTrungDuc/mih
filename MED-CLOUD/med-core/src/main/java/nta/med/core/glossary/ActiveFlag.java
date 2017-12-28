package nta.med.core.glossary;

public enum ActiveFlag {

	/** The inactive. */
	INACTIVE("0"),

	/** The active. */
	ACTIVE("1");

	private String value;

	ActiveFlag(String value) {
		this.value = value;
	}

	public static ActiveFlag get(String value) {
		for (ActiveFlag flg : ActiveFlag.values()) {
			if (flg.value.equals(value))
				return flg;
		}
		return null;
	}

	public String getValue() {
		return value;
	}
}
