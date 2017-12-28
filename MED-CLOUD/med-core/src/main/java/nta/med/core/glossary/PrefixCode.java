package nta.med.core.glossary;

public enum PrefixCode {
	MBS("MBS"), KCCK("KCCK");
	private String value;

	PrefixCode(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
