package nta.med.core.glossary;

public enum ModuleType {
	NURO("NURO"),
	OUTS("OUTS"),
	INJ("INJ");
	
	private String value;

	ModuleType(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
