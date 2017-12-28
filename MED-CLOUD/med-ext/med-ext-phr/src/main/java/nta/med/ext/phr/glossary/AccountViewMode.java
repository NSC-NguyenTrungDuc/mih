package nta.med.ext.phr.glossary;

public enum AccountViewMode {
	VIEW_MODEL_BABY_BG(0), 
	VIEW_MODEL_STANDARD_BG(1);

	private Integer value;

	private AccountViewMode(Integer value) {
		this.value = value;
	}

	public Integer getValue() {
		return value;
	}
}
