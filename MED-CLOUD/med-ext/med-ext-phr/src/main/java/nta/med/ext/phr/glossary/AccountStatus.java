package nta.med.ext.phr.glossary;

public enum AccountStatus {
	DEACTIVE(0), ACTIVE(1);

	private Integer value;

	private AccountStatus(Integer value) {
		this.value = value;
	}

	public Integer getValue() {
		return value;
	}
}
