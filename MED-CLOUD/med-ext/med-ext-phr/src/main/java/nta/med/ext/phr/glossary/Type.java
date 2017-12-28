package nta.med.ext.phr.glossary;

public enum Type {
	FIRST_LOGIN(0), NORMAL_ACTIVE(1);

	private Integer value;

	private Type(Integer value) {
		this.value = value;
	}

	public Integer getValue() {
		return value;
	}
}
