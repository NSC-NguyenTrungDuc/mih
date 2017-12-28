package nta.med.core.glossary;

public enum SeqName {
	OUT0101_SEQ("OUT0101_SEQ");
	
	private String value;

	SeqName(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
