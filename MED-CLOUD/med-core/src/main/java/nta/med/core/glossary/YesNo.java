package nta.med.core.glossary;

public enum YesNo {
	YES("Y"), NO("N"), OTHER("2");
	private String value;

	YesNo(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
