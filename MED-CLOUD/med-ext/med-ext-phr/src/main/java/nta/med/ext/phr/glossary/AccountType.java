package nta.med.ext.phr.glossary;

/**
 * @author DEV-TiepNM
 */
public enum AccountType {
	NEW_REGISTER(0),
    CLIENT_REQUEST(1),
    RESET_PASSWORD(2);

    private Integer value;

    private AccountType(Integer value) {
        this.value = value;
    }
    public Integer getValue(){
        return value;
    }
}
