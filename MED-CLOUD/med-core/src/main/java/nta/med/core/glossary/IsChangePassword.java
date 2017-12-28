package nta.med.core.glossary;

public enum IsChangePassword {
	TRUE("1"), FALSE("0");
	private String value;

	IsChangePassword(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
