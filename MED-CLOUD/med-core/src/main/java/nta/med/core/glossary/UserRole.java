package nta.med.core.glossary;

public enum UserRole {
	SUPER_ADMIN("0"), NORMAL_ADMIN("1"), ANONYMOUS("2");
	private String value;

	UserRole(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
