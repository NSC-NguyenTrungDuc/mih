package nta.med.core.glossary;

public enum InOutType {
	OUT("O"), IN("I");
	private String value;

	InOutType(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
