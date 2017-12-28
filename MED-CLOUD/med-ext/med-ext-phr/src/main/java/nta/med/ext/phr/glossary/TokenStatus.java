package nta.med.ext.phr.glossary;

public enum TokenStatus {

	EXPIRED(0), VALID(1);

	private Integer value;

	private TokenStatus(Integer value) {
		this.value = value;
	}

	public Integer getValue() {
		return value;
	}
}
