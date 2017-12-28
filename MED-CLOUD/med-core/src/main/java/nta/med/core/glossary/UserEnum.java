package nta.med.core.glossary;

public enum UserEnum {
	PFE("PFE");
	private String value;

	UserEnum(String value) {
		this.value = value;
	}

	public String getValue(){
		return value;
	}

}
