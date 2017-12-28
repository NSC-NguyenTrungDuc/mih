package nta.med.core.glossary;

public enum OrderGubun {
	C("C"), D("D"), K("K"), B("B");

	private String value;

	OrderGubun(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
