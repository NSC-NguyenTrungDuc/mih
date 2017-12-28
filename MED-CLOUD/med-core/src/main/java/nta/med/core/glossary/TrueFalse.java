package nta.med.core.glossary;

public enum TrueFalse {
	TRUE("true"), FALSE("false");
	private String value;

	TrueFalse(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
