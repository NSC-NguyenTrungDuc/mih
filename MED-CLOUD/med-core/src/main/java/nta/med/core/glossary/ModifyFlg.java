package nta.med.core.glossary;

public enum ModifyFlg {

	READ("R"), INSERT("I"), UPDATE("U"), DELETE("D");

	private String value;

	ModifyFlg(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
