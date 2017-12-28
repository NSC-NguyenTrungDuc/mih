package nta.med.orca.gw.glossary;

public enum CommonEnum {
	T("T"),
	
	ACCT_ORCA("ACCT_ORCA"),
	ORCA_IP("ORCA_IP"),
	ORCA_PORT("ORCA_PORT"),
	ORCA_USER("ORCA_USER"),
	ORCA_PWD("ORCA_PWD");
	
	private String value;
	
	CommonEnum(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
