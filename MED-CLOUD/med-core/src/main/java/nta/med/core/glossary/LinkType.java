package nta.med.core.glossary;

public enum LinkType {
	KCCK("KCCK"), PHR("PHR");
	private String value;

	LinkType(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
