package nta.med.core.glossary;

/**
 * @author dainguyen.
 */
public enum SessionAttribute {
     PRIVILEGE("PRIVILEGE"),  SESSION_USER_INFO("SESSION_USER_INFO");

    private String value;

    SessionAttribute(String value) {
        this.value = value;
    }
}
