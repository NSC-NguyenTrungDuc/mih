package nta.med.core.glossary;

public enum GubunFlag {
	ONE("1"), TWO("2"), THREE("3");
	private String value;

	GubunFlag(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
