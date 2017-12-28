package nta.med.core.glossary;

public enum EmrTemplateClassify {

	ADM("1"), DEPT("2"), USER("3");

	private String value;

	EmrTemplateClassify(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
